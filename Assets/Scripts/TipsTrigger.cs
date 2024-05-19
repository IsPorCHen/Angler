using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    [Header("Текст подсказки")]
    [TextArea(3, 10)]
    [SerializeField] private string message;

    private bool tipActive = true;

/*    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !tipActive)
        {
            tipActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tipActive)
        {
            tipActive = false;
        }
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) // Проверка нажатия кнопки T
        {
            if (tipActive)
            {
                TipsManager.DisplayTipEvent?.Invoke(message);
            }
            else
            {
                TipsManager.DisableTipEvent?.Invoke();
            }

            tipActive = !tipActive; // Переключение состояния
        }
    }
}
