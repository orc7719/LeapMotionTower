using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public int hoopSize = 0;

    PoleController currentPole;

    bool onPole = false;
    public void DropHoop()
    {
        if(currentPole!=null)
        currentPole.AddNewHoop(this);
    }

    private void FixedUpdate()
    {
        onPole = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Pole")
        {
            onPole = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Pole" && !onPole)
        {
            other.transform.root.GetChild(0).GetComponent<PoleController>().RemoveHoop(this);
            currentPole = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pole")
        {
            currentPole = other.transform.root.GetChild(0).GetComponent<PoleController>();
        }
    }

    public void Eject()
    {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10);
    }
}
