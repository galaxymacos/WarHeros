using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NurseSelectionPanel : MonoBehaviour
{
    private int currentPlayerIndexToSelect;

    public TextMeshProUGUI playerText;
    // Start is called before the first frame update
    public void Setup()
    {
        currentPlayerIndexToSelect = 1;
    }

    public void UpdatePlayerText()
    {
        playerText.text = $"{currentPlayerIndexToSelect}P";
    }

    public void Next()
    {
        if (currentPlayerIndexToSelect >= MainMenuManager.instance.playerNumber)
        {
            MainMenuManager.instance.PrintInputData();
            SaveSystem.SavePlayerNurse(MainMenuManager.instance.inputData);
            SceneManager.LoadScene(1);
        }
        else
        {
            currentPlayerIndexToSelect++;
            UpdatePlayerText();
        }
        
    }

    public void PlayerSelectRedNurse()
    {
        MainMenuManager.instance.inputData.nurseTypes.Add(NurseType.Red);
        Next();
    }

    public void PlayerSelectGreenNurse()
    {
        MainMenuManager.instance.inputData.nurseTypes.Add(NurseType.Green);
        Next();
    }
}

public static class SaveSystem
{
    public static void SavePlayerNurse(InputData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "player.fun");
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static InputData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.fun");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            InputData data = formatter.Deserialize(stream) as InputData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
