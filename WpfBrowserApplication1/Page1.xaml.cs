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


namespace WpfBrowserApplication1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    /// 

    
    public partial class Page1 : Page
    {
        public static int userD;
        public static string mbname;
        public Page1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string uid = txtId.Text;
            string upwd = txtPwd.Password;
            string personnel = cmbPerson.Text;
            if (uid == "admin") { 
                if (upwd=="admin"){
                  Page1 page1 = new Page1();
                  Page2 page2Obj = new Page2(); //Create object of Page2
                  page1.Visibility = System.Windows.Visibility.Hidden;
                  page2Obj.Visibility = System.Windows.Visibility.Visible;
                 
                }
                else{
                    MessageBox.Show("Wrong Password");
                }
            }else{
                MessageBox.Show("Wrong UserName");
            }
            
            }
        

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

       
        private void btnEnta_Click(object sender, RoutedEventArgs e)
        {
            string eid = txtuID.Text;
            string pwd = txtPwd.Password;

            if (eid=="foLAW126" && pwd=="lawyer")
            {
                userD = 3;
                mbname = "Faculty of Law";
                Page1 page1 = new Page1();
                bursaryadmin bad= new bursaryadmin(); //Create object of Page2
                page1.Visibility = System.Windows.Visibility.Hidden;
                bad.Visibility = System.Windows.Visibility.Visible;
            }
            else if (eid == "foSCI237" && pwd == "scientist")
            {
                userD = 9;
                mbname = "Faculty of Science";

                Page1 page1 = new Page1();
                bursaryadmin bad = new bursaryadmin(); //Create object of Page2
                page1.Visibility = System.Windows.Visibility.Hidden;
                bad.Visibility = System.Windows.Visibility.Visible;
            }
            else if (eid == "foART348" && pwd == "artist")
            {
                userD = 27;
                mbname = "Faculty of Arts";

                Page1 page1 = new Page1();
                bursaryadmin bad = new bursaryadmin(); 
                page1.Visibility = System.Windows.Visibility.Hidden;
                bad.Visibility = System.Windows.Visibility.Visible;
            }
            else {
                MessageBox.Show("Wrong Combination", "Access Denied");
            }
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am working");
            Page1 page1 = new Page1();
            schoolAdmin sb = new schoolAdmin(); 
            page1.Visibility = System.Windows.Visibility.Hidden;
            sb.Visibility = System.Windows.Visibility.Visible;
        }


    }
}
