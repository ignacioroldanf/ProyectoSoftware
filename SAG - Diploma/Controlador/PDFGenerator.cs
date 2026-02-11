using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelo; // Para acceder a tus DTOs
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
            string rutaArchivo,
            byte[] imgEstados, List<Reportes.ReporteEstadoUsuarios> datosEstados,
            byte[] imgIngresosDetalle, List<Reportes.ReporteIngresos> datosIngresosDetalle,
            byte[] imgIngresosGrupo, dynamic datosIngresosGrupo
            )
        {
            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // Título General
                doc.Add(new Paragraph("Reporte General de Gestión - Gimnasio", _fontTitulo) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"Fecha de Emisión: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n"));

                // --- SECCIÓN 1: ESTADOS ---
                AgregarSeccion(doc, "1. Estado de la Cartera de Clientes", imgEstados, CrearTablaEstados(datosEstados));
                doc.Add(new Paragraph("\n")); // Espacio

                // --- SECCIÓN 2: INGRESOS POR PLAN (DETALLE) ---
                AgregarSeccion(doc, "2. Ingresos Detallados por Plan", imgIngresosDetalle, CrearTablaIngresos(datosIngresosDetalle));
                doc.Add(new Paragraph("\n"));

                // --- SECCIÓN 3: INGRESOS AGRUPADOS (PREMIUM VS BÁSICO) ---
                // Nota: Para la tabla agrupada, convertimos el dynamic a una lista simple para la tabla
                AgregarSeccion(doc, "3. Resumen: Premium vs Básico", imgIngresosGrupo, CrearTablaAgrupada(datosIngresosGrupo));

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
            layout.SetWidths(new float[] { 55f, 45f }); // 55% Gráfico, 45% Tabla

            // COLUMNA 1: IMAGEN
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagenBytes);
            img.ScaleToFit(380f, 250f); // Ajustar tamaño
            PdfPCell celdaImg = new PdfPCell(img);
            celdaImg.Border = Rectangle.NO_BORDER;
            celdaImg.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaImg.VerticalAlignment = Element.ALIGN_MIDDLE;
            layout.AddCell(celdaImg);

            // COLUMNA 2: TABLA DE DATOS
            PdfPCell celdaTabla = new PdfPCell(tablaDatos);
            celdaTabla.Border = Rectangle.NO_BORDER;
            celdaTabla.PaddingLeft = 10f;
            layout.AddCell(celdaTabla);

            doc.Add(layout);
        }

        // Helpers para crear las tablas de datos
        private static PdfPTable CrearTablaEstados(List<Reportes.ReporteEstadoUsuarios> datos)
        {
            PdfPTable t = new PdfPTable(3); // Estado, Cantidad, %
            t.WidthPercentage = 100;

            // Headers
            AgregarHeader(t, "Estado");
            AgregarHeader(t, "Clientes");
            AgregarHeader(t, "%");

            foreach (var d in datos)
            {
                AgregarCelda(t, d.Estado);
                AgregarCelda(t, d.CantidadUsuarios.ToString());
                AgregarCelda(t, d.Porcentaje);
            }
            return t;
        }

        private static PdfPTable CrearTablaIngresos(List<Reportes.ReporteIngresos> datos)
        {
            PdfPTable t = new PdfPTable(3); // Plan, Socios, Ingresos
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

        private static PdfPTable CrearTablaAgrupada(dynamic datos)
        {
            // Como viene como dynamic (Lista anónima), lo iteramos con foreach
            PdfPTable t = new PdfPTable(2);
            t.WidthPercentage = 100;

            AgregarHeader(t, "Categoría");
            AgregarHeader(t, "Total");

            foreach (var d in datos)
            {
                // Reflection simple para acceder a propiedades anónimas
                string cat = d.GetType().GetProperty("Categoria").GetValue(d, null);
                decimal tot = d.GetType().GetProperty("Total").GetValue(d, null);

                AgregarCelda(t, cat);
                AgregarCelda(t, $"${tot:N0}");
            }
            return t;
        }

        private static void AgregarHeader(PdfPTable t, string texto)
        {
            PdfPCell c = new PdfPCell(new Phrase(texto, _fontHeader));
            c.BackgroundColor = new BaseColor(50, 50, 50); // Gris oscuro
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