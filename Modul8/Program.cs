using System;
class MainClass
{
    public static void Main(string[] args)
    {
        string DirName = @"qwerty";
        DirCleaner(DirName);
    }
    static void DirCleaner(string dirName) 
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if (dirInfo.Exists)
            {
                DirectoryInfo[] folderNames = dirInfo.GetDirectories();
                foreach (var item in folderNames) 
                {
                    if (item.LastAccessTime.CompareTo(DateTime.Now - TimeSpan.FromMinutes(30)) < 0) 
                    {
                        item.Delete(true);
                    }
                }
                FileInfo[] fileNames = dirInfo.GetFiles();
                foreach (var item in fileNames)
                {
                    if (item.LastAccessTime.CompareTo(DateTime.Now - TimeSpan.FromMinutes(30)) < 0)
                    {
                        item.Delete();
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        //Console.WriteLine($"Очистка папки {dirName} от файлов и папок, не использующихся более 30 минут завершена");
    }
}
