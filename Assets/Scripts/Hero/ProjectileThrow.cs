using UnityEngine;

namespace Hero
{
    public class ProjectileThrow : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer; 
        [SerializeField] private Transform startPoint;
        [SerializeField] private float maxHeight = 2f; 
        [SerializeField] private float maxDistance = 10f; 
        [SerializeField] private float throwForce = 1f;
        private bool isThrowing = false;
        private float throwTime = 0f;

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && !isThrowing)
            {
                StartThrow();
            }

            if (Input.GetKey(KeyCode.F) && isThrowing)
            {
                throwTime += Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.F) && isThrowing)
            {
                EndThrow();
            }
        }

        private void StartThrow()
        {
            isThrowing = true;
            throwTime = 0f;

            // Отображение траектории
            int numPoints = 15; // Количество точек траектории для визуализации
            lineRenderer.positionCount = numPoints + 1;
            Vector3[] positions = new Vector3[numPoints + 1];

            float timeInterval = maxDistance / (numPoints - 1) / throwForce;
            positions[0] = startPoint.position;

            for (int i = 1; i <= numPoints; i++)
            {
                float t = i * timeInterval;
                float x = startPoint.position.x + (maxDistance * t);
                float y = startPoint.position.y + ParabolicHeight(t);
                float z = startPoint.position.z;
                positions[i] = new Vector3(x, y, z);
            }

            lineRenderer.SetPositions(positions);
        }

        private void EndThrow()
        {
            isThrowing = false;
            throwForce = throwTime;
            throwTime = 0f;
            lineRenderer.positionCount = 0;

            // Выполнение броска
            Vector3 throwDirection = transform.forward;
            float throwDistance = maxDistance * throwForce;
            float throwHeight = maxHeight * throwForce;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = throwDirection * throwDistance;
            rb.simulated = true;
        }

        private float ParabolicHeight(float time)
        {
            float baseHeight = (4 * maxHeight) / (maxDistance * maxDistance);
            float heightOffset = maxHeight - baseHeight * maxDistance * maxDistance;
            return baseHeight * time * time - baseHeight * maxDistance * maxDistance + heightOffset;
        }
    }
}