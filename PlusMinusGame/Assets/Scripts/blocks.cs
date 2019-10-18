using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class blocks : MonoBehaviour
{
    [SerializeField] private GameManager game_manager;
    [SerializeField] private block[] block_array;
    [SerializeField] private target target;
    [SerializeField] private sum sum;
    [SerializeField] private combo combo;
    [SerializeField] private timer timer;
    [SerializeField] private lifes_score lifes_score;
    [SerializeField] private stage stage;

    public float end_buffer_time = 2f;


    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        block_array = gameObject.GetComponentsInChildren<block>();
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<target>();
        sum = GameObject.FindGameObjectWithTag("Sum").GetComponent<sum>();
        combo = GameObject.FindGameObjectWithTag("Combo").GetComponent<combo>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();
        lifes_score = GameObject.FindGameObjectWithTag("LifesScore").GetComponent<lifes_score>();
        stage = GameObject.FindGameObjectWithTag("Stage").GetComponent<stage>();
        generate_random_numbers();
        set_block_clickabable_array();
    }

    //Public methods
    public void generate_random_numbers()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            if (block_array[i].index == 0)
            {
                block_array[i].value = Random.Range(1, 9);
                block_array[i].refresh_number();
                block_array[i].index = i;
            }
        }
    }

    public void set_block_clickabable_array()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            block_array[i].GetComponent<block>().clickable = true;
        }
    }

    public void set_block_unclickabable_array()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            block_array[i].GetComponent<block>().clickable = false;
        }
    }

    public void end_process()
    {
        set_block_unclickabable_array();
        if (game_manager.is_game_over()) { return; }
        if (target.target_number == sum.the_sum) { lifes_score.calculate_score(combo.count); stage.increment_stage(); }

        blocks_movement();
        combo.reset_combo();
        timer.reset_timer();
        target.generate_target_number();
        sum.reset_the_sum();
        Invoke("set_block_clickabable_array", end_buffer_time);
    }

    //Private methods
    private bool activated_exist()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            if (block_array[i].activated == true) { return true; }
        }
        return false;
    }

    private void blocks_movement()
    {
        while (activated_exist())
        {
            for (int i = block_array.Length - 1; i >= 0; i--)
            {
                if (block_array[i].activated)
                {
                    if (i - 4 < 0)
                    {
                        block_array[i].activated = false;
                        block_array[i].value = Random.Range(1, 9);
                        block_array[i].refresh_number();
                    }
                    else
                    {
                        if (!block_array[i - 4].activated)
                        {
                            block_array[i].activated = false;
                            block_array[i].value = block_array[i - 4].value;
                            block_array[i].refresh_number();
                            block_array[i - 4].activated = true;
                        }
                    }
                }
            }
        }
    }
}
