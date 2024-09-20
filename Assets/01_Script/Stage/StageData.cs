using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StageData", menuName = "Data/StageData", order = 1)]
public class StageData : ScriptableObject
{
    public List<StageState> States;
}
