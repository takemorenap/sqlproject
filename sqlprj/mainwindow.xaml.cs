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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace sqlprj
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string sql = "";
        public static MySqlConnection connection;
        public static bool is_stu = false, login_success = false;
        public static string user = "";
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            user = username.Text.Clone().ToString();
            sql = string.Format("server=localhost;User Id={0};password={1};Database=school", username.Text, password.Password);
            connection = new MySqlConnection(sql);
            try
            {
                connection.Open();
                MessageBox.Show(string.Format("登陆成功 , {0} !", username.Text), "登陆成功");
                login_success = true;
                if (username.Text != "root" && username.Text != "0101")
                    is_stu = true;
                if (is_stu)
                {
                    StuClient stu = new StuClient();
                    stu.Show();

                }
                else
                {
                    TeaClient tea = new TeaClient();
                    tea.Show();
                }
                //@return.Show();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "登陆失败");
            }
        }
    }
}
