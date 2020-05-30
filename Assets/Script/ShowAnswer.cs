using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class ShowAnswer : MonoBehaviour
{

    [SerializeField]
    private Flowchart flowhart;
    [SerializeField]
    private Text answerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flowhart.GetStringVariable("CurrentAnswer") != "Z")
        {
            answerText.text = "正确答案：" + flowhart.GetStringVariable("CorrectAnswer");
        }
        else {
            answerText.text = "";
        }
    }

}
