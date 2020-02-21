using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/// <summary>
/// Comparing the differences between the Payrun.IO PayHistory + YTD Files and the Star Files
/// import the files to database
/// execute comparison queries
/// user downloads reports
/// </summary>

namespace Comparison_Tool_v2
{
    public partial class Form1 : Form
    {
        string starPH;
        string starYTD;
        bool phSuccess = true;

        string payrunioPH;
        string payrunioYTD;
        bool ytdSuccess = true;

        string saveFileCompanyNumber; //this is to hold the company number for the save file dialogs
        string user;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabPH);
            tabControl.TabPages.Remove(tabYTD);
            tabControl.TabPages.Remove(tabImport);
        }

        private void ClearStarPayHistory()
        {
            string table = null;
            if (lblUser.Text == "Sandie")
            {
                table = "starPayHistory;";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "starPayHistoryIT;";
            }

            string query = $"DELETE FROM {table}";

            string sqlConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        /// <summary>
        /// deletes any data in the star pay history file
        /// </summary>

        private void ClearPayRunPayHistory()
        {
            string table = null;
            if(lblUser.Text == "Sandie")
            {
                table = "payRunPayHistory;";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "payRunPayHistoryIT;";
            }
            
            string query = $"DELETE FROM {table}";

            string sqlConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        /// <summary>
        /// deletes any data in the payrun pay history file
        /// </summary>
        
        private void ImportStarPH()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";

            int counter = 0;
            string line;
            string[] csvValues = new string[58];

            string table = null;
            if (lblUser.Text == "Sandie")
            {
                table = "starPayHistory";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "starPayHistoryIT";
            }

            try
            {
                string file = starPH;
                using (StreamReader sr = new StreamReader(file))
                {
                    connection.Open(); //opening the connection to the database

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (counter == 0) { }
                        else
                        {
                            csvValues = Regex.Split(line, ",");

                            string insertQuery = ("INSERT INTO " + table + " (Co, RunDate, Period_Start_Date, Period_End_Date, Process, PayrollYear, EEid, Gross, NetPay, Batch, CheckVoucher, Account, Transit, DeptName, CostCentreName, BranchName, Days_Hours, StudentLoanStartDate, StudentLoanEndDate, StudentLoanDeductions, NI_Letter, Calculation_Basis, Total, Earnings_To_LEL, Earnings_To_SET, Earnings_To_PET, Earnings_To_UST, Earnings_To_AUST, Earnings_To_UEL, Earnings_Above_UEL, Ee_Contributions_Pt1, Ee_Contributions_Pt2, Er_Contributions, Ee_Rebate, Er_Rebate, Ee_Reduction, LeaveDate, Leaver, TaxCode, Week1_Month1, TaxCodeChangeTypeID, TaxCodeChangeType, TaxPreviousEmt, TaxablePayPreviousEmt, TaxThisEmt, TaxablePayThisEmt, PayCode, PayCodeDesc, PayCodeValue, Det, Rate, Hours, Amount, AccYearBal, PAYEYearBal, ACCYearUnits, PAYEYearUnits, PayrollAccrued) " +
                                                                "VALUES (@Co, @runDate, @Period_Start_Date, @Period_End_Date, @process, @PayrollYear, @EEid, @Gross, @NetPay, @Batch, @CheckVoucher, @Account, @Transit, @DeptName, @CostCentreName, @branchName, @Days_Hours, @StudentLoanStartDate, @StudentLoanEndDate, @StudentLoanDeductions, @NI_Letter, @Calculation_Basis, @Total, @Earnings_To_LEL, @Earnings_To_SET, @Earnings_To_PET, @Earnings_To_UST, @Earnings_To_AUST, @Earnings_To_UEL, @Earnings_Above_UEL, @Ee_Contributions_Pt1, @Ee_Contributions_Pt2, @Er_Contributions, @Ee_Rebate, @Er_Rebate, @Ee_Reduction, @LeaveDate, @Leaver, @TaxCode, @Week1_Month1, @TaxCodeChangeTypeID, @TaxCodeChangeType, @TaxPreviousEmt, @TaxablePayPreviousEmt, @TaxThisEmt, @TaxablePayThisEmt, @PayCode, @payCodeDesc, @payCodeValue, @det, @rate, @hours, @Amount, @AccYearBal, @PAYEYearBal, @AccYearUnits, @PAYEYearUnits, @PayrollAccured)");

                            SqlCommand command = new SqlCommand(insertQuery);
                            command.Connection = connection;

                            command.Parameters.AddWithValue("@co", csvValues[0]);
                            command.Parameters.AddWithValue("@runDate", csvValues[1]);
                            command.Parameters.AddWithValue("@Period_Start_Date", csvValues[2]);
                            command.Parameters.AddWithValue("@Period_End_Date", csvValues[3]);
                            command.Parameters.AddWithValue("@process", csvValues[4]);
                            command.Parameters.AddWithValue("@PayrollYear", csvValues[5]);
                            command.Parameters.AddWithValue("@EEid", csvValues[6]);
                            command.Parameters.AddWithValue("@Gross", csvValues[7]);
                            command.Parameters.AddWithValue("@NetPay", csvValues[8]);
                            command.Parameters.AddWithValue("@Batch", csvValues[9]);
                            command.Parameters.AddWithValue("@CheckVoucher", csvValues[10]);
                            command.Parameters.AddWithValue("@Account", csvValues[11]);
                            command.Parameters.AddWithValue("@Transit", csvValues[12]);
                            command.Parameters.AddWithValue("@DeptName", csvValues[13]);
                            command.Parameters.AddWithValue("@CostCentreName", csvValues[14]);
                            command.Parameters.AddWithValue("@branchName", csvValues[15]);
                            command.Parameters.AddWithValue("@Days_Hours", csvValues[16]);
                            command.Parameters.AddWithValue("@StudentLoanStartDate", csvValues[17]);
                            command.Parameters.AddWithValue("@StudentLoanEndDate", csvValues[18]);
                            command.Parameters.AddWithValue("@StudentLoanDeductions", csvValues[19]);
                            command.Parameters.AddWithValue("@NI_Letter", csvValues[20]);
                            command.Parameters.AddWithValue("@Calculation_Basis", csvValues[21]);
                            command.Parameters.AddWithValue("@Total", csvValues[22]);
                            command.Parameters.AddWithValue("@Earnings_To_LEL", csvValues[23]);
                            command.Parameters.AddWithValue("@Earnings_To_SET", csvValues[24]);
                            command.Parameters.AddWithValue("@Earnings_To_PET", csvValues[25]);
                            command.Parameters.AddWithValue("@Earnings_To_UST", csvValues[26]);
                            command.Parameters.AddWithValue("@Earnings_To_AUST", csvValues[27]);
                            command.Parameters.AddWithValue("@Earnings_To_UEL", csvValues[28]);
                            command.Parameters.AddWithValue("@Earnings_Above_UEL", csvValues[29]);
                            command.Parameters.AddWithValue("@Ee_Contributions_Pt1", csvValues[30]);
                            command.Parameters.AddWithValue("@Ee_Contributions_Pt2", csvValues[31]);
                            command.Parameters.AddWithValue("@Er_Contributions", csvValues[32]);
                            command.Parameters.AddWithValue("@Ee_Rebate", csvValues[33]);
                            command.Parameters.AddWithValue("@Er_Rebate", csvValues[34]);
                            command.Parameters.AddWithValue("@Ee_Reduction", csvValues[35]);
                            command.Parameters.AddWithValue("@LeaveDate", csvValues[36]);
                            command.Parameters.AddWithValue("@Leaver", csvValues[37]);
                            command.Parameters.AddWithValue("@TaxCode", csvValues[38]);
                            command.Parameters.AddWithValue("@Week1_Month1", csvValues[39]);
                            command.Parameters.AddWithValue("@TaxCodeChangeTypeID", csvValues[40]);
                            command.Parameters.AddWithValue("@TaxCodeChangeType", csvValues[41]);
                            command.Parameters.AddWithValue("@TaxPreviousEmt", csvValues[42]);
                            command.Parameters.AddWithValue("@TaxablePayPreviousEmt", csvValues[43]);
                            command.Parameters.AddWithValue("@TaxThisEmt", csvValues[44]);
                            command.Parameters.AddWithValue("@TaxablePayThisEmt", csvValues[45]);
                            command.Parameters.AddWithValue("@PayCode", csvValues[46]);
                            command.Parameters.AddWithValue("@payCodeDesc", csvValues[47]);
                            command.Parameters.AddWithValue("@payCodeValue", csvValues[48]);
                            command.Parameters.AddWithValue("@det", csvValues[49]);
                            command.Parameters.AddWithValue("@rate", csvValues[50]);
                            command.Parameters.AddWithValue("@hours", csvValues[51]);
                            command.Parameters.AddWithValue("@Amount", csvValues[52]);
                            command.Parameters.AddWithValue("@AccYearBal", csvValues[53]);
                            command.Parameters.AddWithValue("@PAYEYearBal", csvValues[54]);
                            command.Parameters.AddWithValue("@AccYearUnits", csvValues[55]);
                            command.Parameters.AddWithValue("@PAYEYearUnits", csvValues[56]);
                            command.Parameters.AddWithValue("@PayrollAccured", csvValues[57]);

                            command.ExecuteNonQuery();
                        }
                        counter++;
                    }
                    sr.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cant Read File");
                MessageBox.Show(exception.Message);
                phSuccess = false;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// this method is responsible for importing the star ph files
        /// </summary>

        private void ImportPayRunIOPH()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";

            int counter = 0;
            string line;
            string[] csvValues = new string[58];

            string table = null;
            if (lblUser.Text == "Sandie")
            {
                table = "payRunPayHistory";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "payRunPayHistoryIT";
            }

            try
            {
                string file = payrunioPH;
                using (StreamReader sr = new StreamReader(file))
                {
                    connection.Open(); //opening the connection to the database

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (counter == 0) { }
                        else
                        {
                            csvValues = Regex.Split(line, ",");

                            for (int i = 0; i < csvValues.Length; i++) //taking out the " " thats wraped around the csv values
                            {
                                csvValues[i] = csvValues[i].Replace(@"""", String.Empty);
                            }

                            string insertQuery = ("INSERT INTO " + table + " (Co, RunDate, Period_Start_Date, Period_End_Date, Process, PayrollYear, EEid, Gross, NetPay, Batch, CheckVoucher, Account, Transit, DeptName, CostCentreName, BranchName, Days_Hours, StudentLoanStartDate, StudentLoanEndDate, StudentLoanDeductions, NI_Letter, Calculation_Basis, Total, Earnings_To_LEL, Earnings_To_SET, Earnings_To_PET, Earnings_To_UST, Earnings_To_AUST, Earnings_To_UEL, Earnings_Above_UEL, Ee_Contributions_Pt1, Ee_Contributions_Pt2, Er_Contributions, Ee_Rebate, Er_Rebate, Ee_Reduction, LeaveDate, Leaver, TaxCode, Week1_Month1, TaxCodeChangeTypeID, TaxCodeChangeType, TaxPreviousEmt, TaxablePayPreviousEmt, TaxThisEmt, TaxablePayThisEmt, PayCode, PayCodeDesc, PayCodeValue, Det, Rate, Hours, Amount, AccYearBal, PAYEYearBal, ACCYearUnits, PAYEYearUnits, PayrollAccrued) " +
                                                                "VALUES (@Co, @RunDate, @Period_Start_Date, @Period_End_Date, @Process, @PayrollYear, @EEid, @Gross, @NetPay, @Batch, @CheckVoucher, @Account, @Transit, @DeptName, @CostCentreName, @branchName, @Days_Hours, @StudentLoanStartDate, @StudentLoanEndDate, @StudentLoanDeductions, @NI_Letter, @Calculation_Basis, @Total, @Earnings_To_LEL, @Earnings_To_SET, @Earnings_To_PET, @Earnings_To_UST, @Earnings_To_AUST, @Earnings_To_UEL, @Earnings_Above_UEL, @Ee_Contributions_Pt1, @Ee_Contributions_Pt2, @Er_Contributions, @Ee_Rebate, @Er_Rebate, @Ee_Reduction, @LeaveDate, @Leaver, @TaxCode, @Week1_Month1, @TaxCodeChangeTypeID, @TaxCodeChangeType, @TaxPreviousEmt, @TaxablePayPreviousEmt, @TaxThisEmt, @TaxablePayThisEmt, @PayCode, @payCodeDesc, @payCodeValue, @det, @rate, @hours, @Amount, @AccYearBal, @PAYEYearBal, @AccYearUnits, @PAYEYearUnits, @PayrollAccured)");

                            SqlCommand command = new SqlCommand(insertQuery);
                            command.Connection = connection;

                            command.Parameters.AddWithValue("@co", csvValues[0]);
                            command.Parameters.AddWithValue("@runDate", csvValues[1]);
                            command.Parameters.AddWithValue("@Period_Start_Date", csvValues[2]);
                            command.Parameters.AddWithValue("@Period_End_Date", csvValues[3]);
                            command.Parameters.AddWithValue("@process", csvValues[4]);
                            command.Parameters.AddWithValue("@PayrollYear", csvValues[5]);
                            command.Parameters.AddWithValue("@EEid", csvValues[6]);
                            command.Parameters.AddWithValue("@Gross", csvValues[7]);
                            command.Parameters.AddWithValue("@NetPay", csvValues[8]);
                            command.Parameters.AddWithValue("@Batch", csvValues[9]);
                            command.Parameters.AddWithValue("@CheckVoucher", csvValues[10]);
                            command.Parameters.AddWithValue("@Account", csvValues[11]);
                            command.Parameters.AddWithValue("@Transit", csvValues[12]);
                            command.Parameters.AddWithValue("@DeptName", csvValues[13]);
                            command.Parameters.AddWithValue("@CostCentreName", csvValues[14]);
                            command.Parameters.AddWithValue("@branchName", csvValues[15]);
                            command.Parameters.AddWithValue("@Days_Hours", csvValues[16]);
                            command.Parameters.AddWithValue("@StudentLoanStartDate", csvValues[17]);
                            command.Parameters.AddWithValue("@StudentLoanEndDate", csvValues[18]);
                            command.Parameters.AddWithValue("@StudentLoanDeductions", csvValues[19]);
                            command.Parameters.AddWithValue("@NI_Letter", csvValues[20]);
                            command.Parameters.AddWithValue("@Calculation_Basis", csvValues[21]);
                            command.Parameters.AddWithValue("@Total", csvValues[22]);
                            command.Parameters.AddWithValue("@Earnings_To_LEL", csvValues[23]);
                            command.Parameters.AddWithValue("@Earnings_To_SET", csvValues[24]);
                            command.Parameters.AddWithValue("@Earnings_To_PET", csvValues[25]);
                            command.Parameters.AddWithValue("@Earnings_To_UST", csvValues[26]);
                            command.Parameters.AddWithValue("@Earnings_To_AUST", csvValues[27]);
                            command.Parameters.AddWithValue("@Earnings_To_UEL", csvValues[28]);
                            command.Parameters.AddWithValue("@Earnings_Above_UEL", csvValues[29]);
                            command.Parameters.AddWithValue("@Ee_Contributions_Pt1", csvValues[30]);
                            command.Parameters.AddWithValue("@Ee_Contributions_Pt2", csvValues[31]);
                            command.Parameters.AddWithValue("@Er_Contributions", csvValues[32]);
                            command.Parameters.AddWithValue("@Ee_Rebate", csvValues[33]);
                            command.Parameters.AddWithValue("@Er_Rebate", csvValues[34]);
                            command.Parameters.AddWithValue("@Ee_Reduction", csvValues[35]);
                            command.Parameters.AddWithValue("@LeaveDate", csvValues[36]);
                            command.Parameters.AddWithValue("@Leaver", csvValues[37]);
                            command.Parameters.AddWithValue("@TaxCode", csvValues[38]);
                            command.Parameters.AddWithValue("@Week1_Month1", csvValues[39]);
                            command.Parameters.AddWithValue("@TaxCodeChangeTypeID", csvValues[40]);
                            command.Parameters.AddWithValue("@TaxCodeChangeType", csvValues[41]);
                            command.Parameters.AddWithValue("@TaxPreviousEmt", csvValues[42]);
                            command.Parameters.AddWithValue("@TaxablePayPreviousEmt", csvValues[43]);
                            command.Parameters.AddWithValue("@TaxThisEmt", csvValues[44]);
                            command.Parameters.AddWithValue("@TaxablePayThisEmt", csvValues[45]);
                            command.Parameters.AddWithValue("@PayCode", csvValues[46]);
                            command.Parameters.AddWithValue("@payCodeDesc", csvValues[47]);
                            command.Parameters.AddWithValue("@payCodeValue", csvValues[48]);
                            command.Parameters.AddWithValue("@det", csvValues[49]);
                            command.Parameters.AddWithValue("@rate", csvValues[50]);
                            command.Parameters.AddWithValue("@hours", csvValues[51]);
                            command.Parameters.AddWithValue("@Amount", csvValues[52]);
                            command.Parameters.AddWithValue("@AccYearBal", csvValues[53]);
                            command.Parameters.AddWithValue("@PAYEYearBal", csvValues[54]);
                            command.Parameters.AddWithValue("@AccYearUnits", csvValues[55]);
                            command.Parameters.AddWithValue("@PAYEYearUnits", csvValues[56]);
                            command.Parameters.AddWithValue("@PayrollAccured", csvValues[57]);

                            command.ExecuteNonQuery();

                        }
                        counter++;
                    }
                    sr.Close();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Cant Read File");
                MessageBox.Show(exception.Message);
                phSuccess = false;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// this method is responsible for importing the pr ph files
        /// </summary>

        private void ClearPayRunYTD()
        {
            string table = null;
            if (lblUser.Text == "Sandie")
            {
                table = "payRunYearToDates;";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "payRunYearToDatesIT;";
            }

            string query = $"DELETE FROM {table}";

            string sqlConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        /// <summary>
        /// deletes any data in the ytd file
        /// </summary>

        private void ClearStarYTD()
        {
            string table = null;
            if (lblUser.Text == "Sandie")
            {
                table = "starYearToDates;";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "starYearToDatesIT;";
            }

            string query = $"DELETE FROM {table}";

            string sqlConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        /// <summary>
        /// deletes any data in the ytd file
        /// </summary>

        private void ImportStarYTD()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";

            int counter = 0;
            string line;
            string[] csvValues = new string[56];

            string table = null;
            if (lblUser.Text == "Sandie")
            {
                table = "starYearToDates";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "starYearToDatesIT";
            }

            try
            {
                string file = starYTD;
                using (StreamReader sr = new StreamReader(file))
                {
                    connection.Open();

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (counter == 0) { }
                        else
                        {
                            csvValues = Regex.Split(line, ",");

                            string insertQuery = ("INSERT INTO " + table + " (Co, RunDate, Process, Batch, EeRef, LeaveDate, Leaver, TaxPreviousEmt, TaxablePayPreviousEmt, TaxThisEmt, TaxablePayThisEmt, GrossedUp, GrossedUpTax, NetPay, GrossYTD, BenefitInKind, Superannuation, HolidayPay, ErPensionYTD, EePensionYTD, AEOYTD, StudentLoanStartDate, StudentLoanEndDate, StudentLoanDeductions, NILetter, Total, EarningsToLEL, EarningsToSET, EarningsToPET, EarningsToUST, EarningsToAUST, EarningsToUEL, EarningsAboveUEL, EeContributionsPt1, EeContributionsPt2, ErContributions, EeRebate, ErRebate, EeReduction, PayCode, Det, PayCodeValue, PayCodeDesc, AccYearBal, PAYEYearBal, AccYearUnits, PAYEYearUnits, TaxCode, Week1Month1, WeekNumber, MonthNumber, NIEarningsYTD, StudentLoanPlanType, PostgraduateLoanStartDate, PostgraduateLoanEndDate, PostgraduateLoanDeducted) " +
                                                             "VALUES (@Co, @RunDate, @Process, @Batch, @EeRef, @LeaveDate, @Leaver, @TaxPreviousEmt, @TaxablePayPreviousEmt, @TaxThisEmt, @TaxablePayThisEmt, @GrossedUp, @GrossedUpTax, @NetPay, @GrossYTD, @BenefitInKind, @Superannuation, @HolidayPay, @ErPensionYTD, @EePensionYTD, @AEOYTD, @StudentLoanStartDate, @StudentLoanEndDate, @StudentLoanDeductions, @NILetter, @Total, @EarningsToLEL, @EarningsToSET, @EarningsToPET, @EarningsToUST, @EarningsToAUST, @EarningsToUEL, @EarningsAboveUEL, @EeContributionsPt1, @EeContributionsPt2, @ErContributions, @EeRebate, @ErRebate, @EeReduction, @PayCode, @Det, @PayCodeValue, @PayCodeDesc, @AccYearBal, @PAYEYearBal, @AccYearUnits, @PAYEYearUnits, @TaxCode, @Week1Month1, @WeekNumber, @MonthNumber, @NIEarningsYTD, @StudentLoanPlanType, @PostgraduateLoanStartDate, @PostgraduateLoanEndDate, @PostgraduateLoanDeducted)");

                            SqlCommand command = new SqlCommand(insertQuery);

                            command.Connection = connection;

                            command.Parameters.AddWithValue("@Co", csvValues[0]);
                            command.Parameters.AddWithValue("@RunDate", csvValues[1]);
                            command.Parameters.AddWithValue("@Process", csvValues[2]);
                            command.Parameters.AddWithValue("@Batch", csvValues[3]);
                            command.Parameters.AddWithValue("@EeRef", csvValues[4]);
                            command.Parameters.AddWithValue("@LeaveDate", csvValues[5]);
                            command.Parameters.AddWithValue("@Leaver", csvValues[6]);
                            command.Parameters.AddWithValue("@TaxPreviousEmt", csvValues[7]);
                            command.Parameters.AddWithValue("@TaxablePayPreviousEmt", csvValues[8]);
                            command.Parameters.AddWithValue("@TaxThisEmt", csvValues[9]);
                            command.Parameters.AddWithValue("@TaxablePayThisEmt", csvValues[10]);
                            command.Parameters.AddWithValue("@GrossedUp", csvValues[11]);
                            command.Parameters.AddWithValue("@GrossedUpTax", csvValues[12]);
                            command.Parameters.AddWithValue("@NetPay", csvValues[13]);
                            command.Parameters.AddWithValue("@GrossYTD", csvValues[14]);
                            command.Parameters.AddWithValue("@BenefitInKind", csvValues[15]);
                            command.Parameters.AddWithValue("@Superannuation", csvValues[16]);
                            command.Parameters.AddWithValue("@HolidayPay", csvValues[17]);
                            command.Parameters.AddWithValue("@ErPensionYTD", csvValues[18]);
                            command.Parameters.AddWithValue("@EePensionYTD", csvValues[19]);
                            command.Parameters.AddWithValue("@AEOYTD", csvValues[20]);
                            command.Parameters.AddWithValue("@StudentLoanStartDate", csvValues[21]);
                            command.Parameters.AddWithValue("@StudentLoanEndDate", csvValues[22]);
                            command.Parameters.AddWithValue("@StudentLoanDeductions", csvValues[23]);
                            command.Parameters.AddWithValue("@NILetter", csvValues[24]);
                            command.Parameters.AddWithValue("@Total", csvValues[25]);
                            command.Parameters.AddWithValue("@EarningsToLEL", csvValues[26]);
                            command.Parameters.AddWithValue("@EarningsToSET", csvValues[27]);
                            command.Parameters.AddWithValue("@EarningsToPET", csvValues[28]);
                            command.Parameters.AddWithValue("@EarningsToUST", csvValues[29]);
                            command.Parameters.AddWithValue("@EarningsToAUST", csvValues[30]);
                            command.Parameters.AddWithValue("@EarningsToUEL", csvValues[31]);
                            command.Parameters.AddWithValue("@EarningsAboveUEL", csvValues[32]);
                            command.Parameters.AddWithValue("@EeContributionsPt1", csvValues[33]);
                            command.Parameters.AddWithValue("@EeContributionsPt2", csvValues[34]);
                            command.Parameters.AddWithValue("@ErContributions", csvValues[35]);
                            command.Parameters.AddWithValue("@EeRebate", csvValues[36]);
                            command.Parameters.AddWithValue("@ErRebate", csvValues[37]);
                            command.Parameters.AddWithValue("@EeReduction", csvValues[38]);
                            command.Parameters.AddWithValue("@PayCode", csvValues[39]);
                            command.Parameters.AddWithValue("@Det", csvValues[40]);
                            command.Parameters.AddWithValue("@PayCodeValue", csvValues[41]);
                            command.Parameters.AddWithValue("@PayCodeDesc", csvValues[42]);
                            command.Parameters.AddWithValue("@AccYearBal", csvValues[43]);
                            command.Parameters.AddWithValue("@PAYEYearBal", csvValues[44]);
                            command.Parameters.AddWithValue("@AccYearUnits", csvValues[45]);
                            command.Parameters.AddWithValue("@PAYEYearUnits", csvValues[46]);
                            command.Parameters.AddWithValue("@TaxCode", csvValues[47]);
                            command.Parameters.AddWithValue("@Week1Month1", csvValues[48]);
                            command.Parameters.AddWithValue("@WeekNumber", csvValues[49]);
                            command.Parameters.AddWithValue("@MonthNumber", csvValues[50]);
                            command.Parameters.AddWithValue("@NIEarningsYTD", csvValues[51]);
                            command.Parameters.AddWithValue("@StudentLoanPlanType", csvValues[52]);
                            command.Parameters.AddWithValue("@PostgraduateLoanStartDate", csvValues[53]);
                            command.Parameters.AddWithValue("@PostgraduateLoanEndDate", csvValues[54]);
                            command.Parameters.AddWithValue("@PostgraduateLoanDeducted", csvValues[55]);

                            command.ExecuteNonQuery();
                        }
                        counter++;
                    }
                    sr.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cant Read File");
                MessageBox.Show(exception.Message);
                ytdSuccess = false;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// this method is responsible for importing the star ytd files
        /// </summary>

        private void ImportPayRunioYTD()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";

            int counter = 0;
            string line;
            string[] csvValues = new string[56];

            string table = null;
            if (lblUser.Text == "Sandie")
            {
                table = "payRunYearToDates";
            }
            else if (lblUser.Text == "IT Team")
            {
                table = "payRunYearToDatesIT";
            }

            try
            {
                string file = payrunioYTD;
                using (StreamReader sr = new StreamReader(file))
                {
                    connection.Open();

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (counter == 0) { }
                        else
                        {
                            csvValues = Regex.Split(line, ",");

                            for (int i = 0; i < csvValues.Length; i++) //taking out the " " thats wraped around the csv values
                            {
                                csvValues[i] = csvValues[i].Replace(@"""", String.Empty);
                            }

                            string insertQuery = ("INSERT INTO " + table + " (Co, RunDate, Process, Batch, EeRef, LeaveDate, Leaver, TaxPreviousEmt, TaxablePayPreviousEmt, TaxThisEmt, TaxablePayThisEmt, GrossedUp, GrossedUpTax, NetPay, GrossYTD, BenefitInKind, Superannuation, HolidayPay, ErPensionYTD, EePensionYTD, AEOYTD, StudentLoanStartDate, StudentLoanEndDate, StudentLoanDeductions, NILetter, Total, EarningsToLEL, EarningsToSET, EarningsToPET, EarningsToUST, EarningsToAUST, EarningsToUEL, EarningsAboveUEL, EeContributionsPt1, EeContributionsPt2, ErContributions, EeRebate, ErRebate, EeReduction, PayCode, Det, PayCodeValue, PayCodeDesc, AccYearBal, PAYEYearBal, AccYearUnits, PAYEYearUnits, TaxCode, Week1Month1, WeekNumber, MonthNumber, NIEarningsYTD, StudentLoanPlanType, PostgraduateLoanStartDate, PostgraduateLoanEndDate, PostgraduateLoanDeducted) " +
                                                             "VALUES (@Co, @RunDate, @Process, @Batch, @EeRef, @LeaveDate, @Leaver, @TaxPreviousEmt, @TaxablePayPreviousEmt, @TaxThisEmt, @TaxablePayThisEmt, @GrossedUp, @GrossedUpTax, @NetPay, @GrossYTD, @BenefitInKind, @Superannuation, @HolidayPay, @ErPensionYTD, @EePensionYTD, @AEOYTD, @StudentLoanStartDate, @StudentLoanEndDate, @StudentLoanDeductions, @NILetter, @Total, @EarningsToLEL, @EarningsToSET, @EarningsToPET, @EarningsToUST, @EarningsToAUST, @EarningsToUEL, @EarningsAboveUEL, @EeContributionsPt1, @EeContributionsPt2, @ErContributions, @EeRebate, @ErRebate, @EeReduction, @PayCode, @Det, @PayCodeValue, @PayCodeDesc, @AccYearBal, @PAYEYearBal, @AccYearUnits, @PAYEYearUnits, @TaxCode, @Week1Month1, @WeekNumber, @MonthNumber, @NIEarningsYTD, @StudentLoanPlanType, @PostgraduateLoanStartDate, @PostgraduateLoanEndDate, @PostgraduateLoanDeducted)");

                            SqlCommand command = new SqlCommand(insertQuery);
                            
                            command.Connection = connection;

                            command.Parameters.AddWithValue("@Co", csvValues[0]);
                            command.Parameters.AddWithValue("@RunDate", csvValues[1]);
                            command.Parameters.AddWithValue("@Process", csvValues[2]);
                            command.Parameters.AddWithValue("@Batch", csvValues[3]);
                            command.Parameters.AddWithValue("@EeRef", csvValues[4]);
                            command.Parameters.AddWithValue("@LeaveDate", csvValues[5]);
                            command.Parameters.AddWithValue("@Leaver", csvValues[6]);
                            command.Parameters.AddWithValue("@TaxPreviousEmt", csvValues[7]);
                            command.Parameters.AddWithValue("@TaxablePayPreviousEmt", csvValues[8]);
                            command.Parameters.AddWithValue("@TaxThisEmt", csvValues[9]);
                            command.Parameters.AddWithValue("@TaxablePayThisEmt", csvValues[10]);
                            command.Parameters.AddWithValue("@GrossedUp", csvValues[11]);
                            command.Parameters.AddWithValue("@GrossedUpTax", csvValues[12]);
                            command.Parameters.AddWithValue("@NetPay", csvValues[13]);
                            command.Parameters.AddWithValue("@GrossYTD", csvValues[14]);
                            command.Parameters.AddWithValue("@BenefitInKind", csvValues[15]);
                            command.Parameters.AddWithValue("@Superannuation", csvValues[16]);
                            command.Parameters.AddWithValue("@HolidayPay", csvValues[17]);
                            command.Parameters.AddWithValue("@ErPensionYTD", csvValues[18]);
                            command.Parameters.AddWithValue("@EePensionYTD", csvValues[19]);
                            command.Parameters.AddWithValue("@AEOYTD", csvValues[20]);
                            command.Parameters.AddWithValue("@StudentLoanStartDate", csvValues[21]);
                            command.Parameters.AddWithValue("@StudentLoanEndDate", csvValues[22]);
                            command.Parameters.AddWithValue("@StudentLoanDeductions", csvValues[23]);
                            command.Parameters.AddWithValue("@NILetter", csvValues[24]);
                            command.Parameters.AddWithValue("@Total", csvValues[25]);
                            command.Parameters.AddWithValue("@EarningsToLEL", csvValues[26]);
                            command.Parameters.AddWithValue("@EarningsToSET", csvValues[27]);
                            command.Parameters.AddWithValue("@EarningsToPET", csvValues[28]);
                            command.Parameters.AddWithValue("@EarningsToUST", csvValues[29]);
                            command.Parameters.AddWithValue("@EarningsToAUST", csvValues[30]);
                            command.Parameters.AddWithValue("@EarningsToUEL", csvValues[31]);
                            command.Parameters.AddWithValue("@EarningsAboveUEL", csvValues[32]);
                            command.Parameters.AddWithValue("@EeContributionsPt1", csvValues[33]);
                            command.Parameters.AddWithValue("@EeContributionsPt2", csvValues[34]);
                            command.Parameters.AddWithValue("@ErContributions", csvValues[35]);
                            command.Parameters.AddWithValue("@EeRebate", csvValues[36]);
                            command.Parameters.AddWithValue("@ErRebate", csvValues[37]);
                            command.Parameters.AddWithValue("@EeReduction", csvValues[38]);
                            command.Parameters.AddWithValue("@PayCode", csvValues[39]);
                            command.Parameters.AddWithValue("@Det", csvValues[40]);
                            command.Parameters.AddWithValue("@PayCodeValue", csvValues[41]);
                            command.Parameters.AddWithValue("@PayCodeDesc", csvValues[42]);
                            command.Parameters.AddWithValue("@AccYearBal", csvValues[43]);
                            command.Parameters.AddWithValue("@PAYEYearBal", csvValues[44]);
                            command.Parameters.AddWithValue("@AccYearUnits", csvValues[45]);
                            command.Parameters.AddWithValue("@PAYEYearUnits", csvValues[46]);
                            command.Parameters.AddWithValue("@TaxCode", csvValues[47]);
                            command.Parameters.AddWithValue("@Week1Month1", csvValues[48]);
                            command.Parameters.AddWithValue("@WeekNumber", csvValues[49]);
                            command.Parameters.AddWithValue("@MonthNumber", csvValues[50]);
                            command.Parameters.AddWithValue("@NIEarningsYTD", csvValues[25]); //this is correct but only temporary. james is adding this column to the ytd file i will change once he has this done.
                            command.Parameters.AddWithValue("@StudentLoanPlanType", csvValues[52]);
                            command.Parameters.AddWithValue("@PostgraduateLoanStartDate", csvValues[53]);
                            command.Parameters.AddWithValue("@PostgraduateLoanEndDate", csvValues[54]);
                            command.Parameters.AddWithValue("@PostgraduateLoanDeducted", csvValues[55]);

                            command.ExecuteNonQuery();
                        }
                        counter++;
                    }
                    sr.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cant Read File");
                MessageBox.Show(exception.Message);
                ytdSuccess = false;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// this method is responsible for importing the payrun.io ytd files
        /// </summary>

        private void btnPayHistoryPR_MouseEnter_1(object sender, EventArgs e)
        {
            btnPayHistoryPR.BackColor = Color.FromArgb(21, 66, 139);
            btnPayHistoryPR.ForeColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnPayHistoryPR_MouseLeave_1(object sender, EventArgs e)
        {
            btnPayHistoryPR.BackColor = Color.White;
            btnPayHistoryPR.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnYearToDatePR_MouseEnter_1(object sender, EventArgs e)
        {
            btnYearToDatePR.BackColor = Color.FromArgb(21, 66, 139);
            btnYearToDatePR.ForeColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnYearToDatePR_MouseLeave_1(object sender, EventArgs e)
        {
            btnYearToDatePR.BackColor = Color.White;
            btnYearToDatePR.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnPayHistoryStar_MouseEnter_1(object sender, EventArgs e)
        {
            btnPayHistoryStar.BackColor = Color.FromArgb(21, 66, 139);
            btnPayHistoryStar.ForeColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnPayHistoryStar_MouseLeave_1(object sender, EventArgs e)
        {
            btnPayHistoryStar.BackColor = Color.White;
            btnPayHistoryStar.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnYearToDateStar_MouseEnter_1(object sender, EventArgs e)
        {
            btnYearToDateStar.BackColor = Color.FromArgb(21, 66, 139);
            btnYearToDateStar.ForeColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnYearToDateStar_MouseLeave_1(object sender, EventArgs e)
        {
            btnYearToDateStar.BackColor = Color.White;
            btnYearToDateStar.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>
        /// 
        private void lblImportPH_MouseEnter_1(object sender, EventArgs e)
        {
            lblImportPH.BackColor = Color.Gainsboro;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblImportPH_MouseLeave_1(object sender, EventArgs e)
        {
            lblImportPH.BackColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblImportYTD_MouseEnter_1(object sender, EventArgs e)
        {
            lblImportYTD.BackColor = Color.Gainsboro;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblImportYTD_MouseLeave_1(object sender, EventArgs e)
        {
            lblImportYTD.BackColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblClear_MouseEnter_1(object sender, EventArgs e)
        {
            lblClear.BackColor = Color.Gainsboro;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblClear_MouseLeave_1(object sender, EventArgs e)
        {
            lblClear.BackColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnDownloadPH_MouseEnter(object sender, EventArgs e)
        {
            btnDownloadPH.BackColor = Color.FromArgb(21, 66, 139);
            btnDownloadPH.ForeColor = Color.White;
        }
        /// <summary>
         /// hover effect
         /// </summary>

        private void btnDownloadPH_MouseLeave(object sender, EventArgs e)
        {
            btnDownloadPH.BackColor = Color.White;
            btnDownloadPH.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnDownloadYTD_MouseEnter(object sender, EventArgs e)
        {
            btnDownloadYTD.BackColor = Color.FromArgb(21, 66, 139);
            btnDownloadYTD.ForeColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnDownloadYTD_MouseLeave(object sender, EventArgs e)
        {
            btnDownloadYTD.BackColor = Color.White;
            btnDownloadYTD.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnDownloadPayCodesYTD_MouseEnter(object sender, EventArgs e)
        {
            btnDownloadPayCodesYTD.BackColor = Color.FromArgb(21, 66, 139);
            btnDownloadPayCodesYTD.ForeColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnDownloadPayCodesYTD_MouseLeave(object sender, EventArgs e)
        {
            btnDownloadPayCodesYTD.BackColor = Color.White;
            btnDownloadPayCodesYTD.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnDownloadPayCodesPH_MouseEnter(object sender, EventArgs e)
        {
            btnDownloadPayCodesPH.BackColor = Color.FromArgb(21, 66, 139);
            btnDownloadPayCodesPH.ForeColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnDownloadPayCodesPH_MouseLeave(object sender, EventArgs e)
        {
            btnDownloadPayCodesPH.BackColor = Color.White;
            btnDownloadPayCodesPH.ForeColor = Color.FromArgb(21, 66, 139);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblConfirm_MouseEnter(object sender, EventArgs e)
        {
            lblConfirm.BackColor = Color.Gainsboro;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblConfirm_MouseLeave(object sender, EventArgs e)
        {
            lblConfirm.BackColor = Color.White;
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblClosePHPanel_MouseEnter(object sender, EventArgs e)
        {
            lblClosePHPanel.Font = new Font(lblClosePHPanel.Font.Name, lblClosePHPanel.Font.SizeInPoints, FontStyle.Underline);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblClosePHPanel_MouseLeave(object sender, EventArgs e)
        {
            lblClosePHPanel.Font = new Font(lblClosePHPanel.Font.Name, lblClosePHPanel.Font.SizeInPoints, FontStyle.Regular);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblCloseYTDPanel_MouseEnter(object sender, EventArgs e)
        {
            lblCloseYTDPanel.Font = new Font(lblCloseYTDPanel.Font.Name, lblCloseYTDPanel.Font.SizeInPoints, FontStyle.Underline);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void lblCloseYTDPanel_MouseLeave(object sender, EventArgs e)
        {
            lblCloseYTDPanel.Font = new Font(lblCloseYTDPanel.Font.Name, lblCloseYTDPanel.Font.SizeInPoints, FontStyle.Regular);
        }
        /// <summary>
        /// hover effect
        /// </summary>

        private void btnPayHistoryPR_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.DefaultExt = ".CSV";
            openfiledialog.Filter = "csv (*.csv)|*.csv";
            openfiledialog.ShowDialog();

            payrunioPH = openfiledialog.FileName;
            string file = openfiledialog.FileName;
            lblPayHistoryPR.Text = file.Substring(file.LastIndexOf('\\') + 1);
            toolTip1.SetToolTip(lblPayHistoryPR, file);
            try
            {
                saveFileCompanyNumber = file.Substring(file.LastIndexOf('\\') + 1).Substring(0, 4);

                string[] lines = File.ReadAllLines(file);
                int rows = lines.Length;
                int columns = lines[0].Split(',').Length;
                int row1 = lines[1].Split(',').Length;
                lblColCountPRPH.Text = $"ColCount : {columns}";
                lblRowCountPrPH.Text = $"RowCount : {row1}";
            }
            catch (Exception ex){ }
        }
        /// <summary>
        /// user selecthing the file to upload
        /// count the columns and columns in the first row
        /// </summary>

        private void btnYearToDatePR_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.DefaultExt = ".CSV";
            openfiledialog.Filter = "csv (*.csv)|*.csv";
            openfiledialog.ShowDialog();

            payrunioYTD = openfiledialog.FileName;
            string file = openfiledialog.FileName;
            lblYearToDatePR.Text = file.Substring(file.LastIndexOf('\\') + 1);
            toolTip1.SetToolTip(lblYearToDatePR, file);
            try
            {
                saveFileCompanyNumber = file.Substring(file.LastIndexOf('\\') + 1).Substring(0, 4);

                string[] lines = File.ReadAllLines(file);
                int rows = lines.Length;
                int columns = lines[0].Split(',').Length;
                int row1 = lines[1].Split(',').Length;
                lblColCountPRYTD.Text = $"ColCount : {columns}";
                lblRowCountPrYTD.Text = $"RowCount : {row1}";
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// user selecthing the file to upload
        /// count the columns and columns in the first row
        /// </summary>

        private void btnPayHistoryStar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.DefaultExt = ".CSV";
            openfiledialog.Filter = "csv (*.csv)|*.csv";
            openfiledialog.ShowDialog();

            starPH = openfiledialog.FileName;
            string file = openfiledialog.FileName;
            lblPayHistoryStar.Text = file.Substring(file.LastIndexOf('\\') + 1);
            toolTip1.SetToolTip(lblPayHistoryStar, file);
            try
            {
                string[] lines = File.ReadAllLines(file);
                int rows = lines.Length;
                int columns = lines[0].Split(',').Length;
                int row1 = lines[1].Split(',').Length;
                lblColCountStarPH.Text = $"ColCount : {columns}";
                lblRowCountStarPH.Text = $"RowCount : {row1}";
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// user selecthing the file to upload
        /// count the columns and the columns in the first row
        /// </summary>

        private void btnYearToDateStar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.DefaultExt = ".CSV";
            openfiledialog.Filter = "csv (*.csv)|*.csv";
            openfiledialog.ShowDialog();

            starYTD = openfiledialog.FileName;
            string file = openfiledialog.FileName;
            lblYearToDateStar.Text = file.Substring(file.LastIndexOf('\\') + 1);
            toolTip1.SetToolTip(lblYearToDateStar, file);
            try
            {
                string[] lines = File.ReadAllLines(file);
                int rows = lines.Length;
                int columns = lines[0].Split(',').Length;
                int row1 = lines[1].Split(',').Length;
                lblColCountStarYTD.Text = $"ColCount : {columns}";
                lblRowCountStarYTD.Text = $"RowCount : {row1}";
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// user selecthing the file to upload
        /// count the columns and the columns in the first row
        /// </summary>

        private void lblClear_Click(object sender, EventArgs e)
        {
            lblPayHistoryPR.Text = "";
            lblPayHistoryStar.Text = "";
            lblYearToDatePR.Text = "";
            lblYearToDateStar.Text = "";
            lblColCountPRPH.Text = "";
            lblColCountPRYTD.Text = "";
            lblColCountStarPH.Text = "";
            lblColCountStarYTD.Text = "";
            lblRowCountPrPH.Text = "";
            lblRowCountPrYTD.Text = "";
            lblRowCountStarPH.Text = "";
            lblRowCountStarYTD.Text = "";

            dgvEePH.Rows.Clear();
            dgvEeYTD.Rows.Clear();
            panelPHEes.Visible = false;
            panelYTDEes.Visible = false;

            starPH = null;
            starYTD = null;
            payrunioPH = null;
            payrunioYTD = null;

            if (tabControl.TabPages.Contains(tabYTD)) { tabControl.TabPages.Remove(tabYTD); }
            if (tabControl.TabPages.Contains(tabPH)) { tabControl.TabPages.Remove(tabPH); }
        }
        /// <summary>
        /// clearing the files & everything else that needs cleared
        /// </summary>

        private void lblImportPH_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(lblPayHistoryPR.Text) && String.IsNullOrWhiteSpace(lblPayHistoryStar.Text)) //checking if there is any files
            {
                MessageBox.Show("You have not selected any Pay History files to upload!");
                return;
            }

            if (!String.IsNullOrWhiteSpace(lblPayHistoryPR.Text) && String.IsNullOrWhiteSpace(lblPayHistoryStar.Text))
            {
                MessageBox.Show("Please enter the Star pay history file!");
                return;
            }

            if (!String.IsNullOrWhiteSpace(lblPayHistoryStar.Text) && String.IsNullOrWhiteSpace(lblPayHistoryPR.Text))
            {
                MessageBox.Show("Please enter the PayRun.IO pay history file!");
                return;
            }

                ClearPayRunPayHistory();
                ClearStarPayHistory();

                ImportStarPH();
                ImportPayRunIOPH();
            
            if (phSuccess)
            {
                MessageBox.Show("Pay History Files Imported.");
                if (!tabControl.TabPages.Contains(tabPH)) { tabControl.TabPages.Add(tabPH); }
            }
        }
        /// <summary>
        /// importing the two ph files if present
        /// delete data in the payhistory tables before inserting data from csv files
        /// </summary>

        private void lblImportYTD_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(lblYearToDatePR.Text) && String.IsNullOrWhiteSpace(lblYearToDateStar.Text)) //checking if there is any files
            {
                MessageBox.Show("You have not selected any YTD files to upload!");
                return;
            }

            if (!String.IsNullOrWhiteSpace(lblYearToDatePR.Text) && String.IsNullOrWhiteSpace(lblYearToDateStar.Text))
            {
                MessageBox.Show("Please enter the Star YTD file!");
                return;
            }

            if (!String.IsNullOrWhiteSpace(lblYearToDateStar.Text) && String.IsNullOrWhiteSpace(lblYearToDatePR.Text))
            {
                MessageBox.Show("Please enter the PayRun.IO YTD file!");
                return;
            }

            ClearPayRunYTD();
            ClearStarYTD();

            ImportStarYTD();
            ImportPayRunioYTD();

            if (ytdSuccess)
            {
                MessageBox.Show("YTD Files Imported.");
                if (!tabControl.TabPages.Contains(tabYTD)) { tabControl.TabPages.Add(tabYTD); }
            }
        }
        /// <summary>
        /// importing the two ytd files if present
        /// delete data in the YTD tables before inserting data from csv files
        /// </summary>

        private void btnDownloadPH_Click(object sender, EventArgs e)
        {
            DataSet sqlDataSet = new DataSet();
            string queryPath = "J:\\Shared Data\\Data\\Queries\\SQL\\";
            string query;

            string file = null;
            if (lblUser.Text == "Sandie")
            {
                file = "comparisonPayHistoryFiles.sql";
            }
            else if (lblUser.Text == "IT Team")
            {
                file = "comparisonPayHistoryFilesIT.sql";
            }

            using (StreamReader stream = new StreamReader(queryPath + file))
            {
                query = stream.ReadToEnd();
            }

            string connectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(sqlDataSet, "comparisonPH");
                sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve PayHistory Data.\r\n" + ex);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            sfdPH.FileName = saveFileCompanyNumber + "_PayHistoryDifferences.csv";

            if (sfdPH.ShowDialog() == DialogResult.OK)
            {
                DataRowCollection rows = sqlDataSet.Tables["comparisonPH"].Rows;
                int columnCount = sqlDataSet.Tables["comparisonPH"].Columns.Count;
                string csvLine = "";

                using (StreamWriter writer = new StreamWriter(sfdPH.FileName))
                {
                    writer.WriteLine("Column Name, EeRef, Star Values, PR Values, Difference");

                    foreach (DataRow row in rows)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            csvLine = csvLine + row[i] + ",";
                        }
                        writer.WriteLine(csvLine);
                        csvLine = "";
                    }
                    sqlDataSet.Tables["comparisonPH"].Clear();
                    MessageBox.Show("Report Created Successfully");
                }
            }
        }
        /// <summary>
        /// downloading the differences in the PH files
        /// </summary>

        private void btnDownloadYTD_Click(object sender, EventArgs e)
        {
            DataSet sqlDataSet = new DataSet();
            string queryPath = "J:\\Shared Data\\Data\\Queries\\SQL\\";
            string query;

            string file = null;
            if (lblUser.Text == "Sandie")
            {
                file = "comparisonYTDFiles.sql";
            }
            else if (lblUser.Text == "IT Team")
            {
                file = "comparisonYTDFilesIT.sql";
            }

            using (StreamReader stream = new StreamReader(queryPath + file))
            {
                query = stream.ReadToEnd();
            }

            string connectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(sqlDataSet, "comparisonYTD");
                sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve YTD Data.\r\n\r\n" + ex);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            sfdYTD.FileName = saveFileCompanyNumber + "_YTDDifferences.csv";

            if (sfdYTD.ShowDialog() == DialogResult.OK)
            {
                DataRowCollection rows = sqlDataSet.Tables["comparisonYTD"].Rows;
                int columnCount = sqlDataSet.Tables["comparisonYTD"].Columns.Count;
                string csvLine = "";

                using (StreamWriter writer = new StreamWriter(sfdYTD.FileName))
                {
                    writer.WriteLine("Column Name, EeRef, Star Values, PR Values, Difference");

                    foreach (DataRow row in rows)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            csvLine = csvLine + row[i] + ",";
                        }
                        writer.WriteLine(csvLine);
                        csvLine = "";
                    }
                    sqlDataSet.Tables["comparisonYTD"].Clear();
                    MessageBox.Show("Report Created Successfully");
                }
            }
        }
        /// <summary>
        /// downloading the differences in the YTD files
        /// </summary>

        private void btnDownloadPayCodesPH_Click(object sender, EventArgs e)
        {
            DataSet sqlDataSet = new DataSet();
            string queryPath = "J:\\Shared Data\\Data\\Queries\\SQL\\";
            string query;

            string file = null;
            if (lblUser.Text == "Sandie")
            {
                file = "comparisonPayHistoryPayCodes.sql";
            }
            else if (lblUser.Text == "IT Team")
            {
                file = "comparisonPayHistoryPayCodesIT.sql";
            }

            using (StreamReader stream = new StreamReader(queryPath + file))
            {
                query = stream.ReadToEnd();
            }

            string connectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(sqlDataSet, "comparisonPHPayCodes");
                sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve YTD Data.\r\n\r\n" + ex);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            sfdPHPayCodes.FileName = saveFileCompanyNumber + "_PhPayCodes.csv";

            if (sfdPHPayCodes.ShowDialog() == DialogResult.OK)
            {
                DataRowCollection rows = sqlDataSet.Tables["comparisonPHPayCodes"].Rows;
                int columnCount = sqlDataSet.Tables["comparisonPHPayCodes"].Columns.Count;
                string csvLine = "";

                using (StreamWriter writer = new StreamWriter(sfdPHPayCodes.FileName))
                {
                    writer.WriteLine("EeRef, StarPayCodeDesc, PayRunioPayCodeDesc, StarPayCodeValue, PayRunioPayCodeValue");

                    foreach (DataRow row in rows)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            csvLine = csvLine + row[i] + ",";
                        }
                        writer.WriteLine(csvLine);
                        csvLine = "";
                    }
                    sqlDataSet.Tables["comparisonPHPayCodes"].Clear();
                    MessageBox.Show("Report Created Successfully");
                }
            }
        }
        /// <summary>
        /// downloading the paycode differences in the payhistory file
        /// </summary>

        private void btnDownloadPayCodesYTD_Click(object sender, EventArgs e)
        {
            DataSet sqlDataSet = new DataSet();
            string queryPath = "J:\\Shared Data\\Data\\Queries\\SQL\\";
            string query;

            string file = null;
            if (lblUser.Text == "Sandie")
            {
                file = "comparisonYTDPaycodes.sql";
            }
            else if (lblUser.Text == "IT Team")
            {
                file = "comparisonYTDPaycodesIT.sql";
            }

            using (StreamReader stream = new StreamReader(queryPath + file))
            {
                query = stream.ReadToEnd();
            }

            string connectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(sqlDataSet, "comparisonYTDPayCodes");
                sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve YTD Data.\r\n\r\n" + ex);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            sfdYtdPayCodes.FileName = saveFileCompanyNumber + "_YtdPayCodes.csv";

            if (sfdYtdPayCodes.ShowDialog() == DialogResult.OK)
            {
                DataRowCollection rows = sqlDataSet.Tables["comparisonYTDPayCodes"].Rows;
                int columnCount = sqlDataSet.Tables["comparisonYTDPayCodes"].Columns.Count;
                string csvLine = "";

                using (StreamWriter writer = new StreamWriter(sfdYtdPayCodes.FileName))
                {
                    writer.WriteLine("EeRef, StarPayCodeDesc, PayRunioPayCodeDesc, StarPayCodeValue, PayRunioPayCodeValue");

                    foreach (DataRow row in rows)
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            csvLine = csvLine + row[i] + ",";
                        }
                        writer.WriteLine(csvLine);
                        csvLine = "";
                    }
                    sqlDataSet.Tables["comparisonYTDPayCodes"].Clear();
                    MessageBox.Show("Report Created Successfully");
                }
            }
        }
        /// <summary>
        /// downloading the paycode differences in the ytd file
        /// </summary>

        private void lblConfirm_Click(object sender, EventArgs e)
        {
            if (radSandie.Checked)
            {
                user = "Sandie";
                lblUser.Text = user;
            }
            else if (radIT.Checked)
            {
                user = "IT Team";
                lblUser.Text = user;
            }
            tabControl.TabPages.Remove(tabUser);
            tabControl.TabPages.Add(tabImport);
        }
        /// <summary>
        /// user selects who is using the application
        /// </summary>

        private void chkEes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEes.Checked)
            {
                panelPHEes.Visible = true;
                chkEes.Visible = false;

                DataSet sqlDataSet = new DataSet();
                string queryPath = "J:\\Shared Data\\Data\\Queries\\SQL\\";
                string query;

                string file = null;
                if (lblUser.Text == "Sandie")
                {
                    file = "comparisonPayHistoryEes.sql";
                }
                else if (lblUser.Text == "IT Team")
                {
                    file = "comparisonPayHistoryEesIT.sql";
                }

                using (StreamReader stream = new StreamReader(queryPath + file))
                {
                    query = stream.ReadToEnd();
                }

                string connectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(sqlDataSet, "comparison");
                    sqlCommand.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to retrieve YTD Data.\r\n\r\n" + ex);
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    DataRowCollection rows = sqlDataSet.Tables["comparison"].Rows;
                    int line = 0;

                    foreach (DataRow row in rows)
                    {
                        dgvEePH.Rows.Add();
                        dgvEePH.Rows[line].Cells[0].Value = row.ItemArray[0].ToString();
                        dgvEePH.Rows[line].Cells[1].Value = row.ItemArray[1].ToString();
                        line++;
                    }
                    sqlDataSet.Clear();
                    sqlDataSet.Dispose();
                }
            }
            else if (!chkEes.Checked) { panelPHEes.Visible = false; }
        }
        /// <summary>
        /// checking to see if their is any employees missing from pay history files
        /// </summary>

        private void lblClosePHPanel_Click(object sender, EventArgs e)
        {
            panelPHEes.Visible = false;
            chkEes.Visible = true;
            chkEes.Checked = false;
            dgvEePH.Rows.Clear();
        }
        /// <summary>
        /// closing the pay history employees panel
        /// </summary>

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panelYTDEes.Visible = true;
                checkBox1.Visible = false;

                DataSet sqlDataSet = new DataSet();
                string queryPath = "J:\\Shared Data\\Data\\Queries\\SQL\\";
                string query;

                string file = null;
                if (lblUser.Text == "Sandie")
                {
                    file = "comparisonYTDEes.sql";
                }
                else if (lblUser.Text == "IT Team")
                {
                    file = "comparisonYTDEesIT.sql";
                }

                using (StreamReader stream = new StreamReader(queryPath + file))
                {
                    query = stream.ReadToEnd();
                }

                string connectionString = "Data Source = PESCAPE-SRV1\\SQL2012STAR; Initial Catalog = Unity; User ID = sa; Password = JB20soft14;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(sqlDataSet, "comparison");
                    sqlCommand.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to retrieve YTD Data.\r\n\r\n" + ex);
                }
                finally
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();

                    DataRowCollection rows = sqlDataSet.Tables["comparison"].Rows;
                    int line = 0;

                    foreach (DataRow row in rows)
                    {
                        dgvEeYTD.Rows.Add();
                        dgvEeYTD.Rows[line].Cells[0].Value = row.ItemArray[0].ToString();
                        dgvEeYTD.Rows[line].Cells[1].Value = row.ItemArray[1].ToString();
                        line++;
                    }
                    sqlDataSet.Clear();
                    sqlDataSet.Dispose();
                    label3.Focus();
                }
            }
            else if (!checkBox1.Checked) { panelYTDEes.Visible = false; }
        }
        /// <summary>
        /// checking to see if their is any employees missing from ytd files
        /// </summary>

        private void lblCloseYTDPanel_Click(object sender, EventArgs e)
        {
            panelYTDEes.Visible = false;
            checkBox1.Visible = true;
            checkBox1.Checked = false;
            dgvEeYTD.Rows.Clear();
        }
        /// <summary>
        /// closing the ytd employees panel
        /// </summary>
    }
}