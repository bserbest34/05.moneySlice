using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButtons : MonoBehaviour
{
    Button closeButton;

    private void Start()
    {
        closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(CloseTab);

    }

    void CloseTab()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
