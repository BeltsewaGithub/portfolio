package SearchingFiles;

import org.apache.commons.io.FilenameUtils;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

public abstract class Searcher {

    protected List<File> action(File dir, String necessaryExt)
    {
        List<File> files = new ArrayList<>();

        if (dir.isDirectory())
        {
            for (File file : dir.listFiles())
            {
                String ext = FilenameUtils.getExtension(file.getName());
                if (necessaryExt.equals(ext))
                    files.add(file);
            }
        }
        return files;
    }

    public abstract List<File> searching(File dir);
}
