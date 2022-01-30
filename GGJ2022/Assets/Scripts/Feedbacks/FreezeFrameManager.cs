using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FreezeFrameManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.HealthManager.onHealthChanged += HealthManager_onHealthChanged;
    }

    private void HealthManager_onHealthChanged(int obj)
    {
        FreezeFrame();
    }

    private async void FreezeFrame()
    {
        Time.timeScale = 0;
        await Task.Delay(30);
        Time.timeScale = 1;
    }
}
