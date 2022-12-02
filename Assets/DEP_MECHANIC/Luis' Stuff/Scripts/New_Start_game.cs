using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Start_game : MonoBehaviour
{
    public GameObject player;
    public GameObject sounds;
    public GameObject player_ui;
    public GameObject menu_ui;
    public GameObject menu_GO;
    //public GameObject options_menu;
    public AudioSource click_sound;
    public GameObject storm_go;
    public GameObject death_menu;
    public GameObject exitBox;
    public player_script script_player;
    public bool HUDFlag;
    public PlayButtonHandler dieButtonDissapear;

    public void start_game()
    {

        if (PlayerPrefs.GetString("HUD" + "Switch") == "true")
            HUDFlag = true;
        else
            HUDFlag = false;

        click_sound.Play();
        storm_go.SetActive(true);
        player.SetActive(true);
        sounds.SetActive(true);
        if (HUDFlag)
            player_ui.SetActive(true);
        menu_ui.SetActive(false);
        menu_GO.SetActive(false);
        
    }

    public void disableHUD()
    {
        HUDFlag = false;
    }

    public void activateHUD()
    {
        HUDFlag = true;
    }


    public void restart_game()
    {
        SceneManager.LoadScene(0);
    }
    /*
    public void options_button()
    {
        click_sound.Play();
        if (options_menu.activeInHierarchy == true)
        {
            options_menu.SetActive(false);
        }
        else
        {
            options_menu.SetActive(true);
        }
        
    }
    */
    public void quit_game()
    {
        click_sound.Play();
        Application.Quit();
    }

    public void set_quality(int quality)
    {
        if (quality == 0)
        {
            QualitySettings.SetQualityLevel(0);
        }
        if (quality == 1)
        {
            QualitySettings.SetQualityLevel(1);
        }
        if (quality == 2)
        {
            QualitySettings.SetQualityLevel(2);
        }
    }


    private void Update()
    {

        if (script_player.health <= 0 && player.activeInHierarchy == true && death_menu.activeInHierarchy == false)
        {
            click_sound.Play();
            storm_go.SetActive(false);
            player.SetActive(false);
            sounds.SetActive(false);
            player_ui.SetActive(false);
            menu_ui.SetActive(true);
            menu_GO.SetActive(true);
            death_menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dieButtonDissapear.Hide();
        }


        if (Input.GetKeyDown("r") && death_menu.activeInHierarchy == true)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && player.activeInHierarchy == true && death_menu.activeInHierarchy == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            click_sound.Play();
            storm_go.SetActive(false);
            player.SetActive(false);
            sounds.SetActive(false);
            player_ui.SetActive(false);
            menu_ui.SetActive(true);
            menu_GO.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && player.activeInHierarchy == false && death_menu.activeInHierarchy == false && exitBox.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            storm_go.SetActive(true);
            click_sound.Play();
            player.SetActive(true);
            sounds.SetActive(true);
            if(HUDFlag)
                player_ui.SetActive(true);
            menu_ui.SetActive(false);
            menu_GO.SetActive(false);
            dieButtonDissapear.UpdateToResume();
        }
    }


}
