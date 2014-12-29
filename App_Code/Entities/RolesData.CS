// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Roles Class"
    [Serializable()]
    public class Roles
    {
        #region "Instance Variables"
        protected Int64 m_rol_id;
        protected string m_rol_desc;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        #endregion


        #region "Constructors"

        public Roles()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Roles(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Roles(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Rol_Id
        {
            get { return this.m_rol_id; }
            set
            {
                this.m_isDirty = true;
                this.m_rol_id = value;
            }
        }

        public string Rol_Desc
        {
            get { return this.m_rol_desc; }
            set
            {
                this.m_isDirty = true;
                this.m_rol_desc = value;
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
                this.m_rol_id = (Int64)dtrRow["Rol_ID"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_rol_desc = (string)dtrRow["Rol_Desc"];
            }
            catch (Exception)
            {
            }

        }

        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Rol_ID"], DBNull.Value))))
                {
                    this.m_rol_id = (Int64)dtrRow["Rol_ID"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Rol_Desc"], DBNull.Value))))
                {
                    this.m_rol_desc = (string)dtrRow["Rol_Desc"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Roles_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Rol_ID", SqlDbType.BigInt);
            cmd.Parameters["@Rol_ID"].Value = intId;

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
            string storedProcedure = "sp_Roles_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Rol_ID", SqlDbType.Int);
            cmd.Parameters["@Rol_ID"].Value = this.m_rol_id;

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

                cmd.Parameters.Add("@Rol_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@Rol_Desc", SqlDbType.NVarChar);
                if (this.m_rol_desc != null)
                {
                    cmd.Parameters["@Rol_Desc"].Value = this.m_rol_desc;
                }
                else
                {
                    cmd.Parameters["@Rol_Desc"].Value = "";
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Roles_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Rol_ID"].Value = this.m_rol_id;
                    cmd.Parameters["@Rol_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Roles_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Rol_ID"].Value = this.m_rol_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@Rol_ID"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@Rol_ID"].Direction = ParameterDirection.Input;
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
                    //    this.m_rol_id = (Int64)cmd.Parameters["@Rol_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Roles_GetAll";
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
        //     string storedProcedure = "sp_Roles_Custom";
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
