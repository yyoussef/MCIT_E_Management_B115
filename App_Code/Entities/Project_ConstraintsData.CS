// This file was automatically created by LayerGen 0.99e
// Created: 27/04/2010 01:51 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Project_Constraints Class"
    [Serializable()]
    public class Project_Constraints
    {
        #region "Instance Variables"
        protected Int64 m_pcons_id;
        protected Int64 m_pactv_pactv_id;
        protected string m_pcons_desc;
        protected string m_pcons_sugg_solutions;
        protected Int32 m_pcons_is_critical;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;
                
        #endregion


        #region "Constructors"

        public Project_Constraints()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Project_Constraints(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Project_Constraints(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Pcons_Id
        {
            get { return this.m_pcons_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pcons_id = value;
            }
        }

        public Int64 Pactv_Pactv_Id
        {
            get { return this.m_pactv_pactv_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pactv_pactv_id = value;
            }
        }

        public string Pcons_Desc
        {
            get { return this.m_pcons_desc; }
            set
            {
                this.m_isDirty = true;
                this.m_pcons_desc = value;
            }
        }

        public string Pcons_Sugg_Solutions
        {
            get { return this.m_pcons_sugg_solutions; }
            set
            {
                this.m_isDirty = true;
                this.m_pcons_sugg_solutions = value;
            }
        }

        public Int32 Pcons_Is_Critical
        {
            get { return this.m_pcons_is_critical; }
            set
            {
                this.m_isDirty = true;
                this.m_pcons_is_critical = value;
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
                this.m_pcons_id = (Int64)dtrRow["PCONS_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pactv_pactv_id = (Int64)dtrRow["PActv_PActv_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pcons_desc = (string)dtrRow["PCONS_DESC"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pcons_sugg_solutions = (string)dtrRow["PCONS_Sugg_Solutions"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pcons_is_critical = (Int32)dtrRow["PCONS_IS_CRITICAL"];
            }
            catch (Exception)
            {
            }

        }

        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PCONS_ID"], DBNull.Value))))
                {
                    this.m_pcons_id = (Int64)dtrRow["PCONS_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PActv_PActv_ID"], DBNull.Value))))
                {
                    this.m_pactv_pactv_id = (Int64)dtrRow["PActv_PActv_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PCONS_DESC"], DBNull.Value))))
                {
                    this.m_pcons_desc = (string)dtrRow["PCONS_DESC"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PCONS_Sugg_Solutions"], DBNull.Value))))
                {
                    this.m_pcons_sugg_solutions = (string)dtrRow["PCONS_Sugg_Solutions"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PCONS_IS_CRITICAL"], DBNull.Value))))
                {
                    this.m_pcons_is_critical = (Int32)dtrRow["PCONS_IS_CRITICAL"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Project_Constraints_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PCONS_ID", SqlDbType.BigInt);
            cmd.Parameters["@PCONS_ID"].Value = intId;

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
            string storedProcedure = "sp_Project_Constraints_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PCONS_ID", SqlDbType.Int);
            cmd.Parameters["@PCONS_ID"].Value = this.m_pcons_id;

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

                cmd.Parameters.Add("@PCONS_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@PActv_PActv_ID", SqlDbType.BigInt);
                if (this.m_pactv_pactv_id != 0)
                {
                    cmd.Parameters["@PActv_PActv_ID"].Value = this.m_pactv_pactv_id;
                }
                else
                {
                    cmd.Parameters["@PActv_PActv_ID"].Value = null;
                }

                cmd.Parameters.Add("@PCONS_DESC", SqlDbType.NVarChar);
                if (this.m_pcons_desc != null)
                {
                    cmd.Parameters["@PCONS_DESC"].Value = this.m_pcons_desc;
                }
                else
                {
                    cmd.Parameters["@PCONS_DESC"].Value = "";
                }

                cmd.Parameters.Add("@PCONS_Sugg_Solutions", SqlDbType.NVarChar);
                if (this.m_pcons_sugg_solutions != null)
                {
                    cmd.Parameters["@PCONS_Sugg_Solutions"].Value = this.m_pcons_sugg_solutions;
                }
                else
                {
                    cmd.Parameters["@PCONS_Sugg_Solutions"].Value = "";
                }

                cmd.Parameters.Add("@PCONS_IS_CRITICAL", SqlDbType.Int);
                if (this.m_pcons_is_critical != -1)
                {
                    cmd.Parameters["@PCONS_IS_CRITICAL"].Value = this.m_pcons_is_critical;
                }
                else
                {
                    cmd.Parameters["@PCONS_IS_CRITICAL"].Value = null;
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Project_Constraints_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PCONS_ID"].Value = this.m_pcons_id;
                    cmd.Parameters["@PCONS_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Constraints_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PCONS_ID"].Value = this.m_pcons_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@PCONS_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@PCONS_ID"].Direction = ParameterDirection.Input;
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
                    //    this.m_pcons_id = (Int64)cmd.Parameters["@PCONS_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Constraints_GetAll";
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



        // Get all records which match the passed value of PActv_ID
        public static DataTable GetByPActv_ID(int PActv_ID)
        {
            string storedProcedure = "sp_Project_Constraints_GetByPActv_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PActv_ID", SqlDbType.Int);
            cmd.Parameters["@PActv_ID"].Value = PActv_ID;

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
        //     string storedProcedure = "sp_Project_Constraints_Custom";
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
