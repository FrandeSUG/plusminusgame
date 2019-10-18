using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage : MonoBehaviour
{
    public int the_stage;

    // Start is called before the first frame update
    void Start()
    {
        reset_stage();
    }

    // Public methods
    public void increment_stage()
    {
        the_stage++;
        GetComponentInChildren<Text>().text = "Stage: " + the_stage.ToString();
    }

    public void reset_stage()
    {
        the_stage = 1;
        GetComponentInChildren<Text>().text = "Stage: " + the_stage.ToString();
    }
}
