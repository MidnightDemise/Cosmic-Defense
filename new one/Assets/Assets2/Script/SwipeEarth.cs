using UnityEngine;
using UnityEngine.Events;

public class SwipeEarth : MonoBehaviour
{
    public float rotationSpeed;
    public float pixelsToDetect;
    public float rotationLerpSpeed = 5f; // Adjust this for smoother rotation

    private bool fingerDown = false;
    private bool rotating = false;
    private Vector3 targetEuler;
    private Vector2 startpos;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    
    private float maxhealth = 5000;
    private float currentHealth;

    public HealthBar healthBar;

    //for event handling 
    LevelFailedEvent levelFailedEvent = new LevelFailedEvent();

    private void Start()
    {
        
        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
        // declaring invoker
        EventManager.AddLevelFailedEventInvoker(this);
        
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startpos = touch.position;
                fingerDown = true;
                rotating = false;
            }
            if (Input.touches[0].phase == TouchPhase.Moved && fingerDown)
            {
                float deltaX = Input.touches[0].position.x - startpos.x;

                if (!rotating && Mathf.Abs(deltaX) > pixelsToDetect)
                {
                    rotating = true;

                    // Adjust rotation direction based on the sign of deltaX
                    float rotationDirection = Mathf.Sign(deltaX);
                    targetEuler = new Vector3(0, 0, -rotationDirection * rotationSpeed);
                    targetRotation = initialRotation * Quaternion.Euler(targetEuler);
                }
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                fingerDown = false;
            }
        }

        if (rotating)
        {
            initialRotation = transform.rotation; // Update initialRotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationLerpSpeed);

            // Check if rotation has reached the target within a small threshold
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                rotating = false;
            }
        }
    }


    public void Damage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log(currentHealth);
        if (currentHealth < 0)
        {
            levelFailedEvent.Invoke();
            Destroy(gameObject);
        }
    }

    public void setHealth(float value)
    {
        maxhealth = value;
    }

    public void AddLevelFailedEventListener(UnityAction listener)
    {
        levelFailedEvent.AddListener(listener);
    }

}