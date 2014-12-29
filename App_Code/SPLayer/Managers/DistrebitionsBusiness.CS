// This file was automatically created by LayerGen 0.99e
// Created: 02/03/2010 04:12 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
    #region "Distrebitions Class"
    [Serializable()]
    public class Distrebitions : DBL.Distrebitions
    {

        #region "Constructors"

        public Distrebitions()
            : base()
        {
        }

        public Distrebitions(Int64 intPrimaryKey)
            : base(intPrimaryKey)
        {
        }

        public Distrebitions(DataRow dtrRow)
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

    #region "Distrebitionss Class"
    [Serializable()]
    public class Distrebitionss : CollectionBase
    {

        #region "Constructors"
        public Distrebitionss()
        {

        }

        public Distrebitionss(DataRowCollection datarows)
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
                this.Add(new Distrebitions(dr));
            }
        }

        public Distrebitions this[int index]
        {
            get { return (Distrebitions)base.InnerList[index]; }
            set { base.InnerList[index] = value; }
        }

        public int Add(Distrebitions val)
        {
            return base.InnerList.Add(val);
        }
        #endregion

        #region "Save Function"
        public void Save()
        {
            foreach (Distrebitions a in this.InnerList)
            {
                a.Save();
            }
        }
        #endregion

        #region "Rollback Function"
        public void Rollback()
        {
            foreach (Distrebitions a in this.InnerList)
            {
                a.Rollback();
            }
        }
        #endregion

        public void GetAll()
        {
            DataTable dt = DBL.Distrebitions.GetAll();
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
        //     DataTable dt = DBL.Distrebitions.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
        #endregion

    }
    #endregion
}
