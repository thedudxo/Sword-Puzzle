using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    bool dropping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (dropping)
        {
            Vector3 newPos = transform.position;
            newPos.y--;

            if(newPos.y *-1 > Grid.height -1)
            {
                dropping = false;
                newPos = transform.position;
            }


            transform.position = newPos;
        }

    }

    public void Drop()
    {
        dropping = true;
    }
}
