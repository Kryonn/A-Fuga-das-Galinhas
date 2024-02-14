using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct dialogue
{
    public string name;
    [TextArea(5, 10)]
    public string text;
};

[CreateAssetMenu(fileName = "dialogue_data", menuName = "ScriptableObject/TalkScript", order = 1)]
public class dialogue_data : ScriptableObject
{
    public List<dialogue> talkScript;
}
