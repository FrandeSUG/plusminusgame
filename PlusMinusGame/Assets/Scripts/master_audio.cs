 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class master_audio : MonoBehaviour
{
    public AudioSource one;
    public AudioSource two;
    public AudioSource three;

    private bool sfx;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("audio") == 0) {
            sfx = true;
            audio_on(); 
        } else {
            sfx = false ;
            audio_off(); 
        }
         
    }

    public void clicked()
    {
        sfx = !sfx;
        if (sfx)
        {
            PlayerPrefs.SetInt("audio", 0);
            audio_on();

        }
        else
        {
            PlayerPrefs.SetInt("audio", 1);
            audio_off(); 

        }  
    }

    // Private methods
    private void audio_on()
    {
        one.volume = 1f;
        two.volume = 1f;
        three.volume = 1f;
        if(GameObject.FindGameObjectWithTag("Sfx"))
        {
            GameObject.FindGameObjectWithTag("Sfx").GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 512/icon_512_4_03");
        }
    }

    private void audio_off()
    {
        one.volume = 0; 
        two.volume = 0;
        three.volume = 0;
        if (GameObject.FindGameObjectWithTag("Sfx"))
        {
            GameObject.FindGameObjectWithTag("Sfx").GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 512/icon_512_4_04");
        }   
    }
}
