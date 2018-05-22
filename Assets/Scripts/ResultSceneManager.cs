using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ResultSceneManager : MonoBehaviour {

    [SerializeField]
    private GameObject StartScene;
    [SerializeField]
    public MainSceneManager mainSceneManager;

    public void OnInputClicked(InputClickedEventData eventData)
    {

        this.gameObject.SetActive(false);
        StartScene.SetActive(true);

        mainSceneManager.StartSceneStatus = true;
    }
}
