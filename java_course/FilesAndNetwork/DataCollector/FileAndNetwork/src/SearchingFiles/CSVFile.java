package SearchingFiles;

import java.io.File;
import java.util.List;

public class CSVFile extends Searcher
{
    private final static String necessaryExt = "csv";
    public List<File> searching(File dir) {
        return action(dir, necessaryExt);
    }
}
