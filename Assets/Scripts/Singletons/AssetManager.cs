using System.Collections.Generic;
using UnityEngine;
using System;

public class AssetManager : MonoBehaviour
{
    public static AssetManager Instance { get; private set; }

    public List<Block> blockList = new List<Block>();
    
    //Models
    [HideInInspector] public UnityEngine.Object blockModel;

    //UI sprite textures
    private Texture2D hotbarSlotTexture;
    private Texture2D hotbarSlotSelectedTexture;

    [HideInInspector] public Sprite hotbarSlotSprite;
    [HideInInspector] public Sprite hotbarSlotSelectedSprite;

    private void Awake()
    {
        Instance = this;
        blockList = GetAllBlocks();

        foreach (Block block in blockList)
        {
            block.blockTexture = Resources.Load<Texture2D>($"Textures/Blocks/{block.GetName()}Block");
            Texture2D iconTexture = Resources.Load<Texture2D>($"Textures/Icons/{block.GetName()}Icon");
            block.iconSprite = Sprite.Create(iconTexture, new Rect(0.0f, 0.0f, iconTexture.width, iconTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
        
        hotbarSlotTexture = Resources.Load<Texture2D>("Textures/UI/hotbarSlot");
        hotbarSlotSelectedTexture = Resources.Load<Texture2D>("Textures/UI/hotbarSlotSelected");

        hotbarSlotSprite = Sprite.Create(hotbarSlotTexture, new Rect(0.0f, 0.0f, hotbarSlotTexture.width, hotbarSlotTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        hotbarSlotSelectedSprite = Sprite.Create(hotbarSlotSelectedTexture, new Rect(0.0f, 0.0f, hotbarSlotSelectedTexture.width, hotbarSlotSelectedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    
    public List<Block> GetAllBlocks()
    {
        List<Type> typeList = ReflectionHelper.FindDerivedTypes(typeof(Block));
        List<Block> blockList = new List<Block>();
        foreach (Type type in typeList)
        {
            Block instance = Activator.CreateInstance(type) as Block;
            blockList.Add(instance);
        }
        return blockList;
    }
}
