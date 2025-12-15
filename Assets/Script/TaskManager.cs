using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    public TMP_Text taskText;

    public string defaultTask = "Proceed the next stage";
    public string roomTask = "Find a way to open the door";
    public string mazeTask = "";

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        UpdateTaskForScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateTaskForScene(scene.name);
    }

    void UpdateTaskForScene(string sceneName)
    {
        switch (sceneName)
        {
            case "RoomScene":
                SetTask(roomTask);
                break;

            case "MazeScene":
                SetTask(mazeTask);
                break;

            default:
                SetTask(defaultTask);
                break;
        }
    }

    public void SetTask(string task)
    {
        if (taskText != null)
            taskText.text = task;
    }
}