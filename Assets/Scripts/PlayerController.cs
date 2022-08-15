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
    
    float horizontalInput = 0;
    float verticalInput = 0;
    bool jumpPressed = false;
    Vector3 velocity;
    bool isGrounded;
    float lastYPosition;
    int currentInventorySlot = 0;

    bool destroy = false;
    bool place = false;

    Vector3 placePosition;
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
        lastYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpPressed = Input.GetButton("Jump");

        SelectSlot();

        if (Input.GetButton("Drop")) player.DropItem();

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

    void FixedUpdate()
    {
        isGrounded = lastYPosition == transform.position.y;
        Debug.Log($"{velocity.x} {velocity.z}");

        Vector3 move = (transform.right * horizontalInput + transform.forward * verticalInput).normalized;

        if (isGrounded)
        {
            velocity = Vector3.right * velocity.x + Vector3.down * 0.001f + Vector3.forward * velocity.z;
        } 

        if(jumpPressed && isGrounded) velocity =  Vector3.right * velocity.x + Vector3.up * Mathf.Sqrt(jumpHeight * -2f * gravity) + Vector3.forward * velocity.z;

        if (!isGrounded) 
        {
            velocity += Vector3.up * gravity * Time.deltaTime;
        }
        velocity = move * speed + Vector3.up * velocity.y;

        lastYPosition = transform.position.y;

        controller.Move(velocity * Time.deltaTime);
    }

    private void SelectSlot()
    {
        if (Input.GetButton("Slot1")) player.SelectSlot(0);
        else if (Input.GetButton("Slot2")) player.SelectSlot(1);
        else if (Input.GetButton("Slot3")) player.SelectSlot(2);
        else if (Input.GetButton("Slot4")) player.SelectSlot(3);
        else if (Input.GetButton("Slot5")) player.SelectSlot(4);
        else if (Input.GetButton("Slot6")) player.SelectSlot(5);
        else if (Input.GetButton("Slot7")) player.SelectSlot(6);
        else if (Input.GetButton("Slot8")) player.SelectSlot(7);
        else if (Input.GetButton("Slot9")) player.SelectSlot(8);
    }
}