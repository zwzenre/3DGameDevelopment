using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public static Interactable Instance;

    void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}