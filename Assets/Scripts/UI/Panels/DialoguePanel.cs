using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialoguePanel : abstractUIPanel
{
    [Header("Dialogue References")]
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text contentText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Image speakerImage;
    //private Dialogue currentDialogue;
    private int currentLineIndex;
     protected override void Initialize()
    {
        
    }
    
    public override void Refresh()
    {}
}
