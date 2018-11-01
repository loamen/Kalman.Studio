using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Kalman.Command;
using ICSharpCode.TextEditor.Util;
using iTextSharp.text.rtf;
using iTextSharp.text.html;
using Kalman.Data.SchemaObject;
using Kalman.Data;
using Kalman.PdmParser;

namespace Kalman.Studio
{
    public class iTextExporter
    {
        enum ExportTyep
        {
            PDF = 0,
            RTF = 1,
            HTML = 2
        }

        string fileName = string.Empty;
        Table t = null;
        BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\STSONG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font;

        public iTextExporter(string path)
        {
            fileName = path;

            //如果不使用CID字体，下面三行不需要
            //BaseFont.AddToResourceSearch("iTextAsian-1.0.dll");
            //BaseFont.AddToResourceSearch("iTextAsianCmaps-1.0.dll");
            //BaseFont baseFont = BaseFont.CreateFont("STSong-Light", "UniGB-UCS2-H", BaseFont.EMBEDDED);

            //BaseFont baseFont = BaseFont.CreateFont("C:\\WINDOWS\\FONTS\\SIMHEI.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\STSONG.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            font = new Font(baseFont, 12);
        }

        public void PDModel2Pdf(IList<PDTable> tableList, string title)
        {
            Export(tableList, title, ExportTyep.PDF);
        }

        public void PDModel2Rtf(IList<PDTable> tableList, string title)
        {
            Export(tableList, title, ExportTyep.RTF);
        }

        //public void PDModel2Html(PDModel m)
        //{
        //    Export(m, ExportTyep.HTML);
        //}

        private void Export(IList<PDTable> tableList, string title, ExportTyep exportType)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
            DocWriter w;

            switch (exportType)
            {
                case ExportTyep.PDF:
                    w = PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create, FileAccess.Write));
                    break;
                case ExportTyep.RTF:
                    w = RtfWriter2.GetInstance(doc, new FileStream(fileName, FileMode.Create, FileAccess.Write));
                    break;
                case ExportTyep.HTML:
                    w = HtmlWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create, FileAccess.Write));
                    break;
                default:
                    break;
            }

            doc.Open();
            doc.NewPage();

            //IList<PDTable> tableList = m.AllTableList;

            //Chapter cpt = new Chapter(m.Name, 1);
            Chapter cpt = new Chapter(title, 1);
            Section sec;

            //doc.AddTitle(m.Name);
            doc.AddTitle(title);
            doc.AddAuthor("Kalman");
            doc.AddCreationDate();
            doc.AddCreator("Kalman");
            doc.AddSubject("PDM数据库文档");

            foreach (PDTable table in tableList)
            {
                sec = cpt.AddSection(new Paragraph(string.Format("{0}[{1}]", table.Name, table.Code), font));

                if (string.IsNullOrEmpty(table.Comment) == false)
                {
                    Chunk chunk = new Chunk(table.Comment, font);
                    sec.Add(chunk);
                }

                t = new Table(9, table.ColumnList.Count);

                //t.Border = 15;
                //t.BorderColor = Color.BLACK;
                //t.BorderWidth = 1.0f;
                t.AutoFillEmptyCells = true;
                t.CellsFitPage = true;
                t.TableFitsPage = true;
                t.Cellpadding = 3;
                //if (exportType == ExportTyep.PDF) t.Cellspacing = 2;
                t.DefaultVerticalAlignment = Element.ALIGN_MIDDLE;

                t.SetWidths(new int[] { 200, 200, 150, 50, 50, 50, 50, 50, 300 });

                t.AddCell(BuildHeaderCell("名称"));
                t.AddCell(BuildHeaderCell("代码"));
                t.AddCell(BuildHeaderCell("数据类型"));
                t.AddCell(BuildHeaderCell("长度"));
                t.AddCell(BuildHeaderCell("精度"));
                t.AddCell(BuildHeaderCell("主键"));
                t.AddCell(BuildHeaderCell("外键"));
                t.AddCell(BuildHeaderCell("可空"));
                t.AddCell(BuildHeaderCell("注释"));

                foreach (PDColumn column in table.ColumnList)
                {
                    t.AddCell(BuildCell(column.Name));
                    t.AddCell(BuildCell(column.Code));
                    t.AddCell(BuildCell(column.DataType));
                    t.AddCell(BuildCell(column.Length == 0 ? "" : column.Length.ToString()));
                    t.AddCell(BuildCell(column.Precision == 0 ? "" : column.Precision.ToString()));
                    t.AddCell(BuildCell(column.IsPK ? " √" : ""));
                    t.AddCell(BuildCell(column.IsFK ? " √" : ""));
                    t.AddCell(BuildCell(column.Mandatory ? "" : " √"));
                    t.AddCell(BuildCell(column.Comment));
                }

                sec.Add(t);
            }

            doc.Add(cpt);
            doc.Close();
        }

        private Cell BuildHeaderCell(string title)
        {
            Phrase phrase = new Phrase(title, font);
            Cell cell = new Cell(phrase);
            cell.Header = true;
            cell.BackgroundColor = Color.LIGHT_GRAY;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 15;
            //cell.BorderWidth = 0.2f;
            //cell.BorderColor = Color.BLACK;
            return cell;
        }

        Cell BuildCell(string text)
        {
            Phrase phrase = new Phrase(text, font);
            Cell cell = new Cell(phrase);
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell.Border = 15;
            //cell.BorderWidth = 0.2f;
            //cell.BorderColor = Color.BLACK;

            return cell;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="dbName"></param>
        /// <param name="tableList">若该参数为null，则通过DbSchema对象来获取表列表</param>
        public void DbSchema2Pdf(DbSchema schema, SODatabase db, List<SOTable> tableList)
        {
            tableList = Export(schema, db, tableList, ExportTyep.PDF);
        }

        public void DbSchema2Html(DbSchema schema, SODatabase db, List<SOTable> tableList)
        {
            tableList = Export(schema, db, tableList, ExportTyep.HTML);
        }

        public void DbSchema2Rtf(DbSchema schema, SODatabase db, List<SOTable> tableList)
        {
            tableList = Export(schema, db, tableList, ExportTyep.RTF);
        }

        private List<SOTable> Export(DbSchema schema, SODatabase db, List<SOTable> tableList, ExportTyep exportType)
        {
            if (schema == null) throw new ArgumentException("参数schema不能为空", "schema");
            if (db == null) throw new ArgumentException("参数dbName不能为空", "dbName");

            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
            DocWriter w;

            switch (exportType)
            {
                case ExportTyep.PDF:
                    w = PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create, FileAccess.Write));
                    break;
                case ExportTyep.RTF:
                    w = RtfWriter2.GetInstance(doc, new FileStream(fileName, FileMode.Create, FileAccess.Write));
                    break;
                case ExportTyep.HTML:
                    w = HtmlWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create, FileAccess.Write));
                    break;
                default:
                    break;
            }

            doc.Open();
            doc.NewPage();

            if (tableList == null) tableList = schema.GetTableList(db);

            Chapter cpt = new Chapter(db.Name, 1);
            Section sec;
            #region
            if (exportType != ExportTyep.HTML)
            {
                doc.AddTitle(db.Name);
                doc.AddAuthor("Kalman");
                doc.AddCreationDate();
                doc.AddCreator("Kalman");
                doc.AddSubject("数据库文档");
            }

            foreach (SOTable table in tableList)
            {
                sec = cpt.AddSection(new Paragraph(table.Name, font));

                if (string.IsNullOrEmpty(table.Comment) == false)
                {
                    Chunk chunk = new Chunk(table.Comment, font);
                    sec.Add(chunk);
                }

                List<SOColumn> columnList = schema.GetTableColumnList(table);

                t = new Table(7, columnList.Count);

                t.AutoFillEmptyCells = true;
                t.CellsFitPage = true;
                t.TableFitsPage = true;
                t.Cellpadding = 3;
                //if (exportType == ExportTyep.PDF) t.Cellspacing = 2;
                t.DefaultVerticalAlignment = Element.ALIGN_MIDDLE;

                t.SetWidths(new int[] { 200, 150, 50, 50, 50, 100, 300 });

                t.AddCell(BuildHeaderCell("名称"));
                t.AddCell(BuildHeaderCell("数据类型"));
                t.AddCell(BuildHeaderCell("主键"));
                t.AddCell(BuildHeaderCell("标志"));
                t.AddCell(BuildHeaderCell("可空"));
                t.AddCell(BuildHeaderCell("默认值"));
                t.AddCell(BuildHeaderCell("注释"));

                foreach (SOColumn column in columnList)
                {
                    t.AddCell(BuildCell(column.Name));
                    t.AddCell(BuildCell(GetDbColumnType(column)));
                    t.AddCell(BuildCell(column.PrimaryKey ? " √" : ""));
                    t.AddCell(BuildCell(column.Identify ? " √" : ""));
                    t.AddCell(BuildCell(column.Nullable ? " √" : ""));
                    t.AddCell(BuildCell(column.DefaultValue == null ? "" : column.DefaultValue.ToString()));
                    t.AddCell(BuildCell(column.Comment));
                }

                sec.Add(t);
            }

            doc.Add(cpt);
            doc.Close();
            #endregion
            return tableList;
        }

        string GetDbColumnType(SOColumn c)
        {
            string s = c.NativeType;

            if (c.Length == -1) return s;

            switch (c.DataType)
            {
                case System.Data.DbType.AnsiString:
                case System.Data.DbType.AnsiStringFixedLength:
                case System.Data.DbType.String:
                case System.Data.DbType.StringFixedLength:
                    //s = string.Format("{0}({1})", c.NativeType, c.NativeType.StartsWith("n") ? c.Size / 2 : c.Size);
                    s = string.Format("{0}({1})", c.NativeType, c.Length);
                    break;
                case System.Data.DbType.Currency:
                case System.Data.DbType.Decimal:
                case System.Data.DbType.Single:
                    s = string.Format("{0}({1}, {2})", c.NativeType, c.Precision, c.Scale);
                    break;
                default:
                    s = c.NativeType;
                    break;
            }

            return s;
        }
    }
}
