using System;
using System.Collections.Generic;
using UnityEngine;

/// 環境監控
public class EnviornmentManager : ModulePage
{
   
    public override void OnInit(Action onInitComplete = null)
    {
    }

    protected override void OnShowHandler()
    {
        LandmarkContainer.SetActive(true);
    }

    protected override void OnCloseHandler()
    {
        LandmarkContainer.SetActive(false);
    }

    protected override void InitEventListener()
    {
    }

    protected override void RemoveEventListener()
    {
        
    }

    #region Variables
    [Header(">>> 溫濕度-浮動圖標")] [SerializeField]
    private List<Transform> landmarks;
    
    ///浮動圖標Container
    private GameObject LandmarkContainer => landmarks[0].transform.parent.gameObject;
    #endregion

    #region ContextMenu
    #endregion
}