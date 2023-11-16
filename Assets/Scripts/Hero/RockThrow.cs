using UnityEngine;

namespace Hero
{
    public class RockThrow : MonoBehaviour
    {
        public float speed = 100;
        public float gravity = 9.8f;
        public float timeToLive = 5;

        private Vector3 startPosition;
        private Vector3 startVelocity;

        private void Start()
        {
            startPosition = transform.position;
        }

        private void OnTouchBegin(Touch touch)
        {
            // Получаем позицию точки броска.
            Vector3 endPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Рассчитываем начальную скорость.
            startVelocity = (endPosition - startPosition) * speed;

            // Отрисовываем линию от точки броска до текущего положения камня.
            Debug.DrawLine(startPosition, endPosition, Color.green);
        }

        private void OnTouchEnd(Touch touch)
        {
            // Запускаем движение камня.
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = startVelocity;
        }

        private void Update()
        {
            // Уменьшаем время жизни.
            timeToLive -= Time.deltaTime;

            // Если время жизни истекло, то удаляем камень.
            if (timeToLive <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}