using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player_Movement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpPower = 4f;
    public float gravity = 12f;
    public float lookSpeed = 3f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;

    private bool canMove = true;

    public GameObject bullet;
    public Transform firePoint;

    public static Player_Movement instance;

    // Footsteps
    public AudioSource footstepAudioSource;
    public float footstepInterval = 0.5f;
    private float footstepTimer = 0f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Pause_Menu.isPaused) return; // Stop movement if paused

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Handle jumping
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Handle crouching
        if (Input.GetKey(KeyCode.C))
        {
            characterController.height = crouchHeight;
            walkSpeed = crouchSpeed;
            runSpeed = crouchSpeed;
        }
        else
        {
            characterController.height = defaultHeight;
            walkSpeed = 5f;
            runSpeed = 10f;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        // Handle camera rotation
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        // Handle shooting
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 200f))
            {
                if (Vector3.Distance(playerCamera.transform.position, hit.point) > 1f)
                {
                    firePoint.LookAt(hit.point);
                }
                else
                {
                    firePoint.LookAt(playerCamera.transform.position + playerCamera.transform.forward * 40f);
                }
            }
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }

        // Play footstep sound
        HandleFootsteps(isRunning);
    }

    private void HandleFootsteps(bool isRunning)
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            footstepTimer += Time.deltaTime;

            if (footstepTimer >= (isRunning ? footstepInterval / 2 : footstepInterval))
            {
                if (footstepAudioSource != null)
                {
                    footstepAudioSource.Play();
                }
                footstepTimer = 0f;
            }
        }
        else
        {
            footstepTimer = 0f; // Reset timer
        }
    }
}
