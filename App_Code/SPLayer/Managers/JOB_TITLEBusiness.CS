// This file was automatically created by LayerGen 0.99e
// Created: 24/05/2010 02:07 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "JOB_TITLE Class"
	[Serializable()]
	public class JOB_TITLE : DBL.JOB_TITLE
{

#region "Constructors"

	public JOB_TITLE() : base()
	{
	}

	public JOB_TITLE(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public JOB_TITLE(DataRow dtrRow) : base(dtrRow)
	{
	}

#endregion

#region "Interface Implementation"
	public void Rollback()
	{
	}

	public void Validate()
	{
		// TODO: Write your own validation code
	}
#endregion
	}
#endregion

#region "JOB_TITLEs Class"
	[Serializable()] 
	public class JOB_TITLEs : CollectionBase
	{

	#region "Constructors"
		public JOB_TITLEs()
		{
			
		}

		public JOB_TITLEs(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new JOB_TITLE(dr));
		}   
	}

	public JOB_TITLE this[int index]  {
		get { return (JOB_TITLE)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(JOB_TITLE val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (JOB_TITLE a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (JOB_TITLE a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.JOB_TITLE.GetAll();
             if ((dt != null)) {
                 this.Load(dt.Rows);
             }
         }
        
#region "Custom Query Methods"
        // TODO: Add your own custom Query Methods
        // I have provided an example to show you how easy
        // it is to add your own custom query. Don't forget
        // to add your query method to the Data layer too
        //
        // public void GetByFirstName(string FirstName)
        // {
        //     DataTable dt = DBL.JOB_TITLE.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
