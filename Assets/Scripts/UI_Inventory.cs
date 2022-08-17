using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        for (int i = 0; i < inventory.numberOfSlots; i++)
        {   
            RectTransform itemSlotRectTransform = Instantiate(itemSlotPrefab, itemSlotContainer).GetComponent<RectTransform>();
            if (inventory.slotSelectedIndex == i) itemSlotRectTransform.GetComponent<Image>().sprite = AssetManager.Instance.hotbarSlotSelectedSprite;
            else itemSlotRectTransform.GetComponent<Image>().sprite = AssetManager.Instance.hotbarSlotSprite;
            if (inventory.slots[i] == null) continue;
            Image itemSlotImage = itemSlotRectTransform.GetComponentsInChildren<Image>()[1];
            itemSlotRectTransform.name = $"block {inventory.slots[i].currentStackAmount}";
            itemSlotImage.color = new Color(255, 255, 255, 1);
            itemSlotImage.sprite = inventory.slots[i].iconSprite;
            if (inventory.slots[i].currentStackAmount > 1)
            {
                TMP_Text ammountText = itemSlotImage.GetComponentInChildren<TMP_Text>();
                ammountText.text = inventory.slots[i].currentStackAmount.ToString();
            }
        }
    }

    private void Inventory_OnInventoryChanged(object sender, System.EventArgs e)
    {
        RefreshInventory();
    }
}
