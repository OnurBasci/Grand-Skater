using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer_düzenleme : MonoBehaviour
{
    public Renderer parent;
    public Renderer child;
    public int yer = 1;

    void Update()
    {
        child.sortingOrder = parent.sortingOrder + yer;
    }
}
