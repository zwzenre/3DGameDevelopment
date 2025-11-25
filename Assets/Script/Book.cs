using UnityEngine;

public class Book : MonoBehaviour
{
    public void Collect()
    {
        GameManager.Instance.AddBook(this);
    }
}
