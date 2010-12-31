using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tina
{
    public abstract class Template
    {
        protected Template(string file) : this(file, 0)
        {
            
        }

        protected Template(string file, int line)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException("file");
            }
            File = file;
            Line = line;
        }

        public virtual string File
        {
            get;
            protected set;
        }

        public virtual int Line
        {
            get;
            protected set;
        }
    }
}
