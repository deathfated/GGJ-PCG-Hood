using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DummyChoice", menuName = "Scriptable Objects/Dummy/Choice")]
public class DummyChoiceSO : ScriptableObject
{
    public List<Struct_Choice> choices;
}

[Serializable]
public struct Struct_Choice
{
    public string name;
    public void Action()
    {
        Debug.Log($"Choice {name} is selected");
    }
}
