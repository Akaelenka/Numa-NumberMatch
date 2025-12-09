using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveUtilities
{
    public static void SaveData(string path, string json)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, json);
        stream.Close();
    }

    public static string LoadData(string path)
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string data = formatter.Deserialize(stream) as string;
            stream.Close();

            return data;
        }
        else
        {
            UnityEngine.Debug.Log("Save file is not found on:" + path);
            return null;
        }
    }

    public static void DeleteData(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            UnityEngine.Debug.LogWarning($"Save file not found: {path}");
        }
    }

    public static bool IsExist(string path)
    {
        return File.Exists(path);
    }
}
