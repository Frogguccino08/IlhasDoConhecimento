using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(PersonagemSelecionado perso)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Save.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        Info data = new Info(PersonagemSelecionado.instance);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Info Load()
    {
        string path = Application.persistentDataPath + "/Save.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Info data = formatter.Deserialize(stream) as Info;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
