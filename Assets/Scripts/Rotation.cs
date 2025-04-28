using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float bobbingSpeed = 2f;
    [SerializeField] private float bobbingHeight = 0.2f;

    private float startingHeight;
    private float time;

    void Start()
    {
        startingHeight = transform.position.y;
    }

    void Update()
    {
        // Rotate around Y axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        PerformBobbingEffect();
    }

    private void PerformBobbingEffect()
    {
        // Bobbing movement up and down using sine wave
        time += Time.deltaTime;
        float newY = startingHeight + Mathf.Sin(time * bobbingSpeed) * bobbingHeight;
        Vector3 newPosition = transform.position;
        newPosition.y = newY;
        transform.position = newPosition;
    }
}
