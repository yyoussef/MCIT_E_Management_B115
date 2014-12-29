// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Project_Activities_Exe_Organization Class"
	[Serializable()]
	public class Project_Activities_Exe_Organization
	{
#region "Instance Variables"
        protected Int64 m_paorg_id;
        protected Int64 m_org_org_id;
        protected Int64 m_pactv_pactv_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        protected BLL.Organization myOrganization;

#endregion


#region "Constructors"

	public Project_Activities_Exe_Organization()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Project_Activities_Exe_Organization(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Project_Activities_Exe_Organization(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Paorg_Id {
            get { return this.m_paorg_id; }
            set {
                this.m_isDirty=true;
                this.m_paorg_id = value;
            }
        }

        public Int64 Org_Org_Id {
            get { return this.m_org_org_id; }
            set {
                this.m_isDirty=true;
                this.m_org_org_id = value;
            }
        }

        public Int64 Pactv_Pactv_Id {
            get { return this.m_pactv_pactv_id; }
            set {
                this.m_isDirty=true;
                this.m_pactv_pactv_id = value;
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
                this.m_paorg_id = (Int64)dtrRow["PAOrg_ID"];
            }
            catch (Exception ) {
            }

            try {
                this.m_org_org_id = (Int64)dtrRow["org_org_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_pactv_id = (Int64)dtrRow["PActv_PActv_id"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["PAOrg_ID"], DBNull.Value)))) {
                    this.m_paorg_id = (Int64)dtrRow["PAOrg_ID"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["org_org_id"], DBNull.Value)))) {
                    this.m_org_org_id = (Int64)dtrRow["org_org_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_PActv_id"], DBNull.Value)))) {
                    this.m_pactv_pactv_id = (Int64)dtrRow["PActv_PActv_id"];
                }
            }
            catch (Exception ) {
            }
        }

        private void Get(Int64 intId)
        {
            string storedProcedure = "sp_Project_Activities_Exe_Organization_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PAOrg_ID", SqlDbType.BigInt);
            cmd.Parameters["@PAOrg_ID"].Value = intId;

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
            string storedProcedure = "sp_Project_Activities_Exe_Organization_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PAOrg_ID", SqlDbType.Int);
            cmd.Parameters["@PAOrg_ID"].Value = this.m_paorg_id;

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

            if ((this.myOrganization != null)) {
                myOrganization.Save();
            }

            if ((m_isDirty)) {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PAOrg_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@org_org_id", SqlDbType.BigInt);
                if (this.m_org_org_id !=0) {
                    cmd.Parameters["@org_org_id"].Value = this.m_org_org_id;
                } else {
                    cmd.Parameters["@org_org_id"].Value = null;
                }

                cmd.Parameters.Add("@PActv_PActv_id", SqlDbType.BigInt);
                if (this.m_pactv_pactv_id !=0) {
                    cmd.Parameters["@PActv_PActv_id"].Value = this.m_pactv_pactv_id;
                } else {
                    cmd.Parameters["@PActv_PActv_id"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Project_Activities_Exe_Organization_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PAOrg_ID"].Value = this.m_paorg_id;
                    cmd.Parameters["@PAOrg_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Activities_Exe_Organization_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PAOrg_ID"].Value = this.m_paorg_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@PAOrg_ID"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@PAOrg_ID"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                    if (IsIdentityTable) {
                        this.m_paorg_id = (Int64)cmd.Parameters["@PAOrg_ID"].Value;
                    }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Activities_Exe_Organization_GetAll";
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
        


// Get all records which match the passed value of Org_ID
        public static DataTable GetByOrg_ID(int Org_ID ) {
            string storedProcedure = "sp_Project_Activities_Exe_Organization_GetByOrg_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Org_ID", SqlDbType.Int);
            cmd.Parameters["@Org_ID"].Value = Org_ID;
        
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
        //     string storedProcedure = "sp_Project_Activities_Exe_Organization_Custom";
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
