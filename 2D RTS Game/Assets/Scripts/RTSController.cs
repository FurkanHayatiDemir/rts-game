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
        if (Input.GetMouseButtonDown(0)) //Mouse sol týk
        {
            selectionAreaTransform.gameObject.SetActive(true);

            startPosition = UtilsClass.GetMouseWorldPosition(); //Vektörü dünya konumuna atadýk(codecanyondan yardýmcý element kullandým)

        }

        if(Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(//sol alt köþe için
                Mathf.Min(startPosition.x, currentMousePosition.x), // x için baþlangýç pozisyonu ve mouse pozisyonu
                Mathf.Min(startPosition.y, currentMousePosition.y) // y için baþlangýç pozisyonu ve mouse pozisyonu
                );
            Vector3 upperRight = new Vector3(//sað üst köþe için
                Mathf.Max(startPosition.x, currentMousePosition.x), // x için baþlangýç pozisyonu ve mouse pozisyonu
                Mathf.Max(startPosition.y, currentMousePosition.y) // y için baþlangýç pozisyonu ve mouse pozisyonu
                );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        if (Input.GetMouseButtonUp(0)) //Mouse sol týklandýðý anda
        {
            selectionAreaTransform.gameObject.SetActive(false);

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition()); //plane'de alaný seçiyor

            foreach (UnitRTS unitRTS in selectedUnitRTSList)
            {
                unitRTS.SetSelectedVisable(false); //seçim boþsa false yapýyoruz(altýndaki yeþil seçim alaný)
            }

            selectedUnitRTSList.Clear(); //listeyi temizledik

            foreach (Collider2D collider2D in  collider2DArray)
            {
                UnitRTS unitRTS = collider2D.GetComponent<UnitRTS>(); //unitRTS compenentine eriþti
                if(unitRTS != null)
                {
                    unitRTS.SetSelectedVisable(true); //unitRTS kodundaki setselectedvisable fonksiyonunu true yap eðer seçilirse
                    selectedUnitRTSList.Add(unitRTS);
                }
            }

            Debug.Log(selectedUnitRTSList.Count);//kaç tane collier seçildi ekrana yazdýtýr
        }

        if(Input.GetMouseButton(1))
        {
            Vector3 moveToPosition = UtilsClass.GetMouseWorldPosition(); //mouse sað týklandýðýnda hareket etmesi

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
