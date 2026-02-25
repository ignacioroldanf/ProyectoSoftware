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
        private FormsPlot _plotEstados;
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

            _plotEstados = new FormsPlot() { Dock = DockStyle.Fill };
            panelEstados.Controls.Add(_plotEstados);

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

                GenerarReporteEstados(desde, hasta);
                GenerarReporteIngresos(desde, hasta);
                GenerarReporteEjercicios(desde, hasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reportes: " + ex.Message);
            }
        }

        // REPORTE 1: ESTADOS
        private void GenerarReporteEstados(DateTime desde, DateTime hasta)
        {
            _plotEstados.Plot.Clear();

            var datos = _controlador.ObtenerEstadoClientes(desde, hasta);
            dtgvEstados.DataSource = datos;

            if (datos.Count == 0) return;

            List<Bar> barras = new List<Bar>();

            double[] posiciones = new double[datos.Count];
            string[] etiquetas = new string[datos.Count];

            int i = 0;
            foreach (var item in datos)
            {
                ScottPlot.Color colorBarra;
                if (item.Estado.Contains("Vigente") || item.Estado.Contains("Activo"))
                    colorBarra = ScottPlot.Color.FromHex("#4CAF50");
                else if (item.Estado.Contains("Vencid"))
                    colorBarra = ScottPlot.Color.FromHex("#FF9800");
                else if (item.Estado.Contains("Cancel"))
                    colorBarra = ScottPlot.Color.FromHex("#F44336");
                else
                    colorBarra = ScottPlot.Color.FromHex("#9E9E9E");

                var barra = new Bar
                {
                    Position = i,
                    Value = (double)item.CantidadClientes,
                    FillColor = colorBarra,
                    Label = item.CantidadClientes.ToString()
                };
                barras.Add(barra);

                posiciones[i] = i;
                etiquetas[i] = $"{item.Estado}\n{item.Porcentaje}";

                i++;
            }

            _plotEstados.Plot.Add.Bars(barras);
            _plotEstados.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(posiciones, etiquetas);

            _plotEstados.Plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            _plotEstados.Plot.Title("Estado de Cartera de Clientes");

            _plotEstados.Plot.Axes.AutoScale();

            _plotEstados.Plot.Axes.SetLimitsY(0, datos.Max(x => x.CantidadClientes) * 1.1);
            _plotEstados.Refresh();
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
                    var estRango = _controlador.ObtenerEstadoClientes(desdeRango, hastaRango);
                    var ingRango = _controlador.ObtenerIngresosPorPlan(desdeRango, hastaRango);
                    var ejeRango = _controlador.ObtenerEjerciciosMasPopulares(desdeRango, hastaRango);
                    var ingGruRango = ingRango.GroupBy(x => x.Categoria).Select(g => new { Categoria = g.Key, Total = g.Sum(x => x.TotalIngresos) }).ToList();

                    // 3. OBTENER DATOS TOTALES HISTÓRICOS
                    var estTotal = _controlador.ObtenerEstadoClientes(desdeTotal, hastaTotal);
                    var ingTotal = _controlador.ObtenerIngresosPorPlan(desdeTotal, hastaTotal);
                    var ejeTotal = _controlador.ObtenerEjerciciosMasPopulares(desdeTotal, hastaTotal);
                    var ingGruTotal = ingTotal.GroupBy(x => x.Categoria).Select(g => new { Categoria = g.Key, Total = g.Sum(x => x.TotalIngresos) }).ToList();

                    // 4. GENERAR IMÁGENES PARA EL RANGO
                    byte[] imgEstR = GenerarImagenEstados(estRango);
                    byte[] imgIngDetR = GenerarImagenIngresos(ingRango, true);
                    byte[] imgIngGruR = GenerarImagenIngresos(ingRango, false);
                    byte[] imgEjeR = GenerarImagenEjercicios(ejeRango);

                    // 5. GENERAR IMÁGENES PARA EL TOTAL HISTÓRICOS
                    byte[] imgEstT = GenerarImagenEstados(estTotal);
                    byte[] imgIngDetT = GenerarImagenIngresos(ingTotal, true);
                    byte[] imgIngGruT = GenerarImagenIngresos(ingTotal, false);
                    byte[] imgEjeT = GenerarImagenEjercicios(ejeTotal);

                    // 6. ENVIAR TODO AL GENERADOR DE PDF
                    PDFGenerator.ExportarReporteCompleto(
                        save.FileName, desdeRango, hastaRango,
                        // Parámetros del Rango
                        imgEstR, estRango, imgIngDetR, ingRango, imgIngGruR, ingGruRango, imgEjeR, ejeRango,
                        // Parámetros del Total
                        imgEstT, estTotal, imgIngDetT, ingTotal, imgIngGruT, ingGruTotal, imgEjeT, ejeTotal
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
        private byte[] GenerarImagenEstados(List<Reportes.ReporteEstadoClientes> datos)
        {
            ScottPlot.Plot plot = new ScottPlot.Plot(); // Plot en memoria

            List<Bar> barras = new List<Bar>();
            double[] posiciones = new double[datos.Count];
            string[] etiquetas = new string[datos.Count];
            int i = 0;

            foreach (var item in datos)
            {
                // Colores
                ScottPlot.Color colorBarra;
                if (item.Estado.Contains("Vigente")) colorBarra = ScottPlot.Color.FromHex("#4CAF50");
                else if (item.Estado.Contains("Vencid")) colorBarra = ScottPlot.Color.FromHex("#FF9800");
                else if (item.Estado.Contains("Cancel")) colorBarra = ScottPlot.Color.FromHex("#F44336");
                else colorBarra = ScottPlot.Color.FromHex("#9E9E9E");

                barras.Add(new Bar { Position = i, Value = (double)item.CantidadClientes, FillColor = colorBarra, Label = item.CantidadClientes.ToString() });
                posiciones[i] = i;
                etiquetas[i] = $"{item.Estado}\n{item.Porcentaje}";
                i++;
            }

            plot.Add.Bars(barras);
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(posiciones, etiquetas);
            plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            plot.Title("Estado de Cartera de Clientes");
            plot.Axes.AutoScale();

            return plot.GetImage(600, 400).GetImageBytes();
        }

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



        #endregion
    }
}