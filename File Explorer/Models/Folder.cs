namespace FileExplorer.Models
{
    using System.IO;

    using IOPath = System.IO.Path;

    internal class Folder
    {
        internal Folder(string path) : this(IOPath.GetFileName(path), path)
        {
        }

        protected Folder(string name, string path)
        {
            Name = name;
            Path = path;
            IsHidden = new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.Hidden);
        }

        public string Name { get; }

        public string Path { get; }

        public virtual bool IsHidden { get; }
    }
}