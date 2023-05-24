using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    // Initialisation des Attributs de l'objet Player pour pouvoir les modifier dans le code
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private float velocityX = 7f;
    [SerializeField] private float velocityY = 14f;
    [SerializeField] private float tvelocityY = 22f;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling };

    private float dirX;



    // Start is called before the first frame update
    private void Start() {
        // GetComponent pour les attributs
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("ladder")) {
            rb.gravityScale = 2;
            rb.velocity = new Vector2(rb.velocity.x, tvelocityY);

        }

    }



    // Update is called once per frame
    private void Update() {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * velocityX, rb.velocity.y);
        rb.gravityScale = 3;
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, velocityY);
        }
        // Appel � la m�thode qui update les �tats du joueur
        UpdateAnimationState();
    }
    private void UpdateAnimationState() {
        MovementState state;
        if (dirX > 0f) { // Player must be facing right and start running
            state = MovementState.running; //to run
            sprite.flipX = false; //to face right

        } else if (dirX < 0f) { // Player must be facing left and start running
            state = MovementState.running; //to run
            sprite.flipX = true; //to face left
        }
        else {
            state = MovementState.idle; //idle
        }

        if (rb.velocity.y > .1f) { //fall if y velocity is negative
            state = MovementState.jumping;
        } else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state); // on veut mettre la valeur correspondante � l�tat ex 0 pour idle dans la variable state qui est dans animator et qui controle le passage entre les �tats
    }

    private bool IsGrounded() { //fct qui retourne true si Player is on the Ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
