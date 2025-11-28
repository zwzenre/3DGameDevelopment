using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform grabPointTransform;
    [SerializeField] LayerMask pickupLayerMask;
    float pickupDistance = 2.0f;

    private GrabObject grabObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            // If not grabbing object, try to grab one
            if (grabObject == null)
            {
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out grabObject))
                    {
                        grabObject.Grab(grabPointTransform);
                    }
                }
            }
            else
            {
                // Carrying object
                grabObject.Drop();
                grabObject = null;
            }
        }  
    }
}
