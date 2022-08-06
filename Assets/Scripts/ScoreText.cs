using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(1001)]
public class ScoreText : MonoBehaviour
{
    public Text highScoreText;

    void Awake()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        highScoreText.text = $"High Score : {ScoreManager.Instance.highName} : {ScoreManager.Instance.highScore}";
    }
}
