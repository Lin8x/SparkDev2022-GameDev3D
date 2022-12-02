using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolution : MonoBehaviour
{

    private int aspectRatioIndex;
    private int qualityResolutionIndex;
    private int fullScreen;
    private int refreshRate;
    private int[,,] resolution;

    void Start()
    {
                                              //        Low               SD              HD             QHD              4K
        resolution = new int[4, 5, 2] { {   { 800, 600 },   { 1024, 768 },  { 1280, 960 },  { 1920, 1440 }, { 2560, 1920 } },   // 4:3
                                    {       { 854, 480 },   { 1280, 720 },  { 1920, 1080 }, { 2560, 1440 }, { 3840, 2160 } },   // 16:9
                                    {       { 640, 400 },   { 1280, 800 },  { 1920, 1200 }, { 2560, 1600 }, { 3840, 2400 } },   // 16:10
                                    {       { 1120, 480 },  { 1680, 720 },  { 2520, 1080 }, { 3360, 1440 }, { 5040, 2160 } } }; // 21:9


        // Usage: resolution[aspectRatioIndex, qualityResolutionIndex, 0 || 1] (0 is width and 1 is height) 


        aspectRatioIndex = PlayerPrefs.GetInt("Aspect Ratio" + "HSelectorValue");
        qualityResolutionIndex = PlayerPrefs.GetInt("Resolution" + "HSelectorValue");
        fullScreen = PlayerPrefs.GetInt("Window Mode" + "HSelectorValue");
        refreshRate = PlayerPrefs.GetInt("Refresh Rate" + "HSelectorValue");

    }

    public void SetAspectRatio(int index)
    {

        aspectRatioIndex = index; // (0.) 4:3, (1.) 16:9, (2.) 16:10, (3.) 21:9

    }

    public void SetQualityResolution(int index)
    {

        qualityResolutionIndex = index; // (0.) Low, (1.) SD, (2.) HD, (3.) QHD, (4.) 4K

    }

    public void SetRefreshRate(int value)
    {

        refreshRate = value; // 0 - No Limits, 30 FPS, 60 FPS, 75 FPS, 90 FPS, 120 FPS, 144 FPS

    }

    public void IsFullScreen(int yes)
    {

        fullScreen = yes; // (0.) Windowed, (1.) FullScreenWindow
        // I had to change it from bool to int, so I can use PlayerPrefs.GetInt

    }


    public void Apply()
    {

        /* Types of Full Screen
         
         * ExclusiveFullScreen: Only supported by Windows. Made to set the game to maintain the sole full-screen use of display.
         * FullScreenWindow: Supported by all devices. Also known as Borderless Full Screen.
         * MaximizedWindow: Only supported by Mac OS. This is a full screen hiding the menu bar and dock of Mac OS. If used by other OS, it calls to FullScreenWindow.
         * Windowed: Supported by all desktop devices. This is a regular windows.
            
           I'll oly use FullScreenWindow and Windowed. */

        if (fullScreen == 1)
            Screen.SetResolution(resolution[aspectRatioIndex, qualityResolutionIndex, 0], resolution[aspectRatioIndex, qualityResolutionIndex, 1], FullScreenMode.FullScreenWindow, refreshRate);
        else
            Screen.SetResolution(resolution[aspectRatioIndex, qualityResolutionIndex, 0], resolution[aspectRatioIndex, qualityResolutionIndex, 1], FullScreenMode.Windowed, refreshRate);

    }
}
