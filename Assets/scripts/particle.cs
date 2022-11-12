using UnityEngine;

public class particle : MonoBehaviour
{
    public GameObject duman;
    public Transform yer;
     public void open()
    {
        Instantiate(duman, yer.position, yer.rotation);
    }
}
