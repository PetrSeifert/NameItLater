using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Camera mainCamera;
    public float speed = 12f;
    public float gravity = -10f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    

    Vector3 velocity;
    bool isGrounded;
    int currentInventorySlot = 0;

    bool destroy = false;
    bool place = false;

    Vector3 placePosition;

    public WorldGenerator worldGenerator;
    private GameObject tempFocusedBlock = null;
    private GameObject focusedBlock = null;
    private Player player;

    void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        float z;
        bool jumpPressed = false;

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        jumpPressed = Input.GetButton("Jump");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        controller.Move(move * speed * Time.deltaTime);

        if(jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        place = Input.GetMouseButtonDown(1);
        destroy = Input.GetMouseButtonDown(0);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << 0;

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, layerMask))
        {
            focusedBlock = hit.collider.gameObject;

            focusedBlock.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
            
            if (place)
            {
                placePosition = focusedBlock.transform.position + hit.normal;
                player.PlaceBlock(placePosition);
            }

            if (destroy)
            {
                tempFocusedBlock = null;
                player.DestroyBlock(focusedBlock);
            }
        }
        
        if (tempFocusedBlock != null) 
            if (focusedBlock != tempFocusedBlock) 
                tempFocusedBlock.GetComponent<Renderer>().material.color = new Color(0.8f, 0.8f, 0.8f);

        tempFocusedBlock = focusedBlock;
        focusedBlock = null;
    }
}