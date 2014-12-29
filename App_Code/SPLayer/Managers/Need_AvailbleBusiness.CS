// This file was automatically created by LayerGen 0.99e
// Created: 03/06/2010 09:59 ص

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Need_Availble Class"
	[Serializable()]
	public class Need_Availble : DBL.Need_Availble
{

#region "Constructors"

	public Need_Availble() : base()
	{
	}

	public Need_Availble(Int32 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Need_Availble(DataRow dtrRow) : base(dtrRow)
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

#region "Need_Availbles Class"
	[Serializable()] 
	public class Need_Availbles : CollectionBase
	{

	#region "Constructors"
		public Need_Availbles()
		{
			
		}

		public Need_Availbles(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Need_Availble(dr));
		}   
	}

	public Need_Availble this[int index]  {
		get { return (Need_Availble)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Need_Availble val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Need_Availble a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Need_Availble a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Need_Availble.GetAll();
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
        //     DataTable dt = DBL.Need_Availble.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
