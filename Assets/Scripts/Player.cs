using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
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
        }
    }
}

