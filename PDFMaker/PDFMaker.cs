using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFMaker
{
    public enum FileFormat
    {
        TIFF
    }
    public class PDFMaker
    {
        //private Stream GetStream(string filename)
        //{
        //    Stream fs = File.OpenRead(filename);
        //    return fs;
        //}
        //MemoryStream GeneratePDF(MemoryStream fileName, FileFormat fileFormat)
        //{
        //    //TestSharp
        //    //PdfReader reader = new PdfReader(Server.MapPath(P_InputStream2));
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        Document doc = new Document();
        //        MemoryStream memoryStream = new MemoryStream();
        //        PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
        //        doc.Open();
        //        doc.Add(new Paragraph("Some Text"));
        //        writer.CloseStream = false;
        //        doc.Close();
        //        ms.WriteTo();
        //    }
        //}

        //FileStream GeneratePDF(string fileName, FileFormat fileFormat)
        //{
            
        //}
    }
}
