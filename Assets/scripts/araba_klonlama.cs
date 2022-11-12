using UnityEngine;

public class araba_klonlama : MonoBehaviour
{
    public GameObject araba1;
    public float deletePoint = -15f;
    public float clonPointx = 15f;
    public float rastgelelik = 15f;
    private float clonPointy;
    public GameObject arabatepesi;
    public SpriteRenderer rend;
    public GameObject item;
    public float gelmeme_ihtimal = 90;
    private int i_random; //rastgele bir sayi ile itemin rastgele gelmesini saglar 
    public static Vector2 clonVector;
    private bool geçti = false;

    private void yenileme()
    {
        clonVector = new Vector2(clonPointx, clonPointy);
        clonPointx = Random.Range(rastgelelik, rastgelelik + 15f);
        int pointySelector = Random.Range(0, 3);
        switch (pointySelector)
        {
            case 0: clonPointy = -0.7f;
            break;
            case 1: clonPointy = 0.8f;
            break;
            case 2: clonPointy = 0f;
            break;
            default: break;
        }
        // arabanın y pozisyonuna göre layerını değiştirir
        if (transform.position.y <= -0.6f && transform.position.y >= -0.8f)
        {
            gameObject.layer = 8;
            rend.sortingOrder = 6;
            arabatepesi.layer = 8;
            item.layer = gameObject.layer;
        }
        else if(transform.position.y >= -0.1f && transform.position.y <= 0.1f)
        {
            gameObject.layer = 10;
            rend.sortingOrder = 4;
            arabatepesi.layer = 10;
            item.layer = gameObject.layer;
        }
        else if(transform.position.y >= 0.6f && transform.position.y <= 1f)
        {
            gameObject.layer = 11;
            rend.sortingOrder = 0;
            arabatepesi.layer = 11;
            item.layer = gameObject.layer;
        }
        if (transform.position.x < deletePoint)
        {
            i_random = Random.Range(0, 100);
            geçti = true;
            if (geçti)
            {
                if(i_random > gelmeme_ihtimal) // yuzde onluk bir sans yaratir
                {
                    item.SetActive(true);
                }
                else
                {
                    item.SetActive(false);
                }
                Instantiate(araba1, clonVector, Quaternion.Euler(0f, 0f, 0f));
                Destroy(gameObject);
                geçti = false;
            }
        }
    }
    private void Update()
    {
        yenileme();
    }
}
