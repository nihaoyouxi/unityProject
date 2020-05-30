using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Fungus;
using UnityEngine.SceneManagement;

public class SettingPanel : MonoBehaviour
{

    [SerializeField]
    private Toggle[] languageToggles;
    private bool startGame = false;
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Flowchart flowChart;

    // Start is called before the first frame update
    void Start()
    {
        if (languageToggles.Length>0) {
            languageToggles[0].Select();
        }
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (startGame) {
            Hide();
            if (flowChart==null) {
                return;
            }
            flowChart.ExecuteBlock("Start");
        }
    }

    public void OnLanguageChange(Toggle toggle) {
        if (toggle.isOn) {
            string toggleName = toggle.gameObject.name;
            switch (toggleName) {
                case "LanguageToggle_C":
                    GameData.currentLanguage = 0;
                    startGame = true;
                    break;
                case "LanguageToggle_E":
                    GameData.currentLanguage = 1;
                    startGame = true;
                    break;
                case "LanguageToggle_P":
                    GameData.currentLanguage = 2;
                    startGame = true;
                    break;
                default:
                    break;
            }
            flowChart.SetIntegerVariable("LanguageType", GameData.currentLanguage);
            Debug.Log("GameData.currentLanguage:"+ GameData.currentLanguage);
        }
    }

    private void Hide() {
        canvasGroup.alpha = 1;
        startGame = false;
        canvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

}
