using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject[] tutorials;
    public GameObject araba1, araba2, araba3, canavar, limuzin, kamyon, köpek, karaPanel, endPanel, oklar, hedef1, hedef2 ,hedef3;
    public static int tutorialIndex;
    public static float timer = 0f;
    private player_movement pMove;
    private köpek_movement dog;
    private araba_movement a_move2;
    private araba_movement a_move1;
    private araba_movement a_move3;
    public GameObject wall;  //bug cozmek icin
    private Vector2 sonHiz;  //canavar kamyonun ivme kaybatmeden tekrardan harekete gecmesini saglar

    private void Start()
    {
        pMove = GameObject.Find("teyze").GetComponent<player_movement>();
        pMove.jumpforce = 0f;
        pMove.open_slide = false;
        
        a_move2 = araba2.GetComponent<araba_movement>();
        a_move1 = araba1.GetComponent<araba_movement>();
        a_move3 = araba3.GetComponent<araba_movement>();
    }

    private void Update()
    {
        for (int i = 0; i < tutorials.Length; i++)
        {
            if (i == tutorialIndex && tutorialIndex != 4)
                tutorials[i].SetActive(true);
           // else if (endPanel.activeInHierarchy && tutorialIndex != 7)
            //{
              //  tutorials[i].SetActive(false);
              //  OnKillWarn.SetActive(true);
           // }
            else if (tutorialIndex == i && tutorialIndex == 4)
            {
                if (timer > 2f)
                    tutorials[i].SetActive(true);
            }
            else
                tutorials[i].SetActive(false);
        }
        if(tutorialIndex == 0)
        {
            if (oyun_başlatma.start)
                tutorialIndex++;
        }
        else if(tutorialIndex == 1)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                timer = 0f;
                tutorialIndex++;
            }
        }
        else if(tutorialIndex == 2)
        {
            a_move2.enabled = true;
            if (uzaklik_hesaplama.inzone)
            {
                pMove.jumpforce = 600f;
                hedef3.SetActive(true);
                ClickOnOption.GameIsPaused = true;
                tutorialIndex++;
            }
        }
        else if(tutorialIndex == 3)
        {
            if (pMove.zipladi && ClickOnOption.GameIsPaused)
            {
                ClickOnOption.GameIsPaused = false;
                hedef3.SetActive(false);
                tutorialIndex++;
            }
        }
        else if(tutorialIndex == 4)
        {
            timer += Time.deltaTime; 
            canavar.SetActive(true);
            if (uzaklik_hesaplama.inzone && timer > 3) 
                {
                oklar.SetActive(true);
                //Vector2 start = new Vector2(20, 0);
                //araba_klonlama klonlama = araba2.GetComponent<araba_klonlama>();
                //araba2.transform.position = start;
                //klonlama.enabled = true;
                //araba2.SetActive(false);
                pMove.open_slide = true;
                ClickOnOption.GameIsPaused = true;
               }
            if (pMove.yol == 1 || pMove.yol == 3)
            {
                ClickOnOption.GameIsPaused = false;
                oklar.SetActive(false);
                timer = 0;
                tutorialIndex++;
            }
        }
        else if(tutorialIndex == 5)
        {
            timer += Time.deltaTime;
            if(timer < 0.1)
            {
                FindObjectOfType<AudioManager>().Play("dog_barking");
            }
            if (timer < 1f)
            {
                köpek.SetActive(true);
                dog = GameObject.Find("köpek").GetComponent<köpek_movement>();
                dog.varSpeed = 40;
            }
            if(timer > 5 && !köpek_movement.çarptı)
            {
                hedef1.SetActive(true);
                Vector2 start = new Vector2(20, 0);
                araba_klonlama klonlama = canavar.GetComponent<araba_klonlama>();
                canavar.transform.position = start;
                klonlama.enabled = true;
                canavar.SetActive(false);
                dog.varSpeed = -50;
            }
            if(timer > 9 && !köpek_movement.çarptı)
            {
                dog.varSpeed = 0f;
            }
            if (sopa_movement.oldu)
            {
                hedef1.SetActive(false);
                timer = 0f;
                tutorialIndex++;
            }
        }
        else if(tutorialIndex == 6)
        {
            sopa_movement.oldu = false;
            timer += Time.deltaTime;
            if (timer < 1) 
            {
                a_move1.enabled = true;
            }
            if (timer > 1)
            {
                a_move1.enabled = false;
                hedef2.SetActive(true);
            }
            //if(timer > 2.3f && !Araba_kaza.çarptı)
           // {
                //Rigidbody2D rb = GameObject.Find("araba 1").GetComponent<Rigidbody2D>();
              //  rb.velocity = Vector2.zero;
            //}
            if(timer > 8)
            {
                a_move1.enabled = true;
                hedef2.SetActive(false);
                timer = 0;
                tutorialIndex++;
            }

        }
        else if(tutorialIndex == 7)
        {
            if (araba3 != null) 
            {
                a_move3.enabled = true;
            }
            if (player_movement.obtained)
            {
                tutorialIndex++;
            }
        }
        else if (tutorialIndex == 8)
        {
            //Vector2 start = new Vector2(20, -0.7f);
            //araba_klonlama klonlama = araba1.GetComponent<araba_klonlama>();
            //araba1.transform.position = start;
            //klonlama.enabled = true;
            wall.SetActive(false);
            if (araba1!= null && kamyon != null && limuzin != null && canavar != null) 
            {
                kamyon.SetActive(true);
                limuzin.SetActive(true);
                canavar.SetActive(true);
            }
            if(endPanel.activeInHierarchy)
            {
                tutorialIndex++;
            }
        }
        else if(tutorialIndex == 9)
        {
            timer += Time.deltaTime;
            wayPoinText.artis = 0f;
            endPanel.SetActive(true);
            kedi_movement.öldü = false;
            if (player_movement.touched || Input.GetButtonDown("Jump") || timer > 10)
            {
                tutorialIndex++;
                timer = 0;
            }
        }
        else if (tutorialIndex == 10)
        {
            timer += Time.deltaTime;
            if (player_movement.touched || Input.GetButtonDown("Jump") || timer > 10)
            {
                tutorialIndex++;
                timer = 0;
            }
        }
    }
}