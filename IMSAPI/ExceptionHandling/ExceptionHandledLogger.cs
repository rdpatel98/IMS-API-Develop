using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace IMSAPI.ExceptionHandling
{
    public static class ExceptionHandledLogger 
    {
        public static void Log(Exception ex)
        {
            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/ErrorLog.txt"); 

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();
                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);
                    ex = ex.InnerException;
                }
                writer.WriteLine("-----------------------------------------------------------------------------");
            }

        }

      
    }
}