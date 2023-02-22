//using HomaGames.HomaBelly;
using UnityEngine;

public class LogManager : Singleton<LogManager>
{
    private void Awake()
    {
        UIManager.OnStart += LevelStarted;
        UIManager.OnSuccess += Success;
        UIManager.OnFail += Fail;
    }

    void LevelStarted()
    {
        //DefaultAnalytics.LevelStarted(PlayerPrefs.GetInt("Level"));
    }

    void Fail()
    {
        //DefaultAnalytics.LevelFailed();
    }

    void Success()
    {
        //DefaultAnalytics.LevelCompleted();
    }
}
