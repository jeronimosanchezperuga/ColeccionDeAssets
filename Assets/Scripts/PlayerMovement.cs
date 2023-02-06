using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController2D characterController;
    [SerializeField]
    Rigidbody2D rb;
    public float runSpeed = 40f;
    float horizontalMove;
    bool jump = false;
    bool crouch = false;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
    } 

    public void OnLanding()
    {
        anim.SetBool("IsJumping",false);
    }
    public void OnCrouching(bool isCrouching)
    {
        anim.SetBool("IsCrouching",isCrouching);
    }

    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
