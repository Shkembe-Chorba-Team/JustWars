namespace JustWars.Web.Models
{
    using System.ComponentModel;

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
