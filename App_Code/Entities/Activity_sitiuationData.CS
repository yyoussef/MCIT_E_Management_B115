// This file was automatically created by LayerGen 0.99e
// Created: 12-May-10 3:50 PM

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Activity_sitiuation Class"
	[Serializable()]
	public class Activity_sitiuation
	{
#region "Instance Variables"
        protected Int64 m_actv_sit_id;
        protected string m_actv_sit_desc;
        protected Int64 m_project_activity_fk;
        protected Int64 m_actv_sit_num;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        protected BLL.Project_Activities myProject_activities;

#endregion


#region "Constructors"

	public Activity_sitiuation()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Activity_sitiuation(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Activity_sitiuation(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Actv_Sit_Id {
            get { return this.m_actv_sit_id; }
            set {
                this.m_isDirty=true;
                this.m_actv_sit_id = value;
            }
        }

        public string Actv_Sit_Desc {
            get { return this.m_actv_sit_desc; }
            set {
                this.m_isDirty=true;
                this.m_actv_sit_desc = value;
            }
        }

        public Int64 Project_Activity_Fk {
            get { return this.m_project_activity_fk; }
            set {
                this.m_isDirty=true;
                this.m_project_activity_fk = value;
            }
        }

        public Int64 Actv_Sit_Num {
            get { return this.m_actv_sit_num; }
            set {
                this.m_isDirty=true;
                this.m_actv_sit_num = value;
            }
        }

        public bool IsIdentityTable {
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
            try {
                this.m_actv_sit_id = (Int64)dtrRow["actv_sit_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_actv_sit_desc = (string)dtrRow["actv_sit_desc"];
            }
            catch (Exception ) {
            }

            try {
                this.m_project_activity_fk = (Int64)dtrRow["project_activity_FK"];
            }
            catch (Exception ) {
            }

            try {
                this.m_actv_sit_num = (Int64)dtrRow["actv_sit_num"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["actv_sit_id"], DBNull.Value)))) {
                    this.m_actv_sit_id = (Int64)dtrRow["actv_sit_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["actv_sit_desc"], DBNull.Value)))) {
                    this.m_actv_sit_desc = (string)dtrRow["actv_sit_desc"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["project_activity_FK"], DBNull.Value)))) {
                    this.m_project_activity_fk = (Int64)dtrRow["project_activity_FK"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["actv_sit_num"], DBNull.Value)))) {
                    this.m_actv_sit_num = (Int64)dtrRow["actv_sit_num"];
                }
            }
            catch (Exception ) {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Activity_sitiuation_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@actv_sit_id", SqlDbType.BigInt);
            cmd.Parameters["@actv_sit_id"].Value = intId;

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
            return ds.Tables[0];
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_Activity_sitiuation_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@actv_sit_id", SqlDbType.Int);
            cmd.Parameters["@actv_sit_id"].Value = this.m_actv_sit_id;

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

            if ((this.myProject_activities != null)) {
                myProject_activities.Save();
            }

            if ((m_isDirty)) {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@actv_sit_id", SqlDbType.BigInt);
                cmd.Parameters.Add("@actv_sit_desc", SqlDbType.Text);
                if (this.m_actv_sit_desc !=null) {
                    cmd.Parameters["@actv_sit_desc"].Value = this.m_actv_sit_desc;
                } else {
                    cmd.Parameters["@actv_sit_desc"].Value = null;
                }

                cmd.Parameters.Add("@project_activity_FK", SqlDbType.BigInt);
                if (this.m_project_activity_fk !=0) {
                    cmd.Parameters["@project_activity_FK"].Value = this.m_project_activity_fk;
                } else {
                    cmd.Parameters["@project_activity_FK"].Value = null;
                }

                cmd.Parameters.Add("@actv_sit_num", SqlDbType.BigInt);
                if (this.m_actv_sit_num !=0) {
                    cmd.Parameters["@actv_sit_num"].Value = this.m_actv_sit_num;
                } else {
                    cmd.Parameters["@actv_sit_num"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Activity_sitiuation_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@actv_sit_id"].Value = this.m_actv_sit_id;
                    cmd.Parameters["@actv_sit_id"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Activity_sitiuation_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@actv_sit_id"].Value = this.m_actv_sit_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@actv_sit_id"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@actv_sit_id"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                    //if (IsIdentityTable) {
                    //    this.m_actv_sit_id = (Int64)cmd.Parameters["@actv_sit_id"].Value;
                   // }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Activity_sitiuation_GetAll";
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
        


// Get all records which match the passed value of PActv_ID
        public static DataTable GetByPActv_ID(int PActv_ID ) {
            string storedProcedure = "sp_Activity_sitiuation_GetByPActv_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PActv_ID", SqlDbType.Int);
            cmd.Parameters["@PActv_ID"].Value = PActv_ID;
        
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
        //     string storedProcedure = "sp_Activity_sitiuation_Custom";
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
