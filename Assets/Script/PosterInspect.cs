using UnityEngine;
using StarterAssets;

public class PosterInspect : MonoBehaviour
{
    public GameObject posterUI;   // Assign your PosterZoomUI panel here
    public FirstPersonController playerController;

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
        playerController.enabled = false;
        // Lock player movement & look if you want:
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    void ClosePoster()
    {
        posterUI.SetActive(false);
        isOpen = false;
        playerController.enabled = true;
        // Unlock player back:
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
