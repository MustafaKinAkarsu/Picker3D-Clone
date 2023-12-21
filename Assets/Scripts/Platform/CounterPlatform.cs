using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class CounterPlatform : MonoBehaviour
{
    private int _targetCounter;
    private int _counter;
    private TextMeshPro _textMesh;
    public int target;
    private Vector3 _firstPos;
    [SerializeField] private Material _succesfulMaterial;
    [SerializeField] CheckBox checkBox;
    PickerMovement picker;
    // Start is called before the first frame update
    void Start()
    {
        _counter = 0;
        _targetCounter = target;
        _textMesh = GetComponentInChildren<TextMeshPro>(true);
        _textMesh.text = Mathf.RoundToInt(_counter) + "/" + _targetCounter;
        _firstPos = new Vector3(transform.position.x, -3.43f, transform.position.z);
        picker = FindObjectOfType<PickerMovement>();
    }
    public void SuccesfulAction()
    {        
        _textMesh.enabled = false;
        this.GetComponent<MeshRenderer>().material = _succesfulMaterial;
        checkBox.ActiveCheckPointItem();
        transform.DOMoveY(-0.15f, 1f).OnComplete((() => picker.Activate()));
    }
    public int GetCounter()
    {
        var temp = _counter;
        _counter = 0;
        return temp;
    }
    public int GetTarget()
    {
        return _targetCounter;
    }
    private void OnCollisionEnter(Collision other)
    {
        var collectable = other.gameObject.GetComponent<Collectable>();
        if(collectable != null)
        {
            _counter++;
            _textMesh.text = Mathf.RoundToInt(_counter) + "/" + _targetCounter;
            collectable.Collect();
        }
    }
}
