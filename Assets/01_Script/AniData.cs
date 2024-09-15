using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AniInfo
{
    public string name_animal = "";
    public GameObject Obj_AniBall;
}

[CreateAssetMenu(fileName = "AniData", menuName = "Data/AniData", order = 0)]
public class AniData : ScriptableObject
{
    public List<AniInfo> aniInfos = new List<AniInfo>();

    public GameObject GetAnimalObj(string _name)
    {
        foreach (AniInfo ani in aniInfos)
        {
            if(ani.name_animal == _name)
            {
                return ani.Obj_AniBall;
            }
        }

        return null;
    }
}
