using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    List<Hoop> hoops = new List<Hoop>();

    public void AddHoop(Hoop hoop)
    {
            if (hoops.Count > 0 && hoops[hoops.Count - 1].hoopSize < hoop.hoopSize)
                hoop.shouldEject = true;
            else
            {
                if (!hoops.Contains(hoop))
                    hoops.Add(hoop);
            }
        

    }

    public void RemoveHoop(Hoop hoop)
    {
        hoop.shouldEject = false;
        if(hoops.Contains(hoop))
        {
            hoops.Remove(hoop);
        }
    }
}
