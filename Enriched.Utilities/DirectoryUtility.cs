using System;
using System.IO;

namespace Enriched.Utilities
{
    public static class DirectoryUtility
    {
        public static void Copy(string sourceDir, string targetDir, bool overwrite)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)), overwrite);

            foreach (var directory in Directory.GetDirectories(sourceDir))
                Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)), overwrite);
        }

        public static string CreateTempDirectory()
        {
            var tempDirectory = GetTempDirectory();
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }

            return tempDirectory;
        }

        public static void CreateTempDirectory(Action<string> action, bool autoDelete = true)
        {
            var tempDirectory = GetTempDirectory();
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }
            action(tempDirectory);
            if (autoDelete)
            {
                Directory.Delete(tempDirectory, true);
            }
        }

        public static void DeleteReadOnlyDirectory(string directoryPath)
        {
            foreach (var subdirectory in Directory.EnumerateDirectories(directoryPath))
            {
                DeleteReadOnlyDirectory(subdirectory);
            }
            foreach (var fileName in Directory.EnumerateFiles(directoryPath))
            {
                var fileInfo = new FileInfo(fileName);
                fileInfo.Attributes = FileAttributes.Normal;
                fileInfo.Delete();
            }
            Directory.Delete(directoryPath);
        }

        public static string GetDirectoryPath(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }

        public static string GetParentDirectoryPath(string folderPath, int levels)
        {
            string result = folderPath;
            for (int i = 0; i < levels; i++)
            {
                if (Directory.GetParent(result) != null)
                {
                    result = Directory.GetParent(result).FullName;
                }
                else
                {
                    return result;
                }
            }
            return result;
        }

        public static string GetParentDirectoryPath(string folderPath)
        {
            return GetParentDirectoryPath(folderPath, 1);
        }

        public static string GetTempDirectory()
        {
            return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }

        public static bool RenameDirectory(string directoryPath, string newName)
        {
            var path = Path.GetDirectoryName(directoryPath);
            if (path == null)
                return false;
            try
            {
                Directory.Move(directoryPath, Path.Combine(path, newName));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SafeDeleteDirectory(string path, bool recursive = false)
        {
            if (Directory.Exists(path))
            {
                var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                Directory
                    .EnumerateFileSystemEntries(path, "*", searchOption)
                    .ForEach(x => File.SetAttributes(x, FileAttributes.Normal));

                Directory.Delete(path, recursive);
            }
        }
    }
}