using UnityEngine;

public class ObjectSaving
{
    public void Save(string key, object @object)
    {
        string json = JsonUtility.ToJson(@object);
        PlayerPrefs.SetString(key, json);
    }
}