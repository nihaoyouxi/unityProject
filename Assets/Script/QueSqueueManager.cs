using Fungus;
using UnityEngine;

public class QueSqueueManager:MonoBehaviour
{

    private int[] squeue = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    private int currentIndex;//当前问题进度的序号
    private int currentQueIndex;//当前问题的序号
    private Flowchart flowchart;

    private void Awake()
    {
        EventCenter.AddListener<int>(GameEventType.GetCurrentQueIndex, GetCurrentQueIndex);
        EventCenter.AddListener<int>(GameEventType.GetGameProgress, GetGameProgress);
        RandomSequeue(ref squeue);
        currentIndex = 0;
        flowchart = transform.Find("Flowchart").GetComponent<Flowchart>();
        SetCurrentIndex();
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<int>(GameEventType.GetCurrentQueIndex, GetCurrentQueIndex);
        EventCenter.RemoveListener<int>(GameEventType.GetGameProgress, GetGameProgress);
    }

    private void Start()
    {

    }

    public static void RandomSequeue(ref int[] sequeueArr) {
        for (int i=0;i< sequeueArr.Length;i++) {
            int index = RandomTool.GetRandomValue();
            int temp = sequeueArr[index];
            sequeueArr[index] = sequeueArr[i];
            sequeueArr[i] = temp;
        }
    }

    public void SetCurrentIndex() {
        Debug.Log("SetCurrentIndex");
        currentQueIndex = squeue[currentIndex];
        flowchart.SetIntegerVariable("QuestionIndex", currentQueIndex);
        currentIndex++;
        if (currentIndex> squeue.Length-1) {
            currentIndex = squeue.Length - 1;
            Debug.Log("已到达最大进度：" + currentIndex);
        }
    }

    private int GetCurrentQueIndex() {
        return currentQueIndex;
    }

    private int GetGameProgress() {
        return currentIndex;
    }

}
