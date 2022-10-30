using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFinal1 : MonoBehaviour
{
    private SpriteRenderer rend; 
    public Sprite Frente, Arriba_izquierda, Izquierda, Abajo_izquierda, Abajo, Abajo_derecha, Derecha, Arriba_derecha;
    [SerializeField, Range(0, 8)] private float Colors = 0f;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = Frente;
    }

    private void Update()
    {
        Vector3 mousePosition = GetWorldMousePosition();

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) - Mathf.PI / 2f;
        RotateZ(angle);
        Debug.Log(angle);

        //Frente
        if (angle >= -0.300001 && angle <= 0.500001)
        {
            GetComponent<SpriteRenderer>().sprite = Frente;
            Colors = 0f;
        }

        //Diagonal superior izquierda
        if (angle >= 0.500001 && angle <= 1.000001)
        {
            GetComponent<SpriteRenderer>().sprite = Arriba_izquierda;
            Colors = 1f;
        }

        //Izquierda
        if (angle >= 1.200001 && angle <= 1.500001)
        {
            GetComponent<SpriteRenderer>().sprite = Izquierda;
            Colors = 2f;
        }

        //Diagonal inferior izquierda
        if (angle >= -4.000001 && angle <= -3.00000)
        {
            GetComponent<SpriteRenderer>().sprite = Abajo_izquierda;
            Colors = 3f;
        }

        //Abajo
        if (angle >= -3.50000 && angle <= -2.700001)
        {
            GetComponent<SpriteRenderer>().sprite = Abajo;
            Colors = 4f;
        }

        //Diagonal inferior derecha
        if (angle >= -2.30000 && angle <= -2.050001)
        {
            GetComponent<SpriteRenderer>().sprite = Abajo_derecha;
            Colors = 5f;
        }

        //Derecha
        if (angle >= -1.80000 && angle <= -1.300001)
        {
            GetComponent<SpriteRenderer>().sprite = Derecha;
            Colors = 6f;
        }

        //Diagonal superior derecha
        if (angle >= -1.05000 && angle <= -0.500001)
        {
            GetComponent<SpriteRenderer>().sprite = Arriba_derecha;
            Colors = 7f;
        }

        //Frente
        //if (Input.mousePosition.x >= 127.00 && Input.mousePosition.x <= 207.00) 
        //{
        //    Colors = 0f;
        //}

        //if (Input.mousePosition.y >= 220.00 && Input.mousePosition.y <= 265.00)
        //{
        //  Colors = 0f;
        //}

        //Abajo


        //Diagonal superior izquierda
        //if (Input.mousePosition.x <= 127.00 && Input.mousePosition.x >= 40.00) 
        //{
        //  Colors = 1f;
        //}

        //if (Input.mousePosition.y <= 215.00 && Input.mousePosition.y >= 179.00)
        //{
        //  Colors = 1f;
        //}

        //Izquierda
        //if (Input.mousePosition.x <= 40.00 && Input.mousePosition.x >= 26.00)
        //{
        //Colors = 2f;
        //}

        //Diagonal inferior izquierda
        //if (Input.mousePosition.x <= 110.00 && Input.mousePosition.x >= 40.00)
        //{
        //Colors = 3f;
        //}

        //Diagonal superior derecha
        //if (Input.mousePosition.x >= 207.00 && Input.mousePosition.x <= 260.00)
        //{
        //    Colors = 8f;
        //}

        //if (Input.mousePosition.y <= 265.00 && Input.mousePosition.y <= 265.00)
        //{
        //  Colors = 0f;
        //}

        //

        //Debug.Log(Input.mousePosition);
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
        //Debug.Log(transform.rotation);
    }

    private void ImageChange(float radians)
    {

    }
}
