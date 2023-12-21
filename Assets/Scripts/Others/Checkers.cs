using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkers : MonoBehaviour
{
    private Image _checkImage;

    public bool IsActive;

    public void Initialize()
    {
        _checkImage = GetComponent<Image>();
        IsActive = false;
    }

    public void Active()
    {
        IsActive = true;
        _checkImage.color = Color.yellow;
    }

    public void Deactive()
    {
        IsActive = false;
        _checkImage.color = Color.white;
    }

}
