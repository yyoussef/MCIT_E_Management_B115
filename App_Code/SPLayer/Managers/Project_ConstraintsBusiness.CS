// This file was automatically created by LayerGen 0.99e
// Created: 27/04/2010 01:51 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Constraints Class"
	[Serializable()]
	public class Project_Constraints : DBL.Project_Constraints
{

#region "Constructors"

	public Project_Constraints() : base()
	{
	}

	public Project_Constraints(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Constraints(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Constraintss Class"
	[Serializable()] 
	public class Project_Constraintss : CollectionBase
	{

	#region "Constructors"
		public Project_Constraintss()
		{
			
		}

		public Project_Constraintss(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Constraints(dr));
		}   
	}

	public Project_Constraints this[int index]  {
		get { return (Project_Constraints)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Constraints val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Constraints a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Constraints a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Constraints.GetAll();
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
        //     DataTable dt = DBL.Project_Constraints.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
