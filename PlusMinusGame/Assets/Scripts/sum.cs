using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sum : MonoBehaviour
{
    public float the_sum;
    [SerializeField] private target target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<target>();
        reset_the_sum();
    }

    // Update is called once per frame
    void Update()
    {
        sum_background_change();
    }

    //Public methods
    public void reset_the_sum()
    {
        the_sum = 0;
        refresh_sum();
    }

    public void refresh_sum()
    {
        transform.Find("Text").GetComponent<Text>().text = the_sum.ToString();
    }

    private void sum_background_change()
    {
        if (the_sum == target.target_number)
        {
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 1024/effect_1024_01");
        }
        else
        {
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon 1024/effect_1024_02");
        }
    }
}
