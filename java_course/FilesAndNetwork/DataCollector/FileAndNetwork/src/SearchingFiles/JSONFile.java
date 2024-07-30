package SearchingFiles;

import java.io.File;
import java.util.List;

public class JSONFile extends Searcher
{
    private final static String necessaryExt = "json";
    public List<File> searching(File dir)
    {
        return action(dir, necessaryExt);
    }
}
