using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeLoader : MonoBehaviour
{
    [SerializeField] private DialogPlayer _dialogPlayer;
    [SerializeField] private string _fileTitle;
    [SerializeField] private string _colorsFileTitle;

    private void Awake()
    {
        TextAsset mytxtData = (TextAsset)Resources.Load(_colorsFileTitle);
        Dictionary<string, byte[]> colorsNumber = JsonConvert.DeserializeObject<Dictionary<string, byte[]>>(mytxtData.text);
        
        Dictionary<string, Color32> colors = new Dictionary<string, Color32>();
        foreach (var item in colorsNumber)
        {
            colors.Add(item.Key, new Color32(item.Value[0], item.Value[1], item.Value[2],255));
        }

        mytxtData = (TextAsset)Resources.Load(_fileTitle);
        Queue<Dialog> dialogs = JsonConvert.DeserializeObject<Queue<Dialog>>(mytxtData.text);
        _dialogPlayer.SetDialogs(dialogs, colors);
    }
}
