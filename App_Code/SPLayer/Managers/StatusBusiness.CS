// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Status Class"
	[Serializable()]
	public class Status : DBL.Status
{

#region "Constructors"

	public Status() : base()
	{
	}

	public Status(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Status(DataRow dtrRow) : base(dtrRow)
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

#region "Statuss Class"
	[Serializable()] 
	public class Statuss : CollectionBase
	{

	#region "Constructors"
		public Statuss()
		{
			
		}

		public Statuss(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Status(dr));
		}   
	}

	public Status this[int index]  {
		get { return (Status)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Status val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Status a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Status a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Status.GetAll();
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
        //     DataTable dt = DBL.Status.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
