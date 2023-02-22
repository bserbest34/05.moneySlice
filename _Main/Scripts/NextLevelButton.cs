using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    Button nextLevelButton;
    GManager gManager;

    private void Start()
    {
        gManager = FindObjectOfType<GManager>();
        nextLevelButton = GetComponent<Button>();
        nextLevelButton.onClick.AddListener(NextLevel);
    }
    void NextLevel()
    {
        UIManager.Instance.SuccesGame();
        transform.GetComponent<Image>().enabled = false;
        transform.gameObject.SetActive(false);
    }
}
