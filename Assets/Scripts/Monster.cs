using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    GameObject target;

    public float speed;
    //private int randomSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        //randomSpeed = Random.Range(1, 3);

        Destroy(this.gameObject, 3.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveMonster();
        //Vector2 currentPositon = transform.position;
        //Vector2 targetPosition = target.transform.position;

        //transform.position = Vector2.MoveTowards(currentPositon, targetPosition, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player")
        {

            
            
                Destroy(this.gameObject);
            
        }
    }

    private void MoveMonster()
    {
        Vector2 currentPositon = transform.position;
        Vector2 targetPosition = target.transform.position;

        if (target != null)
        {
            transform.position = Vector2.MoveTowards(currentPositon, targetPosition, speed);
        }
        else
        {
            transform.position = Vector2.zero;
        }
    }
}
