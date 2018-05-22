using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class StartSceneManeger : MonoBehaviour, IInputClickHandler
{

    [SerializeField]
    private GameObject MainScene;
    [SerializeField]
    public MainSceneManager mainSceneManager;

    public void OnInputClicked(InputClickedEventData eventData)
    {


        this.gameObject.SetActive(false);
        MainScene.SetActive(true);

        mainSceneManager.StartSceneStatus = false;
    }


}
