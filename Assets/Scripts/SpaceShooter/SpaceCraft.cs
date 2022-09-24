using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCraft : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laser;

    public int speed;

    Vector2 mousePositon;
    Vector2 lookDirection;

    float lookAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePositon = Input.mousePosition;
        lookDirection = Camera.main.WorldToScreenPoint(mousePositon);

        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        //cameraMousePosition.z = 0;
        //cameraMousePosition = cameraMousePosition - mousePositon;

        //transform.position = lookDirection;

            if(Input.GetMouseButtonDown(0))
        {
            GameObject laserClone = Instantiate(laser);

            laserClone.transform.position = firePoint.transform.position;
            laserClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            laserClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * speed;
        }
    }
}
