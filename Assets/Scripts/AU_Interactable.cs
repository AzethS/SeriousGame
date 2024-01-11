using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_Interactable : MonoBehaviour
{
    [SerializeField] GameObject miniGame;
    GameObject highlight;

    
    public void PlayMiniGame()
    {
        miniGame.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
