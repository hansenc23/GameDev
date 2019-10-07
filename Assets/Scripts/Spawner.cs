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
        if (!gameStarted)
        {
            gameStarted = true;
            nextTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], new Vector2(4.0f, 19.0f), Quaternion.identity);
            previewTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], previewPosition, Quaternion.identity);
            previewTetromino.GetComponent<Tetromino>().enabled = false;
          

        }
        else
        {
            previewTetromino.transform.localPosition = new Vector2(4.0f, 19.0f);
            nextTetromino = previewTetromino;
            nextTetromino.GetComponent<Tetromino>().enabled = true;

            previewTetromino = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], previewPosition, Quaternion.identity);
            previewTetromino.GetComponent<Tetromino>().enabled = false;
       
        }
       
    }
}
