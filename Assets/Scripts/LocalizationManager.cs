using System.Collections.Generic;
using UnityEngine;
using System.IO; //para conseguir acessar as pastas do projeto

public class LocalizationManager : MonoBehaviour {

    public static LocalizationManager instance;
    private Dictionary<string, string> localizedText;
    private bool isReady = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        { 
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
                Debug.Log(loadedData.items[i].key + ", " + loadedData.items[i].value);
            }
            Debug.Log("Dicionário contém " + localizedText.Count + " entradas");
        }
        else
        {
            Debug.Log("Arquivo não encontrado");
        }

        isReady = true;
    }

    public bool GetIsReady()
    {
        return isReady;
    }

    public string GetLocalizedValue(string key)
    {
        string result = "Text not found";
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }
}
