using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateDevInfo : MonoBehaviour
{

    [Header("Script Reference")] 
    public PlayerMove playerMoveScript;

    [Header("UI Parts")]
    //components
    public TMP_Text velocityText;
    public TMP_Text positionText;
    public TMP_Text jumpText;
    public TMP_Text groundedText;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        velocityText.text = "Velocity: " + (playerMoveScript.rb.velocity).ToString();
        positionText.text = "Position: " + (playerMoveScript.transform.position).ToString();
        jumpText.text = "Jump: " + (playerMoveScript.readyToJump).ToString();
        groundedText.text = "Grounded: " + (playerMoveScript.grounded).ToString();
    }
}
