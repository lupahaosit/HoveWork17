using System;
using System.Collections.Generic;
using System.Data;
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

        public MainWindow()
        {
            InitializeComponent();
            Preparing();

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
            sql = @"Inset Into InfoTable(Surname, [Name], LASTNAME, NUMBER, EMAIL)
                                           VALUES(@Surname, @[Name], @LASTNAME, @NUMBER, @EMAIL);
                                    Set @Id = @@IDENTITY";      

            adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
            adapter.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
            adapter.InsertCommand.Parameters.Add("@[NAME]", SqlDbType.NVarChar, 20,  "[NAME]");
            adapter.InsertCommand.Parameters.Add("@LASTNAME", SqlDbType.NVarChar, 20, "LASTNAME");
            adapter.InsertCommand.Parameters.Add("@NUBMER", SqlDbType.Int, 11, "NUMBER");
            adapter.InsertCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 20, "EMAIL");
            #endregion

            #region Update
            sql = @"Update InfoTable Set
                        Surname = @Surname
                        [NAME] = @[NAME]
                        LASTNAME = @LASTNAME
                        NUMBER = @NUMBER
                        EMAIL = @EMAIL
                    Where Id = @Id";
            adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
            adapter.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
            adapter.UpdateCommand.Parameters.Add("@[NAME]", SqlDbType.NVarChar, 20, "[NAME]");
            adapter.UpdateCommand.Parameters.Add("@LASTNAME", SqlDbType.NVarChar, 20, "LASTNAME");
            adapter.UpdateCommand.Parameters.Add("@NUBMER", SqlDbType.Int, 11, "NUMBER");
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

        private void Data_Grid_Add(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add");
        }
        private void Data_Grid_Remove(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Remove");
        }
    }
}
