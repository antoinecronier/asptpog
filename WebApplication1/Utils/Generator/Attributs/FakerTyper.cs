using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Utils.Generator.Attributs
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Property)]
    public class FakerTyper : System.Attribute
    {
        public TypeEnumCustom Typer { get; set; }

        public FakerTyper(TypeEnumCustom type)
        {
            this.Typer = type;
        }
    }
}
