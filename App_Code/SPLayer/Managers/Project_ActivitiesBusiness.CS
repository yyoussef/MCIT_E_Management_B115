// This file was automatically created by LayerGen 0.99e
// Created: 12-May-10 3:42 PM

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Activities Class"
	[Serializable()]
	public class Project_Activities : DBL.Project_Activities
{

#region "Constructors"

	public Project_Activities() : base()
	{
	}

	public Project_Activities(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Activities(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Activitiess Class"
	[Serializable()] 
	public class Project_Activitiess : CollectionBase
	{

	#region "Constructors"
		public Project_Activitiess()
		{
			
		}

		public Project_Activitiess(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Activities(dr));
		}   
	}

	public Project_Activities this[int index]  {
		get { return (Project_Activities)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Activities val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Activities a in this.InnerList) {
			a.Save();
         
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Activities a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Activities.GetAll();
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
        //     DataTable dt = DBL.Project_Activities.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
