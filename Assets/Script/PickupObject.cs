using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform grabPointTransform;
    [SerializeField] LayerMask pickupLayerMask;

    public PipeSlot pipeSlot = null;
    float pickupDistance = 2f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InventoryItem selected = InventoryManager.instance.GetSelectedItem();

            // NO ITEM HELD → try pickup
            if (selected == null)
            {
                TryPickup();
            }
            else
            {
                TryPlaceSelectedItem();
            }
        }
    }

    void TryPickup()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward,
            out RaycastHit hit, pickupDistance, pickupLayerMask))
        {
            PipeObject pipe = hit.transform.GetComponent<PipeObject>();

            if (pipe != null)
            {
                InventoryItem newItem = new InventoryItem();
                newItem.icon = pipe.inventoryIcon;
                newItem.objectPrefab = pipe.pipeObject;

                InventoryManager.instance.AddItem(newItem);
                pipe.gameObject.SetActive(false);
                pipe.LockPipe();
            }
        }
    }

    void TryPlaceSelectedItem()
    {
        InventoryItem item = InventoryManager.instance.GetSelectedItem();
        if (item == null) return;

        PipeSlot slot = pipeSlot;

        if (slot == null)
        {
            Debug.Log("Player not in pipe slot");
            return;
        }

        if (slot.isFilled)
        {
            Debug.Log("Slot already filled");
            return;
        }

        if (slot.pipeObj.name != item.objectPrefab.name)
        {
            Debug.Log("Wrong pipe type");
            return;
        }

        // Snap pipe into place
        GameObject newPipe = Instantiate(item.objectPrefab, slot.snapPoint.position, slot.snapPoint.rotation);

        PipeObject pipe = newPipe.GetComponent<PipeObject>();
        pipe.LockPipe();
        pipe.gameObject.SetActive(true);
        slot.isFilled = true;
        WaterManager.instance.OnPipeSnapped(slot);

        // Remove from inventory
        InventoryManager.instance.RemoveSelectedItem();

        Debug.Log("Pipe snapped!");
    }
}