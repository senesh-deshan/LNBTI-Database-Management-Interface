using System;
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

namespace LNBTI_Database_Management_Interface
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int loggedUser = 0;

        public string username = "";
        public string password = "";

        public int[] access_level = new int[10];

        public Window1()
        {
            InitializeComponent();
            frmLogin.Hide();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            sendToServer("SELECT * FROM Access_Control WHERE Username = '" + cmbxUsername.Text + "'");

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] encodedBytes = ascii.GetBytes(txtPassword.Password.ToString());
            string encodedString="";


            foreach (Byte b in encodedBytes)
            {
                encodedString += b.ToString();
            }

            Console.WriteLine(encodedString);


            if (cmbxUsername.Text == "")
            {
                lblLogin.Content = "Please select a username.";
            }
            else if (txtPassword.Password == "")
            {
                lblLogin.Content = "Please enter the password.";
            }
            else if (cmbxUsername.Text == username && encodedString == password)
            {
                loggedUser = 1; //------------------------
                frmLogin.Hide();
            }
            else
            {
                lblLogin.Content = "Please check your password.";
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmLogin.Close();

        }

        private void sendToServer(string command)
        {
            string sqlCommand = command;
            string connetionString = null;
            MySqlConnection databaseConnection;
            connetionString = "datasource=127.0.0.1;port=3306;database=lnbti_database;username=interface_root;password=lnbti123$%^;sslmode=none";
            databaseConnection = new MySqlConnection(connetionString);

            MySqlCommand databaseSqlCommand = new MySqlCommand(sqlCommand, databaseConnection);

            try
            {
                databaseConnection.Open();
                MySqlDataReader databaseReader = databaseSqlCommand.ExecuteReader();

                while (databaseReader.Read())
                {
                    username = databaseReader[0].ToString();
                    password = databaseReader[1].ToString();

                    for (int i = 0; i < 10; i++)
                    {
                        access_level[i] = Convert.ToInt16(databaseReader[i + 2].ToString());
                    }
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }
        private void getFromServer()
        {
            int numUsers = 0;

            string sqlCommand = "SELECT COUNT(Username) AS UserCount FROM Access_Control";
            string connetionString = null;
            MySqlConnection databaseConnection;
            connetionString = "datasource=127.0.0.1;port=3306;database=lnbti_database;username=interface_root;password=lnbti123$%^;sslmode=none";
            databaseConnection = new MySqlConnection(connetionString);

            MySqlCommand databaseSqlCommand = new MySqlCommand(sqlCommand, databaseConnection);

            try
            {
                databaseConnection.Open();
                MySqlDataReader databaseReader = databaseSqlCommand.ExecuteReader();

                while (databaseReader.Read())
                {
                    numUsers = Convert.ToInt16(databaseReader[0].ToString());
                    Console.WriteLine(numUsers);
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }


            sqlCommand = "SELECT Username FROM Access_Control ";

            connetionString = "datasource=127.0.0.1;port=3306;database=lnbti_database;username=interface_root;password=lnbti123$%^;sslmode=none";
            databaseConnection = new MySqlConnection(connetionString);

            databaseSqlCommand = new MySqlCommand(sqlCommand, databaseConnection);

            try
            {
                databaseConnection.Open();
                MySqlDataReader databaseReader = databaseSqlCommand.ExecuteReader();

                while (databaseReader.HasRows)
                {
                    while (databaseReader.Read())
                    {
                        cmbxUsername.Items.Add(databaseReader.GetString(0));
                    }
                    databaseReader.NextResult();
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {


            }

        }

        private void cmbxUsername_Initialized(object sender, EventArgs e)
        {
            getFromServer();
        }
    }
}
