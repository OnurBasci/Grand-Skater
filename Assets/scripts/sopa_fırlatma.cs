using UnityEngine;
using UnityEngine.UI;

public class sopa_fırlatma : MonoBehaviour
{
    private LineRenderer _lineRendrer;
    private Vector2 iPosition;
    private Vector2 cPosition;
    private Color color = Color.gray;
    public GameObject sopa;
    public static bool basıldı = false;
    public Text inventory;
    private int t_count = 0;  //kac kez ard arda basildigini gosteren sayi
    private float s_time = 0.25f;
    private Vector2? GetCurrentMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector3.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);

        }

        return null;
    }

    public void Start()
    {
        _lineRendrer = gameObject.AddComponent<LineRenderer>();
        _lineRendrer.startWidth = 0.2f;
        _lineRendrer.endWidth = 0.2f;
        _lineRendrer.material = new Material(Shader.Find("Sprites/Default"));
        color.a = 0.42f;
        _lineRendrer.material.color = color;
        _lineRendrer.enabled = false;
    }

    public void Touch_Count()
    {
        if (oyun_başlatma.start) {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);      // telefona aktarirken bu kismi ac
                if (touch.phase == TouchPhase.Ended && player_movement.direction.y < 20 && Input.mousePosition.x > 400)
                {
                    t_count++;
                }
            }
            if (t_count == 1)
            {
                s_time -= Time.fixedDeltaTime;
                if (s_time < 0)
                {
                    s_time = 0.3f;
                    t_count = 0;
                }
            }
        }
    }
    //sopa fırlatır
    public void sopafırlatma()
    {
        e_information bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotZ + 0f);
        if (t_count >= 2)    //Input.GetMouseButtonUp(0) && basıldı == true ||  bilgisayarda oynarken ac
        {
            Instantiate(sopa, transform.position, transform.rotation);
            bilgi.sopaCount--;
            basıldı = false;
            t_count = 0;
        }
    }
    private void sopaInventory()
    {
        e_information bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
        inventory.text = bilgi.sopaCount.ToString();
    }

    public void Update()
    {
        e_information bilgi = GameObject.Find("gameManager").GetComponent<e_information>();
        //yöü gösteren çizgi çizer
        /*if (Input.GetMouseButtonDown(0) && Vector2.Distance(transform.position, GetCurrentMousePosition().GetValueOrDefault()) < 1)
        {
            basıldı = true;
            iPosition = GetCurrentMousePosition().GetValueOrDefault();
            _lineRendrer.SetPosition(0, iPosition);
            _lineRendrer.positionCount = 1;
            _lineRendrer.enabled = true;
        }
        else if (Input.GetMouseButton(0))
        {
            cPosition = GetCurrentMousePosition().GetValueOrDefault();
            _lineRendrer.positionCount = 2;
            _lineRendrer.SetPosition(1, cPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _lineRendrer.enabled = false;
            Vector2 releasePosition = GetCurrentMousePosition().GetValueOrDefault();
            Vector2 direction = releasePosition - iPosition;
        }*/
        if (bilgi.sopaCount > 0 && !ClickOnOption.GameIsPaused)
        {
            sopafırlatma();
        }
        sopaInventory();
        Touch_Count();
    }
}
