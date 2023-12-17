using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public TMP_Text overheatedMessage;
    public Slider weaponTempSlider;

    private void Awake()
    {
        Instance = this;
    }
}