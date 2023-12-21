using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Collect()
    {
        this.gameObject.SetActive(false);
    }
    public void Push()
    {
        float destinationZ = 5f; // The Z position you want to move to
        float duration = 1f; // The duration of the movement
        transform.DOMoveZ(transform.position.z + destinationZ, duration);
    }
}
