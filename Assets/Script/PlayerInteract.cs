using UnityEngine;
using NavKeypad;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactLayer;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
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

            Book book = hit.collider.GetComponent<Book>();
            if (book != null)
            {
                book.Collect();
                return;
            }

            KeypadButton button = hit.collider.GetComponent<KeypadButton>();
            if (button != null)
            {
                button.PressButton();
                return;
            }
        }
    }
}
