using System;

namespace FileCms.Models
{
    [Serializable()]
    public class CustomFile
    {
        public string Path { get; set; }
        public string Type { get; set; }
    }
}