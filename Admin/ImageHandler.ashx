<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;

public class ImageHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) 
    {
        //Checking whether the imagebytes session variable have anything else not doing anything

        if ((context.Session["ImageBytes"]) != null)
        {
            byte[] image = (byte[])(context.Session["ImageBytes"]);
            context.Response.ContentType = "image/"+context.Session["ImageExt"];
            context.Response.BinaryWrite(image);
        }
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}