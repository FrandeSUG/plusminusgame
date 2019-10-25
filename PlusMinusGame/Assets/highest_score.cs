using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highest_score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("HighestScore").GetComponent<Text>().text = "HIGHEST SCORE\n" +  PlayerPrefs.GetInt("Highest Score");
        transform.Find("HighestStage").GetComponent<Text>().text = "HIGHEST STAGE\n" + PlayerPrefs.GetInt("Highest Stage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
