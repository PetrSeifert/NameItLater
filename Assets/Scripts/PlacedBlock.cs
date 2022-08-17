using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedBlock : MonoBehaviour
{
    Block block;

    public void SetBlock(Block block)
    { 
        this.block = block; 
        transform.GetComponent<MeshRenderer>().material.mainTexture = block.blockTexture;
    }

    public Block GetBlock(){ return block; }

    public void DestroySelf()
    { 
        DropSpawner.Instance.SpawnDrop(transform.position, block);
        Destroy(gameObject);
    }
}
