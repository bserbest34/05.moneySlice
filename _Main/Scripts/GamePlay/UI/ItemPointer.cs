using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPointer : MonoBehaviour
{
    private Transform target;
    private RectTransform pointerRectTransform;

    private float borderSize;

    private Image image;

    [SerializeField] Sprite arrow;
    [SerializeField] Sprite sign;

    public void SetItemTransformForTutorials(Transform item)
    {
        transform.Find("Pointer").gameObject.SetActive(true);
        target = item;
    }

    private void Awake()
    {
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        image = transform.Find("Pointer").GetComponent<Image>();
        borderSize = 100f;
    }

    private void Update()
    {
        if (target == null)
            return;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(target.position);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;

        if (isOffScreen)
        {
            Rotation();
            image.sprite = arrow;
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
            if (cappedTargetScreenPosition.x >= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width - borderSize;
            if (cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
            if (cappedTargetScreenPosition.y >= Screen.height - borderSize) cappedTargetScreenPosition.y = Screen.height - borderSize;

            pointerRectTransform.position = cappedTargetScreenPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        }
        else
        {
            Rotation();
            image.sprite = sign;
            pointerRectTransform.position = targetPositionScreenPoint;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        }
    }

    private void Rotation()
    {
        Vector3 toPosition = target.position;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = (Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg) % 360;
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

    }
}