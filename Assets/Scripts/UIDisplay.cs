using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] GameObject Pannel;
    [SerializeField] GameObject PointButton;
    [SerializeField] GameObject DistanceButton;
    [SerializeField] GameObject WayfindingScene;
    [SerializeField] GameObject TestScene;
    [SerializeField] GameObject Destination;
    [SerializeField] GameObject LocalPlayer;
    [SerializeField] TextMeshProUGUI MessageText;
    [SerializeField] GameObject camFirst;
    [SerializeField] GameObject camSky;
    private GameObject[] m_Player;   //创建一个全部游戏物件GameObject类型的数组

    public string filePath = "C:/temp/PlayerTest.xlsx";

    public void setLocalPlayer(GameObject gameObject)
    {
        LocalPlayer = gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool b = Pannel.activeSelf == true ? false : true;
            Pannel.SetActive(b);
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (camFirst.activeSelf)
            {
                camFirst.SetActive(false);
                camSky.SetActive(true);
            }
            else if (camSky.activeSelf)
            {
                camFirst.SetActive(true);
                camSky.SetActive(false);
            }
        }
    }

    public void OnArrivalButtonClick()
    {
        if (Vector3.Distance(Destination.transform.position, LocalPlayer.transform.position) <= 10)
        {
            PointButton.SetActive(true);
            Pannel.SetActive(false);
            m_Player = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < m_Player.Length; i++)  //遍历数组，设定物件信息
            {
                if (m_Player[i] != LocalPlayer)
                {
                    m_Player[i].SetActive(false);
                }
            }

            MessageText.text = "";
        }
        else
        {
            MessageText.text = "No destination reached.";
        }
    }

    public void OnPointButtonClick()
    {
        PointButton.SetActive(false);
        WayfindingScene.SetActive(false);
        TestScene.SetActive(true);
        DistanceButton.SetActive(true);
    }

    public void OnDistanceButtonClick()
    {
        DistanceButton.SetActive(false);
    }
}