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
        sfx = true;
        transform.Find("SFX").GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 512/icon_512_4_03");
    }

    public void clicked()
    {
        sfx = !sfx;
        if (sfx)
        {
            one.volume = 1f;
            two.volume = 1f;
            three.volume = 1f;
            transform.Find("SFX").GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 512/icon_512_4_03");
        }
        else
        {
            one.volume = 0;
            two.volume = 0;
            three.volume = 0;
            transform.Find("SFX").GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 512/icon_512_4_04");
        }
    }
}
