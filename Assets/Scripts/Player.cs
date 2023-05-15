using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    // variable que nos controla si puede o no saltar
    private bool canJump = true;
    // hacemos que en el spawn tengan posicionamiento aleatorio dentro de un margen
    public override void OnNetworkSpawn()
    {
        transform.position = GetRandomPositionOnPlane();
    }

    // metodo que genera una posicion aleatoria dentro de unos margenes
    static Vector3 GetRandomPositionOnPlane()
    {
        return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
    }

    void Update()
    {
        // si eres owner mueve con los imputs
        if (IsOwner)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * 5f * Time.deltaTime;

            // se obtiene si se pulso el imput del salto y si se puede saltar
            if (Input.GetButtonDown("Jump") && canJump)
            {
                // se le añade una fuerza de salto en el eje y, un valor aceptable
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 300f, 0));
                // se pone que no pueda saltar ya que lo acaba de hacer
                canJump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // se comprueba si colisiono con el suelo para dejarlo volver a saltar
        if (collision.transform.CompareTag("Suelo"))
        {
            canJump = true;
        }
    }
}

