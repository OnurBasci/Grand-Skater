using UnityEngine;

public class uzaklik_hesaplama : MonoBehaviour
{
    private GameObject teyze;
    private ex_points co_point;
    private Vector3 teyzepos;
    public float mesafe = 1;
    public static Vector3 uzaklik;
    public static bool inzone = false;

    //arabayla teyze arasindaki uzakligi hesaplar
    private void hesapla()
    {
        teyze = GameObject.Find("teyze");
        teyzepos = teyze.GetComponent<Transform>().position;
        uzaklik = transform.position - teyzepos;
    }
    void Update()
    {
        hesapla();
        co_point = gameObject.GetComponent<ex_points>();
        if (oyun_başlatma.start && !ClickOnOption.GameIsPaused) {
            if (uzaklik.x < mesafe && 0 < uzaklik.x && Mathf.Abs(transform.position.y - player_movement.a_hizalama) < 0.2f && !çarpma.sağlamçarptı)
            {
                co_point.enabled = true;
                co_point.arttirma();
                inzone = true;
            }
            if (co_point.enabled == true)
            {
                if (Mathf.Abs(transform.position.y - player_movement.a_hizalama) >= 0.2f || uzaklik.x > mesafe || 0 > uzaklik.x && Mathf.Abs(transform.position.y - player_movement.a_hizalama) >= 0.2f || çarpma.sağlamçarptı)
                {
                    co_point.sabitle();
                    co_point.enabled = false;
                    inzone = false;
                }
            }
        }
    }
}
