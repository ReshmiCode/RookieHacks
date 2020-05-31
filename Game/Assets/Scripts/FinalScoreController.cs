using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreController : MonoBehaviour
{
    public static FinalScoreController instance { get; private set; }
    public Text scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            scoreText.text = "0";
        }
    }
}

