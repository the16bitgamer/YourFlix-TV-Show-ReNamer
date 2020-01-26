using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TV_Show_ReNamer
{
    class FindFolder
    {
        FolderBrowserDialog diag;
        public FindFolder(string defaultFileLocation)
        {
            diag = new FolderBrowserDialog();
            diag.SelectedPath = defaultFileLocation;
            diag.ShowNewFolderButton = false;
            diag.Description = "Select TV Season to Edit";
        }

        public string SelectFolder()
        {
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return diag.SelectedPath;  //selected folder path
            }
            return string.Empty;
        }
    }        
}
