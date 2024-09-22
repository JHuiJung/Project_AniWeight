using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData
{
    public int[] Stage;

    public StageData()
    {
        Stage = new int[9];
        Stage[0] = 1;  // 첫 번째 값을 1로 설정
    }
}
