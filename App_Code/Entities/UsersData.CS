// This file was automatically created by LayerGen 0.99e
// Created: 10/03/2010 02:51 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Users Class"
    [Serializable()]
    public class Users
    {
        #region "Instance Variables"
        protected Int64 m_usr_id;
        protected string m_usr_name;
        protected string m_usr_pass;
        protected Int64 m_pmp_pmp_id;
        protected Int64 m_urol_urol_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        #endregion


        #region "Constructors"

        public Users()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Users(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Users(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Usr_Id
        {
            get { return this.m_usr_id; }
            set
            {
                this.m_isDirty = true;
                this.m_usr_id = value;
            }
        }

        public string Usr_Name
        {
            get { return this.m_usr_name; }
            set
            {
                this.m_isDirty = true;
                this.m_usr_name = value;
            }
        }

        public string Usr_Pass
        {
            get { return this.m_usr_pass; }
            set
            {
                this.m_isDirty = true;
                this.m_usr_pass = value;
            }
        }

        public Int64 Pmp_Pmp_Id
        {
            get { return this.m_pmp_pmp_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pmp_pmp_id = value;
            }
        }

        public Int64 Urol_Urol_Id
        {
            get { return this.m_urol_urol_id; }
            set
            {
                this.m_isDirty = true;
                this.m_urol_urol_id = value;
            }
        }

        public bool IsIdentityTable
        {
            get { return false; }
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
                this.m_usr_id = (Int64)dtrRow["USR_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_usr_name = (string)dtrRow["USR_Name"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_usr_pass = (string)dtrRow["USR_Pass"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pmp_pmp_id = (Int64)dtrRow["pmp_pmp_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_urol_urol_id = (Int64)dtrRow["UROL_UROL_ID"];
            }
            catch (Exception)
            {
            }

        }
        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["USR_ID"], DBNull.Value))))
                {
                    this.m_usr_id = (Int64)dtrRow["USR_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["USR_Name"], DBNull.Value))))
                {
                    this.m_usr_name = (string)dtrRow["USR_Name"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["USR_Pass"], DBNull.Value))))
                {
                    this.m_usr_pass = (string)dtrRow["USR_Pass"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["pmp_pmp_id"], DBNull.Value))))
                {
                    this.m_pmp_pmp_id = (Int64)dtrRow["pmp_pmp_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["UROL_UROL_ID"], DBNull.Value))))
                {
                    this.m_urol_urol_id = (Int64)dtrRow["UROL_UROL_ID"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Users_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@USR_ID", SqlDbType.BigInt);
            cmd.Parameters["@USR_ID"].Value = intId;

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
            string storedProcedure = "sp_Users_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@USR_ID", SqlDbType.Int);
            cmd.Parameters["@USR_ID"].Value = this.m_usr_id;

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

                cmd.Parameters.Add("@USR_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@USR_Name", SqlDbType.NVarChar);
                if (this.m_usr_name != null)
                {
                    cmd.Parameters["@USR_Name"].Value = this.m_usr_name;
                }
                else
                {
                    cmd.Parameters["@USR_Name"].Value = "";
                }

                cmd.Parameters.Add("@USR_Pass", SqlDbType.NVarChar);
                if (this.m_usr_pass != null)
                {
                    cmd.Parameters["@USR_Pass"].Value = this.m_usr_pass;
                }
                else
                {
                    cmd.Parameters["@USR_Pass"].Value = "";
                }

                cmd.Parameters.Add("@pmp_pmp_id", SqlDbType.BigInt);
                if (this.m_pmp_pmp_id != 0)
                {
                    cmd.Parameters["@pmp_pmp_id"].Value = this.m_pmp_pmp_id;
                }
                else
                {
                    cmd.Parameters["@pmp_pmp_id"].Value = null;
                }

                cmd.Parameters.Add("@UROL_UROL_ID", SqlDbType.BigInt);
                if (this.m_urol_urol_id != 0)
                {
                    cmd.Parameters["@UROL_UROL_ID"].Value = this.m_urol_urol_id;
                }
                else
                {
                    cmd.Parameters["@UROL_UROL_ID"].Value = null;
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Users_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@USR_ID"].Value = this.m_usr_id;
                    cmd.Parameters["@USR_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Users_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@USR_ID"].Value = this.m_usr_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@USR_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@USR_ID"].Direction = ParameterDirection.Input;
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
                    //    this.m_usr_id = (Int64)cmd.Parameters["@USR_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Users_GetAll";
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



        // Get all records which match the passed value of PMP_ID
        public static DataTable GetByPMP_ID(int PMP_ID)
        {
            string storedProcedure = "sp_Users_GetByPMP_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PMP_ID", SqlDbType.Int);
            cmd.Parameters["@PMP_ID"].Value = PMP_ID;

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



        // Get all records which match the passed value of URol_ID
        public static DataTable GetByURol_ID(int URol_ID)
        {
            string storedProcedure = "sp_Users_GetByURol_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@URol_ID", SqlDbType.Int);
            cmd.Parameters["@URol_ID"].Value = URol_ID;

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
        //     string storedProcedure = "sp_Users_Custom";
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
