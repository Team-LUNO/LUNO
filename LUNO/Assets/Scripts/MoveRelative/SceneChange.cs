using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public string transferMapName;
    private Move move;
    // Start is called before the first frame update
    void Start()
    {
        if (move == null) {

            if(GameObject.Find("Player_Night"))
            move = GameObject.Find("Player_Night").GetComponent<Move>();

            else if(GameObject.Find("Player"))
            move = GameObject.Find("Player").GetComponent<Move>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            move.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
        }
    }
}