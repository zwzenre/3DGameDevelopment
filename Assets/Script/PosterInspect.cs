using UnityEngine;

public class PosterInspect : MonoBehaviour
{
    public GameObject posterUI;   // Assign your PosterZoomUI panel here

    private bool isOpen = false;

    void Start()
    {
        posterUI.SetActive(false); // Poster starts hidden
    }

    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.F))
        {
            ClosePoster();
        }
    }

    public void OpenPoster()
    {
        posterUI.SetActive(true);
        isOpen = true;

        // Lock player movement & look if you want:
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ClosePoster()
    {
        posterUI.SetActive(false);
        isOpen = false;

        // Unlock player back:
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
