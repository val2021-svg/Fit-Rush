using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Start_Script : MonoBehaviour
{
    public Canvas can;

    public void Start_Game() {
        can.enabled = !can.enabled;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);

    }
}
