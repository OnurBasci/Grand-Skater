using UnityEngine;

public class şerit_movement : MonoBehaviour
{
    public float clonpointx;
    public float deletePoint = -15;
    public GameObject şerit;
    private float speed = -4f;
    private bool geçti = false;
    private Vector2 clonVector;

    private void Awake()
    {
        clonVector = new Vector2(clonpointx, transform.position.y);  
    }
    private void move()
    {
        if (oyun_başlatma.start) 
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
    }
    private void klonlama()
    {
        if (transform.position.x < deletePoint)
        {
            geçti = true;
            if (geçti)
            {
                Instantiate(şerit, clonVector, şerit.transform.rotation);
                Destroy(gameObject);
                geçti = false;
            }
        }
    }
    private void Update()
    {
        if (oyun_başlatma.oyunu_başlat == true)
        {
            move();
            klonlama();
        }
    }
}
