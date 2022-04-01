using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    private SpriteRenderer spriteR;
    [SerializeField] public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x > gameObject.transform.position.x + 815)
        {
            transform.Translate(new Vector3(815*2 , 0, 0));
        }
    }
}
