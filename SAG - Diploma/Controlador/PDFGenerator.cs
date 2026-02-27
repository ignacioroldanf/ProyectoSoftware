using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelo;
using Controlador; // Necesario para acceder a ReporteEjercicioDTO
using System;
using System.Collections.Generic;
using System.IO;

namespace Controlador
{
    public static class PDFGenerator
    {
        // Fuentes estándar
        static Font _fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
        static Font _fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
        static Font _fontCelda = FontFactory.GetFont(FontFactory.HELVETICA, 9);

        public static void ExportarReporteCompleto(
            string rutaArchivo, DateTime desdeRango, DateTime hastaRango,

            // --- DATOS DEL RANGO SELECCIONADO ---
            byte[] imgInasistenciasR, List<Reportes.ReporteInasistencias> datosInasistenciasR,
            byte[] imgIngresosDetalleR, List<Reportes.ReporteIngresos> datosIngresosDetalleR,
            byte[] imgIngresosGrupoR, dynamic datosIngresosGrupoR,
            byte[] imgEjerciciosR, List<Reportes.ReporteEjerciciosPopulares> datosEjerciciosR,

            // --- DATOS HISTÓRICOS TOTALES ---
            byte[] imgInasistenciasT, List<Reportes.ReporteInasistencias> datosInasistenciasT,
            byte[] imgIngresosDetalleT, List<Reportes.ReporteIngresos> datosIngresosDetalleT,
            byte[] imgIngresosGrupoT, dynamic datosIngresosGrupoT,
            byte[] imgEjerciciosT, List<Reportes.ReporteEjerciciosPopulares> datosEjerciciosT
            )
        {
            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // REPORTE DEL RANGO DE FECHAS SELECCIONADO

                doc.Add(new Paragraph("REPORTE: PERÍODO SELECCIONADO", _fontTitulo) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Fechas filtradas: {desdeRango:dd/MM/yyyy} al {hastaRango:dd/MM/yyyy}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Fecha de Emisión del PDF: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n"));

                AgregarSeccion(doc, "1. Top % Inasistencias a Clases", imgInasistenciasR, CrearTablaInasistencias(datosInasistenciasR)); 
                doc.Add(new Paragraph("\n"));

                AgregarSeccion(doc, "2. Ingresos Detallados por Plan", imgIngresosDetalleR, CrearTablaIngresos(datosIngresosDetalleR));
                doc.Add(new Paragraph("\n"));

                AgregarSeccion(doc, "3. Resumen: Premium vs Básico", imgIngresosGrupoR, CrearTablaAgrupada(datosIngresosGrupoR));
                doc.Add(new Paragraph("\n"));

                AgregarSeccion(doc, "4. Top Ejercicios Más Solicitados", imgEjerciciosR, CrearTablaEjercicios(datosEjerciciosR));


                // REPORTE HISTÓRICO TOTAL
                doc.NewPage();

                doc.Add(new Paragraph("REPORTE: HISTÓRICO TOTAL", _fontTitulo) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Acumulado desde los inicios del gimnasio hasta {DateTime.Now:dd/MM/yyyy}\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)) { Alignment = Element.ALIGN_CENTER });

                AgregarSeccion(doc, "1. Top % Inasistencias a Clases (Histórico)", imgInasistenciasT, CrearTablaInasistencias(datosInasistenciasT));
                doc.Add(new Paragraph("\n"));

                AgregarSeccion(doc, "2. Ingresos Detallados (Histórico Total)", imgIngresosDetalleT, CrearTablaIngresos(datosIngresosDetalleT));
                doc.Add(new Paragraph("\n"));

                AgregarSeccion(doc, "3. Resumen: Premium vs Básico (Histórico Total)", imgIngresosGrupoT, CrearTablaAgrupada(datosIngresosGrupoT));
                doc.Add(new Paragraph("\n"));

                AgregarSeccion(doc, "4. Top Ejercicios Más Solicitados (Histórico Total)", imgEjerciciosT, CrearTablaEjercicios(datosEjerciciosT));

                doc.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar PDF: " + ex.Message);
            }
        }

        // Método Mágico: Crea una tabla invisible de 2 columnas para alinear Gráfico y Datos
        private static void AgregarSeccion(Document doc, string titulo, byte[] imagenBytes, PdfPTable tablaDatos)
        {
            // Subtítulo
            doc.Add(new Paragraph(titulo, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
            doc.Add(new Paragraph("\n"));

            // Tabla Contenedora (Layout)
            PdfPTable layout = new PdfPTable(2);
            layout.WidthPercentage = 100;
            layout.SetWidths(new float[] { 60f, 40f }); // 60% Gráfico, 40% Tabla

            // COLUMNA 1: IMAGEN
            if (imagenBytes != null && imagenBytes.Length > 0)
            {
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagenBytes);
                img.ScaleToFit(450f, 280f);
                PdfPCell celdaImg = new PdfPCell(img);
                celdaImg.Border = Rectangle.NO_BORDER;
                celdaImg.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaImg.VerticalAlignment = Element.ALIGN_MIDDLE;
                layout.AddCell(celdaImg);
            }
            else
            {
                layout.AddCell(new PdfPCell(new Phrase("Sin Gráfico")) { Border = Rectangle.NO_BORDER });
            }

            // COLUMNA 2: TABLA DE DATOS
            PdfPCell celdaTabla = new PdfPCell(tablaDatos);
            celdaTabla.Border = Rectangle.NO_BORDER;
            celdaTabla.PaddingLeft = 10f;
            layout.AddCell(celdaTabla);

            doc.Add(layout);
        }

        // HELPERS PARA CREAR TABLAS

        private static PdfPTable CrearTablaInasistencias(List<Reportes.ReporteInasistencias> datos)
        {
            PdfPTable t = new PdfPTable(4);
            t.WidthPercentage = 100;
            t.SetWidths(new float[] { 40f, 20f, 20f, 20f });

            AgregarHeader(t, "Cliente");
            AgregarHeader(t, "Reservas");
            AgregarHeader(t, "Faltas");
            AgregarHeader(t, "% Faltas");

            foreach (var d in datos)
            {
                AgregarCelda(t, d.Cliente);
                AgregarCelda(t, d.TotalReservas.ToString());
                AgregarCelda(t, d.Faltas.ToString());
                AgregarCelda(t, d.Porcentaje);
            }
            return t;
        }


        private static PdfPTable CrearTablaIngresos(List<Reportes.ReporteIngresos> datos)
        {
            PdfPTable t = new PdfPTable(3);
            t.WidthPercentage = 100;
            AgregarHeader(t, "Plan");
            AgregarHeader(t, "Socios");
            AgregarHeader(t, "Ingresos");

            foreach (var d in datos)
            {
                AgregarCelda(t, d.NombrePlan);
                AgregarCelda(t, d.CantidadSocios.ToString());
                AgregarCelda(t, $"${d.TotalIngresos:N0}");
            }
            return t;
        }

        private static PdfPTable CrearTablaEjercicios(List<Reportes.ReporteEjerciciosPopulares> datos)
        {
            PdfPTable t = new PdfPTable(2);
            t.WidthPercentage = 100;
            t.SetWidths(new float[] { 70f, 30f });

            AgregarHeader(t, "Ejercicio");
            AgregarHeader(t, "Usos Reales");

            foreach (var d in datos)
            {
                AgregarCelda(t, d.NombreEjercicio);
                AgregarCelda(t, d.CantidadUsos.ToString());
            }
            return t;
        }

        private static PdfPTable CrearTablaAgrupada(dynamic datos)
        {
            PdfPTable t = new PdfPTable(2);
            t.WidthPercentage = 100;
            AgregarHeader(t, "Categoría");
            AgregarHeader(t, "Total");

            foreach (var d in datos)
            {
                // Reflection para dynamic
                var props = d.GetType().GetProperties();
                string cat = "";
                decimal tot = 0;

                foreach (var prop in props)
                {
                    if (prop.Name == "Categoria") cat = prop.GetValue(d, null).ToString();
                    if (prop.Name == "Total") tot = Convert.ToDecimal(prop.GetValue(d, null));
                }

                AgregarCelda(t, cat);
                AgregarCelda(t, $"${tot:N0}");
            }
            return t;
        }

        private static void AgregarHeader(PdfPTable t, string texto)
        {
            PdfPCell c = new PdfPCell(new Phrase(texto, _fontHeader));
            c.BackgroundColor = new BaseColor(50, 50, 50);
            c.HorizontalAlignment = Element.ALIGN_CENTER;
            c.Padding = 5;
            t.AddCell(c);
        }

        private static void AgregarCelda(PdfPTable t, string texto)
        {
            PdfPCell c = new PdfPCell(new Phrase(texto, _fontCelda));
            c.HorizontalAlignment = Element.ALIGN_CENTER;
            c.Padding = 5;
            t.AddCell(c);
        }
    }
}