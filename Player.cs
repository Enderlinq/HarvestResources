using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Camera cam;
    public Transform hand;
    Animator handAnim;
    public float interactDist = 10f;

    private void Start()
    {
        handAnim = hand.GetComponent<Animator>();
    }

    private void Update()
    {
        DoInteraction();
    }

    private void DoInteraction()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDist))
        {
            if(hit.collider.tag == "Harvest")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Harvest currentHarvest = hit.collider.GetComponent<Harvest>();
                    currentHarvest.HarvestResources(10f);
                }
            }
        }
    }

}
