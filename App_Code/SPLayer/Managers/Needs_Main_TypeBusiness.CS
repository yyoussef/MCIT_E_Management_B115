// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Needs_Main_Type Class"
	[Serializable()]
	public class Needs_Main_Type : DBL.Needs_Main_Type
{

#region "Constructors"

	public Needs_Main_Type() : base()
	{
	}

	public Needs_Main_Type(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Needs_Main_Type(DataRow dtrRow) : base(dtrRow)
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

#region "Needs_Main_Types Class"
	[Serializable()] 
	public class Needs_Main_Types : CollectionBase
	{

	#region "Constructors"
		public Needs_Main_Types()
		{
			
		}

		public Needs_Main_Types(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Needs_Main_Type(dr));
		}   
	}

	public Needs_Main_Type this[int index]  {
		get { return (Needs_Main_Type)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Needs_Main_Type val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Needs_Main_Type a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Needs_Main_Type a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Needs_Main_Type.GetAll();
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
        //     DataTable dt = DBL.Needs_Main_Type.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
