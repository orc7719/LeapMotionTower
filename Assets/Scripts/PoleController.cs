using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    public List<Hoop> hoops = new List<Hoop>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.tag == "Hoop")
        {
            Hoop hoop = other.transform.root.GetComponent<Hoop>();

            if (CheckHoop(hoop))
                hoop.eject = true;


            if (!hoops.Contains(hoop))
                hoops.Add(hoop);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.tag == "Hoop")
        {
            Hoop hoop = other.transform.root.GetComponent<Hoop>();
            if (hoops.Contains(hoop))
                hoops.Remove(hoop);
        }
    }

    bool CheckHoop (Hoop hoopToCheck)
    {
        if (hoops.Count > 0)
            if (hoops[hoops.Count].hoopSize < hoopToCheck.hoopSize)
                return true;

        return false;
    }
}
