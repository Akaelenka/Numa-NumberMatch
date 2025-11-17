using System;

public class ScoreEM
{
    public static event Action OnResetScore;
    public static event Action<int> OnAddScore;
    public static event Action OnReachTargetScore;

    public static void ResetScore()
    {
        OnResetScore?.Invoke();
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
