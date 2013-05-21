﻿using System;
using System.Text;
using Dev2.Common;
using Dev2.Runtime.Diagnostics;
using Dev2.Runtime.ServiceModel.Data;

namespace Dev2.Runtime.ServiceModel
{
    public class Help : ExceptionManager
    {
        #region GetDictionary

        // POST: Service/Help/GetDictionary
        public HelpDictionary GetDictionary(string dictionaryID, Guid workspaceID, Guid dataListID)
        {
            var result = new HelpDictionary();

            try
            {
                // TODO: Read from file based on dictionaryID
                switch(dictionaryID)
                {
                    case "Server":
                        result.Add("default", "<h4>New Server Details</h4><p>This creates a connection to an existing server.</p>");
                        result.Add("address", "Enter the <b>server url</b> e.g. http://192.168.0.1:77/dsf.");
                        result.Add("authenticationType", "Determines how to authenticate with the server: "
                            + "<p><b>Windows</b> - the current user's windows account will be used.</p>"
                            + "<p><b>User</b> - the given user account will be used.</p>");
                        result.Add("userName", "Enter your <b>user name</b>.");
                        result.Add("password", "Enter the <b>password</b> for the server.");
                        break;
                    //07.03.2013: Ashley Lewis - PBI 8720:
                    case "dbSource":
                        result.Add("default", "<h4>New Database Source Details</h4><p>This creates a connection to an existing database server.</p>");
                        result.Add("dbSourceServerType", "Enter the database <b>type</b> e.g. Microsoft SQL");
                        result.Add("dbSourceServer", "Enter the database <b>server url</b> e.g. IP address or computer name");
                        result.Add("dbSourceUserID", "Enter either your database <b>user name</b> or a Windows domain username e.g. 'Domainname\\Username'");
                        result.Add("dbSourcePassword", "Enter the <b>password</b> for the server.");
                        result.Add("dbSourceDatabase", "Select one of the <b>databases</b> hosted by the server");
                        break;
                    //16.04.2013: Ashley Lewis - PBI 8721:
                    case "pluginSource":
                        result.Add("default", "<h4>Plugin File</h4><p>Select a Dll file to connect to</p>");
                        result.Add("pluginAssemblyFileLocation", "Enter the plugin <b>file address.</b> e.g. 'C:\\Warewolf\\Plugins\\email.plugin.dll'");
                        result.Add("pluginAssemblyGACLocation", "Enter the plugin <b>assembly name</b> starting with '" + GlobalConstants.GACPrefix + "' and followed by the verion number e.g. '" + GlobalConstants.GACPrefix + "Microsoft.Email.Client.Library 2.0.0.0'");
                        result.Add("tab 0", "<h4>Plugin File</h4><p>Select a Dll file to connect to</p>");
                        result.Add("tab 1", "<h4>Global Cache</h4><p>Select an assembly from the <b>Global Assemblies Cache</b></p>");
                        result.Add("GACList", "<h4>Global Cache</h4><p>Select an assembly from the <b>Global Assemblies Cache</b></p>");
                        result.Add("gacSearchTerm", "<h4>Global Cache</h4><p>You are viewing all assemblies</p>");
                        break;

                    // PBI 953 - 2013.05.16 - TWR - Added
                    case "EmailSource":
                        result.Add("default", "<h4>New Email Source Details</h4><p>This creates a connection to a SMTP server.</p>");
                        result.Add("host", "Enter the <b>name or IP address</b> of the computer to use for sending SMTP email. e.g.<br/>" + GetSmtpExamples());
                        result.Add("userName", "Enter the <b>user name</b> used to authenticate the sender.");
                        result.Add("password", "Enter the <b>password</b> used to authenticate the sender.");
                        result.Add("enableSsl", "Specifies whether the SMTP client uses <b>Secure Sockets Layer (SSL)</b> to encrypt the connection.");
                        result.Add("port", "Enter the <b>port number</b> on the SMTP host. The default value is 25. e.g.<br/>" + GetSmtpExamples());
                        result.Add("timeout", "Enter the amount of <b>time in seconds</b> after which a send operation times out. The default value is 100 seconds.");
                        break;

                    // PBI 953 - 2013.05.16 - TWR - Added
                    case "WebSource":
                        result.Add("default", "<h4>New Web Source Details</h4><p>This creates a connection to a web service.</p>");
                        result.Add("address", "Enter the <b>url</b> of the web service. e.g. <span style=\"word-wrap:break-word\">http://www.webservicex.net/globalweather.asmx</span>");
                        result.Add("authenticationType", "Determines how to authenticate with the server: "
                                                         + "<p><b>Anonymous</b> - no account will be used.</p>"
                                                         + "<p><b>User</b> - the given user account will be used.</p>");
                        result.Add("userName", "Enter the <b>user name</b> used to authenticate with the server.");
                        result.Add("password", "Enter the <b>password</b> used to authenticate with the server.");
                        break;
                }
            }
            catch(Exception ex)
            {
                RaiseError(ex);
            }
            return result;
        }

        #endregion

        #region GetSmtpExamples

        // PBI 953 - 2013.05.16 - TWR - Added
        static string GetSmtpExamples()
        {
            const string Format = "<tr><td>{0}</td><td>{1}</td></tr>";

            var servers = new StringBuilder("<table style='width: 100%'><tr><th>Host</th><th>Port</th></tr>");
            servers.AppendFormat(Format, "smtp.gmail.com", "587");
            servers.AppendFormat(Format, "smtp.live.com", "587");
            servers.AppendFormat(Format, "smtp.mail.yahoo.com", "25");
            servers.AppendFormat(Format, "my-exchange-server", "25");

            servers.Append("</table>");
            return servers.ToString();
        }

        #endregion

    }
}
