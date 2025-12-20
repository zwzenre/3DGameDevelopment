using UnityEngine;
using StarterAssets;

public class PosterInspect : MonoBehaviour
{
    public GameObject posterUI;  
    public GameObject interactIcon;
    public PlayerController playerController;

    private bool isOpen = false;

    void Start()
    {
        posterUI.SetActive(false);
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        interactIcon.SetActive(false);
    }

    void ClosePoster()
    {
        posterUI.SetActive(false);
        isOpen = false;
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        interactIcon.SetActive(true);
    }
}
