using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarDado3D : MonoBehaviour
{
    public Vector3 Rotacao1;
    public float speed = 4.0f;
    public System.Random rmd = new System.Random();

    public int numeroRandomicos(int min, int max)
    {
        return rmd.Next(min, max);
    }


    public void girar()
    {
        Rotacao1.x = numeroRandomicos(0,360);
        Rotacao1.y = numeroRandomicos(0,360);
        Debug.Log(Rotacao1.x);
        Debug.Log(Rotacao1.y);
        
    }

    public void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Rotacao1), speed * Time.deltaTime);
    }
}
