// This file was automatically created by LayerGen 0.99e
// Created: 30/05/2010 12:06 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Organization Class"
	[Serializable()]
	public class Organization : DBL.Organization
{

#region "Constructors"

	public Organization() : base()
	{
	}

	public Organization(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Organization(DataRow dtrRow) : base(dtrRow)
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

#region "Organizations Class"
	[Serializable()] 
	public class Organizations : CollectionBase
	{

	#region "Constructors"
		public Organizations()
		{
			
		}

		public Organizations(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Organization(dr));
		}   
	}

	public Organization this[int index]  {
		get { return (Organization)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Organization val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Organization a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Organization a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Organization.GetAll();
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
        //     DataTable dt = DBL.Organization.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
