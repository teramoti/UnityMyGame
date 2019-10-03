using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private int score;
    public static int FinalScore = 0;
    public Text SCORELabel;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SCORELabel.text = "×" + score;

    }

    // Update is called once per frame
    void Update()
    {
        SCORELabel.text = "×" + score;
        print(FinalScore);
        FinalScore = score;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int addScore)
    {
        score += addScore;
    }

    public static int GetLastScore()
    {
        return FinalScore;
    }
}
