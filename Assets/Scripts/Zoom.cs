using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Zoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float zoomSize;
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
        Vector3 scale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(scale.x * zoomSize, scale.y * zoomSize, scale.z);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Vector3 scale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(scale.x / zoomSize, scale.y / zoomSize, scale.z);
    }
}
