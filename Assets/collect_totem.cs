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

    int collectibles_amount = 0;

    private void Update()
    {
        if(collectibles_amount >= 5)
        {
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
