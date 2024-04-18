using System.Text.Json;
using System.Text;

namespace MainApp;

public class FilesData
{
    public string dir;
    public List<string> files;
    public List<FilesData> folders;
    public bool hacked;

    public FilesData(string dir, List<string> files, List<FilesData> folders, bool hacked)
    {
        this.dir = dir;
        this.files = files;
        this.folders = folders;
        this.hacked = hacked;
    }
}

public static partial class SolutionsClass
{
    static partial void Task5()
    {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        int t = Convert.ToInt32(input.ReadLine());
        for (int i = 0; i < t; ++i)
        {
            int k = Convert.ToInt32(input.ReadLine());
            StringBuilder curJsonData = new StringBuilder();
            for (int j = 0; j < k; ++j)
            {
                string trimedJsonLine = input.ReadLine()!.Trim(new char[2] { ' ', '\n' });
                curJsonData.Append(trimedJsonLine);
            }

            JsonDocumentOptions options = new JsonDocumentOptions
            {
                MaxDepth = 1000
            };
            using (JsonDocument document = JsonDocument.Parse(curJsonData.ToString(), options))
            {
                JsonElement root = document.RootElement;
                FilesData test = JsonProcessingClass.DeserializeJsonObject(root);
                Console.WriteLine(JsonProcessingClass.countHacks);
                JsonProcessingClass.countHacks = 0;
            }
        }
    }
}

public static class JsonProcessingClass
{
    public static int countHacks = 0;

    public static FilesData DeserializeJsonObject(JsonElement root, bool hacked = false)
    {
        string dir;
        List<string> files = new List<string>();
        List<FilesData> folders = new List<FilesData>();

        dir = root.GetProperty("dir").GetString()!;

        bool haveFiles = root.TryGetProperty("files", out JsonElement lstFiles);
        if (haveFiles)
        {
            foreach (JsonElement file in lstFiles.EnumerateArray())
            {
                files.Add(file.GetString()!);
            }
        }

        for (int i = 0; i < files.Count; ++i)
        {
            if (files[i].Split('.')[^1] == "hack")
            {
                hacked = true;
                break;
            }
        }

        if (hacked) { countHacks += files.Count; }

        bool haveFolders = root.TryGetProperty("folders", out JsonElement lstFoldersObj);
        if (haveFolders)
        {
            foreach (JsonElement innerDir in lstFoldersObj.EnumerateArray())
            {
                folders.Add(DeserializeJsonObject(innerDir, hacked));
            }
        }

        return new FilesData(dir, files, folders, hacked);
    }
}