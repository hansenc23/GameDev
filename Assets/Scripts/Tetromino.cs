using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tetromino : MonoBehaviour
{
    public Vector3 rotationPoint;
    float fall = 0;
    public float fallSpeed = 1.0f;
    public static int height = 20;
    public static int width = 10;
    public static Transform[,] grid = new Transform[width, height];
    public Animator[] glowAnim;
    public AudioClip[] clips = new AudioClip[2];
    public static int linesCleared = 0;
    public static int cleared = 0;


    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        glowAnim = gameObject.GetComponentsInChildren<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Game.isPaused)
        {

            CheckUserInput();
            //checkIsAboveGrid();
            CheckLines();

             
            disableAnimation();
        }




    }

    //bool checkIsAboveGrid()
    //{
    //    for(int i = 0; i < width; i++)
    //    {
    //        foreach(Transform children in transform)
    //        {
    //            int roundedX = Mathf.RoundToInt(children.transform.position.x);
    //            int roundedY = Mathf.RoundToInt(children.transform.position.y);

    //            if(roundedY > height - 1)
    //            {
                    
    //                return true;
                    
    //            }
    //        }
    //    }

    //    return false;
    //}

    void disableAnimation()
    {
        if (this.enabled == false)
        {
           
            foreach (Animator children in glowAnim)
            {
                
                Destroy(children.GetComponent<Animator>());
            }
        }
    }

    //check user input
    void CheckUserInput()
    {
        //check game level, as level increase tetromino will fall faster
        if(Game.level == 1)
        {
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed - 0.3))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    updateGrid();
                    FindObjectOfType<Spawner>().Spawn();

                    this.enabled = false;


                }

                fall = Time.time;
            }
        }
        else if(Game.level == 2)
        {
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed - 0.5))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    updateGrid();
                    FindObjectOfType<Spawner>().Spawn();

                    this.enabled = false;


                }

                fall = Time.time;
            }
        }
        else if(Game.level == 3)
        {
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed - 0.7))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    updateGrid();
                    FindObjectOfType<Spawner>().Spawn();

                    this.enabled = false;


                }

                fall = Time.time;
            }
        }
        else if (Game.level == 4)
        {
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed - 0.85))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    updateGrid();
                    FindObjectOfType<Spawner>().Spawn();

                    this.enabled = false;


                }

                fall = Time.time;
            }
        }
        else
        {
            //make the tetromino fall by checking it against Time.time
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed)) //e.g if Time.time = 1, fall = 0 >= fallspeed = 1 results to true, then tetromino will move down 1 unit.
            {
                transform.position += new Vector3(0, -1, 0);
                
                if (!ValidMove())
                {
                    transform.position -= new Vector3(0, -1, 0);
                    updateGrid(); //add to tetromino to 2d array when it has landed
                    FindObjectOfType<Spawner>().Spawn();

                    this.enabled = false;


                }

                fall = Time.time;
            }
        }
        
        
  
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove()) //check if inside grid
                transform.position -= new Vector3(-1, 0, 0); //reverse the movement
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove()) //check if inside grid
                transform.position -= new Vector3(1, 0, 0); //reverse the movement
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!gameObject.CompareTag("O"))
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                gameObject.GetComponent<AudioSource>().clip = clips[0];
                gameObject.GetComponent<AudioSource>().Play();
                if (!ValidMove()) //check if inside grid
                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90); //reverse the movement
            }

        }
    }

  

    //check if tetromino is inside the grid
    bool ValidMove()
    {
        //iterate through all the children
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x); //get rounded x position
            int roundedY = Mathf.RoundToInt(children.transform.position.y); //get rounded y position

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height) //check if position of children is inside the grid
            {
                return false; 
            }

            if(grid[roundedX, roundedY] != null) //check if grid coordinate contains a mino
            {
                return false;
            }
        }

        return true;
    }

    //add landed tetromino to 2d array(grid)
    void updateGrid()
    {
        try
        {
            //iterate through all the children
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x); //get rounded x position
                int roundedY = Mathf.RoundToInt(children.transform.position.y); //get rounded y position

                grid[roundedX, roundedY] = children; //add to 2d array
            }
        }
        catch
        {
            SceneManager.LoadScene(3);
        }
        
         
        
    }

    //check if there is line
    void CheckLines()
    {
       
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                gameObject.GetComponent<AudioSource>().clip = clips[1];
                gameObject.GetComponent<AudioSource>().Play();
                DeleteLine(i);
                RowDown(i);
            }
            
        }
        
         
    }

    bool HasLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            if(grid[j,i] == null)
            {
                return false;
            }
        }
        linesCleared++;
        cleared++;
        
        return true;
    }

    void DeleteLine(int i)
    {
        for(int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
        

    }

    

    void RowDown(int i)
    {
        for(int k = i; k < height; k++)
        {
            for(int j = 0; j< width; j++)
            {
                if(grid[j,k] != null)
                {
                    grid[j, k - 1] = grid[j, k];
                    grid[j, k] = null;
                    grid[j, k - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }
}
