using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpwanControl : MonoBehaviour
{
    public List<GameObject> prefabsList;
    public int createNum;
    public float CreateTime;
    public Slider PropSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CreateTime<=0)
        {
            //创建
            CreatePrefabs();
            CreateTime = 10;
        }
        else
        {
            PropSlider.value = CreateTime-5;
            CreateTime -= Time.deltaTime;
        }
    }

    public void CreatePrefabs()
    {
        for (int i = 0; i < createNum; i++)
        {
            float x = Random.Range(0.2f, 2.3f);
            float z = Random.Range(0.2f, 2.3f);
            int index = Random.Range(0, prefabsList.Count);
            GameObject go = Instantiate(prefabsList[index]);
            go.transform.position = new Vector3(x, 0.3f, z);
        }
    }
    
}
