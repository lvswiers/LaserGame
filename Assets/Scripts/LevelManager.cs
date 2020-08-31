using UnityEngine;
using System.Collections;
using GameObjects;

/// <summary>
/// Handles button click events in the level
/// </summary>
public class LevelManager : MonoBehaviour {

    public bool BuildMode = true;

    public DynamicObjectsContainer container; 

    public bool BuildModeToggleable = true;

    public void ResetInventory() {
        foreach (var @object in container.PlaceableObjects)
        {
            @object.ResetPosition();
        }
    }

    private void ToggleBuildMode() {
        if (BuildModeToggleable) {
            foreach (var @object in container.PlaceableObjects) {
            @object.ToggleBuildMode();
            }
        }
    }

    private void StartLaserSource() {
        container.LaserSource.StartMovingBullet();
    }

    private void ResetTarget() {
        container.LaserTarget.ResetTarget();
    }

    private void ResetLaserSource() {
        container.LaserSource.ResetBullet();
    }

    public void ClickStart() {
        StartLaserSource();
        ToggleBuildMode();
    }

    public void ClickReset() {
        ResetInventory();
        ToggleBuildMode();
        ResetTarget(); 
        ResetLaserSource();
    }

    public void ClickResetBullet() {
        ResetLaserSource();
        ToggleBuildMode();
    }

}
