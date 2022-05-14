using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image _bgImage;
    private Image _joyStickImage;
    private Vector3 inputVector = Vector3.zero;
    private Vector3 inputRotation = Vector3.zero;

    public Vector3 PosValue
    {
        get { return inputVector; }
    }
    public Vector3 RotationValue
    {
        get { return inputRotation; }
    }

    private void Start()
    {
        _bgImage = GetComponent<Image>();
        _joyStickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / _bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _bgImage.rectTransform.sizeDelta.y);

            inputVector = Vector3.Lerp(inputVector, new Vector3(pos.x * 2, pos.y * 2, 0), 0.5f);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            _joyStickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (_bgImage.rectTransform.sizeDelta.x / 3), inputVector.y * (_bgImage.rectTransform.sizeDelta.y / 3));

            inputRotation = new Vector3(0f, 0f, -Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        _joyStickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
}
