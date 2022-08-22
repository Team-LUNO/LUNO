using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StoveWarp : MonoBehaviour
{
    public string transferMapName; // 이 부분에 닿으면 이동시킬 Scene의 이름을 넣는 곳
    private Move move;
    public StartPrologueStoveOff stoveOff;
    // Start is called before the first frame update
    void Start()
    {
        stoveOff = GameObject.Find("n.luno1f_stoveOff").GetComponent<StartPrologueStoveOff>();
        if (move == null)
        {

            if (GameObject.Find("Player_Night"))
                move = GameObject.Find("Player_Night").GetComponent<Move>();

            else if (GameObject.Find("Player"))
                move = GameObject.Find("Player").GetComponent<Move>();
        }
    }


    private void OnTriggerStay2D(Collider2D collision) // 기본적으로 해당 부분에 닿아있는 상태에서 E를 누르면 맵 이동을 하게 설정해놓음
    {
        if (collision.CompareTag("Player"))// 이 부분은 조건이므로 자율적으로 수정하셔서 사용하셔도 됩니다
        {
            if(stoveOff.EventNum == 2)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    move.currentMapName = transferMapName;
                    SceneManager.LoadScene(transferMapName);
                }
            }
        }

    }
}