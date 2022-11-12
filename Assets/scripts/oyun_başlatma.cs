using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class oyun_başlatma : MonoBehaviour
{
    public GameObject teyze;
    public GameObject sopa;
    public GameObject kedi;
    public Transform target;
    public float speed = 5f;
    public GameObject gecisekrani;
    public GameObject ParaUI;
    public GameObject baslangicyazisi;
    private player_movement pm;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private kedi_movement km;
    private Animator ani;
    private int geçişsayısı;
    public static bool oyunu_başlat = false;
    private Transform tm;
    public static bool start = false;
    public Animator s_an;     // to start the run animation
    public Animator kedi_an;
    public GameObject s_button , o_panel, s_panel, p_button, o_button, title;
    public Sprite costume;
    //telefonda ui algilamasi icin yazilan bool
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void Awake()
    {
        start = false;
        geçişsayısı = 0;
        pm = teyze.GetComponent<player_movement>();
        rb = teyze.GetComponent<Rigidbody2D>();
        bc = teyze.GetComponent<BoxCollider2D>();
        tm = teyze.GetComponent<Transform>();
        pm.enabled = false;
        bc.enabled = false;
        km = kedi.GetComponent<kedi_movement>();
        ani = kedi.GetComponent<Animator>();
        km.enabled = false;
        ani.enabled = false;
    }

    private void Update()
    {
        //basilan tus ui tipinde bir gameobject uzerinde degilse oyun baslar
        if (!IsPointerOverUIObject() && SceneManager.GetActiveScene().buildIndex == 0 || ClickOnOption.again || SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown("space") && !start || ClickOnOption.again) 
            {
                start = true;
                km.enabled = true;
                ani.enabled = true;
                kedi_an.SetBool("kalk", true);
                if (s_button != null && s_panel != null && o_panel != null && o_button != null && title != null) 
                {
                    s_button.SetActive(false);
                    s_panel.SetActive(false);
                    o_panel.SetActive(false);
                    o_button.SetActive(false);
                    title.SetActive(false);
                }
                p_button.SetActive(true);
                FindObjectOfType<AudioManager>().Play("meow");
            }
            if(Input.touchCount > 0)     //ayni ife koyunca hata verdigi icin ayiriyorum
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && !start)
                {
                    start = true;
                    km.enabled = true;
                    ani.enabled = true;
                    kedi_an.SetBool("kalk", true);
                    s_button.SetActive(false);
                    s_panel.SetActive(false);
                    o_panel.SetActive(false);
                    o_button.SetActive(false);
                    title.SetActive(false);
                    p_button.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("meow");
                }
            }
        }
        if (tm.position.x  < -20f || tm.position.y < -5f)
        {
            endgame();
        }
        if(kedi_movement.öldü)
        {
            Invoke("endgame", 1f);
        }
        if(Vector3.Distance(teyze.transform.position, target.position) < 0.05)
        {
            geçişsayısı = 1;
            oyunu_başlat = true;
        }
        if (geçişsayısı < 1 && start)
        {
            if (player_movement.a_hizalama != 1.5) 
            {
                s_an.SetBool("start", true);
            }
            ParaUI.SetActive(false);
            baslangicyazisi.SetActive(false);
        teyze.transform.position = Vector2.MoveTowards(teyze.transform.position, target.position, speed * Time.deltaTime);
        }
        else if(geçişsayısı == 1)
        {
            rb.gravityScale = 2f;
            pm.enabled = true;
            bc.enabled = true;
        }
    }
    public void endgame()
    {
        ClickOnOption.again = false;
        wayPoinText.artis = 0f;
        gecisekrani.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        kedi_movement.öldü = false;
    }
}
