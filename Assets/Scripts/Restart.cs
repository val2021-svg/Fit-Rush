using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {


    public void Start_Game() {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.UnloadSceneAsync(2);
        SceneManager.LoadScene("Scenes/Level 1", LoadSceneMode.Additive);
    }
}
