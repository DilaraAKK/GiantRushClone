using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject collectible;
    public float speed = 5f;
    public float horizontal = 0;
    public Vector3 turnPoint;
    public Vector3 mousePosition;
    public float health;
    private bool isHurt = true;


    void Start()
    {
      health = 10f;
    }


    void Update()
    {  
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, turnPoint.x - 1.5f, turnPoint.x + 1.5f), transform.position.y, transform.position.z);
        transform.position += transform.forward * Time.deltaTime * speed + transform.right * horizontal * 5;

        if (Input.GetMouseButton(0))
        {
            horizontal = (Input.mousePosition.x - mousePosition.x) / Screen.width * 1.5f;
            mousePosition = Input.mousePosition;
                
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            Debug.Log("You collected a collectible!");
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("You hit an obstacle!");
            health -= 1;
            if (health <= 0)
            {
                Debug.Log("You died!");
            }
        }
    }
    public void hurt()
    {
        if (isHurt)
        {
            health -= 1;
            isHurt = true;
            Debug.Log("You are hurt!");
        }
    }

}
