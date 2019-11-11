using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class blocks : MonoBehaviour
{
    [SerializeField] private GameManager game_manager;
    [SerializeField] private block[] block_array;
    [SerializeField] private target target;
    [SerializeField] private sum sum;
    [SerializeField] private combo combo;
    [SerializeField] private timer timer;
    [SerializeField] private lifes_score lifes_score;
    [SerializeField] private stage stage;
    [SerializeField] private refresh refresh;
    [SerializeField] private ParticleSystem swipe;

    public AudioClip for_generate;
    public AudioClip for_decrement;
    public AudioClip for_refresh;
    public Image hp_decrement;

    public AudioSource audio;

    public float end_buffer_time = 2f;
    public int locked_interval = 3;
    public int locked_count = 1; // max 4
    public int important_interval = 2;
    public int important_count = 1;
    public int hp_drop_rate = 4;
    public int refresh_drop_rate = 4;


    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        block_array = gameObject.GetComponentsInChildren<block>();
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<target>();
        sum = GameObject.FindGameObjectWithTag("Sum").GetComponent<sum>();
        combo = GameObject.FindGameObjectWithTag("Combo").GetComponent<combo>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();
        lifes_score = GameObject.FindGameObjectWithTag("LifesScore").GetComponent<lifes_score>();
        stage = GameObject.FindGameObjectWithTag("Stage").GetComponent<stage>();
        refresh = GameObject.FindGameObjectWithTag("Refresh").GetComponent<refresh>();
        swipe = GameObject.FindGameObjectWithTag("Swipe").GetComponent<ParticleSystem>();
        audio = gameObject.GetComponent<AudioSource>();
        generate_random_numbers();
        set_block_clickabable_array();
        damage_off();
    }

    //Public methods
    public bool has_important()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            if(block_array[i].special == block.SPECIAL.IMPORTANT) { return true; }
        }
        return false;
    }

    public void generate_random_numbers()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            block_array[i].value = Random.Range(1, 9);
            block_array[i].special = block.SPECIAL.NONE;
            block_array[i].hprefresh = block.HPREFRESH.NONE;
            block_array[i].refresh_number();
            block_array[i].index = i;
        }
        set_block_clickabable_array();
    }

    public void set_block_clickabable_array()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            if (block_array[i].special != block.SPECIAL.LOCKED) { block_array[i].GetComponent<block>().clickable = true; }
        }
    }


    public void set_block_unclickabable_array()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            block_array[i].GetComponent<block>().clickable = false;
        }
    }

    public void end_process()
    {
        set_block_unclickabable_array();
        if (game_manager.is_game_over()) { return; }
        if (target.target_number == sum.the_sum && !has_important()) { lifes_score.calculate_score(combo.count); stage.increment_stage(); }

        if (target.target_number != sum.the_sum || has_important())
        {
            audio.clip = for_decrement;
            damage_on();
            Invoke("damage_off", 0.2f);
        }
        else
        {
            audio.clip = for_generate;
            play_particle();
        }
        blocks_movement();
        blocks_special();
        combo.reset_combo();
        timer.reset_timer();
        target.generate_target_number();
        sum.reset_the_sum();
        audio.Play();
        Invoke("set_block_clickabable_array", end_buffer_time);
    }

    public void play_particle()
    {
        swipe.Play();
    }

    //Private methods
    private bool activated_exist()
    {
        for (int i = 0; i < block_array.Length; i++)
        {
            if (block_array[i].activated == true) { return true; }
        }
        return false;
    }

    private void blocks_movement()
    {
        while (activated_exist())
        {
            for (int i = block_array.Length - 1; i >= 0; i--)
            {
                if (block_array[i].activated)
                {
                    if (i - 4 < 0)
                    {
                        check_block_hprefresh(block_array[i]);
                        block_array[i].activated = false;
                        block_array[i].value = Random.Range(1, 9);
                        block_array[i].special = block.SPECIAL.NONE;
                        block_array[i].hprefresh = block.HPREFRESH.NONE;
                        block_array[i].refresh_number();
                    }
                    else
                    {
                        if (!block_array[i - 4].activated)
                        {
                            check_block_hprefresh(block_array[i]);
                            block_array[i].activated = false;
                            block_array[i].value = block_array[i - 4].value;
                            block_array[i].special = block_array[i - 4].special;
                            block_array[i].hprefresh = block_array[i - 4].hprefresh;
                            block_array[i - 4].activated = true;
                            // Delete locked when reach bottom
                            if(block_array[i].special == block.SPECIAL.LOCKED && i >= 12) { block_array[i].activated = true; }

                            block_array[i].refresh_number();
                        }
                    }
                }
            }
        }
    }

    private void check_block_hprefresh(block block)
    {
        if(block.hprefresh == block.HPREFRESH.HP) { if (sum.the_sum == target.target_number) { lifes_score.increment_lifes(); } }
        if (block.hprefresh == block.HPREFRESH.REFRESH) { if (sum.the_sum == target.target_number) { refresh.set_activation(true); } }
        block.hprefresh = block.HPREFRESH.NONE;
    }

    private bool refresh_exist()
    {
        for (int i = block_array.Length - 1; i >= 0; i--)
        {
            if(block_array[i].hprefresh == block.HPREFRESH.REFRESH) { return true; }
        }
        return false;
    }

    private void blocks_special()
    {
        // For locked
        if (stage.the_stage % locked_interval == 0)
        {
            int count = locked_count;
            int tries_allowed = block_array.Length * 10;
            while (count > 0 && tries_allowed > 0)
            {
                int i = Random.Range(0, block_array.Length / 4);
                if(block_array[i].special != block.SPECIAL.LOCKED)
                {
                    block_array[i].special = block.SPECIAL.LOCKED;
                    block_array[i].refresh_number();
                    count--;
                }
                tries_allowed--;
            }
        }

        // For important
        if (stage.the_stage % important_interval == 0)
        {
            int count = important_count;
            int tries_allowed = block_array.Length * 10;
            while (count > 0 && tries_allowed > 0)
            {
                int i = Random.Range(0, block_array.Length);
                if (block_array[i].special != block.SPECIAL.IMPORTANT && block_array[i].special != block.SPECIAL.LOCKED)
                {
                    block_array[i].special = block.SPECIAL.IMPORTANT;
                    block_array[i].refresh_number();
                    count--;
                }
                tries_allowed--;
            }
        }

        // For HP
        if(Random.Range(1, 101) <= hp_drop_rate)
        {
            int count = 1;
            int tries_allowed = block_array.Length * 10;
            while (count > 0 && tries_allowed > 0)
            {
                int i = Random.Range(0, block_array.Length);
                if (block_array[i].special != block.SPECIAL.LOCKED && block_array[i].hprefresh != block.HPREFRESH.HP && block_array[i].hprefresh != block.HPREFRESH.REFRESH)
                {
                    block_array[i].hprefresh = block.HPREFRESH.HP;
                    block_array[i].refresh_number();
                    count--;
                }
                tries_allowed--;
            }
        }

        // For refresh
        if (Random.Range(1, 101) <= refresh_drop_rate && !refresh.is_active && !refresh_exist())
        {
            int count = 1;
            int tries_allowed = block_array.Length * 10;
            while (count > 0 && tries_allowed > 0)
            {
                int i = Random.Range(0, block_array.Length);
                if (block_array[i].special != block.SPECIAL.LOCKED && block_array[i].hprefresh != block.HPREFRESH.HP && block_array[i].hprefresh != block.HPREFRESH.REFRESH)
                {
                    block_array[i].hprefresh = block.HPREFRESH.REFRESH;
                    block_array[i].refresh_number();
                    count--;
                }
                tries_allowed--;
            }
        }
    }

    private void damage_on()
    {
        hp_decrement.color = new Color(1f, 0f, 0f, 0.5f);
    }

    private void damage_off()
    {
        hp_decrement.color = new Color(1f, 0f, 0f, 0f);
    }
}
