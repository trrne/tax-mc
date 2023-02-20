using System.IO;
using UnityEngine;

public class SaveManager
{
    static string filePath = Application.persistentDataPath + "/" + ".savedata.json";

    public static void Save(SaveData.Datas _datas)
    {
        string json = JsonUtility.ToJson(_datas);
        StreamWriter writer = new StreamWriter(filePath);

        writer.Write(json);
        writer.Flush();
        writer.Close();
    }

    public static SaveData.Datas LoadData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(filePath);
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<SaveData.Datas>(datastr);
    }

    /*
    public void Load()
    { 
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData>(data);
        }
    }
    */
}