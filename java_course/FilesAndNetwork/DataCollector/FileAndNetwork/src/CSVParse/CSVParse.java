package CSVParse;

import com.opencsv.CSVReader;

import java.io.*;
import java.text.SimpleDateFormat;
import java.util.*;

public class CSVParse
{
    List<Dates> dates = new ArrayList<>();
    public List<Dates> parse(String path) throws Exception {

        try {
            FileReader fr = new FileReader(path);

            CSVReader csvReader = new CSVReader(fr);
            String[] nextRecord;
            int inx = 0;
            int index = 0;
            while ((nextRecord = csvReader.readNext()) != null)
            {
                String[] date = new String[2];
                for (String cell : nextRecord)
                {
                    if (index == 0)
                    {
                        date[0] = cell;
                        index = 1;
                    }
                    else if (index == 1)
                    {
                        date[1] = cell;
                        index = 0;
                    }
                }
                if (inx != 0) dates.add(new Dates(date[0], new SimpleDateFormat("dd.mm.yyyy", Locale.ENGLISH).parse(date[1])));
                inx++;
                date = new String[2];
            }
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        return dates;
    }
}
