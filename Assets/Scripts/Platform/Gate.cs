using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] string gateName;

    private void Start()
    {
        gateName = gameObject.name;
    }

    public void Open()
    {
        if(gateName == "LeftGate")
        {
            transform.DORotate(new Vector3(-60, 90, 90), 1f);
        }
        else if(gateName == "RightGate")
        {
            transform.DORotate(new Vector3(60, 90, 90), 1f);
        }
    }
}
