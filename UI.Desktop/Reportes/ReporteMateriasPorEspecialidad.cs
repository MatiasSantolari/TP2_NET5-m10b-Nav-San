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
    public partial class ReporteMateriasPorEspecialidad : Form
    {
        public ReporteMateriasPorEspecialidad()
        {
            InitializeComponent();
        }

        private void ReporteMateriasPorEspecialidad_Load(object sender, EventArgs e)
        {
            especialidadesTableAdapter eta = new especialidadesTableAdapter();


            // 2. limpiamos el origen de Datos del informe
            this.reportViewer1.LocalReport.DataSources.Clear();

            // asignamos los Datos al conjunto de Datos del informe
            ReportDataSource rpd = new ReportDataSource("dsEspecialidadesV2", (DataTable)eta.GetData());
            this.reportViewer1.LocalReport.DataSources.Add(rpd);


            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Reportes.RptMateriasPorEspecialidad.rdlc";

            // hacer el paso anterior una vez por cada conjunto de dato que tenga tu informe

            // por ultimo refrescamos el informe
            this.reportViewer1.LocalReport.Refresh();


            this.reportViewer1.RefreshReport();
        }
    }
}
