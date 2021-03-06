﻿using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Xml;
using mojohive;
using net.sf.jni4net;
using QlikView.Qvx.QvxLibrary;

namespace QvBigDataConn
{
    class QvBigDataConnection_dynamic : QvxConnection
    {
        protected SimpleLogger _logger;

        public override void Init()
        {
            // Set to true true to get more logging.
            //QvxLog.SetLogLevels(false, false);
            QvxLog.SetLogLevels(true, true);
            QvxLog.Log(QvxLogFacility.Application, QvxLogSeverity.Notice, "Init()");

            _logger = new SimpleLogger("QvBigDataConn");
            _logger.EnableFileLogging(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), log4net.Core.Level.Debug);

            _logger.LogMsg(log4net.Core.Level.Info, "Initializing QlikView API connection class.");

            _logger.LogMsg(log4net.Core.Level.Info, String.Format("Command queue path: [{0}].", Program.CommandPipe));

            GetBillToCodes();
            //VerifyCredentials();
            //MTables = new List<QvxTable> {
            //    new QvxTable {
            //        TableName = "BillToCodes",
            //        GetRows = GetBillToCodes,
            //        Fields = null
            //    }
            //};
        }

        private void GetBillToCodes()
        {
            String tableName = "BillToCodes";
            String xml_results = "";

            try
            {
                String mydriver;
                Login loginForm = new Login();
                Standalone sd = new Standalone();

                _logger.LogMsg(log4net.Core.Level.Info, "Enter callback function GetBillToCodes()");

                // Run the query, get a dataset in XML ? 

                // Get the path to the executing program so we can add it to the Java CLASSPATH.
                String local_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                _logger.LogMsg(log4net.Core.Level.Info, "Working folder: " + local_path);

                _logger.LogMsg(log4net.Core.Level.Info, "Opening DotNet-Java bridge.");

                var bridgeSetup = new BridgeSetup();
                bridgeSetup.AddAllJarsClassPath(".");
                bridgeSetup.AddAllJarsClassPath(local_path);

                Bridge.CreateJVM(bridgeSetup);
                Bridge.RegisterAssembly(typeof(MojoHiveDriver).Assembly);


                mydriver = loginForm.serverTextBox.Text;

                String drivername = "org.apache.hive.jdbc.HiveDriver";
                //String url = "jdbc:hive2://54.218.97.70:21050/;auth=noSasl";
                String url = "jdbc:" + loginForm.textBoxPrefix.Text + "://" + mydriver + ":" + loginForm.textBoxPort.Text + "/" + loginForm.textBoxQueue.Text;
                String username = loginForm.userTextBox.Text;
                String password = loginForm.passwordBox.Password.Trim();
                String queuename = loginForm.textBoxQueue.Text;

                // *** Create the Java proxy class
                _logger.LogMsg(log4net.Core.Level.Info, "Creating MojoHiveDriver proxy.");
                IMojoHiveDriver driver = new MojoHiveDriver();

                // *** Test Cloudera connection
                //QvxLog.Log(QvxLogFacility.Application, QvxLogSeverity.Notice, String.Format("Testing connection: driver={0} | url={1} | queuename={2} | username={3} | password={4}.", drivername, url, queuename, username, password));
                _logger.LogMsg(log4net.Core.Level.Info, String.Format("Testing connection: driver={0} | url={1} | queuename={2} | username={3} | password={4}.", drivername, url, queuename, username, password));
                int result = driver.TestConnection(drivername, url, queuename, username, password);
                if (result == 0)
                {
                    //QvxLog.Log(QvxLogFacility.Application, QvxLogSeverity.Notice, "Connection successful.");
                    _logger.LogMsg(log4net.Core.Level.Info, "Connection successful.");
                }
                else
                {
                    //QvxLog.Log(QvxLogFacility.Application, QvxLogSeverity.Notice, "Connection failed: " + driver.GetLastExceptionMessage());
                    _logger.LogMsg(log4net.Core.Level.Info, "Connection failed: " + driver.GetLastExceptionMessage());
                }

                // *** Run an actual query
                //TO DO: get this from QlikView ? Must use named pipes?
                //String sql = "SELECT * FROM billtocodes WHERE billtocode='3DAKE'";
                //String sql = "SELECT * FROM billtocodes WHERE billtocode LIKE '4P%'";
                //String sql = "SELECT * FROM BillToCodes";// WHERE billtoeffdt > '2008-02-01 00:00:00' AND billtoeffdt < '2008-02-28 00:00:00'";

                string sql = sd.sqlStatementBox.Text;

                _logger.LogMsg(log4net.Core.Level.Info, "Running query: " + sql);
                xml_results = driver.QueryResultSetAsXML(drivername, url, queuename, username, password, sql);
                //_logger.LogMsg(log4net.Core.Level.Info, "XML results:\r\n" + xml_results);
            }
            catch (System.Exception ex)
            {
                _logger.LogMsg(log4net.Core.Level.Error, "Fatal exception: " + ex.Message);
            }

            _logger.LogMsg(log4net.Core.Level.Info, "Loading XML into parser." + xml_results);
            System.Xml.XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml_results);
            XmlNode root = doc.FirstChild;
            if (root.HasChildNodes)
            {
                _logger.LogMsg(log4net.Core.Level.Info, String.Format("Query returned {0} rows.", root.ChildNodes.Count.ToString()));

                _logger.LogMsg(log4net.Core.Level.Info, "Moving data from XML to QlikView objects." + xml_results);
                foreach (XmlNode row_node in root.ChildNodes)
                {
                    //Debug.WriteLine(row_node.Name);
                    //yield return MakeEntry(row_node, FindTable(tableName, MTables));

                    //foreach (XmlNode field_node in row_node.ChildNodes)
                    //{
                    //    Debug.WriteLine(field_node.Name + " = " + field_node.InnerText);                        
                    //}
                }
            }
            else
            {
                _logger.LogMsg(log4net.Core.Level.Warn, "No rows returned!" + xml_results);
            }
        }

        private void VerifyCredentials()
        {
            QvxLog.Log(QvxLogFacility.Application, QvxLogSeverity.Notice, "VerifyCredentials()");

            string username, password;
            this.MParameters.TryGetValue("UserId", out username);
            this.MParameters.TryGetValue("Password", out password);

            username = "bluestar";
            password = "Bsil@123";

            if (username != "bluestar" || password != "Bsil@123")
            {
                var error = "Username and/or password is incorrect";
                QvxLog.Log(QvxLogFacility.Application, QvxLogSeverity.Notice, String.Format("VerifyCredentials() - {0}", error));
                throw new AuthenticationException(error);
            }
        }

        private QvxDataRow MakeEntry(XmlNode rowNode, QvxTable table)
        {
            var row = new QvxDataRow();

            foreach (XmlNode field_node in rowNode.ChildNodes)
            {
                switch (field_node.Name.ToLower())
                {
                    case "billtocode":
                        row[table.Fields[0]] = field_node.InnerText;
                        break;
                    case "billtodesc":
                        row[table.Fields[1]] = field_node.InnerText;
                        break;
                    case "billtoeffdt":
                        row[table.Fields[2]] = field_node.InnerText;
                        break;
                    case "billtoexpdt":
                        row[table.Fields[3]] = field_node.InnerText;
                        break;
                }
            }
            return row;
        }
    }
}
