// This file was automatically created by LayerGen 0.99e
// Created: 14/03/2010 03:35 م

using System;
using System.Data;

#pragma warning disable 162

namespace DBL
{
    #region "Project Class"
    [Serializable()]
    public class Project
    {
        #region "Instance Variables"
        protected Int64 m_proj_id;
        protected string m_proj_title;
        protected string m_proj_brief;
        protected Decimal m_proj_initvalue;
        protected Int64 m_dept_dept_id;
        protected Int64 m_pmp_pmp_id;
        protected bool m_proj_is_commit;
        protected byte[] m_proj_document;
        protected System.DateTime m_proj_creation_date;
        protected bool m_proj_is_refused;
        protected bool m_proj_is_repeated;
        protected string m_proj_notes;

        protected bool m_isDirty = false;
        protected string ConnectString;
        private bool m_isFresh = false;

        #endregion


        #region "Constructors"

        public Project()
        {
            SetConnectString();
            this.m_isFresh = true;
        }

        public Project(Int64 intPrimaryKey)
        {
            SetConnectString();
            this.Get(intPrimaryKey);
            this.m_isFresh = false;
        }

        public Project(DataRow dtrRow)
        {
            SetConnectString();
            this.Fill(dtrRow);
            this.m_isFresh = false;
        }

        #endregion

        #region "Properties"
        public Int64 Proj_Id
        {
            get { return this.m_proj_id; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_id = value;
            }
        }

        public string Proj_Title
        {
            get { return this.m_proj_title; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_title = value;
            }
        }

        public string Proj_Brief
        {
            get { return this.m_proj_brief; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_brief = value;
            }
        }

        public Decimal Proj_Initvalue
        {
            get { return this.m_proj_initvalue; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_initvalue = value;
            }
        }

        public Int64 Dept_Dept_Id
        {
            get { return this.m_dept_dept_id; }
            set
            {
                this.m_isDirty = true;
                this.m_dept_dept_id = value;
            }
        }

        public Int64 Pmp_Pmp_Id
        {
            get { return this.m_pmp_pmp_id; }
            set
            {
                this.m_isDirty = true;
                this.m_pmp_pmp_id = value;
            }
        }

        public bool Proj_Is_Commit
        {
            get { return this.m_proj_is_commit; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_is_commit = value;
            }
        }

        public byte[] Proj_Document
        {
            get { return this.m_proj_document; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_document = value;
            }
        }

        public System.DateTime Proj_Creation_Date
        {
            get { return this.m_proj_creation_date; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_creation_date = value;
            }
        }

        public bool Proj_Is_Refused
        {
            get { return this.m_proj_is_refused; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_is_refused = value;
            }
        }

        public bool Proj_Is_Repeated
        {
            get { return this.m_proj_is_repeated; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_is_repeated = value;
            }
        }

        public string Proj_Notes
        {
            get { return this.m_proj_notes; }
            set
            {
                this.m_isDirty = true;
                this.m_proj_notes = value;
            }
        }

        public bool IsIdentityTable
        {
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
            try
            {
                this.m_proj_id = (Int64)dtrRow["Proj_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_title = (string)dtrRow["Proj_Title"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_brief = (string)dtrRow["Proj_Brief"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_initvalue = (Decimal)dtrRow["Proj_InitValue"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_dept_dept_id = (Int64)dtrRow["Dept_Dept_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_pmp_pmp_id = (Int64)dtrRow["pmp_pmp_id"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_is_commit = (bool)dtrRow["Proj_is_commit"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_document = (byte[])dtrRow["Proj_Document"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_creation_date = (System.DateTime)dtrRow["Proj_Creation_Date"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_is_refused = (bool)dtrRow["Proj_is_refused"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_is_repeated = (bool)dtrRow["Proj_is_repeated"];
            }
            catch (Exception)
            {
            }

            try
            {
                this.m_proj_notes = (string)dtrRow["Proj_Notes"];
            }
            catch (Exception)
            {
            }

        }

        protected void Fill(DataRow dtrRow)
        {
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_id"], DBNull.Value))))
                {
                    this.m_proj_id = (Int64)dtrRow["Proj_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_Title"], DBNull.Value))))
                {
                    this.m_proj_title = (string)dtrRow["Proj_Title"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_Brief"], DBNull.Value))))
                {
                    this.m_proj_brief = (string)dtrRow["Proj_Brief"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_InitValue"], DBNull.Value))))
                {
                    this.m_proj_initvalue = (Decimal)dtrRow["Proj_InitValue"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Dept_Dept_id"], DBNull.Value))))
                {
                    this.m_dept_dept_id = (Int64)dtrRow["Dept_Dept_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["pmp_pmp_id"], DBNull.Value))))
                {
                    this.m_pmp_pmp_id = (Int64)dtrRow["pmp_pmp_id"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_is_commit"], DBNull.Value))))
                {
                    this.m_proj_is_commit = (bool)dtrRow["Proj_is_commit"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_Document"], DBNull.Value))))
                {
                    this.m_proj_document = (byte[])dtrRow["Proj_Document"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_Creation_Date"], DBNull.Value))))
                {
                    this.m_proj_creation_date = (System.DateTime)dtrRow["Proj_Creation_Date"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_is_refused"], DBNull.Value))))
                {
                    this.m_proj_is_refused = (bool)dtrRow["Proj_is_refused"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_is_repeated"], DBNull.Value))))
                {
                    this.m_proj_is_repeated = (bool)dtrRow["Proj_is_repeated"];
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (((!object.ReferenceEquals(dtrRow["Proj_Notes"], DBNull.Value))))
                {
                    this.m_proj_notes = (string)dtrRow["Proj_Notes"];
                }
            }
            catch (Exception)
            {
            }
        }

        public DataTable Get(Int64 intId)
        {
            string storedProcedure = "sp_Project_Select";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            DataSet ds;
            string ConnectionString = GetConnectString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlDataAdapter da;

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Proj_id", SqlDbType.BigInt);
            cmd.Parameters["@Proj_id"].Value = intId;

            try
            {
                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Fill(ds.Tables[0].Rows[0]);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds.Tables[0];
            conn.Close();
        }

        public void Delete()
        {
            string storedProcedure = "sp_Project_Delete";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            string ConnectionString = GetConnectString();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Proj_id", SqlDbType.Int);
            cmd.Parameters["@Proj_id"].Value = this.m_proj_id;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
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

         
            if ((m_isDirty))
            {
                conn.ConnectionString = ConnectionString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Proj_id", SqlDbType.BigInt);
                cmd.Parameters.Add("@Proj_Title", SqlDbType.NVarChar);
                if (this.m_proj_title != null)
                {
                    cmd.Parameters["@Proj_Title"].Value = this.m_proj_title;
                }
                else
                {
                    cmd.Parameters["@Proj_Title"].Value = "";
                }

                cmd.Parameters.Add("@Proj_Brief", SqlDbType.NText);
                if (this.m_proj_brief != null)
                {
                    cmd.Parameters["@Proj_Brief"].Value = this.m_proj_brief;
                }
                else
                {
                    cmd.Parameters["@Proj_Brief"].Value = "";
                }

                cmd.Parameters.Add("@Proj_InitValue", SqlDbType.Decimal);
                if (this.m_proj_initvalue != 0M)
                {
                    cmd.Parameters["@Proj_InitValue"].Value = this.m_proj_initvalue;
                }
                else
                {
                    cmd.Parameters["@Proj_InitValue"].Value = null;
                }

                cmd.Parameters.Add("@Dept_Dept_id", SqlDbType.BigInt);
                if (this.m_dept_dept_id != 0)
                {
                    cmd.Parameters["@Dept_Dept_id"].Value = this.m_dept_dept_id;
                }
                else
                {
                    cmd.Parameters["@Dept_Dept_id"].Value = null;
                }

                cmd.Parameters.Add("@pmp_pmp_id", SqlDbType.BigInt);
                if (this.m_pmp_pmp_id != 0)
                {
                    cmd.Parameters["@pmp_pmp_id"].Value = this.m_pmp_pmp_id;
                }
                else
                {
                    cmd.Parameters["@pmp_pmp_id"].Value = null;
                }

                cmd.Parameters.Add("@Proj_is_commit", SqlDbType.Bit);
                if (this.m_proj_is_commit != false)
                {
                    cmd.Parameters["@Proj_is_commit"].Value = this.m_proj_is_commit;
                }
                else
                {
                    cmd.Parameters["@Proj_is_commit"].Value = false;
                }

                cmd.Parameters.Add("@Proj_Document", SqlDbType.Image);
                if (this.m_proj_document != null)
                {
                    cmd.Parameters["@Proj_Document"].Value = this.m_proj_document;
                }
                else
                {
                    cmd.Parameters["@Proj_Document"].Value = null;
                }

                cmd.Parameters.Add("@Proj_Creation_Date", SqlDbType.DateTime);
                if (this.m_proj_creation_date != null)
                {
                    cmd.Parameters["@Proj_Creation_Date"].Value = this.m_proj_creation_date;
                }
                else
                {
                    cmd.Parameters["@Proj_Creation_Date"].Value = System.DBNull.Value;
                }

                cmd.Parameters.Add("@Proj_is_refused", SqlDbType.Bit);
                if (this.m_proj_is_refused != false)
                {
                    cmd.Parameters["@Proj_is_refused"].Value = this.m_proj_is_refused;
                }
                else
                {
                    cmd.Parameters["@Proj_is_refused"].Value = false;
                }

                cmd.Parameters.Add("@Proj_is_repeated", SqlDbType.Bit);
                if (this.m_proj_is_repeated != false)
                {
                    cmd.Parameters["@Proj_is_repeated"].Value = this.m_proj_is_repeated;
                }
                else
                {
                    cmd.Parameters["@Proj_is_repeated"].Value = false;
                }

                cmd.Parameters.Add("@Proj_Notes", SqlDbType.NVarChar);
                if (this.m_proj_notes != null)
                {
                    cmd.Parameters["@Proj_Notes"].Value = this.m_proj_notes;
                }
                else
                {
                    cmd.Parameters["@Proj_Notes"].Value = "";
                }

                if (!this.m_isFresh)
                {
                    storedProcedure = "sp_Project_Update";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Proj_id"].Value = this.m_proj_id;
                    cmd.Parameters["@Proj_id"].Direction = ParameterDirection.Input;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    conn.Close();
                }
                else
                {
                    storedProcedure = "sp_Project_Insert";
                    cmd.CommandText = storedProcedure;

                    cmd.Parameters["@Proj_id"].Value = this.m_proj_id;
                    if (IsIdentityTable)
                    {
                        cmd.Parameters["@Proj_id"].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmd.Parameters["@Proj_id"].Direction = ParameterDirection.Input;
                    }
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    //if (IsIdentityTable)
                    //{
                    //    this.m_proj_id = (Int64)cmd.Parameters["@Proj_id"].Value;
                    //}
                    conn.Close();
                }
            }
        }


        public static DataTable GetAll()
        {
            string storedProcedure = "sp_Project_GetAll";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;

            try
            {
                DataSet ds;
                System.Data.SqlClient.SqlDataAdapter da;
                DataTable Table = null;

                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Table = ds.Tables[0];
                    }
                }
                conn.Close();
                return Table;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
        }



        // Get all records which match the passed value of Dept_ID
        public static DataTable GetByDept_ID(int Dept_ID)
        {
            string storedProcedure = "sp_Project_GetByDept_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@Dept_ID", SqlDbType.Int);
            cmd.Parameters["@Dept_ID"].Value = Dept_ID;

            try
            {
                DataSet ds;
                System.Data.SqlClient.SqlDataAdapter da;
                DataTable Table = null;

                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Table = ds.Tables[0];
                    }
                }
                conn.Close();
                return Table;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }
            conn.Close();
        }



        // Get all records which match the passed value of PMP_ID
        public static DataTable GetByPMP_ID(int PMP_ID)
        {
            string storedProcedure = "sp_Project_GetByPMP_ID";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string ConnectionString = GetConnectionString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = ConnectionString;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = storedProcedure;
            cmd.Parameters.Add("@PMP_ID", SqlDbType.Int);
            cmd.Parameters["@PMP_ID"].Value = PMP_ID;

            try
            {
                DataSet ds;
                System.Data.SqlClient.SqlDataAdapter da;
                DataTable Table = null;

                conn.Open();
                da = new System.Data.SqlClient.SqlDataAdapter();
                da.SelectCommand = cmd;

                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Table = ds.Tables[0];
                    }
                }
                conn.Close();
                return Table;
            }
            catch (Exception)
            {
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
        //     string storedProcedure = "sp_Project_Custom";
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
