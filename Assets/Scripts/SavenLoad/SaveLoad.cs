using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveLoad : MonoBehaviour
{
    [SerializeField] private GameObject picker;
    [SerializeField] private GameObject collectablePrefab;
    
    void SavePosition()
    {
        PickerData pickerData = new PickerData();
        pickerData.x = picker.transform.position.x;
        pickerData.y = picker.transform.position.y;
        pickerData.z = picker.transform.position.z;
        pickerData.cameraOffset = picker.GetComponent<CameraMovement>().GetCameraOffset();
        pickerData.collectables = new List<CollectableData>();
        foreach (var collectable in picker.GetComponent<PickerPhysics>().GetCollectables())
        {
            CollectableData collectableData = new CollectableData();
            collectableData.x = collectable.transform.position.x;
            collectableData.y = collectable.transform.position.y;
            collectableData.z = collectable.transform.position.z;

            pickerData.collectables.Add(collectableData);
        }
        string json = JsonUtility.ToJson(pickerData);
        File.WriteAllText(Application.persistentDataPath + "/pickerData.json", json);
    }
    void LoadPosition()
    {
        string path = Application.persistentDataPath + "/pickerData.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PickerData pickerData = JsonUtility.FromJson<PickerData>(json);
            picker.transform.position = new Vector3(pickerData.x, pickerData.y, pickerData.z);
            picker.GetComponent<CameraMovement>().SetCameraOffset(pickerData.cameraOffset.x, pickerData.cameraOffset.y, pickerData.cameraOffset.z);
            Camera.main.transform.position = picker.transform.position + pickerData.cameraOffset;
            PickerPhysics pickerPhysics = picker.GetComponent<PickerPhysics>();
            pickerPhysics.Clear(); // Clear existing collectables
            foreach (var collectableData in pickerData.collectables)
            {
                Vector3 position = new Vector3(collectableData.x, collectableData.y, collectableData.z);
                GameObject newCollectable = Instantiate(collectablePrefab, position, Quaternion.identity); // Assuming collectablePrefab is the prefab for the collectable objects
                pickerPhysics.AddCollectable(newCollectable.GetComponent<Collectable>());
            }
        }
        else if(!File.Exists(path))
        {
            PickerData pickerData = new PickerData();
            pickerData.x = 0f;
            pickerData.y = 0.485f;
            pickerData.z = -56.2f;
            picker.transform.position = new Vector3(pickerData.x, pickerData.y, pickerData.z);           
        }
        
    }
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // App is going to background, save picker's position
            SavePosition();
        }
    }
    private void OnApplicationQuit()
    {
        SavePosition();
    }
    void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
        {
            // App is resuming, load picker's position
            LoadPosition();
        }
    }
}
[System.Serializable]
public class PickerData
{
    public float x;
    public float y;
    public float z;
    public Vector3 cameraOffset;
    public List<CollectableData> collectables;
}
[System.Serializable]
public class CollectableData
{
    public float x;
    public float y;
    public float z;
}
