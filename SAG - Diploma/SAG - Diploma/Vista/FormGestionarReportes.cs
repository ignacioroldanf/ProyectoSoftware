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
        }

        private void FormGestionarReportes_Load(object sender, EventArgs e)
        {
            cmbIngresos.Items.Clear();
            cmbIngresos.Items.Add("Detallado por Plan");
            cmbIngresos.Items.Add("Agrupado (Premium vs Básico)");
            cmbIngresos.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarReporteEstados();
                GenerarReporteIngresos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reportes: " + ex.Message);
            }
        }

        // REPORTE 1: ESTADOS
        private void GenerarReporteEstados()
        {
            _plotEstados.Plot.Clear();

            var datos = _controlador.ObtenerEstadoUsuarios();
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
                    Value = (double)item.CantidadUsuarios,
                    FillColor = colorBarra,
                    Label = item.CantidadUsuarios.ToString()
                };
                barras.Add(barra);

                posiciones[i] = i;
                etiquetas[i] = $"{item.Estado}\n{item.Porcentaje}";

                i++;
            }

            _plotEstados.Plot.Add.Bars(barras);
            _plotEstados.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(posiciones, etiquetas);

            _plotEstados.Plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            _plotEstados.Plot.Title("Estado de la Cartera");

            _plotEstados.Plot.Axes.AutoScale();

            _plotEstados.Plot.Axes.SetLimitsY(0, datos.Max(x => x.CantidadUsuarios) * 1.1);
            _plotEstados.Refresh();
        }

        // REPORTE 2: INGRESOS

        private void GenerarReporteIngresos()
        {
            // 1. Traer datos de la BD
            _cacheIngresos = _controlador.ObtenerIngresosPorPlan();
            dtgvIngresos.DataSource = _cacheIngresos;

            DibujarGraficoIngresos();
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

            pie.SliceLabelDistance = 0.5;

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
                    // 1. OBTENER DATOS (Recuperamos todo fresco)
                    var datosEstados = _controlador.ObtenerEstadoUsuarios();
                    var datosIngresos = _controlador.ObtenerIngresosPorPlan();

                    // Datos agrupados (LINQ)
                    var datosAgrupados = datosIngresos
                        .GroupBy(x => x.Categoria)
                        .Select(g => new { Categoria = g.Key, Total = g.Sum(x => x.TotalIngresos) })
                        .ToList();

                    // 2. GENERAR IMÁGENES
                    // Usamos una función auxiliar para generar gráficos sin mostrarlos
                    byte[] imgEstados = GenerarImagenEstados(datosEstados);
                    byte[] imgIngresosDetalle = GenerarImagenIngresos(datosIngresos, true); // true = detallado
                    byte[] imgIngresosGrupo = GenerarImagenIngresos(datosIngresos, false); // false = agrupado

                    // 3. GENERAR PDF
                    PDFGenerator.ExportarReporteCompleto(
                        save.FileName,
                        imgEstados, datosEstados,
                        imgIngresosDetalle, datosIngresos,
                        imgIngresosGrupo, datosAgrupados
                    );

                    MessageBox.Show("Reporte exportado exitosamente.");

                    // Opcional: Abrir el PDF automáticamente
                    try { System.Diagnostics.Process.Start("explorer.exe", save.FileName); } catch { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private byte[] GenerarImagenEstados(List<Reportes.ReporteEstadoUsuarios> datos)
        {
            ScottPlot.Plot plot = new ScottPlot.Plot(); // Plot en memoria

            // ... (Lógica idéntica a tu GenerarReporteEstados, pero sobre 'plot') ...
            // Copia aquí la lógica de barras que ya hicimos

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

                barras.Add(new Bar { Position = i, Value = (double)item.CantidadUsuarios, FillColor = colorBarra, Label = item.CantidadUsuarios.ToString() });
                posiciones[i] = i;
                etiquetas[i] = $"{item.Estado}\n{item.Porcentaje}";
                i++;
            }

            plot.Add.Bars(barras);
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(posiciones, etiquetas);
            plot.Grid.MajorLineColor = ScottPlot.Colors.Transparent;
            plot.Title("Estado de Cartera");
            plot.Axes.AutoScale();

            return plot.GetImage(600, 400).GetImageBytes();
        }

        private byte[] GenerarImagenIngresos(List<Reportes.ReporteIngresos> datos, bool detallado)
        {
            ScottPlot.Plot plot = new ScottPlot.Plot(); // Plot en memoria
            List<PieSlice> porciones = new List<PieSlice>();

            // Paletas (Mismas que usas en el form)
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
            pie.SliceLabelDistance = 0.5;

            // Limpieza
            plot.HideGrid();
            plot.Axes.Frameless();
            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.EmptyTickGenerator();
            plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.EmptyTickGenerator();

            return plot.GetImage(600, 400).GetImageBytes();
        }
    }
}