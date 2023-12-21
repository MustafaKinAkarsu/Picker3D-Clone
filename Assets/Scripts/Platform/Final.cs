using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    [SerializeField] GameObject buttonCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickerMovement>() != null) other.GetComponent<PickerMovement>().Deactivate();
        if (!buttonCanvas.activeInHierarchy) buttonCanvas.SetActive(true);
        Debug.Log("CurrentScene " + LoadScene.instance.GetCurrentScene());
        buttonCanvas.transform.GetChild(0).gameObject.SetActive(true);

    }
    
}
