using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;   

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        EnablePlayer();
    }

    public void EnablePlayer()
    {
        if (player != null)
        {
            player.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Player not assigned in GameManager!");
        }
    }
}
