// This file was automatically created by LayerGen 0.99e
// Created: 10/03/2010 02:51 م

using System;
using System.Data;
using System.Collections;

namespace BLL
{
    #region "Users Class"
    [Serializable()]
    public class Users : DBL.Users
    {

        #region "Constructors"

        public Users()
            : base()
        {
        }

        public Users(Int64 intPrimaryKey)
            : base(intPrimaryKey)
        {
        }

        public Users(DataRow dtrRow)
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

    #region "Userss Class"
    [Serializable()]
    public class Userss : CollectionBase
    {

        #region "Constructors"
        public Userss()
        {

        }

        public Userss(DataRowCollection datarows)
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
                this.Add(new Users(dr));
            }
        }

        public Users this[int index]
        {
            get { return (Users)base.InnerList[index]; }
            set { base.InnerList[index] = value; }
        }

        public int Add(Users val)
        {
            return base.InnerList.Add(val);
        }
        #endregion

        #region "Save Function"
        public void Save()
        {
            foreach (Users a in this.InnerList)
            {
                a.Save();
            }
        }
        #endregion

        #region "Rollback Function"
        public void Rollback()
        {
            foreach (Users a in this.InnerList)
            {
                a.Rollback();
            }
        }
        #endregion

        public void GetAll()
        {
            DataTable dt = DBL.Users.GetAll();
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
        //     DataTable dt = DBL.Users.GetByFirstName(FirstName);
        //     if ((dt != null)) {
        //         this.Load(dt.Rows);
        //     }
        // }
        //
        #endregion

    }
    #endregion
}
