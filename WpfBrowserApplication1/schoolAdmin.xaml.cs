using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace WpfBrowserApplication1
{
    /// <summary>
    /// Interaction logic for schoolAdmin.xaml
    /// </summary>
    public partial class schoolAdmin : Page
    {
        SqlConnection myConn;
        public schoolAdmin()
        {
            InitializeComponent();

             //String connectionString= @"Driver= {MicrosoftAccessDriver(*.mdb)}; DBQ=C:\Users\INGENIO\Desktop\AUTOMATED BURSARY SYSTEM\The App\absDatabase.accdb";
            //String connectionString = @" Database = C:\Users\INGENIO\Desktop\AUTOMATED BURSARY SYSTEM\The App\absDatabase.accdb; ";
           //Server = myServerAddress;
            
            //myConn = new SqlConnection(connectionString);
             //myConn.Open();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string inputt1 = Microsoft.VisualBasic.Interaction.InputBox("AccessCode - 1", "Verification", "Default", -1, -1);
            string inputt2 = Microsoft.VisualBasic.Interaction.InputBox("AccessCode - 2", "Confirmation", "Default", -1, -1);
            if (inputt1 == "abcd")
            {
                if (inputt2 == "1234")
                {
                    fillGrid();
                }
                else
                {
                    MessageBox.Show("Access Denied,Nothing Loads", "Wrong Code");
                }
            }
            else {
                MessageBox.Show("Access Denied,Nothing Loads", "Wrong Codes");
            }
           

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            myConn.Close();
        }

        public void fillGrid() { 
            using (SqlDataAdapter a = new SqlDataAdapter(
		    "SELECT * FROM sentRequests", myConn))
		{
		    // 3
		    // Use DataAdapter to fill DataTable
		    DataTable t = new DataTable();
		    a.Fill(t);
		    // 4
		    // Render data onto the screen
            dataGridd.DataContext = t;
		       }
        }
        
    }
}
