using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MuteSound : MonoBehaviour
{

    public Sprite MusicOn;
    public Sprite MusicOff;
    public Button Bouton;
    private bool ismuted;

    public AudioSource Music;
    public AudioSource MunchSound;


    // Start is called before the first frame update



    public void Mute()
    {
        Debug.Log("touché");
        if (ismuted)
        {
            Bouton.image.sprite = MusicOn;
            Music.mute = false;
            MunchSound.mute = false;
            ismuted = !ismuted;


        }
        else
        {
            Bouton.image.sprite = MusicOff;
            Music.mute = true;
            MunchSound.mute = true;
            ismuted = !ismuted;
        }
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
