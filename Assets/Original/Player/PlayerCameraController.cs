using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCameraController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image _cameraDragArea;

    public void Awake()
    {
        _cameraDragArea = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Initialize
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _cameraDragArea.rectTransform,
                eventData.position,
                eventData.enterEventCamera,
                out Vector2 posOut))
        { 

        }

    }

    

}
