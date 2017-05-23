using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RdlcReportSolution.Services
{
    public class reportDataSources
    {
        public String dataSourceName { get; set; }
        public ReportDataSource dataSource { get; set; }
    }
    public abstract class ReportServicesBase
    {
        public virtual String ExportType { get; set; }

        public virtual void Export(){}
        public virtual void Render(){}

        public abstract void ResolveDataSource();

        public IList<reportDataSources> dataSources { get; set; }
        public  String ReportName { get; set; }
        public virtual String ReportPath { get; set; }
        public List<ReportParameter> ReportParameter { get; set; }

        public virtual SubreportProcessingEventHandler subReportEvent { get; set; }
    }
}