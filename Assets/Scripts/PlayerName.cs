using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    public class PlayerName : NetworkBehaviour
    {

        [Tooltip("Leader area of the character")]
        public GameObject flotingInfo;

        [Tooltip("Name area of the character")]
        public GameObject nameInfo;

        [Tooltip("Leader TextMesh of the character")]
        public TextMesh leaderText;

        [Tooltip("Player TextMesh of the character")]
        public TextMesh nameText;

        [Tooltip("Perspective of the character")]
        public GameObject Perspective;

        [SyncVar(hook = nameof(OnPlayerNameChanged))]
        private string playerName;

        [SyncVar(hook = nameof(OnLeaderNameChanged))]
        private string leaderName;

        [SyncVar(hook = nameof(OnColorChanged))]
        private Color PerspectiveColor;

        //private Material PerspectiveMaterialClone;


        private void OnPlayerNameChanged(string oldName, string newName)
        {
            nameText.text = newName;
        }

        private void OnLeaderNameChanged(string oldName, string newName)
        {
            leaderText.text = newName;
        }

        private void OnColorChanged(Color oldColor, Color newColor)
        {
            Perspective.GetComponent<Renderer>().material.color = newColor;

        }

        [Command]
        private void CmdSetupPlayer(string nameValue)
        {
                playerName = nameValue;
        }

        [Command]
        private void CmdSetupLeader(string nameValue)
        {
                leaderName = nameValue;
        }

        [Command]
        private void CmdSetupColor(Color colorValue)
        {
                PerspectiveColor = colorValue;
        }

        public override void OnStartLocalPlayer()
        {
            nameInfo.transform.localPosition = new Vector3(0, -.75f, .6f);
            nameInfo.transform.localScale = new Vector3(1, 1, 1);
        }

        private void Update()
        {
            flotingInfo.transform.LookAt(Camera.main.transform);
            nameInfo.transform.LookAt(Camera.main.transform);

            if (Input.GetKeyUp(KeyCode.F12))
            {
                string text = leaderText.text == "" ? "Leader" : "";
                CmdSetupLeader(text);

                CmdSetupColor(Color.red);
            }

            if (Input.GetKeyUp(KeyCode.F11))
            {
                string text = nameText.text =="" ? System.DateTime.Now.ToString("A" + "MMddHH" + "Y"):"";
                CmdSetupPlayer(text);

                CmdSetupColor(Color.blue);
            }
            
            if (Input.GetKeyUp(KeyCode.F10))
            {
                string text = nameText.text == "" ? System.DateTime.Now.ToString("A" + "MMddHH" + "X") : "";
                CmdSetupPlayer(text);

                CmdSetupColor(Color.yellow);
            }
        }
    }
}


