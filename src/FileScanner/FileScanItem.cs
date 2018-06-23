using System;

namespace FileScanner
{
    public class FileScanItem
    {
        public int Level { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string FolderPath { get; set; }

        public string FolderName { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastWriteTime { get; set; }

        public decimal Size { get; set; }

        public bool IsReadOnly { get; set; }
    }
}