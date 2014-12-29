// This file was automatically created by LayerGen 0.99e
// Created: 12-May-10 3:42 PM

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
#region "Project_Activities Class"
	[Serializable()]
	public class Project_Activities
	{
#region "Instance Variables"
        protected Int64 m_pactv_id;
        protected string m_pactv_desc;
        protected Decimal m_pactv_wieght;
        protected Decimal m_pactv_alarm;
        protected System.DateTime m_pactv_start_date;
        protected System.DateTime m_pactv_end_date;
        protected Decimal m_pactv_period;
        protected System.DateTime m_pactv_actual_start_date;
        protected System.DateTime m_pactv_actual_end_date;
        protected Decimal m_pactv_actual_period;
        protected Int64 m_pactv_parent;
        protected Int64 m_pactv_is_milestone;
        protected Int64 m_proj_proj_id;
        protected Int64 m_actstat_actstat_id;
        protected Int64 m_excutive_responsible_org_org_id;
        protected string m_pactv_implementing_person;
        protected string m_pactv_implementing_location;
        protected string m_parent_pactv_desc;
        protected Int64 m_parent_actv_num;
        protected Int64 m_child_actv_num;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

       

#endregion


#region "Constructors"

	public Project_Activities()
	{
		SetConnectString();
		this.m_isFresh = true;
	}

	public Project_Activities(Int64 intPrimaryKey )
	{
		SetConnectString();
		this.Get(intPrimaryKey);
		this.m_isFresh = false;
	}

	public Project_Activities(DataRow dtrRow)
	{
		SetConnectString();
		this.Fill(dtrRow);
		this.m_isFresh = false;
	}

#endregion

#region "Properties"
        public Int64 Pactv_Id {
            get { return this.m_pactv_id; }
            set {
                this.m_isDirty=true;
                this.m_pactv_id = value;
            }
        }

        public string Pactv_Desc {
            get { return this.m_pactv_desc; }
            set {
                this.m_isDirty=true;
                this.m_pactv_desc = value;
            }
        }

        public Decimal Pactv_Wieght {
            get { return this.m_pactv_wieght; }
            set {
                this.m_isDirty=true;
                this.m_pactv_wieght = value;
            }
        }

        public Decimal Pactv_Alarm {
            get { return this.m_pactv_alarm; }
            set {
                this.m_isDirty=true;
                this.m_pactv_alarm = value;
            }
        }

        public System.DateTime Pactv_Start_Date {
            get { return this.m_pactv_start_date; }
            set {
                this.m_isDirty=true;
                this.m_pactv_start_date = value;
            }
        

        }

        public System.DateTime Pactv_End_Date {
            get { return this.m_pactv_end_date; }
            set {
                this.m_isDirty=true;
                this.m_pactv_end_date = value;
            }
        }

        public Decimal Pactv_Period {
            get { return this.m_pactv_period; }
            set {
                this.m_isDirty=true;
                this.m_pactv_period = value;
            }
        }

        public System.DateTime Pactv_Actual_Start_Date {
            get { return this.m_pactv_actual_start_date; }
            set {
                this.m_isDirty=true;
                this.m_pactv_actual_start_date = value;
            }
        }

        public System.DateTime Pactv_Actual_End_Date {
            get { return this.m_pactv_actual_end_date; }
            set {
                this.m_isDirty=true;
                this.m_pactv_actual_end_date = value;
            }
        }

        public Decimal Pactv_Actual_Period {
            get { return this.m_pactv_actual_period; }
            set {
                this.m_isDirty=true;
                this.m_pactv_actual_period = value;
            }
        }

        public Int64 Pactv_Parent {
            get { return this.m_pactv_parent; }
            set {
                this.m_isDirty=true;
                this.m_pactv_parent = value;
            }
        }

        public Int64 Pactv_Is_Milestone {
            get { return this.m_pactv_is_milestone; }
            set {
                this.m_isDirty=true;
                this.m_pactv_is_milestone = value;
            }
        }

        public Int64 Proj_Proj_Id {
            get { return this.m_proj_proj_id; }
            set {
                this.m_isDirty=true;
                this.m_proj_proj_id = value;
            }
        }

        public Int64 Actstat_Actstat_Id {
            get { return this.m_actstat_actstat_id; }
            set {
                this.m_isDirty=true;
                this.m_actstat_actstat_id = value;
            }
        }

        public Int64 Excutive_Responsible_Org_Org_Id {
            get { return this.m_excutive_responsible_org_org_id; }
            set {
                this.m_isDirty=true;
                this.m_excutive_responsible_org_org_id = value;
            }
        }

        public string Pactv_Implementing_Person {
            get { return this.m_pactv_implementing_person; }
            set {
                this.m_isDirty=true;
                this.m_pactv_implementing_person = value;
            }
        }

        public string Pactv_Implementing_Location {
            get { return this.m_pactv_implementing_location; }
            set {
                this.m_isDirty=true;
                this.m_pactv_implementing_location = value;
            }
        }

        public string Parent_Pactv_Desc {
            get { return this.m_parent_pactv_desc; }
            set {
                this.m_isDirty=true;
                this.m_parent_pactv_desc = value;
            }
        }

        public Int64 Parent_Actv_Num {
            get { return this.m_parent_actv_num; }
            set {
                this.m_isDirty=true;
                this.m_parent_actv_num = value;
            }
        }

        public Int64 Child_Actv_Num {
            get { return this.m_child_actv_num; }
            set {
                this.m_isDirty=true;
                this.m_child_actv_num = value;
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
                this.m_pactv_id = (Int64)dtrRow["PActv_ID"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_desc = (string)dtrRow["PActv_Desc"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_wieght = (Decimal)dtrRow["PActv_wieght"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_alarm = (Decimal)dtrRow["PActv_Alarm"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_start_date = (System.DateTime)dtrRow["PActv_Start_Date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_end_date = (System.DateTime)dtrRow["PActv_End_Date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_period = (Decimal)dtrRow["PActv_Period"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_actual_start_date = (System.DateTime)dtrRow["PActv_Actual_Start_Date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_actual_end_date = (System.DateTime)dtrRow["PActv_Actual_End_Date"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_actual_period = (Decimal)dtrRow["PActv_Actual_Period"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_parent = (Int64)dtrRow["PActv_Parent"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_is_milestone = (Int64)dtrRow["PActv_is_Milestone"];
            }
            catch (Exception ) {
            }

            try {
                this.m_proj_proj_id = (Int64)dtrRow["proj_proj_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_actstat_actstat_id = (Int64)dtrRow["ActStat_ActStat_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_excutive_responsible_org_org_id = (Int64)dtrRow["Excutive_responsible_Org_Org_id"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_implementing_person = (string)dtrRow["PActv_Implementing_person"];
            }
            catch (Exception ) {
            }

            try {
                this.m_pactv_implementing_location = (string)dtrRow["PActv_Implementing_Location"];
            }
            catch (Exception ) {
            }

            try {
                this.m_parent_pactv_desc = (string)dtrRow["Parent_PActv_Desc"];
            }
            catch (Exception ) {
            }

            try {
                this.m_parent_actv_num = (Int64)dtrRow["Parent_Actv_Num"];
            }
            catch (Exception ) {
            }

            try {
                this.m_child_actv_num = (Int64)dtrRow["Child_Actv_Num"];
            }
            catch (Exception ) {
            }

        }
        protected void Fill(DataRow dtrRow )
        {
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_ID"], DBNull.Value)))) {
                    this.m_pactv_id = (Int64)dtrRow["PActv_ID"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Desc"], DBNull.Value)))) {
                    this.m_pactv_desc = (string)dtrRow["PActv_Desc"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_wieght"], DBNull.Value)))) {
                    this.m_pactv_wieght = (Decimal)dtrRow["PActv_wieght"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Alarm"], DBNull.Value)))) {
                    this.m_pactv_alarm = (Decimal)dtrRow["PActv_Alarm"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Start_Date"], DBNull.Value)))) {
                    this.m_pactv_start_date = (System.DateTime)dtrRow["PActv_Start_Date"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_End_Date"], DBNull.Value)))) {
                    this.m_pactv_end_date = (System.DateTime)dtrRow["PActv_End_Date"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Period"], DBNull.Value)))) {
                    this.m_pactv_period = (Decimal)dtrRow["PActv_Period"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Actual_Start_Date"], DBNull.Value)))) {
                    this.m_pactv_actual_start_date = (System.DateTime)dtrRow["PActv_Actual_Start_Date"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Actual_End_Date"], DBNull.Value)))) {
                    this.m_pactv_actual_end_date = (System.DateTime)dtrRow["PActv_Actual_End_Date"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Actual_Period"], DBNull.Value)))) {
                    this.m_pactv_actual_period = (Decimal)dtrRow["PActv_Actual_Period"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Parent"], DBNull.Value)))) {
                    this.m_pactv_parent = (Int64)dtrRow["PActv_Parent"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_is_Milestone"], DBNull.Value)))) {
                    this.m_pactv_is_milestone = (Int64)dtrRow["PActv_is_Milestone"];
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
                if (((!object.ReferenceEquals(dtrRow["ActStat_ActStat_id"], DBNull.Value)))) {
                    this.m_actstat_actstat_id = (Int64)dtrRow["ActStat_ActStat_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Excutive_responsible_Org_Org_id"], DBNull.Value)))) {
                    this.m_excutive_responsible_org_org_id = (Int64)dtrRow["Excutive_responsible_Org_Org_id"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Implementing_person"], DBNull.Value)))) {
                    this.m_pactv_implementing_person = (string)dtrRow["PActv_Implementing_person"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["PActv_Implementing_Location"], DBNull.Value)))) {
                    this.m_pactv_implementing_location = (string)dtrRow["PActv_Implementing_Location"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Parent_PActv_Desc"], DBNull.Value)))) {
                    this.m_parent_pactv_desc = (string)dtrRow["Parent_PActv_Desc"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Parent_Actv_Num"], DBNull.Value)))) {
                    this.m_parent_actv_num = (Int64)dtrRow["Parent_Actv_Num"];
                }
            }
            catch (Exception ) {
            }
            try {
                if (((!object.ReferenceEquals(dtrRow["Child_Actv_Num"], DBNull.Value)))) {
                    this.m_child_actv_num = (Int64)dtrRow["Child_Actv_Num"];
                }
            }
            catch (Exception ) {
            }
        }

        public DataTable Get(Int64 intId)
        {

            string storedProcedure = "sp_Project_Activities_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(); 
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PActv_ID", SqlDbType.BigInt);
            cmd.Parameters["@PActv_ID"].Value = intId;

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
            string storedProcedure = "sp_Project_Activities_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PActv_ID", SqlDbType.Int);
            cmd.Parameters["@PActv_ID"].Value = this.m_pactv_id;

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

                cmd.Parameters.Add("@PActv_ID", SqlDbType.BigInt);
                cmd.Parameters.Add("@PActv_Desc", SqlDbType.NVarChar);
                if (this.m_pactv_desc !=null) {
                    cmd.Parameters["@PActv_Desc"].Value = this.m_pactv_desc;
                } else {
                    cmd.Parameters["@PActv_Desc"].Value = "";
                }

                cmd.Parameters.Add("@PActv_wieght", SqlDbType.Decimal);
                if (this.m_pactv_wieght !=0M) {
                    cmd.Parameters["@PActv_wieght"].Value = this.m_pactv_wieght;
                } else {
                    cmd.Parameters["@PActv_wieght"].Value = null;
                }

                cmd.Parameters.Add("@PActv_Alarm", SqlDbType.Decimal);
                if (this.m_pactv_alarm !=0M) {
                    cmd.Parameters["@PActv_Alarm"].Value = this.m_pactv_alarm;
                } else {
                    cmd.Parameters["@PActv_Alarm"].Value = null;
                }

                cmd.Parameters.Add("@PActv_Start_Date", SqlDbType.DateTime);
                if (this.m_pactv_start_date !=null) {
                    cmd.Parameters["@PActv_Start_Date"].Value = this.m_pactv_start_date;
                } else {
                    cmd.Parameters["@PActv_Start_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@PActv_End_Date", SqlDbType.DateTime);
                if (this.m_pactv_end_date !=null) {
                    cmd.Parameters["@PActv_End_Date"].Value = this.m_pactv_end_date;
                } else {
                    cmd.Parameters["@PActv_End_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@PActv_Period", SqlDbType.Decimal);
                if (this.m_pactv_period !=0M) {
                    cmd.Parameters["@PActv_Period"].Value = this.m_pactv_period;
                } else {
                    cmd.Parameters["@PActv_Period"].Value = null;
                }

                cmd.Parameters.Add("@PActv_Actual_Start_Date", SqlDbType.DateTime);
                if (this.m_pactv_actual_start_date !=null) {
                    cmd.Parameters["@PActv_Actual_Start_Date"].Value = this.m_pactv_actual_start_date;
                } else {
                    cmd.Parameters["@PActv_Actual_Start_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@PActv_Actual_End_Date", SqlDbType.DateTime);
                if (this.m_pactv_actual_end_date !=null) {
                    cmd.Parameters["@PActv_Actual_End_Date"].Value = this.m_pactv_actual_end_date;
                } else {
                    cmd.Parameters["@PActv_Actual_End_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@PActv_Actual_Period", SqlDbType.Decimal);
                if (this.m_pactv_actual_period !=0M) {
                    cmd.Parameters["@PActv_Actual_Period"].Value = this.m_pactv_actual_period;
                } else {
                    cmd.Parameters["@PActv_Actual_Period"].Value = null;
                }

                cmd.Parameters.Add("@PActv_Parent", SqlDbType.BigInt);
                if (this.m_pactv_parent !=0) {
                    cmd.Parameters["@PActv_Parent"].Value = this.m_pactv_parent;
                } else {
                    cmd.Parameters["@PActv_Parent"].Value = null;
                }

                cmd.Parameters.Add("@PActv_is_Milestone", SqlDbType.BigInt);
                if (this.m_pactv_is_milestone !=0) {
                    cmd.Parameters["@PActv_is_Milestone"].Value = this.m_pactv_is_milestone;
                } else {
                    cmd.Parameters["@PActv_is_Milestone"].Value = null;
                }

                cmd.Parameters.Add("@proj_proj_id", SqlDbType.BigInt);
                if (this.m_proj_proj_id !=0) {
                    cmd.Parameters["@proj_proj_id"].Value = this.m_proj_proj_id;
                } else {
                    cmd.Parameters["@proj_proj_id"].Value = null;
                }

                cmd.Parameters.Add("@ActStat_ActStat_id", SqlDbType.BigInt);
                if (this.m_actstat_actstat_id !=0) {
                    cmd.Parameters["@ActStat_ActStat_id"].Value = this.m_actstat_actstat_id;
                } else {
                    cmd.Parameters["@ActStat_ActStat_id"].Value = null;
                }

                cmd.Parameters.Add("@Excutive_responsible_Org_Org_id", SqlDbType.BigInt);
                if (this.m_excutive_responsible_org_org_id !=0) {
                    cmd.Parameters["@Excutive_responsible_Org_Org_id"].Value = this.m_excutive_responsible_org_org_id;
                } else {
                    cmd.Parameters["@Excutive_responsible_Org_Org_id"].Value = null;
                }

                cmd.Parameters.Add("@PActv_Implementing_person", SqlDbType.NVarChar);
                if (this.m_pactv_implementing_person !=null) {
                    cmd.Parameters["@PActv_Implementing_person"].Value = this.m_pactv_implementing_person;
                } else {
                    cmd.Parameters["@PActv_Implementing_person"].Value = "";
                }

                cmd.Parameters.Add("@PActv_Implementing_Location", SqlDbType.NVarChar);
                if (this.m_pactv_implementing_location !=null) {
                    cmd.Parameters["@PActv_Implementing_Location"].Value = this.m_pactv_implementing_location;
                } else {
                    cmd.Parameters["@PActv_Implementing_Location"].Value = "";
                }

                cmd.Parameters.Add("@Parent_PActv_Desc", SqlDbType.Text);
                if (this.m_parent_pactv_desc !=null) {
                    cmd.Parameters["@Parent_PActv_Desc"].Value = this.m_parent_pactv_desc;
                } else {
                    cmd.Parameters["@Parent_PActv_Desc"].Value = null;
                }

                cmd.Parameters.Add("@Parent_Actv_Num", SqlDbType.BigInt);
                if (this.m_parent_actv_num !=0) {
                    cmd.Parameters["@Parent_Actv_Num"].Value = this.m_parent_actv_num;
                } else {
                    cmd.Parameters["@Parent_Actv_Num"].Value = null;
                }

                cmd.Parameters.Add("@Child_Actv_Num", SqlDbType.BigInt);
                if (this.m_child_actv_num !=0) {
                    cmd.Parameters["@Child_Actv_Num"].Value = this.m_child_actv_num;
                } else {
                    cmd.Parameters["@Child_Actv_Num"].Value = null;
                }

                if (!this.m_isFresh) {
                    storedProcedure = "sp_Project_Activities_Update";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PActv_ID"].Value = this.m_pactv_id;
                    cmd.Parameters["@PActv_ID"].Direction = ParameterDirection.Input;
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
                    storedProcedure = "sp_Project_Activities_Insert";
                    cmd.CommandText=storedProcedure;

                    cmd.Parameters["@PActv_ID"].Value = this.m_pactv_id;
                    if (IsIdentityTable) {
                        cmd.Parameters["@PActv_ID"].Direction = ParameterDirection.Output;
                    } else {
                        cmd.Parameters["@PActv_ID"].Direction = ParameterDirection.Input;
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
            string storedProcedure = "sp_Project_Activities_GetAll";
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
            string storedProcedure = "sp_Project_Activities_GetByOrg_ID";
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
            string storedProcedure = "sp_Project_Activities_GetByProj_id";
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
        //     string storedProcedure = "sp_Project_Activities_Custom";
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
