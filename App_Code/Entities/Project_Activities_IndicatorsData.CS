// This file was automatically created by LayerGen 0.99e
// Created: 16-May-10 11:52 AM

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Project_Activities_Indicators Class"
	[Serializable()]
	public class Project_Activities_Indicators
	{
#region "Instance Variables"
        protected Int64 m_pai_id;
        protected string m_pai_desc;
        protected string m_pai_unit;
        protected Decimal m_pai_wieght;
        protected Int64 m_indt_indt_id;
        protected Int64 m_pactv_pactv_id;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

       

#endregion


#region "Constructors"

	public Project_Activities_Indicators()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Project_Activities_Indicators(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Project_Activities_Indicators(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Pai_Id {
            get { return this.m_pai_id; }
            set {
                this.m_isDirty=true;
                this.m_pai_id = value;
            }
        }

        public string Pai_Desc {
            get { return this.m_pai_desc; }
            set {
                this.m_isDirty=true;
                this.m_pai_desc = value;
            }
        }

        public string Pai_Unit {
            get { return this.m_pai_unit; }
            set {
                this.m_isDirty=true;
                this.m_pai_unit = value;
            }
        }

        public Decimal Pai_Wieght {
            get { return this.m_pai_wieght; }
            set {
                this.m_isDirty=true;
                this.m_pai_wieght = value;
            }
        }

        public Int64 Indt_Indt_Id {
            get { return this.m_indt_indt_id; }
            set {
                this.m_isDirty=true;
                this.m_indt_indt_id = value;
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
                this.m_pai_id = (Int64)dtrRow["PAI_ID"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pai_desc = (string)dtrRow["PAI_Desc"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pai_unit = (string)dtrRow["PAI_Unit"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pai_wieght = (Decimal)dtrRow["PAI_Wieght"];
            }
            catch (Exception ) {
            }

            try {
                this.m_indt_indt_id = (Int64)dtrRow["indt_indt_id"];
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
                if (((!object.ReferenceEquals(dtrRow["PAI_ID"], DBNull.Value)))) {
                    this.m_pai_id = (Int64)dtrRow["PAI_ID"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PAI_Desc"], DBNull.Value)))) {
                    this.m_pai_desc = (string)dtrRow["PAI_Desc"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PAI_Unit"], DBNull.Value)))) {
                    this.m_pai_unit = (string)dtrRow["PAI_Unit"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PAI_Wieght"], DBNull.Value)))) {
                    this.m_pai_wieght = (Decimal)dtrRow["PAI_Wieght"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["indt_indt_id"], DBNull.Value)))) {
                    this.m_indt_indt_id = (Int64)dtrRow["indt_indt_id"];
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

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Project_Activities_Indicators_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PAI_ID", SqlDbType.BigInt);
            cmd.Parameters["@PAI_ID"].Value = intId;

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
            string storedProcedure = "sp_Project_Activities_Indicators_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PAI_ID", SqlDbType.Int);
            cmd.Parameters["@PAI_ID"].Value = this.m_pai_id;

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

                cmd.Parameters.Add("@PAI_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@PAI_Desc", SqlDbType.NVarChar);
                if (this.m_pai_desc !=null) {
                    cmd.Parameters["@PAI_Desc"].Value = this.m_pai_desc;
                } else {
                    cmd.Parameters["@PAI_Desc"].Value = "";
                }

                cmd.Parameters.Add("@PAI_Unit", SqlDbType.VarChar);
                if (this.m_pai_unit !=null) {
                    cmd.Parameters["@PAI_Unit"].Value = this.m_pai_unit;
                } else {
                    cmd.Parameters["@PAI_Unit"].Value = "";
                }

                cmd.Parameters.Add("@PAI_Wieght", SqlDbType.Decimal);
                if (this.m_pai_wieght !=0M) {
                    cmd.Parameters["@PAI_Wieght"].Value = this.m_pai_wieght;
                } else {
                    cmd.Parameters["@PAI_Wieght"].Value = null;
                }

                cmd.Parameters.Add("@indt_indt_id", SqlDbType.BigInt);
                if (this.m_indt_indt_id !=0) {
                    cmd.Parameters["@indt_indt_id"].Value = this.m_indt_indt_id;
                } else {
                    cmd.Parameters["@indt_indt_id"].Value = null;
                }

                cmd.Parameters.Add("@pactv_pactv_id", SqlDbType.BigInt);
                if (this.m_pactv_pactv_id !=0) {
                    cmd.Parameters["@pactv_pactv_id"].Value = this.m_pactv_pactv_id;
                } else {
                    cmd.Parameters["@pactv_pactv_id"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Project_Activities_Indicators_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PAI_ID"].Value = this.m_pai_id;
                    cmd.Parameters["@PAI_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Activities_Indicators_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PAI_ID"].Value = this.m_pai_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@PAI_ID"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@PAI_ID"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                    //if (IsIdentityTable) {
                    //    this.m_pai_id = (Int64)cmd.Parameters["@PAI_ID"].Value;
                   // }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Activities_Indicators_GetAll";
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
        


// Get all records which match the passed value of IndT_id
        public static DataTable GetByIndT_id(int IndT_id ) {
            string storedProcedure = "sp_Project_Activities_Indicators_GetByIndT_id";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@IndT_id", SqlDbType.Int);
            cmd.Parameters["@IndT_id"].Value = IndT_id;
        
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
        


// Get all records which match the passed value of PActv_ID
        public static DataTable GetByPActv_ID(int PActv_ID ) {
            string storedProcedure = "sp_Project_Activities_Indicators_GetByPActv_ID";
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
        //     string storedProcedure = "sp_Project_Activities_Indicators_Custom";
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
