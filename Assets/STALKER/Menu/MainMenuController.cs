using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu References")]
    [SerializeField] private Button newGameButton;      // ��� ������ �������
    [SerializeField] private Button resumeButton;       // ��� ������ �������
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button saveGameButton;
    [SerializeField] private Button lastSaveButton;     // ��������� ��������� ����������?
    [SerializeField] private Button leaveGameButton;    // ������� �������� ����?
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    [Header("Exit Menu References")]
    [SerializeField] private Button confirmExitButton;
    [SerializeField] private Button cancelExitButton;

    [Header("Settings firstLevelName")]
    [SerializeField] private string firstLevelName; // = "Test1"; // ����� �� GameManager

    private void Awake()
    {
        // ������������� ������
        newGameButton.onClick.AddListener(StartNewGame);

        resumeButton.onClick.AddListener(ResumeGame);

        loadGameButton.onClick.AddListener(ShowLoadGame);

        saveGameButton.onClick.AddListener(ShowSaveGame);

        lastSaveButton.onClick.AddListener(ShowLastSavedGame);

        leaveGameButton.onClick.AddListener(ShowLeaveGame);     // ����������� ������: ������� ���� ���� PlayMode = GamePlay || GamePause

        optionsButton.onClick.AddListener(ShowOptions);         // ��������� ������ ��������

        creditsButton.onClick.AddListener(ShowCredits);

        exitButton.onClick.AddListener(ShowExitConfirm);        // ����������� ������ ������������� ������
        cancelExitButton.onClick.AddListener(HideExitConfirm);  // ������ ������������� �����������
        confirmExitButton.onClick.AddListener(ExitGame);        // �������� ����������

        //optionsBackButton.onClick.AddListener(HideOptions);
    }

    private void OnEnable()
    {
        Debug.LogError("MainMenu Enabled");

        // ��������� ����������� ������ �����������
        if (GameManager.Instance.CurrentState == GameManager.GameState.MainMenu)
            resumeButton.interactable = false;
        else
            resumeButton.interactable = true;

        // ��������� ����������� ������ ��������� ����
        if (GameManager.Instance.CurrentState == GameManager.GameState.MainMenu)
            leaveGameButton.interactable = false;
        else
            leaveGameButton.interactable = true;
    }

    private void OnDisable()
    {
        Debug.LogError("MainMenu Disabled");
    }

    private void Start()
    {
        firstLevelName = GameManager.Instance.GetFirstGameSceneName;
    }

    #region [Start New Game]
    private void StartNewGame()
    {
        // ���� ���� ��� � ��������, ���� �������� �������� �� �� �������� ������������� ������
        if(GameManager.Instance.CurrentState != GameManager.GameState.MainMenu)
        {
            UIManager.Instance.ShowConfirmLostUnsavedGameMenu();
        }
        else
        // ��������� ����� ����� GameManager
        GameManager.Instance.LoadGameScene(firstLevelName);
    }
    #endregion


    #region [Resume Game]
    private void ResumeGame()
    {
        GameManager.Instance.ReturnToGame();
    }
    #endregion

    #region [Load Game UI Panel]
    private void ShowLoadGame()
    {
        UIManager.Instance.ShowLoadGameMenu();
    }
    private void HideLoadGame()
    {
        UIManager.Instance.HideLoadGameMenu();
    }
    #endregion

    #region [Save Game UI Panel]
    private void ShowSaveGame()
    {
        UIManager.Instance.ShowSaveGameMenu();
    }
    private void HideSaveGame()
    {
        UIManager.Instance.HideSaveGameMenu();
    }
    #endregion

    #region [Last Saved Game UI Panel]
    private void ShowLastSavedGame()
    {
        //UIManager.Instance.ShowSaveGameMenu();
    }
    private void HideLastSavedGame()
    {
        UIManager.Instance.ShowSaveGameMenu();
    }
    #endregion

    #region [Leave Game UI Panel]
    private void ShowLeaveGame()
    {
        UIManager.Instance.ShowLeaveGameMenu();
    }
    private void HideLeaveGame()
    {
        UIManager.Instance.HideLeaveGameMenu();
    }
    #endregion

    #region [Options UI Panel]
    private void ShowOptions()
    {
        UIManager.Instance.ShowOptionsMenu();
    }

    private void HideOptions()
    {
        UIManager.Instance.HideOptionsMenu();
    }
    #endregion

    #region [Creditss UI Panel]
    private void ShowCredits()
    {
        UIManager.Instance.ShowCreditsMenu();
    }

    private void HideCredits()
    {
        UIManager.Instance.HideCreditsMenu();
    }
    #endregion

    #region [Exit Confirm UI Panel]
    private void ShowExitConfirm()
    {
        UIManager.Instance.ShowExitMenu();
    }

    private void HideExitConfirm()
    {
        UIManager.Instance.HideExitMenu();
    }
    #endregion

    #region [ExitGame - action]
    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ����� ��������� ... � ����� � ���
        Application.Quit();
#endif
    }
    #endregion
}