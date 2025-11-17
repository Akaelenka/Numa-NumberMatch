using System;
using UnityEngine;

public class LoadingEM
{
    public static event Action OnResetProgression;
    public static event Action<int> OnUpdateProgression;
    public static event Action OnLoadingComplete;

    public static void ResetProgression()
    {
        OnResetProgression?.Invoke();
    }

    public static void UpdateProgression(int value)
    {
        OnUpdateProgression?.Invoke(value);
    }

    public static void LoadingComplete()
    {
        OnLoadingComplete?.Invoke();
    }
}
