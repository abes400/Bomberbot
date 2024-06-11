using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OSDControl : MonoBehaviour
{
     TextMeshProUGUI OSDText;

    // Start is called before the first frame update
    void Start()
    {
        OSDText = GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("OSD"));
    }

    public void LateUpdate()
    {
        OSDText.text = String.Format("{0}\t       {1}\n{2}\t       {3}",
                                      GameManager.life,
                                      GameManager.crateCount,
                                      GameManager.roombaCount,
                                      GameManager.score);
    }
}
