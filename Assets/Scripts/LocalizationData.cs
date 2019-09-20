[System.Serializable] //Para que tenha acesso as pastas do projeto
public class LocalizationData
{

    public LocalizationItem[] items;
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}

