using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookshelfSelection : SelectionBalloon
{
    public popUpDetail popUpDetail;
    Bookshelf bookshelfManager;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public override void First()
    {
        bookshelfManager = popUpDetail.details[popUpDetail.index].GetComponent<Bookshelf>();
        bookshelfManager.answer.SetActive(true);
        bookshelfManager.PrologueOff();
    }

    public override void Second()
    {
        bookshelfManager = popUpDetail.details[popUpDetail.index].GetComponent<Bookshelf>();
        bookshelfManager.PrologueOff();
    }
}
