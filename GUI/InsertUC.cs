using System.Diagnostics;

using Data;

using Microsoft.Data.SqlClient;

using Microsoft.EntityFrameworkCore;

namespace GUI
{
    public partial class InsertUC : UserControl
    {
        public InsertUC()
        {
            InitializeComponent();
            insertButtons.Add(insert100Button);
            insertButtons.Add(insert20Button);
        }

        private readonly byte[] LargeData = File.ReadAllBytes("../../../sampleData/100MB.zip");
        private readonly byte[] MediumData = File.ReadAllBytes("../../../sampleData/20MB.zip");

        private readonly List<Button> insertButtons = new List<Button>();

        private ImageDAO DAO => DIContainer.Get<ImageDAO>();
        private CancellationTokenSource cts = null;

        private async Task Insert(byte[] data)
        {
            var name = GetTime();
            try
            {
                cts = new CancellationTokenSource();
                var token = cts.Token;
                insertButtons.ForEach(b => b.Enabled = false);
                cancelInsertingButton.Enabled = true;
                int ID = await DAO.InsertAsync(name, data, token);
                Trace.WriteLine($"Inserted. ID = {ID}");
            }
            catch (DbUpdateException ex)
            {
                //when cancelling while uploading data to DB, DbUpdateException with inner InvalidOperationException is thrown
                Trace.WriteLine($"---{ex.GetType()}");
                if (ex.InnerException is InvalidOperationException)
                {
                    Trace.WriteLine("The operation was cancelled during uploading the data to DB.");
                }
            }
            catch (OperationCanceledException ex)
            {
                //happens when TaskCanceledException is thrown when cancelling while connection is being established
                //this is between "Opening connection to database 'devRemin' on server 'neon.tempus-admin.eu'." and "Opened connection to database 'devRemin' on server 'neon.tempus-admin.eu'."
                //this can be simulated by clicking the button just after EF DLLs are loaded
                //(but this is only achievable on first connection attempt in application lifetime - for first attempt it takes ~700 ms
                //but for any subsequent attempt, it takes only ~2 ms)
                Trace.WriteLine($"---{ex.GetType()}");
                Trace.WriteLine($"Operation was really cancelled at {GetTime()}");
            }
            catch (SqlException ex)
            {
                Trace.WriteLine($"---{ex.GetType()}");
                Trace.WriteLine(
                    $"SqlException class: {ex.Class} number: {ex.Number} " +
                    Environment.NewLine + $"message: {ex.Message}");
                //1) happens automatically for SqlConnection not reaching SQL Server at all within timeout
                //(result: SqlException class: 20 number: 53)
                //(default is 15 seconds, works precisely. Can be customized in connection string)
                //takes exactly 15 seconds also for all subsequent offline attemps on Windows
                //(on MAUI Android, there is probably a different TCP/SSL provider, all subsequent attempts usually fail almost instantly)

                //2)  class: 11 number: -2 "Execution Timeout Expired.  The timeout period elapsed prior to completion of the operation or the server is not responding."
                //when a connection from the pool (established previously online) is reused (and connected successfully!) but actually internet is off
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"---{ex.GetType()}");

                //1) InvalidOperationException with internal DbUpdateException with inner SqlException with TCP provider error 0
                //happens when switching off internet connection while a long DbCommand is being executed
                //happens e.g. when offline for 40 seconds (the duration is random)
            }
            finally
            {
                cts.Dispose();
                cts = null;
                insertButtons.ForEach(b => b.Enabled = true);
                cancelInsertingButton.Enabled = false;
            }
        }

        private async void insert100Button_Click(object sender, EventArgs e)
        {
            await Insert(LargeData);
        }

        private async void insert20Button_Click(object sender, EventArgs e)
        {
            await Insert(MediumData);
        }

        private void Cancel()
        {
            cts.Cancel();
        }

        private void cancelInsertingButton_Click(object sender, EventArgs e)
        {
            Trace.WriteLine($"Operation cancel request submitted at {GetTime()}");
            Cancel();
        }


        private string GetTime() => DateTime.Now.ToString("HH:mm:ss.fff");
    }
}
