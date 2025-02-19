using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CCTV_Manager : ModulePage
{

    
    public override void OnInit(Action onInitComplete = null)
    {
    }

    protected override void OnShowHandler()
    {
    }

    protected override void OnCloseHandler()
    {
        cctvLandmarks.ForEach(target => target.IsOn = false);
    }

    protected override void InitEventListener()
    {
    }

    protected override void RemoveEventListener()
    {
    }

    #region Variables
    [Header(">>> CCTV浮動圖標")]
    [SerializeField] private List<CCTV_InstanceHandler> cctvLandmarks = new List<CCTV_InstanceHandler>();
    #endregion
    
    #region ContextMenu
    [ContextMenu("- FindCCTVInstances")]
    private void ContextMenu_FindCCTVInstances()
    {
        cctvLandmarks = FindObjectsOfType<CCTV_InstanceHandler>().OrderBy(target=>target.name).ToList();
    }
    #endregion
   
}