using System;

public class GameplayEM
{
    public static event Action OnPrepareGame;
    public static event Action OnStartGame;

    public static void PrepareGame()
    {
        OnPrepareGame?.Invoke();
    }

    public static void StartGame()
    {
        OnStartGame?.Invoke();
    }
}
