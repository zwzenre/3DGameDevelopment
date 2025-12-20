using UnityEngine;
using TMPro;

public class Bottle : MonoBehaviour
{
    public int maxBottles = 6;

    public TMP_Text bottleCountText;
    public Color normalColor = Color.white;
    public Color maxColor = Color.green;

    private static int currentBottles = 0;
    private bool collected = false;

    private void Start()
    {
        UpdateUI();
    }

    public void Collect()
    {
        if (collected) return;

        if (currentBottles >= maxBottles)
        {
            Debug.Log("Max bottles reached!");
            return;
        }

        collected = true;
        currentBottles++;

        UpdateUI();
        gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        if (bottleCountText == null) return;

        bottleCountText.text = $"Bottles: {currentBottles}";

        if (currentBottles >= maxBottles)
        {
            bottleCountText.color = maxColor;
        }
        else
        {
            bottleCountText.color = normalColor;
        }
    }

    public static int GetBottleCount()
    {
        return currentBottles;
    }

    void Awake()
    {
        currentBottles = 0;
    }
}
