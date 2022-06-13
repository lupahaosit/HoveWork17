using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Add_number.Text = null;
        }
        public Window1(DataRow row) : this()
        {
            BT_cancel.Click += delegate { this.DialogResult = false; };
            BT_Add.Click += delegate
            {
                row["Surname"] = Add_Surname.Text;
                row["NAME"] = Add_Name.Text;
                row["LASTNAME"] = Add_LastName.Text;
                row["NUMBER"] = (Add_number.Text);
                row["EMAIL"] = Add_email.Text;

                this.DialogResult = true;
            };
        }
    
    }
}
