// This file was automatically created by LayerGen 0.99e
// Created: 01-Apr-10 10:21 AM

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "EMPLOYEE Class"
	[Serializable()]
	public class EMPLOYEE : DBL.EMPLOYEE
{

#region "Constructors"

	public EMPLOYEE() : base()
	{
	}

	public EMPLOYEE(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public EMPLOYEE(DataRow dtrRow) : base(dtrRow)
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

#region "EMPLOYEEs Class"
	[Serializable()] 
	public class EMPLOYEEs : CollectionBase
	{

	#region "Constructors"
		public EMPLOYEEs()
		{
			
		}

		public EMPLOYEEs(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new EMPLOYEE(dr));
		}   
	}

	public EMPLOYEE this[int index]  {
		get { return (EMPLOYEE)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(EMPLOYEE val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (EMPLOYEE a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (EMPLOYEE a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.EMPLOYEE.GetAll();
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
        //     DataTable dt = DBL.EMPLOYEE.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
