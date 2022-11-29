using Spectre.Console;

namespace D5BF9U.AutoTasks;

public class MyBarchart :IBarChartItem
{
    public string Label { get; set; }
    public double Value { get; set; }
    public Color? Color { get; set; }

    public MyBarchart(string label, double value, Color? color)
    {
        this.Label = label;
        value = value;
        Color = color;
    }
}