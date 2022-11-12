using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    bool yerde = false;
    float çap = 0.51f;
    public Rigidbody2D rb;
    private LayerMask temas;
    public Transform groundcheck;
    public float jumpforce = 400f;
    public Transform player;
    public float inmeçıkma;
    public Text inventory;
    public int yol = 2;
    private SpriteRenderer rend;
    private float bzaman = 0.04f;  // basılma zamanı
    private float czaman = 0.04f;  //ilerleyen süre
    public static float a_hizalama = 0.1f; // uzaklik hesaplama scipti icin
   // private bool basıldı = false;
    private int item = 5;
    public Animator jump_an;
    private Vector2 startpos;
    public static Vector2 direction;
    public static bool touched = false;
    public bool zipladi = false;
    public bool open_slide = true;
    public static bool obtained = false;  //tutorial bolumu icin

    private void Awake()
    {
        temas = LayerMask.GetMask("yol 2");
        rend = gameObject.GetComponent<SpriteRenderer>();
        bzaman = czaman;
        obtained = false;
    }
    public void touchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    startpos = touch.position;
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    direction = touch.position - startpos;
                    if (Mathf.Abs(direction.y) < 50)
                    {
                        touched = true;
                    }
                    break;
            }
        }
    }
    public void zıplama()
    {
        yerde = Physics2D.OverlapCircle(groundcheck.position, çap, temas);
        bool corrector = false;
        if (Input.GetButtonDown("Jump") && yerde || yerde && touched && Input.mousePosition.x < 600)  //belki degisebili!!!!
        {
            touched = false;
            corrector = true;
            zipladi = true;
            rb.AddForce(new Vector2(0, jumpforce));
            a_hizalama = 1.5f;
        }
        if(!yerde)
        {
            touched = false;
            jump_an.SetBool("jump", true);
            zipladi = true;
            corrector = false;
        }
        else if(!corrector)
        {
            touched = false;
            zipladi = false;
        }
        if (yerde)
        {
            jump_an.SetBool("jump", false);
            if(yol == 2)
            {
                a_hizalama = 0;
            }
        }
    }
    //karakterin yukarı çıkmasını sağlar
    public void yer()
    {
        //gerekirse kullan
        // bir tuşa basıldığı zaman çok kısa süreli bir true boolu yaratır bu sayede karakter yukarı aşağı inerken çifter yer değiştirmez
        /*  if(Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("z"))
          {
              basıldı = true;
          }
          if(basıldı)
          {
              czaman -= Time.fixedDeltaTime;
          }
          if(czaman < 0)
          {
              basıldı = false;
              czaman = bzaman;
          }
          */
        if (open_slide)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w") || Input.GetKeyDown("z") || direction.y > 50)
            {

                if (yol == 1)
                {
                    direction = new Vector2(0, 0);
                    a_hizalama = 0;
                    player.position = new Vector3(player.position.x, player.position.y + inmeçıkma);
                    gameObject.layer = 13;
                    yol = 2;
                    temas = LayerMask.GetMask("yol 2");
                    rend.sortingOrder = 4;
                }
                else if (yol == 2)
                {
                    direction = new Vector2(0, 0);
                    a_hizalama = 0.8f;
                    player.position = new Vector3(player.position.x, player.position.y + inmeçıkma);
                    gameObject.layer = 14;
                    yol = 3;
                    temas = LayerMask.GetMask("yol 3");
                    rend.sortingOrder = 0;
                    direction = new Vector2(0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s") || direction.y < -50)
            {
                if (yol == 3)
                {
                    direction = new Vector2(0, 0);
                    a_hizalama = 0;
                    player.position = new Vector3(player.position.x, player.position.y - inmeçıkma);
                    gameObject.layer = 13;
                    yol = 2;
                    temas = LayerMask.GetMask("yol 2");
                    rend.sortingOrder = 4;
                    direction = new Vector2(0, 0);
                }
                else if (yol == 2)
                {
                    direction = new Vector2(0, 0);
                    a_hizalama = -0.7f;
                    player.position = new Vector3(player.position.x, player.position.y - inmeçıkma);
                    gameObject.layer = 12;
                    yol = 1;
                    temas = LayerMask.GetMask("yol 1");
                    rend.sortingOrder = 6;
                    direction = new Vector2(0, 0);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "item")
        {
            obtained = true;
            FindObjectOfType<AudioManager>().Play("item");
            e_information bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
            bilgi.sopaCount += item;
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "araba" && SceneManager.GetActiveScene().buildIndex == 1 && TutorialScript.tutorialIndex < 8)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void Update()
    {
        if (!ClickOnOption.GameIsPaused || SceneManager.GetActiveScene().buildIndex ==1) 
        {
            zıplama();
            yer();
        }
        touchControls();
    }
}
