// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Project_Distrebition Class"
    [Serializable()]
    public class Project_Distrebition
    {
        #region "Instance Variables"
        protected Int64 m_pdist_id;
        protected Int64 m_dist_dist_id;
        protected Int64 m_proj_proj_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;



        #endregion


        #region "Constructors"

        public Project_Distrebition()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Project_Distrebition(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Project_Distrebition(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Pdist_Id
        {
            get { return this.m_pdist_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pdist_id = value;
            }
        }

        public Int64 Dist_Dist_Id
        {
            get { return this.m_dist_dist_id; }
            set
            {
                this.m_isDirty = true;
                this.m_dist_dist_id = value;
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
                this.m_pdist_id = (Int64)dtrRow["PDist_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_dist_dist_id = (Int64)dtrRow["dist_dist_id"];
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
                if (((!object.ReferenceEquals(dtrRow["PDist_ID"], DBNull.Value))))
                {
                    this.m_pdist_id = (Int64)dtrRow["PDist_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["dist_dist_id"], DBNull.Value))))
                {
                    this.m_dist_dist_id = (Int64)dtrRow["dist_dist_id"];
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
            DataTable _dt;
            string storedProcedure = "sp_Project_Distrebition_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PDist_ID", SqlDbType.BigInt);
            cmd.Parameters["@PDist_ID"].Value = intId;

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
            _dt = ds.Tables[0];
            return _dt;
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_Project_Distrebition_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PDist_ID", SqlDbType.Int);
            cmd.Parameters["@PDist_ID"].Value = this.m_pdist_id;

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

                cmd.Parameters.Add("@PDist_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@dist_dist_id", SqlDbType.BigInt);
                if (this.m_dist_dist_id != 0)
                {
                    cmd.Parameters["@dist_dist_id"].Value = this.m_dist_dist_id;
                }
                else
                {
                    cmd.Parameters["@dist_dist_id"].Value = null;
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
                    storedProcedure = "sp_Project_Distrebition_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PDist_ID"].Value = this.m_pdist_id;
                    cmd.Parameters["@PDist_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Distrebition_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@PDist_ID"].Value = this.m_pdist_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@PDist_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@PDist_ID"].Direction = ParameterDirection.Input;
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
                    //    this.m_pdist_id = (Int64)cmd.Parameters["@PDist_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Distrebition_GetAll";
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



        // Get all records which match the passed value of Dist_ID
        public static DataTable GetByDist_ID(int Dist_ID)
        {
            string storedProcedure = "sp_Project_Distrebition_GetByDist_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Dist_ID", SqlDbType.Int);
            cmd.Parameters["@Dist_ID"].Value = Dist_ID;

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



        // Get all records which match the passed value of Proj_id
        public static DataTable GetByProj_id(int Proj_id)
        {
            string storedProcedure = "sp_Project_Distrebition_GetByProj_id";
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
        //     string storedProcedure = "sp_Project_Distrebition_Custom";
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
