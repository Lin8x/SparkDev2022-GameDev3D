using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // Declares multiple variables needed for the Settings.
    public Toggle fullscreenToggle, vSyncToggle;
    public TMP_Dropdown graphicsQualityDropdown;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown framerateDropdown;

    // List of resolutions.
    Resolution[] resolutions;

    // Framerate multiple of sorts; 30, 60, 90, 120...
    int framerateCount = 30;

    // This function happens at the start of the game
    void Start()
    {
        // Does a system check for VSync and Fullscreen on starting the game.
        fullscreenToggle.isOn = Screen.fullScreen;
        if(QualitySettings.vSyncCount == 0)
        {
            vSyncToggle.isOn = false;
        }else
        {
            vSyncToggle.isOn = true;
        }

        // Clear any leftover options to make it system dependent.
        graphicsQualityDropdown.ClearOptions();
        resolutionDropdown.ClearOptions();
        framerateDropdown.ClearOptions();

        // Assigned this variable to all the user's supported resolutions 
        resolutions = Screen.resolutions;

        // Converts all the values of the array into a resolution string list.
        List<string> resolutionOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionOptions.Add(resolutions[i].ToString());
        }
        // Added the string list to the resolution dropdown options.
        resolutionDropdown.AddOptions(resolutionOptions);
        // Automatically sets resolution's default value to the system's current resolution.
        resolutionDropdown.value = resolutionOptions.IndexOf(Screen.currentResolution.ToString());

        // Added all qualities to the quality string list.
        List<string> allQualityLevels = new List<string> (QualitySettings.names);
        // Added the string list to the resolution dropdown options.
        graphicsQualityDropdown.AddOptions(allQualityLevels);
        // Automatically sets graphics quality default value to the system's current resolution.
        graphicsQualityDropdown.value = QualitySettings.GetQualityLevel();

        // Creates a string array of framerates.
        List<string> framerates = new List<string>();
        // Adds all framerate possiblities by multiples of 30; to the list of options.
        while(Screen.currentResolution.refreshRate >= framerateCount)
        {
            framerates.Add(framerateCount.ToString() + " FPS");
            framerateCount += 30;
        }
        framerateDropdown.AddOptions(framerates);
        Application.targetFrameRate = framerateCount - 30;
        // Sets the current value to whichever framarate is being used.
        framerateDropdown.value = framerates.IndexOf((framerateCount-30).ToString() + " FPS");
        
    }

    public void openGameLevel()
    {
        SceneManager.LoadScene("Concept2");
    }

    // Applies all video settings at the same time.
    public void ApplyVideoSettings()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
        if(vSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        QualitySettings.SetQualityLevel(graphicsQualityDropdown.value);
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullscreenToggle.isOn);
        Application.targetFrameRate = (framerateDropdown.value + 1) * 30;
    }

    // This quits the application.
    public void QuitApplication()
    {
        Application.Quit();
    }
}
