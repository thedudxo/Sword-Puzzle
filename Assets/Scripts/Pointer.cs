using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    [SerializeField] GameObject getGrid;
    Grid grid;

    public GameObject attachedBlock = null;

    [SerializeField] KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] KeyCode rightKey = KeyCode.RightArrow;
    [SerializeField] KeyCode dropKey = KeyCode.DownArrow;

    // Start is called before the first frame update
    void Start()
    {
        grid = getGrid.GetComponent<Grid>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = gameObject.transform.position;


        //move pointer, if pressed

        if (Input.GetKeyDown(leftKey))
        {
            newPos.x--;
        }

        if (Input.GetKeyDown(rightKey))
        {
            newPos.x++;
        }


        //clamp to grid
        newPos.x = Mathf.Clamp(newPos.x, 0, grid.gridList.GetLength(0) - 1);

        //update pointer position
        gameObject.transform.position = newPos;


        //move attached block, if any
        if(attachedBlock != null)
        {
            newPos.y = 1;
            attachedBlock.transform.position = newPos;
        }


        //drop block, if pressed
        if (Input.GetKeyDown(dropKey) && attachedBlock != null)
        {
            attachedBlock.GetComponent<Block>().Drop();
            attachedBlock = null;
        }
    }
}
