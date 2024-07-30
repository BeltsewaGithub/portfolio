package WebPage;

public class MetroStation
{
    private String stationName;
    private String lineNumber;
    private Boolean hasConnecion;

    public Boolean getHasConnecion()
    {
        return hasConnecion;
    }
    public void setHasConnecion(Boolean hasConnecion)
    {
        this.hasConnecion = hasConnecion;
    }
    public MetroStation (String stationName, String lineNumber, Boolean hasConnection)
    {
        this.stationName = stationName;
        this.lineNumber = lineNumber;
        this.hasConnecion = hasConnection;
    }
    public String getStationName() {
        return stationName;
    }

    public void setStationName(String stationName) {
        this.stationName = stationName;
    }

    public String getLineNumber() {
        return lineNumber;
    }

    public void setLineNumber(String lineNumber) {
        this.lineNumber = lineNumber;
    }
    public String toString()
    {
        return (stationName + " - " + lineNumber + "|has connection = " + hasConnecion);
    }
}
