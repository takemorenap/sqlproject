using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace sqlprj
{
    /// <summary>
    /// StuClient.xaml 的交互逻辑
    /// </summary>
    public partial class StuClient : Window
    {
        public StuClient()
        {
            InitializeComponent();
        }
        private MySqlDataAdapter adpl,adpr;
        private DataTable tableleft = null , tableright = null;
        private MySqlCommandBuilder cb;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            qr.Visibility = Visibility.Visible;
            adpr = new MySqlDataAdapter(string.Format("select xh,xq,kh,gh from e where xh='{0}'", MainWindow.user), MainWindow.connection);
            tableright = new DataTable();
            adpr.Fill(tableright);
            gridright.ItemsSource = tableright.DefaultView;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            gridleft.ItemsSource = null;
            gridright.ItemsSource = null;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            qr.Visibility = Visibility.Hidden;
            adpr = new MySqlDataAdapter(string.Format("select t.xm,t.gh,c.km ,c.kh,e.zpcj from c,e,t where c.kh=e.kh and e.xh='{0}' and t.gh=e.gh", MainWindow.user), MainWindow.connection);
            tableright = new DataTable();
            adpr.Fill(tableright);
            gridright.ItemsSource = tableright.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            adpl = new MySqlDataAdapter("select * from o", MainWindow.connection);
            tableleft = new DataTable();
            adpl.Fill(tableleft);
            gridleft.ItemsSource = tableleft.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                cb = new MySqlCommandBuilder(adpr);
                adpr.Update(tableright);
                tableright.AcceptChanges();
                MessageBox.Show("更新完成!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "更新失败!");
            }
        }
    }
}
