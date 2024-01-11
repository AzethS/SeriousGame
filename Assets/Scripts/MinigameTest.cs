using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTest : MonoBehaviour
{
    [SerializeField] int nextButton;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject[] myObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonOrderPanelClose()
    {
        GamePanel.SetActive(false);
    }
    public void ButtonPanelOpen()
    {
        GamePanel.SetActive(true);
    }
}
