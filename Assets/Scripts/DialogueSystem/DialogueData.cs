using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string dialogueID;
    public List<DialogueLine> lines = new List<DialogueLine>();
    public bool hasChoice;
    public List<ChoiceOption> options = new List<ChoiceOption>();
}