using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargantua : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    

    [Header("World")]
    [SerializeField] Camera camera;
    [SerializeField] Transform gargantua;


    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        move();
    }

    void Update()
    {

        position.Draw(Color.blue);
        velocity.Draw(position, Color.red);
        acceleration.Draw(position, Color.green);
        MyVector2D myPosition = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D gargantuaPosition = new MyVector2D(gargantua.position.x, gargantua.position.y);

        acceleration = gargantuaPosition - myPosition;
     
    }

    public void move()
    {
        velocity = velocity + acceleration * Time.deltaTime;

        position = position + velocity * Time.deltaTime;

        transform.position = new Vector3(position.x, position.y);
    }
}
