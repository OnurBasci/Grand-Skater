using UnityEngine;

public class sopa_movement : MonoBehaviour
{
    public float speed = 5f;
    public float y_süresi;
    public static bool oldu = false;

    private void Start()
    {
        Invoke("ölüm", y_süresi);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "araba" || collision.collider.tag == "limuzin" || collision.collider.tag == "düşman")
        {
            oldu = true;
            FindObjectOfType<AudioManager>().Play("car_crash");
            ölüm();
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }

    private void ölüm()
    {
        Destroy(gameObject);
    }
}
