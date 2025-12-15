using UnityEngine;

public class PipeObject : MonoBehaviour
{
    public Sprite inventoryIcon;
    public GameObject pipeObject;

    public void LockPipe()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Collider col = rb.GetComponent<Collider>();

        rb.isKinematic = true;
        rb.useGravity = false;
        col.enabled = true;
        //this.enabled = false;
    }
}
