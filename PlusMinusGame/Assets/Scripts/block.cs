using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class block : MonoBehaviour
{
    public int index = 0;
    public int value;
    public bool clickable = false;
    public bool activated = false;

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
            game_manager.operate(index, value);
        }
    }

    public void refresh_number()
    {
        transform.Find("Number").GetComponentInChildren<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Puzzle stage & settings GUI Pack/Image_pink/txt/" + value + ".png", typeof(Sprite));
        set_clicked_border(false);
    }

    // Private methods
    private void set_clicked_border(bool b)
    {
        if (b) { GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/ui_y_01.png", typeof(Sprite)); }
        else { GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/ui_g_01.png", typeof(Sprite)); }
    }
}
