using UnityEngine;

public class GrabObject : MonoBehaviour
{
    Rigidbody objectRb;
    Transform grabPointTransform;
    float lerpSpeed = 10.0f;
    Vector3 newPosition;

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();

    }
    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;
        objectRb.useGravity = false;
        objectRb.isKinematic = true;
    }

    public void Drop()
    {
        this.grabPointTransform = null;
        objectRb.useGravity = true;
        objectRb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        if(grabPointTransform != null)
        {
            newPosition = Vector3.Lerp(transform.position, grabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRb.MovePosition(newPosition);
        }
    }
}
