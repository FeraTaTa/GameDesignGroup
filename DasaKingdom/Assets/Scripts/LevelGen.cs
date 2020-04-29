using UnityEditor;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public int width;
    public int length;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public string mapName;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for(int x = 0; x< width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                GenerateTile(x,z);
            }
        }
        if (mapName != string.Empty)
        {
            PrefabUtility.SaveAsPrefabAsset(gameObject, "Assets/Prefabs/MapGens/"+mapName+".prefab");

        }
    }

    private void GenerateTile(int x, int z)
    {
        int tileChoice = Random.Range(0, 3);
        Vector3 position = new Vector3(3*x, 0, 3*z);
        int rotation = 90 * Random.Range(0, 4);
        
        GameObject obj;
        switch (tileChoice)
        {
            case 0:
                //Instantiate(tile1, position, Quaternion.identity, transform);
                obj = PrefabUtility.InstantiatePrefab(tile1, transform) as GameObject;
                obj.transform.SetPositionAndRotation(position, Quaternion.Euler(0.0f, rotation, 0.0f));
                break;

            case 1:
                obj = PrefabUtility.InstantiatePrefab(tile2, transform) as GameObject;
                obj.transform.SetPositionAndRotation(position, Quaternion.Euler(0.0f, rotation, 0.0f));
                break;

            case 2:
                obj = PrefabUtility.InstantiatePrefab(tile3, transform) as GameObject;
                obj.transform.SetPositionAndRotation(position, Quaternion.Euler(0.0f, rotation, 0.0f));
                break;

        }

    }
}
