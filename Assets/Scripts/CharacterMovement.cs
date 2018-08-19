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
    public float jumpspeed, gravity;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    private void Start()
    {   //grabs the object "character controller" when you start, you don't need to drag it under the slot manually"
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      
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
