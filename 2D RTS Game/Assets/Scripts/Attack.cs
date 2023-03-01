using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject top;
    public Transform attackPosition;
    public float speed;
    private bool attack;

    private float nextActionTime = 0.0f;
    public float attackTimer = 1.5f;
    public float health = 900f;

    private void Start()
    {
        attack = false;
    }
    void Update()
    {
        if (attack == true) //1.5 saniyede bir çalýþmasý true ise çalýþýr
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += attackTimer;
                Instantiate(top, attackPosition.position, attackPosition.rotation); //top mermisi oluþturur
            }
        }
        
        if(attack==false)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += attackTimer;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col) //tetikleme kontrol içerde ise true
    {
        if (col.tag == "Tower")
        {
            Debug.Log("Çarptý");
            top.SetActive(true);
            attack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//tetik kontrol dýþarda ise false
    {
        if (collision.tag == "Tower")
        {
            Debug.Log("çýktý");
            top.SetActive(false);
            attack = false;
        }
    }   

}
