using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWars.Web.Models
{
    public enum Color
    {
        [Description("Green")]
        Green = 0,
        [Description("Red")]
        Red = 1,
        [Description("Blue")]
        Blue = 2,
        [Description("Yellow")]
        Yellow = 3
    }
}
