using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combo : MonoBehaviour
{
    public int count = 0;
    public int font_size = 30;
    Text combo_text;
    Color red = new Color(255f / 255f, 0 / 255f, 0 / 255f);
    Color yellow = new Color(255f / 255f, 254f / 255f, 59f / 255f);
    Color white = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    private AudioSource audio;

    public AudioClip one;
    public AudioClip two;
    public AudioClip three;
    public AudioClip four;
    public AudioClip eight;
    public AudioClip twelve;


    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        combo_text = gameObject.transform.Find("Text").GetComponent<Text>();
        combo_text.fontSize = font_size;
        combo_text.color = white;
    }

    // Update is called once per frame
    void Update()
    {
        show_combo();
    }

    // Private methods
    private void show_combo()
    {
        if(count > 0)
        {
            combo_text.gameObject.SetActive(true);
            combo_text.text = count.ToString() + " COMBO";
            combo_text.fontSize = font_size + count;
            if(count > 5){combo_text.color = yellow;}
            if(count > 10){combo_text.color = red; }

        }
        else
        {
            combo_text.gameObject.SetActive(false);
        }
    }

    // Public methods
    public void increment_combo()
    {
        count++;
        if(count == 1)
        {
            audio.clip = one;
            audio.Play();
        }
        else if (count == 2)
        {
            audio.clip = two;
            audio.Play();
        }
        else if (count == 3)
        {
            audio.clip = three;
            audio.Play();
        }
        else if (count == 4)
        {
            audio.clip = four;
            audio.Play();
        }
        else if (count < 8)
        {
            audio.clip = eight;
            audio.Play();
        }
        else
        {
            audio.clip = twelve;
            audio.Play();
        }
        
    }

    public void reset_combo()
    {
        count = 0;
        font_size = 30;
        combo_text.color = white;
    }

}
