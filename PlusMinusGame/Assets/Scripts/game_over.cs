using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_over : MonoBehaviour
{
    Color hide = new Color(0 / 255f, 0 / 255f, 0 / 255f, 0 / 225f);
    Color show = new Color(0 / 255f, 0 / 255f, 0 / 255f, 225f / 225f);

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = hide;
    }

    // Public methods
    public void over_and_score(int score, int stage)
    {
        GetComponent<Image>().color = show;
        transform.Find("Text").GetComponent<Text>().text = "Game Over";
        transform.Find("Score").GetComponent<Text>().text = "Score: " + score;
        transform.Find("Stage").GetComponent<Text>().text = "Stage: " + stage;
    }

}
