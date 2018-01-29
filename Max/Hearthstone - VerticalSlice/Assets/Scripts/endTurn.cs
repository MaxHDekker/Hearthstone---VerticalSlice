using UnityEngine;
using System.Collections;

public class endTurn : MonoBehaviour
{
    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "endturn")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    print("robin sux");
                }
            }
        }
    }
}