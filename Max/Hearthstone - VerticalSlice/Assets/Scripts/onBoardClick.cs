using UnityEngine;
using System.Collections;

public class onBoardClick : MonoBehaviour
{

    public GameObject particle;

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //particle.transform.position = hit.point;
                Instantiate(particle, hit.point, transform.rotation);
                print("hit");
            }
        }
    }
}