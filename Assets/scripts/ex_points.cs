using UnityEngine;
using UnityEngine.SceneManagement;
public class ex_points : MonoBehaviour
{
    public GameObject ex_puan;
    public GameObject metin;
    public static float son;
    public static bool sabit = false;
    public Animator artis_an;
    public void arttirma()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            sabit = false;
            wayPoinText.artis += 1f;
            ex_puan.SetActive(true);
            metin.SetActive(true);
        }
    }
    public void sabitle()
    {
        son = wayPoinText.artis;
        sabit = true;
        if (artis_an != null) 
        {
            artis_an.enabled = true;
        }
        ex_puan.SetActive(false);
        wayPoinText.artis = 1f;
    }
}
