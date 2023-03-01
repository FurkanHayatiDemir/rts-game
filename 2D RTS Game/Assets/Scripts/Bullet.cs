using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1f;
    public float tankBullet = 20;
    public float carBullet = 5;

    private void Update()
    {
        transform.position += transform.position * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Tower")
        {
            Debug.Log("Kurþun deðdi");
            GameObject theObject = collision.transform.gameObject;
            theObject.GetComponent<Tower>().health -= carBullet;
            Destroy(gameObject);
        }
       
    }
}
