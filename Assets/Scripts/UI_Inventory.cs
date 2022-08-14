using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private GameObject itemSlotPrefab;

    private void Awake()
    {
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnInventoryChanged += Inventory_OnInventoryChanged;
        RefreshInventory();
    }

    private void RefreshInventory()
    {
        foreach (Transform itemSlot in itemSlotContainer)
        {
            Destroy(itemSlot.gameObject);
        }
        Debug.Log(inventory.numberOfSlots);

        for (int i = 0; i < inventory.numberOfSlots; i++)
        {   
            RectTransform itemSlotRectTransform = Instantiate(itemSlotPrefab, itemSlotContainer).GetComponent<RectTransform>();
            if (inventory.slots[i] == null) continue;
            itemSlotRectTransform.name = $"block {inventory.slots[i].currentStackAmount}";
        }
    }

    private void Inventory_OnInventoryChanged(object sender, System.EventArgs e)
    {
        RefreshInventory();
    }
}
