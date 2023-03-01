using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MovePositionDirect : MonoBehaviour, IMovePosition
{

    private Vector3 movePosition;

    private void Awake()
    {
        movePosition = transform.position; //move pozisyonu pozisyona eþitledik
    }
    public void SetMovePosition(Vector3 movePosition) //vektörü oluþturuldu
    {
        this.movePosition = movePosition;
    }

    private void Update()
    {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        if (Vector3.Distance(movePosition, transform.position) < 1f) moveDir = Vector3.zero;
        GetComponent<IMoveVelocity>().SetVelocity(moveDir);

        if (Input.GetMouseButton(1))
        {
            
            Vector3 moveToPosition = UtilsClass.GetMouseWorldPosition(); //mouse sað týklandýðýnda hareket etmesi


            Vector3 aimDirection = (moveToPosition).normalized;
            float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90;
            this.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, angle);
        }
    }

}
