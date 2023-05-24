using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Spikes")) {
            Die();
        }

    }

    private void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void RestardtLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
