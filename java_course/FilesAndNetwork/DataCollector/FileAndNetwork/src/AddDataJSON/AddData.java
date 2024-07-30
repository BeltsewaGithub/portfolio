package AddDataJSON;

import CSVParse.CSVParse;
import CSVParse.Dates;
import JSONParse.Depths;
import JSONParse.JSONParse;
import SearchingFiles.CSVFile;
import SearchingFiles.JSONFile;
import SearchingFiles.SearchFileInFoldersTree;
import WebPage.MetroLine;
import WebPage.MetroStation;
import WebPage.WebPageParse;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import java.io.File;
import java.io.FileWriter;
import java.text.SimpleDateFormat;
import java.util.*;

public class AddData
{
    private String path;
    private String url;
    public AddData(String path, String url) //"https://skillbox-java.github.io/"
    {
        this.path = path;
        this.url = url;
    }

    public void addMetroStations() throws Exception
    {
        File f = new File(path);
        WebPageParse webParsing = new WebPageParse(url);
        JSONObject jsonObjectStationsBlock = new JSONObject();

        List<MetroStation> metroStationsList = webParsing.getMetroStationsList();

        //объект со станциями метро
        JSONObject jsonObjectStationsByLines = new JSONObject();
        String currentLine = metroStationsList.getFirst().getLineNumber();
        List<String> currentLineStations = new ArrayList<>();
        for (MetroStation ms : webParsing.getMetroStationsList())
        {
            if (ms.getLineNumber().equals(currentLine))
            {
                currentLineStations.add(ms.getStationName());
            }
            else
            {
                jsonObjectStationsByLines.put(currentLine, currentLineStations);
                currentLine = ms.getLineNumber();
                currentLineStations = new ArrayList<>();
                currentLineStations.add(ms.getStationName());
            }
        }

        //объект с линиями метро
        List<MetroLine> metroLinesList = webParsing.getMetroLinesList();
        JSONArray jsonArr = new JSONArray();
        for (MetroLine ml : metroLinesList)
        {
            JSONObject jsonObjectLine = new JSONObject();
            jsonObjectLine.put("number", ml.getLineNumber());
            jsonObjectLine.put("name", ml.getLineName());
            jsonArr.add(jsonObjectLine);
        }

        //запись в json
        jsonObjectStationsBlock.put("stations", jsonObjectStationsByLines);
        jsonObjectStationsBlock.put("lines", jsonArr);

        FileWriter fwriter = new FileWriter(f);
        fwriter.write(jsonObjectStationsBlock.toJSONString());
        fwriter.flush();
        fwriter.close();
    }

    public void addStations() throws Exception
    {
        File f = new File("stations.json");
        WebPageParse webParsing = new WebPageParse(url);
        File path = new File("E:/работа на Java/Java/FilesAndNetwork/DataCollector/FileAndNetwork/sourses/data");

        //список название станции - номер ветки - имеет ли переход
        List<MetroStation> metroStationsList = webParsing.getMetroStationsList();

        //список название ветки - номер ветки
        List<MetroLine> metroLines = webParsing.getMetroLinesList();

        //список название станции -  дата открытия
        List<Dates> dates = new ArrayList<>();
        SearchFileInFoldersTree sf = new SearchFileInFoldersTree();
        CSVParse csvParser = new CSVParse();
        sf.addSearcher(new CSVFile());
        for(File file : sf.searching(path))
        {
            csvParser.parse(file.getPath())
                    .stream()
                    .forEach(el ->
                            {
                                if (!dates.contains(el))
                                    dates.add(el);
                            });
        }

        //список название станции - глубина
        List<Depths> depths = new ArrayList<>();
        JSONParse jsonParser = new JSONParse();
        SearchFileInFoldersTree sf1 = new SearchFileInFoldersTree();
        sf1.addSearcher(new JSONFile());
        for(File file : sf1.searching(path))
        {
            jsonParser.parse(file)
                    .stream()
                    .forEach(el ->
                    {
                        if (!depths.contains(el))
                            depths.add(el);
                    });
        }

        List<StationInformation> stations = new ArrayList<>();
        for (MetroStation ms : metroStationsList)
        {
            char dot = '.';
            int index = 0;
            String stationName = ms.getStationName();
            for (char ch : ms.getStationName().toCharArray())
            {
                if (ch == dot)
                {
                    index = stationName.indexOf(ch);
                    break;
                }

            }
            stationName = stationName.substring(index+2, stationName.length());

            String lineName = null;
            String depth = null;
            Date date = null;

            for (MetroLine ml : metroLines)
            {
                if(ms.getLineNumber().equals(ml.getLineNumber()))
                    lineName = ml.getLineName();
            }

            for (Depths dpth : depths)
            {
                if(stationName.equals(dpth.getStationName()))
                    depth = dpth.getDepth();
            }
            for (Dates date1 : dates)
            {
                if(stationName.equals(date1.getName()))
                    date = date1.getDate();
            }

            stations.add(new StationInformation(stationName, lineName, ms.getHasConnecion(), date, depth));
        }

        //запись в файл
        FileWriter fwriter = new FileWriter(f);
        JSONObject block = new JSONObject();
        JSONArray arr = new JSONArray();
        for (StationInformation si : stations)
        {
            JSONObject station = new JSONObject();
            station.put("name", si.getStationName());
            station.put("line", si.getLineName());
            if (si.getDate() != null)
                station.put("date",si.dateToString());
            if (si.getDepth() != null)
                station.put("depth", si.getDepth());
            station.put("has connection", si.getHasConnection());

            arr.add(station);
            block.put("stations", arr);
            fwriter.write(block.toJSONString());
            arr = new JSONArray();
        }

        fwriter.flush();
        fwriter.close();

    }

}