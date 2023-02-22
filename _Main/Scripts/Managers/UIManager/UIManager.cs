using UnityEngine;

public class UIManager : UIBaseManager
{
    internal static event GameStatus OnStart;
    internal static event GameStatus OnSuccess;
    internal static event GameStatus OnFail;
    internal static event GameStatus OnRetry;
    internal static event GameStatus OnLoadNextLevel;

    internal override void Start()
    {
        base.Start();
    }

    internal override void SuccesGame()
    {
        base.SuccesGame();
        OnSuccess?.Invoke();
    }

    internal override void FailGame()
    {
        base.FailGame();
        OnFail?.Invoke();
    }

    internal override void TapToStart()
    {
        base.TapToStart();
        OnStart?.Invoke();
    }

    internal override void TapToContinue()
    {
        base.TapToContinue();
        OnLoadNextLevel?.Invoke();
    }

    internal override void TapToRetry()
    {
        base.TapToRetry();
        OnRetry?.Invoke();
    }
}