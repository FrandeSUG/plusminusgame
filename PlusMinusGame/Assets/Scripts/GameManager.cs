using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    private Button[] block_array;
    private int[] block_numbers;
    private int target_number;
    private float plus_minus;
    private bool count_down_start = false;
    private float timer;

    public GameObject blocks;
    public GameObject target;
    public GameObject sum;
    public combo combo;
    public float count_down_timer = 6;


    // Start is called before the first frame update
    void Start()
    {
        
        Init();
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (count_down()) { time_out_process(); }
        sum_background_change();
    }

    // Private methods
    private void Init()
    {
        block_array = blocks.GetComponentsInChildren<Button>();
        timer = count_down_timer;
    }

    private void refresh_sum()
    {
        sum.transform.Find("Text").GetComponent<Text>().text = plus_minus.ToString();
    }

    private void sum_background_change()
    {
        if (plus_minus == target_number)
        {
            sum.GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/icon 1024/effect_1024_01.png", typeof(Sprite));
        }
        else
        {
            sum.GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/icon 1024/effect_1024_02.png", typeof(Sprite));
        }
    }

    private bool count_down()
    {
        if (count_down_start) {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                count_down_start = false;
                timer = count_down_timer;
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void time_out_process()
    {
        set_block_unclickabable_array();
        Debug.Log("ended");
    }

    // Public methods
    public void reset()
    {
        plus_minus = 0;
        generate_random_numbers();
        generate_target_number();
        set_block_clickabable_array();
    }

    public void generate_target_number()
    {
        target_number = Random.Range(1, 9);
        target.transform.Find("TargetNumber").GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_red/txt/" + target_number + ".png", typeof(Sprite));
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

    public void generate_random_numbers()
    {
        block_numbers = new int[block_array.Length];
        for (int i = 0; i < block_array.Length; i++)
        {
            if(block_array[i].GetComponent<block>().index == 0)
            {
                block_numbers[i] = Random.Range(1, 9);
                block_array[i].transform.Find("Number").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_pink/txt/" + block_numbers[i] + ".png", typeof(Sprite));
                block_array[i].GetComponent<block>().index = i;
                block_array[i].GetComponent<block>().value = block_numbers[i];
            }
        }
    }

    public void operate(int index, int value)
    {
        if (!count_down_start) { count_down_start = true; Debug.Log("started"); }
        Debug.Log("index = " + index.ToString() + "    value = " + value.ToString());
        if(plus_minus <= target_number)
        {
            plus_minus += value;
            refresh_sum();
        }
        else
        {
            plus_minus -= value;
            refresh_sum();
        }
    }
}
