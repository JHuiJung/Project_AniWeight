using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_AniSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> anis = new List<GameObject>();

    [SerializeField]
    Vector2 minPos = Vector2.zero;

    [SerializeField]
    Vector2 maxPos = Vector2.zero;

    [SerializeField, Range(0, 10f)]
    float minTime = 0f;

    [SerializeField, Range(0, 10f)]
    float maxTime = 0f;

    float selectedTime = 0f;
    float _time = 0f;
    private void Start()
    {
        selectedTime = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= selectedTime)
        {
            _time = 0f;

            // Instantiate a random object from the list
            var np = Instantiate(anis[Random.Range(0, anis.Count)]);

            // Set position
            np.transform.position = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0f);

            // Set random rotation on the Z axis
            float randomZRotation = Random.Range(0f, 360f);
            np.transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);

            // Destroy the object after 3 seconds
            Destroy(np, 7f);
        }
    }


}
