using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    [SerializeField] public Transform player;

    void Update()
    {
        if (player.position.x - this.transform.position.x > 75)
            Destroy(gameObject);
    }

}
