// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Indicators_Type Class"
    [Serializable()]
    public class Indicators_Type
    {
        #region "Instance Variables"
        protected Int64 m_indt_id;
        protected string m_indt_desc;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        #endregion


        #region "Constructors"

        public Indicators_Type()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Indicators_Type(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Indicators_Type(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Indt_Id
        {
            get { return this.m_indt_id; }
            set
            {
                this.m_isDirty = true;
                this.m_indt_id = value;
            }
        }

        public string Indt_Desc
        {
            get { return this.m_indt_desc; }
            set
            {
                this.m_isDirty = true;
                this.m_indt_desc = value;
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
                this.m_indt_id = (Int64)dtrRow["IndT_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_indt_desc = (string)dtrRow["IndT_Desc"];
            }
            catch (Exception)
            {
            }

        }
        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["IndT_id"], DBNull.Value))))
                {
                    this.m_indt_id = (Int64)dtrRow["IndT_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["IndT_Desc"], DBNull.Value))))
                {
                    this.m_indt_desc = (string)dtrRow["IndT_Desc"];
                }
            }
            catch (Exception)
            {
            }
        }

        private void Get(Int64 intId)
        {
            string storedProcedure = "sp_Indicators_Type_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@IndT_id", SqlDbType.BigInt);
            cmd.Parameters["@IndT_id"].Value = intId;

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
            string storedProcedure = "sp_Indicators_Type_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@IndT_id", SqlDbType.Int);
            cmd.Parameters["@IndT_id"].Value = this.m_indt_id;

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

            if ((m_isDirty))
            {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@IndT_id", SqlDbType.BigInt);
                cmd.Parameters.Add("@IndT_Desc", SqlDbType.NVarChar);
                if (this.m_indt_desc != null)
                {
                    cmd.Parameters["@IndT_Desc"].Value = this.m_indt_desc;
                }
                else
                {
                    cmd.Parameters["@IndT_Desc"].Value = "";
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Indicators_Type_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@IndT_id"].Value = this.m_indt_id;
                    cmd.Parameters["@IndT_id"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Indicators_Type_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@IndT_id"].Value = this.m_indt_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@IndT_id"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@IndT_id"].Direction = ParameterDirection.Input;
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
                        this.m_indt_id = (Int64)cmd.Parameters["@IndT_id"].Value;
                    }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Indicators_Type_GetAll";
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
        //     string storedProcedure = "sp_Indicators_Type_Custom";
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
