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
    private int plus_minus;
    public GameObject blocks;
    public GameObject target;
    public GameObject sum;


    // Start is called before the first frame update
    void Start()
    {
        Init();
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Private methods
    private void Init()
    {
        block_array = blocks.GetComponentsInChildren<Button>();
    }

    // Public methods
    public void reset()
    {
        plus_minus = 0;
        generate_random_numbers();
        generate_target_number();
    }

    public void generate_target_number()
    {
        target_number = Random.Range(1, 9);
        target.transform.Find("TargetNumber").GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_red/txt/" + target_number + ".png", typeof(Sprite));
    }

    public void generate_random_numbers()
    {
        block_numbers = new int[block_array.Length];
        for (int i = 0; i < block_array.Length; i++)
        {
            block_numbers[i] = Random.Range(1, 9);
            block_array[i].transform.Find("Number").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_pink/txt/" + block_numbers[i] + ".png" , typeof(Sprite));
        }
    }

    public void operate()
    {

    }
}
