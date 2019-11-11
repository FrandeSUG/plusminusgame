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
        blocks.important_count = the_stage / 2;
        if(blocks.important_count >= 8) { blocks.important_count = 8; }
        if (the_stage >= 18) { blocks.important_interval = 1; }
        if (the_stage == 6) { blocks.locked_count = 2; }
        if (the_stage == 9) { blocks.locked_count = 3; }
        if (the_stage == 12) { blocks.locked_count = 4; }
        if (the_stage == 17) { blocks.locked_interval = 1; }
        if (the_stage == 18) { blocks.locked_count = 0; }
        if (the_stage == 19) { blocks.locked_count = 4; }
        if (the_stage == 20) { blocks.locked_count = 0; }
        if (the_stage == 21) { blocks.locked_count = 4; }


    }

    public void reset_stage()
    {
        the_stage = 1;
        GetComponentInChildren<Text>().text = "Stage: " + the_stage.ToString();
    }
}
