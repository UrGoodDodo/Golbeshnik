using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class DefaultQTE : MonoBehaviour //TODO: переписать
{
    public GameObject displayBox;
    public GameObject passBox;
    TextMeshProUGUI displayBoxText;
    TextMeshProUGUI passBoxText;
    public int QTEGen;
    public bool passQTE = false;
    private bool mistake = false;
    private int pressCount = 5;
    private int mistakeCount = 0;
    private bool canPress = true;
    private string[] displayKeys = { "[V]", "[C]", "[U]" };
    private string[] inputKeys = { "VKey", "CKey", "UKey" };

    private void Start()
    {
        displayBoxText = displayBox.GetComponent<TextMeshProUGUI>();
        passBoxText = passBox.GetComponent<TextMeshProUGUI>();

        QTEGen = Random.Range(1, 4);
        StartCoroutine(CountDown());
        displayBoxText.text = displayKeys[QTEGen - 1];
    }
    private void Update()
    {
        if (canPress && Input.anyKeyDown)
        {
            if (Input.GetButtonDown(inputKeys[QTEGen-1]))
            {
                pressCount--;
                if (pressCount == 0)
                {
                    passQTE = true;
                }
            }
            else
            {
                mistakeCount++;
                if (mistakeCount == 2)
                {
                    mistake = true;
                }
            }
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.5f);
        canPress = false;
        if (passQTE && !mistake)
        {
            passBoxText.text = "PASS";
            yield return new WaitForSeconds(1.5f);
            passBoxText.text = "";
            displayBoxText.text = "";
        }
        else
        {
            passBoxText.text = "FAIL";
            yield return new WaitForSeconds(1.5f);
            passBoxText.text = "";
            displayBoxText.text = "";
            FailQTE();
        }
    }

    private void FailQTE()
    {
        Debug.Log("FailQTE");
    }
}


