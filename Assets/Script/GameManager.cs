using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int booksCollected = 0;
    public int totalBooks = 10;

    public TextMeshProUGUI text;     // Assign in Inspector
    public Transform bookResetParent; // A hidden empty object where books reset to

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddBook(Book book)
    {
        booksCollected++;

        // Update UI text
        text.text = $"{booksCollected}/{totalBooks} books collected";

        // Reset book position to original parent (hidden)
        book.transform.SetParent(bookResetParent);
        book.transform.localPosition = Vector3.zero;
    }
}
