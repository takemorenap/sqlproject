using System;
using System.Data;
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
using MySql.Data.MySqlClient;


namespace sqlprj
{
    /// <summary>
    /// TeaClient.xaml 的交互逻辑
    /// </summary>
    public partial class TeaClient : Window
    {
        public TeaClient()
        {
            InitializeComponent();
        }

        private MySqlDataAdapter adp;
        private DataTable table = null;
        private MySqlCommandBuilder cb;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.user == "root")
                adp = new MySqlDataAdapter("select * from o", MainWindow.connection);
            else
                adp = new MySqlDataAdapter(string.Format("select * from o where gh='{0}'", MainWindow.user), MainWindow.connection);
            table = new DataTable();
            adp.Fill(table);
            mygrid.ItemsSource = table.DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MainWindow.user == "root")
                adp = new MySqlDataAdapter("select * from e", MainWindow.connection);
            else
                adp = new MySqlDataAdapter(string.Format("select * from e where gh='{0}'", MainWindow.user), MainWindow.connection);
            table = new DataTable();
            adp.Fill(table);
            mygrid.ItemsSource = table.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            adp = new MySqlDataAdapter("select * from s", MainWindow.connection);
            table = new DataTable();
            adp.Fill(table);
            mygrid.ItemsSource = table.DefaultView;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                cb = new MySqlCommandBuilder(adp);
                adp.Update(table);
                table.AcceptChanges();
                MessageBox.Show("更新完成!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"更新失败!");
            }
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            mygrid.ItemsSource = null;
        }
    }
}
