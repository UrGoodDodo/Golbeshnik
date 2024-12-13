using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQTE2 : MonoBehaviour
{

    public GameObject point;
    public GameObject QTEBar;
    public GameObject QTEBarEasy;
    public GameObject QTEBarMedium;
    private RectTransform pointRect;
    [SerializeField] float pointSpeed = 250f;
    private List<GameObject> zoneObjects = new List<GameObject>();
    private List<float> zonePoints = new List<float>();
    private string currentZone = "positive";
    private int currentZoneIndex = 0;
    private bool passZone = true;
    private bool doubleClick = false;
    private int passCount = 0;
    private int mistakeCount = 0;
    private SoundManager _soundManager;
    private MindController _mindController;
    private CanvasGroup canvasGroup;
    [SerializeField] bool visibleBar = true;

    void Start()
    {
        List<GameObject> difficultBars = new List<GameObject>() { QTEBarEasy, QTEBarMedium };
        int k = Random.Range(0, 2);
        for (int i = 0; i < 2; i++)
        {
            if (i != k)
            {
                difficultBars[i].GetComponent<CanvasGroup>().alpha = 0;
            }
        }
        pointRect = point.GetComponent<RectTransform>();
        foreach (Transform child in difficultBars[k].GetComponentsInChildren<Transform>())
        {
            if (child.gameObject == difficultBars[k])
            {
                continue;
            }
            zoneObjects.Add(child.gameObject);
            zonePoints.Add(child.gameObject.GetComponent<RectTransform>().sizeDelta.x / 2 + child.gameObject.GetComponent<RectTransform>().anchoredPosition.x);
        }
        _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        _mindController = GameObject.FindWithTag("MindController").GetComponent<MindController>();
        canvasGroup = QTEBar.GetComponent<CanvasGroup>();
        if (!visibleBar)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        _soundManager.Play("HeartPulsBreath");
        PlayHearthBeat();
    }
    void Update()
    {
        if (pointRect.anchoredPosition.x <= zonePoints[zonePoints.Count - 1])
        {
            pointRect.anchoredPosition = new Vector3(pointRect.anchoredPosition.x + pointSpeed * Time.deltaTime, pointRect.anchoredPosition.y, 0);
        }
        if (currentZoneIndex < zonePoints.Count && pointRect.anchoredPosition.x >= zonePoints[currentZoneIndex])
        {
            CheckZoneOnPass();
            currentZoneIndex += 1;
            if (currentZoneIndex == zonePoints.Count) { StopEvent(); }
            if (currentZone == "positive") 
            { 
                currentZone = "negative";
                passZone = true;
            }
            else 
            {
                currentZone = "positive";
                passZone = false;
                PlayHearthBeat();
            }
            doubleClick = false;
        }
        if (Input.GetButtonDown("CKey") || Input.GetButtonDown("VKey") || Input.GetButtonDown("UKey"))
        {
            if (currentZone == "negative")
            {
                passZone = false;
            }
            else
            {
                if (passZone == false)
                {
                    passZone = true;
                }
                else
                {
                    doubleClick = true;
                }
            }
        }
    }
    void PlayHearthBeat()
    {
        int k = Random.Range(1, 4);
        _soundManager.Play($"HearthBeat{k}");
        _mindController.HearthPuls();
        
    }
    void CheckZoneOnPass()
    {
        if (passZone && !doubleClick && currentZone == "positive")
        {
            passCount++;
        }
        else if (!passZone && currentZone == "negative")
        {
            mistakeCount++;
        }
    }
    void StopEvent()
    {
        if ((int)(zonePoints.Count / 2) + 1 - passCount + mistakeCount <= 2)
        {
            _mindController.IncreaseMindStatus(4);
            _mindController.StopQTE();
        }
        else
        {
            Debug.Log("GAME OVER");
            _mindController.StopQTE();
        }
        _soundManager.Stop("HeartPulsBreath");
        Destroy(gameObject);
    }
}

