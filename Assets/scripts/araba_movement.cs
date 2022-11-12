using UnityEngine;

public class araba_movement : MonoBehaviour
{
    public float speed = 200f;
    Rigidbody2D rb;
    public float k_zamanı = 0f;
    public Collider2D görünmezlik;
    public Collider2D görünmezliküst;
    private float ctime;
    public float acceleration = 10f;
    private wayPoinText way;
    private bool zkısıtlama = true;

    private void Awake()
    {
        ctime = k_zamanı;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        way = GameObject.Find("metre ölçer").GetComponent<wayPoinText>();
    }

    private void ilerleme()
    {
            if (ctime > 0)
            {
                ctime -= 1 * Time.fixedDeltaTime;
                görünmezlik.enabled = false;
                görünmezliküst.enabled = false;
            }
            else if (ctime <= 0)
            {
                görünmezlik.enabled = true;
                görünmezliküst.enabled = true;
                rb.AddForce(Vector2.left * speed * Time.fixedDeltaTime);
            }
            if (way.meter % 100 == 0 && way.meter != 0 && zkısıtlama)
            {
                speed += acceleration;
                zkısıtlama = false;
            }
    }
    private void FixedUpdate()
    {
        ilerleme();
    }
}
