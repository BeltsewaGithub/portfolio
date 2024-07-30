package CSVParse;

import javax.swing.text.DateFormatter;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

public class Dates
{
    private String name;
    private Date date;

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public Date getDate()
    {
        return date;
    }

    public void setDate(Date date)
    {
        this.date = date;
    }

    public Dates(String name, Date date)
    {
        this.name = name;
        this.date = date;
    }

    public String toString()
    {
        SimpleDateFormat formater = new SimpleDateFormat("dd.mm.yyyy");
        return formater.format(date);
    }
}
