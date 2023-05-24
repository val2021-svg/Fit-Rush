using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isMoving;
    public LayerMask layerMaskForGrounded;
    public float isGroundedRayLength = 1f;
    public bool isGrounded { get{
        Debug.DrawRay (transform.position, Vector2.down * isGroundedRayLength, Color.black);
        bool grounded = Physics2D.Raycast (transform.position, Vector2.down, isGroundedRayLength, layerMaskForGrounded.value);
        return grounded;
        }
    }
    
    private Rigidbody2D rb;
    private Vector2 move;
    private Vector3 saveLScale;//save localscale for optional scaling in Editor
    private Animator anim;
    private float scaleXNegative;
    private Vector3 oldPosition;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        saveLScale = transform.localScale;
        scaleXNegative = saveLScale.x * -1f;

        oldPosition = transform.position;
    }
    void Update() {
        float h = Input.GetAxis("Horizontal");
        //Detect Space key for Jump
        if (isGrounded){
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpForce);
            //play Jump Animation
            anim.Play("Jump");
            anim.SetBool("isGrounded", false);
        }
        }
        anim.SetBool("isGrounded", isGrounded);
        //facing, moving detect
        if (h<0f){
            //Right face scale
            transform.localScale = new Vector2 (scaleXNegative, transform.localScale.y);
            isMoving = true;
        }else if (h>0f){
            //Left face scale
            transform.localScale = new Vector2 (saveLScale.x, transform.localScale.y);
            isMoving = true;
        }else{
            isMoving = false;
        }
        anim.SetBool("isMoving", isMoving);
        Vector2 movement = new Vector2(h * speed, rb.velocity.y);
        rb.velocity = movement; //moving rigidbody2D

        //Demo auto reset position
        if (transform.position.y < -5f){
            //Character fall off the map, reset position
            transform.position = oldPosition;
        }
    }

}
