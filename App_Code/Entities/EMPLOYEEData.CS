// This file was automatically created by LayerGen 0.99e
// Created: 01-Apr-10 10:21 AM

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "EMPLOYEE Class"
    [Serializable()]
    public class EMPLOYEE
    {
        #region "Instance Variables"
        protected Int64 m_pmp_id;
        protected Int64 m_dept_dept_id;
        protected Int64 m_job_job_id;
        protected string m_pmp_name;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;



        #endregion


        #region "Constructors"

        public EMPLOYEE()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public EMPLOYEE(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public EMPLOYEE(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Pmp_Id
        {
            get { return this.m_pmp_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pmp_id = value;
            }
        }

        public Int64 Dept_Dept_Id
        {
            get { return this.m_dept_dept_id; }
            set
            {
                this.m_isDirty = true;
                this.m_dept_dept_id = value;
            }
        }

        public Int64 Job_Job_Id
        {
            get { return this.m_job_job_id; }
            set
            {
                this.m_isDirty = true;
                this.m_job_job_id = value;
            }
        }

        public string Pmp_Name
        {
            get { return this.m_pmp_name; }
            set
            {
                this.m_isDirty = true;
                this.m_pmp_name = value;
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
                this.m_pmp_id = (Int64)dtrRow["PMP_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_dept_dept_id = (Int64)dtrRow["Dept_Dept_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_job_job_id = (Int64)dtrRow["job_job_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pmp_name = (string)dtrRow["pmp_name"];
            }
            catch (Exception)
            {
            }

        }
        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PMP_ID"], DBNull.Value))))
                {
                    this.m_pmp_id = (Int64)dtrRow["PMP_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Dept_Dept_id"], DBNull.Value))))
                {
                    this.m_dept_dept_id = (Int64)dtrRow["Dept_Dept_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["job_job_id"], DBNull.Value))))
                {
                    this.m_job_job_id = (Int64)dtrRow["job_job_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["pmp_name"], DBNull.Value))))
                {
                    this.m_pmp_name = (string)dtrRow["pmp_name"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            DataTable Table;
            string storedProcedure = "sp_EMPLOYEE_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PMP_ID", SqlDbType.BigInt);
            cmd.Parameters["@PMP_ID"].Value = intId;

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
            Table = ds.Tables[0];
            return Table;
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_EMPLOYEE_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PMP_ID", SqlDbType.Int);
            cmd.Parameters["@PMP_ID"].Value = this.m_pmp_id;

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

                cmd.Parameters.Add("@PMP_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@Dept_Dept_id", SqlDbType.BigInt);
                if (this.m_dept_dept_id != 0)
                {
                    cmd.Parameters["@Dept_Dept_id"].Value = this.m_dept_dept_id;
                }
                else
                {
                    cmd.Parameters["@Dept_Dept_id"].Value = null;
                }

                cmd.Parameters.Add("@job_job_id", SqlDbType.BigInt);
                if (this.m_job_job_id != 0)
                {
                    cmd.Parameters["@job_job_id"].Value = this.m_job_job_id;
                }
                else
                {
                    cmd.Parameters["@job_job_id"].Value = null;
                }

                cmd.Parameters.Add("@pmp_name", SqlDbType.NVarChar);
                if (this.m_pmp_name != null)
                {
                    cmd.Parameters["@pmp_name"].Value = this.m_pmp_name;
                }
                else
                {
                    cmd.Parameters["@pmp_name"].Value = "";
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_EMPLOYEE_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PMP_ID"].Value = this.m_pmp_id;
                    cmd.Parameters["@PMP_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_EMPLOYEE_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PMP_ID"].Value = this.m_pmp_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@PMP_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@PMP_ID"].Direction = ParameterDirection.Input;
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
                    //  if (IsIdentityTable) {
                    //       this.m_pmp_id = (Int64)cmd.Parameters["@PMP_ID"].Value;
                    //  }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_EMPLOYEE_GetAll";
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



        // Get all records which match the passed value of Dept_ID
        public static DataTable GetByDept_ID(int Dept_ID)
        {
            string storedProcedure = "sp_EMPLOYEE_GetByDept_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Dept_ID", SqlDbType.Int);
            cmd.Parameters["@Dept_ID"].Value = Dept_ID;

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



        // Get all records which match the passed value of JOB_ID
        public static DataTable GetByJOB_ID(int JOB_ID)
        {
            string storedProcedure = "sp_EMPLOYEE_GetByJOB_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@JOB_ID", SqlDbType.Int);
            cmd.Parameters["@JOB_ID"].Value = JOB_ID;

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
        //     string storedProcedure = "sp_EMPLOYEE_Custom";
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
