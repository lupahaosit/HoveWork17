using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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

namespace HoveWork17
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        OleDbDataAdapter oleDbData;
        DataTable dt2;
       
        
        public Window2()
        {
            InitializeComponent();
            
           

        }
        public Window2(string x) : this()
        {

            OleDbConnectionStringBuilder oleDbConnection = new OleDbConnectionStringBuilder()
            {
                DataSource = @"Database3.mdb",
                Provider = "Microsoft.Jet.OLEDB.4.0"



            };
            OleDbConnection connection = new OleDbConnection(oleDbConnection.ConnectionString);

            
            var cmdText =$@"Select Cod, objectName from ObjectsInfo Where (Email  = " + "'"  + x + "')";

            oleDbData = new OleDbDataAdapter(cmdText, connection);
            dt2 = new DataTable();
            oleDbData.Fill(dt2);
            DG.DataContext = dt2.DefaultView;
        }
       



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
