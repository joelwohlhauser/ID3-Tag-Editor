using System.IO;

namespace ID3_Tag_Editor.Logic
{
    public class BasicFunctions
    {
        public static string FormatFileSize(long Length)
        {
            string Unit = " B";
            double Len = Length;

            if (Len >= 1024)
            {
                Len = Length / 1024.00;
                Unit = " KB";
            }

            if (Len >= 1024)
            {
                Len /= 1024.00;
                Unit = " MB";
            }

            return Len.ToString("F2") + Unit;
        }


        public static bool FileInUse(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    if (fs.CanWrite)
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}
