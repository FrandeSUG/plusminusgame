using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private blocks blocks;
    [SerializeField] private target target;
    [SerializeField] private sum sum;
    [SerializeField] private combo combo;
    [SerializeField] private timer timer;
    [SerializeField] private lifes_score lifes_score;
    [SerializeField] private game_over game_over;
    [SerializeField] private stage stage;



    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Private methods
    private void Init()
    {
        blocks = GameObject.FindGameObjectWithTag("Blocks").GetComponent<blocks>();
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<target>();
        sum = GameObject.FindGameObjectWithTag("Sum").GetComponent<sum>();
        combo = GameObject.FindGameObjectWithTag("Combo").GetComponent<combo>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();
        lifes_score = GameObject.FindGameObjectWithTag("LifesScore").GetComponent<lifes_score>();
        game_over = GameObject.FindGameObjectWithTag("GameOver").GetComponent<game_over>();
        stage = GameObject.FindGameObjectWithTag("Stage").GetComponent<stage>();
    }

    // Public methods
    public void operate(int index, int value)
    {
        if (!timer.count_down_start) { timer.count_down_start = true; Debug.Log("started"); }
        Debug.Log("index = " + index.ToString() + "    value = " + value.ToString());
        if(sum.the_sum <= target.target_number)
        {
            sum.the_sum += value;
            sum.refresh_sum();
        }
        else
        {
            sum.the_sum -= value;
            sum.refresh_sum();
        }
    }

    public bool is_game_over()
    {
        if(target.target_number != sum.the_sum || blocks.has_important())
        {
            lifes_score.decrement_lifes();
            if(lifes_score.the_lifes <= 0)
            {
                game_over.over_and_score(lifes_score.the_score, stage.the_stage);
                return true;
            }
        }
        return false;
    }
}
