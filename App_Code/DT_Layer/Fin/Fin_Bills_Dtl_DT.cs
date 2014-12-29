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
/// Summary description for Fin_Bills_Dtl_DT
/// </summary>
public class Fin_Bills_Dtl_DT
{
	 public enum EnumInfo_Bills_Dtl
        {
            Bil_Dtl_ID, Bil_ID, PActv_ID, Quantity, unit_value, Total_Value, Notes, 
        }

        
		/// <summary>
		/// 
		/// </summary>
		protected Int32 mBil_Dtl_ID;
		public Int32 Bil_Dtl_ID
		{
			get
			{
				return mBil_Dtl_ID;
			}
			set
			{
				mBil_Dtl_ID = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected Int32 mBil_ID;
		public Int32 Bil_ID
		{
			get
			{
				return mBil_ID;
			}
			set
			{
				mBil_ID = value;
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
		
		/// <summary>
		/// 
		/// </summary>
		protected Int32 mQuantity;
		public Int32 Quantity
		{
			get
			{
				return mQuantity;
			}
			set
			{
				mQuantity = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected Decimal munit_value;
		public Decimal unit_value
		{
			get
			{
				return munit_value;
			}
			set
			{
				munit_value = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected Decimal mTotal_Value;
		public Decimal Total_Value
		{
			get
			{
				return mTotal_Value;
			}
			set
			{
				mTotal_Value = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		protected String mNotes;
		public String Notes
		{
			get
			{
				return mNotes;
			}
			set
			{
				mNotes = value;
			}
		}
		
    }
