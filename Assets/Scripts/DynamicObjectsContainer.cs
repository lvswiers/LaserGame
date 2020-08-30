
using UnityEngine;
using GameObjects;

public class DynamicObjectsContainer: MonoBehaviour {

    private PlaceableMirror[] mirrors;
    private LaserSource laserSource;
    private LaserTarget laserTarget;

    public PlaceableMirror[] Mirrors {
        get { return mirrors; }
    }

    public LaserSource LaserSource {
        get { return laserSource; }
    }

    public LaserTarget LaserTarget {
        get { return laserTarget; }
    }

    void Start() {
        mirrors = GetComponentsInChildren<PlaceableMirror>();
        laserSource = GetComponentInChildren<LaserSource>();
        laserTarget = GetComponentInChildren<LaserTarget>();
    }
}