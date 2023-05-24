using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelCompleted = false;
    // Start is called before the first frame update

    //private void OnTriggerEnter2D(Collider2D collision) {
      //  if (collision.gameObject.name == "Player") {
        //    levelCompleted = true;
          //  
            //Invoke("Completelevel", .2f);
        //}
   // }
    private void Completelevel() {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        }
    

}
