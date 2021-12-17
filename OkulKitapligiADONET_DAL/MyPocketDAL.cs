using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulKitapligiADONET_DAL
{
    public class MyPocketDAL
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

        private string _sqlConnectionString;

        public string SQLConnectionString
        {
            get
            {
                return _sqlConnectionString;
            }

        }

        private SqlConnection mySQLConnection = new SqlConnection();

        private SqlCommand mySQLCommand = new SqlCommand();

        private SqlDataAdapter mySQLAdapter = new SqlDataAdapter();

        public MyPocketDAL(string serverName, string dbname, string userid, string password)
        {
            //MyPocketDAL classından bir nesne türetilirken sql server name ve parola alınacak. Alınan değerler bu class'ın sahip olduğu SQLConnectionString property'sine atanacak.
            //Böylece bu class yapacağı tüm sql işlemlerinde connection stringi buradan alacak
            //Bir kere yazdık bu class'ın birçok metodunda kullabiliriz.
            this.ServerName = serverName;
            this.DatabaseName = dbname;
            this.UserID = userid;
            this.Password = password;

            if (string.IsNullOrEmpty(this.ServerName) || string.IsNullOrEmpty(this.DatabaseName))
            {
                throw new Exception("SQLConnection string için Server name ve database name gereklidir!");
            }
            else if (string.IsNullOrEmpty(this.UserID) && string.IsNullOrEmpty(this.Password))
            {
                //windows authentication
                this._sqlConnectionString = @"Server=" + this.ServerName + ";Database=" + this.DatabaseName + ";Trusted_Connection=True";

            }
            else
            {
                //server authentication
                this._sqlConnectionString = @"Data Source=" + this.ServerName + ";Initial Catalog=" + this.DatabaseName + ";Persist Security Info=True;User ID=" + this.UserID + ";Password=" + this.Password;
            }

        }

        public DataTable GetTheData(string tableName, string fieldName, string condition)
        {
            //returnValue----->retVal
            DataTable retVal = new DataTable();
            string queryString = "";
            if (string.IsNullOrEmpty(condition))
            {
                queryString = "Select " + fieldName + " from " + tableName;
            }

            else
            {
                queryString = "Select " + fieldName + " from " + tableName + " where " + condition;
            }

            using (this.mySQLConnection)
            {
                this.mySQLCommand = new SqlCommand(queryString, this.mySQLConnection);

                OpentheConnection();
                this.mySQLAdapter = new SqlDataAdapter(this.mySQLCommand);
                this.mySQLAdapter.Fill(retVal);

            }

            return retVal;
        }
        public DataTable GetTheData(string query)
        {
            DataTable retVal = new DataTable();
            using (this.mySQLConnection)
            {
                this.mySQLCommand = new SqlCommand(query, this.mySQLConnection);

                OpentheConnection();
                this.mySQLAdapter = new SqlDataAdapter(this.mySQLCommand);
                this.mySQLAdapter.Fill(retVal);

            }

            return retVal;
        }
        public void OpentheConnection()
        {
            try
            {
                if (this.mySQLConnection.State != ConnectionState.Open)
                {
                    this.mySQLConnection.ConnectionString = this.SQLConnectionString;
                    this.mySQLConnection.Open();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ClosetheConnection()
        {
            try
            {
                if (this.mySQLConnection.State != ConnectionState.Closed)
                {
                    this.mySQLConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public object GetTheDataByExecuteScalar(string query)
        {
            object retVal = null;

            using (this.mySQLConnection)
            {

                this.mySQLCommand = new SqlCommand(query, this.mySQLConnection);
                OpentheConnection();
                retVal = this.mySQLCommand.ExecuteScalar();

            }

            return retVal;
        }

        //insert ile ilgili işlemler
        //1. adım insert query cümlesi oluşturmak
        public string CreateInsertQueryAsString(string tableName, Hashtable htData)
        {
            string retVal = string.Empty;
            string theFields = "", theValues = "";
            foreach (string theKey in htData.Keys)
            {
                string theValue = htData[theKey].ToString();
                theFields += theKey + ",";  //OgrId,BaslangicTarihi,BitisTarihi,KitapId,
                theValues += theValue + ",";
            }


            //en sondaki virgüllerden kurtuluyoruz.
            theFields = theFields.TrimEnd(','); //Trim Traşlamak demekti. En sondaki virgülü traşlayacak.
            theValues = theValues.TrimEnd(',');


            retVal = "insert into " + tableName + "(" + theFields + ") values (" + theValues + ")";

            return retVal;
        }


        //Update ile ilgili işlemler
        public string CreateUpdateQueryAsString(string tableName, Hashtable htData, string condition)
        {
            string retVal = string.Empty;

            string theSet = string.Empty;
            foreach (string theKey in htData)
            {
                //KitapAd = 'Yeni Kitap' --> yeni htData'daki anahtarı ve değerini yan yana almam gerekli.

                theSet += theKey + "=" + htData[theKey].ToString() + ",";
            }
            theSet = theSet.TrimEnd(',');


            retVal = "update " + tableName + " set " + theSet + " where " + condition;
            return retVal;

        }


        //Delete ile ilgili query cümlesi oluşturan metot
        public string CreateDeleteQueryAsString(string tableName, string condition)
        {
            string retVal = string.Empty;

            retVal = "delete from " + tableName + " where " + condition;

            return retVal;
        }

        public string CreateDeleteQueryAsString(string tableName, Hashtable htData)
        {
            string retVal = string.Empty;
            if (htData.Count == 1)
            {
                foreach (string theKey in htData)
                {
                    retVal = "delete from " + tableName + " where " + theKey + "=" + htData[theKey].ToString();

                }

            }

            else
            {
                string deleteConditions = string.Empty;
                foreach (string theKey in htData)
                {
                    deleteConditions += theKey + "=" + htData[theKey].ToString() + " and ";
                }
                deleteConditions.TrimEnd();
                //deleteConditions.TrimEnd("dna".ToCharArray());
                deleteConditions.TrimEnd('d');
                deleteConditions.TrimEnd('n');
                deleteConditions.TrimEnd('a');

                retVal = "delete from " + tableName + " where " + deleteConditions;
            }


            return retVal;
        }

        //2. adım executenonquery işlemini TRANSACTION ile yapmak
        public bool ExecuteTheQueriesWithTransaction(params string[] theQueries)
        {
            bool retVal = false;
            SqlTransaction myTransaction = null;
            try
            {
                using (this.mySQLConnection)
                {
                    OpentheConnection();
                    myTransaction = this.mySQLConnection.BeginTransaction();

                    //işlemler
                    foreach (string item in theQueries)
                    {
                        this.mySQLCommand = new SqlCommand(item,this.mySQLConnection,myTransaction);
                        this.mySQLCommand.ExecuteNonQuery();
                    }

                    myTransaction.Commit();
                    retVal = true;
                }

            }
            catch (Exception ex)
            {
                myTransaction.Rollback();
                retVal = false;
                throw ex;
            }



            return retVal;
        }



        //insert update ve delete cümlelerini executenonquery ile işleyen metot
        public int ExecuteTheQuery(string theQuery)
        {

            int rowsAffected = 0;

            using (this.mySQLConnection)
            {
                this.mySQLCommand = new SqlCommand(theQuery, this.mySQLConnection);
                OpentheConnection();
                rowsAffected = this.mySQLCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("HATA : Kayıt eklenemedi.");
                }
            }

            return rowsAffected;

        }



    }
}
