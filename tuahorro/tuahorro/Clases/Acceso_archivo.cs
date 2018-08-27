using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using tuahorro.objetos;

namespace tuahorro.Clases
{
    public class Acceso_archivo
    {
        public Boolean ExistenciaArchivo(String ruta, String archivo)
        {
            if (!File.Exists(ruta+archivo))
            {
                DirectoryInfo di = Directory.CreateDirectory(ruta);
                StreamWriter file = File.AppendText(ruta+archivo);
                file.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setLog(String msgLog)
        {
            String ruta = @"C:\tuahorro\log\", archivo = "log_" + DateTime.Now.ToString("MM_dd_yyyy") + ".log";

            if (ExistenciaArchivo(ruta,archivo))
            {
                using (StreamWriter file = File.AppendText(ruta+archivo))
                {
                    file.WriteLine("["+ DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "] - "+ msgLog);
                }
            }
        }

        public void CrearUsuario(User usuario)
        {
            String ruta = @"C:\tuahorro\", archivo = "base.xls";
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            

            if (ExistenciaArchivo(ruta, archivo))
            {
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = "Socios";
                xlWorkSheet.Cells[1, 1] = "Nombre";
                xlWorkSheet.Cells[1, 2] = "Cupos";
                xlWorkSheet.Cells[1, 3] = "Fecha";
                xlWorkSheet.Cells[1, 4] = "Estado";
                int row = xlWorkSheet.UsedRange.Rows.Count + 1;
                xlWorkSheet.Cells[row, 1] = usuario.Nombre;
                xlWorkSheet.Cells[row , 2] = usuario.Cupos;
                xlWorkSheet.Cells[row , 3] = usuario.Fecha;
                xlWorkSheet.Cells[row, 4] = usuario.Estado;
                xlWorkBook.SaveAs(ruta + archivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }
            else
            {
                xlWorkBook = xlApp.Workbooks.Open(ruta + archivo, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, false, false);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int row = xlWorkSheet.UsedRange.Rows.Count + 1;
                xlWorkSheet.Cells[row, 1] = usuario.Nombre;
                xlWorkSheet.Cells[row, 2] = usuario.Cupos;
                xlWorkSheet.Cells[row, 3] = usuario.Fecha;
                xlWorkSheet.Cells[row, 4] = usuario.Estado;
                xlWorkBook.SaveAs(ruta + archivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
            }

        } 

        public List<string> ConsultarUsuarios()
        {
            String ruta = @"C:\tuahorro\", archivo = "base.xls";
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Open(ruta + archivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, false, false);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            List<string> columnValue = new List<string>();
            int row = xlWorkSheet.UsedRange.Rows.Count;
            for (int i = 2; i<=row; i++)
            {
                columnValue.Add((string)(xlWorkSheet.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range).Value);
            }
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            return columnValue;
        }
    }
}
