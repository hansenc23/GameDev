using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tetromino : MonoBehaviour
{
    public Vector3 rotationPoint;
    float fall = 0;
    public float fallSpeed = 1;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];
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
        CheckUserInput();

        CheckLines();

        if (this.enabled == false)
        {
            //Debug.Log("DONE");
            //this.GetComponentInChildren<Animator>().enabled =

            foreach (Animator children in glowAnim)
            {
                //children.GetComponent<Animator>().enabled = false;
                Destroy(children.GetComponent<Animator>());
            }
        }


    }

    void CheckUserInput()
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
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;         
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
