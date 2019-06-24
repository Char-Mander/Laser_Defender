using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Configuration parameters
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;



    float xMin, xMax;
    float yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        //Visual sabe de qué tipo va a ser y lo convierte automáticamente
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; 
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        Debug.Log("Posición: (" + deltaX + ", " + deltaY + ")");

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin+padding, xMax-padding);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin+padding, yMax-padding);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject laser = Instantiate(
                laserPrefab, 
                transform.position, 
                Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        //Asignamos los límites en la x
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        //Asignamos los límites en la y
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

}
