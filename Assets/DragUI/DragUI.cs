using UnityEngine;

public class DragUI : MonoBehaviour
{
    public GameObject MainScene;

    public Vector2 offset;

    public Vector2 miniOffset;

    public void OnDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (MainScene.transform.localScale.x < 1)
        {
            MainScene.transform.position = pos + miniOffset;
        }
        else
        {
            MainScene.transform.position = pos + offset;
        }
    }
}
