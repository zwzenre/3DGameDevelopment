using UnityEngine;

public class PipeObject : MonoBehaviour
{
    public Sprite inventoryIcon;
    public GameObject pipeObject;

    public void LockPipe()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Collider col = GetComponent<Collider>();

        if (rb)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        if (col)
            col.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("Default");
        this.enabled = false;
    }
}
