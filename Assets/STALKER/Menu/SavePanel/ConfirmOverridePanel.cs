using UnityEngine;

public class ConfirmOverridePanel : MonoBehaviour
{
    private System.Action<bool> callback;

    // ������������� ������ � callback
    public void Show(System.Action<bool> resultCallback)
    {
        this.callback = resultCallback;
        gameObject.SetActive(true);
    }

    // ���������� ��� ������� "Save" (�����������)
    public void OnConfirmSave()
    {
        callback?.Invoke(true);
        gameObject.SetActive(false);
    }

    // ���������� ��� ������� "Cancel" (��������)
    public void OnConfirmCancel()
    {
        callback?.Invoke(false);
        gameObject.SetActive(false);
    }
}
