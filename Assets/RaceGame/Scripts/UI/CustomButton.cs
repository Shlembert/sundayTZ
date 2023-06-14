using UnityEngine.UI;

public class CustomButton : Button
{
    public bool ButtonIsPressed { get { return base.IsPressed(); } }
}
