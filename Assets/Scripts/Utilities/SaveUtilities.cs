using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveUtilities
{
    public static void SaveData(string json)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GameSettingsUtilities.Path, FileMode.Create);

        formatter.Serialize(stream, json);
        stream.Close();
    }

    public static string LoadData()
    {
        if (File.Exists(GameSettingsUtilities.Path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(GameSettingsUtilities.Path, FileMode.Open);

            string data = formatter.Deserialize(stream) as string;
            stream.Close();

            return data;
        }
        else
        {
            UnityEngine.Debug.Log("Save file is not found on:" + GameSettingsUtilities.Path);
            return null;
        }
    }

    public static void DeleteData()
    {
        if (File.Exists(GameSettingsUtilities.Path))
        {
            File.Delete(GameSettingsUtilities.Path);
        }
        else
        {
            UnityEngine.Debug.LogWarning($"Save file not found: {GameSettingsUtilities.Path}");
        }
    }

    public static bool IsExist()
    {
        return File.Exists(GameSettingsUtilities.Path);
    }
}
