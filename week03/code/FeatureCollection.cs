public class FeatureCollection
{
    public Feature[] Features { get; set; } = [];
}

public class Feature
{
    public Properties Properties { get; set; } = new();
}

public class Properties
{
    public string Place { get; set; } = string.Empty;
    public double? Mag { get; set; }
}