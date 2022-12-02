using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreStart : MonoBehaviour
{
    [SerializeField]
    private Text bestScore;

    // Start is called before the first frame update
    void Start()
    {
        int scoreValue = PlayerPrefs.GetInt("high score");
        bestScore.text = "Best Score – " + scoreValue.ToString();
    }

}
