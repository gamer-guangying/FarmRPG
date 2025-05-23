using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(3, 5)] public string content;
    public Sprite portrait;
    public UnityEvent onLineEndEvent;
}

[System.Serializable]
public class ChoiceOption
{
    public string optionText;
    public UnityEvent onChooseEvent;
    public DialogueData nextDialogue; // 用于分支对话
}