string folderPath = @"C:\Users\tamer\Рабочий стол\folder";

try
{
    long Sizefolder = SizeFolder(folderPath);
    Console.WriteLine($"Размер папки {folderPath}: {Sizefolder} байт");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

static long SizeFolder(string folderPath)
{
    long Sizefolder = 0;
    DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
    if (!directoryInfo.Exists)
    {
        throw new DirectoryNotFoundException($"Папка {folderPath} не найдена");
    }
    FileInfo[] files = directoryInfo.GetFiles();
    foreach (FileInfo file in files)
    {
        Sizefolder += file.Length;
    }

    DirectoryInfo[] subDirs = directoryInfo.GetDirectories();
    foreach (DirectoryInfo subDir in subDirs)
    {
        Sizefolder += SizeFolder(subDir.FullName);
    }
    return Sizefolder;
}