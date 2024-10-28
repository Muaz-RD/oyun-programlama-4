using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;


    void Update()
    {
        
        hareket();
    }


    void hareket(){
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -5.2)
        {
            float randomx = Random.Range(-10f, 10f);
            transform.position = new Vector3(randomx, 5.2f, 0);
        }
    }


    void OnTriggerEnter(Collider other)
    {

        player_sc oyuncu = other.transform.GetComponent<player_sc>();

        if (other.tag == "Player")
        {
            oyuncu.Demage();
            transform.position = new Vector3(Random.Range(-10f,10f), 5.2f, 0);
        }
        else if (other.tag == "laser")
        {
            Destroy(other.gameObject);
            transform.position = new Vector3(Random.Range(-10f,10f), 5.2f, 0);
        }
    }

}
