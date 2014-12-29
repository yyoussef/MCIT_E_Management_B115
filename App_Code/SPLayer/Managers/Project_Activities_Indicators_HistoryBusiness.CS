// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Activities_Indicators_History Class"
	[Serializable()]
	public class Project_Activities_Indicators_History : DBL.Project_Activities_Indicators_History
{

#region "Constructors"

	public Project_Activities_Indicators_History() : base()
	{
	}

	public Project_Activities_Indicators_History(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Activities_Indicators_History(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Activities_Indicators_Historys Class"
	[Serializable()] 
	public class Project_Activities_Indicators_Historys : CollectionBase
	{

	#region "Constructors"
		public Project_Activities_Indicators_Historys()
		{
			
		}

		public Project_Activities_Indicators_Historys(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Activities_Indicators_History(dr));
		}   
	}

	public Project_Activities_Indicators_History this[int index]  {
		get { return (Project_Activities_Indicators_History)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Activities_Indicators_History val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Activities_Indicators_History a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Activities_Indicators_History a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Activities_Indicators_History.GetAll();
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
        //     DataTable dt = DBL.Project_Activities_Indicators_History.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
