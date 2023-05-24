using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderClimbing : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private float velocityY = 17f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("ladder")) {
            rb.gravityScale = 2;
            rb.velocity = new Vector2(rb.velocity.x, velocityY);
            
        }
        
    }
    
}
