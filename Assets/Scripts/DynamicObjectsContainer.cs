
using UnityEngine;
using GameObjects;

/// <summary>
/// This class represents most objects in the scene that have dynamic properties.
/// Especially the ones that are changed by button triggers or custom events.
/// Example of dynamic object not contained here: Bullet.
/// </summary>
public class DynamicObjectsContainer: MonoBehaviour {

    private PlaceableObject[] placeableObjects;
    private InventoryMirror[] inventoryMirrors;
    private LaserSource laserSource;
    private LaserTarget laserTarget;
    private DynamicButton dynamicButton;

    public PlaceableObject[] PlaceableObjects {
        get { return placeableObjects; }
    }

    public LaserSource LaserSource {
        get { return laserSource; }
    }

    public LaserTarget LaserTarget {
        get { return laserTarget; }
    }

    public DynamicButton DynamicButton {
        get { return dynamicButton; }
    }

    public InventoryMirror[] InventoryMirrors {
        get { return inventoryMirrors; }
    }

    void Start() {
        placeableObjects = GetComponentsInChildren<PlaceableObject>();
        laserSource = GetComponentInChildren<LaserSource>();
        laserTarget = GetComponentInChildren<LaserTarget>();
        dynamicButton = GetComponentInChildren<DynamicButton>();
        inventoryMirrors = GetComponentsInChildren<InventoryMirror>();

        // Link events of lasertarget to button:
        laserTarget.Event += dynamicButton.OnSuccess;
    }
}