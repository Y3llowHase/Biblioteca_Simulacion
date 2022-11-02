using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtFinal5 : MonoBehaviour
{
    
    private SpriteRenderer rend;
    //private BoxCollider2D Box;
    //[SerializeField] GameObject Imagen;
    public Sprite Frente, Arriba, Arriba_izquierda, Izquierda, Abajo_izquierda, Abajo, Abajo_derecha, Derecha, Arriba_derecha;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = Frente;
        //Box = GetComponent<BoxCollider2D>();
       // Objeto1 = GetComponent<GameObject>();
    }

    private void Update()
    {
        //OnMouseEnter();
        //Imagen.transform.position = new Vector2(Imagen.transform.position.x, Imagen.transform.position.y);
        //Vector3 worldImagen = Camera.main.ScreenToWorldPoint(Imagen.transform.position);
        

        //OnMouseOver(Imagen);
        Vector3 mousePosition = GetWorldMousePosition();
        

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) - Mathf.PI / 2f;
        //RotateZ(angle);
        Debug.Log(angle);

        
            //Arriba
            if (angle >= -0.400001 && angle <= 0.50000)
            {
                GetComponent<SpriteRenderer>().sprite = Arriba;

            }

            //Diagonal superior izquierda
            if (angle >= 0.500001 && angle <= 1.00001)
            {
                GetComponent<SpriteRenderer>().sprite = Arriba_izquierda;

            }

            //Izquierda
            if (angle >= 1.100001 && angle <= 1.500001)
            {
                GetComponent<SpriteRenderer>().sprite = Izquierda;

            }

            //Diagonal inferior izquierda
            if (angle >= -4.60000 && angle <= -3.90000)
            {
                GetComponent<SpriteRenderer>().sprite = Abajo_izquierda;

            }

            //Abajo
            if (angle >= -3.90001 && angle <= -2.30000)
            {
                GetComponent<SpriteRenderer>().sprite = Abajo;

            }

            //Diagonal inferior derecha
            if (angle >= -2.30001 && angle <= -2.050001)
            {
                GetComponent<SpriteRenderer>().sprite = Abajo_derecha;

            }

            //Derecha
            if (angle >= -1.80000 && angle <= -1.300001)
            {
                GetComponent<SpriteRenderer>().sprite = Derecha;

            }

            //Diagonal superior derecha
            if (angle >= -1.300002 && angle <= -0.500001)
            {
                GetComponent<SpriteRenderer>().sprite = Arriba_derecha;

            }

        

        
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    //private void RotateZ(float radians)
    //{
    //  transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    //Debug.Log(transform.rotation);
    //}


    private void OnMouseEnter()
    {
        rend.sprite = Frente;
    }
    //void OnMouseOver()
    //{

      //  rend.sprite = Frente;
    //}


}
