using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class lifes_score : MonoBehaviour
{

    private bool score_animation_start = false;
    private float timer = 0;
    private int score_to_add = 0;

    public float time_needed = 2;
    public int the_lifes;
    public int the_score;

    // Start is called before the first frame update
    void Start()
    {
        reset_lifes_score();
    }

    void Update()
    {
         score_animation();
    }

    // Public methods
    public void decrement_lifes()
    {
        the_lifes -= 1;
        transform.Find("Lifes").GetComponentInChildren<Text>().text = the_lifes.ToString();
    }

    public void increment_lifes()
    {
        the_lifes += 1;
        transform.Find("Lifes").GetComponentInChildren<Text>().text = the_lifes.ToString();
    }

    public void reset_lifes_score()
    {
        the_lifes = 2;
        the_score = 0;
        transform.Find("Lifes").GetComponentInChildren<Text>().text = the_lifes.ToString();
        transform.Find("Score").GetComponentInChildren<Text>().text = the_score.ToString();
    }

    public void calculate_score(int combo)
    {
        score_to_add = (int)Math.Pow(2, combo);
        score_animation_start = true;
    }

    // Private methods
    private void score_animation()
    {
        if (score_animation_start)
        {
            if (timer <= time_needed)
            {
                timer += Time.deltaTime;
                transform.Find("Score").GetComponentInChildren<Text>().text = ((int)(the_score + ((score_to_add * timer) / time_needed))).ToString();
            }
            else
            {
                timer = 0;
                the_score += score_to_add;
                transform.Find("Score").GetComponentInChildren<Text>().text = the_score.ToString();
                score_animation_start = false;
            }
        }
    }
}
