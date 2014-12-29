// This file was automatically created by LayerGen 0.99e
// Created: 07-Apr-10 10:27 AM

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Objective Class"
	[Serializable()]
	public class Project_Objective : DBL.Project_Objective
{

#region "Constructors"

	public Project_Objective() : base()
	{
	}

	public Project_Objective(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Objective(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Objectives Class"
	[Serializable()] 
	public class Project_Objectives : CollectionBase
	{

	#region "Constructors"
		public Project_Objectives()
		{
			
		}

		public Project_Objectives(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Objective(dr));
		}   
	}

	public Project_Objective this[int index]  {
		get { return (Project_Objective)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Objective val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Objective a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Objective a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Objective.GetAll();
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
        //     DataTable dt = DBL.Project_Objective.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
