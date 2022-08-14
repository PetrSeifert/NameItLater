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
        inventory.AddItem(WorldGenerator.Instance.blocks[0]);
    }

    public void PlaceBlock(Vector3 position)
    {   
        Block block = inventory.slots[inventory.currentSlotSeleted];
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
        block.GetComponent<PlacedBlock>().DestroySelf();
    } 
}
