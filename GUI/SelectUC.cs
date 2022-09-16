using System.Diagnostics;

using Data;

namespace GUI
{
    public partial class SelectUC : UserControl
    {
        public SelectUC()
        {
            InitializeComponent();
        }

        private ImageDAO DAO => DIContainer.Get<ImageDAO>();
        private CancellationTokenSource cts = null;

        private async Task LoadAll()
        {
            var name = GetTime();
            try
            {
                cts = new CancellationTokenSource();
                var token = cts.Token;
                loadAllButton.Enabled = false;
                cancelLoadingButton.Enabled = true;
                var items = await DAO.LoadAllAsync(token);  //takes 1m 31s to execute in SSMS
                Trace.WriteLine($"Loaded {items.Count} items, total size: {items.Sum(i => i.Data.Length / 1024*1024)} MB");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.GetType() + ex.Message);
            }
            finally
            {
                Trace.WriteLine($"Operation was really cancelled at {GetTime()}");
                cts.Dispose();
                cts = null;
                loadAllButton.Enabled = true;
                cancelLoadingButton.Enabled = false;
            }
        }

        private void Cancel()
        {
            cts.Cancel();
        }


        private string GetTime() => DateTime.Now.ToString("HH:mm:ss.fff");

        private async void loadAllButton_Click(object sender, EventArgs e)
        {
            await LoadAll();
        }

        private void cancelLoadingButton_Click(object sender, EventArgs e)
        {
            Trace.WriteLine($"Operation cancel request submitted at {GetTime()}");
            Cancel();
        }
    }
}
