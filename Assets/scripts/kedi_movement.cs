using UnityEngine;

public class kedi_movement : MonoBehaviour
{
    public float speed = 0f;
    public static bool öldü = false;
    public Rigidbody2D rb;
    private bool oldu2 = false; //bug cozmek icin
    public Animator animator;
    public void FixedUpdate()
    {
        transform.Translate(new Vector2(speed * Time.fixedDeltaTime, 0));
        if (transform.position.x < 6f && !öldü && !oldu2)
        {
            speed = 3f;
        }
        else if(transform.position.x >= 6f && !öldü && !oldu2)
        {
            speed = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            speed = -12f;
        }
    }
    public void kos()
    {
        animator.SetBool("kos", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "düşman")
        {
            animator.SetBool("dead", true);
            öldü = true;
            oldu2 = true;
        }
    }
}
