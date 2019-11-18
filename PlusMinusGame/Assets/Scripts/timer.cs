using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class timer : MonoBehaviour
{
    public bool count_down_start = false;
    private float the_timer;
    private int bar_max = 780;
    public float count_down_timer = 6;

    [SerializeField] private blocks blocks;
    [SerializeField] private refresh refresh;

    // Start is called before the first frame update
    void Start()
    {
        blocks = GameObject.FindGameObjectWithTag("Blocks").GetComponent<blocks>();
        refresh = GameObject.FindGameObjectWithTag("Refresh").GetComponent<refresh>();
        the_timer = count_down_timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (count_down()) { time_out_process(); }
    }

    // Public methods
    public void reset_timer()
    {
        transform.Find("Bar").GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, bar_max);
    }

    // Private methods
    private void time_out_process()
    {
        blocks.end_process();
        refresh.set_clickable(true);
        Debug.Log("ended");
    }

    private bool count_down()
    {
        if (count_down_start)
        {
            the_timer -= Time.deltaTime;
            transform.Find("Bar").GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, ((the_timer / count_down_timer) * bar_max));
            if (the_timer <= 0 || blocks.all_clicked())
            {
                count_down_start = false;
                the_timer = count_down_timer;
                return true;
            }
        }
        return false;
    }
}
