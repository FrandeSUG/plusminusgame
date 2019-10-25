using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

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
                transform.Find("Number").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_pink/txt/" + value + ".png", typeof(Sprite));
                break;
            case SPECIAL.LOCKED:
                transform.Find("Number").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/locked.png", typeof(Sprite));
                break;
            case SPECIAL.IMPORTANT:
                transform.Find("Number").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_orange/Text/" + value + ".png", typeof(Sprite));
                break;
        }
        switch (hprefresh)
        {
            case HPREFRESH.NONE:
                transform.Find("Hprefresh").gameObject.SetActive(false);
                break;
            case HPREFRESH.HP:
                transform.Find("Hprefresh").gameObject.SetActive(true);
                transform.Find("Hprefresh").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/icon_70_10.png", typeof(Sprite));
                break;
            case HPREFRESH.REFRESH:
                transform.Find("Hprefresh").gameObject.SetActive(true);
                transform.Find("Hprefresh").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/icon_100_03.png", typeof(Sprite));
                break;
        }
        set_clicked_border(false);
    }

    // Private methods
    private void set_clicked_border(bool b)
    {
        if (b) { GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/ui_y_01.png", typeof(Sprite)); }
        else { GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/ui_g_01.png", typeof(Sprite)); }
    }

}
