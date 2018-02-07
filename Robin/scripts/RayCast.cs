using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RayCast : MonoBehaviour
{
    public bool turnover = false;
    public bool confirm = false;

    public GameObject begingame;
    public GameObject particle;
    private GameObject minions;
    private GameObject target;

    private bool click;
    private bool clicking = false;
    private bool stopClick = false;

    void Update()
    {   
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        click = Input.GetMouseButton(0);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //particle.transform.position = hit.point;
                Instantiate(particle, hit.point, transform.rotation);
            }
            if (hit.collider.tag == "confirm")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    confirm = true;
                    Destroy(begingame);
                }
            }
            if (hit.collider.tag == "endturn")
            {
                if (this.GetComponent<Player1>().myTurn)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        turnover = true;
                    }
                }
            }
            if (click)
            {
                clicking = true;
            }
            if(click && clicking)
            {
                stopClick = true;

            }
            if (this.GetComponent<Player1>().myTurn)
            {
                if (click)
                {
                    if (hit.collider.tag == "p1")
                    {
                        minions = hit.transform.gameObject;
                    }
                }
                if (stopClick)
                {
                    if (hit.collider.tag == "p2")
                    {
                        target = hit.transform.gameObject;
                    }
                }
            }
        }
        print(stopClick);
        print(minions.name);
        print(target.name);
    }
}