using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnInventoryChanged;
    public Block[] slots;
    public int numberOfSlots = 9;
    public int emptySlots = 9;
    public int slotSelectedIndex = 0;

    public Inventory()
    {
        slots = new Block[numberOfSlots];
    }

    public bool AddItem(Block block)
    {
        if (block.maxStackAmount > 1) //Is stackable?
        {
            foreach (Block slot in slots)
            {
                if (slot == null) continue;
                if (slot.GetName() != block.GetName()) continue;
                if (slot.localizedName != block.localizedName) continue;

                if (block.maxStackAmount < slot.currentStackAmount + block.currentStackAmount) //If not enough space
                {

                }
                else
                {
                    slot.currentStackAmount = slot.currentStackAmount + block.currentStackAmount;
                    OnInventoryChanged?.Invoke(this, EventArgs.Empty);
                    return true;
                }
            }

            if (emptySlots == 0) return false;
            for (int i = 0; i < numberOfSlots; i++) //Find empty slot and add item
            {
                if (slots[i] != null) continue;
                slots[i] = block;
                OnInventoryChanged?.Invoke(this, EventArgs.Empty);
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(Block block)
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            if (slots[i] == null) continue;
            if (slots[i].GetName() != block.GetName()) continue;
            if (slots[i].localizedName != block.localizedName) continue;

            if (slots[i].currentStackAmount > 1) //If more than one item
            {
                slots[i].currentStackAmount = slots[i].currentStackAmount - 1;
                OnInventoryChanged?.Invoke(this, EventArgs.Empty);
                return;
            }
            else
            {
                slots[i] = null;
                OnInventoryChanged?.Invoke(this, EventArgs.Empty);
                return;
            }
        }
    }

    public void DropItem(Vector3 position)
    {
        if (slots[slotSelectedIndex] == null) return;
        DropSpawner.Instance.SpawnDrop(position, slots[slotSelectedIndex]);
        RemoveItem(slots[slotSelectedIndex]);

    }

    public void SelectSlot(int slotIndex)
    {
        slotSelectedIndex = slotIndex;
        OnInventoryChanged?.Invoke(this, EventArgs.Empty);
    }
}
