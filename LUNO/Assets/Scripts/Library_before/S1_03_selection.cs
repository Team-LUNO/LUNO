using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S1_03_selection : SelectionBalloon
{
    [SerializeField]
    public PrologueManager[] prologueManagers;

    public GameObject[] carts;
    public int cnt = 0;
    private bool isEnabled = true;
    private bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCart(3);
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "좋아.";
        gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "나중에.";
    }

    private void ChangeCart(int i)
    {
        foreach (GameObject _cart in carts)
        {
            _cart.SetActive(false);
        }
        carts[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == 3)
        {
            isEnabled = false;
        }
    }

    public bool GetDone()
    {
        return isDone;
    }

    public int getCnt()
    {
        return cnt;
    }


    //좋아
    public override void First()
    {
        if (isEnabled)
        {
            ChangeCart(cnt);
            cnt++;      
        }
        prologueManagers[0].IncreaseOrder();
        Debug.Log("현재: "+cnt+prologueManagers[cnt].GetDone());
        if (prologueManagers[cnt].GetDone())
        {
            prologueManagers[cnt].ResetOrder();
        }
        prologueManagers[cnt].StartPrologue();
    }

    //나중에
    public override void Second()
    {
        Debug.Log("아니");
        prologueManagers[0].IncreaseOrder();
        isDone=true;
    }

}
