namespace FileExplorer.Models
{
    internal class Folder : FileSystemObject
    {
        internal Folder(string path) : base(path)
        {
        }

        protected Folder(string name, string path) : base(name, path)
        {
        }
    }
}