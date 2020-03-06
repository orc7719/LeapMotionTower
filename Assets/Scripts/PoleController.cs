using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    public List<Hoop> hoops = new List<Hoop>();

    public void AddNewHoop(Hoop hoop)
    {
        if (!hoops.Contains(hoop))
        {
            if (CheckHoop(hoop))
                hoop.Eject();
            else
            hoops.Add(hoop);
        }
    }

    public void RemoveHoop(Hoop hoop)
    {
            if (hoops.Contains(hoop))
                hoops.Remove(hoop);
    }

    bool CheckHoop (Hoop hoopToCheck)
    {
        if (hoops.Count > 0)
            if (hoops[hoops.Count - 1].hoopSize < hoopToCheck.hoopSize)
                return true;

        return false;
    }
}
