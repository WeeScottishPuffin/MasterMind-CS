using System;
namespace MasterMind;

public class Colours
{
    public static Dictionary<string,string> ColourPairs()
    {
        Dictionary<string, string> _colourMap = new Dictionary<string, string>(6);
        _colourMap.Add("r", "\u001B[1m\u001B[31mo\u001B[0m");
        _colourMap.Add("y", "\u001B[1m\u001B[33mo\u001B[0m");
        _colourMap.Add("g", "\u001B[1m\u001B[32mo\u001B[0m");
        _colourMap.Add("b", "\u001B[1m\u001B[34mo\u001B[0m");
        _colourMap.Add("m", "\u001B[1m\u001B[35mo\u001B[0m");
        _colourMap.Add("c", "\u001B[1m\u001B[36mo\u001B[0m");
        return _colourMap;
    }
}
