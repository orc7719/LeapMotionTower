using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public int hoopSize = 0;

    public bool eject = false;

    public void DropHoop()
    {
        if(eject)
        {
            eject = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10);
        }
    }
}
