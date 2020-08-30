
using UnityEngine;
using GameObjects;

public class DynamicObjectsContainer: MonoBehaviour {

    private PlaceableMirror[] mirrors;
    private LaserSource laserSource;
    private LaserTarget laserTarget;

    private DynamicButton dynamicButton;

    public PlaceableMirror[] Mirrors {
        get { return mirrors; }
    }

    public LaserSource LaserSource {
        get { return laserSource; }
    }

    public LaserTarget LaserTarget {
        get { return laserTarget; }
    }

    public DynamicButton DynamicButton {
        get { return DynamicButton; }
    }

    void Start() {
        mirrors = GetComponentsInChildren<PlaceableMirror>();
        laserSource = GetComponentInChildren<LaserSource>();
        laserTarget = GetComponentInChildren<LaserTarget>();
        dynamicButton = GetComponentInChildren<DynamicButton>();

        // Link events of lasertarget to button:
        laserTarget.Event += dynamicButton.OnSuccess;
    }
}