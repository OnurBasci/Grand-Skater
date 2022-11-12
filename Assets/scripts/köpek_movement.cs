using UnityEngine;
using UnityEngine.SceneManagement;

public class köpek_movement : MonoBehaviour
{
    public float varSpeed = 0f;
    public float dogSpeed = 200f;
    Rigidbody2D rb;
    public GameObject köpek;
    public Animator animator;
    private Vector2 clonVector;
    public static bool çarptı = false;
    private float z_baslangic = 0;
    private float z_simdiki;
    private float z_son;
    private bool baslat = false;

    private void Awake()
    {
        clonVector = new Vector2(transform.position.x, transform.position.y);
        z_simdiki = z_baslangic;
        baslat = false;
        çarptı = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //bastonla çarpışma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "sopa")
        {
            çarpma();
            animator.SetBool("bayildi", true);
        }
        else if(collision.collider.tag == "kedi")
        {
            çarpma();
            FindObjectOfType<AudioManager>().Play("attacked");
        }
    }
    private void çarpma()
    {
        varSpeed = 3f;
        çarptı = true;
    }
    private void klonlama()
    {
        if (transform.position.x > 15f || clonVector.x - 5f > transform.position.x)
        {
            baslat = false;
            Instantiate(köpek, clonVector, Quaternion.Euler(0, 0, 0));
            varSpeed = 0;
            çarptı = false;
            Destroy(gameObject);
        }
    }
    private void ilerleme()
    {
        if (!çarptı && baslat) 
        {
            rb.AddForce(Vector2.right * varSpeed * Time.fixedDeltaTime);
        }
        else if(!baslat && SceneManager.GetActiveScene().buildIndex == 0)
        {
            varSpeed = 0;
        }
        if(çarptı)
        {
            rb.velocity = Vector2.left * varSpeed;
        }

        z_son = Random.Range(10, 20);
        if(oyun_başlatma.start)
        {
            z_simdiki += 1 * Time.fixedDeltaTime;
        }
        if (z_simdiki >= z_son && !çarptı)
        {
            if (varSpeed == 0f && SceneManager.GetActiveScene().buildIndex == 0 && baslat)
            {
                FindObjectOfType<AudioManager>().Play("dog_barking");
                varSpeed = dogSpeed;
            }
            baslat = true;
            z_simdiki = z_baslangic;
        }
        if(z_simdiki > 0 && !çarptı)
        {
            if( SceneManager.GetActiveScene().buildIndex == 1)
            {
                baslat = true;
                varSpeed = dogSpeed;
            }
        }
    }
    private void FixedUpdate()
    {
        klonlama();
        ilerleme();
    }
}
