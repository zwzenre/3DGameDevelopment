using UnityEngine;
using UnityEngine.UI;
using NavKeypad;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactLayer;
    public TMP_Text interactText;
    public static PlayerInteract Instance;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        DetectInteractable();

        if (Input.GetButtonDown("Fire1"))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);

            // Book
            Book book = hit.collider.GetComponent<Book>();
            if (book != null)
            {
                PlayInteractSound();
                book.Collect();
                return;
            }

            // Keypad
            KeypadButton button = hit.collider.GetComponent<KeypadButton>();
            if (button != null)
            {
                button.PressButton();
                return;
            }

            // Poster
            PosterInspect poster = hit.collider.GetComponent<PosterInspect>();
            if (poster != null)
            {
                PlayInteractSound();
                poster.OpenPoster();
                return;
            }

            // Remote
            RemotePickupTV tv = hit.collider.GetComponent<RemotePickupTV>();
            if (tv != null)
            {
                PlayInteractSound();
                tv.PickupRemote();
                return;
            }

            PickupObject pipe = hit.transform.GetComponent<PickupObject>();
            if (pipe != null)
            {
                PlayInteractSound();
                pipe.TryPickup();
                return;
            }

            PickupObject flashlight = hit.transform.GetComponent<PickupObject>();
            if (flashlight != null)
            {
                PlayInteractSound();
                flashlight.TryPickup();
                return;
            }
        }
    }

    public void PlayInteractSound()
    {
        AudioManager.instance.PlayInteractSound();
    }

    private void ShowText(string text)
    {
        interactText.text = text;
        interactText.gameObject.SetActive(true);
    }

    private void HideText()
    {
        interactText.gameObject.SetActive(false);
    }

    private void DetectInteractable()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactLayer))
        {
            if (hit.collider.GetComponent<Book>())
            {
                ShowText("Book");
                return;
            }

            if (hit.collider.GetComponent<KeypadButton>())
            {
                ShowText("Keypad");
                return;
            }

            if (hit.collider.GetComponent<PosterInspect>())
            {
                ShowText("Poster");
                return;
            }

            if (hit.collider.GetComponent<RemotePickupTV>())
            {
                ShowText("Remote");
                return;
            }

            if (hit.collider.GetComponent<FlashlightObject>())
            {
                ShowText("Flashlight");
                return;
            }

            if (hit.collider.GetComponent<PipeObject>())
            {
                ShowText("Pipe");
                return;
            }
        }

        HideText();
    }

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
