using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History_Texts : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] speechTxt;

    private HistoryControl hc;
    bool started = false;

    void Start()
    {
        hc = FindObjectOfType<HistoryControl>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !started)
        {
            started = true;
            hc.Speech(speechTxt);
        }
    }
}
