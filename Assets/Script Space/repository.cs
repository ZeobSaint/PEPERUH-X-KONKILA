using System.Collections.Generic;
using UnityEngine;

public class repository : MonoBehaviour
{
    public static repository repositoryInScene = null;
    private List<GameObject> objectsList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        repositoryInScene = this;
    }

    private void OnDestroy()
    {
        repositoryInScene = null;
    }

    public GameObject GetObject(GameObject objectGet)
    {
        GameObject objX = objectsList.Find(x => objectGet.name == x.name && !x.activeInHierarchy);

        if (!objX)
        {
            for(int i=0; i < 8; i++)
            {
                objX = Instantiate(objectGet);
                objX.name = objectGet.name;
                objX.transform.SetParent(transform);
                objX.SetActive(false);
                objectsList.Add(objX);
            }          
        }

        return objX;
    }

    public void AddObject(GameObject objectSet, int howMany)
    {
        if (!objectsList.Exists(x => x.name == objectSet.name))
        {
            for (int i = 0; i < howMany; i++)
            {
                GameObject objX = Instantiate(objectSet);
                objX.name = objectSet.name;
                objX.transform.SetParent(transform);
                objX.SetActive(false);
                objectsList.Add(objX);
            }
        }
    }
}
