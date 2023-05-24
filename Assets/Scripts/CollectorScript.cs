using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    private int nbcherries = 0;
    [SerializeField] private Text cherries_text;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Cherry")){
            Destroy(collision.gameObject);
            nbcherries++;
            cherries_text.text = "Cherries " + nbcherries;
        }
    }

}
