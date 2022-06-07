using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIController : MonoBehaviour
{
   
   public GameObject startBtn;
   public RectTransform winPanel;
   public RectTransform restartBtn;
   public TextMeshProUGUI moneyText;
   
   // Win control
   public void WinPanelControl()
   {
      if (winPanel.gameObject.activeSelf)
      {
         winPanel.DOScale(Vector3.one, .6f).SetEase(Ease.Linear).SetDelay(2).OnComplete(() => restartBtn.DOScale(new Vector3(1.25f,1.25f,1.25f), 0.6f).SetDelay(1));
      }
   }
}
