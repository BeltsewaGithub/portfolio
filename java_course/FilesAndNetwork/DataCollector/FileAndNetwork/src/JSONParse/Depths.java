package JSONParse;

public class Depths
{
    private String stationName;
    private String depth;

    public String getStationName()
    {
        return stationName;
    }

    public void setStationName(String stationName)
    {
        this.stationName = stationName;
    }

    public String getDepth()
    {
        return depth;
    }

    public void setDepth(String depth)
    {
        this.depth = depth;
    }

    public Depths(String station_name, String depth)
    {
        this.stationName = station_name;
        this.depth = depth;
    }

    public String toString()
    {
        return (stationName + " " + depth);
    }
}
