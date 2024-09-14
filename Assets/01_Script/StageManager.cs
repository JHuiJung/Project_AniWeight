using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageManager : MonoBehaviour
{
    public static StageManager inst;

    public List<Plate> plates = new List<Plate>(); 

    public List<AniBall> aniBalls = new List<AniBall>();

    [Space(10),Header("Display")]
    public GameObject Panel_Fail;
    public GameObject Panel_Success;
    public TMP_Text textCnt;


    public bool isGameEnd = false;

    bool allAnimalAttached = false;
    bool allPlateWeightEqual = false;

    float _time = 0f;

    private void Awake()
    {
        inst = this;
    }

    private void Update()
    {
        if (isGameEnd) return;
        CheckPlateWeights();
        CheckAnimalAttached();

        if(allAnimalAttached && allPlateWeightEqual)
        {
            _time += Time.deltaTime;

            textCnt.text = (3f-_time).ToString("F0");

            if ( _time > 3f )
            {
                _time = 0f;
                Sucess();
            }
        }
        else
        {
            _time = 0f;
            textCnt.text = "";
        }
    }

    public void BTN_Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BTN_Preference()
    {

    }

    public void BTN_Play()
    {
        aniBalls.Clear();
        aniBalls = new List<AniBall>(FindObjectsOfType<AniBall>());

        foreach(AniBall ani in aniBalls)
        {
            ani.Play();
        }

    }

    public void Fail()
    {
        isGameEnd = true;
        Panel_Fail.SetActive(true);
    }

    public void Sucess()
    {
        isGameEnd = true;
        Panel_Success.SetActive(true);
    }

    void CheckAnimalAttached()
    {
        if(aniBalls.Count > 0)
        {
            foreach (AniBall ani in aniBalls)
            {
                if(!ani.isAttached)
                {
                    allAnimalAttached = false;
                    return;
                }
            }

            allAnimalAttached = true;
        }
        else
        {
            allAnimalAttached = false;
        }
    }

    void CheckPlateWeights()
    {
        if (plates.Count == 0) return; // 리스트가 비어있을 경우 종료

        // 리스트 내 최소, 최대 total_weight 값 구하기
        float minWeight = float.MaxValue;
        float maxWeight = float.MinValue;

        foreach (Plate plate in plates)
        {
            if (plate.Total_Weight < minWeight) minWeight = plate.Total_Weight;
            if (plate.Total_Weight > maxWeight) maxWeight = plate.Total_Weight;
        }

        // 무게 차이가 1 미만인지 확인
        if (maxWeight - minWeight < 1f)
        {
            allPlateWeightEqual = true;
        }
        else
        {
            allPlateWeightEqual = false;
        }
    }
}
