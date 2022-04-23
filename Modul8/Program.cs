using System;
class MainClass
{
    public static void Main(string[] args)
    {
        string DirName = @"D:\new";
        DirCleaner(DirName);
    }
    static void DirCleaner(string dirName)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if (dirInfo.Exists)
            {
                FileInfo[] fileNames = dirInfo.GetFiles();
                foreach (var item in fileNames)
                {
                    if (item.LastAccessTime.CompareTo(DateTime.Now - TimeSpan.FromMinutes(30)) < 0)
                    {
                        item.Delete();
                    }
                }
                DirectoryInfo[] folderNames = dirInfo.GetDirectories();
                foreach (var item in folderNames)
                {
                    if (item.LastAccessTime.CompareTo(DateTime.Now - TimeSpan.FromMinutes(30)) < 0)
                    {
                        item.Delete(true);
                    }
                }
                Console.WriteLine($"Очистка папки {dirInfo.FullName} от файлов и папок, не использующихся более 30 минут завершена");
            }
            else
            {
                Console.WriteLine($"По указанному адресу директория отсутствует");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
