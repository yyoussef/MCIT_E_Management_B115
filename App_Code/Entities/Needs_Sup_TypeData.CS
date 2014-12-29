// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Needs_Sup_Type Class"
    [Serializable()]
    public class Needs_Sup_Type
    {
        #region "Instance Variables"
        protected Int64 m_nst_id;
        protected string m_nst_desc;
        protected Int64 m_nmt_nmt_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        protected BLL.Needs_Main_Type myNeeds_main_type;

        #endregion


        #region "Constructors"

        public Needs_Sup_Type()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Needs_Sup_Type(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Needs_Sup_Type(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Nst_Id
        {
            get { return this.m_nst_id; }
            set
            {
                this.m_isDirty = true;
                this.m_nst_id = value;
            }
        }

        public string Nst_Desc
        {
            get { return this.m_nst_desc; }
            set
            {
                this.m_isDirty = true;
                this.m_nst_desc = value;
            }
        }

        public Int64 Nmt_Nmt_Id
        {
            get { return this.m_nmt_nmt_id; }
            set
            {
                this.m_isDirty = true;
                this.m_nmt_nmt_id = value;
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
                this.m_nst_id = (Int64)dtrRow["NST_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_nst_desc = (string)dtrRow["NST_Desc"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_nmt_nmt_id = (Int64)dtrRow["nmt_nmt_id"];
            }
            catch (Exception)
            {
            }

        }

        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["NST_ID"], DBNull.Value))))
                {
                    this.m_nst_id = (Int64)dtrRow["NST_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["NST_Desc"], DBNull.Value))))
                {
                    this.m_nst_desc = (string)dtrRow["NST_Desc"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["nmt_nmt_id"], DBNull.Value))))
                {
                    this.m_nmt_nmt_id = (Int64)dtrRow["nmt_nmt_id"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Needs_Sup_Type_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@NST_ID", SqlDbType.BigInt);
            cmd.Parameters["@NST_ID"].Value = intId;

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
            return ds.Tables[0];
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_Needs_Sup_Type_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@NST_ID", SqlDbType.Int);
            cmd.Parameters["@NST_ID"].Value = this.m_nst_id;

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

            if ((this.myNeeds_main_type != null))
            {
                myNeeds_main_type.Save();
            }

            if ((m_isDirty))
            {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NST_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@NST_Desc", SqlDbType.NVarChar);
                if (this.m_nst_desc != null)
                {
                    cmd.Parameters["@NST_Desc"].Value = this.m_nst_desc;
                }
                else
                {
                    cmd.Parameters["@NST_Desc"].Value = "";
                }

                cmd.Parameters.Add("@nmt_nmt_id", SqlDbType.BigInt);
                if (this.m_nmt_nmt_id != 0)
                {
                    cmd.Parameters["@nmt_nmt_id"].Value = this.m_nmt_nmt_id;
                }
                else
                {
                    cmd.Parameters["@nmt_nmt_id"].Value = null;
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Needs_Sup_Type_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@NST_ID"].Value = this.m_nst_id;
                    cmd.Parameters["@NST_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Needs_Sup_Type_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@NST_ID"].Value = this.m_nst_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@NST_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@NST_ID"].Direction = ParameterDirection.Input;
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
                    //if (IsIdentityTable)
                    //{
                    //    this.m_nst_id = (Int64)cmd.Parameters["@NST_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Needs_Sup_Type_GetAll";
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



        // Get all records which match the passed value of NMT_ID
        public static DataTable GetByNMT_ID(int NMT_ID)
        {
            string storedProcedure = "sp_Needs_Sup_Type_GetByNMT_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@NMT_ID", SqlDbType.Int);
            cmd.Parameters["@NMT_ID"].Value = NMT_ID;

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
        //     string storedProcedure = "sp_Needs_Sup_Type_Custom";
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
