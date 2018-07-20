﻿using CrystalDecisions.CrystalReports.Engine;
using SystemConsoler.BLL.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SystemConsoler.WebForms
{
    public partial class ReportViwer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["ds"];
            ReportDocument rd = new ReportDocument();
            string path = string.Empty;

            switch ((Enumeration.ReportType)Session["ReportType"])
            {
                case Enumeration.ReportType.SalesPipeLine:
                    path = Server.MapPath(@"\Reports\ReportsTemplate\SalesPipeLine.rpt");
                    break;
                case Enumeration.ReportType.UnAssigned:
                    path = Server.MapPath(@"\Reports\ReportsTemplate\UnAssignedLead.rpt");
                    break;
                case Enumeration.ReportType.OpportunityInHand:
                    path = Server.MapPath(@"\Reports\ReportsTemplate\UnAssignedLead.rpt");
                    break;

                case Enumeration.ReportType.Campaign:
                    path = Server.MapPath(@"\Reports\ReportsTemplate\Campaign.rpt");
                    break;


                case Enumeration.ReportType.LeadConversion:
                    path = Server.MapPath(@"\Reports\ReportsTemplate\UnAssignedLead.rpt");
                    break;


                default:
                    break;
            }

            rd.Load(path);
            //rd.DataSourceConnections[0].SetConnection(@"DESKTOP-R4OEROM\SQLEXPRESS", "SystemConsoler_DB", false);
            //rd. = null;
            rd.SetDataSource(ds);

            //foreach (ReportDocument item in rd.Subreports)
            //{
            //    item.DataSourceConnections[0].SetConnection(@"DESKTOP-R4OEROM\SQLEXPRESS", "SystemConsoler_DB", false);
            //}

            CrystalReportViewer1.EnableDatabaseLogonPrompt = false;

            CrystalReportViewer1.ReportSource = rd;
            //CrystalReportViewer1.RefreshReport();
            CrystalReportViewer1.DataBind();
        }
    }
}