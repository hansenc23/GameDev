using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    
 
    public static int totalScore = 0;
    public int scoreOneLine = 40;
    public int scoreTwoLine = 100;
    public int scoreThreeLine = 300;
    public int scoreFourLine = 1200;
    public static int level = 0;
    public Text score;
    public Text numOfLines;
    public Text levelText;
    public static bool isPaused = false;
    private AudioSource gameMusic;
    public Canvas stats_canvas;
    public Canvas pause_canvas;
    //public Canvas item_canvas;
    public Button pauseButton;
    public Button resumeButton;
    public static bool isItemUsed = false;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameMusic = gameObject.GetComponent<AudioSource>();
        gameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        updateScoreUI();
        numOfLines.text = Tetromino.cleared.ToString();
        updateLevel();
        levelText.text = level.ToString();
        //CheckGamePaused();
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        //if (getItem() == true)
        //{
        //    item_canvas.enabled = true;
            
        //    if(isItemUsed == true)
        //    {
        //        disableItem();
        //    }

        //}
        //checkInput();

     
       
    }

    //void CheckGamePaused()
    //{
    //    if (Input.GetKeyUp(KeyCode.P))
    //    {
    //        if (Time.timeScale == 1)
    //            PauseGame();
    //        else
    //            ResumeGame();
    //    }
    //}

    //bool getItem()
    //{
    //    if(Tetromino.cleared >= 1)
    //    {
            
    //        return true;
    //    }

    //    return false;
    //}

    //void disableItem()
    //{
    //    item_canvas.enabled = false;

    //}



    //void useGridSweeper()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        isItemUsed = true;
    //        for (int i = 0; i < Tetromino.height; i++)
    //        {
    //            for (int j = 0; j < Tetromino.width; j++)
    //            {
    //                if (Tetromino.grid[j, i] != null)
    //                {
    //                    Destroy(Tetromino.grid[j, i].gameObject);
    //                }
    //            }
    //        }

    //        item_canvas.enabled = false;
    //    }
      

    //}

    //void checkIsItemUsed()
    //{
    //    if (Input.GetKeyUp(KeyCode.Q))
    //    {
    //        if(item_canvas.enabled == false)
    //        {
    //            item_canvas.enabled = true;
    //        }
    //        else
    //        {
    //            item_canvas.enabled = false;
    //        }
    //    }
        
    //}

    //void showItem()
    //{
    //    item_canvas.enabled = true;
    //}

    //void removeItem()
    //{
    //    item_canvas.enabled = false;
    //}

    //resume the game
    void ResumeGame()
    {
        Time.timeScale = 1;
        gameMusic.Play();
        pause_canvas.enabled = false;
        isPaused = false;
    }

    //pause the game
    void PauseGame()
    {
        Time.timeScale = 0;
        gameMusic.Pause();
        pause_canvas.enabled = true;
        isPaused = true;
    }
    public void updateLevel()
    {
        level = Tetromino.cleared / 10;
    }


    public void updateScoreUI()
    {
        score.text = totalScore.ToString();
    }


    public void UpdateScore()
    {
        //check number of lines cleared at once
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


    //score for 1 line cleared
    void ClearOne()
    {
        totalScore += scoreOneLine;
    }

    //score for 2 lines cleared at once
    void ClearTwo()
    {
        totalScore += scoreTwoLine;
    }

    //score for 3 lines cleared at once
    void ClearThree()
    {
        totalScore += scoreThreeLine;
    }

    //score for 4 lines cleared at once
    void ClearFour()
    {
        totalScore += scoreFourLine;
    }
}
