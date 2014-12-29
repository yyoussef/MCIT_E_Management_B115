// This file was automatically created by LayerGen 0.99e
// Created: 27-Apr-10 10:44 AM

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Project_Team Class"
	[Serializable()]
	public class Project_Team
	{
#region "Instance Variables"
        protected Int64 m_ptem_id;
        protected string m_ptem_name;
        protected string m_ptem_task_cat;
        protected string m_ptem_task;
        protected Int64 m_rol_rol_id;
        protected Int64 m_proj_proj_id;
        protected Int64 m_pmp_pmp_id;
        protected Int64 m_job_job_id;
        protected bool m_Edit_Project ;
        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

       

#endregion


#region "Constructors"

	public Project_Team()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Project_Team(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Project_Team(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Ptem_Id {
            get { return this.m_ptem_id; }
            set {
                this.m_isDirty=true;
                this.m_ptem_id = value;
            }
        }

        public string Ptem_Name {
            get { return this.m_ptem_name; }
            set {
                this.m_isDirty=true;
                this.m_ptem_name = value;
            }
        }

        public string Ptem_Task_Cat {
            get { return this.m_ptem_task_cat; }
            set {
                this.m_isDirty=true;
                this.m_ptem_task_cat = value;
            }
        }

        public string Ptem_Task {
            get { return this.m_ptem_task; }
            set {
                this.m_isDirty=true;
                this.m_ptem_task = value;
            }
        }

        public Int64 Rol_Rol_Id {
            get { return this.m_rol_rol_id; }
            set {
                this.m_isDirty=true;
                this.m_rol_rol_id = value;
            }
        }

        public Int64 Proj_Proj_Id {
            get { return this.m_proj_proj_id; }
            set {
                this.m_isDirty=true;
                this.m_proj_proj_id = value;
            }
        }

        public Int64 Pmp_Pmp_Id {
            get { return this.m_pmp_pmp_id; }
            set {
                this.m_isDirty=true;
                this.m_pmp_pmp_id = value;
            }
        }

        public Int64 Job_Job_Id {
            get { return this.m_job_job_id; }
            set {
                this.m_isDirty=true;
                this.m_job_job_id = value;
            }
        }

        public bool Edit_Project
        {
            get { return this.m_Edit_Project; }
            set
            {
                this.m_isDirty = true;
                this.m_Edit_Project = value;
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
                this.m_ptem_id = (Int64)dtrRow["PTem_ID"];
            }
            catch (Exception ) {
            }

            try {
                this.m_ptem_name = (string)dtrRow["PTem_Name"];
            }
            catch (Exception ) {
            }

            try {
                this.m_ptem_task_cat = (string)dtrRow["PTem_Task_Cat"];
            }
            catch (Exception ) {
            }

            try {
                this.m_ptem_task = (string)dtrRow["PTem_Task"];
            }
            catch (Exception ) {
            }

            try {
                this.m_rol_rol_id = (Int64)dtrRow["rol_rol_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_proj_proj_id = (Int64)dtrRow["proj_proj_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pmp_pmp_id = (Int64)dtrRow["pmp_pmp_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_job_job_id = (Int64)dtrRow["job_job_id"];
            }
            catch (Exception ) {
            }

            try
            {
                this.m_Edit_Project = (bool)dtrRow["Edit_Project"];
            }
            catch (Exception)
            {
            }


        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["PTem_ID"], DBNull.Value)))) {
                    this.m_ptem_id = (Int64)dtrRow["PTem_ID"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PTem_Name"], DBNull.Value)))) {
                    this.m_ptem_name = (string)dtrRow["PTem_Name"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PTem_Task_Cat"], DBNull.Value)))) {
                    this.m_ptem_task_cat = (string)dtrRow["PTem_Task_Cat"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PTem_Task"], DBNull.Value)))) {
                    this.m_ptem_task = (string)dtrRow["PTem_Task"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["rol_rol_id"], DBNull.Value)))) {
                    this.m_rol_rol_id = (Int64)dtrRow["rol_rol_id"];
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
                if (((!object.ReferenceEquals(dtrRow["pmp_pmp_id"], DBNull.Value)))) {
                    this.m_pmp_pmp_id = (Int64)dtrRow["pmp_pmp_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["job_job_id"], DBNull.Value)))) {
                    this.m_job_job_id = (Int64)dtrRow["job_job_id"];
                }
            }
            catch (Exception ) {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Edit_Project"], DBNull.Value))))
                {
                    this.m_Edit_Project = (bool)dtrRow["Edit_Project"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            DataTable Table;
            string storedProcedure = "sp_Project_Team_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PTem_ID", SqlDbType.BigInt);
            cmd.Parameters["@PTem_ID"].Value = intId;

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
            Table = ds.Tables[0];
            return Table;
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_Project_Team_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PTem_ID", SqlDbType.Int);
            cmd.Parameters["@PTem_ID"].Value = this.m_ptem_id;

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

                cmd.Parameters.Add("@PTem_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@PTem_Name", SqlDbType.NVarChar);
                if (this.m_ptem_name !=null) {
                    cmd.Parameters["@PTem_Name"].Value = this.m_ptem_name;
                } else {
                    cmd.Parameters["@PTem_Name"].Value = "";
                }

                cmd.Parameters.Add("@PTem_Task_Cat", SqlDbType.VarChar);
                if (this.m_ptem_task_cat !=null) {
                    cmd.Parameters["@PTem_Task_Cat"].Value = this.m_ptem_task_cat;
                } else {
                    cmd.Parameters["@PTem_Task_Cat"].Value = "";
                }

                cmd.Parameters.Add("@PTem_Task", SqlDbType.NVarChar);
                if (this.m_ptem_task !=null) {
                    cmd.Parameters["@PTem_Task"].Value = this.m_ptem_task;
                } else {
                    cmd.Parameters["@PTem_Task"].Value = "";
                }

                cmd.Parameters.Add("@rol_rol_id", SqlDbType.BigInt);
                if (this.m_rol_rol_id !=0) {
                    cmd.Parameters["@rol_rol_id"].Value = this.m_rol_rol_id;
                } else {
                    cmd.Parameters["@rol_rol_id"].Value = null;
                }

                cmd.Parameters.Add("@proj_proj_id", SqlDbType.BigInt);
                if (this.m_proj_proj_id !=0) {
                    cmd.Parameters["@proj_proj_id"].Value = this.m_proj_proj_id;
                } else {
                    cmd.Parameters["@proj_proj_id"].Value = null;
                }

                cmd.Parameters.Add("@pmp_pmp_id", SqlDbType.BigInt);
                if (this.m_pmp_pmp_id !=0) {
                    cmd.Parameters["@pmp_pmp_id"].Value = this.m_pmp_pmp_id;
                } else {
                    cmd.Parameters["@pmp_pmp_id"].Value = null;
                }

                cmd.Parameters.Add("@job_job_id", SqlDbType.BigInt);
                if (this.m_job_job_id !=0) {
                    cmd.Parameters["@job_job_id"].Value = this.m_job_job_id;
                } else {
                    cmd.Parameters["@job_job_id"].Value = null;
                }

                cmd.Parameters.Add("@Edit_Project", SqlDbType.Bit);
                cmd.Parameters["@Edit_Project"].Value = this.m_Edit_Project;
                


                if (!this.m_isFresh) {
                    storedProcedure = "sp_Project_Team_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PTem_ID"].Value = this.m_ptem_id;
                    cmd.Parameters["@PTem_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Team_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PTem_ID"].Value = this.m_ptem_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@PTem_ID"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@PTem_ID"].Direction = ParameterDirection.Input;
                    }
                    try {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                   // if (IsIdentityTable) {
                    //    this.m_ptem_id = (Int64)cmd.Parameters["@PTem_ID"].Value;
                   // }
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_Team_GetAll";
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
        


// Get all records which match the passed value of PMP_ID
        public static DataTable GetByPMP_ID(int PMP_ID ) {
            string storedProcedure = "sp_Project_Team_GetByPMP_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PMP_ID", SqlDbType.Int);
            cmd.Parameters["@PMP_ID"].Value = PMP_ID;
        
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
        


// Get all records which match the passed value of JOB_ID
        public static DataTable GetByJOB_ID(int JOB_ID ) {
            string storedProcedure = "sp_Project_Team_GetByJOB_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@JOB_ID", SqlDbType.Int);
            cmd.Parameters["@JOB_ID"].Value = JOB_ID;
        
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
            string storedProcedure = "sp_Project_Team_GetByProj_id";
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
        


// Get all records which match the passed value of Rol_ID
        public static DataTable GetByRol_ID(int Rol_ID ) {
            string storedProcedure = "sp_Project_Team_GetByRol_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        
            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Rol_ID", SqlDbType.Int);
            cmd.Parameters["@Rol_ID"].Value = Rol_ID;
        
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
        //     string storedProcedure = "sp_Project_Team_Custom";
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
