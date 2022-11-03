using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite Frenteg, Arribag, Arriba_izquierdag, Izquierdag, Abajo_izquierdag, Abajog, Abajo_derechag, Derechag, Arriba_derechag, Características;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = Frenteg;
        
    }

    private void Update()
    {
     
        Vector3 mousePosition = GetWorldMousePosition();


        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) - Mathf.PI / 2f;
       
        
        
            //Arriba
            if (angle >= -0.400001 && angle <= 0.50000)
            {
                GetComponent<SpriteRenderer>().sprite = Arribag;

            }

            //Diagonal superior izquierda
            if (angle >= 0.500001 && angle <= 1.00001)
            {
                GetComponent<SpriteRenderer>().sprite = Arriba_izquierdag;

            }

            //Izquierda
            if (angle >= 1.100001 && angle <= 1.500001)
            {
                GetComponent<SpriteRenderer>().sprite = Izquierdag;

            }

            //Diagonal inferior izquierda
            if (angle >= -4.60000 && angle <= -3.90000)
            {
                GetComponent<SpriteRenderer>().sprite = Abajo_izquierdag;

            }

            //Abajo
            if (angle >= -3.90001 && angle <= -2.30000)
            {
                GetComponent<SpriteRenderer>().sprite = Abajog;

            }

            //Diagonal inferior derecha
            if (angle >= -2.30001 && angle <= -2.050001)
            {
                GetComponent<SpriteRenderer>().sprite = Abajo_derechag;

            }

            //Derecha
            if (angle >= -1.80000 && angle <= -1.300001)
            {
                GetComponent<SpriteRenderer>().sprite = Derechag;

            }

            //Diagonal superior derecha
            if (angle >= -1.300002 && angle <= -0.500001)
            {
                GetComponent<SpriteRenderer>().sprite = Arriba_derechag;

            }

            //Frente
            {
                LayerMask mask = LayerMask.GetMask("Gato");
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hits = Physics2D.GetRayIntersectionAll(ray, 1500f, mask);

                foreach (var hit in hits)
                {
                    GetComponent<SpriteRenderer>().sprite = Frenteg;

                    if (Input.GetMouseButton(0))
                    {
                     GetComponent<SpriteRenderer>().sprite = Características;
                    }
                }
            }



    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);

        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

   


}