using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

public class WorldGenerator : MonoBehaviour
{

    public static WorldGenerator Instance { get; private set; }
    [SerializeField] private GameObject placedBlockPrefab;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        int blockIndex = AssetManager.Instance.blockList.Count;
        for (int y = 0; y < AssetManager.Instance.blockList.Count; y++)
        {
            blockIndex--;
            for (int z = -9; z < 10; z++)
            {
                for (int x = -9; x < 10; x++)
                {
                    GenerateBlock(new Vector3(x, -y, z), blockIndex);
                }
            }
        }
    }

    public void GenerateBlock(Vector3 position, int blockIndex)
    {
        GameObject block = Instantiate(placedBlockPrefab);
        block.GetComponent<PlacedBlock>().SetBlock(AssetManager.Instance.blockList[blockIndex]);
        block.transform.position = position;
        block.GetComponent<Renderer>().material.color = new Color(0.8f, 0.8f, 0.8f);
    }
}
