using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class RTSController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTransform;

    private Vector3 startPosition;
    private List<UnitRTS> selectedUnitRTSList;
    public Transform lookTransform;


    private void Awake()
    {
        selectedUnitRTSList = new List<UnitRTS>();
        selectionAreaTransform.gameObject.SetActive(false);
  
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Mouse sol t�k
        {
            selectionAreaTransform.gameObject.SetActive(true);

            startPosition = UtilsClass.GetMouseWorldPosition(); //Vekt�r� d�nya konumuna atad�k(codecanyondan yard�mc� element kulland�m)

        }

        if(Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(//sol alt k��e i�in
                Mathf.Min(startPosition.x, currentMousePosition.x), // x i�in ba�lang�� pozisyonu ve mouse pozisyonu
                Mathf.Min(startPosition.y, currentMousePosition.y) // y i�in ba�lang�� pozisyonu ve mouse pozisyonu
                );
            Vector3 upperRight = new Vector3(//sa� �st k��e i�in
                Mathf.Max(startPosition.x, currentMousePosition.x), // x i�in ba�lang�� pozisyonu ve mouse pozisyonu
                Mathf.Max(startPosition.y, currentMousePosition.y) // y i�in ba�lang�� pozisyonu ve mouse pozisyonu
                );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        if (Input.GetMouseButtonUp(0)) //Mouse sol t�kland��� anda
        {
            selectionAreaTransform.gameObject.SetActive(false);

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition()); //plane'de alan� se�iyor

            foreach (UnitRTS unitRTS in selectedUnitRTSList)
            {
                unitRTS.SetSelectedVisable(false); //se�im bo�sa false yap�yoruz(alt�ndaki ye�il se�im alan�)
            }

            selectedUnitRTSList.Clear(); //listeyi temizledik

            foreach (Collider2D collider2D in  collider2DArray)
            {
                UnitRTS unitRTS = collider2D.GetComponent<UnitRTS>(); //unitRTS compenentine eri�ti
                if(unitRTS != null)
                {
                    unitRTS.SetSelectedVisable(true); //unitRTS kodundaki setselectedvisable fonksiyonunu true yap e�er se�ilirse
                    selectedUnitRTSList.Add(unitRTS);
                }
            }

            Debug.Log(selectedUnitRTSList.Count);//ka� tane collier se�ildi ekrana yazd�t�r
        }

        if(Input.GetMouseButton(1))
        {
            Vector3 moveToPosition = UtilsClass.GetMouseWorldPosition(); //mouse sa� t�kland���nda hareket etmesi

            /*Vector3 aimDirection = (moveToPosition).normalized;
            float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg)-90;
            lookTransform.eulerAngles = new Vector3(0, 0, angle);*/

            foreach (UnitRTS unitRTS in selectedUnitRTSList)
            {
                unitRTS.MoveTo(moveToPosition);
            }
        }
    }
}
