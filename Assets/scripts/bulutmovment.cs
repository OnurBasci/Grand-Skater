using UnityEngine;

public class bulutmovment : MonoBehaviour
{
    public float speed;
    private float xpos;
    private float ypos;
    private float scale;
    private bool gecti = false;
    
    public void move()
    {
        transform.Translate(new Vector2(speed *1/100, 0));
        if(transform.position.x < -15)
        {
            gecti = true;
        }
    }
    public void uret()
    {
        if(gecti)
        {
            Instantiate(gameObject, new Vector2(xpos, ypos), transform.rotation);
            Destroy(gameObject);
            gecti = false;
        }
    }
   //   public void Update()
   // {
   //   DontDestroyOnLoad(gameObject);
   // }
    public void FixedUpdate()
    {
        xpos = Random.Range(20, 30);
        ypos = Random.Range(4, 7);
        scale = Random.Range(1, 2);
        move();
        uret();
    }
}
