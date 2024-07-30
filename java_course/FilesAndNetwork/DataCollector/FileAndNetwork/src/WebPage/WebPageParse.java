package WebPage;

import org.jsoup.*;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class WebPageParse
{
    private List<MetroLine> metroLinesList = new ArrayList<>();
    private List<MetroStation> metroStationsList = new ArrayList<>();
    private String url;
    private Document doc;
    public WebPageParse (String url) throws IOException
    {
        this.url = url;
        doc = Jsoup.connect(url).get();
    }

    public List<MetroLine> getMetroLinesList()
    {
        doc.select("div > span")
                .stream()
                .forEach(element -> metroLinesList.add(new MetroLine(element.text(), element.attr("data-line"))));
        return metroLinesList;
    }

    public List<MetroStation> getMetroStationsList()
    {
        String currentLine;
        for(Element element : doc.select("div"))
        {
            currentLine = element.attr("data-line");
            if(!currentLine.equals("")) {
                String finalCurrentLine = currentLine;
                element.getElementsByTag("p")
                        .stream()
                        .forEach(elem ->
                        {
                            Boolean hasConn;
                            if (elem.getElementsByTag("span").attr("title").equals(""))
                                hasConn = false;
                            else
                                hasConn = true;
                            metroStationsList.add(new MetroStation(elem.text(), finalCurrentLine, hasConn));
                        });
            }
        }
        return metroStationsList;
    }
}

