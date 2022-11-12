using UnityEngine;

public class Araba_kaza : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject arabaüstü;
    public float jumpForce = 200f;
    public GameObject limuzin;
    private bool çarptı = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //sopa isabet ettiginde araba firlar
        if(collision.collider.tag == "sopa")
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddForce(new Vector2(0f, jumpForce));
            çarptı = true;
        }
        //arabalarin carpismasini engellemek icin carpisma aninda arabyi arkaya atar
        else if(collision.collider.tag == "limuzin")
        {
            if (gameObject.layer == limuzin.layer)
            {
                transform.position = new Vector2(limuzin.transform.position.x + 8 ,transform.position.y);
            }
        }
    }
    public void kaza()
    {
        if(çarptı)
        {
            gameObject.layer = 16;
            arabaüstü.layer = 16;
        }
    }
    private void FixedUpdate()
    {
        kaza();
        if (transform.position.x > 14f)
        {
            //karakter sopayla temas halinden sonraki constraints durumunu kapatır
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
