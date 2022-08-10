using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDogTriggerSection : MonoBehaviour
{
    GameObject upCollid;
    GameObject leftCollid;
    GameObject wallCollid;
    Vector2 objLoc;
    Vector2 objSize;

    //각각의 콜라이더를 불러오고
    //콜라이더를 주위에 설치해야되는 오브젝트(토끼)의 위치와 사이즈를 가져옵니다 
    void Start()
    {
        upCollid = gameObject.transform.GetChild(2).gameObject;
        leftCollid = gameObject.transform.GetChild(3).gameObject;
        wallCollid = gameObject.transform.GetChild(4).gameObject;
        objLoc = GetComponent<Transform>().position;
        objSize = GetComponent<Transform>().localScale;
        SettingTriggerSection();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //오브젝트를 중심으로 각 콜라이더들의 사이즈와 위치를 설정해줍니다
    public void SettingTriggerSection()
    {
        Vector2 UppperSize = new Vector2(objSize.x * 3, objSize.y * 0.1f);
        Vector2 LeftSize = new Vector2(objSize.x * 0.1f, objSize.y);
        Vector2 WallSize = new Vector2(objSize.x * 0.1f, objSize.y);
        Vector2 LeftPosition = new Vector2(-2, 0);
        Vector2 UpperPosition = new Vector2(0, 1);
        Vector2 WallPosition = new Vector2(2, 0);
        upCollid.GetComponent<Transform>().localScale = UppperSize;
        upCollid.transform.localPosition = UpperPosition;
        leftCollid.GetComponent<Transform>().localScale = LeftSize;
        leftCollid.transform.localPosition = LeftPosition;
        wallCollid.GetComponent<Transform>().localScale = WallSize;
        wallCollid.transform.localPosition = WallPosition;
    }
}
