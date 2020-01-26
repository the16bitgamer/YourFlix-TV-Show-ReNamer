using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TV_Show_ReNamer
{
    class VideoRetitler
    {
        public bool RenameVideos(List<VideoStruct> videos, string fileTag, ProgressBar PB)
        {
            PB.Minimum = 0;
            PB.Maximum = videos.Count;
            foreach (var video in videos)
            {
                ChangeVideoTitle(video.FileLocation, fileTag + video.Name);

                if(video.isRenamed)
                {
                    RenameVideo(video.FileLocation, video.FileName);
                }

                PB.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate (){ PB.Value++; }));
            }
            return true;
        }

        private void ChangeVideoTitle(string fileLoc, string newTitle)
        {
            TagLib.File videoFile = TagLib.File.Create(fileLoc);
            videoFile.Tag.Title = newTitle;
            videoFile.Save();
        }

        private void RenameVideo(string currLoc, string newTitle)
        {
            string fileLoc = Path.GetDirectoryName(currLoc)+"\\";
            var fileExt = Path.GetExtension(currLoc);

            File.Move(currLoc, fileLoc + newTitle + fileExt);
        }
    }
}
