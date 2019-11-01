using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class refresh : MonoBehaviour
{
    public bool is_active = true;
    private bool clickable = true;

    [SerializeField] private blocks blocks;

    public void set_activation(bool b)
    {
        is_active = b;
        GetComponent<Image>().enabled = is_active;
        GetComponent<Button>().enabled = is_active;
    }

    public void clicked()
    {
        if (clickable)
        {
            blocks = GameObject.FindGameObjectWithTag("Blocks").GetComponent<blocks>();
            blocks.generate_random_numbers();
            blocks.play_particle();
            blocks.audio.clip = blocks.for_refresh;
            blocks.audio.Play();
            set_activation(false);
        }
    }

    public void set_clickable(bool b)
    {
        clickable = b;
        if (clickable) { GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); }
        else { GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f); }
    }
}
