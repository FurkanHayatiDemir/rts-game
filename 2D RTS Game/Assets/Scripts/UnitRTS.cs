using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour
{
    private GameObject selectedGameObject;
    private IMovePosition movePosition;

    private void Awake()
    {
        selectedGameObject = transform.Find("Selected").gameObject; //ad� selecten olan objeyi se�er

        movePosition = GetComponent<IMovePosition>();
        SetSelectedVisable(false); //g�r�n�rl�k false yap�ld�
    }

    public void SetSelectedVisable(bool visable) //bool olarak visable de�eri olu�turuyoruz
    {
        selectedGameObject.SetActive(visable); //obje se�ilirse g�r�n�r yapar visable true
    }

    public void MoveTo(Vector3 targetPosition) //hareket
    {
        movePosition.SetMovePosition(targetPosition);
    }
}
