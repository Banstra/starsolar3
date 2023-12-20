using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueVariables
{
    private Dictionary<string, Ink.Runtime.Object> _variables;
    private readonly Story _variablesStory;
    public DialogueVariables(TextAsset gloabalsJson)
    {
        _variablesStory = new(gloabalsJson.text);

        _variables ??= new();
        GetVariablesFromStory(_variablesStory);
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
        foreach (var vari in _variables)
            Debug.Log(vari.Key + " + " + vari.Value);
    }

    public void StopListening(Story story) =>
        story.variablesState.variableChangedEvent -= VariableChanged;
    private void VariableChanged(string name, Ink.Runtime.Object value) =>
        _variables[name] = value;

    private void VariablesToStory(Story story)
    {
        foreach (var key in _variables)
            story.variablesState.SetGlobal(key.Key, key.Value);
    }

    public string GetDataToVariables()
    {
        VariablesToStory(_variablesStory);
        return _variablesStory.state.ToJson();
    }

    public void Load(string story)
    {
        _variablesStory.state.LoadJson(story);

        GetVariablesFromStory(_variablesStory);
    }
    
    private void GetVariablesFromStory(Story story)
    {
        foreach (string name in story.variablesState)
        {
            var value = story.variablesState.GetVariableWithName(name);
            Debug.Log(name + ": " + value);
            if (!_variables.ContainsKey(name))
                _variables.Add(name, value);
            else
                _variables[name] = value;
        }
    }
}
