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
            string rutaArchivo,
            // 1. Estados
            byte[] imgEstados, List<Reportes.ReporteEstadoUsuarios> datosEstados,
            // 2. Ingresos Detalle
            byte[] imgIngresosDetalle, List<Reportes.ReporteIngresos> datosIngresosDetalle,
            // 3. Ingresos Grupo
            byte[] imgIngresosGrupo, dynamic datosIngresosGrupo,
            // 4. NUEVO: Ejercicios
            byte[] imgEjercicios, List<Reportes.ReporteEjerciciosPopulares> datosEjercicios
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
                doc.Add(new Paragraph("\n"));

                // --- SECCIÓN 2: INGRESOS POR PLAN (DETALLE) ---
                AgregarSeccion(doc, "2. Ingresos Detallados por Plan", imgIngresosDetalle, CrearTablaIngresos(datosIngresosDetalle));
                doc.Add(new Paragraph("\n"));

                // --- SECCIÓN 3: INGRESOS AGRUPADOS (PREMIUM VS BÁSICO) ---
                AgregarSeccion(doc, "3. Resumen: Premium vs Básico", imgIngresosGrupo, CrearTablaAgrupada(datosIngresosGrupo));
                doc.Add(new Paragraph("\n"));

                // --- SECCIÓN 4: TOP EJERCICIOS (NUEVO) ---
                // Agregamos un salto de página si es necesario, o dejamos que fluya
                // doc.NewPage(); // Descomentar si quieres que esto empiece en hoja nueva
                AgregarSeccion(doc, "4. Top Ejercicios Más Solicitados", imgEjercicios, CrearTablaEjercicios(datosEjercicios));

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
            layout.SetWidths(new float[] { 60f, 40f }); // Ajusté un poco: 60% Gráfico, 40% Tabla (mejor para barras horizontales)

            // COLUMNA 1: IMAGEN
            if (imagenBytes != null && imagenBytes.Length > 0)
            {
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagenBytes);
                img.ScaleToFit(450f, 280f); // Aumenté un poco el tamaño permitido para el gráfico de barras
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

        // ----------------------------------------------------------------------
        // HELPERS PARA CREAR TABLAS
        // ----------------------------------------------------------------------

        private static PdfPTable CrearTablaEstados(List<Reportes.ReporteEstadoUsuarios> datos)
        {
            PdfPTable t = new PdfPTable(3);
            t.WidthPercentage = 100;
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

        // NUEVO MÉTODO PARA EJERCICIOS
        private static PdfPTable CrearTablaEjercicios(List<Reportes.ReporteEjerciciosPopulares> datos)
        {
            PdfPTable t = new PdfPTable(2); // Nombre, Cantidad
            t.WidthPercentage = 100;

            // Definir anchos relativos (Nombre más ancho que cantidad)
            t.SetWidths(new float[] { 70f, 30f });

            AgregarHeader(t, "Ejercicio");
            AgregarHeader(t, "Veces Asignado");

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

                // Forma segura de leer propiedades anónimas
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

        // Estilos comunes
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