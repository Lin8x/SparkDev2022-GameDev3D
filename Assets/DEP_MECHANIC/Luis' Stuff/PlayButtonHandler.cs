using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Shift;
using TMPro;

public class PlayButtonHandler : MonoBehaviour
{

    [SerializeField]
    private SpotlightButton playButton;

    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI descriptionText;

    public void UpdateToResume()
    {
        titleText = gameObject.transform.Find("Content/Title").GetComponent<TextMeshProUGUI>();
        descriptionText = gameObject.transform.Find("Content/Description").GetComponent<TextMeshProUGUI>();

        titleText.text = "RESUME";
        descriptionText.text = "Survive and obtain the power of the Sun";

    }

}
