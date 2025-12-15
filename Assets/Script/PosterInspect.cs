using UnityEngine;
using StarterAssets;

public class PosterInspect : MonoBehaviour
{
    public GameObject posterUI;  
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
        
    }

    void ClosePoster()
    {
        posterUI.SetActive(false);
        isOpen = false;
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
