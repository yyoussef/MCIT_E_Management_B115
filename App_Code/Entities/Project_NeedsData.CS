// This file was automatically created by LayerGen 0.99e
// Created: 09/06/2010 02:26 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Project_Needs Class"
	[Serializable()]
	public class Project_Needs
	{
#region "Instance Variables"
        protected Int32 m_pned_id;
        protected string m_pned_name;
        protected Int64 m_pned_number;
        protected Int64 m_approved_amount;
        protected Decimal m_pned_initvalue;
        protected Int64 m_nst_nst_id;
        protected System.DateTime m_pned_date;
        protected Int64 m_proj_proj_id;
        protected Int64 m_totaldelievered;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        protected BLL.Needs_Sup_Type myNeeds_sup_type;
        protected BLL.Project myProject;

#endregion


#region "Constructors"

	public Project_Needs()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Project_Needs(Int32 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Project_Needs(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int32 Pned_Id {
            get { return this.m_pned_id; }
            set {
                this.m_isDirty=true;
                this.m_pned_id = value;
            }
        }

        public string Pned_Name {
            get { return this.m_pned_name; }
            set {
                this.m_isDirty=true;
                this.m_pned_name = value;
            }
        }

        public Int64 Pned_Number {
            get { return this.m_pned_number; }
            set {
                this.m_isDirty=true;
                this.m_pned_number = value;
            }
        }

        public Int64 Approved_Amount {
            get { return this.m_approved_amount; }
            set {
                this.m_isDirty=true;
                this.m_approved_amount = value;
            }
        }

        public Decimal Pned_Initvalue {
            get { return this.m_pned_initvalue; }
            set {
                this.m_isDirty=true;
                this.m_pned_initvalue = value;
            }
        }

        public Int64 Nst_Nst_Id {
            get { return this.m_nst_nst_id; }
            set {
                this.m_isDirty=true;
                this.m_nst_nst_id = value;
            }
        }

        public System.DateTime Pned_Date {
            get { return this.m_pned_date; }
            set {
                this.m_isDirty=true;
                this.m_pned_date = value;
            }
        }

        public Int64 Proj_Proj_Id {
            get { return this.m_proj_proj_id; }
            set {
                this.m_isDirty=true;
                this.m_proj_proj_id = value;
            }
        }

        public Int64 Totaldelievered {
            get { return this.m_totaldelievered; }
            set {
                this.m_isDirty=true;
                this.m_totaldelievered = value;
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
                this.m_pned_id = (Int32)dtrRow["PNed_ID"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pned_name = (string)dtrRow["PNed_Name"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pned_number = (Int64)dtrRow["PNed_Number"];
            }
            catch (Exception ) {
            }

            try {
                this.m_approved_amount = (Int64)dtrRow["approved_amount"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pned_initvalue = (Decimal)dtrRow["PNed_InitValue"];
            }
            catch (Exception ) {
            }

            try {
                this.m_nst_nst_id = (Int64)dtrRow["nst_nst_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pned_date = (System.DateTime)dtrRow["PNed_Date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_proj_proj_id = (Int64)dtrRow["proj_proj_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_totaldelievered = (Int64)dtrRow["TotalDelievered"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["PNed_ID"], DBNull.Value)))) {
                    this.m_pned_id = (Int32)dtrRow["PNed_ID"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PNed_Name"], DBNull.Value)))) {
                    this.m_pned_name = (string)dtrRow["PNed_Name"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PNed_Number"], DBNull.Value)))) {
                    this.m_pned_number = (Int64)dtrRow["PNed_Number"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["approved_amount"], DBNull.Value)))) {
                    this.m_approved_amount = (Int64)dtrRow["approved_amount"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PNed_InitValue"], DBNull.Value)))) {
                    this.m_pned_initvalue = (Decimal)dtrRow["PNed_InitValue"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["nst_nst_id"], DBNull.Value)))) {
                    this.m_nst_nst_id = (Int64)dtrRow["nst_nst_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PNed_Date"], DBNull.Value)))) {
                    this.m_pned_date = (System.DateTime)dtrRow["PNed_Date"];
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
                if (((!object.ReferenceEquals(dtrRow["TotalDelievered"], DBNull.Value)))) {
                    this.m_totaldelievered = (Int64)dtrRow["TotalDelievered"];
                }
            }
            catch (Exception ) {
            }
        }

        public DataTable Get(Int32 intId)
        {
            string storedProcedure = "sp_Project_Needs_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PNed_ID", SqlDbType.Int);
            cmd.Parameters["@PNed_ID"].Value = intId;

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
            string storedProcedure = "sp_Project_Needs_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PNed_ID", SqlDbType.Int);
            cmd.Parameters["@PNed_ID"].Value = this.m_pned_id;

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

            if ((this.myNeeds_sup_type != null)) {
                myNeeds_sup_type.Save();
            }

            if ((this.myProject != null)) {
                myProject.Save();
            }

            if ((m_isDirty)) {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PNed_ID", SqlDbType.Int);
                cmd.Parameters.Add("@PNed_Name", SqlDbType.VarChar);
                if (this.m_pned_name !=null) {
                    cmd.Parameters["@PNed_Name"].Value = this.m_pned_name;
                } else {
                    cmd.Parameters["@PNed_Name"].Value = "";
                }

                cmd.Parameters.Add("@PNed_Number", SqlDbType.BigInt);
                if (this.m_pned_number !=0) {
                    cmd.Parameters["@PNed_Number"].Value = this.m_pned_number;
                } else {
                    cmd.Parameters["@PNed_Number"].Value = null;
                }

                cmd.Parameters.Add("@approved_amount", SqlDbType.BigInt);
                if (this.m_approved_amount !=0) {
                    cmd.Parameters["@approved_amount"].Value = this.m_approved_amount;
                } else {
                    cmd.Parameters["@approved_amount"].Value = null;
                }

                cmd.Parameters.Add("@PNed_InitValue", SqlDbType.Decimal);
                if (this.m_pned_initvalue !=0M) {
                    cmd.Parameters["@PNed_InitValue"].Value = this.m_pned_initvalue;
                } else {
                    cmd.Parameters["@PNed_InitValue"].Value = null;
                }

                cmd.Parameters.Add("@nst_nst_id", SqlDbType.BigInt);
                if (this.m_nst_nst_id !=0) {
                    cmd.Parameters["@nst_nst_id"].Value = this.m_nst_nst_id;
                } else {
                    cmd.Parameters["@nst_nst_id"].Value = null;
                }

                cmd.Parameters.Add("@PNed_Date", SqlDbType.DateTime);
                if (this.m_pned_date !=null) {
                    cmd.Parameters["@PNed_Date"].Value = this.m_pned_date;
                } else {
                    cmd.Parameters["@PNed_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@proj_proj_id", SqlDbType.BigInt);
                if (this.m_proj_proj_id !=0) {
                    cmd.Parameters["@proj_proj_id"].Value = this.m_proj_proj_id;
                } else {
                    cmd.Parameters["@proj_proj_id"].Value = null;
                }

                cmd.Parameters.Add("@TotalDelievered", SqlDbType.BigInt);
                if (this.m_totaldelievered !=0) {
                    cmd.Parameters["@TotalDelievered"].Value = this.m_totaldelievered;
                } else {
                    cmd.Parameters["@TotalDelievered"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Project_Needs_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PNed_ID"].Value = this.m_pned_id;
                    cmd.Parameters["@PNed_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Needs_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PNed_ID"].Value = this.m_pned_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@PNed_ID"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@PNed_ID"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                    //if (IsIdentityTable) {
                    //    this.m_pned_id = (Int32)cmd.Parameters["@PNed_ID"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Needs_GetAll";
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
        


// Get all records which match the passed value of NST_ID
        public static DataTable GetByNST_ID(int NST_ID ) {
            string storedProcedure = "sp_Project_Needs_GetByNST_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@NST_ID", SqlDbType.Int);
            cmd.Parameters["@NST_ID"].Value = NST_ID;
        
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
            string storedProcedure = "sp_Project_Needs_GetByProj_id";
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
        //     string storedProcedure = "sp_Project_Needs_Custom";
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
