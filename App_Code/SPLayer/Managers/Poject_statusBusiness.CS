// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Poject_status Class"
	[Serializable()]
	public class Poject_status : DBL.Poject_status
{

#region "Constructors"

	public Poject_status() : base()
	{
	}

	public Poject_status(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Poject_status(DataRow dtrRow) : base(dtrRow)
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

#region "Poject_statuss Class"
	[Serializable()] 
	public class Poject_statuss : CollectionBase
	{

	#region "Constructors"
		public Poject_statuss()
		{
			
		}

		public Poject_statuss(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Poject_status(dr));
		}   
	}

	public Poject_status this[int index]  {
		get { return (Poject_status)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Poject_status val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Poject_status a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Poject_status a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Poject_status.GetAll();
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
        //     DataTable dt = DBL.Poject_status.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
