using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wayPoinText : MonoBehaviour
{
    public float meter = 0f;
    public static float artis = 1f;
    public Text WayPoint;
    public Text Score;
    public Text ex_score;
    public GameObject metin;
    public Text highScore;
    //ekstre skorun fontunu buyutme icin gerekli veriler
    private float b_hizi = 0.2f;
    private float fontsize = 10;
    public float highscore;

    public void IncreaseMeter()
    {
        if (oyun_başlatma.oyunu_başlat && oyun_başlatma.start)
        {
            meter = meter + artis;
        }
    }
    void Start()
    {
        artis = 1f;
        InvokeRepeating("IncreaseMeter", 0f, 0.3f);
        StartCoroutine("FontBüyütme");
        PlayerData data = SaveSystem.LoadPlayer();
        highscore = data.highscore;
    }
            IEnumerator FontBüyütme()
    {
        for (float sayma = 0; sayma < 60; sayma++)
        {
            yield return new WaitForSeconds(0.0001f);
            fontsize += b_hizi;
            ex_score.fontSize = (int)fontsize;
        }
    }

    public void hg_hesaplama()
    {
        if (meter > highscore)
        {
            highscore = meter;
        }
    }
    void Update()
    {
        hg_hesaplama();
        WayPoint.text = "Score: " + meter;
        Score.text = "Score: " + meter;
        highScore.text = "HighScore: " + highscore;
        if (!ex_points.sabit)
        {
            ex_score.text = "+ " + artis;
            ex_score.color = new Color(1,1,1,1);
        }
        else
        {
            ex_score.text = "+ " + ex_points.son;
            metin.transform.Translate(new Vector2(0, 1));
        }
    }
}
