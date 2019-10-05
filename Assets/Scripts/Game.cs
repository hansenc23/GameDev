using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    
 
    public int totalScore = 0;
    public int scoreOneLine = 40;
    public int scoreTwoLine = 100;
    public int scoreThreeLine = 300;
    public int scoreFourLine = 1200;
    public Text score;
    public Text numOfLines;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        updateScoreUI();
        numOfLines.text = Tetromino.cleared.ToString();
    }


    public void updateScoreUI()
    {
        score.text = totalScore.ToString();
    }

    public void UpdateScore()
    {
        if (Tetromino.linesCleared > 0)
        {
            if (Tetromino.linesCleared == 1)
            {
                ClearOne();
            }
            else if (Tetromino.linesCleared == 2)
            {
                ClearTwo();
            }
            else if (Tetromino.linesCleared == 3)
            {
                ClearThree();
            }
            else if (Tetromino.linesCleared == 4)
            {
                ClearFour();
            }

            Tetromino.linesCleared = 0;
        }
    }

    void ClearOne()
    {
        totalScore += scoreOneLine;
    }

    void ClearTwo()
    {
        totalScore += scoreTwoLine;
    }

    void ClearThree()
    {
        totalScore += scoreThreeLine;
    }

    void ClearFour()
    {
        totalScore += scoreFourLine;
    }
}
