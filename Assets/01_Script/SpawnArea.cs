using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SpawnArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool MouseOnArea = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOnArea = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOnArea = false;
    }
}
