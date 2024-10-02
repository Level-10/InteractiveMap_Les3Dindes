using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZonesManager : MonoBehaviour
{
    [SerializeField] GameObject vallon = null;
    public List<ZoneParent> zones;
    string zoneTag = "Zone";

    //Getter

    void Start()
    {
        zones = FindObjectsOfType<ZoneParent>().ToList();
    }

    void Update()
    {
        
    }
}
