using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLine : MonoBehaviour
{
    private bool isColliding = false;
    private float collisionStartTime;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float gameOverTime = 3f;

    // ������� ������ ��������, ������� ����� �������
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

        // �������� �������, ������ ���� ��� �� ������
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

        // ������������� �������� ��� ������ �� ��������
        if (isBlinking)
        {
            isBlinking = false;
            StopCoroutine(blinkCoroutine);
            // ��������������� ��������� �������� ����� ��������
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
            // ����������� ��������� �������� � ������ ���������
            foreach (GameObject obj in blinkingObjects)
            {
                obj.SetActive(!obj.activeSelf);
            }
            // ���� ��������� ����� ����� ��������� �������������
            yield return new WaitForSeconds(0.5f); // ����� ������������ �������� �������� �����
        }
    }
}
