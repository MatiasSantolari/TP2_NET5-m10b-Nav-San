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

namespace UI.Desktop.Reportes
{
    public partial class ReporteInscriptosPorMateria : Form
    {
        public ReporteInscriptosPorMateria()
        {
            InitializeComponent();
        }

        private void ReporteInscriptosPorMateria_Load(object sender, EventArgs e)
        {
            GetReporteInscriptosPorMateriaTableAdapter grim = new GetReporteInscriptosPorMateriaTableAdapter();


            // 2. limpiamos el origen de Datos del informe
            this.reportViewer1.LocalReport.DataSources.Clear();

            // asignamos los Datos al conjunto de Datos del informe
            ReportDataSource rpd = new ReportDataSource("dsInscriptosPorMateria", (DataTable)grim.GetData());
            this.reportViewer1.LocalReport.DataSources.Add(rpd);


            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.RptInscriptosPorMateria.rdlc";

            // hacer el paso anterior una vez por cada conjunto de dato que tenga tu informe

            // por ultimo refrescamos el informe
            this.reportViewer1.LocalReport.Refresh();


            this.reportViewer1.RefreshReport();
        }
    }
}
