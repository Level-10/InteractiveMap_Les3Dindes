using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneParent : MonoBehaviour
{
    [SerializeField] protected Color newColor = Color.black;

    virtual public Color GetNewColor() { return newColor; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    virtual public void ChangeZoneTint(Color _color)
    {
        SpriteRenderer _sr = GetComponent<SpriteRenderer>();
        _sr.color = _color;
    }

    public void ResetColor()
    {
        SpriteRenderer _sr = GetComponent<SpriteRenderer>();
        _sr.color = Color.white;
    }
}
