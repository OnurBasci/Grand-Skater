using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class çarpma : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool çarptı = false;
    public GameObject mekan;
    public float kuvvet = 200f;
    public float gerigelmehızı = 3f;
    public static bool sağlamçarptı = false;
    private float z_simdiki = 0;

    public void Start()
    {
        sağlamçarptı = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "araba üstü")
        {
            rb.AddForce(new Vector2(-50, kuvvet));
            çarptı = true;
        }
        else if(collision.collider.tag == "yol")
        {
            çarptı = false;
        }
        else if(collision.collider.tag == "araba")
        {
            sağlamçarptı = true;
        }
    }
    private void çarpmak()
    {
        if (sağlamçarptı)
        {
            z_simdiki += 1 * Time.deltaTime;
        }
        if (z_simdiki > 3)
        {
            sağlamçarptı = false;
            z_simdiki = 0;
        }  //ekstra puan artisini surekli calisir hale getirmek icin
        if (!çarptı && transform.position.x < -8.73f && sağlamçarptı == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-7.63f, transform.position.y), gerigelmehızı * Time.fixedDeltaTime);
        }
        if (çarptı)
        {
            mekan.SetActive(true);
        }
        else if(!çarptı)
        {
            mekan.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        çarpmak();
    }
}
