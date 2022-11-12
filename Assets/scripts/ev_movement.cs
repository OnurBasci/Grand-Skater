using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ev_movement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if (transform.position.x > -30 && oyun_başlatma.oyunu_başlat && oyun_başlatma.start)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
    }
}
