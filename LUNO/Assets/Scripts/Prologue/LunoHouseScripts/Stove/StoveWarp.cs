using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StoveWarp : MonoBehaviour
{
    public string transferMapName; // �� �κп� ������ �̵���ų Scene�� �̸��� �ִ°�
    public string arriveStartPoint; // �� �κп� ������ �̵���ų Scene�� Ư�� StartPoint�� ����
    private Move move;
    public StartPrologueStoveOff stoveOff;
    // Start is called before the first frame update
    void Start()
    {
        if (move == null)
        {

            if (GameObject.Find("Player_Night"))
                move = GameObject.Find("Player_Night").GetComponent<Move>();

            else if (GameObject.Find("Player"))
                move = GameObject.Find("Player").GetComponent<Move>();
        }
    }


    private void OnTriggerStay2D(Collider2D collision) // �⺻������ �ش� �κп� ����ִ� ���¿��� E�� ������ �� �̵��� �ϰ� �����س���
    {
        if (collision.CompareTag("Player"))// �� �κ��� �����̹Ƿ� ���������� �����ϼż� ����ϼŵ� �˴ϴ�
        {
            if(stoveOff.EventNum == 4)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    move.currentMapName = transferMapName;
                    move.arriveStartPoint = arriveStartPoint;
                    SceneManager.LoadScene(transferMapName);
                }
            }
        }

    }
}