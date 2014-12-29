// This file was automatically created by LayerGen 0.99e
// Created: 03/06/2010 08:16 ص

using System;
using System.Data;
using System.Collections;

namespace BLL
{
#region "Need_Recieve Class"
	[Serializable()]
	public class Need_Recieve : DBL.Need_Recieve
{

#region "Constructors"

	public Need_Recieve() : base()
	{
	}

	public Need_Recieve(Int64 intPrimaryKey) : base(intPrimaryKey)
	{
	}

	public Need_Recieve(DataRow dtrRow) : base(dtrRow)
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

#region "Need_Recieves Class"
	[Serializable()] 
	public class Need_Recieves : CollectionBase
	{

	#region "Constructors"
		public Need_Recieves()
		{
			
		}

		public Need_Recieves(DataRowCollection datarows) : this()
		{
			this.Load(datarows);
		}
	#endregion

#region "Member Functions"
	protected void Load(DataRowCollection dataRows)
	{
		foreach (DataRow dr in dataRows) {
			this.Add(new Need_Recieve(dr));
		}   
	}

	public Need_Recieve this[int index]  {
		get { return (Need_Recieve)base.InnerList[index]; }
		set { base.InnerList[index] = value; }
	}

	public int Add(Need_Recieve val)
	{
		return base.InnerList.Add(val);
	}
#endregion

#region "Save Function"
	public void Save()
	{
		foreach (Need_Recieve a in this.InnerList) {
			a.Save();
		}
	}
#endregion

#region "Rollback Function"
	public void Rollback()
	{
		foreach (Need_Recieve a in this.InnerList) {
			a.Rollback();
		}
	}
#endregion

         public void GetAll()
         {
             DataTable dt = DBL.Need_Recieve.GetAll();
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
        //     DataTable dt = DBL.Need_Recieve.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
#endregion

	}
#endregion
}
