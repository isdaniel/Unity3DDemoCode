using Dao;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScript : MonoBehaviour {

    public static InfoScript Instance;
    public GameObject PersonPrefab;

    public Transform PersonTable;

	// Use this for initialization
	void Start ()
    {
        Instance = this;
        Init();
    }

    public void Init()
    {
        Clear();

        PersonDao helper = new PersonDao();

        int index = 1;

        foreach (var item in helper.GetPersonInfo())
        {
            GameObject person = Instantiate(PersonPrefab);

            person.GetComponent<PeronScript>().SetPersonInfo(item);

            //設置父物件
            person.transform.SetParent(PersonTable);

            //設置Person位置
            person.GetComponent<RectTransform>().transform.localPosition =
                new Vector2(0, -index * 40); //Vector2(x軸,y軸)

            index++;
        }

    
    }

    private void Clear()
    {
        foreach (Transform child in PersonTable.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
