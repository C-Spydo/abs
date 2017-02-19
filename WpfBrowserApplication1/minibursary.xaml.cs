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

//using Mysql.Data.MysqlClient; 


namespace WpfBrowserApplication1
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        int uID = Page1.userD;
        string labelname=Page1.mbname;

        TextBox txtDetailss = null;
        TextBox txtOfficerr=null;
        TextBox txtAmountt=null;
        SqlConnection myConn;
        public Page2()
        {
           
            InitializeComponent();
            
           // DataTable accreports = new DataTable();
            

            //String connectionString = @"Provider=Microsoft.ACE(C:\Users\INGENIO\Desktop\AUTOMATED BURSARY SYSTEM\The App\WebDatabase.accdb),
                                       // Persist Security Info=False;";

           //String connectionString= @"Driver= {MicrosoftAccessDriver(*.mdb)}; DBQ=C:\Users\INGENIO\Desktop\AUTOMATED BURSARY SYSTEM\The App\absDatabase.accdb";
            //Uid=Your_Username; Pwd=Your_Password;";
           String cs2 = @"server=localhost;userid=''; password='';database=test";
          
            //MySqlConnection conn2 = null;

             myConn = new SqlConnection(cs2);
             myConn.Open();
        }

      
	

	    public  void FillData()
	    {
		// Create new DataAdapter
		if(uID==3){
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
        else if (uID == 9)
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
        else if (uID == 27)
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
        else {
            MessageBox.Show("Error in Obtaining Data");
        }
        }//End of method fill dAta();


        public void btnPostacc_Click(object sender, RoutedEventArgs e)
        {
            String DateP = datePicker1.Text;

            txtDetailss = this.Template.FindName("txtDetail", this) as TextBox;
            txtAmountt = this.Template.FindName("txtAmount", this) as TextBox;
            txtOfficerr = this.Template.FindName("txtOfficer", this) as TextBox;
            
            String Amount = txtAmountt.Text;
            String Detail = txtDetailss.Text;
            String Officer = txtOfficerr.Text;
            Double Amountt = Convert.ToDouble(Amount);

            try
            {
                if (uID == 3)
                {
                    string insertCom = "INSERT INTO facultyOfLaw (Date_Posted, Amount, Details, Account_Officer ) VALUES ('Datep', 'Amountt', 'Details', 'Officer')";
                    SqlCommand cmdd = new SqlCommand(insertCom, myConn);
                    cmdd.ExecuteNonQuery();
                }

                else if (uID == 9) {
                    string insertCom = "INSERT INTO facultyOfScience (Date_Posted, Amount, Details, Account_Officer ) VALUES ('Datep', 'Amountt', 'Details', 'Officer')";
                    SqlCommand cmdd = new SqlCommand(insertCom, myConn);
                    cmdd.ExecuteNonQuery();
                }
                else if (uID == 27) {
                    string insertCom = "INSERT INTO facultyOfArts (Date_Posted, Amount, Details, Account_Officer ) VALUES ('Datep', 'Amountt', 'Details', 'Officer')";
                    SqlCommand cmdd = new SqlCommand(insertCom, myConn);
                    cmdd.ExecuteNonQuery();
                }
                else {
                    MessageBox.Show("User Not Recognised", "Error");
                }
                   MessageBox.Show("Posting Succesful");
            }
            catch(Exception excep){
                MessageBox.Show("Error in Posting");
            }
            /*finally{
                myConn.Close();

            }*/

        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            label9.Content = labelname;
            FillData();
            Window window = new Window();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.WindowState = WindowState.Maximized;
            window.Show();


        }

        private void Page_Unloaded(object sender, RoutedEventArgs e) {
            myConn.Close();
        }

        private void txtAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtDetails_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtOfficer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        //The codes for the second tab (sending of requests ) commences here
        private void btnSendReq_Click(object sender, RoutedEventArgs e)
        {

            String date = datePicker2.Text;
            String title = txtTitle.Text;
            String Detaill =txtDetaills.Text;
            String fileloc = txtAttach.Text;
           

            try
            {

                string insertComreq = "INSERT INTO receivedRequests (Date_Sent, Title, Details, File ) VALUES ( 'date', 'title', 'Detaill','fileloc')";
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

        private void btnAttach_Click(object sender, RoutedEventArgs e)
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
