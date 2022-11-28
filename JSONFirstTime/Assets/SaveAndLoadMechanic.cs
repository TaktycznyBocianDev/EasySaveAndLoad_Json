using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveAndLoadMechanic : MonoBehaviour
{
    [Header("To get player position")] 
    [SerializeField] GameObject player;

    [Header("Massage if there is no save game")]
    [SerializeField] GameObject noSaveScreen;

    private void Start()
    {


        
    }

    public void SaveGame()
    {
        if (!File.Exists(Application.dataPath + "/saveFile.json"))
        {
            PlayerData playerData = new PlayerData(player.transform.position, GetComponent<AddGold>().goldAmount);
            string gameSave = JsonUtility.ToJson(playerData);
            File.WriteAllText(Application.dataPath + "/saveFile.json", gameSave);
        }
        else
        {
            File.Delete(Application.dataPath + "/saveFile.json");
            SaveGame();
        }
    }

    public void LoadGame()
    {
        if (File.Exists(Application.dataPath + "/saveFile.json"))
        {
            string gameLoad = File.ReadAllText(Application.dataPath + "/saveFile.json");
            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(gameLoad);

            player.transform.position = loadedPlayerData.playerPosition;
            GetComponent<AddGold>().SetGoldAmount(loadedPlayerData.goldAmount);
        }
        else
        {
            noSaveScreen.SetActive(true);
        }
    }


}

 class PlayerData
{
    public Vector3 playerPosition;
    public int goldAmount;

    public PlayerData(Vector3 playerPosition, int goldAmount)
    {
        this.playerPosition = playerPosition;
        this.goldAmount = goldAmount;
    }
}
