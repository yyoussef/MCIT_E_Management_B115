// This file was automatically created by LayerGen 0.99e
// Created: 07/04/2010 01:09 م

using System;
using System.Data;

#pragma warning disable 162


namespace DBL
{
    #region "Departments Class"
    [Serializable()]
    public class Departments
    {
        #region "Instance Variables"
        protected Int64 m_dept_id;
        protected string m_dept_name;
        protected Int64 m_deptt_deptt_id;
        protected Int64 m_dept_parent;
        protected Int64 m_sec_sec_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        #endregion


        #region "Constructors"

        public Departments()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Departments(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Departments(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Dept_Id
        {
            get { return this.m_dept_id; }
            set
            {
                this.m_isDirty = true;
                this.m_dept_id = value;
            }
        }

        public string Dept_Name
        {
            get { return this.m_dept_name; }
            set
            {
                this.m_isDirty = true;
                this.m_dept_name = value;
            }
        }

        public Int64 Deptt_Deptt_Id
        {
            get { return this.m_deptt_deptt_id; }
            set
            {
                this.m_isDirty = true;
                this.m_deptt_deptt_id = value;
            }
        }

        public Int64 Dept_Parent
        {
            get { return this.m_dept_parent; }
            set
            {
                this.m_isDirty = true;
                this.m_dept_parent = value;
            }
        }

        public Int64 Sec_Sec_Id
        {
            get { return this.m_sec_sec_id; }
            set
            {
                this.m_isDirty = true;
                this.m_sec_sec_id = value;
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
                this.m_dept_id = (Int64)dtrRow["Dept_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_dept_name = (string)dtrRow["Dept_name"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_deptt_deptt_id = (Int64)dtrRow["Deptt_Deptt_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_dept_parent = (Int64)dtrRow["Dept_Parent"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_sec_sec_id = (Int64)dtrRow["sec_sec_id"];
            }
            catch (Exception)
            {
            }

        }

        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Dept_ID"], DBNull.Value))))
                {
                    this.m_dept_id = (Int64)dtrRow["Dept_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Dept_name"], DBNull.Value))))
                {
                    this.m_dept_name = (string)dtrRow["Dept_name"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Deptt_Deptt_id"], DBNull.Value))))
                {
                    this.m_deptt_deptt_id = (Int64)dtrRow["Deptt_Deptt_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Dept_Parent"], DBNull.Value))))
                {
                    this.m_dept_parent = (Int64)dtrRow["Dept_Parent"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["sec_sec_id"], DBNull.Value))))
                {
                    this.m_sec_sec_id = (Int64)dtrRow["sec_sec_id"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Departments_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Dept_ID", SqlDbType.BigInt);
            cmd.Parameters["@Dept_ID"].Value = intId;

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
            string storedProcedure = "sp_Departments_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Dept_ID", SqlDbType.Int);
            cmd.Parameters["@Dept_ID"].Value = this.m_dept_id;

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

                cmd.Parameters.Add("@Dept_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@Dept_name", SqlDbType.NVarChar);
                if (this.m_dept_name != null)
                {
                    cmd.Parameters["@Dept_name"].Value = this.m_dept_name;
                }
                else
                {
                    cmd.Parameters["@Dept_name"].Value = "";
                }

                cmd.Parameters.Add("@Deptt_Deptt_id", SqlDbType.BigInt);
                if (this.m_deptt_deptt_id != 0)
                {
                    cmd.Parameters["@Deptt_Deptt_id"].Value = this.m_deptt_deptt_id;
                }
                else
                {
                    cmd.Parameters["@Deptt_Deptt_id"].Value = null;
                }

                cmd.Parameters.Add("@Dept_Parent", SqlDbType.BigInt);
                if (this.m_dept_parent != 0)
                {
                    cmd.Parameters["@Dept_Parent"].Value = this.m_dept_parent;
                }
                else
                {
                    cmd.Parameters["@Dept_Parent"].Value = null;
                }

                cmd.Parameters.Add("@sec_sec_id", SqlDbType.BigInt);
                if (this.m_sec_sec_id != 0)
                {
                    cmd.Parameters["@sec_sec_id"].Value = this.m_sec_sec_id;
                }
                else
                {
                    cmd.Parameters["@sec_sec_id"].Value = null;
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Departments_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Dept_ID"].Value = this.m_dept_id;
                    cmd.Parameters["@Dept_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Departments_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Dept_ID"].Value = this.m_dept_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@Dept_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@Dept_ID"].Direction = ParameterDirection.Input;
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
                    //    this.m_dept_id = (Int64)cmd.Parameters["@Dept_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Departments_GetAll";
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



        // Get all records which match the passed value of Deptt_ID
        public static DataTable GetByDeptt_ID(int Deptt_ID)
        {
            string storedProcedure = "sp_Departments_GetByDeptt_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Deptt_ID", SqlDbType.Int);
            cmd.Parameters["@Deptt_ID"].Value = Deptt_ID;

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



        // Get all records which match the passed value of Sec_id
        public static DataTable GetBySec_id(int Sec_id)
        {
            string storedProcedure = "sp_Departments_GetBySec_id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Sec_id", SqlDbType.Int);
            cmd.Parameters["@Sec_id"].Value = Sec_id;

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
        //     string storedProcedure = "sp_Departments_Custom";
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
