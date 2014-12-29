using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public partial class UserControls_ALL_Document_Details : System.Web.UI.UserControl
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null && Request["type"] != null)
            {
                try
                {

                    SqlDataAdapter sqladptr = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection();
                    if (string.IsNullOrEmpty(Session_CS.local_connectionstring))
                    {
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    }
                    else
                    {
                        con = new SqlConnection(Session_CS.local_connectionstring);
                       
                     
                    }
                    string procedure_name = "";


                    switch (Request["type"].ToLower())
                    {
                        case "meeting":
                            procedure_name = "Get_Meetings_Files_By_ID";
                            break;
                        case "inbox":
                            procedure_name = "Inbox_OutBox_Files_Select";
                            break;
                        case "imgservice":
                            procedure_name = "proj_img_service_Select";
                            break;
                        case "videoservice":
                            procedure_name = "proj_video_service_Select";
                            break;
                        case "statservice":
                            procedure_name = "proj_statistics_service_Select";
                            break;
                        case "commission":
                            procedure_name = "Commission_Files_Select";
                            break;
                        case "work":
                            procedure_name = "Fin_Work_bill_Files_Select";
                            break;
                        case "outbox":
                            procedure_name = "Get_Outbox";
                            break;
                        case "presentation":
                            procedure_name = "Get_Presentation";
                            break;
                        case "protocol":
                            procedure_name = "Get_Protocol";
                            break;
                        case "event":
                            procedure_name = "Get_Event";
                            break;
                        case "file":
                            procedure_name = "Get_File_Documents";
                            break;
                        case "protocoldef":
                            procedure_name = "Protocol_Documents_Select";
                            break;
                        case "protocolmain":
                            procedure_name = "Protocol_Main_Documents_Select";
                            break;

                        case "deprtfile":
                            procedure_name = "Departments_Documents_Select";
                            break;
                        case "protocolfnsh":
                            procedure_name = "Protocol_Finishing_Select";
                            break;

                        case "projectend":
                            procedure_name = "Project_End_Document_Select";
                            break;

                        case "projectneed":
                            procedure_name = "Project_Needs_Document_Select";
                            break;
                        case "projectneedavailble":
                            procedure_name = "Need_Availble_Select";
                            break;
                        case "projectrecieve":
                            procedure_name = "Need_Recieve_Select";
                            break;

                        case "projectrecievenew":
                            procedure_name = "Need_Recieve_Select_New";
                            break;
                        case "inbox_follow":
                            procedure_name = "Inbox_Visa_Follows_Select_For_Doc";
                            break;
                        case "inbox_visa":
                            procedure_name = "Inbox_Visa_Select_For_Doc";
                            break;
                          case "com_follow":
                            procedure_name = "Commission_Visa_Follows_Select_For_Doc";
                            break;
                        case "outbox_follow":
                            procedure_name = "Outbox_Visa_Follows_Select_For_Doc";
                            break;
                      case "training":
                            procedure_name = "Course_getFiles";
                            break;
                      case "review":
                            procedure_name = "Review_Files_Select";
                            break;
                      case "review_follow":
                            procedure_name = "Review_Visa_Follows_Select_For_Doc";
                            break;
                      case "archive":
                            procedure_name = "Get_File_Archive";
                            break;
                      case "archiveupdate":
                            procedure_name = "Get_File_Archive_withupdate";
                            break;
                    }

                    if (procedure_name != "")
                    {
                        SqlCommand obj = new SqlCommand(procedure_name, con);
                        obj.CommandType = CommandType.StoredProcedure;

                        //SqlParameter objpar = new SqlParameter("Parent", 0);
                        //obj.Parameters.Add(new SqlParameter("@Parent", parentParam));
                        if (procedure_name != "Course_getFiles")
                        {
                            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"].ToString())));
                        }
                        else if (procedure_name == "Course_getFiles")
                        {
                            obj.Parameters.Add(new SqlParameter("@id", Convert.ToInt16(Request["id"].ToString())));
                            obj.Parameters.Add(new SqlParameter("@category", Convert.ToInt16(Request["category"].ToString())));
                        }
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {

                   
                        sqladptr.SelectCommand = obj;
                        DataTable DT = new DataTable();
                        sqladptr.Fill(DT);
                        string MY_File_Path = "";
                        if (Request["type"].ToString() == "work")
                            MY_File_Path = "~/Uploads/Fin/";
                        else if (Request["type"].ToString() == "deprtfile")
                            MY_File_Path = "~/Uploads/Doc/";
                        else
                            MY_File_Path = "";

                        if (DT.Rows.Count > 0)
                        {
                            if (DT.Rows[0]["File_data"] != DBNull.Value)
                            {
                                byte[] bytes = (byte[])DT.Rows[0]["File_data"];
                                Response.ContentType = "application/x-unknown";
                                string File_Name = "";
                                File_Name = DT.Rows[0]["File_name"].ToString() + DT.Rows[0]["File_ext"].ToString();
                                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name));
                                Response.BinaryWrite(bytes);
                                Response.Flush();
                                Response.Close();
                            }
                            else if (!string.IsNullOrEmpty(MY_File_Path) && !string.IsNullOrEmpty(DT.Rows[0]["File_Sytem_Name"].ToString()))
                            {
                                string New_File_Path = Server.MapPath(MY_File_Path + DT.Rows[0]["File_Sytem_Name"].ToString());

                                FileStream fs = new FileStream(New_File_Path, FileMode.Open, FileAccess.Read);

                                byte[] bytes = new byte[fs.Length];

                                fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

                                fs.Close();


                                Response.ContentType = "application/x-unknown";
                                string File_Name = "";
                                File_Name = DT.Rows[0]["File_name"].ToString() + DT.Rows[0]["File_ext"].ToString();
                                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name));
                                Response.BinaryWrite(bytes);
                                Response.Flush();
                                Response.Close();



                                //Response.Redirect("~/Uploads/Fin/" + DT.Rows[0]["File_Sytem_Name"].ToString());
                            }
                            else
                            {
                                ShowAlertMessage("   عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                            }
                        }




                        else
                        {
                            //Page.RegisterStartupScript("Sucess", "<script language=javascript>alert('لا يوجد ملف')</script>");
                        
                          Response.Redirect(Request.UrlReferrer.ToString());

                        }

                    }
                        else
                        {
                            ShowAlertMessage("   عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");

                        }


                    }
                }
                catch
                {
                   // Response.Redirect(Request.UrlReferrer.ToString());
                    ShowAlertMessage(" عفوا لم يتم الإتصال بقاعدة البيانات الداخلية");
                }
            }
        }
    }
    public static void ShowAlertMessage(string error)
    {

        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
}
