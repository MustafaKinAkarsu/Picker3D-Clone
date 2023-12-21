using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerPhysics : MonoBehaviour
{
    [SerializeField] private List<Collectable> _collectables;

    public PickerPhysics()
    {
        _collectables = new List<Collectable>();
    }

    public void AddCollectable(Collectable collectable)
    {
        _collectables.Add(collectable);
    }

    public void RemoveCollectable(Collectable collectable)
    {
        _collectables.Remove(collectable);
    }

    public List<Collectable> GetCollectables()
    {
        return _collectables;
    }

    public void Clear()
    {
        _collectables.Clear();
    }
    public void PushCollectables()
    {
        this.gameObject.GetComponent<PickerMovement>().Deactivate();
        foreach (var collectable in GetCollectables())
        {
            collectable.Push();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<Collectable>();
        if (collectable != null)
        {
            AddCollectable(collectable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var collectable = other.GetComponent<Collectable>();
        if (collectable != null)
        {
            RemoveCollectable(collectable);
        }
    }

    
}
