using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collect_totem : MonoBehaviour
{
    public player_script sript_player;
    public storm_script script_storm;
    public GameObject player;
    public GameObject this_object;
    public GameObject text_to_display;
    public TextMesh question_text;
    public AudioSource deposit_sound;
    public AudioSource error;
    public GameObject action_music;
    public GameObject win_round;
    public Text round_text;
    public int collectibles_amount = 0;

    private void Update()
    {
       
        if (collectibles_amount >= 5)
        {
            sript_player.round = sript_player.round + 1;
            round_text.text ="Round - " + sript_player.round.ToString();
            win_round.SetActive(true);
            action_music.SetActive(false);
            script_storm.start_stom_rush = true;
            collectibles_amount = 0;
        }


        question_text.text = collectibles_amount.ToString();
        text_to_display.transform.LookAt(player.transform.position);

        if (Vector3.Distance(this_object.transform.position, player.transform.position) < 2.3f)
        {
            text_to_display.SetActive(true);

            if (Input.GetKeyDown("e") && sript_player.question_mark_pickup >=1)
            {
                sript_player.question_mark_pickup = sript_player.question_mark_pickup - 1;
                collectibles_amount = collectibles_amount + 1;
                deposit_sound.Play();
            }
            else if(Input.GetKeyDown("e") && sript_player.question_mark_pickup < 1)
            {
                error.Play();
            }

        }
        else
        {
            text_to_display.SetActive(false);
        }
    }
}
