using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace WebCosmetic.Models
{
    public class ImagePath
    {
        public string _folder { get; set; }
        public List<string> _imageFullPath { get; set; }

        public List<string> collectAllImagePath()
        {
            var getAllFiles = Directory.GetFiles(this._folder);
            this._imageFullPath = new List<string>(getAllFiles.Count());
            foreach(var image in getAllFiles)
            {
                this._imageFullPath.Add(Path.GetFileName(image));
            }
            return this._imageFullPath;
        }
    }
}
