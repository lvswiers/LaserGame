﻿using UnityEngine;
using System.Collections;
using GameObjects;

/// <summary>
/// Handles button click events in the level
/// </summary>
public class LevelManager : MonoBehaviour {

    private int numberOfAttempts = 0;
    public bool BuildMode = true;

    public DynamicObjectsContainer container; 

    public bool BuildModeToggleable = true;

    public void ResetInventory() {
        foreach (var placeable in container.PlaceableObjects)
        {
            placeable.ResetPosition();
        }
    }

    private void toggleBuildMode() {
        if (BuildModeToggleable) {
            foreach (var placeable in container.PlaceableObjects) {
                placeable.ToggleBuildMode();
            }
            foreach (var mirror in container.InventoryItems) {
                mirror.ToggleBuildMode();
            }
        }
    }

    private void startLaserSource() {
        container.LaserSource.StartMovingBullet();
    }

    private void resetTarget() {
        container.LaserTarget.ResetTarget();
    }

    private void resetLaserSource() {
        container.LaserSource.ResetBullet();
    }

    private void enableStartButton() {
        container.DynamicButton.Enable();
    }

    private void disableStartButton() {
        container.DynamicButton.Disable();
    }

    private void updateNumberOfAttempts() {
        numberOfAttempts += 1;
        container.Counter.text = numberOfAttempts.ToString();
    }

    private void resetPortals() {
        foreach (var portal in container.Portals) {
            portal.ResetTeleported();
        }
    }

    public void ClickStart() {
        startLaserSource();
        toggleBuildMode();
        disableStartButton();
        updateNumberOfAttempts();
    }

    public void ClickReset() {
        ResetInventory();
        resetTarget(); 

        ClickResetBullet();
    }

    public void ClickResetBullet() {
        resetLaserSource();
        toggleBuildMode();
        enableStartButton();
        resetPortals();
    }

}
