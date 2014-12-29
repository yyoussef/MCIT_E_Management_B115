// This file was automatically created by LayerGen 0.99e
// Created: 30/05/2010 01:21 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Project_Organization Class"
	[Serializable()]
	public class Project_Organization
	{
#region "Instance Variables"
        protected Int64 m_porg_id;
        protected Int64 m_org_org_id;
        protected Int64 m_proj_proj_id;
        protected string m_contact_person;
        protected string m_phone;
        protected string m_email;
        protected string m_mobile;
        protected string m_notes;
        protected string m_role;
        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

#endregion


#region "Constructors"

	public Project_Organization()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Project_Organization(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Project_Organization(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Porg_Id {
            get { return this.m_porg_id; }
            set {
                this.m_isDirty=true;
                this.m_porg_id = value;
            }
        }

        public Int64 Org_Org_Id {
            get { return this.m_org_org_id; }
            set {
                this.m_isDirty=true;
                this.m_org_org_id = value;
            }
        }

        public Int64 Proj_Proj_Id {
            get { return this.m_proj_proj_id; }
            set {
                this.m_isDirty=true;
                this.m_proj_proj_id = value;
            }
        }

        public string Contact_Person {
            get { return this.m_contact_person; }
            set {
                this.m_isDirty=true;
                this.m_contact_person = value;
            }
        }

        public string Phone {
            get { return this.m_phone; }
            set {
                this.m_isDirty=true;
                this.m_phone = value;
            }
        }

        public string Email {
            get { return this.m_email; }
            set {
                this.m_isDirty=true;
                this.m_email = value;
            }
        }

        public string Mobile {
            get { return this.m_mobile; }
            set {
                this.m_isDirty=true;
                this.m_mobile = value;
            }
        }

        public string Notes {
            get { return this.m_notes; }
            set {
                this.m_isDirty=true;
                this.m_notes = value;
            }
        }

        public string role
        {
            get { return this.m_role; }
            set
            {
                this.m_isDirty = true;
                this.m_role = value;
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
                this.m_porg_id = (Int64)dtrRow["POrg_ID"];
            }
            catch (Exception ) {
            }

            try {
                this.m_org_org_id = (Int64)dtrRow["org_org_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_proj_proj_id = (Int64)dtrRow["proj_proj_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_contact_person = (string)dtrRow["Contact_Person"];
            }
            catch (Exception ) {
            }

            try {
                this.m_phone = (string)dtrRow["Phone"];
            }
            catch (Exception ) {
            }

            try {
                this.m_email = (string)dtrRow["Email"];
            }
            catch (Exception ) {
            }

            try {
                this.m_mobile = (string)dtrRow["mobile"];
            }
            catch (Exception ) {
            }

            try {
                this.m_notes = (string)dtrRow["Notes"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["POrg_ID"], DBNull.Value)))) {
                    this.m_porg_id = (Int64)dtrRow["POrg_ID"];
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
                if (((!object.ReferenceEquals(dtrRow["proj_proj_id"], DBNull.Value)))) {
                    this.m_proj_proj_id = (Int64)dtrRow["proj_proj_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Contact_Person"], DBNull.Value)))) {
                    this.m_contact_person = (string)dtrRow["Contact_Person"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Phone"], DBNull.Value)))) {
                    this.m_phone = (string)dtrRow["Phone"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Email"], DBNull.Value)))) {
                    this.m_email = (string)dtrRow["Email"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["mobile"], DBNull.Value)))) {
                    this.m_mobile = (string)dtrRow["mobile"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Notes"], DBNull.Value)))) {
                    this.m_notes = (string)dtrRow["Notes"];
                }
            }
            catch (Exception ) {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["role"], DBNull.Value))))
                {
                    this.m_role = (string)dtrRow["role"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Project_Organization_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@POrg_ID", SqlDbType.BigInt);
            cmd.Parameters["@POrg_ID"].Value = intId;

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
            string storedProcedure = "sp_Project_Organization_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@POrg_ID", SqlDbType.Int);
            cmd.Parameters["@POrg_ID"].Value = this.m_porg_id;

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

                cmd.Parameters.Add("@POrg_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@org_org_id", SqlDbType.BigInt);
                if (this.m_org_org_id !=0) {
                    cmd.Parameters["@org_org_id"].Value = this.m_org_org_id;
                } else {
                    cmd.Parameters["@org_org_id"].Value = null;
                }

                cmd.Parameters.Add("@proj_proj_id", SqlDbType.BigInt);
                if (this.m_proj_proj_id !=0) {
                    cmd.Parameters["@proj_proj_id"].Value = this.m_proj_proj_id;
                } else {
                    cmd.Parameters["@proj_proj_id"].Value = null;
                }

                cmd.Parameters.Add("@Contact_Person", SqlDbType.VarChar);
                if (this.m_contact_person !=null) {
                    cmd.Parameters["@Contact_Person"].Value = this.m_contact_person;
                } else {
                    cmd.Parameters["@Contact_Person"].Value = "";
                }

                cmd.Parameters.Add("@Phone", SqlDbType.VarChar);
                if (this.m_phone !=null) {
                    cmd.Parameters["@Phone"].Value = this.m_phone;
                } else {
                    cmd.Parameters["@Phone"].Value = "";
                }

                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                if (this.m_email !=null) {
                    cmd.Parameters["@Email"].Value = this.m_email;
                } else {
                    cmd.Parameters["@Email"].Value = "";
                }

                cmd.Parameters.Add("@mobile", SqlDbType.VarChar);
                if (this.m_mobile !=null) {
                    cmd.Parameters["@mobile"].Value = this.m_mobile;
                } else {
                    cmd.Parameters["@mobile"].Value = "";
                }

                cmd.Parameters.Add("@Notes", SqlDbType.VarChar);
                if (this.m_notes !=null) {
                    cmd.Parameters["@Notes"].Value = this.m_notes;
                } else {
                    cmd.Parameters["@Notes"].Value = "";
                }

                cmd.Parameters.Add("@role", SqlDbType.VarChar);
                if (this.m_role != null)
                {
                    cmd.Parameters["@role"].Value = this.m_role;
                }
                else
                {
                    cmd.Parameters["@role"].Value = "";
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Project_Organization_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@POrg_ID"].Value = this.m_porg_id;
                    cmd.Parameters["@POrg_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Organization_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@POrg_ID"].Value = this.m_porg_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@POrg_ID"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@POrg_ID"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                 //   if (IsIdentityTable) {
                 //       this.m_porg_id = (Int64)cmd.Parameters["@POrg_ID"].Value;
                 //   }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Organization_GetAll";
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
            string storedProcedure = "sp_Project_Organization_GetByOrg_ID";
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
        


// Get all records which match the passed value of Proj_id
        public static DataTable GetByProj_id(int Proj_id ) {
            string storedProcedure = "sp_Project_Organization_GetByProj_id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Proj_id", SqlDbType.Int);
            cmd.Parameters["@Proj_id"].Value = Proj_id;
        
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
        //     string storedProcedure = "sp_Project_Organization_Custom";
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
