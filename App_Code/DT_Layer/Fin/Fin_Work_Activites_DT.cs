using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Fin_Work_Activites_DT
/// </summary>
public class Fin_Work_Activites_DT
{
	 public enum EnumInfo_Work_Activites
        {
            Work_Act_ID, Work_Order_ID, PActv_ID, 
        }

        
		/// <summary>
		/// 
		/// </summary>
		protected Int32 mWork_Act_ID;
		public Int32 Work_Act_ID
		{
			get
			{
				return mWork_Act_ID;
			}
			set
			{
				mWork_Act_ID = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected Int32 mWork_Order_ID;
		public Int32 Work_Order_ID
		{
			get
			{
				return mWork_Order_ID;
			}
			set
			{
				mWork_Order_ID = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected Int32 mPActv_ID;
		public Int32 PActv_ID
		{
			get
			{
				return mPActv_ID;
			}
			set
			{
				mPActv_ID = value;
			}
		}
		
    }

