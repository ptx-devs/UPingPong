using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBehaviour : MonoBehaviour
{
    public Transform ballTransform;

    
    System.Random R = new System.Random();
    int? rand = null;
    float currentSpeed = 0f;
    int maxSpeed = 15;
    private Vector3 originPos;

    // Start is called before the first frame update
    void Start()
    {
        originPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (ballTransform.GetComponent<BallBehaviour>().gameStarted)
        {
            //  Checamos donde esta la bola
            float x = Camera.main.WorldToScreenPoint(ballTransform.position).x;
            bool ballInField = x > Screen.width / 2;


            //  Si la bola ya está en nuestro campo y aun no se registra el random
            if (ballInField && rand == null)
            {
                //  Registramos el random y asignamos la velocidad...
                rand = R.Next(3, (R.Next(1, (DeadZone.PlayerScore) + 1) > 2 ? maxSpeed : 10));
                currentSpeed = (int)rand / 100f; // minima de 0.05 y maxima de 0.2
            }

            //  si aun no esta en el campo, ponemos una velocidad normal
            else if (!ballInField)
            {
                rand = null;
                currentSpeed = 0.03f;
            }

            //  Si la posición en y del enemigo es menor que la de la bola
            float v = (transform.position.y < ballTransform.position.y)

                //le damos espid
                ? transform.position.y + currentSpeed

                //si no, le quitamos
                : transform.position.y - currentSpeed;

            //  Por ultimo le damos la velocidad
            transform.position = new Vector3(
                transform.position.x,
                v, 
                transform.position.z
            );
        }
        else
            transform.position = originPos;

    }
}
