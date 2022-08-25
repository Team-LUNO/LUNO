using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_03_selection : SelectionBalloon
{
    [SerializeField]
    public PrologueManager[] prologueManagers;

    public GameObject[] carts;
    private int cnt = 0;
    private bool isEnabled = true;
    private bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCart(3);
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


    public override void First()
    {
        if (isEnabled)
        {
            ChangeCart(cnt);
            cnt++;      
        }
        prologueManagers[0].IncreaseOrder();
        if (prologueManagers[cnt].GetDone())
        {
            prologueManagers[cnt].ResetOrder();
        }
        prologueManagers[cnt].StartPrologue();
    }

    public override void Second()
    {
        Debug.Log("¾Æ´Ï");
        prologueManagers[0].IncreaseOrder();
        isDone=true;
    }

}
