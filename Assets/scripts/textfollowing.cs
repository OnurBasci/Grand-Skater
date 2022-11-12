using UnityEngine;
using UnityEngine.UI;

public class textfollowing : MonoBehaviour
{
    public Text artis;
    void Update()
    {
        Vector3 spherepos = Camera.main.WorldToScreenPoint(this.transform.position);
        artis.transform.position = spherepos;
    }
}
