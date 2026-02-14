using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        uiText.text = "Score 0";
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Score: " + score.ToString("#,0"); // This 0 is a zero!
    }
}
