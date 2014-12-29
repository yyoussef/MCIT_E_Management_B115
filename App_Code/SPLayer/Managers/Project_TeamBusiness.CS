// This file was automatically created by LayerGen 0.99e
// Created: 27-Apr-10 10:44 AM

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Team Class"
	[Serializable()]
	public class Project_Team : DBL.Project_Team
{

#region "Constructors"

	public Project_Team() : base()
	{
	}

	public Project_Team(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Team(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Teams Class"
	[Serializable()] 
	public class Project_Teams : CollectionBase
	{

	#region "Constructors"
		public Project_Teams()
		{
			
		}

		public Project_Teams(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Team(dr));
		}   
	}

	public Project_Team this[int index]  {
		get { return (Project_Team)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Team val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Team a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Team a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Team.GetAll();
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
        //     DataTable dt = DBL.Project_Team.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
