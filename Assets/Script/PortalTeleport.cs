using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public string sceneToLoad;

    private bool hasTeleported = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTeleported) return;

        if (other.CompareTag("Player"))
        {
            hasTeleported = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
