namespace TV_Show_ReNamer
{
    public class VideoStruct
    {
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }

        public bool isRenamed
        {
            get
            {
                return ProcessFileName(FileLocation) != FileName;
            }
        }

        public VideoStruct(string fileName)
        {
            FileLocation = fileName;
            FileName = ProcessFileName(fileName);
            Name = FileName;
        }
        public VideoStruct(string fileLocation, string videoName)
        {
            FileLocation = fileLocation;
            FileName = fileLocation;
            Name = videoName;
        }

        private string ProcessFileName(string oldName)
        {
            //Getting the filename from the file location
            var newName = oldName.Split('\\');
            string videoName = newName[newName.Length - 1];

            //Removing extention
            for (int i = videoName.Length - 1; i >= 0; i--)
            {
                if (videoName[i] == '.')
                {
                    videoName = videoName.Remove(i);
                    break;
                }
            }
            return videoName;
        }
    }
}
