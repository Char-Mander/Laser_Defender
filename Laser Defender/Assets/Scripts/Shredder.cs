using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Muro para que desaparezcan los proyectiles
public class Shredder : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
