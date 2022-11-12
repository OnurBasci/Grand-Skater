using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaydir : MonoBehaviour
{
    public Animator shop_an;
    public static bool solda = false;
    private int page = 1;
    public void sola_kaydir()
    {
        if (!solda) 
        {
            shop_an.SetBool("sa_kaydi", false);
            shop_an.SetBool("s_kay", true);
            page++;
        }
    }
    public void sol_durdur()
    {
        shop_an.SetBool("s_kay", false);
        shop_an.SetBool("s_kaydi", true);
        solda = true;
    }
    public void saga_kaydir()
    {
        if (solda) 
        {
            shop_an.SetBool("s_kaydi", false);
            shop_an.SetBool("sa_kay", true);
        }
    }
    public void sag_durdur()
    {
        shop_an.SetBool("sa_kay", false);
        shop_an.SetBool("sa_kaydi", true);
        if(open_shop.clicked)
        {
            FindObjectOfType<open_shop>().kapat();
            open_shop.clicked = false;
        }
        solda = false;
    }
}
