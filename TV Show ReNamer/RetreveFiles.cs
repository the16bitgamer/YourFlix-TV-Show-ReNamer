using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TV_Show_ReNamer
{
    class RetreveFiles
    {
        public List<VideoStruct> RetreveFilesFromFolder(string FolderLocation)
        {
            List<VideoStruct> listOfVideos = new List<VideoStruct>();
            
            if(Directory.Exists(FolderLocation))
            {
                var files = Directory.GetFiles(FolderLocation);
                foreach(var file in files)
                {
                    if (Path.GetExtension(file) == ".mp4" || Path.GetExtension(file) == ".m4v" || Path.GetExtension(file) == ".ogg")
                    {
                        VideoStruct newVideo = new VideoStruct(file);
                        listOfVideos.Add(newVideo);
                    }
                }
            }

            return listOfVideos;
        }
    }
}
