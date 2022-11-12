using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dance : MonoBehaviour
{
    //dansi bitirmeye yarayan script
    public Animator teyze_an;
    public GameObject store;
    public GameObject s_button;
    public static bool dancing = false;
    public void stop_dance()
    {
        teyze_an.SetBool("dance", false);
        dancing = false;
        store.SetActive(false);
        s_button.SetActive(true);
    }
}
