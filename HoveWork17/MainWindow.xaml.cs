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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HoveWork17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dataTable;
        SqlDataAdapter adapter;
        DataRowView dataRow;
        OleDbDataAdapter DataAdapter;

        DataSet ds;
        DataTable dt;

        public MainWindow()
        {
            InitializeComponent();
            Preparing();
            OledbPreparing();

        }
        private void Preparing()
        {
            dataTable = new DataTable();
            adapter = new SqlDataAdapter();

            #region init
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"MSSQLLocalDB",
                IntegratedSecurity = true,
                UserID = "Admin",
                Password = "Admin",
                Pooling = true
            };
            string x = connectionStringBuilder.ConnectionString;
            
            SqlConnection sqlConnection = new SqlConnection() { ConnectionString = x };
            #endregion

            #region Select
            var sql = @"Select * from InfoTable Order by InfoTable.Id ";
            adapter.SelectCommand = new SqlCommand(sql, sqlConnection);
            #endregion

            #region Insert
            sql = @"Insert Into InfoTable (Surname,WorkerNAME, LASTNAME, NUMBER, EMAIL)
                                           VALUES (@Surname, @WorkerNAME, @LASTNAME, @NUMBER, @EMAIL);
                                    SET @Id = @@IDENTITY;";      

            adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
            adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
            adapter.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
            adapter.InsertCommand.Parameters.Add("@WorkerNAME", SqlDbType.NVarChar, 20, "WorkerNAME");
            adapter.InsertCommand.Parameters.Add("@LASTNAME", SqlDbType.NVarChar, 20, "LASTNAME");
            adapter.InsertCommand.Parameters.Add("@NUMBER", SqlDbType.Int, 11, "NUMBER");
            adapter.InsertCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 20, "EMAIL");
            #endregion

            #region Update
            sql = @"Update InfoTable Set
                        Surname = @Surname,
                       WorkerNAME = @WorkerNAME,
                        LASTNAME = @LASTNAME,
                        NUMBER = @NUMBER,
                        EMAIL = @EMAIL
                    Where Id = @Id";
            adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
            adapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
            adapter.UpdateCommand.Parameters.Add("@WorkerNAME", SqlDbType.NVarChar, 20, "WorkerNAME");
            adapter.UpdateCommand.Parameters.Add("@LASTNAME", SqlDbType.NVarChar, 20, "LASTNAME");
            adapter.UpdateCommand.Parameters.Add("@NUMBER", SqlDbType.Int, 11, "NUMBER");
            adapter.UpdateCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 20, "EMAIL");
            #endregion

            #region Delete
            sql = "Delete From InfoTable where Id = @Id";
            adapter.DeleteCommand = new SqlCommand(sql, sqlConnection);
            adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            #endregion

            adapter.Fill(dataTable);

            GridView.DataContext = dataTable.DefaultView;


        }

        public void OledbPreparing()
        {
            OleDbConnectionStringBuilder oleDbConnection = new OleDbConnectionStringBuilder()
            {
                DataSource = @"Database3.mdb",
                Provider = "Microsoft.Jet.OLEDB.4.0"



            };
            OleDbConnection connection = new OleDbConnection(oleDbConnection.ConnectionString);
            DataAdapter = new OleDbDataAdapter();
            #region Select
            var cmdText = "SELECT Id, Email, Cod, objectName FROM ObjectsInfo";
            DataAdapter.SelectCommand = new OleDbCommand(cmdText, connection);
            var oledb = @"Select * from ObjectsInfo";
            DataAdapter = new OleDbDataAdapter(oledb, oleDbConnection.ConnectionString);
            #endregion
            ds = new DataSet();
            dt = new DataTable();
            DataAdapter.Fill(dt);


            GV_Access.DataContext = dt.DefaultView;







        }
        #region sqlWork
        private void Data_Grid_Add(object sender, RoutedEventArgs e)
        {
            DataRow r = dataTable.NewRow();
            Window1 window1 = new Window1(r);
            window1.ShowDialog();

            if (window1.DialogResult.Value)
            {
                dataTable.Rows.Add(r);

                adapter.Update(dataTable);
               
               
            }
        }
        private void Data_Grid_Remove(object sender, RoutedEventArgs e)
        {
            var row = (DataRowView)GridView.SelectedItem;
            row.Row.Delete();
            adapter.Update(dataTable);
        }

        private void GridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataRow == null)
            {
                return;
            }
            dataRow.EndEdit();
            adapter.Update(dataTable);
        }

        private void GridView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            dataRow = (DataRowView)GridView.SelectedItem;
            dataRow.BeginEdit();
        }
        #endregion


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
          

            var row = (DataRowView)GridView.SelectedItem;
            string x = (string)row["EMAIL"];
            Window2 window2 = new Window2(x);
            window2.ShowDialog();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var row = (DataRowView)GV_Access.SelectedItem;      
            row.Row.Delete();
            DataAdapter.Update(dt);
        }
    }
}
