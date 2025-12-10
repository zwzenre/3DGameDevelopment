using UnityEngine;

public class GrabObject : MonoBehaviour
{
    Rigidbody objectRb;
    Transform grabPointTransform;
    Collider colliders;
    float lerpSpeed = 10.0f;
    Vector3 newPosition;

    private void Awake()
    {
        objectRb = GetComponent<Rigidbody>();
        colliders = GetComponentInChildren<Collider>();

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

    public void SnapTo(Transform snapPoint)
    {
        transform.position = snapPoint.position;
        transform.rotation = snapPoint.rotation;

        objectRb.useGravity = false;
        objectRb.isKinematic = true;
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
