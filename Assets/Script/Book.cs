using UnityEngine;
using TMPro;

public class Book : MonoBehaviour
{
    public int maxBooks = 8;

    public TMP_Text bookCountText;

    public Color normalColor = Color.white;
    public Color maxColor = Color.green;

    private static int currentBooks = 0;
    private bool collected = false;

    private void Start()
    {
        UpdateUI();
    }

    public void Collect()
    {
        if (collected) return;

        if (currentBooks >= maxBooks)
        {
            Debug.Log("Max books reached!");
            return;
        }

        collected = true;
        currentBooks++;

        UpdateUI();
        gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        if (bookCountText == null) return;

        bookCountText.text = $"Books: {currentBooks}";

        if (currentBooks >= maxBooks)
        {
            bookCountText.color = maxColor;
        }
        else
        {
            bookCountText.color = normalColor;
        }
    }

    public static int GetBookCount()
    {
        return currentBooks;
    }

    void Awake()
    {
        currentBooks = 0;
    }
}
