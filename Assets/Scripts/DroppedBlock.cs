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

    private void OnCollisionEnter(Collision other) 
    {
        if (transform.position.y < other.transform.position.y + 0.5f)
            transform.position += Vector3.up;
    }
}
