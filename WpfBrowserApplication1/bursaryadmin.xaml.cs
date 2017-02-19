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

namespace WpfBrowserApplication1
{
    /// <summary>
    /// Interaction logic for bursaryadmin.xaml
    /// </summary>
    public partial class bursaryadmin : Page
    {
        SqlConnection myConn;
        public bursaryadmin()
        {
            InitializeComponent();

            
           String connectionString= @"Driver= {MicrosoftAccessDriver(*.mdb)}; DBQ=C:\Users\INGENIO\Desktop\AUTOMATED BURSARY SYSTEM\The App\absDatabase.accdb";

             myConn = new SqlConnection(connectionString);
             myConn.Open();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillRecr();
            fillAccr();
            fillsrs();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            myConn.Close();
        }

        public void fillRecr() { 
            using (SqlDataAdapter a = new SqlDataAdapter(
		    "SELECT * FROM receivedRequests", myConn))
		{
		    // 3
		    // Use DataAdapter to fill DataTable
		    DataTable t = new DataTable();
		    a.Fill(t);
		    // 4
		    // Render data onto the screen
            dataGrid2.DataContext = t;
		        }
        }


        public void fillsrs()
        {
            using (SqlDataAdapter a = new SqlDataAdapter(
            "SELECT * FROM sentRequests", myConn))
            {
                // 3
                // Use DataAdapter to fill DataTable
                DataTable t = new DataTable();
                a.Fill(t);
                // 4
                // Render data onto the screen
                dataGrid3.DataContext = t;
            }
        }

        public void fillAccr()
        {
            if (comboBox1.Text == "Faculty of Science")
            {
                using (SqlDataAdapter a = new SqlDataAdapter(
                "SELECT * FROM facultyOfScience", myConn))
                {
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4
                    // Render data onto the screen
                    dataGrid1.DataContext = t;
                }
            }

            else if (comboBox1.Text == "Faculty of Law")
            {
                using (SqlDataAdapter a = new SqlDataAdapter(
                "SELECT * FROM facultyOfLaw", myConn))
                {
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4
                    // Render data onto the screen
                    dataGrid1.DataContext = t;
                }
            }
            else if (comboBox1.Text == "Faculty of Arts")
            {
                using (SqlDataAdapter a = new SqlDataAdapter(
                "SELECT * FROM facultyOfArts", myConn))
                {
                    // 3
                    // Use DataAdapter to fill DataTable
                    DataTable t = new DataTable();
                    a.Fill(t);
                    // 4
                    // Render data onto the screen
                    dataGrid1.DataContext = t;
                }
            }

            else { MessageBox.Show("Error"); }
        }

        private void btnSendReq_Click(object sender, RoutedEventArgs e)
        {
            String date = datePicker2.Text;
            String title = txtTitle.Text;
            String Detaill =txtDetaills.Text;
            String fileloc = txtAttach.Text;
           

            try
            {

                string insertComreq = "INSERT INTO sentRequests (Date_Sent, Title, Details, File ) VALUES ( 'date', 'title', 'Detaill','fileloc')";
                SqlCommand cmdd = new SqlCommand(insertComreq, myConn);
                cmdd.ExecuteNonQuery();
                MessageBox.Show("Posting Succesful");
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error in Posting");
            }
            /*finally{
                myConn.Close();

            }*/

        }


        private void btnAttach_Click_1(object sender, RoutedEventArgs e)
        {
                  // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();          
 
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt,PDF documents (.pdf)|*.pdf,Picture Documents (.jpeg)|*.jpeg|*.png";
 
            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();
 
            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                txtAttach.Text = filename;
             }


        }

        

    }
}
