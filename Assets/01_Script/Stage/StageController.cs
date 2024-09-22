using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public List<StageInfo> StageInfos;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        DataManager.Instance.LoadGameData();

        if (StageInfos.Count != DataManager.Instance.data.Stage.Length)
        {
            Debug.Log("�������� ������ ������ ������ ���� ����");
            return;
        }

        for (int i = 0; i < DataManager.Instance.data.Stage.Length; i++)
        {
            StageInfos[i].ChangeState((DataManager.Instance.data.Stage[i]));
        }

    }
}
