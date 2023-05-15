using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkTransform : NetworkBehaviour
{
    private float speed = 4.5f;


    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
            Debug.Log("el inutil de turno");
        }
    }
}
