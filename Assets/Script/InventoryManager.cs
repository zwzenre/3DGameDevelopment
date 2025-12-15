using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<InventoryItem> items = new List<InventoryItem>();
    public Image[] slots;

    public int selectedIndex = -1;

    public GameObject currentHeldObject = null;
    public Transform grabPoint;

    void Awake()
    {
        instance = this;
    }

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
        UpdateUI();
    }

    public void SelectedItem(int index)
    {
        if (index >= items.Count) return;

        selectedIndex = index;
        InventoryItem item = items[index];

        // Destroy old held object
        if (currentHeldObject != null) Destroy(currentHeldObject);

        // Spawn preview pipe in player's hand
        currentHeldObject = Instantiate(item.objectPrefab, grabPoint.position, grabPoint.rotation);
        currentHeldObject.SetActive(true);
        currentHeldObject.transform.SetParent(grabPoint, true);

        Rigidbody rb = currentHeldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Collider col = currentHeldObject.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }
    }

    public InventoryItem GetSelectedItem()
    {
        if (selectedIndex >= 0 && selectedIndex < items.Count)
            return items[selectedIndex];
        return null;
    }

    public void RemoveSelectedItem()
    {
        if (selectedIndex >= 0 && selectedIndex < items.Count)
            items.RemoveAt(selectedIndex);

        selectedIndex = -1;

        if (currentHeldObject != null)
            Destroy(currentHeldObject);

        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].sprite = items[i].icon;
            else
                slots[i].sprite = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectedItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectedItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectedItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectedItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectedItem(4);
    }
}