using System;
using System.Windows.Forms;
using System.IO;
namespace Aplikasi_Perpus___Server
{
    static class Upload
    {
        static string targetPath = Properties.Settings.Default.defaultPath;
        static string sourceFile;
        public static void copy(string d)
        {
            try
            {
                sourceFile = d;
                string destFile = Path.Combine(targetPath, Path.GetFileName(d));
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                File.Copy(sourceFile, destFile, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        
    }
}
