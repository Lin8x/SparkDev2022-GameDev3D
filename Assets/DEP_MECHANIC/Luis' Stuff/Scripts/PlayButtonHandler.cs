using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Shift;

public class PlayButtonHandler : MonoBehaviour
{

    [SerializeField]
    private SpotlightButton playButton;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private string title;
    [SerializeField]
    private string description;

    public void UpdateToResume()
    {
        playButton.UpdateByButton(title, description);

    }

    public void Hide()
    {
        button.SetActive(false);

    }

}
