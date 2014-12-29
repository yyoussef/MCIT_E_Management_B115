// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Project_Activities_Budgets Class"
	[Serializable()]
	public class Project_Activities_Budgets
	{
#region "Instance Variables"
        protected Int64 m_pabud_id;
        protected Decimal m_pabud_value;
        protected System.DateTime m_pabud_date;
        protected string m_pabud_desc;
        protected Int64 m_pabud_order_no;
        protected Int64 m_pabud_order_year;
        protected Int64 m_pactv_pactv_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

#endregion


#region "Constructors"

	public Project_Activities_Budgets()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Project_Activities_Budgets(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Project_Activities_Budgets(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Pabud_Id {
            get { return this.m_pabud_id; }
            set {
                this.m_isDirty=true;
                this.m_pabud_id = value;
            }
        }

        public Decimal Pabud_Value {
            get { return this.m_pabud_value; }
            set {
                this.m_isDirty=true;
                this.m_pabud_value = value;
            }
        }

        public System.DateTime Pabud_Date {
            get { return this.m_pabud_date; }
            set {
                this.m_isDirty=true;
                this.m_pabud_date = value;
            }
        }

        public string Pabud_Desc {
            get { return this.m_pabud_desc; }
            set {
                this.m_isDirty=true;
                this.m_pabud_desc = value;
            }
        }

        public Int64 Pabud_Order_No {
            get { return this.m_pabud_order_no; }
            set {
                this.m_isDirty=true;
                this.m_pabud_order_no = value;
            }
        }

        public Int64 Pabud_Order_Year {
            get { return this.m_pabud_order_year; }
            set {
                this.m_isDirty=true;
                this.m_pabud_order_year = value;
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
                this.m_pabud_id = (Int64)dtrRow["PABUD_ID"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pabud_value = (Decimal)dtrRow["PABUD_Value"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pabud_date = (System.DateTime)dtrRow["PABUD_Date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pabud_desc = (string)dtrRow["PABUD_Desc"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pabud_order_no = (Int64)dtrRow["PABUD_Order_No"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pabud_order_year = (Int64)dtrRow["PABUD_Order_Year"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_pactv_id = (Int64)dtrRow["pactv_pactv_id"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["PABUD_ID"], DBNull.Value)))) {
                    this.m_pabud_id = (Int64)dtrRow["PABUD_ID"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PABUD_Value"], DBNull.Value)))) {
                    this.m_pabud_value = (Decimal)dtrRow["PABUD_Value"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PABUD_Date"], DBNull.Value)))) {
                    this.m_pabud_date = (System.DateTime)dtrRow["PABUD_Date"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PABUD_Desc"], DBNull.Value)))) {
                    this.m_pabud_desc = (string)dtrRow["PABUD_Desc"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PABUD_Order_No"], DBNull.Value)))) {
                    this.m_pabud_order_no = (Int64)dtrRow["PABUD_Order_No"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PABUD_Order_Year"], DBNull.Value)))) {
                    this.m_pabud_order_year = (Int64)dtrRow["PABUD_Order_Year"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["pactv_pactv_id"], DBNull.Value)))) {
                    this.m_pactv_pactv_id = (Int64)dtrRow["pactv_pactv_id"];
                }
            }
            catch (Exception ) {
            }
        }

        private void Get(Int64 intId)
        {
            string storedProcedure = "sp_Project_Activities_Budgets_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PABUD_ID", SqlDbType.BigInt);
            cmd.Parameters["@PABUD_ID"].Value = intId;

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
            string storedProcedure = "sp_Project_Activities_Budgets_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PABUD_ID", SqlDbType.Int);
            cmd.Parameters["@PABUD_ID"].Value = this.m_pabud_id;

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

                cmd.Parameters.Add("@PABUD_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@PABUD_Value", SqlDbType.Decimal);
                if (this.m_pabud_value !=0M) {
                    cmd.Parameters["@PABUD_Value"].Value = this.m_pabud_value;
                } else {
                    cmd.Parameters["@PABUD_Value"].Value = null;
                }

                cmd.Parameters.Add("@PABUD_Date", SqlDbType.DateTime);
                if (this.m_pabud_date !=null) {
                    cmd.Parameters["@PABUD_Date"].Value = this.m_pabud_date;
                } else {
                    cmd.Parameters["@PABUD_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@PABUD_Desc", SqlDbType.NVarChar);
                if (this.m_pabud_desc !=null) {
                    cmd.Parameters["@PABUD_Desc"].Value = this.m_pabud_desc;
                } else {
                    cmd.Parameters["@PABUD_Desc"].Value = "";
                }

                cmd.Parameters.Add("@PABUD_Order_No", SqlDbType.BigInt);
                if (this.m_pabud_order_no !=0) {
                    cmd.Parameters["@PABUD_Order_No"].Value = this.m_pabud_order_no;
                } else {
                    cmd.Parameters["@PABUD_Order_No"].Value = null;
                }

                cmd.Parameters.Add("@PABUD_Order_Year", SqlDbType.BigInt);
                if (this.m_pabud_order_year !=0) {
                    cmd.Parameters["@PABUD_Order_Year"].Value = this.m_pabud_order_year;
                } else {
                    cmd.Parameters["@PABUD_Order_Year"].Value = null;
                }

                cmd.Parameters.Add("@pactv_pactv_id", SqlDbType.BigInt);
                if (this.m_pactv_pactv_id !=0) {
                    cmd.Parameters["@pactv_pactv_id"].Value = this.m_pactv_pactv_id;
                } else {
                    cmd.Parameters["@pactv_pactv_id"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Project_Activities_Budgets_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PABUD_ID"].Value = this.m_pabud_id;
                    cmd.Parameters["@PABUD_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Activities_Budgets_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PABUD_ID"].Value = this.m_pabud_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@PABUD_ID"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@PABUD_ID"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                    if (IsIdentityTable) {
                        this.m_pabud_id = (Int64)cmd.Parameters["@PABUD_ID"].Value;
                    }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Activities_Budgets_GetAll";
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
            string storedProcedure = "sp_Project_Activities_Budgets_GetByPActv_ID";
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
        //     string storedProcedure = "sp_Project_Activities_Budgets_Custom";
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
