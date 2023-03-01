using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public Text TowerText, TowerText1, TowerText2, TowerText3 , TowerText4;
    public float health=500;

    private void Update()
    {
        TowerText.text = health.ToString();
        TowerText1.text = health.ToString();
        TowerText2.text = health.ToString();
        TowerText3.text = health.ToString();
        TowerText4.text = health.ToString();
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
