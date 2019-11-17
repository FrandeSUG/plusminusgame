using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("audio") == 0)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 512/icon_512_4_03");
        }
        else
        {
            GameObject.FindGameObjectWithTag("Sfx").GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 512/icon_512_4_04"); 
        } 
    }
}
