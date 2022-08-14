using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public static WorldGenerator Instance { get; private set; }
    public Block[] blocks = {new BlockDirt() , new BlockDirtGrass()};
    [SerializeField] private GameObject placedBlockPrefab;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int z = -9; z < 10; z++)
        {
            for (int x = -9; x < 10; x++)
            {
                GenerateBlock(placedBlockPrefab, new Vector3(x, 0, z));
            }
        }
    }

    public void GenerateBlock(GameObject _block, Vector3 position)
    {
        GameObject block = Instantiate(_block);
        block.GetComponent<PlacedBlock>().SetBlock(blocks[0]);
        block.transform.position = position;
        block.GetComponent<Renderer>().material.color = new Color(0.8f, 0.8f, 0.8f);
    }
}
