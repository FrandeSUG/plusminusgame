using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stage : MonoBehaviour
{
    [SerializeField] private blocks blocks;
    public int the_stage;

    // Start is called before the first frame update
    void Start()
    {
        blocks = GameObject.FindGameObjectWithTag("Blocks").GetComponent<blocks>();
        reset_stage();
    }

    // Public methods
    public void increment_stage()
    {
        the_stage++;
        GetComponentInChildren<Text>().text = "Stage: " + the_stage.ToString();
        if(the_stage > 5) { blocks.important_count = 2; }
        if(the_stage > 8) { blocks.important_count = 3; }
        if(the_stage > 11) { blocks.important_count = 4; blocks.important_interval = 1; }
        if(the_stage > 15) { blocks.locked_interval = 2; }
        if(the_stage >= 18) { blocks.important_count = 5; }
        if (the_stage > 20) { blocks.locked_interval = 1; }
        if (the_stage > 21) { blocks.important_count = 6; }

    }

    public void reset_stage()
    {
        the_stage = 1;
        GetComponentInChildren<Text>().text = "Stage: " + the_stage.ToString();
    }
}
