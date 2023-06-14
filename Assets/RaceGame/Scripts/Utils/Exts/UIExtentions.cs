using UnityEngine.UI;

public static class UIExtentions
{
    public static void SetAlpha(this Graphic g, float newAlpha)
    {
        var color = g.color;
        color.a = newAlpha;
        g.color = color;
    }
}
