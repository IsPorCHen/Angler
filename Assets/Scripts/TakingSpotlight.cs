using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingSpotlight : MonoBehaviour
{
    [SerializeField] private GameObject player; // Ссылка на игрока
    private bool isFollowing = false;
    private bool playerInRange = false;

    private Vector3 offset; // Смещение для сохранения относительного положения прожектора

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            isFollowing = !isFollowing; // Переключаем состояние следования

            if (isFollowing)
            {
                // Сохраняем текущее смещение прожектора относительно игрока
                offset = transform.position - player.transform.position;
            }
        }

        if (isFollowing && player != null)
        {
            // Обновляем позицию прожектора относительно игрока с учетом смещения
            transform.position = player.transform.position + offset;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject; // Сохраняем ссылку на игрока при входе в зону света
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false; // Устанавливаем, что игрок вышел из зоны света
        }
    }
}
