// This file was automatically created by LayerGen 0.99e
// Created: 03/06/2010 09:59 ص

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Need_Availble Class"
	[Serializable()]
	public class Need_Availble
	{
#region "Instance Variables"
        protected Int32 m_need_availble_id;
        protected string m_availble_item;
        protected Int64 m_availble_amount;
        protected System.DateTime m_availble_amount_date;
        protected Int32 m_pned_pned_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        protected BLL.Project_Needs myProject_needs;

#endregion


#region "Constructors"

	public Need_Availble()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Need_Availble(Int32 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Need_Availble(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int32 Need_Availble_Id {
            get { return this.m_need_availble_id; }
            set {
                this.m_isDirty=true;
                this.m_need_availble_id = value;
            }
        }

        public string Availble_Item {
            get { return this.m_availble_item; }
            set {
                this.m_isDirty=true;
                this.m_availble_item = value;
            }
        }

        public Int64 Availble_Amount {
            get { return this.m_availble_amount; }
            set {
                this.m_isDirty=true;
                this.m_availble_amount = value;
            }
        }

        public System.DateTime Availble_Amount_Date {
            get { return this.m_availble_amount_date; }
            set {
                this.m_isDirty=true;
                this.m_availble_amount_date = value;
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
                this.m_need_availble_id = (Int32)dtrRow["Need_Availble_Id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_availble_item = (string)dtrRow["Availble_Item"];
            }
            catch (Exception ) {
            }

            try {
                this.m_availble_amount = (Int64)dtrRow["Availble_Amount"];
            }
            catch (Exception ) {
            }

            try {
                this.m_availble_amount_date = (System.DateTime)dtrRow["Availble_Amount_Date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pned_pned_id = (Int32)dtrRow["PNed_PNed_Id"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["Need_Availble_Id"], DBNull.Value)))) {
                    this.m_need_availble_id = (Int32)dtrRow["Need_Availble_Id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Availble_Item"], DBNull.Value)))) {
                    this.m_availble_item = (string)dtrRow["Availble_Item"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Availble_Amount"], DBNull.Value)))) {
                    this.m_availble_amount = (Int64)dtrRow["Availble_Amount"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Availble_Amount_Date"], DBNull.Value)))) {
                    this.m_availble_amount_date = (System.DateTime)dtrRow["Availble_Amount_Date"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PNed_PNed_Id"], DBNull.Value)))) {
                    this.m_pned_pned_id = (Int32)dtrRow["PNed_PNed_Id"];
                }
            }
            catch (Exception ) {
            }
        }

        public DataTable Get(Int32 intId)
        {
            string storedProcedure = "sp_Need_Availble_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Need_Availble_Id", SqlDbType.Int);
            cmd.Parameters["@Need_Availble_Id"].Value = intId;

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
            string storedProcedure = "sp_Need_Availble_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Need_Availble_Id", SqlDbType.Int);
            cmd.Parameters["@Need_Availble_Id"].Value = this.m_need_availble_id;

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

                cmd.Parameters.Add("@Need_Availble_Id", SqlDbType.Int);
                cmd.Parameters.Add("@Availble_Item", SqlDbType.VarChar);
                if (this.m_availble_item !=null) {
                    cmd.Parameters["@Availble_Item"].Value = this.m_availble_item;
                } else {
                    cmd.Parameters["@Availble_Item"].Value = "";
                }

                cmd.Parameters.Add("@Availble_Amount", SqlDbType.BigInt);
                if (this.m_availble_amount !=0) {
                    cmd.Parameters["@Availble_Amount"].Value = this.m_availble_amount;
                } else {
                    cmd.Parameters["@Availble_Amount"].Value = null;
                }

                cmd.Parameters.Add("@Availble_Amount_Date", SqlDbType.DateTime);
                if (this.m_availble_amount_date !=null) {
                    cmd.Parameters["@Availble_Amount_Date"].Value = this.m_availble_amount_date;
                } else {
                    cmd.Parameters["@Availble_Amount_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@PNed_PNed_Id", SqlDbType.Int);
                if (this.m_pned_pned_id !=0) {
                    cmd.Parameters["@PNed_PNed_Id"].Value = this.m_pned_pned_id;
                } else {
                    cmd.Parameters["@PNed_PNed_Id"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Need_Availble_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@Need_Availble_Id"].Value = this.m_need_availble_id;
                    cmd.Parameters["@Need_Availble_Id"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Need_Availble_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@Need_Availble_Id"].Value = this.m_need_availble_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@Need_Availble_Id"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@Need_Availble_Id"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                  //  if (IsIdentityTable) {
                  //      this.m_need_availble_id = (Int32)cmd.Parameters["@Need_Availble_Id"].Value;
                  //  }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Need_Availble_GetAll";
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
            string storedProcedure = "sp_Need_Availble_GetByPNed_ID";
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
        //     string storedProcedure = "sp_Need_Availble_Custom";
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
