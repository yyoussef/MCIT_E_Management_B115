// This file was automatically created by LayerGen 0.99e
// Created: 03/06/2010 08:16 ص

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Need_Recieve Class"
	[Serializable()]
	public class Need_Recieve
	{
#region "Instance Variables"
        protected Int64 m_need_recieve_id;
        protected Int64 m_recieved_amount;
        protected System.DateTime m_recieved_amount_date;
        protected Int64 m_remain_amount;
        protected string m_recieve_organization;
        protected string m_recieve_organization_person;
        protected Int32 m_pned_pned_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        protected BLL.Project_Needs myProject_needs;

#endregion


#region "Constructors"

	public Need_Recieve()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Need_Recieve(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Need_Recieve(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Need_Recieve_Id {
            get { return this.m_need_recieve_id; }
            set {
                this.m_isDirty=true;
                this.m_need_recieve_id = value;
            }
        }

        public Int64 Recieved_Amount {
            get { return this.m_recieved_amount; }
            set {
                this.m_isDirty=true;
                this.m_recieved_amount = value;
            }
        }

        public System.DateTime Recieved_Amount_Date {
            get { return this.m_recieved_amount_date; }
            set {
                this.m_isDirty=true;
                this.m_recieved_amount_date = value;
            }
        }

        public Int64 Remain_Amount {
            get { return this.m_remain_amount; }
            set {
                this.m_isDirty=true;
                this.m_remain_amount = value;
            }
        }

        public string Recieve_Organization {
            get { return this.m_recieve_organization; }
            set {
                this.m_isDirty=true;
                this.m_recieve_organization = value;
            }
        }

        public string Recieve_Organization_Person {
            get { return this.m_recieve_organization_person; }
            set {
                this.m_isDirty=true;
                this.m_recieve_organization_person = value;
            }
        }

        public Int32 Pned_Pned_Id {
            get { return this.m_pned_pned_id; }
            set {
                this.m_isDirty=true;
                this.m_pned_pned_id = value;
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
                this.m_need_recieve_id = (Int64)dtrRow["need_recieve_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_recieved_amount = (Int64)dtrRow["recieved_amount"];
            }
            catch (Exception ) {
            }

            try {
                this.m_recieved_amount_date = (System.DateTime)dtrRow["recieved_amount_date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_remain_amount = (Int64)dtrRow["remain_amount"];
            }
            catch (Exception ) {
            }

            try {
                this.m_recieve_organization = (string)dtrRow["recieve_organization"];
            }
            catch (Exception ) {
            }

            try {
                this.m_recieve_organization_person = (string)dtrRow["recieve_organization_person"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pned_pned_id = (Int32)dtrRow["pned_pned_id"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["need_recieve_id"], DBNull.Value)))) {
                    this.m_need_recieve_id = (Int64)dtrRow["need_recieve_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["recieved_amount"], DBNull.Value)))) {
                    this.m_recieved_amount = (Int64)dtrRow["recieved_amount"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["recieved_amount_date"], DBNull.Value)))) {
                    this.m_recieved_amount_date = (System.DateTime)dtrRow["recieved_amount_date"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["remain_amount"], DBNull.Value)))) {
                    this.m_remain_amount = (Int64)dtrRow["remain_amount"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["recieve_organization"], DBNull.Value)))) {
                    this.m_recieve_organization = (string)dtrRow["recieve_organization"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["recieve_organization_person"], DBNull.Value)))) {
                    this.m_recieve_organization_person = (string)dtrRow["recieve_organization_person"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["pned_pned_id"], DBNull.Value)))) {
                    this.m_pned_pned_id = (Int32)dtrRow["pned_pned_id"];
                }
            }
            catch (Exception ) {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Need_Recieve_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@need_recieve_id", SqlDbType.BigInt);
            cmd.Parameters["@need_recieve_id"].Value = intId;

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
            string storedProcedure = "sp_Need_Recieve_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@need_recieve_id", SqlDbType.Int);
            cmd.Parameters["@need_recieve_id"].Value = this.m_need_recieve_id;

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

            if ((this.myProject_needs != null)) {
                myProject_needs.Save();
            }

            if ((m_isDirty)) {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@need_recieve_id", SqlDbType.BigInt);
                cmd.Parameters.Add("@recieved_amount", SqlDbType.BigInt);
                if (this.m_recieved_amount !=0) {
                    cmd.Parameters["@recieved_amount"].Value = this.m_recieved_amount;
                } else {
                    cmd.Parameters["@recieved_amount"].Value = null;
                }

                cmd.Parameters.Add("@recieved_amount_date", SqlDbType.DateTime);
                if (this.m_recieved_amount_date !=null) {
                    cmd.Parameters["@recieved_amount_date"].Value = this.m_recieved_amount_date;
                } else {
                    cmd.Parameters["@recieved_amount_date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@remain_amount", SqlDbType.BigInt);
                if (this.m_remain_amount !=0) {
                    cmd.Parameters["@remain_amount"].Value = this.m_remain_amount;
                } else {
                    cmd.Parameters["@remain_amount"].Value = null;
                }

                cmd.Parameters.Add("@recieve_organization", SqlDbType.VarChar);
                if (this.m_recieve_organization !=null) {
                    cmd.Parameters["@recieve_organization"].Value = this.m_recieve_organization;
                } else {
                    cmd.Parameters["@recieve_organization"].Value = "";
                }

                cmd.Parameters.Add("@recieve_organization_person", SqlDbType.VarChar);
                if (this.m_recieve_organization_person !=null) {
                    cmd.Parameters["@recieve_organization_person"].Value = this.m_recieve_organization_person;
                } else {
                    cmd.Parameters["@recieve_organization_person"].Value = "";
                }

                cmd.Parameters.Add("@pned_pned_id", SqlDbType.Int);
                if (this.m_pned_pned_id !=0) {
                    cmd.Parameters["@pned_pned_id"].Value = this.m_pned_pned_id;
                } else {
                    cmd.Parameters["@pned_pned_id"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Need_Recieve_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@need_recieve_id"].Value = this.m_need_recieve_id;
                    cmd.Parameters["@need_recieve_id"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Need_Recieve_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@need_recieve_id"].Value = this.m_need_recieve_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@need_recieve_id"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@need_recieve_id"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
               //     if (IsIdentityTable) {
               //         this.m_need_recieve_id = (Int64)cmd.Parameters["@need_recieve_id"].Value;
                //    }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Need_Recieve_GetAll";
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
        


// Get all records which match the passed value of PNed_ID
        public static DataTable GetByPNed_ID(int PNed_ID ) {
            string storedProcedure = "sp_Need_Recieve_GetByPNed_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PNed_ID", SqlDbType.Int);
            cmd.Parameters["@PNed_ID"].Value = PNed_ID;
        
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
        //     string storedProcedure = "sp_Need_Recieve_Custom";
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
