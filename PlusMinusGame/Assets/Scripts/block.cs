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
    GameManager game_manager;
    combo combo;
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
            combo.increment_combo();
            gameObject.GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/03. Asset/Flat icoon n UI/ui_y_01.png", typeof(Sprite));
            game_manager.operate(index, value);
        }
    }
}
