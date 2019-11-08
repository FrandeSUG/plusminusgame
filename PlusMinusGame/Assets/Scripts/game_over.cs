using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_over : MonoBehaviour
{
    Color hide = new Color(0 / 255f, 0 / 255f, 0 / 255f, 0 / 225f);
    Color show = new Color(0 / 255f, 0 / 255f, 0 / 255f, 225f / 225f);
    public bool animation_start;
    float timer = 0;
    public int changing_size = 1;
    public int max_font_size = 280;

    private AudioSource audio;
    

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        animation_start = false;
        GetComponent<Image>().color = hide;
    }

     void Update()
    {
        text_animation();
    }

    // Public methods
    public void over_and_score(int score, int stage)
    {
        audio.Play();
        GetComponent<Image>().color = show;
        transform.Find("Text").GetComponent<Text>().text = "Game Over";
        transform.Find("Score").GetComponent<Text>().text = "Score: " + score;
        transform.Find("Stage").GetComponent<Text>().text = "Stage: " + stage;
        transform.Find("MainMenu").gameObject.SetActive(true);

        if (score > PlayerPrefs.GetInt("Highest Score"))
        {
            PlayerPrefs.SetInt("Highest Score", score);
            transform.Find("HighestScore").GetComponent<Text>().text = "New High Score!";
            animation_start = true;
        }
        if (stage > PlayerPrefs.GetInt("Highest Stage"))
        {
            PlayerPrefs.SetInt("Highest Stage", stage);
            transform.Find("HighestStage").GetComponent<Text>().text = "New High Stage!";
            animation_start = true;
        }
    }

    // Private methods
    private void text_animation()
    { 
        if(timer <= 1)
        {
            timer += Time.deltaTime * 100;
        }
        else
        {
            if(transform.Find("HighestScore").GetComponent<Text>().fontSize >= max_font_size) { changing_size = -2; }
            if (transform.Find("HighestScore").GetComponent<Text>().fontSize <= 250) { changing_size = 2; }
            transform.Find("HighestScore").GetComponent<Text>().fontSize += changing_size;
            transform.Find("HighestStage").GetComponent<Text>().fontSize += changing_size;
            timer = 0;
        }
    }

}
