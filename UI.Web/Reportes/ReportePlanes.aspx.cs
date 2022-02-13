using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Desktop.Reportes.DsPlanTableAdapters;

namespace UI.Web.Reportes
{
    public partial class ReportePlanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReportePlanesTableAdapter gpta = new GetReportePlanesTableAdapter();


            // 2. limpiamos el origen de Datos del informe
            this.ReportViewer1.LocalReport.DataSources.Clear();

            // asignamos los Datos al conjunto de Datos del informe
            ReportDataSource rpd = new ReportDataSource("dsPlanes", (DataTable)gpta.GetData());
            this.ReportViewer1.LocalReport.DataSources.Add(rpd);


            this.ReportViewer1.ProcessingMode = ProcessingMode.Local;
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.RptPlanes.rdlc";

            // hacer el paso anterior una vez por cada conjunto de dato que tenga tu informe

            // por ultimo refrescamos el informe
            this.ReportViewer1.LocalReport.Refresh();


            //this.ReportViewer1.RefreshReport();
        }
    }
}