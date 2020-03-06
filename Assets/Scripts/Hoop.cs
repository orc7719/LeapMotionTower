using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public int hoopSize = 0;
    PoleController currentPole;
    bool onPole = false;
    public bool shouldEject;

    Vector3 resetPos;
    Quaternion resetRot;

    private void Start()
    {
        resetPos = transform.position;
        resetRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered: " + other);

        if (other.tag == "Pole")
        {
            currentPole = other.transform.root.GetChild(0).GetComponent<PoleController>();
            currentPole.AddHoop(this);
            onPole = true;
        }
    }

    private void Update()
    {
        if (transform.position.y <= -10f)
            ResetHoop();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left: " + other);

        if (other.tag == "Pole")
        {
            currentPole.RemoveHoop(this);
            currentPole = null;
            onPole = false;
        }
    }

    public void PickupHoop()
    {
        resetPos = transform.position;
        resetRot = transform.rotation;
    }

    void ResetHoop()
    {
        transform.position = resetPos;
        transform.rotation = resetRot;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void DropHoop()
    {
        if(shouldEject)
        {

            Invoke("EjectHoop", 1f);
        }
    }

    [ContextMenu("Eject Hoop")]
    void EjectHoop()
    {
        Debug.Log("EJECT HOOP");
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 0.3f, ForceMode.Impulse);
        shouldEject = false;

        Invoke("ResetHoop", 3f);
    }
}
