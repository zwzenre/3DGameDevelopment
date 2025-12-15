using UnityEngine;
using NavKeypad;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactLayer;
    public TMP_Text interactText;
    public AudioSource audioSource;
    public AudioClip interactSound;

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
        }
    }

    private void PlayInteractSound()
    {
        if (audioSource != null && interactSound != null)
        {
            audioSource.PlayOneShot(interactSound);
        }
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
        }

        HideText();
    }
}
