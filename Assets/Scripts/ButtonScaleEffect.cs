using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffects : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string audioObjectName = "ButtonSound"; // ім'я об'єкта зі звуком
    public float scaleFactor = 1.1f;
    public float animationSpeed = 8f;

    private Vector3 originalScale;
    private bool isPressed = false;
    private static AudioSource sharedAudioSource;

    void Awake()
    {
        // знайти спільний звук лише один раз
        if (sharedAudioSource == null)
        {
            GameObject soundObj = GameObject.Find(audioObjectName);
            if (soundObj != null)
                sharedAudioSource = soundObj.GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        Vector3 targetScale = isPressed ? originalScale * scaleFactor : originalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * animationSpeed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        if (sharedAudioSource != null)
            sharedAudioSource.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
