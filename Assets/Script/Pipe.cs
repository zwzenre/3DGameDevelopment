using TMPro;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public static Pipe instance;

    public int maxPipes = 5;
    public TMP_Text pipeCountText;
    public Color normalColor = Color.white;
    public Color maxColor = Color.green;

    private int currentPipes = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddPipe()
    {
        if (currentPipes >= maxPipes) return;

        currentPipes++;
        UpdateUI();
    }

    void UpdateUI()
    {
        pipeCountText.text = $"Pipes: {currentPipes}";
        pipeCountText.color = currentPipes >= maxPipes ? maxColor : normalColor;
    }
}
