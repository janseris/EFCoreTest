using GUI;

namespace EFCoreTest
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Add(new InsertUC(), 0, 0);
        }
    }
}