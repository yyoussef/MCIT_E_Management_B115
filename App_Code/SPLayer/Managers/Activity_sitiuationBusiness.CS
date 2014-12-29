// This file was automatically created by LayerGen 0.99e
// Created: 12-May-10 3:50 PM

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Activity_sitiuation Class"
	[Serializable()]
	public class Activity_sitiuation : DBL.Activity_sitiuation
{

#region "Constructors"

	public Activity_sitiuation() : base()
	{
	}

	public Activity_sitiuation(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Activity_sitiuation(DataRow dtrRow) : base(dtrRow)
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

#region "Activity_sitiuations Class"
	[Serializable()] 
	public class Activity_sitiuations : CollectionBase
	{

	#region "Constructors"
		public Activity_sitiuations()
		{
			
		}

		public Activity_sitiuations(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Activity_sitiuation(dr));
		}   
	}

	public Activity_sitiuation this[int index]  {
		get { return (Activity_sitiuation)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Activity_sitiuation val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Activity_sitiuation a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Activity_sitiuation a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Activity_sitiuation.GetAll();
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
        //     DataTable dt = DBL.Activity_sitiuation.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
