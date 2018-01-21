using Dao;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class PeronScript : MonoBehaviour
{
    public GameObject Age;
    public GameObject Name;
    public GameObject RowId;

    public Button DeleteBtn;

    public InputField Input_Age;
    public InputField Input_Name;

    private PersonModel personInfo;

    private PersonDao _personDAO;

    void Awake()
    {
        _personDAO = new PersonDao();
    }

    /// <summary>
    /// Person物件初始化
    /// </summary>
    /// <param name="personModel"></param>
    public void SetPersonInfo(PersonModel personModel)
    {
        Age.GetComponent<Text>().text = personModel.Age.ToString();
        Name.GetComponent<Text>().text = personModel.Name;
        RowId.GetComponent<Text>().text = personModel.Rowid.ToString();
        personInfo = personModel;

        Button btn = DeleteBtn.GetComponent<Button>();
        btn.onClick.AddListener(DeletePerson);
    }

    /// <summary>
    /// 新增Person方法
    /// </summary>
    public void AddPerson()
    {
        //Input Age
        string age = Input_Age.text;
        //Input Name
        string name = Input_Name.text;

        _personDAO.AddPerson(new PersonModel()
        {
            Age = age.IntOrDefault(),
            Name = name
        });

        InfoScript.Instance.Init();
    }

    /// <summary>
    /// 刪除Person方法
    /// </summary>
    public void DeletePerson()
    {
        _personDAO.DeletePerson(personInfo.Rowid);
        InfoScript.Instance.Init();
    }
}

public static class BaseExt
{
    public static int IntOrDefault(this string input)
    {
        int result = 0;
        return int.TryParse(input, out result) ? result : default(int);
    }
}
