using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMovement : MonoBehaviour
{

    public GameObject target;

    //The clicking works but the units dont update to move to the new target
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
            {
                Instantiate(target, raycastHit.point, Quaternion.identity);
            }
        }

    }
}
