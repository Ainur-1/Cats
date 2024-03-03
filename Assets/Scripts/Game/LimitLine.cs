using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLine : MonoBehaviour
{
    private bool isColliding = false;
    private float collisionStartTime;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float gameOverTime = 3f;

    // Добавим список объектов, которые будут моргать
    [SerializeField] private List<GameObject> blinkingObjects = new List<GameObject>();
    private bool isBlinking = false;
    private Coroutine blinkCoroutine;

    private void Update()
    {
        if (!gameManager.isPaused && isColliding && Time.time - collisionStartTime >= gameOverTime)
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
        collisionStartTime = Time.time;

        // Начинаем моргать, только если еще не начали
        if (!isBlinking)
        {
            isBlinking = true;
            blinkCoroutine = StartCoroutine(BlinkObjects());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
        collisionStartTime = 0;

        // Останавливаем моргание при выходе из триггера
        if (isBlinking)
        {
            isBlinking = false;
            StopCoroutine(blinkCoroutine);
            // Восстанавливаем видимость объектов после моргания
            foreach (GameObject obj in blinkingObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    private IEnumerator BlinkObjects()
    {
        while (true)
        {
            // Переключаем видимость объектов в списке моргающих
            foreach (GameObject obj in blinkingObjects)
            {
                obj.SetActive(!obj.activeSelf);
            }
            // Ждем некоторое время перед следующим переключением
            yield return new WaitForSeconds(0.5f); // Можно регулировать скорость моргания здесь
        }
    }
}
