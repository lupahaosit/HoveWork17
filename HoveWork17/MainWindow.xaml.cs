using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.Entity.Migrations;
namespace HoveWork17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MSSQLLocalDBEntities1 model = new MSSQLLocalDBEntities1();

        ObservableCollection<InfoTable> infoTables = new ObservableCollection<InfoTable>();
        List<ObjectsInfoSet> objectsInfos = new List<ObjectsInfoSet>();
        Random rnd = new Random();
        DataTable dataTable = new DataTable();
        InfoTable dataRow;



        public MainWindow()
        {
            InitializeComponent();

            

            #region Заполнение InfoTable

            //for (int i = 0; i < 15; i++)

            //{
            //    infoTables.Add(new InfoTable
            //    {
            //        Surname = $"WorkerSurname{i}",
            //        NAME = $"WorkerName{i}",
            //        LASTNAME = $"WorkerLastName{i}",
            //        NUMBER = null,
            //        EMAIL = $"Worker{i}@mail.ru"
            //    });
            //}
            //foreach (var item in infoTables)
            //{
            //    model.InfoTable.Add(item);
            //}
            //for (int i = 0; i < 15; i++)

            //{
            //    objectsInfos.Add(new ObjectsInfoSet
            //    {

            //        Cod = rnd.Next(1000, 10000),
            //        Email = $"Worker{rnd.Next(1, 7)}@mail.ru",
            //        objectName = $"Телевизор{i}"

            //    });
            //}
            //foreach (var item in objectsInfos)
            //{
            //    model.ObjectsInfoSet.Add(item);
            //}

            //model.SaveChanges();
            //MessageBox.Show("готово");
            #endregion

            foreach (var item in model.InfoTable)
            {
                infoTables.Add(item);
            }
            foreach (var item in model.ObjectsInfoSet)
            {
                objectsInfos.Add(item);
            }
            
            GridView.ItemsSource = infoTables;
            GV_Access.ItemsSource = objectsInfos;
        }
        //private void Preparing()
        //{
        //    dataTable = new DataTable();
        //    adapter = new SqlDataAdapter();

        //    #region init устаревший 
        //    //var connectionStringBuilder = new SqlConnectionStringBuilder
        //    //{
        //    //    DataSource = @"(localdb)\MSSQLLocalDB",
        //    //    InitialCatalog = @"MSSQLLocalDB",
        //    //    IntegratedSecurity = true,
        //    //    UserID = "Admin",
        //    //    Password = "Admin",
        //    //    Pooling = true
        //    //};
        //    //string x = connectionStringBuilder.ConnectionString;

        //    //SqlConnection sqlConnection = new SqlConnection() { ConnectionString = x };
        //    //#endregion

        //    //#region Select
        //    //var sql = @"Select * from InfoTable Order by InfoTable.Id ";
        //    //adapter.SelectCommand = new SqlCommand(sql, sqlConnection);
        //    //#endregion

        //    //#region Insert
        //    //sql = @"Insert Into InfoTable (Surname,WorkerNAME, LASTNAME, NUMBER, EMAIL)
        //    //                               VALUES (@Surname, @WorkerNAME, @LASTNAME, @NUMBER, @EMAIL);
        //    //                        SET @Id = @@IDENTITY;";      

        //    //adapter.InsertCommand = new SqlCommand(sql, sqlConnection);
        //    //adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
        //    //adapter.InsertCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
        //    //adapter.InsertCommand.Parameters.Add("@WorkerNAME", SqlDbType.NVarChar, 20, "WorkerNAME");
        //    //adapter.InsertCommand.Parameters.Add("@LASTNAME", SqlDbType.NVarChar, 20, "LASTNAME");
        //    //adapter.InsertCommand.Parameters.Add("@NUMBER", SqlDbType.Int, 11, "NUMBER");
        //    //adapter.InsertCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 20, "EMAIL");
        //    //#endregion

        //    //#region Update
        //    //sql = @"Update InfoTable Set
        //    //            Surname = @Surname,
        //    //           WorkerNAME = @WorkerNAME,
        //    //            LASTNAME = @LASTNAME,
        //    //            NUMBER = @NUMBER,
        //    //            EMAIL = @EMAIL
        //    //        Where Id = @Id";
        //    //adapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
        //    //adapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").SourceVersion = DataRowVersion.Original;
        //    //adapter.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NVarChar, 20, "Surname");
        //    //adapter.UpdateCommand.Parameters.Add("@WorkerNAME", SqlDbType.NVarChar, 20, "WorkerNAME");
        //    //adapter.UpdateCommand.Parameters.Add("@LASTNAME", SqlDbType.NVarChar, 20, "LASTNAME");
        //    //adapter.UpdateCommand.Parameters.Add("@NUMBER", SqlDbType.Int, 11, "NUMBER");
        //    //adapter.UpdateCommand.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 20, "EMAIL");
        //    //#endregion

        //    //#region Delete
        //    //sql = "Delete From InfoTable where Id = @Id";
        //    //adapter.DeleteCommand = new SqlCommand(sql, sqlConnection);
        //    //adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
        //    #endregion 

        //    adapter.Fill(dataTable);

        //    GridView.DataContext = dataTable.DefaultView;


        //}
        //#region УСТАРЕВШИЙ
        ////public void OledbPreparing()
        ////{
        ////    OleDbConnectionStringBuilder oleDbConnection = new OleDbConnectionStringBuilder()
        ////    {
        ////        DataSource = @"Database3.mdb",
        ////        Provider = "Microsoft.Jet.OLEDB.4.0"



        ////    };
        ////    OleDbConnection connection = new OleDbConnection(oleDbConnection.ConnectionString);
        ////    DataAdapter = new OleDbDataAdapter();
        ////    #region Select
        ////    var cmdText = "SELECT Id, Email, Cod, objectName FROM ObjectsInfo";
        ////    DataAdapter.SelectCommand = new OleDbCommand(cmdText, connection);
        ////    var oledb = @"Select * from ObjectsInfo";
        ////    DataAdapter = new OleDbDataAdapter(oledb, oleDbConnection.ConnectionString);
        ////    #endregion
        ////    ds = new DataSet();
        ////    dt = new DataTable();
        ////    DataAdapter.Fill(dt);


        ////    GV_Access.DataContext = dt.DefaultView;







        ////}
        //#endregion
        #region sqlWork
        private void Data_Grid_Add(object sender, RoutedEventArgs e)
        {
            InfoTable r = new InfoTable();
            Window1 window1 = new Window1(r);
            window1.ShowDialog();

            if (window1.DialogResult.Value)
            {
                infoTables.Add(r);
                model.InfoTable.Add(r);
                model.SaveChanges();
              
            }
        }
        private void Data_Grid_Remove(object sender, RoutedEventArgs e)
        {
            var row = GridView.SelectedItem;
            InfoTable x = (InfoTable)row;
            model.InfoTable.Remove((InfoTable)x);
            infoTables.Remove((InfoTable)x);
            GridView.ItemsSource = infoTables;
            model.SaveChanges();




        }

       

        private void GridView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            dataRow = (InfoTable)GridView.SelectedItem;
        }
        private void GridView_CurrentCellChanged(object sender, EventArgs e)
        {
            dataRow = (InfoTable)GridView.SelectedItem;
            if (dataRow.Surname == null || dataRow.NAME == null || dataRow.LASTNAME == null || dataRow.EMAIL == null )
            {
                return;
            }
            InfoTable x = (InfoTable)GridView.SelectedItem;
            int y = GridView.SelectedIndex;
            infoTables[y] = x;
            model.InfoTable.AddOrUpdate(E => E.Id, x);
            model.SaveChanges();
           

        }
        #endregion


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            InfoTable y = (InfoTable)GridView.SelectedItem;
            var x = model.InfoTable.Join(model.ObjectsInfoSet,
                InfoTable => InfoTable.EMAIL,
                ObjectsInfoSet => ObjectsInfoSet.Email,
                (InfoTable, ObjectsInfoSet) => new
                {
                    InfoTable.Id,
                    InfoTable.Surname,
                    InfoTable.NAME,
                    InfoTable.LASTNAME,
                    InfoTable.EMAIL,
                    InfoTable.NUMBER,
                    ObjectsInfoSet.Cod,
                    ObjectsInfoSet.objectName
                });

            List<result> results = new List<result>();
            foreach (var item in x)
            {
                if (item.Id == y.Id)
                {
                    results.Add(new result
                    {
                        Name = item.NAME,
                        Id = item.Id,
                        Surname = item.Surname,
                        LastName = item.LASTNAME,
                        Number = item.NUMBER,
                        Email = item.EMAIL,
                        Cod = item.Cod,
                        ObjectName = item.objectName

                    });
                }
               
            }
            Window2 window2 = new Window2(results);
           
           window2.ShowDialog();

        }

     

       
    }

}
