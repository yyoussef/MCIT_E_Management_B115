// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Poject_status Class"
    [Serializable()]
    public class Poject_status
    {
        #region "Instance Variables"
        protected Int64 m_pstat_id;
        protected System.DateTime m_pstat_date;
        protected Int64 m_stst_stat_id;
        protected Int64 m_proj_proj_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        #endregion


        #region "Constructors"

        public Poject_status()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Poject_status(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Poject_status(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Pstat_Id
        {
            get { return this.m_pstat_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pstat_id = value;
            }
        }

        public System.DateTime Pstat_Date
        {
            get { return this.m_pstat_date; }
            set
            {
                this.m_isDirty = true;
                this.m_pstat_date = value;
            }
        }

        public Int64 Stst_Stat_Id
        {
            get { return this.m_stst_stat_id; }
            set
            {
                this.m_isDirty = true;
                this.m_stst_stat_id = value;
            }
        }

        public Int64 Proj_Proj_Id
        {
            get { return this.m_proj_proj_id; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_proj_id = value;
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
                this.m_pstat_id = (Int64)dtrRow["Pstat_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pstat_date = (System.DateTime)dtrRow["PStat_Date"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_stst_stat_id = (Int64)dtrRow["stst_stat_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_proj_id = (Int64)dtrRow["proj_proj_id"];
            }
            catch (Exception)
            {
            }

        }

        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Pstat_ID"], DBNull.Value))))
                {
                    this.m_pstat_id = (Int64)dtrRow["Pstat_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["PStat_Date"], DBNull.Value))))
                {
                    this.m_pstat_date = (System.DateTime)dtrRow["PStat_Date"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["stst_stat_id"], DBNull.Value))))
                {
                    this.m_stst_stat_id = (Int64)dtrRow["stst_stat_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["proj_proj_id"], DBNull.Value))))
                {
                    this.m_proj_proj_id = (Int64)dtrRow["proj_proj_id"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            DataTable Table;
            string storedProcedure = "sp_Poject_status_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Pstat_ID", SqlDbType.BigInt);
            cmd.Parameters["@Pstat_ID"].Value = intId;

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
            Table = ds.Tables[0];
            return Table;
        }

        public void Delete()
        {
            string storedProcedure = "sp_Poject_status_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Pstat_ID", SqlDbType.Int);
            cmd.Parameters["@Pstat_ID"].Value = this.m_pstat_id;

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

                cmd.Parameters.Add("@Pstat_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@PStat_Date", SqlDbType.DateTime);
                if (this.m_pstat_date != null)
                {
                    cmd.Parameters["@PStat_Date"].Value = this.m_pstat_date;
                }
                else
                {
                    cmd.Parameters["@PStat_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@stst_stat_id", SqlDbType.BigInt);
                if (this.m_stst_stat_id != 0)
                {
                    cmd.Parameters["@stst_stat_id"].Value = this.m_stst_stat_id;
                }
                else
                {
                    cmd.Parameters["@stst_stat_id"].Value = null;
                }

                cmd.Parameters.Add("@proj_proj_id", SqlDbType.BigInt);
                if (this.m_proj_proj_id != 0)
                {
                    cmd.Parameters["@proj_proj_id"].Value = this.m_proj_proj_id;
                }
                else
                {
                    cmd.Parameters["@proj_proj_id"].Value = null;
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Poject_status_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Pstat_ID"].Value = this.m_pstat_id;
                    cmd.Parameters["@Pstat_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Poject_status_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Pstat_ID"].Value = this.m_pstat_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@Pstat_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@Pstat_ID"].Direction = ParameterDirection.Input;
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
                    //    this.m_pstat_id = (Int64)cmd.Parameters["@Pstat_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Poject_status_GetAll";
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



        // Get all records which match the passed value of Proj_id
        public static DataTable GetByProj_id(int Proj_id)
        {
            string storedProcedure = "sp_Poject_status_GetByProj_id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Proj_id", SqlDbType.Int);
            cmd.Parameters["@Proj_id"].Value = Proj_id;

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



        // Get all records which match the passed value of Stat_id
        public static DataTable GetByStat_id(int Stat_id)
        {
            string storedProcedure = "sp_Poject_status_GetByStat_id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Stat_id", SqlDbType.Int);
            cmd.Parameters["@Stat_id"].Value = Stat_id;

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
        //     string storedProcedure = "sp_Poject_status_Custom";
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
