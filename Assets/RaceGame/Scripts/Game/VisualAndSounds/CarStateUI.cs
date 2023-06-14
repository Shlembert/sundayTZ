using TMPro;
using UnityEngine;

public class CarStateUI : MonoBehaviour
{

    [SerializeField] int UpdateFrameCount = 3;
    [SerializeField] TextMeshProUGUI SpeedText;
    [SerializeField] TextMeshProUGUI CurrentGearText;

    [SerializeField] RectTransform TahometerArrow;
    [SerializeField] float MinArrowAngle = 0;
    [SerializeField] float MaxArrowAngle = -315f;

    int CurrentFrame;
    CarController SelectedCar { get { return GameController.PlayerCar; } }

    private void Update()
    {

        if (CurrentFrame >= UpdateFrameCount)
        {
            UpdateGamePanel();
            CurrentFrame = 0;
        }
        else
        {
            CurrentFrame++;
        }

        UpdateArrow();
    }

    public void UpdateArrow()
    {
        var procent = SelectedCar.EngineRPM / SelectedCar.GetMaxRPM;
        var angle = (MaxArrowAngle - MinArrowAngle) * procent + MinArrowAngle;
        TahometerArrow.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void UpdateGamePanel()
    {
        SpeedText.text = SelectedCar.SpeedInHour.ToString("000");
        CurrentGearText.text = SelectedCar.CurrentGear.ToString();
    }
}
