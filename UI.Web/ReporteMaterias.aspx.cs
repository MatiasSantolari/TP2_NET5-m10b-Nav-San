using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Business.Logic;
using System.Data;

namespace UI.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * ReportViewer viewer = new Microsoft.Reporting.WebForms.ReportViewer();
            MateriaLogic ml = new MateriaLogic();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataMaterias", ml.GetAll()));
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = "ReportedeMaterias.rdlc";
            */

            //1 . primero llenanos el Dataset o lista si estamos trabajando con listas
            MateriaLogic mat = new MateriaLogic();
            PlanLogic pla = new PlanLogic();


            var materias = mat.GetAll();
            var planes = pla.GetAll();

            var mater = (from m in materias
                         join p in planes on m.IdPlan equals p.ID
                         select (m, p.DescPlan)).ToList();

            DataTable dataTable1 = new DataTable();
            dataTable1.TableName = "Materias";
            dataTable1.Columns.Add("ID");
            dataTable1.Columns.Add("DescMateria");
            dataTable1.Columns.Add("HsSemanales");
            dataTable1.Columns.Add("HsTotales");
            dataTable1.Columns.Add("DescPlan");
            foreach (var ma in mater)
            {
                dataTable1.Rows.Add(ma.m.ID, ma.m.DescMateria, ma.m.HsSemanales, ma.m.HsTotales, ma.DescPlan);
            }

            // 2. limpiamos el origen de Datos del informe
            this.ReportViewer1.LocalReport.DataSources.Clear();

            // asignamos los Datos al conjunto de Datos del informe

            this.ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataMaterias", dataTable1));


            this.ReportViewer1.ProcessingMode = ProcessingMode.Local;
            this.ReportViewer1.LocalReport.ReportPath = "ReportedeMaterias.rdlc";

            // hacer el paso anterior una vez por cada conjunto de dato que tenga tu informe

            // por ultimo refrescamos el informe
            this.ReportViewer1.LocalReport.Refresh();



        }
    }
}