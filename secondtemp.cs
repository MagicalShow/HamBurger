using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Horizontal
{
    public List<Vector3> Horizontal_List = new List<Vector3>();
}

public class secondtemp : MonoBehaviour
{

    public int Total;
    public List<Horizontal> Horizontal = new List<Horizontal>();
    public List<Horizontal> Horizontal_Temp = new List<Horizontal>();
    public GameObject Bread, Obstacles, Empty;
    public Transform Parent;
    public List<Vector3> First, Second, Third, Fourth, Fifth, AllNumAdd = new List<Vector3>();
    public int FirstRandom, SecondRandom, ThirdRandom, FourthRandom, FifthRandom, RandomValue;
    private void Start()
    {
        SetHorizontalValue();
        Horizontal_Temp = Horizontal;

        FirstRandom = Random.Range(1, 5);
        SecondRandom = Random.Range(1, 5);
        ThirdRandom = Random.Range(1, 5);
        FourthRandom = Random.Range(1, 5);
        FifthRandom = Random.Range(1, 5);

        int VerticalRandom = Random.Range(3, 6);

        for (int i = 0; i < VerticalRandom; i++)
        {
            if (i == 0) AllRoundPos(FirstRandom, i, First);
            if (i == 1) AllRoundPos(SecondRandom, i, Second);
            if (i == 2) AllRoundPos(ThirdRandom, i, Third);
            if (i == 3) AllRoundPos(FourthRandom, i, Fourth);
            if (i == 4) AllRoundPos(FifthRandom, i, Fifth);
        }

        InstantiateObjects();
    }

    void SetHorizontalValue()
    {
        float z = -2.5f;
        for (int i = 0; i < Horizontal.Count; i++)
        {
            float x = -1.875f;
            float add = 1.25f;

            for (int j = 0; j < 4; j++)
            {
                if (i == 0)
                {
                    Horizontal[i].Horizontal_List.Add(new Vector3(x, 0, z));
                    x += add;
                }
                if (i == 1)
                {
                    Horizontal[i].Horizontal_List.Add(new Vector3(x, 0, z));
                    x += add;
                }
                if (i == 2)
                {
                    Horizontal[i].Horizontal_List.Add(new Vector3(x, 0, z));
                    x += add;
                }
                if (i == 3)
                {
                    Horizontal[i].Horizontal_List.Add(new Vector3(x, 0, z));
                    x += add;
                }
                if (i == 4)
                {
                    Horizontal[i].Horizontal_List.Add(new Vector3(x, 0, z));
                    x += add;
                }
            }
            z += add;
        }
    }

    private void AllRoundPos(int RandomLoopValue, int NumberIncrease, List<Vector3> LoopVector)
    {
        if (NumberIncrease == 0)
            RandomValue = Random.Range(0, Horizontal_Temp[NumberIncrease].Horizontal_List.Count);

        for (int i = 0; i < RandomLoopValue; i++)
        {
            if (i == 0)
            {
                Vector3 TempVector = Horizontal_Temp[NumberIncrease].Horizontal_List[RandomValue];
                if (!LoopVector.Contains(TempVector))
                    LoopVector.Add(TempVector);
            }
            else
            {
                Vector3 RandomValueTemp = LoopVector[0];
                RandomValueTemp += new Vector3(1.25f, 0, 0);
                if (!LoopVector.Contains(RandomValueTemp))
                    LoopVector.Add(RandomValueTemp);
                else
                {
                    RepeatForValueIsContains(LoopVector);
                }
            }
        }
        for (int i = 0; i < LoopVector.Count; i++)
        {
            if (!AllNumAdd.Contains(LoopVector[i]))
                AllNumAdd.Add(LoopVector[i]);
        }
    }

    void RepeatForValueIsContains(List<Vector3> LoopVector)
    {
        Vector3 RandomValueTempRepeat = LoopVector[0];
        RandomValueTempRepeat -= new Vector3(1.25f, 0, 0);
        if (!LoopVector.Contains(RandomValueTempRepeat))
            LoopVector.Add(RandomValueTempRepeat);
        else
        {
            //RepeatForValueIsContains(LoopVector);
        }
    }

    void InstantiateObjects()
    {
        int BreadUpRandom = Random.Range(1, AllNumAdd.Count);
        int BreadDownRandom = BreadUpRandom + 1;

        for (int i = 0; i < AllNumAdd.Count; i++)
        {
            if (BreadUpRandom == i)
            {
                GameObject BreadUp_TempGameobject = Instantiate(Bread, Parent.transform);
                BreadUp_TempGameobject.transform.position = AllNumAdd[i];
                BreadUp_TempGameobject.name = $"Bread_Up => {BreadUpRandom}";

                GameObject BreadDown_TempGameobject = Instantiate(Bread, Parent.transform);
                BreadDown_TempGameobject.transform.position = BreadUp_TempGameobject.transform.position + SecondBreadPos(BreadUp_TempGameobject);
                BreadDown_TempGameobject.name = $"Bread_Down => {BreadDownRandom}";
            }
            else
            {
                GameObject Obstacles_TempGameobject = Instantiate(Obstacles, Parent.transform);
                Obstacles_TempGameobject.transform.position = AllNumAdd[i];
            }
        }
    }

    Vector3 SecondBreadPos(GameObject Object)
    {
        Vector3 Value = new Vector3(0, 0, 1.25f);
        int TotalEmpty_ToPut_SecondBread = 0;

        RaycastHit Right, Left, Up, Down;
        
        Debug.DrawRay(Object.transform.position+new Vector3(0,0,.55f),Vector3.forward, Color.black,50);

        if (Physics.Raycast(Object.transform.position + new Vector3(0, 0, .55f), Object.transform.TransformDirection(Vector3.forward), out Up, int.MaxValue))
        {
            Debug.Log("Up Ray");
            //Value = new Vector3(0, 0, 1.25f);
        }
        else
        {
             Debug.Log("Up = ");
            TotalEmpty_ToPut_SecondBread++;
        }
       /* if (Physics.Raycast(Object.transform.position, Vector3.back, out Down, Mathf.Infinity))
        {
            TotalEmpty_ToPut_SecondBread++;
            Debug.Log("Down");
            //Value = new Vector3(0, 0, -1.25f);
        }
        if (Physics.Raycast(Object.transform.position, Vector3.right, out Right, Mathf.Infinity))
        {
            TotalEmpty_ToPut_SecondBread++;
            Debug.Log("Right");
            //Value = new Vector3(1.25f, 0, 0);
        }
        if (Physics.Raycast(Object.transform.position, Vector3.left, out Left, Mathf.Infinity))
        {
            TotalEmpty_ToPut_SecondBread++;
            Debug.Log("Left");
            //Value = new Vector3(-1.25f, 0, 0);
        }*/

        //Debug.Log(TotalEmpty_ToPut_SecondBread);

        return Value;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
