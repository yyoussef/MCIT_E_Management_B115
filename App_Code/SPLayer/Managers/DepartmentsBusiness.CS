// This file was automatically created by LayerGen 0.99e
// Created: 07/04/2010 01:09 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
    #region "Departments Class"
    [Serializable()]
    public class Departments : DBL.Departments
    {

        #region "Constructors"

        public Departments()
            : base()
        {
        }

        public Departments(Int64 intPrimaryKey)
            : base(intPrimaryKey)
        {
        }

        public Departments(DataRow dtrRow)
            : base(dtrRow)
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

    #region "Departmentss Class"
    [Serializable()]
    public class Departmentss : CollectionBase
    {

        #region "Constructors"
        public Departmentss()
        {

        }

        public Departmentss(DataRowCollection datarows)
            : this()
        {
            this.Load(datarows);
        }
        #endregion

        #region "Member Functions"
        protected void Load(DataRowCollection dataRows)
        {
            foreach (DataRow dr in dataRows)
            {
                this.Add(new Departments(dr));
            }
        }

        public Departments this[int index]
        {
            get { return (Departments)base.InnerList[index]; }
            set { base.InnerList[index] = value; }
        }

        public int Add(Departments val)
        {
            return base.InnerList.Add(val);
        }
        #endregion

        #region "Save Function"
        public void Save()
        {
            foreach (Departments a in this.InnerList)
            {
                a.Save();
            }
        }
        #endregion

        #region "Rollback Function"
        public void Rollback()
        {
            foreach (Departments a in this.InnerList)
            {
                a.Rollback();
            }
        }
        #endregion

        public void GetAll()
        {
            DataTable dt = DBL.Departments.GetAll();
            if ((dt != null))
            {
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
        //     DataTable dt = DBL.Departments.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
        #endregion

    }
    #endregion
}
