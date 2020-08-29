using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace Amy.UI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIScreen : MonoBehaviour
    {
        public Animator animator;
        [Header("Main Properties")]
        public Selectable m_StartSelectable;
        [Header("Main Properties")]
        public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();





        void Start()
        {
            animator = GetComponent<Animator>();

			if (m_StartSelectable)
			{
                EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
			}
        }



        public virtual void StartScreen()
		{
            if (onScreenStart != null)
			{
                onScreenStart.Invoke();
			}
            HandleAnimator("show");
        }

        public virtual void CloseScreen()
		{
            if (onScreenClose != null)
            {
                onScreenClose.Invoke();
            }
            HandleAnimator("hide");

        }

        void HandleAnimator(string aTrigger)
		{
            if (animator)
            {
                animator.SetTrigger(aTrigger);
            }
        }


    }
}

