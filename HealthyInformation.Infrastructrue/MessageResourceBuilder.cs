using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HealthyInformation.Infrastructrue
{
    public class MessageResourceBuilder
    {
        private static Dictionary<string, string> messages;

        public static string GetMessageResource(string resourceID)
        {
            if (messages == null || messages.Count == 0)
            {
                messages = GetAllMessageResource();
            }

            if (!messages.ContainsKey(resourceID))
            {
                throw new Exception(string.Concat("ResourceID:", resourceID, " doesn't exist in message resource file."));
            }

            return messages[resourceID];
        }

        private static Dictionary<string, string> GetAllMessageResource()
        {
            Dictionary<string, string> messageResources = new Dictionary<string, string>();
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string messageFolder = GlobalConfig.CONN_MessageResourceFolder;
            string messageResourceFolder = Path.Combine(baseFolder, messageFolder);

            if (!Directory.Exists(messageResourceFolder))
            {
                LogHelper.WriteExceptionLog(string.Concat(MethodBase.GetCurrentMethod().Name, ":", "MessageResource Folder does'nt exist!"));
                return null;
            }

            string[] resourceFiles = Directory.GetFiles(messageResourceFolder, "*.xml", SearchOption.AllDirectories);
            if (resourceFiles.Length == 0)
            {
                LogHelper.WriteExceptionLog(string.Concat(MethodBase.GetCurrentMethod().Name, ":", "MessageResource files don't exist!"));
                return null;
            }

            foreach (var resourceFile in resourceFiles)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(resourceFile);

                XmlElement root = xmlDocument.DocumentElement;
                XmlNodeList nodeList = root.SelectNodes("/MessageResources/MessageResouce");
                foreach (XmlNode node in nodeList)
                {
                    messageResources.Add(node.Attributes["Code"].Value, node.InnerText);
                }
            }

            return messageResources;
        }
    }
}
