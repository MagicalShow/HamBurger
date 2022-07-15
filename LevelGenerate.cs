using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerate : MonoBehaviour
{
    public int Totoal;
    public GameObject Bread, Obstacles, Empty;
    public int BreadFirst, BreadSecond, GridConstaintCount;
    public List<int> EmptyInt = new List<int>();
    public List<int> BreadPosCheck = new List<int>();

    public void Awake()
    {
        GridConstaintCount = GridObjects.gridObjects.constraintCount;
        Totoal = Random.Range(10, 14);
        /*BreadFirst = Random.Range(1, Totoal);                
        int LoopDiv = Totoal / GridConstaintCount;
        int VerticalRandom = Random.Range(1, 5);
        VerticalRandom = 3;
        for (int i = 1; i <= LoopDiv; i++)
        {
            BreadPosCheck.Add(GridConstaintCount);
            GridConstaintCount = GridConstaintCount + GridObjects.gridObjects.constraintCount;
        }
        BreadSecond = BreadPosSet(VerticalRandom);*/
        Instantiate_Object();
    }
    int BreadPosSet(int VerticalRandom)
    {
        int TempBreadSecond = BreadSecond;
        TempBreadSecond = BreadFirst + 1;
        foreach (var item in BreadPosCheck)
        {
            if (BreadFirst == item)
            {
                if (VerticalRandom == 3)
                {
                    int TempVertical = BreadFirst + GridObjects.gridObjects.constraintCount;
                    Debug.Log(TempVertical + " = " + Totoal);
                    if (TempVertical > Totoal)
                    {
                        TempBreadSecond = BreadFirst - 1;
                        Debug.Log($">>>>>>>> => {BreadSecond}");
                        return TempBreadSecond;
                    }
                    else
                    {
                        TempBreadSecond = TempVertical;
                        Debug.Log($"VerticalRandom => {BreadSecond}");
                        return TempBreadSecond;
                    }
                }
                else
                {
                    TempBreadSecond = BreadFirst - 1;
                    Debug.Log($">>>>>>>> => {BreadSecond}");
                    return TempBreadSecond;
                }
            }
            else
            {
                TempBreadSecond = BreadFirst - 1;
                Debug.Log($"Odd => {BreadSecond} => {item}");
                return TempBreadSecond;
            }
        }
        return TempBreadSecond;
    }

    void SetEmptyValue()
    {
        for (int i = 0; i < 3; i++)
        {
            AgainRepeateInt();
        }
    }

    void AgainRepeateInt()
    {
        int TempRandomValue = Random.Range(1, Totoal);

        if (EmptyInt.Contains(TempRandomValue) && EmptyInt.Count != 0)
        {
            AgainRepeateInt();
        }
        else
        {
            EmptyInt.Add(TempRandomValue);
            Debug.Log(TempRandomValue);
        }

        for (int i = 0; i < EmptyInt.Count; i++)
        {
            if (i == 1)
            {

            }
            if (i == 2)
            {
                int Diff1 = EmptyInt[i] - EmptyInt[i - 1];
                int Diff2 = EmptyInt[i] - EmptyInt[i + 1];
                Debug.Log($"Differece => {Diff1} => {Diff2}");
            }
            if (i == 3)
            {
                int Diff1 = EmptyInt[i] - EmptyInt[i - 2];
                int Diff2 = EmptyInt[i] - EmptyInt[i - 1];
                Debug.Log($"Differece => {Diff1} => {Diff2}");
            }
        }
    }
    void Instantiate_Object()
    {
        SetEmptyValue();

        for (int i = 1; i <= Totoal; i++)
        {
            if (i == EmptyInt[0])
            {
                GameObject Temp_Obstacles = Instantiate(Empty, transform);
            }
            else if (i == EmptyInt[1])
            {
                GameObject Temp_Obstacles = Instantiate(Empty, transform);
            }
            else if (i == EmptyInt[2])
            {
                GameObject Temp_Obstacles = Instantiate(Empty, transform);
            }
            else
            {
                GameObject Temp_Obstacles = Instantiate(Obstacles, transform);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
