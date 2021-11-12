using System.IO;
using System.Linq;

namespace Enriched.Utilities
{
    public static class PathUtility
    {
        public static string GetDirectoryName(string path)
        {
            if (IsDirectory(path).HasValue)
                return Path.GetFullPath(path).Split(Path.DirectorySeparatorChar).LastOrDefault();
            var newPath = Path.GetDirectoryName(path);
            return Path.GetFullPath(newPath ?? string.Empty).Split(Path.DirectorySeparatorChar).LastOrDefault();
        }

        public static string GetFilePathWithoutExtension(string path)
        {
            return Path.ChangeExtension(path, null);
        }

        public static string GetFullPathWithoutExtension(string path)
        {
            return Path.Combine(Path.GetDirectoryName(path) ?? string.Empty, Path.GetFileNameWithoutExtension(path));
        }

        // Null means there is no file or directory with this path
        public static bool? IsDirectory(string path)
        {
            if (Directory.Exists(path))
                return true;
            if (File.Exists(path))
                return false;
            return null;
        }

        // Null means there is no file or directory with this path
        public static bool? IsFile(string path)
        {
            var isDir = IsDirectory(path);
            return isDir == null ? null : !isDir;
        }
    }
}