using TMPro;
using UnityEngine;

namespace Assets.Scripts.Skin
{
    public class SkinMenuControl : MonoBehaviour
    {
        public GameObject yellowCheckMark, blueCheckMark, greenCheckMark, redCheckMark;
        public GameObject blueLockText, greenLockText, redLockText;
        public GameObject blueTopLockText, greenTopLockText, redTopLockText;
 


        void Start()
        {
            if(!PlayerPrefs.HasKey("checkMark"))
            {
                PlayerPrefs.SetInt("checkMark", 0);
            }
            else
            {
                switch (PlayerPrefs.GetInt("checkMark"))
                {
                    case 0:
                        ButtonYellow(); break;
                    case 1:
                        ButtonBlue(); break;
                    case 2:
                        ButtonGreen(); break;
                    case 3:
                        ButtonRed(); break;
                    default:
                        break;
                }
                
            }

            LockTextPointControl("blueLockText", blueLockText, 50);
            LockTextPointControl("greenLockText", greenLockText, 80);
          
            LockTextControl("blueLockText", blueLockText, blueTopLockText);
            LockTextControl("greenLockText", greenLockText, greenTopLockText);
            LockTextControl("redLockText", redLockText, redTopLockText);
        }
       

        void LockTextPointControl(string key,GameObject lockText, int unlockScore)
        {
            if (!PlayerPrefs.HasKey("highestScore"))
            {
                PlayerPrefs.SetInt("highestScore", 0);
            }
            if (PlayerPrefs.GetInt("highestScore") >= unlockScore)
            {
                PlayerPrefs.SetInt(key, 1);
            }
        }

        void LockTextControl(string key, GameObject lockText, GameObject topLockText)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key, 0);
            }
            if (PlayerPrefs.GetInt(key) == 1)
            {
                lockText.SetActive(false);
                var tmp = topLockText.GetComponent<TextMeshProUGUI>();
                tmp.text = "Unlocked";
                tmp.color = Color.blue;
            }
        }


        public void ButtonYellow()
        {
            
            PlayerPrefs.SetInt("checkMark", 0);
            yellowCheckMark.SetActive(true);
            blueCheckMark.SetActive(false);
            greenCheckMark.SetActive(false);
            redCheckMark.SetActive(false);
        }

        public void ButtonBlue()
        {
            if ((PlayerPrefs.GetInt("blueLockText") == 1))
            {
                PlayerPrefs.SetInt("checkMark", 1);
                yellowCheckMark.SetActive(false);
                blueCheckMark.SetActive(true);
                greenCheckMark.SetActive(false);
                redCheckMark.SetActive(false);
            }
                
        }
        public void ButtonGreen()
        {
            if ((PlayerPrefs.GetInt("greenLockText") == 1))
            {
                PlayerPrefs.SetInt("checkMark", 2);
                yellowCheckMark.SetActive(false);
                blueCheckMark.SetActive(false);
                greenCheckMark.SetActive(true);
                redCheckMark.SetActive(false);
            }
        }
        public void ButtonRed()
        {
            if ((PlayerPrefs.GetInt("redLockText") == 1))
            {
                PlayerPrefs.SetInt("checkMark", 3);
                yellowCheckMark.SetActive(false);
                blueCheckMark.SetActive(false);
                greenCheckMark.SetActive(false);
                redCheckMark.SetActive(true);
            }
        }
    }
}