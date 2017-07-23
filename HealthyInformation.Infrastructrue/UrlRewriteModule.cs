using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HealthyInformation.Infrastructrue
{
    public class UrlRewriteModule : IHttpModule
    {
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += delegate
            {
                HttpContext cxt = HttpContext.Current;
                string folder = cxt.Request.Headers["Folder"];
                string path = string.Concat("~/Services/", folder ?? string.Empty, cxt.Request.CurrentExecutionFilePath);
                try
                {
                    int lastIndex = path.LastIndexOf('/');
                    lastIndex = path.LastIndexOf(folder) + folder.Length + 1;
                    int i = path.IndexOf('/', lastIndex);
                    if (i > 0)
                    {
                        string a = path.Substring(0, i) + ".svc";
                        string b = path.Substring(i, path.Length - i);
                        string c = cxt.Request.QueryString.ToString();
                        cxt.RewritePath(a, b, c, false);
                    }
                }
                catch
                {

                }
            };
        }
    }
}
