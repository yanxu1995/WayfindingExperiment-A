using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerLog : MonoBehaviour
{
    private GameObject[] m_Player;   //创建一个全部游戏物件GameObject类型的数组
    private float ftime;
    public bool start = false;
    public string filePath = "C:/temp/PlayerTest.xlsx";

    int maxColumnNum = 1; //最大列    
    int maxColumnNum1 = 1; //最大行1
    int maxColumnNum2 = 1; //最大行2


    private void Start()
    {
        FileInfo fileinfo = new FileInfo(filePath);
        using (ExcelPackage excelPackage = new ExcelPackage(fileinfo))
        {
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("PlayerLog");
            ExcelWorksheet excelWorksheet1 = excelPackage.Workbook.Worksheets.Add("PlayerPoint");
            ExcelWorksheet excelWorksheet2 = excelPackage.Workbook.Worksheets.Add("PlayerLocate");

            excelPackage.Save();
        }

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F4))
        {
            if (start)
            {
                start = false;
            }
            else
            {
                start = true;
            }
        }

        if (start)
        {
            ftime += Time.deltaTime;
            if (ftime >= 1f)//设定间隔时间
            {
                //执行代码
                GetPlayerInfo();

                ftime = 0f;//计时器复位
            }
        }
    }

    private void GetPlayerInfo()
    {
        m_Player = GameObject.FindGameObjectsWithTag("Player"); //查找所有关于Player标签的物件，保存到数组m_Player

        //取得Excel文件的信息
        FileInfo fileinfo = new FileInfo(filePath);

        //通过Excel文件的信息打开Excel文件
        using (ExcelPackage excelPackage = new ExcelPackage(fileinfo))
        {
            //获取我们要操作的Excel表格sheet
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[1];

            for (int i = 0; i < m_Player.Length; i++)  //遍历数组，输出物件的信息
            {
                Scene scene = SceneManager.GetActiveScene();

                Debug.Log("PlayerName:" + m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text +
                    " PX:" + m_Player[i].GetComponent<Transform>().position.x +
                    " PZ:" + m_Player[i].GetComponent<Transform>().position.z +
                    " RY:" + m_Player[i].GetComponent<Transform>().rotation.y +
                    " RW:" + m_Player[i].GetComponent<Transform>().rotation.w
                    );


                if (excelWorksheet.Cells[1, 1].Value == null)
                {
                    excelWorksheet.Cells[1, 1].Value = "SCENE";
                    excelWorksheet.Cells[1, 2].Value = "TIME";
                    excelWorksheet.Cells[1, 3].Value = "NAME";
                    excelWorksheet.Cells[1, 4].Value = "POSITIONX";
                    excelWorksheet.Cells[1, 5].Value = "POSITIONZ";
                    excelWorksheet.Cells[1, 6].Value = "ROTATIONY";
                    excelWorksheet.Cells[1, 7].Value = "ROTATIONW";
                    excelWorksheet.Cells[maxColumnNum + 1, 1].Value = scene.name;
                    excelWorksheet.Cells[maxColumnNum + 1, 2].Value = System.DateTime.Now.ToString("MMddHHmmss");
                    excelWorksheet.Cells[maxColumnNum + 1, 3].Value = m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text;
                    excelWorksheet.Cells[maxColumnNum + 1, 4].Value = m_Player[i].GetComponent<Transform>().position.x;
                    excelWorksheet.Cells[maxColumnNum + 1, 5].Value = m_Player[i].GetComponent<Transform>().position.z;
                    excelWorksheet.Cells[maxColumnNum + 1, 6].Value = m_Player[i].GetComponent<Transform>().rotation.y;
                    excelWorksheet.Cells[maxColumnNum + 1, 7].Value = m_Player[i].GetComponent<Transform>().rotation.w;

                    maxColumnNum += 2;
                }
                else
                {
                    excelWorksheet.Cells[maxColumnNum + 1, 1].Value = scene.name;
                    excelWorksheet.Cells[maxColumnNum + 1, 2].Value = System.DateTime.Now.ToString("MMddHHmmss");
                    excelWorksheet.Cells[maxColumnNum + 1, 3].Value = m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text;
                    excelWorksheet.Cells[maxColumnNum + 1, 4].Value = m_Player[i].GetComponent<Transform>().position.x;
                    excelWorksheet.Cells[maxColumnNum + 1, 5].Value = m_Player[i].GetComponent<Transform>().position.z;
                    excelWorksheet.Cells[maxColumnNum + 1, 6].Value = m_Player[i].GetComponent<Transform>().rotation.y;
                    excelWorksheet.Cells[maxColumnNum + 1, 7].Value = m_Player[i].GetComponent<Transform>().rotation.w;

                    maxColumnNum += 1;
                }

                excelPackage.Save();
            }
        }
        
    }

    public void OnPointButtonClick1()
    {
        m_Player = GameObject.FindGameObjectsWithTag("Player"); //查找所有关于Player标签的物件，保存到数组m_Player

        //取得Excel文件的信息
        FileInfo fileinfo = new FileInfo(filePath);

        //通过Excel文件的信息打开Excel文件
        using (ExcelPackage excelPackage = new ExcelPackage(fileinfo))
        {
            //获取我们要操作的Excel表格sheet
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[2];

            for (int i = 0; i < m_Player.Length; i++)  //遍历数组，输出物件的信息
            {
                Scene scene = SceneManager.GetActiveScene();

                Debug.Log("★POINT　PlayerName:" + m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text +
                    " PX:" + m_Player[i].GetComponent<Transform>().position.x +
                    " PZ:" + m_Player[i].GetComponent<Transform>().position.z +
                    " RY:" + m_Player[i].GetComponent<Transform>().rotation.y +
                    " RW:" + m_Player[i].GetComponent<Transform>().rotation.w
                    );

                if (excelWorksheet.Cells[1, 1].Value == null)
                {
                    excelWorksheet.Cells[1, 1].Value = "SCENE";
                    excelWorksheet.Cells[1, 2].Value = "TIME";
                    excelWorksheet.Cells[1, 3].Value = "NAME";
                    excelWorksheet.Cells[1, 4].Value = "POSITIONX";
                    excelWorksheet.Cells[1, 5].Value = "POSITIONZ";
                    excelWorksheet.Cells[1, 6].Value = "ROTATIONY";
                    excelWorksheet.Cells[1, 7].Value = "ROTATIONW";
                    excelWorksheet.Cells[maxColumnNum1 + 1, 1].Value = scene.name;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 2].Value = System.DateTime.Now.ToString("MMddHHmmss");
                    excelWorksheet.Cells[maxColumnNum1 + 1, 3].Value = m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 4].Value = m_Player[i].GetComponent<Transform>().position.x;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 5].Value = m_Player[i].GetComponent<Transform>().position.z;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 6].Value = m_Player[i].GetComponent<Transform>().rotation.y;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 7].Value = m_Player[i].GetComponent<Transform>().rotation.w;

                    maxColumnNum += 2;
                }
                else
                {
                    excelWorksheet.Cells[maxColumnNum1 + 1, 1].Value = scene.name;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 2].Value = System.DateTime.Now.ToString("MMddHHmmss");
                    excelWorksheet.Cells[maxColumnNum1 + 1, 3].Value = m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 4].Value = m_Player[i].GetComponent<Transform>().position.x;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 5].Value = m_Player[i].GetComponent<Transform>().position.z;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 6].Value = m_Player[i].GetComponent<Transform>().rotation.y;
                    excelWorksheet.Cells[maxColumnNum1 + 1, 7].Value = m_Player[i].GetComponent<Transform>().rotation.w;

                    maxColumnNum1 += 1;
                }

                excelPackage.Save();
            }
        }
    }

    public void OnDistanceButtonClick1()
    {
        m_Player = GameObject.FindGameObjectsWithTag("Player"); //查找所有关于Player标签的物件，保存到数组m_Player

        //取得Excel文件的信息
        FileInfo fileinfo = new FileInfo(filePath);

        //通过Excel文件的信息打开Excel文件
        using (ExcelPackage excelPackage = new ExcelPackage(fileinfo))
        {
            //获取我们要操作的Excel表格sheet
            ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[3];

            for (int i = 0; i < m_Player.Length; i++)  //遍历数组，输出物件的信息
            {
                Scene scene = SceneManager.GetActiveScene();

                Debug.Log("★LOCATION　PlayerName:" + m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text +
                    " PX:" + m_Player[i].GetComponent<Transform>().position.x +
                    " PZ:" + m_Player[i].GetComponent<Transform>().position.z +
                    " RY:" + m_Player[i].GetComponent<Transform>().rotation.y +
                    " RW:" + m_Player[i].GetComponent<Transform>().rotation.w
                    );

                if (excelWorksheet.Cells[1, 1].Value == null)
                {
                    excelWorksheet.Cells[1, 1].Value = "SCENE";
                    excelWorksheet.Cells[1, 2].Value = "TIME";
                    excelWorksheet.Cells[1, 3].Value = "NAME";
                    excelWorksheet.Cells[1, 4].Value = "POSITIONX";
                    excelWorksheet.Cells[1, 5].Value = "POSITIONZ";
                    excelWorksheet.Cells[1, 6].Value = "ROTATIONY";
                    excelWorksheet.Cells[1, 7].Value = "ROTATIONW";
                    excelWorksheet.Cells[maxColumnNum2 + 1, 1].Value = scene.name;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 2].Value = System.DateTime.Now.ToString("MMddHHmmss");
                    excelWorksheet.Cells[maxColumnNum2 + 1, 3].Value = m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 4].Value = m_Player[i].GetComponent<Transform>().position.x;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 5].Value = m_Player[i].GetComponent<Transform>().position.z;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 6].Value = m_Player[i].GetComponent<Transform>().rotation.y;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 7].Value = m_Player[i].GetComponent<Transform>().rotation.w;

                    maxColumnNum2 += 2;
                }
                else
                {
                    excelWorksheet.Cells[maxColumnNum2 + 1, 1].Value = scene.name;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 2].Value = System.DateTime.Now.ToString("MMddHHmmss");
                    excelWorksheet.Cells[maxColumnNum2 + 1, 3].Value = m_Player[i].transform.Find("NameInfo/NameText").gameObject.GetComponent<TextMesh>().text;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 4].Value = m_Player[i].GetComponent<Transform>().position.x;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 5].Value = m_Player[i].GetComponent<Transform>().position.z;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 6].Value = m_Player[i].GetComponent<Transform>().rotation.y;
                    excelWorksheet.Cells[maxColumnNum2 + 1, 7].Value = m_Player[i].GetComponent<Transform>().rotation.w;

                    maxColumnNum2 += 1;
                }

                excelPackage.Save();
            }
        }
    }
}
