using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    public CharacterController CharacterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    public float playerSpeed = 2.0f;
    public float jumpPower = 1.0f;
    public float gravityValue = -9.81f;

    public Animator Animator;

    private Vector3 oldVelocity;

    public FoodStepsSoundManager FoodStepsSoundManager;

    public Camera mainCamera;

    public float MaxStamina = 6f;

    public float NowStamina = 0;

    public bool Tired = false;

    private void Start()
    {
        NowStamina = MaxStamina;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(groundedPlayer && playerVelocity.y<0)
        {
            playerVelocity.y = 0;
        }

        if(NowStamina <= 0  && !Tired)
        {
            Tired = true;
            Animator.SetBool("Tired", true);
        }
        if (Tired)
        {
            NowStamina += Time.deltaTime / 2;
            if(NowStamina > MaxStamina)
            {
                Tired = false;
                NowStamina = MaxStamina;
                Animator.SetBool("Tired", false);
            }
            return;
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        var movePower = Mathf.Abs(move.z) + Mathf.Abs(move.x);

        if (Input.GetKey(KeyCode.X)){
            playerSpeed = 3.5f;
            NowStamina -= Time.deltaTime;
        }
        else{
            playerSpeed = 2.0f;
            if (NowStamina < MaxStamina)
            {
                NowStamina += Time.deltaTime;
            } 
        }

        if (move.magnitude > 0)
        {
            FoodStepsSoundManager.PlayFootStepSE();

        }
        else
        {
            FoodStepsSoundManager.StopFootStepSE();
        }

        Animator.SetFloat("MovePower", move.magnitude * playerSpeed);
        
        playerVelocity = move;

        var horizontalRotation = Quaternion.AngleAxis(mainCamera.transform.eulerAngles.y, Vector3.up);
        
        playerVelocity = horizontalRotation * move;
       
        playerVelocity = Vector3.Slerp(oldVelocity, playerVelocity, playerSpeed * Time.deltaTime);
       
        oldVelocity = playerVelocity;
        if(playerVelocity.magnitude>0f)
        {
            transform.LookAt(transform.position + playerVelocity);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        CharacterController.Move(playerVelocity * Time.deltaTime * playerSpeed);
    }

}
