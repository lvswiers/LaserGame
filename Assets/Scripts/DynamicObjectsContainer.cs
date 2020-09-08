using UnityEngine;
using GameObjects;
using UnityEngine.UI;

/// <summary>
/// This class represents most objects in the scene that have dynamic properties.
/// Especially the ones that are changed by button triggers or custom events.
/// Example of dynamic object not contained here: Bullet.
/// </summary>
public class DynamicObjectsContainer: MonoBehaviour {

    private PlaceableObject[] placeableObjects;
    private InventoryItem[] inventoryItems;
    private LaserSource laserSource;
    private LaserTarget laserTarget;
    private DynamicButton dynamicButton;
    private Text counter;
    private Portal[] portals;

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

    public InventoryItem[] InventoryItems {
        get { return inventoryItems; }
    }

    public Text Counter {
        get { return counter; }
    }

    public Portal[] Portals {
        get { return portals; }
    }

    void Start() {
        placeableObjects = GetComponentsInChildren<PlaceableObject>();
        laserSource = GetComponentInChildren<LaserSource>();
        laserTarget = GetComponentInChildren<LaserTarget>();
        dynamicButton = GetComponentInChildren<DynamicButton>();
        inventoryItems = GetComponentsInChildren<InventoryItem>();
        GameObject test = GameObject.FindGameObjectWithTag("Counter");
        counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<Text>();
        portals = GetComponentsInChildren<Portal>();

        // Link events of lasertarget to button:
        laserTarget.Event += dynamicButton.OnSuccess;
    }
}