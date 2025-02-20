using System;
using UnityEngine;
using VictorDev.RTSP;
using VictorDev.RTSP;

public class AccessRecordManager : ModulePage
{
   
    public override void OnInit(Action onInitComplete = null)
    {
    }

    private void OnClickScaleButtonHandler(string label, RtspScreen rtspScreen)
    {
    }

    protected override void OnShowHandler()
    {
        LandmarkContainer.SetActive(true);
        CctvLandmarkEntry.IsOn = true;
    }

    protected override void OnCloseHandler()
    {
        LandmarkContainer.SetActive(false);
        CctvLandmarkEntry.IsOn = false;
    }

    protected override void InitEventListener()
    {
    }

    protected override void RemoveEventListener()
    {
        
    }

    #region Variables
    [Header(">>> 門禁浮動圖標")] [SerializeField]
    private Transform accessDoorLandmarks;
    
    ///門禁圖標Container
    private GameObject LandmarkContainer => accessDoorLandmarks.transform.parent.gameObject;
    
    ///CCTV浮動圖標 - 機房入口
    private CCTV_Landmark CctvLandmarkEntry => _cctvLandmarkEntry ??= accessDoorLandmarks.transform.parent.Find("CCTV圖標 - 機房入口監視器").GetComponent<CCTV_Landmark>();
    private CCTV_Landmark _cctvLandmarkEntry;
    
    #endregion

    #region ContextMenu
    #endregion
}