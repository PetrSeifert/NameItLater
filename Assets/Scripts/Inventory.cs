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
    public int currentSlotSeleted = 0;

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
}
