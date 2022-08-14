using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedBlock : MonoBehaviour
{
    [SerializeField] private int rotationSpeed;

    private Block block;

    private void FixedUpdate()
    {
        Rotate();
    }

    public void SetBlock(Block block)
    { 
        this.block = block; 
        transform.GetComponent<MeshRenderer>().material.mainTexture = block.GetBlockTexture();
    }
    

    public Block GetBlock(){ return block; }

    public void DestroySelf(){ Destroy(this.gameObject); }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed);
    }
}
