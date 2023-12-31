using UnityEngine;
using Photon.Pun;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner Instance;

    public GameObject playerPrefab;
    private GameObject player;

    public GameObject deathEffect;

    public float respawnTime = 5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        Transform spawnPoint = SpawnManager.Instance.GetSpawnPoint();

        player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }

    public void Die(string damager)
    {
        UIController.Instance.deathText.text = "You were killed by " + damager;

        MatchManager.Instance.UpdateStatsSend(PhotonNetwork.LocalPlayer.ActorNumber, 1, 1);

        if (player != null)
        {
            StartCoroutine(DieCo());
        }
    }

    public IEnumerator DieCo()
    {
        PhotonNetwork.Instantiate(deathEffect.name, player.transform.position, Quaternion.identity);

        PhotonNetwork.Destroy(player);
        player = null;
        UIController.Instance.deathScreen.SetActive(true);

        yield return new WaitForSeconds(respawnTime);

        UIController.Instance.deathScreen.SetActive(false);

        if (MatchManager.Instance.state == MatchManager.GameState.Playing && player == null)
        {
            SpawnPlayer();
        }
    }
}
