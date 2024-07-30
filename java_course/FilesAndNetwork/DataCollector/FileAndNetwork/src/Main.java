import AddDataJSON.AddData;
import CSVParse.CSVParse;
import SearchingFiles.CSVFile;
import SearchingFiles.JSONFile;
import SearchingFiles.SearchFileInFoldersTree;
import WebPage.WebPageParse;
import JSONParse.JSONParse;

import java.io.File;
import java.io.IOException;

public class Main
{
    public static void main(String[] args) throws Exception
    {
       webParsingTask();
    }

    public static void webParsingTask() throws IOException
    {
        WebPageParse testWebParsing = new WebPageParse("https://skillbox-java.github.io/");
        System.out.println(testWebParsing.getMetroLinesList());
        System.out.println(testWebParsing.getMetroStationsList());
    }

    public static void searchingTask() throws Exception {
        File path = new File("E:/работа на Java/Java/FilesAndNetwork/DataCollector/FileAndNetwork/sourses/data");
        SearchFileInFoldersTree sf = new SearchFileInFoldersTree();
        sf.addSearcher(new CSVFile());
        sf.addSearcher(new JSONFile());
        sf.searching(path).stream().forEach(System.out::println);
    }

    public  static void CSVparsing() throws Exception {
        CSVParse csv = new CSVParse();
        csv.parse("E:/работа на Java/Java/FilesAndNetwork/DataCollector/FileAndNetwork/sourses/data/9/6/dates-3.csv")
                .stream()
                .forEach(el -> System.out.println(el.toString()));
    }

    public static void JSONparsing()
    {
        JSONParse parser = new JSONParse();
        File fileName = new File("E:/работа на Java/Java/FilesAndNetwork/DataCollector/FileAndNetwork/sourses/data/2/4/depths-1.json");
        parser.parse(fileName)
                .stream()
                .forEach(depth -> System.out.println(depth.toString()));
    }

    public static void addDataTask() throws Exception {
        AddData add = new AddData("stations.json", "https://skillbox-java.github.io/");
        add.addStations();
    }
}