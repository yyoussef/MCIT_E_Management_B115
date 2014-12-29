using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>

    public class HierarchyTrees : List<HierarchyTrees.HTree>
    {
        public class HTree
        {
            private string m_NodeDescription;
            private int m_UnderParent;
            private int m_LevelDepth;
            private int m_NodeID;

            public int NodeID
            {
                get { return m_NodeID; }
                set { m_NodeID = value; }
            }

            public string NodeDescription
            {
                get { return m_NodeDescription; }
                set { m_NodeDescription = value; }
            }
            public int UnderParent
            {
                get { return m_UnderParent; }
                set { m_UnderParent = value; }
            }
            public int LevelDepth
            {
                get { return m_LevelDepth; }
                set { m_LevelDepth = value; }
            }
        }
    }  

