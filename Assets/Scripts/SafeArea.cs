using UnityEngine;
[RequireComponent(typeof(RectTransform))]

public class SafeArea : MonoBehaviour

{
    RectTransform panel;
    Rect lastSafeArea = new Rect(0, 0, 0, 0);

    void Awake() { panel = GetComponent<RectTransform>(); ApplySafeArea(); }
    void OnRectTransformDimensionsChange() { ApplySafeArea(); }

    void ApplySafeArea()
    {
        Rect sa = Screen.safeArea;
        if (sa == lastSafeArea) return;
        lastSafeArea = sa;

        Vector2 anchorMin = sa.position;
        Vector2 anchorMax = sa.position + sa.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;
    }
}

