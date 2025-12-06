using System;

public class ScoreEM
{
    public static event Action<bool> OnResetScore;
    public static event Action<int> OnAddScore;
    public static event Action OnReachTargetScore;

    public static void ResetScore(bool isSaving)
    {
        OnResetScore?.Invoke(isSaving);
    }

    public static void AddScore(int newScore)
    {
        OnAddScore?.Invoke(newScore);
    }

    public static void ReachTargetScore()
    {
        OnReachTargetScore?.Invoke();
    }
}
