using QBankingSystemv2._0.Interfaces;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Forms
{
    public partial class Account : Form
    {
        public Account(IAccount account)
        {
            InitializeComponent();
        }
    }
}
