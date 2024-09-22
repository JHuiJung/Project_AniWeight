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

    public GameObject icon_Lock;
    public GameObject icon_Clear;

    public void ChangeState(int _state)
    {
        // 0 = Lock
        // 1 = UnLock
        // 2 = Clear
        switch (_state)
        {
            case 0:
                icon_Clear.SetActive(false);
                icon_Lock.SetActive(true);
                break;
            case 1:
                icon_Clear.SetActive(false);
                icon_Lock.SetActive(false);
                break ;
            case 2:
                icon_Clear.SetActive(true);
                icon_Lock.SetActive(false);
                break;
        }
    }
}
