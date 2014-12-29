using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace MCIT.Web.Data
{
    public enum BrowserFieldType
    {
        NIDate   ,
        NIFloat  ,
        NIInteger,
        NIString
    }

    public class BrowseDataEventArgs: EventArgs
    {
        public static explicit operator DataRow(BrowseDataEventArgs VThis)
        {
            return VThis.VDRBrowseValues;
        }

        //private object[] VARYOBJBrowseValues;
        private DataRow VDRBrowseValues;

        /*public BrowseDataEventArgs(object[] VARYOBJBrowseValues)
            {
                this.VARYOBJBrowseValues = VARYOBJBrowseValues;
            }*/

        public BrowseDataEventArgs(DataRow VDRBrowseValues)
        {
            this.VDRBrowseValues = VDRBrowseValues;
        }

        public object this[int VNIIndex]
        {
            get
            {
                return this.VDRBrowseValues[VNIIndex];
            }
        }

        public object this[string VSTRColName]
        {
            get
            {
                return this.VDRBrowseValues[VSTRColName];
            }
        }
    }

    public delegate void BrowseDataEventHandler(object VOBJSender, BrowseDataEventArgs VArgs);

    public class cBrowser: Control, IPostBackDataHandler
    {
        #region Fields
        private int VNIPageRowCount;
        private string VSTRBrowseData, VSTRTitle, VSTRSqlQuery;
        private ArrayList VFields;
        private static CultureInfo VFormatter;
        #endregion

        public event BrowseDataEventHandler BrowseData;

        #region Constructor
        static cBrowser()
        {
            cBrowser.VFormatter = new CultureInfo("ar-EG");
            cBrowser.VFormatter.DateTimeFormat.ShortDatePattern    = "d/M/yyyy"     ;
            cBrowser.VFormatter.DateTimeFormat.FullDateTimePattern = "d/M/yyyy  m:H";

            cBrowser.VFormatter.NumberFormat.NumberDecimalDigits    = 2;
            cBrowser.VFormatter.NumberFormat.NumberGroupSeparator   = "";
            cBrowser.VFormatter.NumberFormat.NumberDecimalSeparator = ".";
        }
        /// <summary>
        /// take object of cBrowser
        /// </summary>
        /// <param name="VParent">this page</param>
        /// <param name="VSTRSqlQuery">query to be selected</param>
        /// <param name="VSTRTitle">the title of page </param>
        /// <param name="VNIPageRowCount">number of row to be shown in grid</param>
        public cBrowser(Page VParent, string VSTRSqlQuery, string VSTRTitle, int VNIPageRowCount)
        {
            if (VParent.Form != null)
            {
                this.VSTRTitle = VSTRTitle;
                this.VNIPageRowCount = VNIPageRowCount;
                this.VFields = new ArrayList(2);
                this.VSTRSqlQuery = VSTRSqlQuery;
                //this.Title = VSTRTitle;

                //foreach(Control VChild in VParent.Controls)
                //{
                //    if(VChild.GetType() == typeof(HtmlForm))
                //    {
                //        VChild.Controls.Add(this);
                //        return;
                //    }
                //}
                VParent.Form.Controls.Add(this);
            }
            //VParent.Controls.Add(this);
        }
        #endregion

        #region Properties
        public int PageRowCount
        {
            get
            {
                return this.VNIPageRowCount;
            }

            set
            {
                this.VNIPageRowCount = value;
            }
        }

        public string Title
        {
            get
            {
                return this.VSTRTitle;
            }

            set
            {
                this.VSTRTitle = value;
            }
        }

        public string SqlQuery
        {
            get
            {
                return this.VSTRSqlQuery;
            }
            set
            {
                this.VSTRSqlQuery = value;
            }
        }

        public string ClientSideFunction
        {
            get
            {
                return "func_Browse_" + this.UniqueID + "();";
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// add fields data to our object
        /// </summary>
        /// <param name="VSTRName">Filed name as database</param>
        /// <param name="VSTRTitle">name that will diaplay in grid</param>
        /// <param name="VNIColumnWidth">widht colum in grid</param>
        /// <param name="VType"> Field type </param>
        public void MAddField(string VSTRName, string VSTRTitle, int VNIColumnWidth, BrowserFieldType VType)
        {
            this.VFields.Add(new cBrowserField(VSTRName, VSTRTitle, VNIColumnWidth, VType));
        }

        public void MClear()
        {
            this.VFields.Clear();
        }

        #region IPostBackDataHandler Members
        public void RaisePostDataChangedEvent()
        {
            if(this.BrowseData != null)
            {
                this.BrowseData(this, new BrowseDataEventArgs((DataRow)this.Page.Session["RtVl"]));
                //this.Page.Session.Remove("RtVl");
                /*string   VSTRTemp;
                    string[] VARYSTRBrowseData = this.VSTRBrowseData.Split('^');
                    object[] VARYOBJBrowseData = new object[VARYSTRBrowseData.Length];

                    for(int VNIIndex = 0; VNIIndex < this.VFields.Count; VNIIndex++)
                    {
                        BrowserFieldType VFieldType = (BrowserFieldType)((cBrowserField)this.VFields[VNIIndex]).VType;
                    
                        if((VSTRTemp = VARYSTRBrowseData[VNIIndex]) == "_D$b_N$u_L$l_")
                            VARYOBJBrowseData[VNIIndex] = DBNull.Value;
                        else
                        {
                            switch(VFieldType)
                            {
                                case BrowserFieldType.NIString:
                                    VARYOBJBrowseData[VNIIndex] = VSTRTemp;
                                    break;

                                case BrowserFieldType.NIDate:
                                    VARYOBJBrowseData[VNIIndex] = Convert.ToDateTime(VSTRTemp, cBrowser.VFormatter.DateTimeFormat);
                                    break;
                           
                                case BrowserFieldType.NIInteger:
                                    VARYOBJBrowseData[VNIIndex] = Convert.ToInt64(VSTRTemp);
                                    break;

                                case BrowserFieldType.NIFloat:
                                    VARYOBJBrowseData[VNIIndex] = Convert.ToDouble(VSTRTemp, cBrowser.VFormatter.NumberFormat);
                                    break;
                            }
                        }
                    }
                    this.BrowseData(this, new BrowseDataEventArgs(VARYOBJBrowseData));*/
            }
        }

        public bool LoadPostData(string VPostDataKey, System.Collections.Specialized.NameValueCollection VPostCollection)
        {
            if((this.VSTRBrowseData = VPostCollection[VPostDataKey]) != "")
                return true;

            return false;
        }
        #endregion
        #endregion

        protected override void Render(HtmlTextWriter VWriter)
        {
            #region HTML rendering
            VWriter.AddAttribute(HtmlTextWriterAttribute.Name , this.UniqueID);
            VWriter.AddAttribute(HtmlTextWriterAttribute.Type , "hidden"     );
            VWriter.AddAttribute(HtmlTextWriterAttribute.Value, ""           );
            
            VWriter.RenderBeginTag(HtmlTextWriterTag.Input);
            VWriter.RenderEndTag();
            #endregion

            #region JavaScript rendering
            int VNIColumnsWidth = 0;
            string VSTRScript = "<SCRIPT language=JavaScript>function func_Browse_" + this.UniqueID + "(){ var lcl_arrBrowserData = new Array(" + this.VSTRSqlQuery.Length.ToString() + ", ";

            foreach(char VCElement in this.VSTRSqlQuery)
                VSTRScript += ((short)VCElement).ToString() + ", ";

            VSTRScript += '\'' + this.VSTRTitle + "', " + this.VNIPageRowCount.ToString() + ", ";

            if(this.VFields.Count != 0)
            {
                IEnumerator VIndex = this.VFields.GetEnumerator();
                VIndex.MoveNext();

                while(true)
                {
                    cBrowserField VItem = (cBrowserField)VIndex.Current;
                    char VCType = '\0';
                    switch(VItem.VType)
                    {
                        case BrowserFieldType.NIString:
                            VCType = 's';
                            break;

                        case BrowserFieldType.NIInteger:
                            VCType = 'i';
                            break;

                        case BrowserFieldType.NIDate:
                            VCType = 'd';
                            break;

                        case BrowserFieldType.NIFloat:
                            VCType = 'f';
                            break;
                    }

                    VNIColumnsWidth += VItem.VNIWidth;
                    VSTRScript += "new Array('" + VItem.VSTRName + "', '" + VItem.VSTRTitle + "', '" + VCType + "', " + VItem.VNIWidth.ToString() + ')';

                    if(!VIndex.MoveNext())
                        break;
                    VSTRScript += ", ";
                }
            }
            else
                VSTRScript += "new Array()";

            PostBackOptions VPostBackOptions = new PostBackOptions(this);
            VPostBackOptions.RequiresJavaScriptProtocol = false;
            VPostBackOptions.PerformValidation = false;
            VSTRScript += "); var lcl_RetVal = window.showModalDialog('Browser.html', lcl_arrBrowserData, 'dialogHeight:" + (this.VNIPageRowCount * 25 + 360).ToString() + "px;dialogWidth:" + (VNIColumnsWidth + 100).ToString() + "px;center:yes;edge:sunken;help:no;resizable:no;scroll:yes;status:no'); if(lcl_RetVal != ''){document." + this.Parent.UniqueID + '.' + this.UniqueID + ".value = lcl_RetVal; " + this.Page.ClientScript.GetPostBackEventReference(VPostBackOptions) + ";}}";
            //VSTRScript += "); var lcl_RetVal = window.showModalDialog('Browser.html', lcl_arrBrowserData, 'dialogHeight:" + (this.VNIPageRowCount * 25 + 360).ToString() + "px;dialogWidth:" + (VNIColumnsWidth + 100).ToString() + "px;center:yes;edge:sunken;help:no;resizable:no;scroll:yes;status:no'); if(lcl_RetVal != ''){document." + this.Parent.UniqueID + '.' + this.UniqueID + ".value = lcl_RetVal; document." + this.Parent.UniqueID + ".submit();}}";
            //VSTRScript += "); var lcl_RetVal = window.showModalDialog('Browser.html', lcl_arrBrowserData, 'dialogHeight:" + (this.VNIPageRowCount * 25 + 360).ToString() + "px;dialogWidth:" + (VNIColumnsWidth + 100).ToString() + "px;center:yes;edge:sunken;help:no;resizable:no;scroll:yes;status:no'); if(lcl_RetVal != ''){document." + this.Parent.UniqueID + '.' + this.UniqueID + ".value = lcl_RetVal; document." + this.Parent.UniqueID + ".submit()}}";

            this.Page.RegisterStartupScript("scr_" + this.UniqueID, VSTRScript + "</SCRIPT>");
            #endregion
        }

        private class cBrowserField
        {
            internal string           VSTRName ;
            internal string           VSTRTitle;
            internal BrowserFieldType VType    ;
            internal int              VNIWidth ;

            internal cBrowserField(string VSTRName, string VSTRTitle, int VNIWidth, BrowserFieldType VType)
            {
                this.VSTRName  = VSTRName ;
                this.VSTRTitle = VSTRTitle;
                this.VNIWidth  = VNIWidth ;
                this.VType     = VType    ;
            }
        }
    }
}