using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerSection : MonoBehaviour
{
    BoxCollider2D collid;

    void Start()
    {
        collid = GetComponent<BoxCollider2D>();
        SettingTriggerSection();
    }

    public void SettingTriggerSection()
    {
        collid.size = new Vector2(2f, 1f);
    }
}
