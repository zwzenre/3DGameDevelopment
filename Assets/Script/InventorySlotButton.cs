using UnityEngine;

public class InventorySlotButton : MonoBehaviour
{
    public int slotIndex;

    public void OnClickSlot()
    {
        InventoryManager.instance.SelectedItem(slotIndex);
    }
}
