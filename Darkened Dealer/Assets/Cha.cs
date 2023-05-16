using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float Hor;
    float Ver;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void playerMove()
    {
         Hor = Input.GetAxis("Horizontal");
         Ver = Input.GetAxis("Vertical");

        Vector3 playerMove = new Vector3(Hor, 0f, Ver) * moveSpeed * Time.deltaTime;
        transform.Translate(playerMove, Space.Self);
    }
}

