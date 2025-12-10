using UnityEngine;

public class PipeSlot : MonoBehaviour
{
    public GameObject pipeObj;
    public Transform snapPoint;
    public bool inCollider = false;
    public bool isFilled = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupObject pickup = other.GetComponentInChildren<PickupObject>();

            if (pickup != null)
            {
                pickup.pipeSlot = this;   // ← IMPORTANT FIX
            }

            inCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupObject pickup = other.GetComponentInChildren<PickupObject>();

            if (pickup != null)
            {
                pickup.pipeSlot = null;   // ← reset when leaving collider
            }

            inCollider = false;
        }
    }
}
