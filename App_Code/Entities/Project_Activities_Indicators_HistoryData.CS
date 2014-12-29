// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Project_Activities_Indicators_History Class"
    [Serializable()]
    public class Project_Activities_Indicators_History
    {
        #region "Instance Variables"
        protected Int64 m_paih_id;
        protected Decimal m_paih_value;
        protected System.DateTime m_paih_date;
        protected string m_paih_resp_person;
        protected Int64 m_pai_pai_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        protected BLL.Project_Activities_Indicators myProject_activities_indicators;

        #endregion


        #region "Constructors"

        public Project_Activities_Indicators_History()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Project_Activities_Indicators_History(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Project_Activities_Indicators_History(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Paih_Id
        {
            get { return this.m_paih_id; }
            set
            {
                this.m_isDirty = true;
                this.m_paih_id = value;
            }
        }

        public Decimal Paih_Value
        {
            get { return this.m_paih_value; }
            set
            {
                this.m_isDirty = true;
                this.m_paih_value = value;
            }
        }

        public System.DateTime Paih_Date
        {
            get { return this.m_paih_date; }
            set
            {
                this.m_isDirty = true;
                this.m_paih_date = value;
            }
        }

        public string Paih_Resp_Person
        {
            get { return this.m_paih_resp_person; }
            set
            {
                this.m_isDirty = true;
                this.m_paih_resp_person = value;
            }
        }

        public Int64 Pai_Pai_Id
        {
            get { return this.m_pai_pai_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pai_pai_id = value;
            }
        }

        public bool IsIdentityTable
        {
            get { return true; }
        }

        #endregion

        protected void SetConnectString()
        {
            ConnectString = DBL.Universal.GetConnectionString();
        }

        protected string GetConnectString()
        {
            return ConnectString;
        }

        protected static string GetConnectionString()
        {
            return DBL.Universal.GetConnectionString();
        }

        public void Copy(DataRow dtrRow)
        {
            try
            {
                this.m_paih_id = (Int64)dtrRow["PAIH_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_paih_value = (Decimal)dtrRow["PAIH_Value"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_paih_date = (System.DateTime)dtrRow["PAIH_Date"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_paih_resp_person = (string)dtrRow["PAIH_Resp_Person"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pai_pai_id = (Int64)dtrRow["pai_pai_id"];
            }
            catch (Exception)
            {
            }

        }
        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PAIH_ID"], DBNull.Value))))
                {
                    this.m_paih_id = (Int64)dtrRow["PAIH_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PAIH_Value"], DBNull.Value))))
                {
                    this.m_paih_value = (Decimal)dtrRow["PAIH_Value"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PAIH_Date"], DBNull.Value))))
                {
                    this.m_paih_date = (System.DateTime)dtrRow["PAIH_Date"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PAIH_Resp_Person"], DBNull.Value))))
                {
                    this.m_paih_resp_person = (string)dtrRow["PAIH_Resp_Person"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["pai_pai_id"], DBNull.Value))))
                {
                    this.m_pai_pai_id = (Int64)dtrRow["pai_pai_id"];
                }
            }
            catch (Exception)
            {
            }
        }

        private void Get(Int64 intId)
        {
            string storedProcedure = "sp_Project_Activities_Indicators_History_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PAIH_ID", SqlDbType.BigInt);
            cmd.Parameters["@PAIH_ID"].Value = intId;

            try
            {
                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Fill(ds.Tables[0].Rows[0]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_Project_Activities_Indicators_History_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PAIH_ID", SqlDbType.Int);
            cmd.Parameters["@PAIH_ID"].Value = this.m_paih_id;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            conn.Close();
        }

        public void Save()
        {
            string storedProcedure;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            if ((this.myProject_activities_indicators != null))
            {
                myProject_activities_indicators.Save();
            }

            if ((m_isDirty))
            {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PAIH_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@PAIH_Value", SqlDbType.Decimal);
                if (this.m_paih_value != 0M)
                {
                    cmd.Parameters["@PAIH_Value"].Value = this.m_paih_value;
                }
                else
                {
                    cmd.Parameters["@PAIH_Value"].Value = null;
                }

                cmd.Parameters.Add("@PAIH_Date", SqlDbType.DateTime);
                if (this.m_paih_date != null)
                {
                    cmd.Parameters["@PAIH_Date"].Value = this.m_paih_date;
                }
                else
                {
                    cmd.Parameters["@PAIH_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@PAIH_Resp_Person", SqlDbType.NVarChar);
                if (this.m_paih_resp_person != null)
                {
                    cmd.Parameters["@PAIH_Resp_Person"].Value = this.m_paih_resp_person;
                }
                else
                {
                    cmd.Parameters["@PAIH_Resp_Person"].Value = "";
                }

                cmd.Parameters.Add("@pai_pai_id", SqlDbType.BigInt);
                if (this.m_pai_pai_id != 0)
                {
                    cmd.Parameters["@pai_pai_id"].Value = this.m_pai_pai_id;
                }
                else
                {
                    cmd.Parameters["@pai_pai_id"].Value = null;
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Project_Activities_Indicators_History_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PAIH_ID"].Value = this.m_paih_id;
                    cmd.Parameters["@PAIH_ID"].Direction = ParameterDirection.Input;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    conn.Close();
                }
                else
                {
                    storedProcedure = "sp_Project_Activities_Indicators_History_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PAIH_ID"].Value = this.m_paih_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@PAIH_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@PAIH_ID"].Direction = ParameterDirection.Input;
                    }
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    if (IsIdentityTable)
                    {
                        this.m_paih_id = (Int64)cmd.Parameters["@PAIH_ID"].Value;
                    }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Activities_Indicators_History_GetAll";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;

            try
            {
                DataSet ds;
                System.Data.SqlClient.SqlDataAdapter da;
                DataTable Table = null;

                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Table = ds.Tables[0];
                    }
                }
                conn.Close();
                return Table;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }



        // Get all records which match the passed value of PAI_ID
        public static DataTable GetByPAI_ID(int PAI_ID)
        {
            string storedProcedure = "sp_Project_Activities_Indicators_History_GetByPAI_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PAI_ID", SqlDbType.Int);
            cmd.Parameters["@PAI_ID"].Value = PAI_ID;

            try
            {
                DataSet ds;
                System.Data.SqlClient.SqlDataAdapter da;
                DataTable Table = null;

                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Table = ds.Tables[0];
                    }
                }
                conn.Close();
                return Table;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
            conn.Close();
        }


        #region "Custom Query Methods"
        // TODO: Add your own custom queries here. To do this, simply
        // create a stored procedure in your database. Then use the
        // sample code below as a guide to calling your stored
        // procedure. Also, make sure you make the appropriate changes
        // in the Business layer to call this function. See the region
        // called "Custom Query Methods" in the business
        // layer code. 
        //
        // public static DataTable GetByFirstName(string FirstName)
        // {
        //     string storedProcedure = "sp_Project_Activities_Indicators_History_Custom";
        //     System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
        //     string ConnectionString = GetConnectionString();
        //     System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(); 
        //
        //     conn.ConnectionString = ConnectionString;
        //     cmd.CommandType = CommandType.StoredProcedure;
        //     cmd.Connection = conn;
        //     cmd.CommandText = storedProcedure;
        //     cmd.Parameters.Add("@fname", SqlDbType.VarChar);
        //     cmd.Parameters["@fname"].Value = FirstName;
        //
        //     try {
        //         DataSet ds; 
        //         System.Data.SqlClient.SqlDataAdapter da;
        //         DataTable Table = null;
        //
        //         conn.Open();
        //         da = new System.Data.SqlClient.SqlDataAdapter();
        //         da.SelectCommand = cmd;
        //
        //         ds = new DataSet();
        //         da.Fill(ds);
        //
        //         if (ds.Tables.Count > 0) {
        //            if (ds.Tables[0].Rows.Count > 0) {
        //                 Table = ds.Tables[0];
        //            }
        //         }
        //         conn.Close();
        //         return Table;
        //      }
        //      catch (Exception e) {
        //         throw;
        //      }
        //     conn.Close();
        // }
        //

        #endregion
    }
    #endregion
}
