using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class StartScene : MonoBehaviour
{

    [SerializeField]
    private Flowchart f;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("f.BlockViewHeight" + f.BlockViewHeight);
        f. += 1000;
        Debug.Log("f.BlockViewHeight" + f.BlockViewHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayUrgent()
    {
        EventCenter.Boardcast(GameEventType.PlayUrgent);
    }

    public void LoadFlagScene() {
        Debug.Log("LoadFlagScene");
        SceneManager.LoadScene("Flag");
    }

}
