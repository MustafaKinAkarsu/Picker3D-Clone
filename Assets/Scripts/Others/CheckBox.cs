using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    [SerializeField] private List<Checkers> checkers;
    // Start is called before the first frame update
    private void Start()
    {
        checkers = GetComponentsInChildren<Checkers>().ToList();
        foreach (var checkItem in checkers)
        {
            checkItem.Initialize();
        }
    }
    public void DeActivateCheckPointItem()
    {
        foreach (var item in checkers)
        {
            item.Deactive();
        }
    }

    public void ActiveCheckPointItem()
    {
        foreach (var item in checkers)
        {
            if (!item.IsActive)
            {
                item.Active();
                break;
            }
        }
    }
}
