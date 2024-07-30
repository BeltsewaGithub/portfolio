package SearchingFiles;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

public class SearchFileInFoldersTree
{
    private List <File> fileList = new ArrayList<>();
    List<Searcher> searchers = new ArrayList<>();
    public void addSearcher(Searcher searcher) {
        searchers.add(searcher);
    }
    public List<File> searching(File dir) throws Exception {
        if (searchers.isEmpty()) throw new Exception();
        return this.visitAllDirsAndFiles(dir);
    }

    private List<File> visitAllDirsAndFiles(File dir)
    {
        for (Searcher searcher : searchers)
        {
            fileList.addAll(searcher.searching(dir));
        }

        if (dir.isDirectory())
        {
            String[] children = dir.list();
            for (int i=0; i<children.length; i++)
            {
                visitAllDirsAndFiles(new File(dir, children[i]));
            }
        }
        return fileList;
    }
}
