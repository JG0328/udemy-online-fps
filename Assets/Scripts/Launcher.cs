using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    public GameObject loadingScreen;
    public TMP_Text loadingText;
    public GameObject menuButtons;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CloseMenus();

        loadingScreen.SetActive(true);
        loadingText.text = "Connecting To Network...";

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

        loadingText.text = "Joining Lobby...";
    }

    public override void OnJoinedLobby()
    {
        CloseMenus();
        menuButtons.SetActive(true);
    }

    private void CloseMenus()
    {
        loadingScreen.SetActive(false);
        menuButtons.SetActive(false);
    }
}
