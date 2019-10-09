using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public Canvas item_canvas;
    public Canvas[] items_canvas;
    public AudioClip[] clips;
    
    private bool itemUsed = false;
    //public GameObject canvas;
    //public GameObject enemyCar;
    bool useItemSweeper = false;
    bool useItemPoints = false;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Tetromino.cleared >= 5)
        {
            //useGridSweeper();
            //if (useItem == true)
            //{
            //    disableGridSweeper();

            //}
            items_canvas[0].enabled = true;

            if (items_canvas[0].enabled == true)
            {
                useGridSweeper();
                if (useItemSweeper == true)
                {
                    items_canvas[0].enabled = false;
                }

            }
        }

        if (Tetromino.cleared >= 10)
        {
            
            items_canvas[1].enabled = true;
            if(items_canvas[1].enabled == true)
            {
                useBonusPoints();
                if (useItemPoints == true)
                {
                    items_canvas[1].enabled = false;
                }
            }

          
        }



        //if (Tetromino.cleared >= 10)
        //{
        //    useBonusPoints();
        //    if (useBonus == true)
        //    {
        //        disableBonusPoints();


        //    }


        //}



        //if (Tetromino.cleared > 0 && isEven() == true)
        //{
        //    item_canvas.enabled = true;
        //    useGridSweeper();
        //    checkIsItemUsed();

        //}

        //if(Tetromino.cleared == 3)
        //{
        //    if (gameObject.GetComponent<Item>().enabled == false)
        //        Debug.Log("SCRIPT FALSE");
        //        gameObject.GetComponent<Item>().enabled = true;

        //    //gameObject.GetComponent<Item>().enabled = true;
        //}

        //if (gameObject.GetComponent<Item>().enabled == false)
        //{
        //    gameObject.GetComponent<Item>().enabled = true;
        //}

        //else
        //{
        //    gameObject.GetComponent<Item>().enabled = false;
        //}

        //if(item_canvas.enabled == true)
        //{
        //    useGridSweeper();
        //}

        //if(itemUsed == true)
        //{
        //    item_canvas.enabled = false;
        //    gameObject.GetComponent<Item>().enabled = false;

        //}
        addLevel();
    }

    void addLevel()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tetromino.cleared += 1;
        }
    }

    bool isEven()
    {
        if(Tetromino.cleared % 2 == 0)
        {
            return true;
        }

        return false;
    }

    public void useGridSweeper()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            useItemSweeper = true;
            gameObject.GetComponent<AudioSource>().clip = clips[0];
            gameObject.GetComponent<AudioSource>().Play();


            for (int i = 0; i < Tetromino.height; i++)
            {
                for (int j = 0; j < Tetromino.width; j++)
                {
                    if (Tetromino.grid[j, i] != null)
                    {
                        Destroy(Tetromino.grid[j, i].gameObject);
                    }
                }
            }

            
        }

    }

    public void disableGridSweeper()
    {
        items_canvas[0].enabled = false;
        
        //gameObject.GetComponent<Item>().enabled = false;
    }

    public void useBonusPoints()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            useItemPoints = true;
            gameObject.GetComponent<AudioSource>().clip = clips[1];
            gameObject.GetComponent<AudioSource>().Play();
            Game.totalScore += 10000;
        }
    }
     
    public void disableBonusPoints()
    {
        items_canvas[1].enabled = false;
        useItemPoints = false;
       // gameObject.GetComponent<Item>().enabled = false;
    }

    //void CreateEnemy()
    //{
    //    GameObject newCanvas = Instantiate(canvas) as GameObject;
    //    GameObject createImage = Instantiate(enemyCar) as GameObject;
    //    createImage.transform.SetParent(newCanvas.transform, false);
    //}

    void checkIsItemUsed()
    {
       if(itemUsed == true)
        {
            item_canvas.enabled = false;
            gameObject.GetComponent<Item>().enabled = false;
        }
        

    }

    void showItem()
    {
        item_canvas.enabled = true;
    }

    void removeItem()
    {
        item_canvas.enabled = false;
    }

}
