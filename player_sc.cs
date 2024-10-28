using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_sc : MonoBehaviour
{
    [SerializeField]
    int lives = 3;
    [SerializeField]
    public float speed = 5.0f;
    public GameObject laserprefab;
    public float firerate = 0.5f;
    public float nextfire = 1f;

    spawnManager_sc spawnManager_Sc;

    void Start()
    {
        spawnManager_Sc = GameObject.Find("spawnManager").GetComponent<spawnManager_sc>();

        if (spawnManager_Sc == null)
        {
            Debug.Log("Spwan_Manager oyun nesnesi bulunmadi");

        }
    }
    void Update()
    {
        movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextfire)
        {
            attack();
        }
    }
    public void Demage()
    {
        lives--;
        if (lives < 1)
        {
            if (spawnManager_Sc != null)
                spawnManager_Sc.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }










    void attack()
    {
        Instantiate(laserprefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        nextfire = Time.time + firerate;
    }

    void movement()
    {
        float dikey = Input.GetAxis("Vertical");
        float yatay = Input.GetAxis("Horizontal");
        transform.position += Vector3.up * dikey * speed * Time.deltaTime;
        transform.position += Vector3.right * yatay * speed * Time.deltaTime;

        if (transform.position.y >= 4.104424f)
        {
            transform.position = new Vector3(transform.position.x, 4.104424f, 0);

        }
        else if (transform.position.y <= -1.871267f)
        {
            transform.position = new Vector3(transform.position.x, -1.871267f, 0);
        }

        if (transform.position.x >= 12.6f)
        {
            transform.position = new Vector3(-12.59f, transform.position.y, 0);
        }
        else if (transform.position.x <= -12.6f)
        {
            transform.position = new Vector3(12.59f, transform.position.y, 0);
        }
    }



}
