using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public static DropSpawner Instance { get; private set; }

    [SerializeField] private GameObject dropPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnDrop(Vector3 position, Block block)
    {
        Transform drop = Instantiate(dropPrefab, position, Quaternion.identity).GetComponent<Transform>();

        drop.GetComponent<DroppedBlock>().SetBlock(block.Copy());
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
