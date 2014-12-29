// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Distrebition Class"
	[Serializable()]
	public class Project_Distrebition : DBL.Project_Distrebition
{

#region "Constructors"

	public Project_Distrebition() : base()
	{
	}

	public Project_Distrebition(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Distrebition(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Distrebitions Class"
	[Serializable()] 
	public class Project_Distrebitions : CollectionBase
	{

	#region "Constructors"
		public Project_Distrebitions()
		{
			
		}

		public Project_Distrebitions(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Distrebition(dr));
		}   
	}

	public Project_Distrebition this[int index]  {
		get { return (Project_Distrebition)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Distrebition val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Distrebition a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Distrebition a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Distrebition.GetAll();
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
        //     DataTable dt = DBL.Project_Distrebition.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
