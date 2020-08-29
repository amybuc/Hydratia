using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Amy.UI
{
    public class UISystem : MonoBehaviour
    {
        [Header("Main Properties")]
        public UIScreen m_StartScreen;

        [Header("System Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();

        [Header("Fader Properties")]
        public Image m_Fader;
        public float m_FadeInDuration = 1f;
        public float m_FadeOutDuration = 1f;

        public Component[] screens = new Component[0];
        public UIScreen currentScreen;

        public UIScreen CurrentScreen { get { return currentScreen; } }

        public UIScreen previousScreen;

        public UIScreen PreviousScreen { get { return previousScreen; } }




        void Start()
        {
            screens = GetComponentsInChildren<UIScreen>(true);

            InitialiseScreens();

			if (m_StartScreen)
			{
                //SwitchScreens(m_StartScreen);
                switchStartScreen(m_StartScreen);
                Debug.Log("Starting start screen");

            }

            if (m_Fader)
			{
                m_Fader.gameObject.SetActive(true);
			}
            Fadein();
        }


        public void SwitchScreens(UIScreen aScreen)
		{
            if (aScreen)
			{
                if (currentScreen)
				{
                    currentScreen.CloseScreen();
                    previousScreen = currentScreen;
				}

                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();

                if (onSwitchedScreen != null)
				{
                    onSwitchedScreen.Invoke();
				}

			}
		}

        public void switchStartScreen(UIScreen aScreen)
		{
            if (aScreen)
			{
                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
                currentScreen.StartScreen();

                if (onSwitchedScreen != null)
                {
                    onSwitchedScreen.Invoke();
                }

            }

        }

        public void Fadein()
		{
			if (m_Fader)
			{
                m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
			}
		}

        public void FadeOut()
		{
            if (m_Fader)
            {
                m_Fader.CrossFadeAlpha(1f, m_FadeOutDuration, false);
            }
        }

        public void GoToPreviousScreen()
        {
			if (previousScreen)
			{
                SwitchScreens(previousScreen);
			}

        }

        public void LoadScene(int sceneIndex)
		{
            StartCoroutine(WaitToLoadScene(sceneIndex));
		}

        IEnumerator WaitToLoadScene(int sceneIndex)
		{
            yield return null;
		}

        void InitialiseScreens()
		{
            foreach (var screen in screens)
			{
                screen.gameObject.SetActive(true);
			}
		}

    }


}

