using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private int[] sequeueArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    [SerializeField]
    private Localization lo;
    [SerializeField]
    private Flowchart fchart;

    private void Start()
    {
        fchart.SetIntegerVariable("LanguageType", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //QueSqueueManager.RandomSequeue(ref sequeueArr);
            //string str = "";
            //foreach (int value in sequeueArr) {
            //    str += value + "、";
            //}
            //Debug.Log(str);
            //lo.SetActiveLanguage("English",true);
        }
    }
}
