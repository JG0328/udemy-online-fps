using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public TMP_Text overheatedMessage;

    private void Awake()
    {
        Instance = this;
    }
}
