using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public static BlockPlacer Instance { get; private set; }

    [SerializeField] private GameObject placedBlockPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaceBlock(Vector3 position, Block block)
    {
        Transform placedBlock = Instantiate(placedBlockPrefab, position, Quaternion.identity).GetComponent<Transform>();

        placedBlock.GetComponent<PlacedBlock>().SetBlock(block.Copy());
    }
}
