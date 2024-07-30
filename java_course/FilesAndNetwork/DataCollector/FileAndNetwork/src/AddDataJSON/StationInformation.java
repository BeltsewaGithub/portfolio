package AddDataJSON;

import java.text.SimpleDateFormat;
import java.util.*;

public class StationInformation
{
    private String stationName;
    private String lineName;
    private Boolean hasConnection;
    private Date date;
    private String depth;

    public String getStationName() {
        return stationName;
    }

    public void setStationName(String stationName) {
        this.stationName = stationName;
    }

    public String getLineName() {
        return lineName;
    }

    public void setLineName(String lineName) {
        this.lineName = lineName;
    }

    public Boolean getHasConnection() {
        return hasConnection;
    }

    public void setHasConnection(Boolean hasConnection) {
        this.hasConnection = hasConnection;
    }

    public Date getDate() {
        return date;
    }
    protected String dateToString()
    {
        SimpleDateFormat formater = new SimpleDateFormat("dd.mm.yyyy");
        return formater.format(date);
    }
    public void setDate(Date date) {
        this.date = date;
    }

    public String getDepth() {
        return depth;
    }

    public void setDepth(String depth) {
        this.depth = depth;
    }

    public StationInformation(String stationName, String lineName, Boolean hasConnection, Date date, String depth) {
        this.stationName = stationName;
        this.lineName = lineName;
        this.hasConnection = hasConnection;
        this.date = date;
        this.depth = depth;
    }
    public String toString()
    {
        return stationName + " | " + lineName + " | " + hasConnection + " | " + date + " | " + depth;
    }
}
