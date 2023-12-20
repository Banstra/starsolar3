using Ink.Parsed;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SceneSave : MonoBehaviour
{
    [SerializeField] SavedObject[] _objects;
    [SerializeField] InkTestingScript _dialogue;
    private const string _fileName = "_data.json";
    private string _firstFilePath;

    private void Start()
    {
        _firstFilePath = Application.persistentDataPath;
        LoadAll();
    }

    public void SaveAll()
    {
        SaveObjectsData();
        SaveDialogueVariables();
    }

    private void LoadAll()
    {
        LoadSceneData();
        LoadDialogueData();
    }

    private void SaveObjectsData()
    {
        var data = new List<ObjectData>();
        foreach (var obj in _objects)
            data.Add(obj.GetData());
        
        using StreamWriter writer = new(_firstFilePath + SceneManager.GetActiveScene().name + _fileName);
        var json = JsonHelper.ToJson(data.ToArray());
        writer.Write(json);
    }

    private void SaveDialogueVariables()
    {
        var variables = _dialogue.GetDataToSave();

        using StreamWriter writer = new(_firstFilePath + "DialogueVariables" + _fileName);
        writer.Write(variables);
    }

    private void LoadSceneData()
    {
        try
        {
            using StreamReader reader = new(_firstFilePath + SceneManager.GetActiveScene().name + _fileName);
            var data = JsonHelper.FromJson<ObjectData>(reader.ReadToEnd());

            for (int i = 0; i < data.Length; i++)
                _objects[i].LoadData(data[i]);
        }
        catch { Debug.Log("File can`t found"); }
    }

    private void LoadDialogueData()
    {
        try
        {
            using StreamReader reader = new(_firstFilePath + "DialogueVariables" + _fileName);
            var data = reader.ReadToEnd();

            if (data == null) throw new Exception("NoData");

            _dialogue.Load(data);
        }
        catch(Exception ex) { Debug.Log($"File can`t found. {ex.Message}"); }
    }
}
