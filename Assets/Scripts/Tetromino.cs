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

    void CheckUserInput()
    {
      
        if(Game.level == 1)
        {
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed - 0.4))
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
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed - 0.6))
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
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed - 0.8))
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
            if (Time.time - fall >= (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed))
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
        
        
  
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!gameObject.CompareTag("O"))
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
                gameObject.GetComponent<AudioSource>().clip = clips[0];
                gameObject.GetComponent<AudioSource>().Play();
                if (!ValidMove())
                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }

        }
    }

    public void clearGrid()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (grid[j, i] != null)
                    {
                        Destroy(grid[j, i].gameObject);
                    }
                }
            }
        }
    }


    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if(grid[roundedX, roundedY] != null)
            {
                return false;
            }
        }

        return true;
    }

    void updateGrid()
    {
        try
        {
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                grid[roundedX, roundedY] = children;
            }
        }
        catch
        {
            SceneManager.LoadScene(2);
        }
        
         
        
    }

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
