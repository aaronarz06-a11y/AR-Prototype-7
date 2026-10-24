using UnityEngine;
using UnityEngine.UI;

public class Fallingnotes : MonoBehaviour
{
    public float fallSpeed = 200f;
    public Image pianoKey;
    private KeyCode correctKey;
    private bool finished = false;

    void Start()
    {
        if (pianoKey == null)
        {
            finished = true;
            return;
        }

        if (pianoKey.name == "Key A")
        correctKey = KeyCode.A;
        else if (pianoKey.name == "Key S")
        correctKey = KeyCode.S;
        else if (pianoKey.name == "Key D")
        correctKey = KeyCode.D;
        else if (pianoKey.name == "Key F")
        correctKey = KeyCode.F;
        else
        {
            finished = true;
        }
    }

    void Update()
    {
        if (finished)
            return;

        RectTransform note = GetComponent<RectTransform>();
        RectTransform key = pianoKey.GetComponent<RectTransform>();

        note.anchoredPosition -= new Vector2(0, fallSpeed * Time.deltaTime);

        float noteBottom = note.position.y - note.rect.height / 2f;
        float keyTop = key.position.y + key.rect.height / 2f;
        float keyMiddle = key.position.y;
        bool inHitArea = noteBottom <= keyTop && noteBottom >= keyMiddle;

        if (inHitArea && Input.GetKey(correctKey))
        {
            finished = true;
            Destroy(gameObject);
            return;
        }

        if (noteBottom < keyMiddle)
        {
            finished = true;
            pianoKey.color = Color.red;
            Destroy(gameObject);
        }
    }
}