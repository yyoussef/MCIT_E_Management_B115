// This file was automatically created by LayerGen 0.99e
// Created: 14/03/2010 03:35 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
    #region "Project Class"
    [Serializable()]
    public class Project : DBL.Project
    {

        #region "Constructors"

        public Project()
            : base()
        {
        }

        public Project(Int64 intPrimaryKey)
            : base(intPrimaryKey)
        {
        }

        public Project(DataRow dtrRow)
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

    #region "Projects Class"
    [Serializable()]
    public class Projects : CollectionBase
    {

        #region "Constructors"
        public Projects()
        {

        }

        public Projects(DataRowCollection datarows)
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
                this.Add(new Project(dr));
            }
        }

        public Project this[int index]
        {
            get { return (Project)base.InnerList[index]; }
            set { base.InnerList[index] = value; }
        }

        public int Add(Project val)
        {
            return base.InnerList.Add(val);
        }
        #endregion

        #region "Save Function"
        public void Save()
        {
            foreach (Project a in this.InnerList)
            {
                a.Save();
            }
        }
        #endregion

        #region "Rollback Function"
        public void Rollback()
        {
            foreach (Project a in this.InnerList)
            {
                a.Rollback();
            }
        }
        #endregion

        public void GetAll()
        {
            DataTable dt = DBL.Project.GetAll();
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
        //     DataTable dt = DBL.Project.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
        #endregion

    }
    #endregion
}
