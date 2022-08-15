using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager Instance { get; private set; }
    
    //Block textures
    [HideInInspector] public Texture2D dirtBlockTexture;
    [HideInInspector] public Texture2D dirtGrassBlockTexture;

    //Models
    [HideInInspector] public Object blockModel;

    //Icon sprite textures
    private Texture2D dirtIconTexture;
    private Texture2D dirtGrassIconTexture;

    //UI sprite textures
    private Texture2D hotbarSlotTexture;
    private Texture2D hotbarSlotSelectedTexture;

    //Sprites
    [HideInInspector] public Sprite dirtIconSprite;
    [HideInInspector] public Sprite hotbarSlotSprite;
    [HideInInspector] public Sprite hotbarSlotSelectedSprite;

    private void Awake()
    {
        Instance = this;

        //Block textures
        dirtBlockTexture = Resources.Load<Texture2D>("Textures/Blocks/dirtBlock");
        dirtGrassBlockTexture = Resources.Load<Texture2D>("Textures/Blocks/dirtGrassBlock");

        //Models
        blockModel = Resources.Load("Models/Block");

        //Icon sprite textures
        dirtIconTexture = Resources.Load<Texture2D>("Textures/Icons/dirtIcon");
        dirtGrassIconTexture = Resources.Load<Texture2D>("Textures/Icons/dirtGrassIcon");

        //UI sprite textures
        hotbarSlotTexture = Resources.Load<Texture2D>("Textures/UI/hotbarSlot");
        hotbarSlotSelectedTexture = Resources.Load<Texture2D>("Textures/UI/hotbarSlotSelected");

        CreateSprites();
    }

    private void CreateSprites()
    {
        dirtIconSprite = Sprite.Create(dirtIconTexture, new Rect(0.0f, 0.0f, dirtIconTexture.width, dirtIconTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        hotbarSlotSprite = Sprite.Create(hotbarSlotTexture, new Rect(0.0f, 0.0f, hotbarSlotTexture.width, hotbarSlotTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        hotbarSlotSelectedSprite = Sprite.Create(hotbarSlotSelectedTexture, new Rect(0.0f, 0.0f, hotbarSlotSelectedTexture.width, hotbarSlotSelectedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
