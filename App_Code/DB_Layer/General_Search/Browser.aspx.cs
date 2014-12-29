using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Resources;


namespace MCIT.Web.Data
{
	/// <summary>
	/// Summary description for Browser.
	/// </summary>
	public class Browser : System.Web.UI.Page
	{
        #region Member variables
        private bool VBIsThereMore;/*, VBIsArabic;*/
        private SortOrder VSortOrder;
        private int VNIPageRowCount, VNICurrentPage, VNIOrderField;
        private string VSTRPageTitle, VSTRQuery, VSTRCountQuery, VSTRFilter;
        private string[][] VFields;
        //private System.Resources.ResourceManager VResources;
        private DbCommand VCMDFetcher, VCMDCounter;
        private DbConnection VCONMain;
        private DataTable VPage;
        private CultureInfo VFormatter;
        //private ResourceManager VCaptions;
        DbProviderFactory VProviderFactory;
        #endregion

        private enum SortOrder: byte
        {
            Asc,
            Desc
        }

        protected override void OnLoad(EventArgs VArgs)
        {
            string VSTROperation;
            #region Get image operation
            //if((VSTROperation = this.Request.QueryString[0]) == "img")
            //{
            //    this.MLoadSessionVariables();

            //    if(this.Request.QueryString[1] == "up")
            //    {
            //        System.Drawing.Bitmap VImg = (System.Drawing.Bitmap)this.VResources.GetObject("imgUpArrow");
            //        MemoryStream VBuffer = new MemoryStream(VImg.Width * VImg.Height * 3);
            //        VImg.Save(VBuffer, System.Drawing.Imaging.ImageFormat.Bmp);
            //        this.Response.BinaryWrite(VBuffer.ToArray());
            //    }
            //    else
            //    {
            //        System.Drawing.Bitmap VImg = (System.Drawing.Bitmap)this.VResources.GetObject("imgDownArrow");
            //        MemoryStream VBuffer = new MemoryStream(VImg.Width * VImg.Height * 3);
            //        VImg.Save(VBuffer, System.Drawing.Imaging.ImageFormat.Bmp);
            //        this.Response.BinaryWrite(VBuffer.ToArray());
            //    }

            //    this.Response.End();
            //}
                #endregion

            #region Next page operation
            /*else*/
            if((VSTROperation = this.Request.QueryString[0]) == "nxt")
            {
                this.MLoadSessionVariables();

                this.Session["CrntPg"] = ++this.VNICurrentPage;
                
                if(!this.MFetchRecords())
                    return;
                this.MRenderPage();
                //this.Response.End();
            }
                #endregion

            #region Previous page operation
            else if(VSTROperation == "prv")
            {
                this.MLoadSessionVariables();

                this.Session["CrntPg"] = --this.VNICurrentPage;
                
                if(!this.MFetchRecords())
                    return;
                this.MRenderPage();
                //this.Response.End();
            }
                #endregion

            #region Filter operation
            else if(VSTROperation == "fltr")
            {
                this.MLoadSessionVariables();

                string[] VARYSTRField = this.VFields[int.Parse(this.Request.QueryString[1])];
                
                #region Add the filter parameter to the command
                switch(VARYSTRField[2])
                {
                    case "s":
                        string VSTRTemp;
                        this.Session["Fltr"] = this.VSTRFilter = " WHERE " + VARYSTRField[0] + " LIKE ? + '%'";
                        this.VCMDFetcher.Parameters.Clear();
                        this.VCMDCounter.Parameters.Clear();
                        //this.VCMDFetcher.Parameters.Add(new SqlParameter(string.Empty, VSTRTemp = this.Request.Form[0]));
                        //this.VCMDCounter.Parameters.Add(new SqlParameter(string.Empty, VSTRTemp));
                        this.VCMDCounter.CommandText += " WHERE " + VARYSTRField[0] + " LIKE  '%" + this.Request.Form[0] + "%'";
                        this.VCMDFetcher.CommandText += " WHERE " + VARYSTRField[0] + " LIKE  '%" + this.Request.Form[0] + "%'";
                        //this.VCMDFetcher.Parameters.Add("", OleDbType.VarWChar).Value = this.Request.Form[0];
                        //this.VCMDCounter.Parameters.Add("", OleDbType.VarWChar).Value = VSTRTemp;
                        break;

                    case "i":
                        long VNLTemp;
                        this.Session["Fltr"] = this.VSTRFilter = " WHERE " + VARYSTRField[0] + ' ' + this.Request.Form[1] + '?';
                        this.VCMDFetcher.Parameters.Clear();
                        this.VCMDCounter.Parameters.Clear();
                        try
                        {
                            this.VCMDFetcher.Parameters.Add(VNLTemp = long.Parse(this.Request.Form[0]));
                            this.VCMDCounter.Parameters.Add(VNLTemp);
                            //this.VCMDFetcher.Parameters.Add("", OleDbType.BigInt).Value = VNLTemp = long.Parse(this.Request.Form[0]);
                            //this.VCMDCounter.Parameters.Add("", OleDbType.BigInt).Value = VNLTemp;
                        }
                        catch
                        {
                            //cPopupMessage.MShowMessage(this, "errInvalidNumber", "ttlError", EeekSoft.Web.PopupColorStyle.Red);
                            this.Session["Fltr"] = this.VSTRFilter = "";
                        }
                        break;

                    case "d":
                        DateTime VDTemp;
                        this.Session["Fltr"] = this.VSTRFilter = " WHERE " + VARYSTRField[0] + ' ' + this.Request.Form[1] + '?';
                        this.VCMDFetcher.Parameters.Clear();
                        this.VCMDCounter.Parameters.Clear();
                        try
                        {
                            this.VCMDFetcher.Parameters.Add(VDTemp = DateTime.Parse(this.Request.Form[0], this.VFormatter.DateTimeFormat));
                            this.VCMDCounter.Parameters.Add(VDTemp);
                            //this.VCMDFetcher.Parameters.Add("", OleDbType.Date).Value = VDTemp = DateTime.Parse(this.Request.Form[0], this.VFormatter.DateTimeFormat);
                            //this.VCMDCounter.Parameters.Add("", OleDbType.Date).Value = VDTemp;
                        }
                        catch
                        {
                            //cPopupMessage.MShowMessage(this, "errInvalidDate", "ttlError", EeekSoft.Web.PopupColorStyle.Red);
                            this.Session["Fltr"] = this.VSTRFilter = "";
                        }
                        break;

                    case "f":
                        double VNDTemp;
                        this.Session["Fltr"] = this.VSTRFilter = " WHERE " + VARYSTRField[0] + ' ' + this.Request.Form[1] + '?';
                        this.VCMDFetcher.Parameters.Clear();
                        this.VCMDCounter.Parameters.Clear();
                        try
                        {
                            this.VCMDFetcher.Parameters.Add(VNDTemp = double.Parse(this.Request.Form[0], this.VFormatter.NumberFormat));
                            this.VCMDCounter.Parameters.Add(VNDTemp);
                            //this.VCMDFetcher.Parameters.Add("", OleDbType.Date).Value = VNDTemp = double.Parse(this.Request.Form[0], this.VFormatter.NumberFormat);
                            //this.VCMDCounter.Parameters.Add("", OleDbType.Date).Value = VNDTemp;
                        }
                        catch
                        {
                            //cPopupMessage.MShowMessage(this, "errInvalidNumber", "ttlError", EeekSoft.Web.PopupColorStyle.Red);
                            this.Session["Fltr"] = this.VSTRFilter = "";
                        }
                        break;
                }
                #endregion

                if(!this.MFetchRecords())
                    return;
                this.MRenderPage();
                //this.Response.End();
            }
            #endregion

            #region Order operation
            else if(VSTROperation == "ord")
            {
                this.MLoadSessionVariables();

                this.Session["OrdFld"] = this.VNIOrderField = int.Parse(this.Request.QueryString[1]);
                this.Session["OrdTp" ] = this.VSortOrder    = (this.Request.QueryString[2] == "asc")? SortOrder.Asc: SortOrder.Desc;

                if(!this.MFetchRecords())
                    return;
                this.MRenderPage();
                //this.Response.End();
            }
                #endregion

            #region Initialization operation
            else if(VSTROperation == "init")
            {
                this.RegisterStartupScript("scr", "<SCRIPT language=JavaScript>function func_Init() { var lcl_arrArgs = window.dialogArguments; var lcl_iIndex = 1; " +
                    "document.write('<FORM name=LoadParams id=LoadParams method=post action=Browser.aspx?op=ld>'); " +
                    "var lcl_iQueryLength = lcl_arrArgs[0]; var lcl_strQuery = '';" +
                    "for(; lcl_iIndex <= lcl_iQueryLength; lcl_iIndex++)lcl_strQuery += String.fromCharCode(lcl_arrArgs[lcl_iIndex]);" +
                    "document.write('<INPUT type=hidden name=Query value=\"' + lcl_strQuery + '\" />'); " +
                    "document.write('<INPUT type=hidden name=Title value=\"' + lcl_arrArgs[lcl_iIndex++] + '\" />'); document.write('<INPUT type=hidden name=RowCount value=' + lcl_arrArgs[lcl_iIndex++] + ' />'); " + 
                    "for(; lcl_iIndex < lcl_arrArgs.length; lcl_iIndex++) {" +
                    "document.write('<INPUT type=hidden name=F' + lcl_iIndex + ' value=\"' + lcl_arrArgs[lcl_iIndex][0] + \"$\" + lcl_arrArgs[lcl_iIndex][1] + \"$\" + lcl_arrArgs[lcl_iIndex][2] + \"$\" + lcl_arrArgs[lcl_iIndex][3] + '\" />');}" +
                    "document.write('</FORM>'); document.LoadParams.submit()} window.returnValue = ''; window.onload = func_Init;</SCRIPT>");
            }
                #endregion

            #region Load operation
            else if(VSTROperation == "ld")
            {
                #region Initialize the variables
                this.VPage = new DataTable();
                string VSTRTemp;
                string[][] VFields = new string[this.Request.Form.Count - 3][];
//                string[] VARYSTRTemp;
                //this.VResources = new System.Resources.ResourceManager("DF84.Resources", System.Reflection.Assembly.GetExecutingAssembly());
                #endregion

                #region Get fields data
                for(int VNIIndex = 3; VNIIndex < this.Request.Form.Count; VNIIndex++)
                {
                    VFields[VNIIndex - 3] = /*VARYSTRTemp =*/ this.Request.Form[VNIIndex].Split('$');
//                    VSTRQuery += VARYSTRTemp[0] + ',';
//                    
//                    Type VColType = null;
//                    switch(VARYSTRTemp[2])
//                    {
//                        case "s":
//                            VColType = typeof(string);
//                            break;
//
//                        case "i":
//                            VColType = typeof(long);
//                            break;
//
//                        case "d":
//                            VColType = typeof(DateTime);
//                            break;
//
//                        case "f":
//                            VColType = typeof(double);
//                            break;
//                    }
//                    this.VPage.Columns.Add(VARYSTRTemp[0], VColType);
                }
                VSTRTemp = this.Request.Form[0];
                this.VProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                DbConnection VCONTemp = VProviderFactory.CreateConnection();
                VCONTemp.ConnectionString = Database.ConnectionString;
                DbDataAdapter VDASchemaFetcher = VProviderFactory.CreateDataAdapter();
                VDASchemaFetcher.SelectCommand = VProviderFactory.CreateCommand();
                VDASchemaFetcher.SelectCommand.CommandText = VSTRTemp;
                VDASchemaFetcher.SelectCommand.Connection  = VCONTemp;

                try
                {
                    VDASchemaFetcher.FillSchema(this.VPage, SchemaType.Source);
                }
                catch
                {
                    //cPopupMessage.MShowMessage(this, "flBrowserError", "ttlFail", EeekSoft.Web.PopupColorStyle.Red);
                    return;
                }
                #endregion

                #region Configuring the formatter
                this.VFormatter = new CultureInfo("ar-EG");

                this.VFormatter.DateTimeFormat.ShortDatePattern    = "d/M/yyyy"     ;
                this.VFormatter.DateTimeFormat.FullDateTimePattern = "d/M/yyyy  m:H";

                this.VFormatter.NumberFormat.NumberDecimalDigits    = 2;
                this.VFormatter.NumberFormat.NumberGroupSeparator   = "";
                this.VFormatter.NumberFormat.NumberDecimalSeparator = ".";
                #endregion

                #region Save session variables
                this.Session["RtVl"  ] = null;
                //this.Session["Rsrc"  ] = this.VResources;
                this.Session["Cltr"  ] = this.VFormatter;
                this.Session["Tbl"   ] = this.VPage;
                this.Session["PgLen" ] = this.VNIPageRowCount = int.Parse(this.Request.Form[2]);
                this.Session["Ttl"   ] = this.VSTRPageTitle   = this.Request.Form[1];
                this.Session["Qry"   ] = this.VSTRQuery       = "SELECT * FROM(" + VSTRTemp + ")t";
                this.Session["Flds"  ] = this.VFields         = VFields;                
                this.Session["Cnctn" ] = this.VCONMain        = VCONTemp;
                this.Session["CntQry"] = this.VSTRCountQuery  = "SELECT COUNT(*) FROM(" + VSTRTemp + ")t";                
                this.Session["Fltr"  ] = this.VSTRFilter      = "";
                this.Session["CrntPg"] = this.VNICurrentPage  = 0;
                this.Session["OrdFld"] = this.VNIOrderField   = -1;
                this.Session["OrdTp" ] = this.VSortOrder      = SortOrder.Asc;
                this.Session["DBFact"] = VProviderFactory;

                this.VCMDCounter = VProviderFactory.CreateCommand();
                this.VCMDCounter.CommandText = this.VSTRCountQuery;
                this.VCMDCounter.Connection  = VCONTemp;
                this.Session["Cntr"] = this.VCMDCounter;

                this.VCMDFetcher = VProviderFactory.CreateCommand();
                this.VCMDFetcher.CommandText = VSTRQuery;
                this.VCMDFetcher.Connection  = VCONTemp ;
                this.Session["Ftchr"] = this.VCMDFetcher;
                #endregion

                if(!this.MFetchRecords())
                    return;

                this.MRenderPage();
                //this.Response.End();
            }
            #endregion

            #region Select operation
            else if(VSTROperation == "slct")
            {
                this.MLoadSessionVariables();
                
                this.Session["RtVl"] = this.VPage.Rows[int.Parse(this.Request.QueryString[1])];
                this.Session.Remove("OrdTp"  );
                this.Session.Remove("CrntPg" );
                this.Session.Remove("PgLen"  );
                this.Session.Remove("OrdFld" );
                this.Session.Remove("Fltr"   );
                this.Session.Remove("Ttl"    );
                this.Session.Remove("Qry"    );
                this.Session.Remove("CntQry" );
                this.Session.Remove("Flds"   );
                this.Session.Remove("Ftchr"  );
                this.Session.Remove("Cntr"   );
                this.Session.Remove("Cnctn"  );
                this.Session.Remove("Tbl"    );
                this.Session.Remove("Cltr"   );
                this.Session.Remove("Rsrc"   );
                this.Session.Remove("MxPgCnt");
                this.Session.Remove("DBFact" );
                this.RegisterStartupScript("scr", "<SCRIPT language=JavaScript>window.returnValue = 'v'; window.close();</SCRIPT>");
                /*int VNIColCount = this.VFields.Length;
                string VSTRRetVal = "", VSTRTemp;
                object VOBJTemp;
                DataRow VSelected = this.VPage.Rows[int.Parse(this.Request.QueryString[1])];
                for(int VNIIndex = 0; VNIIndex < VNIColCount; VNIIndex++)
                {
                    if((VOBJTemp = VSelected[VNIIndex]) == DBNull.Value)
                        VSTRRetVal += "_D$b_N$u_L$l_" + '^';

                    else
                    {
                        switch(VSTRTemp = this.VFields[VNIIndex][2])
                        {
                            case "d":
                                VSTRRetVal += ((DateTime)VOBJTemp).ToString("F", this.VFormatter.DateTimeFormat) + '^';
                                break;

                            case "f":
                                VSTRRetVal += (Convert.ToDouble(VOBJTemp).ToString("N", this.VFormatter.NumberFormat)) + '^';
                                break;

                            default:
                                VSTRRetVal += VOBJTemp.ToString() + '^';
                                break;
                        }
                    }
                }
                VSTRRetVal = VSTRRetVal.Remove(VSTRRetVal.Length - 1, 1);

                this.RegisterStartupScript("scr", "<SCRIPT language=JavaScript>window.returnValue ='" + VSTRRetVal + "'; window.close();</SCRIPT>");*/
            }
            #endregion
        }

        #region Load session variables method
        private void MLoadSessionVariables()
        {
            this.VSortOrder      = (SortOrder)this.Session["OrdTp"];

            this.VNICurrentPage  = (int)this.Session["CrntPg"];
            this.VNIPageRowCount = (int)this.Session["PgLen" ];
            this.VNIOrderField   = (int)this.Session["OrdFld"];

            this.VSTRFilter     = (string)this.Session["Fltr"  ];
            this.VSTRPageTitle  = (string)this.Session["Ttl"   ];
            this.VSTRQuery      = (string)this.Session["Qry"   ];
            this.VSTRCountQuery = (string)this.Session["CntQry"];

            this.VFields          = (string[][]       )this.Session["Flds"  ];
            this.VCMDFetcher      = (DbCommand        )this.Session["Ftchr" ];
            this.VCMDCounter      = (DbCommand        )this.Session["Cntr"  ];
            this.VCONMain         = (DbConnection     )this.Session["Cnctn" ];
            this.VProviderFactory = (DbProviderFactory)this.Session["DBFact"];
            this.VPage            = (DataTable        )this.Session["Tbl"   ];
            this.VFormatter       = (CultureInfo      )this.Session["Cltr"  ];            
            //this.VResources  = (System.Resources.ResourceManager)this.Session["Rsrc"]; 
        }
        #endregion

        private bool MFetchRecords()
        {
            #region Open the connection
            try
            {
                this.VCONMain.Open();
            }
            catch
            {
                //cPopupMessage.MShowMessage(this, "flBrowserError", "ttlFail", EeekSoft.Web.PopupColorStyle.Red);
                return false;
            }
            #endregion

            #region Get the rows count
            int VNIRecordsCount;
            //this.VCMDCounter.CommandText = this.VSTRCountQuery + this.VSTRFilter;
            //this.VCMDCounter.CommandText = "SELECT COUNT(*) FROM(SELECT [PMP_ID], [pmp_name] FROM [EMPLOYEE])t WHERE pmp_name LIKE  '%ßãÇá%'";
            try
            {
                VNIRecordsCount = Convert.ToInt32(this.VCMDCounter.ExecuteScalar());
            }
            catch
            {
                this.VCONMain.Close();
                //cPopupMessage.MShowMessage(this, "flBrowserError", "ttlFail", EeekSoft.Web.PopupColorStyle.Red);
                return false;
            }
            #endregion

            #region Adjust the command
            //if(this.VNIOrderField != -1)
            //    this.VCMDFetcher.CommandText = this.VSTRQuery + this.VSTRFilter + " ORDER BY " + this.VFields[this.VNIOrderField][0] + ((this.VSortOrder == SortOrder.Asc)? " ASC": " DESC");
            //else
            //    this.VCMDFetcher.CommandText = this.VSTRQuery + this.VSTRFilter;

           // this.VCMDFetcher.CommandText = " SELECT [PMP_ID], [pmp_name] FROM [EMPLOYEE]t WHERE pmp_name LIKE  '%ßãÇá%' ";
            #endregion

            #region Initialize the reader
            DbDataReader VFetcher = null;
            try
            {
                VFetcher = this.VCMDFetcher.ExecuteReader();
            }
            catch
            {
                try
                {
                    VFetcher.Close();
                }
                catch
                {}

                this.VCONMain.Close();
                //cPopupMessage.MShowMessage(this, "flBrowserError", "ttlFail", EeekSoft.Web.PopupColorStyle.Red);
                return false;
            }
            #endregion

            this.VPage.Clear();

            #region Adjust the current page index
            int VNIRemainder, VNIMaxPageCount;
            VNIMaxPageCount = Math.DivRem(VNIRecordsCount, this.VNIPageRowCount, out VNIRemainder);
            if(VNIRemainder > 0)
                VNIMaxPageCount++;
            this.Session["MxPgCnt"] = VNIMaxPageCount;

            if(this.VNICurrentPage >= --VNIMaxPageCount)
            {
                this.Session["CrntPg"] = this.VNICurrentPage = VNIMaxPageCount;
                this.VBIsThereMore = false;
            }
            else
                this.VBIsThereMore = true;
            #endregion

            if(!VFetcher.HasRows)
            {
                VFetcher.Close();
                this.VCONMain.Close();
                this.Session["CrntPg"] = this.VNICurrentPage = 0;
                this.VBIsThereMore = false;
                return true;
            }

            #region Advance the reader to the first record of the current page
            int VNIFirstRecordIndex = this.VNICurrentPage * this.VNIPageRowCount, VNIIndex;
            for(VNIIndex = 0; VNIIndex < VNIFirstRecordIndex; VNIIndex++)
            {
                try
                {
                    if(!VFetcher.Read())
                        throw new Exception();
                }
                catch
                {
                    try
                    {
                        VFetcher.Close();
                    }
                    catch
                    {}

                    this.VCONMain.Close();
                    //cPopupMessage.MShowMessage(this, "flBrowserError", "ttlFail", EeekSoft.Web.PopupColorStyle.Red);
                    return false;
                }
            }
            #endregion
            
            #region Fill the data table
            object[] VARYOBJTemp = new object[VFetcher.FieldCount];
            for(VNIIndex = 0; VNIIndex < this.VNIPageRowCount; VNIIndex++)
            {
                try
                {
                    if(!VFetcher.Read())
                    {
                        VFetcher.Close();
                        this.VCONMain.Close();
                        return true;
                    }
                }
                catch
                {
                    try
                    {
                        VFetcher.Close();
                    }
                    catch
                    {}

                    this.VCONMain.Close();
                    //cPopupMessage.MShowMessage(this, "flBrowserError", "ttlFail", EeekSoft.Web.PopupColorStyle.Red);
                    return false;
                }

                VFetcher.GetValues (VARYOBJTemp);
                this.VPage.Rows.Add(VARYOBJTemp);
            }
            #endregion

            VFetcher.Close();
            this.VCONMain.Close();
            return true;
        }

        private void MRenderPage()
        {
            #region Local variables
            int VNIIndex, VNIIndex2, VNIFieldCount = this.VFields.Length;
            string VSTRTemp, VSTRTemp2;
            string[] VARYSTRTemp;
            HtmlTextWriter VOutput = new HtmlTextWriter(this.Response.Output);
            object VOBJTemp;
            #endregion

            #region . HTML .
            VOutput.RenderBeginTag(HtmlTextWriterTag.Html);

            #region . HEAD .
            VOutput.RenderBeginTag(HtmlTextWriterTag.Head);

            #region . TITLE .
            VOutput.RenderBeginTag(HtmlTextWriterTag.Title);
            
            VOutput.Write(this.VSTRPageTitle);
            VOutput.RenderEndTag();
            #endregion

            VOutput.Write("<META http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1256\">");
            //VOutput.Write("<META http-equiv=\"Content-Type\" content=\"text/html; charset= UTF-8\">");
            VOutput.Write("<LINK href=\"../CSS/Search_Style.css\" type=\"text/css\" rel=\"stylesheet\">");
            VOutput.Write("<SCRIPT language=JavaScript>window.returnValue = '';</SCRIPT>");
            VOutput.RenderEndTag();
            #endregion

            #region . BODY .
            VOutput.RenderBeginTag(HtmlTextWriterTag.Body);

            #region . H1 . Page title
            VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            VOutput.RenderBeginTag(HtmlTextWriterTag.H1);
            
            VOutput.Write(this.VSTRPageTitle);
            VOutput.RenderEndTag();
            #endregion

            #region . TABLE . The grid
            VOutput.AddAttribute(HtmlTextWriterAttribute.Class, "GridSearch");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "3");
            //VOutput.AddAttribute(HtmlTextWriterAttribute.Bordercolor, "#ff9966");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Bordercolor, "#436485");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Border, "1");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            VOutput.RenderBeginTag(HtmlTextWriterTag.Table);

            #region . TR . Grid header
            VOutput.AddAttribute(HtmlTextWriterAttribute.Class, "Header");
            VOutput.RenderBeginTag(HtmlTextWriterTag.Tr);

            #region . TD . Cells
            for(VNIIndex = 0; VNIIndex < VNIFieldCount; VNIIndex++)
            {
                VARYSTRTemp = this.VFields[VNIIndex];

                VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                VOutput.AddAttribute(HtmlTextWriterAttribute.Width, VARYSTRTemp[3]);
                VOutput.RenderBeginTag(HtmlTextWriterTag.Td);
                if(this.VNIOrderField != VNIIndex)
                {
                    VOutput.AddAttribute(HtmlTextWriterAttribute.Href, "Browser.aspx?op=ord&fld=" + VNIIndex.ToString() + "&type=asc");
                    VOutput.RenderBeginTag(HtmlTextWriterTag.A);
                    VOutput.Write(VARYSTRTemp[1]);
                }
                else
                {
                    if(this.VSortOrder == SortOrder.Asc)
                    {
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Href, "Browser.aspx?op=ord&fld=" + VNIIndex.ToString() + "&type=desc");
                        VOutput.RenderBeginTag(HtmlTextWriterTag.A);
                        VOutput.Write(VARYSTRTemp[1]);
                        //VOutput.AddAttribute(HtmlTextWriterAttribute.Src, "Browser.aspx?op=img&src=up");
                        //VOutput.RenderBeginTag(HtmlTextWriterTag.Img);
                        //VOutput.RenderEndTag();
                    }
                    else
                    {
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Href, "Browser.aspx?op=ord&fld=" + VNIIndex.ToString() + "&type=asc");
                        VOutput.RenderBeginTag(HtmlTextWriterTag.A);
                        VOutput.Write(VARYSTRTemp[1]);
                        //VOutput.AddAttribute(HtmlTextWriterAttribute.Src, "Browser.aspx?op=img&src=dn");
                        //VOutput.RenderBeginTag(HtmlTextWriterTag.Img);
                        //VOutput.RenderEndTag();
                    }
                }
                VOutput.RenderEndTag();
                VOutput.RenderEndTag();
            }

            VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Width, "60");
            VOutput.RenderBeginTag(HtmlTextWriterTag.Td);
            VOutput.RenderEndTag();
            #endregion
            
            VOutput.RenderEndTag();
            #endregion

            #region . TR . Grid items
            VNIIndex2 = 0;
            foreach(DataRow VItem in this.VPage.Rows)
            {
                VOutput.AddAttribute(HtmlTextWriterAttribute.Class, "Item");
                VOutput.RenderBeginTag(HtmlTextWriterTag.Tr);

                for(VNIIndex = 0; VNIIndex < VNIFieldCount; VNIIndex++)
                {
                    VARYSTRTemp = this.VFields[VNIIndex];

                    VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                    VOutput.RenderBeginTag(HtmlTextWriterTag.Td);
                    VOBJTemp = VItem[VARYSTRTemp[0]];

                    if(VOBJTemp == DBNull.Value)
                        VOutput.Write("");
                    else
                    {
                        switch(VSTRTemp = VARYSTRTemp[2])
                        {
                            case "d":
                                VOutput.Write(((DateTime)VOBJTemp).ToString("d", this.VFormatter.DateTimeFormat));
                                break;

                            case "f":
                                VOutput.Write(Convert.ToDouble(VOBJTemp).ToString("N", this.VFormatter.NumberFormat));
                                break;

                            default:
                                VOutput.Write(VOBJTemp.ToString());
                                break;
                        }
                    }
                    VOutput.RenderEndTag();
                }

                #region The select column
                VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                VOutput.RenderBeginTag(HtmlTextWriterTag.Td);
                VOutput.AddAttribute(HtmlTextWriterAttribute.Href, "Browser.aspx?op=slct&row=" + VNIIndex2.ToString());
                VOutput.RenderBeginTag(HtmlTextWriterTag.A);
                VOutput.Write("ÅÎÊÑ");
                VOutput.RenderEndTag();
                VOutput.RenderEndTag();
                #endregion

                VOutput.RenderEndTag();

                VNIIndex2++;
            }
            #endregion

            #region . TR . Grid footer
            VOutput.AddAttribute(HtmlTextWriterAttribute.Class , "Footer");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Height, "25");
            VOutput.RenderBeginTag(HtmlTextWriterTag.Tr);

            #region . TD . Cells
            for(VNIIndex = 0; VNIIndex < VNIFieldCount; VNIIndex++)
            {
                VARYSTRTemp = this.VFields[VNIIndex];

                VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                VOutput.RenderBeginTag(HtmlTextWriterTag.Td);

                #region . FORM . Searcher
                VOutput.AddAttribute("method", "post");
                VOutput.AddAttribute("action", "Browser.aspx?op=fltr&fld=" + VNIIndex.ToString());
                VOutput.AddAttribute("name", VSTRTemp2 = "Frm_" + VARYSTRTemp[0]);
                VOutput.RenderBeginTag(HtmlTextWriterTag.Form);

                #region . INPUT . Search field
                VOutput.AddAttribute(HtmlTextWriterAttribute.Name   , "Fld_" + VARYSTRTemp[0]    );
                VOutput.AddAttribute(HtmlTextWriterAttribute.Type   , "text"                     );
                VOutput.AddAttribute(HtmlTextWriterAttribute.Onclick, "JavaScript: this.value=''");

                switch(VSTRTemp = VARYSTRTemp[2])
                {
                    case "s":
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + VARYSTRTemp[3] + "px;");
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Value, "ÈÍË ÈäÕ");
                        VOutput.RenderBeginTag(HtmlTextWriterTag.Input);
                        VOutput.RenderEndTag();
                        goto SEARCH_LINK;

                    case "i":
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + (int.Parse(VARYSTRTemp[3]) - 35).ToString() + "px;");
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Value, "ÈÍË ÑÞãí");
                        VOutput.RenderBeginTag(HtmlTextWriterTag.Input);
                        VOutput.RenderEndTag();
                        goto SEARCH_COMBO;

                    case "d":
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + (int.Parse(VARYSTRTemp[3]) - 35).ToString() + "px;");
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Value, "ÈÍË ÈÊÇÑíÎ í/Ô/Ó");
                        VOutput.RenderBeginTag(HtmlTextWriterTag.Input);
                        VOutput.RenderEndTag();
                        goto SEARCH_COMBO;

                    case "f":
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Style, "width:" + (int.Parse(VARYSTRTemp[3]) - 35).ToString() + "px;");
                        VOutput.AddAttribute(HtmlTextWriterAttribute.Value, "ÈÍË ÑÞãí");
                        VOutput.RenderBeginTag(HtmlTextWriterTag.Input);
                        VOutput.RenderEndTag();
                        goto SEARCH_COMBO;
                }
                #endregion

            SEARCH_COMBO:
                #region . SELECT . Search option combo
                VOutput.AddAttribute(HtmlTextWriterAttribute.Name , "Cmb_" + VARYSTRTemp[0]);
                VOutput.AddAttribute(HtmlTextWriterAttribute.Type , "select-one"           );
                VOutput.AddAttribute(HtmlTextWriterAttribute.Size , "1"                    );
                VOutput.AddAttribute(HtmlTextWriterAttribute.Style, "width:35px;"          );
                VOutput.RenderBeginTag(HtmlTextWriterTag.Select);

                #region . OPTION . >
                VOutput.AddAttribute(HtmlTextWriterAttribute.Value, ">");
                VOutput.RenderBeginTag(HtmlTextWriterTag.Option);
                VOutput.Write(">");
                VOutput.RenderEndTag();
                #endregion

                #region . OPTION . =
                VOutput.AddAttribute(HtmlTextWriterAttribute.Value, "=");
                VOutput.RenderBeginTag(HtmlTextWriterTag.Option);
                VOutput.Write("=");
                VOutput.RenderEndTag();
                #endregion

                #region . OPTION . <
                VOutput.AddAttribute(HtmlTextWriterAttribute.Value, "<");
                VOutput.RenderBeginTag(HtmlTextWriterTag.Option);
                VOutput.Write("<");
                VOutput.RenderEndTag();
                #endregion

                VOutput.RenderEndTag();
                #endregion

            SEARCH_LINK:
                #region . A . Search link
                VOutput.RenderBeginTag(HtmlTextWriterTag.Br);
                VOutput.RenderEndTag();
                VOutput.AddAttribute(HtmlTextWriterAttribute.Href, "JavaScript: document." + VSTRTemp2 + ".submit()");
                VOutput.RenderBeginTag(HtmlTextWriterTag.A);
                VOutput.Write("ÈÍË");
                VOutput.RenderEndTag();
                
                #endregion

                VOutput.RenderEndTag();
                #endregion

                VOutput.RenderEndTag();
            }

            VOutput.RenderBeginTag(HtmlTextWriterTag.Td);
            VOutput.RenderEndTag();
            #endregion

            VOutput.RenderEndTag();
            #endregion

            #region . TR . Grid pager
            VOutput.AddAttribute(HtmlTextWriterAttribute.Class , "Footer");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Height, "25"     );
            VOutput.RenderBeginTag(HtmlTextWriterTag.Tr);

            #region . TD . Pager cell
            VOutput.AddAttribute(HtmlTextWriterAttribute.Colspan, (VNIFieldCount + 1).ToString());
            VOutput.AddAttribute(HtmlTextWriterAttribute.Align  , "center");
            VOutput.RenderBeginTag(HtmlTextWriterTag.Td);

            #region Next link
            if(this.VBIsThereMore)
            {
                VOutput.AddAttribute(HtmlTextWriterAttribute.Href, "Browser.aspx?op=nxt");
                VOutput.RenderBeginTag(HtmlTextWriterTag.A);
            }
            else
                VOutput.RenderBeginTag(HtmlTextWriterTag.Span);

            VOutput.Write("ÇáÊÇáí");
            VOutput.RenderEndTag();
            #endregion

            #region . SPAN . Page number
            VOutput.RenderBeginTag(HtmlTextWriterTag.Span);
            if((VNIIndex = (int)this.Session["MxPgCnt"]) == 0)
                VOutput.Write("&nbsp;0/0&nbsp;");
            else
                VOutput.Write("&nbsp;" + (this.VNICurrentPage + 1).ToString() + '/' + VNIIndex.ToString() + "&nbsp;");
            VOutput.RenderEndTag();
            #endregion

            #region Previous link
            if(this.VNICurrentPage != 0)
            {
                VOutput.AddAttribute(HtmlTextWriterAttribute.Href, "Browser.aspx?op=prv");
                VOutput.RenderBeginTag(HtmlTextWriterTag.A);
            }
            else
                VOutput.RenderBeginTag(HtmlTextWriterTag.Span);

            VOutput.Write("ÇáÓÇÈÞ");
            VOutput.RenderEndTag();
            #endregion

            VOutput.RenderEndTag();
            #endregion

            VOutput.RenderEndTag();
            #endregion

            VOutput.RenderEndTag();
            #endregion

            #region . INPUT . Close button
            VOutput.RenderBeginTag(HtmlTextWriterTag.Br);
            VOutput.AddAttribute(HtmlTextWriterAttribute.Align, "center");
            VOutput.RenderBeginTag(HtmlTextWriterTag.P);
            VOutput.AddAttribute(HtmlTextWriterAttribute.Type   , "button");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Value  , "ÅÛáÇÞ");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Style  , "width:50px");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Class, "Button-Search");
            VOutput.AddAttribute(HtmlTextWriterAttribute.Onclick, "JavaScript: window.close()");
            VOutput.RenderBeginTag(HtmlTextWriterTag.Input);
            VOutput.RenderEndTag();
            VOutput.RenderEndTag();
            #endregion

            VOutput.RenderEndTag();
            #endregion

            #endregion
        }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
            //LanguageSwitcher.MSwitchThreadCulture((CultureInfo)this.Session["VCurrentCulture"]);
            //this.VCaptions  = (ResourceManager)this.Session["RCaptions" ];
            //this.VBIsArabic = (bool           )this.Session["VBIsArabic"];

			base.OnInit(e);
		}
		#endregion
	}    
}
