using System.Collections;

using UnityEngine;
//single line of comment

/*
    multi line comment
*/

//adds the component "charactercontroller" when you attatch the script
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [Range(0f, 10f)]
    [Space(10)]
    public float speed;
    public float sprintSpeed;
    public float crouchSpeed;
    private float initialSpeed;
    private float initialSprintSpeed;
    private float initialCrouchSpeed;
    public float jumpspeed, gravity;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public CharacterHandler handler;
    public void Awake()
    {
        initialCrouchSpeed = crouchSpeed;
        initialSpeed = speed;
        initialSprintSpeed = sprintSpeed;

    }
    private void Start()
    {   //grabs the object "character controller" when you start, you don't need to drag it under the slot manually"
        controller = this.GetComponent<CharacterController>();
        handler = GetComponent<CharacterHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            speed = crouchSpeed;
        }
        else if (Input.GetKey(KeyCode.Q) && handler.curStamina > 0f)
        {
            speed = sprintSpeed;
            handler.curStamina--;
            handler.staminaTimer = 2f;

        }
        else
        { speed = initialSpeed; }
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpspeed;
            }
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

   
}
