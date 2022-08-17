using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory();
    }

    private void Start()
    {
        uiInventory.SetInventory(inventory);

        for (int i = 0; i < 10; i++)
            inventory.AddItem(AssetManager.Instance.blockList[1].Copy());
    }

    public void PlaceBlock(Vector3 position)
    {   
        Block block = inventory.slots[inventory.slotSelectedIndex];
        if (block == null) return;
        inventory.RemoveItem(block);
        BlockPlacer.Instance.PlaceBlock(position, block);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<DroppedBlock>() != null){
            CollectBlock(other.GetComponent<DroppedBlock>());
        }
    }

    private void CollectBlock(DroppedBlock collectible)
    {
        inventory.AddItem(collectible.GetBlock());
        collectible.DestroySelf();
    }

    public void DestroyBlock(GameObject block)
    {
        PlacedBlock placedBlock = block.GetComponent<PlacedBlock>();
        if (placedBlock.GetBlock().durability < 1000)
            placedBlock.DestroySelf();
    } 

    public void SelectSlot(int slotIndex)
    {
        inventory.SelectSlot(slotIndex);
    }

    public void DropItem()
    {
        Vector3 dropPositon = transform.position + transform.forward * 2;
        inventory.DropItem(dropPositon);
    }
}
