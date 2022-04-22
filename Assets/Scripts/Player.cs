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
    public Color orangeColor;
    public Color greenColor;
    public Color redColor;
    Renderer rend;

    void Start()
    {
        health = 10f;
        rend = GetComponent<Renderer>();
        rend.material.color = orangeColor;
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
        else
        {
            mousePosition = Input.mousePosition;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (rend.material.color == orangeColor)
        {
            if (collision.gameObject.tag == "Orange")
            {
                Destroy(collision.gameObject);
                Debug.Log("You touched the same color!");
                transform.localScale += new Vector3(0.1f, 0.1f);
                transform.position += new Vector3(0, 0.05f, 0);
            }
            else if (collision.gameObject.tag == "Green" || collision.gameObject.tag == "Red")
            {
                Destroy(collision.gameObject);
                Debug.Log("You touched the different color!");
                transform.localScale -= new Vector3(0.1f, 0.1f);
                transform.position -= new Vector3(0, 0.05f, 0);
            }
        }
        else if (rend.material.color == greenColor)
        {
            if (collision.gameObject.tag == "Green")
            {
                Destroy(collision.gameObject);
                Debug.Log("You touched the same color!");
                transform.localScale += new Vector3(0.1f, 0.1f);
                transform.position += new Vector3(0, 0.05f, 0);
            }
            else if (collision.gameObject.tag == "Orange" || collision.gameObject.tag == "Red")
            {
                Destroy(collision.gameObject);
                Debug.Log("You touched the different color!");
                transform.localScale -= new Vector3(0.1f, 0.1f);
                transform.position -= new Vector3(0, 0.05f, 0);
            }
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("You hit and obstacle and failed");
            health -= 1;
            if (health <= 0)
            {
                Debug.Log("You died!");
            }
        }
        if (collision.gameObject.tag == "ColorChange")
        {
            rend.material.color = greenColor;
            Debug.Log("You hit a color change! Color is green!");
        }
        if (collision.gameObject.tag == "FinishLine")
        {
            Debug.Log("You finished the level!");
            this.enabled = false;
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
