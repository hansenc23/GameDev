using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    private GameObject nextTetromino;
    private GameObject previewTetromino;
    private Vector2 previewPosition = new Vector2(18.0f, 12.0f);
 
    private bool gameStarted;
   
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //if game has not started
        if (!gameStarted)
        {
            
            gameStarted = true; //set bool to true, so when Spawn() is called again it will go to the else statement
            nextTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], new Vector2(4.0f, 19.0f), Quaternion.identity); //instantiate the tetromino that is going to fall
            previewTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], previewPosition, Quaternion.identity); //instantate the preview for the next tetromino
            previewTetromino.GetComponent<Tetromino>().enabled = false; //disable script
          

        }
        else
        {
            previewTetromino.transform.localPosition = new Vector2(4.0f, 19.0f); 
            nextTetromino = previewTetromino; //set the preview to the tetromino that will fall
            nextTetromino.GetComponent<Tetromino>().enabled = true; //enable script

            previewTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], previewPosition, Quaternion.identity); //instantiate preview tetromino
            previewTetromino.GetComponent<Tetromino>().enabled = false;
       
        }
       
    }
}
