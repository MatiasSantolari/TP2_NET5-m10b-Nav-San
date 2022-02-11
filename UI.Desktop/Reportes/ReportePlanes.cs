using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UI.Desktop.Reportes.DsPlanTableAdapters;
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            GetReportePlanesTableAdapter gpta = new GetReportePlanesTableAdapter();


            // 2. limpiamos el origen de Datos del informe
            this.reportViewer1.LocalReport.DataSources.Clear();

            // asignamos los Datos al conjunto de Datos del informe
            ReportDataSource rpd = new ReportDataSource("dsPlanes", (DataTable)gpta.GetData());
            this.reportViewer1.LocalReport.DataSources.Add(rpd);


            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.RptPlanes.rdlc";

            // hacer el paso anterior una vez por cada conjunto de dato que tenga tu informe

            // por ultimo refrescamos el informe
            this.reportViewer1.LocalReport.Refresh();


            this.reportViewer1.RefreshReport();
        }
    }
}
