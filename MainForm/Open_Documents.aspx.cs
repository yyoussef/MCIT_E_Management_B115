using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

public partial class WebForms_Open_Documents : System.Web.UI.Page
{
    Session_CS Session_CS = new Session_CS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "inline");

            System.IO.MemoryStream MemStream = new System.IO.MemoryStream();
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            iTextSharp.text.pdf.PdfReader reader;
            int numberOfPages;
            int currentPageNumber;

            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, MemStream);
            doc.Open();
            iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;

            iTextSharp.text.pdf.PdfImportedPage page;
            int rotation;
            DataTable dt = LoadX();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["File_ext"].ToString().ToLower().Contains("pdf"))
                {
                    if (dt.Rows[0]["File_data"] != DBNull.Value)
                    {
                        byte[] bytes = (byte[])dt.Rows[i]["File_data"];
                        reader = new iTextSharp.text.pdf.PdfReader(bytes);
                        numberOfPages = reader.NumberOfPages;
                        currentPageNumber = 0;

                        do
                        {
                            currentPageNumber += 1;
                            //doc.SetPageSize(PageSize.LETTER);
                            doc.NewPage();
                            page = writer.GetImportedPage(reader, currentPageNumber);
                            rotation = reader.GetPageRotation(currentPageNumber);
                            if (rotation == 90 || rotation == 270)
                                cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(currentPageNumber).Height);
                            else
                                cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0);
                        }
                        while (currentPageNumber < numberOfPages);
                    }
                    else if (!string.IsNullOrEmpty(dt.Rows[0]["File_Sytem_Name"].ToString()))
                    {
                        string MY_File_Path = "";
                        MY_File_Path = "~/Uploads/Doc/";
                        string New_File_Path = Server.MapPath(MY_File_Path + dt.Rows[0]["File_Sytem_Name"].ToString());

                        FileStream fs = new FileStream(New_File_Path, FileMode.Open, FileAccess.Read);

                        byte[] bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));

                        fs.Close();

                        reader = new iTextSharp.text.pdf.PdfReader(bytes);
                        numberOfPages = reader.NumberOfPages;
                        currentPageNumber = 0;

                        do
                        {
                            currentPageNumber += 1;
                            //doc.SetPageSize(PageSize.LETTER);
                            doc.NewPage();
                            page = writer.GetImportedPage(reader, currentPageNumber);
                            rotation = reader.GetPageRotation(currentPageNumber);
                            if (rotation == 90 || rotation == 270)
                                cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(currentPageNumber).Height);
                            else
                                cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0);
                        }
                        while (currentPageNumber < numberOfPages);

                    }
                }
                //Response.OutputStream.Write(MemStream.GetBuffer(), 0, MemStream.GetBuffer().Length);
                //Response.OutputStream.Flush();
                //Response.OutputStream.Close();
                //MemStream.Close();
            }

            try
            {
                doc.Close();
                Response.BinaryWrite(MemStream.GetBuffer());
                Response.Flush();
                Response.Close();
                Response.End();
                MemStream.Close();
            }
            catch
            {
                // Page.RegisterStartupScript("error", "<script language=javascript>this.window.close();</script>");

            }
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlPathEncode(File_Name));
            //Response.BinaryWrite(MemStream.GetBuffer());
            //Response.Flush();
            //Response.Close();
            //    Response.AddHeader("Content-Disposition", "attachment; filename=ppppp");

            //    Response.BinaryWrite(MemStream.GetBuffer());
            //Response.Flush();
            //Response.Close();
        }
    }


    private DataTable LoadX()
    {
        DataTable DT_Tree = new DataTable();
        if (CDataConverter.ConvertToInt(Request["id"].ToString()) > 0)
        {
            int id = CDataConverter.ConvertToInt(Request["id"].ToString());

            DT_Tree = General_Helping.GetDataTable("select * from Departments_Documents where  File_ID =" + id);
            //File_ext LIKE '%pdf%'and
            LoadSubTree(DT_Tree, id);
        }
        return DT_Tree;
    }

    private void LoadSubTree(DataTable TreeTable, int parent_ID)
    {
        DataTable DT = new DataTable();
        DT = General_Helping.GetDataTable("select * from Departments_Documents where  Parent_ID =" + parent_ID);

        if (DT.Rows.Count != 0)
        {
            foreach (DataRow row in DT.Rows)
            {
                TreeTable.ImportRow(row);
                LoadSubTree(TreeTable, CDataConverter.ConvertToInt(row["File_ID"].ToString()));
            }
        }
    }
}
