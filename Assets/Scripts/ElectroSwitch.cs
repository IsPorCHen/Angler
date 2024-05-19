using UnityEngine;

public class ElectroSwitch : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Switch"))
            {
                Debug.Log("Мышка наведена на целевой объект: " + hit.collider.gameObject.name);
                if (Input.GetMouseButton(0))
                {

                    Debug.Log("Левая кнопка мыши нажата");
                }
            }
        }
    }
}
