using Controlador;
using Modelo; 
using ScottPlot; 
using ScottPlot.WinForms;
using ScottPlot.TickGenerators;
using System.Linq;


using DrawingColor = System.Drawing.Color;
using ScottColor = ScottPlot.Color;

namespace SAG___Diploma.Vista
{
    public partial class FormGestionarReportes : Form
    {
        private CtrlGestionarReportes _controlador;

        private FormsPlot _plotIngresos;
        private FormsPlot _plotInasistencias;
        private FormsPlot _plotEjercicios;

        private List<Reportes.ReporteIngresos> _cacheIngresos;

        public FormGestionarReportes()
        {
            InitializeComponent();
            _controlador = new CtrlGestionarReportes();

            InicializarGraficos();
        }

        private void InicializarGraficos()
        {
            _plotIngresos = new FormsPlot() { Dock = DockStyle.Fill };
            panelIngresos.Controls.Add(_plotIngresos);

            _plotInasistencias = new FormsPlot() { Dock = DockStyle.Fill };
            panelInasistencias.Controls.Add(_plotInasistencias);

            _plotEjercicios = new FormsPlot() { Dock = DockStyle.Fill };
            panelEjercicios.Controls.Add(_plotEjercicios);
        }

        private void FormGestionarReportes_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Today.AddMonths(-1);
            dtpFechaHasta.Value = DateTime.Today;

            cmbIngresos.Items.Clear();
            cmbIngresos.Items.Add("Detallado por Plan");
            cmbIngresos.Items.Add("Agrupado (Premium vs Básico)");
            cmbIngresos.SelectedIndex = 0;
            AplicarSeguridad();
        }

        private void AplicarSeguridad()
        {
            if (btnGenerar != null)
                btnGenerar.Visible = Sesion.Instancia.TienePermiso("GenerarReportes");

            if (btnExportar != null)
                btnExportar.Visible = Sesion.Instancia.TienePermiso("ExportarReportes");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = dtpFechaDesde.Value.Date;
                DateTime hasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1);

                GenerarReporteInasistencias(desde, hasta);
                GenerarReporteIngresos(desde, hasta);
                GenerarReporteEjercicios(desde, hasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reportes: " + ex.Message);
            }
        }

        // REPORTE 1: INASISTENCIAS
        private void GenerarReporteInasistencias(DateTime desde, DateTime hasta)
        {
            _plotInasistencias.Plot.Clear();

            var datos = _controlador.ObtenerTopInasistencias(desde, hasta);
            dtgvInasistencias.DataSource = datos;

            if (dtgvInasistencias.Columns.Contains("PorcentajeFaltas"))
                dtgvInasistencias.Columns["PorcentajeFaltas"].Visible = false;

            if (datos.Count == 0) return;

            var datosDibujo = new List<Reportes.ReporteInasistencias>(datos);
            datosDibujo.Reverse(); 

            List<Bar> barras = new List<Bar>();
            double[] posiciones = new double[datosDibujo.Count];
            string[] etiquetas = new string[datosDibujo.Count];

            int i = 0;
            foreach (var item in datosDibujo)
            {
                barras.Add(new Bar { Position = i, Value = item.PorcentajeFaltas, FillColor = ScottPlot.Color.FromHex("#E53935"), Label = $"{item.PorcentajeFaltas:0.00}%" });
                posiciones[i] = i;
                etiquetas[i] = item.Cliente;
                i++;
            }

            var barPlot = _plotInasistencias.Plot.Add.Bars(barras);
            barPlot.Horizontal = true;

            _plotInasistencias.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(posiciones, etiquetas);
            _plotInasistencias.Plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            _plotInasistencias.Plot.Title("Mayor % Inasistencias");
            _plotInasistencias.Plot.Axes.AutoScale();
            _plotInasistencias.Plot.Axes.SetLimitsX(0, datosDibujo.Max(x => x.PorcentajeFaltas) * 1.2);
            _plotInasistencias.Refresh();
        }
        // REPORTE 2: INGRESOS

        private void GenerarReporteIngresos(DateTime desde, DateTime hasta)
        {
            _cacheIngresos = _controlador.ObtenerIngresosPorPlan(desde, hasta);
            dtgvIngresos.DataSource = _cacheIngresos;

            DibujarGraficoIngresos();
        }

        // REPORTE 3: EJERCICIOS POPULARES

        private void GenerarReporteEjercicios(DateTime desde, DateTime hasta)
        {
            var datos = _controlador.ObtenerEjerciciosMasPopulares(desde, hasta);

            dtgvEjercicios.DataSource = datos;

            if (datos.Count == 0) return;

            datos = datos.OrderBy(x => x.CantidadUsos).ToList();

            List<Bar> barras = new List<Bar>();
            double[] posiciones = new double[datos.Count];
            string[] tags = new string[datos.Count];

            int i = 0;
            foreach (var item in datos) 
            {
                var barra = new Bar
                {
                    Position = i,
                    Value = (double)item.CantidadUsos,
                    FillColor = ScottPlot.Color.FromHex("#20B2AA"),
                    Label = item.CantidadUsos.ToString()
                };

                barras.Add(barra);
                posiciones[i] = i;
                tags[i] = $"{item.NombreEjercicio}\n{item.CantidadUsos} usos";
                i++;
            }

            var barPlot = _plotEjercicios.Plot.Add.Bars(barras);
            barPlot.Horizontal = true;

            _plotEjercicios.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(posiciones, tags);
            _plotEjercicios.Plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            _plotEjercicios.Plot.Title("Ejercicios Más Populares");
            _plotEjercicios.Plot.Axes.AutoScale();

            double maxVal = datos.Max(x => x.CantidadUsos);
            _plotEjercicios.Plot.Axes.SetLimitsX(0, maxVal * 1.1);

            _plotEjercicios.Refresh();
        }
        private void cmbIngresos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cacheIngresos != null && _cacheIngresos.Count > 0)
            {
                DibujarGraficoIngresos();
            }
        }

        private void DibujarGraficoIngresos()
        {
            _plotIngresos.Plot.Clear();

            List<PieSlice> porciones = new List<PieSlice>();

            ScottPlot.Color[] paletaPremium = {
                ScottPlot.Color.FromHex("#FFD700"), ScottPlot.Color.FromHex("#FFA500"),
                ScottPlot.Color.FromHex("#B8860B"), ScottPlot.Color.FromHex("#F0E68C")
            };
            ScottPlot.Color[] paletaBasico = {
                ScottPlot.Color.FromHex("#2196F3"), ScottPlot.Color.FromHex("#03A9F4"),
                ScottPlot.Color.FromHex("#00BCD4"), ScottPlot.Color.FromHex("#3F51B5")
            };

            if (cmbIngresos.SelectedIndex == 0) // Detallado
            {
                int idxP = 0; int idxB = 0;
                foreach (var item in _cacheIngresos)
                {
                    ScottPlot.Color colorSlice;
                    if (item.Categoria == "Premium") { colorSlice = paletaPremium[idxP % paletaPremium.Length]; idxP++; }
                    else { colorSlice = paletaBasico[idxB % paletaBasico.Length]; idxB++; }

                    porciones.Add(new PieSlice
                    {
                        Value = (double)item.TotalIngresos,
                        Label = item.NombrePlan,
                        FillColor = colorSlice,
                        LegendText = $"{item.NombrePlan}: ${item.TotalIngresos:N0}"
                    });
                }
                _plotIngresos.Plot.Title("Ingresos por Plan");
            }
            else // Agrupado
            {
                var grupos = _cacheIngresos.GroupBy(x => x.Categoria)
                    .Select(g => new { Categoria = g.Key, Total = g.Sum(x => x.TotalIngresos) }).ToList();

                foreach (var grupo in grupos)
                {
                    var color = grupo.Categoria == "Premium" ? ScottPlot.Color.FromHex("#FFD700") : ScottPlot.Color.FromHex("#2196F3");

                    porciones.Add(new PieSlice
                    {
                        Value = (double)grupo.Total,
                        Label = grupo.Categoria,
                        FillColor = color,
                        LegendText = $"{grupo.Categoria}: ${grupo.Total:N0}"
                    });
                }
                _plotIngresos.Plot.Title("Ingresos: Premium vs Básico");
            }

            var pie = _plotIngresos.Plot.Add.Pie(porciones);

            pie.SliceLabelDistance = 1.3;

            _plotIngresos.Plot.HideGrid();
            _plotIngresos.Plot.Axes.Frameless();
            _plotIngresos.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.EmptyTickGenerator();
            _plotIngresos.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.EmptyTickGenerator();
            _plotIngresos.Plot.Axes.AutoScale();
            _plotIngresos.Refresh();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = $"Reporte_Gestion_{DateTime.Now:yyyyMMdd}.pdf";
            save.Filter = "PDF Files|*.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. DEFINIR LAS FECHAS
                    // A. Fechas del rango seleccionado por el usuario
                    DateTime desdeRango = dtpFechaDesde.Value.Date;
                    DateTime hastaRango = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1);

                    // B. Fechas para el TOTAL histórico (Desde el año 2000 hasta el futuro)
                    DateTime desdeTotal = new DateTime(2000, 1, 1);
                    DateTime hastaTotal = DateTime.Now.AddYears(1);

                    // 2. OBTENER DATOS DEL RANGO
                    var inaRango = _controlador.ObtenerTopInasistencias(desdeRango, hastaRango);
                    var ingRango = _controlador.ObtenerIngresosPorPlan(desdeRango, hastaRango);
                    var ejeRango = _controlador.ObtenerEjerciciosMasPopulares(desdeRango, hastaRango);
                    var ingGruRango = ingRango.GroupBy(x => x.Categoria).Select(g => new { Categoria = g.Key, Total = g.Sum(x => x.TotalIngresos) }).ToList();

                    // 3. OBTENER DATOS TOTALES HISTÓRICOS
                    var inaTotal = _controlador.ObtenerTopInasistencias(desdeTotal, hastaTotal);
                    var ingTotal = _controlador.ObtenerIngresosPorPlan(desdeTotal, hastaTotal);
                    var ejeTotal = _controlador.ObtenerEjerciciosMasPopulares(desdeTotal, hastaTotal);
                    var ingGruTotal = ingTotal.GroupBy(x => x.Categoria).Select(g => new { Categoria = g.Key, Total = g.Sum(x => x.TotalIngresos) }).ToList();

                    // 4. GENERAR IMÁGENES PARA EL RANGO
                    byte[] imgInaR = GenerarImagenInasistencias(inaRango);
                    byte[] imgIngDetR = GenerarImagenIngresos(ingRango, true);
                    byte[] imgIngGruR = GenerarImagenIngresos(ingRango, false);
                    byte[] imgEjeR = GenerarImagenEjercicios(ejeRango);

                    // 5. GENERAR IMÁGENES PARA EL TOTAL HISTÓRICOS
                    byte[] imgInaT = GenerarImagenInasistencias(inaTotal);
                    byte[] imgIngDetT = GenerarImagenIngresos(ingTotal, true);
                    byte[] imgIngGruT = GenerarImagenIngresos(ingTotal, false);
                    byte[] imgEjeT = GenerarImagenEjercicios(ejeTotal);

                    // 6. ENVIAR TODO AL GENERADOR DE PDF
                    PDFGenerator.ExportarReporteCompleto(
                                            save.FileName, desdeRango, hastaRango,
                                            imgInaR, inaRango, imgIngDetR, ingRango, imgIngGruR, ingGruRango, imgEjeR, ejeRango,
                                            imgInaT, inaTotal, imgIngDetT, ingTotal, imgIngGruT, ingGruTotal, imgEjeT, ejeTotal
                                        );

                    MessageBox.Show("Reporte exportado exitosamente.");
                    try { System.Diagnostics.Process.Start("explorer.exe", save.FileName); } catch { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }        
        
        #region Generadores de imagen para PDF

        private byte[] GenerarImagenIngresos(List<Reportes.ReporteIngresos> datos, bool detallado)
        {
            ScottPlot.Plot plot = new ScottPlot.Plot(); // Plot en memoria
            List<PieSlice> porciones = new List<PieSlice>();

            ScottPlot.Color[] paletaPremium = { ScottPlot.Color.FromHex("#FFD700"), ScottPlot.Color.FromHex("#FFA500") };
            ScottPlot.Color[] paletaBasico = { ScottPlot.Color.FromHex("#2196F3"), ScottPlot.Color.FromHex("#03A9F4") };

            if (detallado)
            {
                int idxP = 0; int idxB = 0;
                foreach (var item in datos)
                {
                    ScottPlot.Color c = (item.Categoria == "Premium") ? paletaPremium[idxP++ % 2] : paletaBasico[idxB++ % 2];
                    porciones.Add(new PieSlice { Value = (double)item.TotalIngresos, Label = item.NombrePlan, FillColor = c });
                }
                plot.Title("Ingresos Detallados");
            }
            else
            {
                var grupos = datos.GroupBy(x => x.Categoria).Select(g => new { Cat = g.Key, Tot = g.Sum(x => x.TotalIngresos) });
                foreach (var g in grupos)
                {
                    ScottPlot.Color c = (g.Cat == "Premium") ? ScottPlot.Color.FromHex("#FFD700") : ScottPlot.Color.FromHex("#2196F3");
                    porciones.Add(new PieSlice { Value = (double)g.Tot, Label = g.Cat, FillColor = c });
                }
                plot.Title("Ingresos Agrupados");
            }

            var pie = plot.Add.Pie(porciones);
            pie.SliceLabelDistance = 1.3;

            // Limpieza
            plot.HideGrid();
            plot.Axes.Frameless();
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.EmptyTickGenerator();
            plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.EmptyTickGenerator();

            return plot.GetImage(600, 400).GetImageBytes();
        }

        private byte[] GenerarImagenEjercicios(List<Reportes.ReporteEjerciciosPopulares> datos)
        {
            ScottPlot.Plot plot = new ScottPlot.Plot();

            if (datos.Count == 0) return plot.GetImage(600, 400).GetImageBytes();

            var datosDibujo = new List<Reportes.ReporteEjerciciosPopulares>(datos);
            datosDibujo.Reverse();

            List<Bar> barras = new List<Bar>();
            double[] posiciones = new double[datosDibujo.Count];
            string[] etiquetas = new string[datosDibujo.Count];

            int i = 0;
            foreach (var item in datosDibujo)
            {
                barras.Add(new Bar
                {
                    Position = i,
                    Value = item.CantidadUsos,
                    FillColor = ScottPlot.Color.FromHex("#20B2AA"),
                    Label = item.CantidadUsos.ToString()
                });

                posiciones[i] = i;
                etiquetas[i] = item.NombreEjercicio;
                i++;
            }

            var barPlot = plot.Add.Bars(barras);
            barPlot.Horizontal = true; // Horizontal

            plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(posiciones, etiquetas);
            plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            plot.Title("Top Ejercicios");
            plot.Axes.AutoScale();
            double maxVal = datosDibujo.Max(x => x.CantidadUsos);
            plot.Axes.SetLimitsX(0, maxVal * 1.2);

            return plot.GetImage(600, 400).GetImageBytes();
        }


        private byte[] GenerarImagenInasistencias(List<Reportes.ReporteInasistencias> datos)
        {
            ScottPlot.Plot plot = new ScottPlot.Plot();
            if (datos.Count == 0) return plot.GetImage(600, 400).GetImageBytes();

            var datosDibujo = new List<Reportes.ReporteInasistencias>(datos);
            datosDibujo.Reverse();

            List<Bar> barras = new List<Bar>();
            double[] pos = new double[datosDibujo.Count];
            string[] tags = new string[datosDibujo.Count];
            int i = 0;

            foreach (var item in datosDibujo)
            {
                barras.Add(new Bar { Position = i, Value = item.PorcentajeFaltas, FillColor = ScottPlot.Color.FromHex("#E53935"), Label = $"{item.PorcentajeFaltas:0.00}%" });
                pos[i] = i; tags[i] = item.Cliente; i++;
            }

            var barPlot = plot.Add.Bars(barras);
            barPlot.Horizontal = true;
            plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(pos, tags);
            plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            plot.Title("Top % Inasistencias");
            plot.Axes.AutoScale();
            plot.Axes.SetLimitsX(0, datosDibujo.Max(x => x.PorcentajeFaltas) * 1.2);
            return plot.GetImage(600, 400).GetImageBytes();
        }

        #endregion
    }
}