using QBankingSystemv2._0.Forms;
using System.Threading;
using System.Windows.Forms;

namespace QBankingSystemv2._0
{
    public partial class StartFrom : Form
    {
        public StartFrom()
        {
            InitializeComponent();
            Thread thread = new Thread(OpenWelcomeForm);
            thread.Start();
        }

        private void OpenWelcomeForm()
        {
            Thread.Sleep(10000);
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();
        }
    }
}
