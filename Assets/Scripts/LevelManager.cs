using UnityEngine;
using System.Collections;
using GameObjects;

public class LevelManager : MonoBehaviour {

    public bool BuildMode = true;

    public DynamicObjectsContainer container; 

    public void ResetInventory() {
        foreach (var mirror in container.Mirrors)
        {
            mirror.ResetPosition();
        }
    }

    private void ToggleBuildMode() {
        foreach (var mirror in container.Mirrors) {
            mirror.ToggleBuildMode();
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

}
