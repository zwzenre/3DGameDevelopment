using UnityEngine;
using UnityEngine.Video;

public class RemotePickupTV : MonoBehaviour
{
    public GameObject tv;
    public Material newScreenMaterial;
    public int screenMaterialIndex = 0;

    private bool used = false;

    public void PickupRemote()
    {
        if (used) return; // prevent double use
        used = true;

        // Stop & disable video
        VideoPlayer vp = tv.GetComponent<VideoPlayer>();
        if (vp != null)
        {
            vp.Stop();
            vp.enabled = false;
        }

        // Change TV screen material
        MeshRenderer renderer = tv.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            Material[] mats = renderer.materials;

            if (screenMaterialIndex >= 0 && screenMaterialIndex < mats.Length)
            {
                mats[screenMaterialIndex] = newScreenMaterial;
                renderer.materials = mats;
            }
            else
            {
                Debug.LogWarning("Screen Material Index out of range!");
            }
        }

        // Disable remote (picked up)
        gameObject.SetActive(false);
    }
}
