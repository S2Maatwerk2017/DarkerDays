using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;


public class Gate : MonoBehaviour
{
    private Collider MyCollider;

    void Start()
    {
        MyCollider = GetComponent<BoxCollider>();
    }

    public void CloseGate()
    {
        MyCollider.isTrigger = false;
    }

    public void OpenGate()
    {
        MyCollider.isTrigger = true;
    }
}
