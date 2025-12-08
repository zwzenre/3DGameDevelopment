using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public void SetText(string msg)
    {
        dialogueText.text = msg;
    }

    public void ClearText()
    {
        dialogueText.text = "";
    }
}
