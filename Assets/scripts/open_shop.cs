using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_shop : MonoBehaviour
{
    public GameObject store;
    public GameObject s_button;
    public Animator shop_an;
    public static bool clicked = false;

     public void open()
    {
        e_information bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
        store.SetActive(true);
        s_button.SetActive(false);
        PlayerData data = SaveSystem.LoadPlayer();
        bilgi.costumes[0] = data.Costumes[0];
        bilgi.costumes[1] = data.Costumes[1];
        bilgi.costumes[2] = data.Costumes[2];
        bilgi.costumes[3] = data.Costumes[3];
        bilgi.costumes[4] = data.Costumes[4];
        bilgi.costumes[5] = data.Costumes[5];
        bilgi.costumes[6] = data.Costumes[6];
        bilgi.costumes[7] = data.Costumes[7];
        bilgi.costumes[8] = data.Costumes[8];
        bilgi.costumes[9] = data.Costumes[9];
        bilgi.costumes[10] = data.Costumes[10];

        //para sayisini item alindiysa yok et
        GameObject info0 = GameObject.Find("info1");
        GameObject info1 = GameObject.Find("info2");
        GameObject info2 = GameObject.Find("info3");
        GameObject info3 = GameObject.Find("info4");
        GameObject info4 = GameObject.Find("info5");
        GameObject info5 = GameObject.Find("info6");
        GameObject info6 = GameObject.Find("info7");
        GameObject info7 = GameObject.Find("info8");
        GameObject info8 = GameObject.Find("info9");
        GameObject info9 = GameObject.Find("info10");
        GameObject info10 = GameObject.Find("info11");
        if (bilgi.costumes[0] && info0 != null)
        {
            info0.SetActive(false);
        }
        if (bilgi.costumes[1] && info1 != null)
        {
            info1.SetActive(false);
        }
        if (bilgi.costumes[2] && info2 != null)
        {
            info2.SetActive(false);
        }
        if (bilgi.costumes[3] && info3 != null)
        {
            info3.SetActive(false);
        }
        if (bilgi.costumes[4] && info4 != null)
        {
            info4.SetActive(false);
        }
        if (bilgi.costumes[5] && info5 != null)
        {
            info5.SetActive(false);
        }
        if (bilgi.costumes[6] && info6 != null)
        {
            info6.SetActive(false);
        }
        if (bilgi.costumes[7] && info7 != null)
        {
            info7.SetActive(false);
        }
        if (bilgi.costumes[8] && info8 != null)
        {
            info8.SetActive(false);
        }
        if (bilgi.costumes[9] && info9 != null)
        {
            info9.SetActive(false);
        }
        if (bilgi.costumes[10] && info10 != null)
        {
            info10.SetActive(false);
        }
        shop_an.SetBool("sa_kay", false);
    }
    public void close()
    {
        if (kaydir.solda)
        {
            shop_an.SetBool("s_kaydi", false);
            shop_an.SetBool("sa_kay", true);
            clicked = true;
        }
        else 
        {
            kapat();
            shop_an.SetBool("sa_kay", false);
        }
    }
    public void kapat()
    {
        if (!dance.dancing) 
        {
            store.SetActive(false);
            s_button.SetActive(true);
        }
    }
}
