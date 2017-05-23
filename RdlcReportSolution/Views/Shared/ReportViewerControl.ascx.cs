using RdlcReportSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RdlcReportSolution.Views.Shared
{
    public partial class ReportViewerControl : System.Web.Mvc.ViewUserControl//System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Required for report events to be handled properly.
            //reportViewer.ServerReport.ReportServerCredentials = new ReportServerCredentials();
            Context.Handler = Page;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ReportServicesBase model = (ReportServicesBase)Model;
                //reportViewer.ServerReport.ReportServerCredentials = model.ServerCredentials;
                //ReportParameter[] RptParameters = model.parameters;
                ////reportViewer.ServerReport.ReportServerCredentials = model.ServerCredentials;
                //reportViewer.ServerReport.ReportPath = model.ReportPath;
                //reportViewer.ServerReport.ReportServerUrl = model.ReportServerURL;

                if (model.dataSources != null && model.dataSources.Count > 0)
                    foreach (var item in model.dataSources)
                        reportViewer.LocalReport.DataSources.Add(item.dataSource);
                //reportViewer.LocalReport.DataSources.Add()

                //if(RptParameters.Count() > 0)
                //this.reportViewer.ServerReport.SetParameters(RptParameters);
                //this.reportViewer.ServerReport.Refresh();
                
                reportViewer.LocalReport.ReportPath = Server.MapPath(model.ReportPath);
                reportViewer.LocalReport.Refresh();

            }
        }
    }
}