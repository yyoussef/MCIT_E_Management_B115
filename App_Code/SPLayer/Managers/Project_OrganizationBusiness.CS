// This file was automatically created by LayerGen 0.99e
// Created: 30/05/2010 01:21 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Organization Class"
	[Serializable()]
	public class Project_Organization : DBL.Project_Organization
{

#region "Constructors"

	public Project_Organization() : base()
	{
	}

	public Project_Organization(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Organization(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Organizations Class"
	[Serializable()] 
	public class Project_Organizations : CollectionBase
	{

	#region "Constructors"
		public Project_Organizations()
		{
			
		}

		public Project_Organizations(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Organization(dr));
		}   
	}

	public Project_Organization this[int index]  {
		get { return (Project_Organization)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Organization val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Organization a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Organization a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Organization.GetAll();
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
        //     DataTable dt = DBL.Project_Organization.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
