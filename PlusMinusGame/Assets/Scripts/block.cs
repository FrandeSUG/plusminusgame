using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class block : MonoBehaviour
{
    public enum SPECIAL
    {
        NONE,
        LOCKED,
        IMPORTANT
    }

    public enum HPREFRESH
    {
        NONE,
        HP,
        REFRESH
    }

    public int index = 0;
    public int value;
    public bool clickable = false;
    public bool activated = false;

    public SPECIAL special;
    public HPREFRESH hprefresh;

    [SerializeField] private GameManager game_manager;
    [SerializeField] private combo combo;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        combo = GameObject.FindGameObjectWithTag("Combo").GetComponent<combo>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Public methods
    public void clicked()
    {
        if(clickable == true)
        {
            clickable = false;
            activated = true;
            combo.increment_combo();
            set_clicked_border(true);
            special = SPECIAL.NONE;
            game_manager.operate(index, value);
        }
    }

    public void refresh_number()
    {
        switch (special)
        {
            case SPECIAL.NONE:
                transform.Find("Number").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Puzzle stage & settings GUI Pack/Image_pink/txt/" + value);
                break;
            case SPECIAL.LOCKED:
                transform.Find("Hprefresh").gameObject.SetActive(false);
                transform.Find("Number").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/locked");
                break;
            case SPECIAL.IMPORTANT:
                transform.Find("Number").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Puzzle stage & settings GUI Pack/Image_orange/Text/" + value);
                break;
        }
        switch (hprefresh)
        {
            case HPREFRESH.NONE:
                transform.Find("Hprefresh").gameObject.SetActive(false);
                break;
            case HPREFRESH.HP:
                transform.Find("Hprefresh").gameObject.SetActive(true);
                transform.Find("Hprefresh").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon_70_10");
                break;
            case HPREFRESH.REFRESH:
                transform.Find("Hprefresh").gameObject.SetActive(true);
                transform.Find("Hprefresh").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/icon_100_03");
                break;
        }
        set_clicked_border(false);
    }

    // Private methods
    private void set_clicked_border(bool b)
    {
        if (b) { GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/ui_y_01"); }
        else { GetComponent<Image>().sprite = Resources.Load<Sprite>("03. Asset/Flat icoon n UI/ui_g_01"); }
    }

}
