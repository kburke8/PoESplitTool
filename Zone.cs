public class Zone
{
    public string Name { get; set; }
    public int Act { get; set; }
    public bool IsCity { get; set; }
    public bool HasWaypoint { get; set; }
    public bool IsBossArea { get; set; }
    public string Notes { get; set; }
    public Zone(string name, int act, bool isCity, bool hasWaypoint, bool isBossArea, string notes = null)
    {
        Name = name;
        Act = act;
        IsCity = isCity;
        HasWaypoint = hasWaypoint;
        IsBossArea = isBossArea;
        Notes = notes;
    }
}
