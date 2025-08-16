using UnityEngine;
using UnityEngine.UI;

// ����� ���� ������������� ������ ������� ��������� � dropdown �����
// sorting order � Canvas ���������� 32767 - ��� ����

public class AnimatedCursor : MonoBehaviour
{
    [SerializeField]
    private Sprite[] cursorFrames;
    public float frameRate = 10f;

    private Image cursorImage;
    private int currentFrame;
    private float timer;

    // ���� ������ ��������� ��������
    private Vector2 offset = new Vector2(28, -30); // �������� ������ � ����

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined; // ��� Locked, ���� ����� ������ ����
    }

    void Start()
    {
        Cursor.visible = false;
        cursorImage = GetComponent<Image>();
        if (cursorFrames.Length > 0)
            cursorImage.sprite = cursorFrames[0];
    }

    void Update()
    {

        transform.position = Input.mousePosition + (Vector3)offset;

        if (cursorFrames == null || cursorFrames.Length == 0)
            return;

        // ���������� unscaledDeltaTime, ����� �������� ��� Time.timeScale = 0
        timer += Time.unscaledDeltaTime;

        if (timer >= 1f / frameRate)
        {

            currentFrame = (currentFrame + 1) % cursorFrames.Length;
            if (currentFrame >= 7) currentFrame = 0;
            cursorImage.sprite = cursorFrames[currentFrame];
            timer = 0f;
        }
    }
}
