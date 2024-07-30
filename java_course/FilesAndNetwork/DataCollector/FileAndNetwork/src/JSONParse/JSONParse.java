package JSONParse;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class JSONParse
{
    List<Depths> depthsList = new ArrayList<>();
    public List<Depths> parse(File fileName)
    {
        JSONParser parser = new JSONParser();
        try (FileReader reader = new FileReader(fileName))
        {
            JSONArray jsonArray = (JSONArray) parser.parse(reader);
            String stationName;
            String depth;
            for (Object obj : jsonArray)
            {
                JSONObject jsonObj = (JSONObject) obj;

                stationName = (String) jsonObj.get("station_name");
                depth= (String) jsonObj.get("depth");
                depthsList.add(new Depths(stationName, depth));
            }
            return depthsList;
        }
        catch (IOException | ParseException e)
        {
            System.out.println("Parsing Error " + e.toString());
        }
        return null;
    }
}
