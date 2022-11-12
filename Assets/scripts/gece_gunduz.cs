using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gece_gunduz : MonoBehaviour
{
    public Camera Cam;
    public Animator cam_an;
    private bool sabah = true;
    private float z_simdi;
    public float z_son = 20;

    private void Awake()
    {
        z_simdi = 0;
    }
    public void Gece_gunduz()
    {
        if(oyun_başlatma.start)
        {
            z_simdi += Time.fixedDeltaTime;
        }
        if (z_simdi > z_son)
        {
            if (sabah)
            {
                cam_an.SetBool("gece_gec", true);
            }
            else
            {
                cam_an.SetBool("gece_gec", false);
            }
            z_simdi = 0;
        }
    }
    public void Gece()
    {
        cam_an.SetBool("gunduz", false);
        sabah = false;
    }
    public void Gunduz()
    {
        cam_an.SetBool("gunduz", true);
        sabah = true;
    }
    void FixedUpdate()
    {
        Gece_gunduz();
    }
}
