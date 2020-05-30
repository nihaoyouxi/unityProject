using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    private bool isAnswering = false;
    private Flowchart flowchart;
    private string blockName = "Question";
    private string answerName = "ShowAnswer";
    private bool hasComplete = false;

    private void Awake()
    {
        EventCenter.AddListener(GameEventType.StopAllBlock, StopAllBlock);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(GameEventType.StopAllBlock, StopAllBlock);
    }

    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        //Test:
        //int index = EventCenter.Boardcast<int>(GameEventType.GetCurrentQueIndex);
        //Debug.Log("index:" + index);
        flowchart.SetIntegerVariable("LanguageType", GameData.currentLanguage);
        Say();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnswering) {
            if (Answer()) {
                ShowAnswer();
                isAnswering = false;
            }
        }
    }

    private void StopAllBlock() {
        if (flowchart==null) {
            return;
        }
        flowchart.StopAllBlocks();
        flowchart.ExecuteBlock("GameOver");
    }

    public void EnableAnswer() {
        Debug.Log("EnableAnswer");
        isAnswering = true;
    }

    public void DisableAnswer()
    {
        Debug.Log("DisableAnswer");
        isAnswering = false;
    }

    public void Say() {
        if (flowchart==null) {
            return;
        }
        if (EventCenter.Boardcast<int>(GameEventType.GetGameProgress)>=11&&!hasComplete) {
            hasComplete = true;
            CompleteAllQuestion();
        }
        if (hasComplete) {
            return;
        }
        //Debug.Log("当前游戏进度：" + EventCenter.Boardcast<int>(GameEventType.GetGameProgress));
        string name = blockName + EventCenter.Boardcast<int>(GameEventType.GetCurrentQueIndex);
        //string name = blockName + "0";
        if (flowchart.HasBlock(name))
        {
            flowchart.ExecuteBlock(name);
        }
    }

    private void CompleteAllQuestion() {
        if (flowchart==null) {
            return;
        }
        EventCenter.Boardcast(GameEventType.PauseTimer);
        flowchart.ExecuteBlock("GameOver");
    }

    public void AddCorrectCount() {
        if (flowchart==null) {
            return;
        }
        flowchart.SetIntegerVariable("CorrectCount", (flowchart.GetIntegerVariable("CorrectCount") + 1));
    }

    public void RetrunStartScene() {
        SceneManager.LoadScene("Start");
    }

    private void ShowAnswer() {
        if (flowchart==null) {
            return;
        }
        flowchart.ExecuteBlock(answerName + EventCenter.Boardcast<int>(GameEventType.GetCurrentQueIndex));
        //flowchart.ExecuteBlock(answerName + "0");
    }

    private bool Answer() {
        if (Input.GetKeyDown(KeyCode.A)) {
            flowchart.SetStringVariable("CurrentAnswer", "A");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            flowchart.SetStringVariable("CurrentAnswer", "B");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            flowchart.SetStringVariable("CurrentAnswer", "C");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            flowchart.SetStringVariable("CurrentAnswer", "D");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            flowchart.SetStringVariable("CurrentAnswer", "E");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            flowchart.SetStringVariable("CurrentAnswer", "F");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            flowchart.SetStringVariable("CurrentAnswer", "G");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            flowchart.SetStringVariable("CurrentAnswer", "H");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            flowchart.SetStringVariable("CurrentAnswer", "I");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            flowchart.SetStringVariable("CurrentAnswer", "J");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            flowchart.SetStringVariable("CurrentAnswer", "K");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            flowchart.SetStringVariable("CurrentAnswer", "L");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            flowchart.SetStringVariable("CurrentAnswer", "M");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            flowchart.SetStringVariable("CurrentAnswer", "N");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            flowchart.SetStringVariable("CurrentAnswer", "O");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            flowchart.SetStringVariable("CurrentAnswer", "P");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            flowchart.SetStringVariable("CurrentAnswer", "Q");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            flowchart.SetStringVariable("CurrentAnswer", "R");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            flowchart.SetStringVariable("CurrentAnswer", "S");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            flowchart.SetStringVariable("CurrentAnswer", "T");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            flowchart.SetStringVariable("CurrentAnswer", "U");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            flowchart.SetStringVariable("CurrentAnswer", "V");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            flowchart.SetStringVariable("CurrentAnswer", "W");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            flowchart.SetStringVariable("CurrentAnswer", "X");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            flowchart.SetStringVariable("CurrentAnswer", "Y");
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            flowchart.SetStringVariable("CurrentAnswer", "Z");
            return true;
        }
        return false;
    }

}
