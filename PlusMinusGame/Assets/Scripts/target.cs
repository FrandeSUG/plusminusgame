using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class target : MonoBehaviour
{
    public int target_number;

    // Start is called before the first frame update
    void Start()
    {
        generate_target_number();
    }

    public void generate_target_number()
    {
        target_number = Random.Range(1, 9);
        transform.Find("TargetNumber").GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_red/txt/" + target_number + ".png", typeof(Sprite));
    }
}
