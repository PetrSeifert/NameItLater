using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager Instance { get; private set; }
    
    //Block textures
    [HideInInspector] public Texture2D dirtBlockTexture;
    [HideInInspector] public Texture2D dirtGrassBlockTexture;

    //Icon textures
    [HideInInspector] public Texture2D dirtIconTexture;
    [HideInInspector] public Texture2D dirtGrassIconTexture;

    //Models
    [HideInInspector] public Object blockModel;

    private void Awake()
    {
        Instance = this;
        dirtBlockTexture = Resources.Load<Texture2D>("Textures/Blocks/dirtBlock");
        dirtGrassBlockTexture = Resources.Load<Texture2D>("Textures/Blocks/dirtGrassBlock");
        blockModel = Resources.Load("Models/Block");
    }
}
