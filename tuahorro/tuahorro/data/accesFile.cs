using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace tuahorro.data
{
    public class accesFile
    {
        public void validateFile()
        {
            if (!File.Exists(ruta))
            {
                book = excel.Workbooks.Add();
                book.SaveAs(ruta);
                book.Close();
                excel.Quit();
            }
        }
    }
}
