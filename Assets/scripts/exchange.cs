using UnityEngine;
using UnityEngine.SceneManagement;

public class exchange : MonoBehaviour
{
    public GameObject sop_animation;
    public GameObject artis;
    public static int g_sopa; //gecen sopa sayisi

    public void animasyon()
    {
        GameObject gecis = GameObject.Find("gecis");
        e_information bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
        g_sopa += 1;
        if (g_sopa <= bilgi.sopaCount) {
            Instantiate(sop_animation, new Vector2(0, 0), Quaternion.identity, gecis.transform);
        }
    }
    public void showMoney()
    {
        FindObjectOfType<AudioManager>().Play("item");
        GameObject gecis = GameObject.Find("gecis");
        Instantiate(artis, new Vector2(0, 0), Quaternion.identity, gecis.transform);
        Destroy(gameObject);
    }
    public void bitir()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            TutorialScript.tutorialIndex = 0;
        }
        else
        {
            e_information bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
            wayPoinText score = GameObject.Find("metre ölçer").GetComponent<wayPoinText>();
            //son sopa gecisinde bolumun bitmesini saglar
            if (g_sopa > bilgi.sopaCount)
            {
                bilgi.parasayisi += bilgi.sopaCount;
                bilgi.sopaCount = 2;
                SaveSystem.SavePlayer(bilgi, score);
                g_sopa = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        //animasyon bittiginde nesneyi yok eder
        Destroy(gameObject);
    }
}
