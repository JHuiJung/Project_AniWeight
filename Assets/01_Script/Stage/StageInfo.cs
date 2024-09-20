using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StageState
{
    Lock,
    UnLock,
    Clear
}
public class StageInfo : MonoBehaviour
{
    public StageState state = StageState.UnLock;
    public string moveSceneName = "Title";

    public GameObject icon_Lock;
    public GameObject icon_Clear;

    public void ChangeState(StageState _state)
    {
        switch (_state)
        {
            case StageState.Lock:
                icon_Clear.SetActive(false);
                icon_Lock.SetActive(true);
                break;
            case StageState.UnLock:
                icon_Clear.SetActive(false);
                icon_Lock.SetActive(false);
                break ;
            case StageState.Clear:
                icon_Clear.SetActive(true);
                icon_Lock.SetActive(false);
                break;
        }
    }
}
