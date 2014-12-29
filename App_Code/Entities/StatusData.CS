// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Status Class"
	[Serializable()]
	public class Status
	{
#region "Instance Variables"
        protected Int64 m_stat_id;
        protected string m_stat_desc;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

#endregion


#region "Constructors"

	public Status()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Status(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Status(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Stat_Id {
            get { return this.m_stat_id; }
            set {
                this.m_isDirty=true;
                this.m_stat_id = value;
            }
        }

        public string Stat_Desc {
            get { return this.m_stat_desc; }
            set {
                this.m_isDirty=true;
                this.m_stat_desc = value;
            }
        }

        public bool IsIdentityTable {
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
            try {
                this.m_stat_id = (Int64)dtrRow["Stat_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_stat_desc = (string)dtrRow["Stat_Desc"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["Stat_id"], DBNull.Value)))) {
                    this.m_stat_id = (Int64)dtrRow["Stat_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Stat_Desc"], DBNull.Value)))) {
                    this.m_stat_desc = (string)dtrRow["Stat_Desc"];
                }
            }
            catch (Exception ) {
            }
        }

        private void Get(Int64 intId)
        {
            string storedProcedure = "sp_Status_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Stat_id", SqlDbType.BigInt);
            cmd.Parameters["@Stat_id"].Value = intId;

            try {
                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0) {
                    if (ds.Tables[0].Rows.Count > 0) {
                        Fill(ds.Tables[0].Rows[0]);
                    }
                }
            }
            catch (Exception e) {
                throw e;
            }
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_Status_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Stat_id", SqlDbType.Int);
            cmd.Parameters["@Stat_id"].Value = this.m_stat_id;

            try {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
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

            if ((m_isDirty)) {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Stat_id", SqlDbType.BigInt);
                cmd.Parameters.Add("@Stat_Desc", SqlDbType.NVarChar);
                if (this.m_stat_desc !=null) {
                    cmd.Parameters["@Stat_Desc"].Value = this.m_stat_desc;
                } else {
                    cmd.Parameters["@Stat_Desc"].Value = "";
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Status_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@Stat_id"].Value = this.m_stat_id;
                    cmd.Parameters["@Stat_id"].Direction = ParameterDirection.Input;
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e ) {
                        throw e;
                    }
                    conn.Close();
                }
                else {
                    storedProcedure = "sp_Status_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@Stat_id"].Value = this.m_stat_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@Stat_id"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@Stat_id"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                    if (IsIdentityTable) {
                        this.m_stat_id = (Int64)cmd.Parameters["@Stat_id"].Value;
                    }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Status_GetAll";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
        
            try {
                DataSet ds;
                System.Data.SqlClient.SqlDataAdapter da;
                DataTable Table = null;
        
                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;
        
                ds = new DataSet();
                da.Fill(ds);
        
                if (ds.Tables.Count > 0) {
                   if (ds.Tables[0].Rows.Count > 0) {
                        Table = ds.Tables[0]; 
                   }
                }
                conn.Close();
                return Table;
             }
             catch (Exception ) {
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
        //     string storedProcedure = "sp_Status_Custom";
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
