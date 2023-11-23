using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCosmetic.Models
{
    public class SummerNote
    {
        public string _name { get; set; }
        public bool _loadLib { get; set; }
        public int height { get; set; }
        public SummerNote(string name)
        {
            this._name = name;
        }
        public SummerNote(string name, string toolbar)
        {
            this._name = name;
            this._toolBar = toolbar;
        }
        public SummerNote(string name, int height, bool load)
        {
            this._name = name;
            this.height = height;
            this._loadLib = load;
        }
        public string _toolBar { get; set; } = @"[
            ['style', ['style']],
            ['font', ['bold', 'underline', 'clear']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['link', 'picture', 'video']],
            ['view', ['fullscreen', 'codeview', 'help']]
        ]";
    }
}
