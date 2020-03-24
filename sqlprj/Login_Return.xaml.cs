using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace sqlprj
{
    /// <summary>
    /// Login_Return.xaml 的交互逻辑
    /// </summary>
    public partial class Login_Return : Window
    {
        public Login_Return()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.login_success)
            {
                if (MainWindow.is_stu)
                {
                    StuClient stu = new StuClient();
                    stu.Show();

                }
                else
                {
                    TeaClient tea = new TeaClient();
                    tea.Show();
                }
                Close();
            }
            else
            {
                Close();
                
            }
        }
    }
}
