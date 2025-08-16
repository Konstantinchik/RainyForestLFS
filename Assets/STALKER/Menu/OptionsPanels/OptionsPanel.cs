using UnityEngine;
using static GameManager;

public class OptionsPanel : MonoBehaviour
{
    [Header("������ ��������")]
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject videoTab;
    [SerializeField] private GameObject soundTab;
    [SerializeField] private GameObject gameTab;
    [SerializeField] private GameObject controlTab;



    private void OnEnable()
    {
        // ��� ��������� OptionsPanel ���������� VideoTab �� ���������
        ShowVideoTab();
    }

    // ������ ��� ������������ ����� ��������
    #region [SHOW TABS]
    public void ShowVideoTab()
    {
        SetAllTabsInactive();
        videoTab.SetActive(true);
    }

    public void ShowSoundTab()
    {
        SetAllTabsInactive();
        soundTab.SetActive(true);
    }

    public void ShowGameTab()
    {
        SetAllTabsInactive();
        gameTab.SetActive(true);
    }

    public void ShowControlTab()
    {
        SetAllTabsInactive();
        controlTab.SetActive(true);
    }

    private void SetAllTabsInactive()
    {
        videoTab.SetActive(false);
        soundTab.SetActive(false);
        gameTab.SetActive(false);
        controlTab.SetActive(false);
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsPanel.SetActive(false);
            GameManager.Instance.MainMenu = true;
        }
    }

    private void UpdateButtonStates(GameObject activeButton)
    {
        // ����� ����� �������� ������ ��������� ��������� ������,
        // ��������, ������ ���� ��� ����������� ��������/���������� ������

        // ������ (���� � ������ ���� ��������� Image):
        // ResetAllButtons();
        // activeButton.GetComponent<Image>().color = activeColor;
    }

    private void ResetAllButtons()
    {
        // ����� ��������� ���� ������
        // ��������:
        // videoButton.GetComponent<Image>().color = normalColor;
        // soundButton.GetComponent<Image>().color = normalColor;
        // gameButton.GetComponent<Image>().color = normalColor;
        // controlButton.GetComponent<Image>().color = normalColor;
    }
}
