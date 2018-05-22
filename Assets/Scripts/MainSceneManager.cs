using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using HoloToolkit.Unity.InputModule;

public class MainSceneManager : MonoBehaviour
{

    public int GameScore;
    [SerializeField]
    TextMeshPro scoreText;

    [SerializeField]
    Transform mainCamTrans;

    [SerializeField]
    GameObject MainScene;
    [SerializeField]
    GameObject ResultScene;

    [SerializeField]
    GameObject[] Mogura = new GameObject[3];
    [SerializeField]
    GameObject[] MoguraTarget = new GameObject[3];
    [SerializeField]
    Collider[] MoguraCollider = new Collider[3];

    bool[] MoguraActiveFlag = new bool[4];

    public bool StartSceneStatus;
    private bool InitializeFlag;


    private float timeOut = 30;
    private float elapsedTime;
    private float moguraActiveTimeOut = 3;
    private float moguraActiveElapsedTime;

    RaycastHit hit;

    void Start()
    {
        scoreText.text = "Score:0";
        GameScore = 0;

        StartSceneStatus = true;
        InitializeFlag = true;
    }

    void Update()
    {

        ActiveRayCast();

        RandomMoguraActive();

        //if(StartSceneStatus == false && InitializeFlag == true)
        //{
            PutMoguraOnFloor(MoguraTarget[2]);
            InitializeFlag = false;
        //}

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= timeOut)
        {
            EndMainScene();
        }

    }

    void ActiveRayCast()
    {

        Vector3 fwd = mainCamTrans.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(mainCamTrans.transform.position, fwd, out hit, 10) )
        {
            if (hit.collider.tag == "Mogura") {
                hit.collider.enabled = false;

                AddScore();
                NegativeMogura(Mogura[0]);
            }
            if (hit.collider.tag == "Mogura1")
            {
                hit.collider.enabled = false;

                AddScore();
                NegativeMogura(Mogura[1]);
            }
            if (hit.collider.tag == "Mogura2")
            {
                hit.collider.enabled = false;

                AddScore();
                Debug.Log("OK");
                NegativeMogura(Mogura[2]);
            }

        }
    }

    void ActiveMogura(GameObject mogura, Collider moguraCol)
    {
        moguraCol.enabled = true;
        mogura.transform.DOLocalMove(new Vector3(0, 0.2f, 0), 0.3f);
    }

    void NegativeMogura(GameObject mogura)
    {
        
        mogura.transform.DOLocalMove(new Vector3(0, 0, 0), 1f);

    }

    void RandomMoguraActive()
    {
        moguraActiveElapsedTime += Time.deltaTime;

        if (moguraActiveElapsedTime >= moguraActiveTimeOut)
        {
            int MoguraNumber = Random.Range(0, 3);
            Debug.Log(MoguraNumber);
            moguraActiveElapsedTime = 0.0f;
            ActiveMogura(Mogura[MoguraNumber], MoguraCollider[MoguraNumber]);

            MoguraNumber = 6;
        }
    }

    void AddScore()
    {
        GameScore += 1;
        scoreText.text = "Score:" + GameScore;
    }

    void PutMoguraOnFloor(GameObject mogura)
    {
        Vector3 fwd = mogura.transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(mogura.transform.position, fwd, out hit, 10))
        {
            Vector3 FloorHeight = mogura.transform.position;

            FloorHeight.y = hit.transform.position.y;

            mogura.transform.position = FloorHeight; 
        }
    }


    void EndMainScene()
    {
        MainScene.SetActive(false);
        ResultScene.SetActive(true);
    }

 
}
