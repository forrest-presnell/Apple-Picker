using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    [Header("Dynamic")]
    private int round = 1;
    private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        UpdateText();
    }

    public void UpdateText()
    {
        uiText.text = "Round: " + round.ToString("#");
    }

    public void IncrementRound()
    {
        round++;
        UpdateText();
    }
}
