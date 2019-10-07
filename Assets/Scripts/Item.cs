using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public Canvas item_canvas;
    private bool itemUsed = false;
    //public GameObject canvas;
    //public GameObject enemyCar;
    bool called = false;


    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Tetromino.cleared >= 1)
        {
            
            item_canvas.enabled = true;
            
            useGridSweeper();
        }

        if(itemUsed == true)
        {
            item_canvas.enabled = false;
            gameObject.GetComponent<Item>().enabled = false;

        }
    }


    void useGridSweeper()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            itemUsed = true;
           
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

    //void CreateEnemy()
    //{
    //    GameObject newCanvas = Instantiate(canvas) as GameObject;
    //    GameObject createImage = Instantiate(enemyCar) as GameObject;
    //    createImage.transform.SetParent(newCanvas.transform, false);
    //}

    void checkIsItemUsed()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (item_canvas.enabled == false)
            {
                item_canvas.enabled = true;
            }
            else
            {
                item_canvas.enabled = false;
            }
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
