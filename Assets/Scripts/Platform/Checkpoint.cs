using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CounterPlatform counterPlatform;
    private Transform leftGate;
    private Transform rightGate;
    [SerializeField] GameObject buttonCanvas;

    private void Start()
    {
        counterPlatform = GetComponentInChildren<CounterPlatform>();
    }

    public void OpenGates()
    {
        leftGate = transform.Find("LeftGate");
        rightGate = transform.Find("RightGate");
        leftGate.GetComponent<Gate>().Open();
        rightGate.GetComponent<Gate>().Open();
    }

    public void Succeeded()
    {
        var counter = counterPlatform.GetCounter();
        Debug.Log("Counter " + counter + " Target : " + counterPlatform.GetTarget());
        if (counter >= counterPlatform.GetTarget())
        {
            counterPlatform.SuccesfulAction();
            OpenGates();
        }
        else
        {
            buttonCanvas.SetActive(true);
            Debug.Log("CurrentScene " + LoadScene.instance.GetCurrentScene());
            buttonCanvas.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var picker = other.GetComponent<PickerPhysics>();
        if (picker != null)
        {
            picker.PushCollectables();
            StartCoroutine(Wait(2.5f));         
        }
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Succeeded();
    }
}
