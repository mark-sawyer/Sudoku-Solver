using UnityEngine;

public class Mouse : MonoBehaviour {
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D ray = Physics2D.Raycast(mousePos, Vector2.zero);
            Collider2D collider = ray.collider;
            if (collider != null) {
                GameObject clickedGameObject = collider.gameObject;
                clickedGameObject.GetComponent<IClickable>().clicked();
            } else {
                GameEvents.nothingClicked.Invoke();
            }
        }
    }
}
