// This file was automatically created by LayerGen 0.99e
// Created: 16-May-10 11:52 AM

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Project_Activities_Indicators Class"
	[Serializable()]
	public class Project_Activities_Indicators : DBL.Project_Activities_Indicators
{

#region "Constructors"

	public Project_Activities_Indicators() : base()
	{
	}

	public Project_Activities_Indicators(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Project_Activities_Indicators(DataRow dtrRow) : base(dtrRow)
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

#region "Project_Activities_Indicatorss Class"
	[Serializable()] 
	public class Project_Activities_Indicatorss : CollectionBase
	{

	#region "Constructors"
		public Project_Activities_Indicatorss()
		{
			
		}

		public Project_Activities_Indicatorss(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Project_Activities_Indicators(dr));
		}   
	}

	public Project_Activities_Indicators this[int index]  {
		get { return (Project_Activities_Indicators)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Project_Activities_Indicators val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Project_Activities_Indicators a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Project_Activities_Indicators a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Project_Activities_Indicators.GetAll();
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
        //     DataTable dt = DBL.Project_Activities_Indicators.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
