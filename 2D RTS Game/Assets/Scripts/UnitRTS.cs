using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour
{
    private GameObject selectedGameObject;
    private IMovePosition movePosition;

    private void Awake()
    {
        selectedGameObject = transform.Find("Selected").gameObject; //adý selecten olan objeyi seçer

        movePosition = GetComponent<IMovePosition>();
        SetSelectedVisable(false); //görünürlük false yapýldý
    }

    public void SetSelectedVisable(bool visable) //bool olarak visable deðeri oluþturuyoruz
    {
        selectedGameObject.SetActive(visable); //obje seçilirse görünür yapar visable true
    }

    public void MoveTo(Vector3 targetPosition) //hareket
    {
        movePosition.SetMovePosition(targetPosition);
    }
}
