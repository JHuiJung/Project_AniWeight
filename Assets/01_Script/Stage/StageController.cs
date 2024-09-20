using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{

    public StageData stageData;
    public List<StageInfo> StageInfos;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        if(StageInfos.Count != stageData.States.Count)
        {
            Debug.Log("�������� ������ ������ ������ ���� ����");
            return;
        }

        for(int i = 0; i < stageData.States.Count; i++)
        {
            StageInfos[i].ChangeState(stageData.States[i]);
        }
        
    }
}
