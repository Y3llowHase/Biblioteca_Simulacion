using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ni�a : MonoBehaviour
{
    
    private SpriteRenderer rend;
    public Sprite Frente, Arriba, Arriba_izquierda, Izquierda, Abajo_izquierda, Abajo, Abajo_derecha, Derecha, Arriba_derecha, Caracter�sticas;

    private void Start()
    {
        
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = Frente;   
    }

    private void Update()
    {
        
        
        Vector3 mousePosition = GetWorldMousePosition();
        

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) - Mathf.PI / 2f;
       

        
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
          
        //Frente
        {
            
            LayerMask mask = LayerMask.GetMask("Ni�a"); 
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics2D.GetRayIntersectionAll(ray, 1500f, mask);

            foreach (var hit in hits)
            {
                GetComponent<SpriteRenderer>().sprite = Frente;

                 if (Input.GetMouseButton(0))
                 {
                    GetComponent<SpriteRenderer>().sprite = Caracter�sticas;
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
