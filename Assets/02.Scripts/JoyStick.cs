using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Transform _leftController;
    private Transform _rightController;

    private Image _bgImage = null;
    private Image _joyStickImage = null;
    private Button _interactionBtn = null;

    private Vector3 inputPos = Vector3.zero;
    private Vector3 inputRotation = Vector3.zero;

    public Vector3 PosValue
    {
        get
        {
            return inputPos;
        }
        set
        {
            inputPos = value;
        }
    }
    public Vector3 RotationValue
    {
        get
        {
            return inputRotation;
        }
        set
        {
            inputRotation = value;
        }
    }

    private void Start()
    {
        _leftController = transform.Find("BackgroundImage");
        _bgImage = _leftController.GetComponent<Image>();
        _joyStickImage = _leftController.Find("JoyStickImage").GetComponent<Image>();

        _rightController = transform.Find("InteractionBtn");
        _interactionBtn = _rightController.GetComponent<Button>();
        _interactionBtn.onClick.AddListener(() => GameManager.instance._partyController.Interaction());
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / _bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _bgImage.rectTransform.sizeDelta.y);

            Vector3 inputPos = new Vector3(pos.x * 2, pos.y * 2, 0);
            PosValue = (inputPos.magnitude > 1.0f) ? inputPos.normalized : inputPos;

            _joyStickImage.rectTransform.anchoredPosition = new Vector3(PosValue.x * (_bgImage.rectTransform.sizeDelta.x / 3), PosValue.y * (_bgImage.rectTransform.sizeDelta.y / 3));

            RotationValue = new Vector3(0f, 0f, -Mathf.Atan2(inputPos.x, inputPos.y) * Mathf.Rad2Deg);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputPos = Vector3.zero;
        _joyStickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
}
