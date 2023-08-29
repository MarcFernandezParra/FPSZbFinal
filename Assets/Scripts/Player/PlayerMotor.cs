using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private bool isGrounded, isSprinting;
    
    private Vector3 playerSpeed;
    public float speed = 5f;
    public static float walkingSpeed = 5f;
    private bool isTired = false;
    public static float sprintingSpeed = 8f;
    public float gravity = -9.8f;

    private InputManager inputManager;
    public float jumpHeight = 2f;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(isSprinting){
            PlayerStamina.loseStamina(0.3f);
        }else{
            PlayerStamina.healStamina(.4f);
        }
    }

    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero;
        if(isTired){
            speed = walkingSpeed;
        } 
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        if(isGrounded && playerSpeed.y<0){
            playerSpeed.y = -2f;
        }
        playerSpeed.y += gravity * Time.deltaTime;
        controller.Move(playerSpeed * Time.deltaTime);
    }

    public bool getSprinting(){
        return isSprinting;
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerSpeed.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void setTired(bool tired){
        isTired = tired;
        if(tired){
            StopSprint();
        }
    }

    public void Sprint(){
        if(!isTired){
            isSprinting=true;
            speed=sprintingSpeed;
        }
    }
    
    public void StopSprint(){
        isSprinting = false;
        speed=walkingSpeed;
    }
}