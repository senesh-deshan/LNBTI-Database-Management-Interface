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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;


namespace LNBTI_Database_Management_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int loggedUser = 0;

        public int deleteBlocked = 1;

        const int numCheckBoxes = 28;
        CheckBox[] checkboxArrayView = new CheckBox[numCheckBoxes];
        CheckBox[] checkboxArrayFilter = new CheckBox[numCheckBoxes];
        TextBox[] fieldArray = new TextBox[numCheckBoxes];
        string[] fieldArrayString = new string[numCheckBoxes];

        string sqlCommand = "";
        string sqlCommand_1 = "";
        string sqlCommand_2 = "";
        string sqlCommand_3 = "";
        string sqlCommand_4 = "";

        Boolean optionsRequested = false;
        Boolean qualificationsRequested = false;

        public MainWindow()
        {
            InitializeComponent();
            restart();
        }
        void restart()
        {
            frmMain.Hide();

            Window1 loginWindow = new Window1();

            dgdMain.Items.Clear();
            dgdOption_1.Items.Clear();
            dgdOption_2.Items.Clear();
            dgdOption_3.Items.Clear();
            dgdOption_4.Items.Clear();

            dgdMain.Visibility = Visibility.Visible;
            dgdOption_1.Visibility = Visibility.Hidden;
            dgdOption_2.Visibility = Visibility.Hidden;
            dgdOption_3.Visibility = Visibility.Hidden;
            dgdOption_4.Visibility = Visibility.Hidden;

            cnvsMain.Visibility = Visibility.Hidden;
            cnvsMain.Width = 400;
            cnvsMain.Height = 700;

            txtReg_No_4.MaxLength = 4;
            txtAge.MaxLength = 2;
            txtNIC.MaxLength = 12;
            txtTeleNo.MaxLength = 10;
            txtParentTeleNo.MaxLength = 10;
            txtQualYear.MaxLength = 4;

            loginWindow.ShowInTaskbar = false;

            loginWindow.ShowDialog();//-------------------

            // Window3 paymentWindow = new Window3();//---------
            // paymentWindow.ShowDialog();//--------------------

            //Window2 studentWindow = new Window2(1,"");//------------
            //studentWindow.ShowDialog();//---------------



            loggedUser = loginWindow.loggedUser;
            loginWindow.Close();

            //loggedUser = 1;//-----------

            if (loggedUser == 0)
            {
                frmMain.Close();
            }
            else if (loggedUser == 1)
            {
                frmMain.Show();
            }







            checkboxArrayView[0] = cxvReg_No;
            checkboxArrayView[1] = cxvName;
            checkboxArrayView[2] = cxvRegDate;
            checkboxArrayView[3] = cxvBatchYear;
            checkboxArrayView[4] = cxvCourse;
            checkboxArrayView[5] = cxvInactiveReason; //*****
            checkboxArrayView[6] = cxvAge; //*****
            checkboxArrayView[7] = cxvDOB;
            checkboxArrayView[8] = cxvGender;
            checkboxArrayView[9] = cxvAddress; //*****
            checkboxArrayView[10] = cxvNIC;
            checkboxArrayView[11] = cxvNationality;
            checkboxArrayView[12] = cxvEmail;
            checkboxArrayView[13] = cxvTeleNo;
            checkboxArrayView[14] = cxvParentName;
            checkboxArrayView[15] = cxvOccupation;
            checkboxArrayView[16] = cxvParentTeleNo;
            checkboxArrayView[17] = cxvQualType; //*****
            checkboxArrayView[18] = cxvQualIndexNo; //*****
            checkboxArrayView[19] = cxvQualYear; //*****
            checkboxArrayView[20] = cxvSchlInst; //*****
            checkboxArrayView[21] = cxvPaymentOption; //*****
            checkboxArrayView[22] = cxvScholarship;
            checkboxArrayView[23] = cxvRegFee;
            checkboxArrayView[24] = cxvAmount;
            checkboxArrayView[25] = cxvSlipNo; //*****
            checkboxArrayView[26] = cxvPaidDate; //*****
            checkboxArrayView[27] = cxvNOPD;

            checkboxArrayFilter[0] = cxfReg_No;
            checkboxArrayFilter[1] = cxfName;
            checkboxArrayFilter[2] = cxfRegDate;
            checkboxArrayFilter[3] = cxfBatchYear;
            checkboxArrayFilter[4] = cxfCourse;
            checkboxArrayFilter[5] = cxfInactiveReason;
            checkboxArrayFilter[6] = cxfAge;
            checkboxArrayFilter[7] = cxfDOB;
            checkboxArrayFilter[8] = cxfGender;
            checkboxArrayFilter[9] = cxfAddress;
            checkboxArrayFilter[10] = cxfNIC;
            checkboxArrayFilter[11] = cxfNationality;
            checkboxArrayFilter[12] = cxfEmail;
            checkboxArrayFilter[13] = cxfTeleNo;
            checkboxArrayFilter[14] = cxfParentName;
            checkboxArrayFilter[15] = cxfOccupation;
            checkboxArrayFilter[16] = cxfParentTeleNo;
            checkboxArrayFilter[17] = cxfQualType;
            checkboxArrayFilter[18] = cxfQualIndexNo;
            checkboxArrayFilter[19] = cxfQualYear;
            checkboxArrayFilter[20] = cxfSchlInst;
            checkboxArrayFilter[21] = cxfPaymentOption;
            checkboxArrayFilter[22] = cxfScholarship;
            checkboxArrayFilter[23] = cxfRegFee;
            checkboxArrayFilter[24] = cxfAmount;
            checkboxArrayFilter[25] = cxfSlipNo;
            checkboxArrayFilter[26] = cxfPaidDate;
            checkboxArrayFilter[27] = cxfNOPD;

            //            fieldArray[0] = txtReg_No; //*****
            fieldArray[1] = txtName;
            //            fieldArray[2] = txtRegDate; //*****
            //            fieldArray[3] = txtBatchYear; //*****
            //            fieldArray[4] = txtCourse; //*****
            fieldArray[5] = txtInactiveReason;
            fieldArray[6] = txtAge;
            //            fieldArray[7] = txtDOB; //*****
            //            fieldArray[8] = txtGender; //*****
            fieldArray[9] = txtAddress;
            fieldArray[10] = txtNIC;
            fieldArray[11] = txtNationality;
            fieldArray[12] = txtEmail;
            fieldArray[13] = txtTeleNo;
            fieldArray[14] = txtParentName;
            fieldArray[15] = txtOccupation;
            fieldArray[16] = txtParentTeleNo;
            //            fieldArray[17] = txtQualType; //*****
            fieldArray[18] = txtQualIndexNo;
            fieldArray[19] = txtQualYear;
            fieldArray[20] = txtSchlInst;
            //            fieldArray[21] = txtPaymentOption; //*****
            fieldArray[22] = txtScholarship;
            fieldArray[23] = txtRegFee;
            fieldArray[24] = txtAmount;
            fieldArray[25] = txtSlipNo;
            //            fieldArray[26] = txtPaidDate; //*****
            fieldArray[27] = txtNOPD;


            setupUser(loginWindow);


            dgdMain.Margin = new Thickness(50, 280, 0, 0);
            dgdOption_1.Margin = new Thickness(50, 280, 0, 0);
            dgdOption_2.Margin = new Thickness(50, 395, 0, 0);
            dgdOption_3.Margin = new Thickness(50, 505, 0, 0);
            dgdOption_4.Margin = new Thickness(50, 610, 0, 0);
            dgdMain.Width = 1275;
            dgdOption_1.Width = 1275;
            dgdOption_2.Width = 1275;
            dgdOption_3.Width = 1275;
            dgdOption_4.Width = 1275;
        }

        void setupUser(Window1 loginWindow)
        {
            if (loginWindow.access_level[0] == 0)
            {
                for (int i = 0; i <= 16; i++)
                {
                    checkboxArrayView[i].IsEnabled = false;
                    checkboxArrayFilter[i].IsEnabled = false;

                }
            }
            if (loginWindow.access_level[1] == 0)
            {
                for (int i = 17; i <= 20; i++)
                {
                    checkboxArrayView[i].IsEnabled = false;
                    checkboxArrayFilter[i].IsEnabled = false;
                }
            }
            if (loginWindow.access_level[2] == 0)
            {
                for (int i = 21; i <= 27; i++)
                {
                    checkboxArrayView[i].IsEnabled = false;
                    checkboxArrayFilter[i].IsEnabled = false;
                }
            }
            if (loginWindow.access_level[3] == 0)
            {
                btnExecute.IsEnabled = false;
                btnFilterDisplay.IsEnabled = false;
            }
            if (loginWindow.access_level[4] == 0)
            {
                btnAddStudent.IsEnabled = false;
            }
            if (loginWindow.access_level[5] == 0)
            {
                btnEditStudent.IsEnabled = false;
            }
            if (loginWindow.access_level[6] == 0)
            {
                deleteBlocked = loginWindow.access_level[6];
            }
            if (loginWindow.access_level[7] == 0)
            {
                btnAddPayment.IsEnabled = false;
            }
            if (loginWindow.access_level[8] == 0)
            {
                txtQueryBox.Visibility = Visibility.Hidden;
                txtQueryBox_1.Visibility = Visibility.Hidden;
                btnAdmin.Visibility = Visibility.Hidden;
            }
            if (loginWindow.access_level[9] == 0)
            {

            }


            if (loginWindow.access_level[0] == 1)
            {
                for (int i = 0; i <= 16; i++)
                {
                    checkboxArrayView[i].IsEnabled = true;
                    checkboxArrayFilter[i].IsEnabled = true;
                }
            }
            if (loginWindow.access_level[1] == 1)
            {
                for (int i = 17; i <= 20; i++)
                {
                    checkboxArrayView[i].IsEnabled = true;
                    checkboxArrayFilter[i].IsEnabled = true;
                }
            }
            if (loginWindow.access_level[2] == 1)
            {
                for (int i = 21; i <= 27; i++)
                {
                    checkboxArrayView[i].IsEnabled = true;
                    checkboxArrayFilter[i].IsEnabled = true;
                }
            }
            if (loginWindow.access_level[3] == 1)
            {
                btnExecute.IsEnabled = true;
                btnFilterDisplay.IsEnabled = true;
            }
            if (loginWindow.access_level[4] == 1)
            {
                btnAddStudent.IsEnabled = true;
            }
            if (loginWindow.access_level[5] == 1)
            {
                btnEditStudent.IsEnabled = true;
            }
            if (loginWindow.access_level[6] == 1)
            {
                deleteBlocked = loginWindow.access_level[6];
            }
            if (loginWindow.access_level[7] == 1)
            {
                btnAddPayment.IsEnabled = true;
            }
            if (loginWindow.access_level[8] == 1)
            {
                txtQueryBox.Visibility = Visibility.Visible;
                txtQueryBox_1.Visibility = Visibility.Visible;
                btnAdmin.Visibility = Visibility.Visible;
            }
            if (loginWindow.access_level[9] == 1)
            {

            }

            lblLoggedUser.Content = loginWindow.cmbxUsername.Text;
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            buildQuary();

            string connetionString = null;
            MySqlConnection databaseConnection;
            connetionString = "datasource=127.0.0.1;port=3306;database=lnbti_database;username=interface_root;password=lnbti123$%^;sslmode=none";
            databaseConnection = new MySqlConnection(connetionString);

            MySqlCommand databaseSqlCommand = new MySqlCommand(sqlCommand, databaseConnection);
            MySqlCommand databaseSqlCommand_1 = new MySqlCommand(sqlCommand_1, databaseConnection);
            MySqlCommand databaseSqlCommand_2 = new MySqlCommand(sqlCommand_2, databaseConnection);
            MySqlCommand databaseSqlCommand_3 = new MySqlCommand(sqlCommand_3, databaseConnection);
            MySqlCommand databaseSqlCommand_4 = new MySqlCommand(sqlCommand_4, databaseConnection);
            //databaseSqlCommand.CommandTimeout = 60;
            MySqlDataAdapter databaseAdapter = new MySqlDataAdapter(databaseSqlCommand);
            MySqlDataAdapter databaseAdapter_1 = new MySqlDataAdapter(databaseSqlCommand_1);
            MySqlDataAdapter databaseAdapter_2 = new MySqlDataAdapter(databaseSqlCommand_2);
            MySqlDataAdapter databaseAdapter_3 = new MySqlDataAdapter(databaseSqlCommand_3);
            MySqlDataAdapter databaseAdapter_4 = new MySqlDataAdapter(databaseSqlCommand_4);
            //
            DataSet databaseDataSet = new DataSet();
            DataSet databaseDataSet_1 = new DataSet();
            DataSet databaseDataSet_2 = new DataSet();
            DataSet databaseDataSet_3 = new DataSet();
            DataSet databaseDataSet_4 = new DataSet();

            try
            {
                databaseConnection.Open();
                if (optionsRequested)
                {
                    dgdMain.Visibility = Visibility.Hidden;
                    dgdOption_1.Visibility = Visibility.Visible;
                    dgdOption_2.Visibility = Visibility.Visible;
                    dgdOption_3.Visibility = Visibility.Visible;
                    dgdOption_4.Visibility = Visibility.Visible;

                    databaseAdapter_1.Fill(databaseDataSet_1);
                    dgdOption_1.ItemsSource = databaseDataSet_1.Tables[0].DefaultView;

                    databaseAdapter_2.Fill(databaseDataSet_2);
                    dgdOption_2.ItemsSource = databaseDataSet_2.Tables[0].DefaultView;

                    databaseAdapter_3.Fill(databaseDataSet_3);
                    dgdOption_3.ItemsSource = databaseDataSet_3.Tables[0].DefaultView;

                    databaseAdapter_4.Fill(databaseDataSet_4);
                    dgdOption_4.ItemsSource = databaseDataSet_4.Tables[0].DefaultView;

                }

                else
                {
                    dgdMain.Visibility = Visibility.Visible;
                    dgdOption_1.Visibility = Visibility.Hidden;
                    dgdOption_2.Visibility = Visibility.Hidden;
                    dgdOption_3.Visibility = Visibility.Hidden;
                    dgdOption_4.Visibility = Visibility.Hidden;


                    if (sqlCommand == "")
                    {
                        lblStatus.Content = "Quary is empty.";
                    }
                    else
                    {
                        databaseAdapter.Fill(databaseDataSet);
                        dgdMain.ItemsSource = databaseDataSet.Tables[0].DefaultView;
                    }
                }
                databaseConnection.Close();

                optionsRequested = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection !\n" + ex.ToString());
            }
        }

        private void dgdMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnFilterDisplay_Click(object sender, RoutedEventArgs e)
        {
            if (cnvsMain.Visibility == Visibility.Visible)
            {
                btnFilterDisplay.Content = ">>";
                cnvsMain.Visibility = Visibility.Hidden;

                dgdMain.Margin = new Thickness(50, 280, 0, 0);
                dgdOption_1.Margin = new Thickness(50, 280, 0, 0);
                dgdOption_2.Margin = new Thickness(50, 395, 0, 0);
                dgdOption_3.Margin = new Thickness(50, 505, 0, 0);
                dgdOption_4.Margin = new Thickness(50, 610, 0, 0);
                dgdMain.Width = 1275;
                dgdOption_1.Width = 1275;
                dgdOption_2.Width = 1275;
                dgdOption_3.Width = 1275;
                dgdOption_4.Width = 1275;
            }
            else
            {
                btnFilterDisplay.Content = "<<";
                cnvsMain.Visibility = Visibility.Visible;

                dgdMain.Margin = new Thickness(435, 280, 0, 0);
                dgdOption_1.Margin = new Thickness(435, 280, 0, 0);
                dgdOption_2.Margin = new Thickness(435, 395, 0, 0);
                dgdOption_3.Margin = new Thickness(435, 505, 0, 0);
                dgdOption_4.Margin = new Thickness(435, 610, 0, 0);
                dgdMain.Width = 890;
                dgdOption_1.Width = 890;
                dgdOption_2.Width = 890;
                dgdOption_3.Width = 890;
                dgdOption_4.Width = 890;
            }
        }

        void updateFieldArrayString()
        {
            fieldArrayString[0] = cmbxReg_No_1.Text + "/" + cmbxReg_No_2.Text + "/" + cmbxReg_No_3.Text + "/";
            for (int j = 0; j < 4 - txtReg_No_4.Text.Length; j++)
            {
                fieldArrayString[0] += "0";
            }
            fieldArrayString[0] += txtReg_No_4.Text;
            fieldArrayString[1] = txtName.Text;
            fieldArrayString[2] = dpkDOR.Text;
            fieldArrayString[3] = cmbxBatchYear.Text;
            fieldArrayString[4] = cmbxCourse.Text;
            fieldArrayString[5] = txtInactiveReason.Text;
            fieldArrayString[6] = txtAge.Text;
            fieldArrayString[7] = dpkDOB.Text;
            fieldArrayString[8] = cmbxGender.Text;
            fieldArrayString[9] = txtAddress.Text;
            fieldArrayString[10] = txtNIC.Text;
            fieldArrayString[11] = txtNationality.Text;
            fieldArrayString[12] = txtEmail.Text;
            fieldArrayString[13] = txtTeleNo.Text;
            fieldArrayString[14] = txtParentName.Text;
            fieldArrayString[15] = txtOccupation.Text;
            fieldArrayString[16] = txtParentTeleNo.Text;
            fieldArrayString[17] = cmbxQualType.Text;
            fieldArrayString[18] = txtQualIndexNo.Text;
            fieldArrayString[19] = txtQualYear.Text;
            fieldArrayString[20] = txtSchlInst.Text;
            fieldArrayString[21] = cmbxPaymentOption.Text;
            fieldArrayString[22] = txtScholarship.Text;
            fieldArrayString[23] = txtRegFee.Text;
            fieldArrayString[24] = txtAmount.Text;
            fieldArrayString[25] = txtSlipNo.Text;
            fieldArrayString[26] = dpkPaidDate.Text;
            fieldArrayString[27] = txtNOPD.Text;
        }

        void buildQuary()
        {
            updateFieldArrayString();

            optionsRequested = false;
            qualificationsRequested = false;

            sqlCommand = "";
            sqlCommand_1 = "";
            sqlCommand_2 = "";
            sqlCommand_3 = "";
            sqlCommand_4 = "";

            Boolean viewCkecked = false;
            Boolean filterChecked = false;

            Boolean requestConsidered = false;
            Boolean nothingUpdated = false;

            for (int i = 0; i < numCheckBoxes; i++)
            {
                if (checkboxArrayView[i].IsChecked == true)
                {
                    viewCkecked = true;
                    break;
                }
            }
            for (int i = 21; i <= 27; i++) // options requested
            {
                if (checkboxArrayView[i].IsChecked == true)
                {
                    optionsRequested = true;
                    break;
                }
            }
            for (int i = 17; i <= 20; i++) // qualifications requested
            {
                if (cxfLondon.IsChecked == true)
                {
                    qualificationsRequested = true;
                    break;
                }
                if (checkboxArrayView[i].IsChecked == true)
                {
                    qualificationsRequested = true;
                    break;
                }
            }

            for (int i = 0; i < numCheckBoxes; i++)
            {
                if (checkboxArrayFilter[i].IsChecked == true)
                {
                    filterChecked = true;
                    break;
                }
            }
            for (int i = 21; i <= 27; i++) // options requested
            {
                if (checkboxArrayFilter[i].IsChecked == true)
                {
                    optionsRequested = true;
                    break;
                }
            }
            for (int i = 17; i <= 20; i++) // qualifications requested
            {
                if (cxfLondon.IsChecked == true)
                {
                    qualificationsRequested = true;
                    break;
                }
                if (checkboxArrayFilter[i].IsChecked == true)
                {
                    qualificationsRequested = true;
                    break;
                }
            }

            if (optionsRequested)
            {
                cxfNotPaid.IsEnabled = true;
            }
            else
            {
                cxfNotPaid.IsEnabled = false;
            }


            if (viewCkecked)
            {
                cxfLondon.IsEnabled = true;


                sqlCommand += "SELECT ";

                for (int i = 0; i < numCheckBoxes; i++)
                {
                    if (checkboxArrayView[i].IsChecked == true)
                    {
                        if (checkboxArrayView[i].Name == "cxvReg_No")
                        {
                            sqlCommand += "Student.Reg_No";
                        }
                        else if (checkboxArrayView[i].Name == "cxvRegDate")
                        {
                            sqlCommand += "DATE_FORMAT(RegDate, '%c/%e/%Y') AS RegDate";
                        }
                        else if (checkboxArrayView[i].Name == "cxvAge")
                        {
                            sqlCommand += "TIMESTAMPDIFF(YEAR, DOB, CURDATE()) AS Age";
                        }
                        else if (checkboxArrayView[i].Name == "cxvDOB")
                        {
                            sqlCommand += "DATE_FORMAT(DOB, '%c/%e/%Y') AS DOB";
                        }
                        else if (checkboxArrayView[i].Name == "cxvAddress")
                        {
                            if (cxfAddressCombine.IsChecked == true)
                            {
                                sqlCommand += "CONCAT(PA_1,',',PA_2,',',PA_City,',',PA_Region,'.') AS Permanent_Address, CONCAT(MA_1,',',MA_2,',',MA_City,',',MA_Region,'.') AS Mailing_Address";
                            }
                            else
                            {
                                sqlCommand += "PA_1,PA_2,PA_City,PA_Region,MA_1,MA_2,MA_City,MA_Region";
                            }
                        }
                        else if (checkboxArrayView[i].Name == "cxvQualType")
                        {
                            if (cmbxQualType.Text == "O/L")
                            {
                                sqlCommand += "S1,R1,S2,R2,S3,R3,S4,R4,S5,R5,S6,R6,S7,R7,S8,R8,S9,R9";
                            }
                            else if (cmbxQualType.Text == "A/L")
                            {
                                sqlCommand += "S1,R1,S2,R2,S3,R3,S4,R4";
                            }
                            else
                            {
                                sqlCommand += "QualType";
                            }
                        }
                        else if (checkboxArrayView[i].Name == "cxvQualIndexNo")
                        {
                            if (cmbxQualType.Text == "O/L")
                            {
                                sqlCommand += "OL_Index_No";
                            }
                            else if (cmbxQualType.Text == "A/L")
                            {
                                sqlCommand += "AL_Index_No";
                            }
                            else
                            {
                                sqlCommand += "Ref_ID";
                            }
                        }
                        else if (checkboxArrayView[i].Name == "cxvQualYear")
                        {
                            if (cmbxQualType.Text == "O/L")
                            {
                                sqlCommand += "Ex_Year";
                            }
                            else if (cmbxQualType.Text == "A/L")
                            {
                                sqlCommand += "Ex_Year";
                            }
                            else
                            {
                                sqlCommand += "QualYear";
                            }
                        }
                        else if (checkboxArrayView[i].Name == "cxvSchlInst")
                        {
                            if (cmbxQualType.Text == "O/L")
                            {
                                sqlCommand += "School";
                            }
                            else if (cmbxQualType.Text == "A/L")
                            {
                                sqlCommand += "School";
                            }
                            else
                            {
                                sqlCommand += "Institute";
                            }
                        }
                        else if (checkboxArrayView[i].Name == "cxvPaymentOption")
                        {
                            sqlCommand += "IF(PaymentOption=1,'12M',IF(PaymentOption=2,'6M',IF(PaymentOption=3,'3M',IF(PaymentOption=4,'1M','ERROR')))) AS PaymentOption";
                        }
                        else if (checkboxArrayView[i].Name == "cxvGender")
                        {
                            sqlCommand += "IF(Gender=1,'M',IF(Gender=0,'F','ERROR')) AS Gender";
                        }
                        else if (checkboxArrayView[i].Name == "cxvSlipNo" || checkboxArrayView[i].Name == "cxvPaidDate")
                        {
                            if (!requestConsidered)
                            {
                                requestConsidered = true;
                                sqlCommand_1 += sqlCommand;
                                sqlCommand_2 += sqlCommand;
                                sqlCommand_3 += sqlCommand;
                                sqlCommand_4 += sqlCommand;

                                sqlCommand = "";

                                if (cxfNotPaid.IsEnabled == true && cxfNotPaid.IsChecked == true)
                                {
                                    sqlCommand_1 += "DATE_FORMAT((DATE_ADD(Paid_Date_1, INTERVAL 12*NOPD MONTH)), '%c/%e/%Y') as payment_Deadline,";
                                    sqlCommand_2 += "DATE_FORMAT((DATE_ADD(Paid_Date_1, INTERVAL 6*NOPD MONTH)), '%c/%e/%Y') as payment_Deadline,";
                                    sqlCommand_3 += "DATE_FORMAT((DATE_ADD(Paid_Date_1, INTERVAL 3*NOPD MONTH)), '%c/%e/%Y') as payment_Deadline,";
                                    sqlCommand_4 += "DATE_FORMAT((DATE_ADD(Paid_Date_1, INTERVAL 1*NOPD MONTH)), '%c/%e/%Y') as payment_Deadline,";

                                    sqlCommand = "";
                                }

                                for (int k = 1; k <= 3; k++)
                                {
                                    if (cxvSlipNo.IsChecked == true)
                                    {
                                        sqlCommand_1 += "Slip_No_" + k.ToString() + ",";
                                    }
                                    if (cxvPaidDate.IsChecked == true)
                                    {
                                        sqlCommand_1 += "DATE_FORMAT(Paid_Date_" + k.ToString() + ", '%c/%e/%Y') AS Paid_Date_" + k.ToString() + ",";
                                    }
                                }
                                for (int k = 1; k <= 6; k++)
                                {
                                    if (cxvSlipNo.IsChecked == true)
                                    {
                                        sqlCommand_2 += "Slip_No_" + k.ToString() + ",";
                                    }
                                    if (cxvPaidDate.IsChecked == true)
                                    {
                                        sqlCommand_2 += "DATE_FORMAT(Paid_Date_" + k.ToString() + ", '%c/%e/%Y') AS Paid_Date_" + k.ToString() + ",";
                                    }
                                }
                                for (int k = 1; k <= 12; k++)
                                {
                                    if (cxvSlipNo.IsChecked == true)
                                    {
                                        sqlCommand_3 += "Slip_No_" + k.ToString() + ",";
                                    }
                                    if (cxvPaidDate.IsChecked == true)
                                    {
                                        sqlCommand_3 += "DATE_FORMAT(Paid_Date_" + k.ToString() + ", '%c/%e/%Y') AS Paid_Date_" + k.ToString() + ",";
                                    }
                                }
                                for (int k = 1; k <= 36; k++)
                                {
                                    if (cxvSlipNo.IsChecked == true)
                                    {
                                        sqlCommand_4 += "Slip_No_" + k.ToString() + ",";
                                    }
                                    if (cxvPaidDate.IsChecked == true)
                                    {
                                        sqlCommand_4 += "DATE_FORMAT(Paid_Date_" + k.ToString() + ", '%c/%e/%Y') AS Paid_Date_" + k.ToString() + ",";
                                    }
                                }

                                sqlCommand_1 = sqlCommand_1.Remove(sqlCommand_1.Length - 1);
                                sqlCommand_2 = sqlCommand_2.Remove(sqlCommand_2.Length - 1);
                                sqlCommand_3 = sqlCommand_3.Remove(sqlCommand_3.Length - 1);
                                sqlCommand_4 = sqlCommand_4.Remove(sqlCommand_4.Length - 1);
                            }
                            else
                            {
                                nothingUpdated = true;
                            }
                        }
                        else
                        {
                            sqlCommand += checkboxArrayView[i].Name.Remove(0, 3);
                        }


                        if (nothingUpdated)
                        {
                            nothingUpdated = false;
                        }
                        else
                        {
                            sqlCommand += ",";
                        }

                        //sqlCommand += ",";

                    }
                }

                if (optionsRequested)
                {
                    sqlCommand = sqlCommand.Remove(sqlCommand.Length - 1);
                    sqlCommand_1 += sqlCommand;
                    sqlCommand_2 += sqlCommand;
                    sqlCommand_3 += sqlCommand;
                    sqlCommand_4 += sqlCommand;

                    sqlCommand = "";
                }
                else
                {
                    sqlCommand = sqlCommand.Remove(sqlCommand.Length - 1);
                }
                sqlCommand += " FROM Student";
            }
            else
            {
                cxfLondon.IsEnabled = false;
            }
            ////////////////////////////////////////////////////////////////////////////////////////
            if (viewCkecked)
            {
                if (cxvInactiveReason.IsChecked == true || cxfInactiveReason.IsChecked == true)
                {
                    sqlCommand += " LEFT JOIN Inactive ON Student.reg_no = Inactive.reg_no";
                }
                if (cxvAddress.IsChecked == true || cxfAddress.IsChecked == true)
                {
                    sqlCommand += " LEFT JOIN S_Address ON Student.reg_no = S_Address.reg_no";
                }
                if (qualificationsRequested)
                {
                    if (cmbxQualType.Text == "O/L")
                    {
                        sqlCommand += " LEFT JOIN O_Level ON Student.reg_no = O_Level.reg_no";
                    }
                    else if (cmbxQualType.Text == "A/L")
                    {
                        sqlCommand += " LEFT JOIN A_Level ON Student.reg_no = A_Level.reg_no";
                    }
                    else
                    {
                        sqlCommand += " LEFT JOIN Other_Qualification ON Student.reg_no = Other_Qualification.reg_no";
                    }
                }


                if (optionsRequested && (cxvSlipNo.IsChecked == true || cxvPaidDate.IsChecked == true || cxvAmount.IsChecked == true || cxvNOPD.IsChecked == true || cxfSlipNo.IsChecked == true || cxfPaidDate.IsChecked == true || cxfAmount.IsChecked == true || cxfNOPD.IsChecked == true || cxfNotPaid.IsChecked == true))
                {
                    sqlCommand += " LEFT JOIN Payment_Option ON Student.Reg_No = Payment_Option.Reg_No RIGHT JOIN ";

                    sqlCommand_1 += sqlCommand + "Option1_12M ON Payment_Option.Reg_No=Option1_12M.Reg_No";
                    sqlCommand_2 += sqlCommand + "Option2_6M ON Payment_Option.Reg_No=Option2_6M.Reg_No";
                    sqlCommand_3 += sqlCommand + "Option3_3M ON Payment_Option.Reg_No=Option3_3M.Reg_No";
                    sqlCommand_4 += sqlCommand + "Option4_1M ON Payment_Option.Reg_No=Option4_1M.Reg_No";


                    sqlCommand = "";
                }

                else if (optionsRequested)
                {
                    sqlCommand += " JOIN Payment_Option ON Student.Reg_No = Payment_Option.Reg_No";
                }

            }
            ////////////////////////////////////////////////////////////////////////////////////////
            if ((viewCkecked && filterChecked) || optionsRequested)
            {
                requestConsidered = false;

                sqlCommand += " WHERE ";

                if (optionsRequested && cxfNotPaid.IsEnabled == true && cxfNotPaid.IsChecked == true)
                {
                    sqlCommand_1 += sqlCommand;
                    sqlCommand_2 += sqlCommand;
                    sqlCommand_3 += sqlCommand;
                    sqlCommand_4 += sqlCommand;

                    sqlCommand_1 += "(DATE_ADD(Paid_Date_1, INTERVAL 12*NOPD MONTH) < NOW()) AND ";
                    sqlCommand_2 += "(DATE_ADD(Paid_Date_1, INTERVAL 6*NOPD MONTH) < NOW()) AND ";
                    sqlCommand_3 += "(DATE_ADD(Paid_Date_1, INTERVAL 3*NOPD MONTH) < NOW()) AND ";
                    sqlCommand_4 += "(DATE_ADD(Paid_Date_1, INTERVAL 1*NOPD MONTH) < NOW()) AND ";

                    sqlCommand = "";
                }
                if (optionsRequested)
                {
                    sqlCommand_1 += sqlCommand;
                    sqlCommand_2 += sqlCommand;
                    sqlCommand_3 += sqlCommand;
                    sqlCommand_4 += sqlCommand;

                    sqlCommand_1 += "PaymentOption = 1 AND ";
                    sqlCommand_2 += "PaymentOption = 2 AND ";
                    sqlCommand_3 += "PaymentOption = 3 AND ";
                    sqlCommand_4 += "PaymentOption = 4 AND ";

                    sqlCommand = "";
                }

                for (int i = 0; i < numCheckBoxes; i++)
                {
                    if (checkboxArrayFilter[i].IsChecked == true)
                    {
                        if (checkboxArrayFilter[i].Name == "cxfReg_No")
                        {
                            sqlCommand += "Student.Reg_No";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfGender")
                        {
                            sqlCommand += checkboxArrayFilter[i].Name.Remove(0, 3);
                            sqlCommand += " = ";
                            if (fieldArrayString[i] == "M")
                            {
                                sqlCommand += "1";
                            }
                            else if (fieldArrayString[i] == "F")
                            {
                                sqlCommand += "0";
                            }
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfRegDate")
                        {
                            sqlCommand += "DATE_FORMAT(RegDate, '%c/%e/%Y') = '" + fieldArrayString[i] + "'";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfAge")
                        {
                            sqlCommand += "TIMESTAMPDIFF(YEAR, DOB, CURDATE()) = '" + fieldArrayString[i] + "'";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfDOB")
                        {
                            sqlCommand += "DATE_FORMAT(DOB, '%c/%e/%Y') = '" + fieldArrayString[i] + "'";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfAddress")
                        {
                            sqlCommand += "(";
                            sqlCommand += "PA_1 LIKE '%" + fieldArrayString[i] + "%' OR ";
                            sqlCommand += "PA_2 LIKE '%" + fieldArrayString[i] + "%' OR ";
                            sqlCommand += "PA_City LIKE '%" + fieldArrayString[i] + "%' OR ";
                            sqlCommand += "PA_Region LIKE '%" + fieldArrayString[i] + "%' OR ";
                            sqlCommand += "MA_1 LIKE '%" + fieldArrayString[i] + "%' OR ";
                            sqlCommand += "MA_2 LIKE '%" + fieldArrayString[i] + "%' OR ";
                            sqlCommand += "MA_City LIKE '%" + fieldArrayString[i] + "%' OR ";
                            sqlCommand += "MA_Region LIKE '%" + fieldArrayString[i] + "%'";
                            sqlCommand += ")";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfQualIndexNo")
                        {
                            if (cmbxQualType.Text == "O/L")
                            {
                                sqlCommand += "OL_Index_No LIKE '%" + fieldArrayString[i] + "%'";
                            }
                            else if (cmbxQualType.Text == "A/L")
                            {
                                sqlCommand += "AL_Index_No LIKE '%" + fieldArrayString[i] + "%'";
                            }
                            else
                            {
                                sqlCommand += "Ref_ID LIKE '%" + fieldArrayString[i] + "%'";
                            }
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfQualYear")
                        {
                            if (cmbxQualType.Text == "O/L")
                            {
                                sqlCommand += "Ex_Year LIKE '%" + fieldArrayString[i] + "%'";
                            }
                            else if (cmbxQualType.Text == "A/L")
                            {
                                sqlCommand += "Ex_Year LIKE '%" + fieldArrayString[i] + "%'";
                            }
                            else
                            {
                                sqlCommand += "QualYear LIKE '%" + fieldArrayString[i] + "%'";
                            }
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfSchlInst")
                        {
                            if (cmbxQualType.Text == "O/L")
                            {
                                sqlCommand += "School LIKE '%" + fieldArrayString[i] + "%'";
                            }
                            else if (cmbxQualType.Text == "A/L")
                            {
                                sqlCommand += "School LIKE '%" + fieldArrayString[i] + "%'";
                            }
                            else
                            {
                                sqlCommand += "Institute LIKE '%" + fieldArrayString[i] + "%'";
                            }
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfScholarship")
                        {
                            sqlCommand += "Scholarship = '" + fieldArrayString[i] + "'";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfRegFee")
                        {
                            sqlCommand += "RegFee = '" + fieldArrayString[i] + "'";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfNOPD")
                        {
                            sqlCommand += "NOPD = '" + fieldArrayString[i] + "'";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfAmount")
                        {
                            sqlCommand += "Amount = '" + fieldArrayString[i] + "'";
                        }
                        else if (checkboxArrayFilter[i].Name == "cxfSlipNo")
                        {
                            sqlCommand += " (";

                            if (cmbxPaymentOption.Text == "12M")
                            {
                                for (int j = 1; j <= 3; j++)
                                {
                                    sqlCommand += "Slip_No_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }
                            if (cmbxPaymentOption.Text == "6M")
                            {
                                for (int j = 1; j <= 6; j++)
                                {
                                    sqlCommand += "Slip_No_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }
                            if (cmbxPaymentOption.Text == "3M")
                            {
                                for (int j = 1; j <= 12; j++)
                                {
                                    sqlCommand += "Slip_No_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }
                            if (cmbxPaymentOption.Text == "1M")
                            {
                                for (int j = 1; j <= 36; j++)
                                {
                                    sqlCommand += "Slip_No_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }
                           

                            sqlCommand = sqlCommand.Remove(sqlCommand.Length - 3);
                            sqlCommand += ") ";

                        }
                        else if (checkboxArrayFilter[i].Name == "cxfPaidDate")
                        {
                            sqlCommand += " (";

                            if (cmbxPaymentOption.Text == "12M")
                            {
                                for (int j = 1; j <= 3; j++)
                                {
                                    sqlCommand += "Paid_Date_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }
                            if (cmbxPaymentOption.Text == "6M")
                            {
                                for (int j = 1; j <= 6; j++)
                                {
                                    sqlCommand += "Paid_Date_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }
                            if (cmbxPaymentOption.Text == "3M")
                            {
                                for (int j = 1; j <= 12; j++)
                                {
                                    sqlCommand += "Paid_Date_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }
                            if (cmbxPaymentOption.Text == "1M")
                            {
                                for (int j = 1; j <= 36; j++)
                                {
                                    sqlCommand += "Paid_Date_" + j + " LIKE  '%" + fieldArrayString[i] + "%' OR ";
                                }
                            }

                            sqlCommand = sqlCommand.Remove(sqlCommand.Length - 3);

                            sqlCommand += ") ";

                        }
                        else
                        {
                            sqlCommand += checkboxArrayFilter[i].Name.Remove(0, 3);
                            sqlCommand += " LIKE ";
                            sqlCommand += "'%";
                            sqlCommand += fieldArrayString[i];
                            sqlCommand += "%'";
                        }


                        sqlCommand += " AND ";
                    }

                    if (cxfLondon.IsEnabled = true && cxfLondon.IsChecked == true)
                    {
                        sqlCommand += "Local_London = 1 AND ";
                    }

                }


                if (optionsRequested)
                {
                    sqlCommand_1 += sqlCommand;
                    sqlCommand_2 += sqlCommand;
                    sqlCommand_3 += sqlCommand;
                    sqlCommand_4 += sqlCommand;

                    sqlCommand_1 = sqlCommand_1.Remove(sqlCommand_1.Length - 4);
                    sqlCommand_2 = sqlCommand_2.Remove(sqlCommand_2.Length - 4);
                    sqlCommand_3 = sqlCommand_3.Remove(sqlCommand_3.Length - 4);
                    sqlCommand_4 = sqlCommand_4.Remove(sqlCommand_4.Length - 4);
                }
                else
                {
                    sqlCommand = sqlCommand.Remove(sqlCommand.Length - 4);
                }

            }

            // sqlCommand += ";";

            

            lblStatus.Content = "";

            txtQueryBox.Text = sqlCommand;
            txtQueryBox_1.Text = sqlCommand_1;

        }

        private void checkedBoxes_Click(object sender, RoutedEventArgs e)
        {
            buildQuary();
        }

        private void checkedBoxes_Click(object sender, MouseButtonEventArgs e)
        {
            buildQuary();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            restart();
        }

        private void btnAddPayment_Click(object sender, RoutedEventArgs e)
        {
            Window3 paymentWindow = new Window3();
            paymentWindow.ShowDialog();

        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Window2 studentWindow = new Window2(1, "", 1);
            studentWindow.ShowDialog();
        }

        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            Window2 studentWindow = new Window2(2, "", deleteBlocked);
            studentWindow.ShowDialog();
        }

        private void dgdOption_1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


        }

        private void dgdMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // if (dgdMain.SelectedCells[0]!=null) {
            //     try
            //     {
            //     Window2 studentWindow = new Window2(2, (dgdMain.SelectedCells[0].Column.GetCellContent(dgdMain.SelectedItem) as TextBlock).ToString());
            //       studentWindow.ShowDialog();
            //     }
            //     catch (Exception ex)
            //     {
            //                    MessageBox.Show(ex.ToString());
            //   MessageBox.Show((dgdMain.SelectedCells[0].Column.GetCellContent(dgdMain.SelectedItem) as object).ToString());
            //     }

            // }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string adminurl = "http://localhost/phpmyadmin/";
                System.Diagnostics.Process.Start(adminurl);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error opening Admin Page";
                MessageBox.Show(ex.ToString());
            }
        }
    }


}