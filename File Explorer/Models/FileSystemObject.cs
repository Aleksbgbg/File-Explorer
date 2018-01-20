namespace FileExplorer.Models
{
    using System.IO;

    using IOPath = System.IO.Path;

    internal abstract class FileSystemObject
    {
        protected FileSystemObject(string path) : this(IOPath.GetFileName(path), path)
        {
        }

        protected FileSystemObject(string name, string path)
        {
            Name = name;
            Path = path;
            IsHidden = new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
        }

        public string Name { get; }

        public string Path { get; }

        public bool IsHidden { get; }
    }
}