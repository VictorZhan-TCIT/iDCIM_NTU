using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using VictorDev.RTSP;

public class CCTV_Manager : ModulePage
{
   

    public override void OnInit(Action onInitComplete = null)
    {
    }

    private void OnClickScaleButtonHandler(string label, RtspScreen rtspScreen)
    {
        cctvFullScreenPlayer.Show(label, rtspScreen);
    }

    protected override void OnShowHandler()
    {
        LandmarkContainer.SetActive(true);
    }

    protected override void OnCloseHandler()
    {
        cctvLandmarks.ForEach(target => { target.IsOn = false; });
        LandmarkContainer.SetActive(false);
    }

    protected override void InitEventListener()
    {
        cctvLandmarks.ForEach(target => target.onClickScaleButton.AddListener(OnClickScaleButtonHandler));
        cctvPanels.ForEach(target => target.onClickScaleButton.AddListener(OnClickScaleButtonHandler));
    }

    protected override void RemoveEventListener()
    {
        cctvLandmarks.ForEach(target => target.onClickScaleButton.RemoveListener(OnClickScaleButtonHandler));
        cctvPanels.ForEach(target => target.onClickScaleButton.RemoveListener(OnClickScaleButtonHandler));
    }

    #region Variables

    [Header("[資料項] - RTSP資料設定")] [SerializeField]
    private List<SoData_RTSP_Channel> rtspChannels = new List<SoData_RTSP_Channel>();
    
    [Header(">>> CCTV浮動圖標")] [SerializeField]
    private List<CCTV_Landmark> cctvLandmarks = new List<CCTV_Landmark>();

    [Header(">>> CCTV視窗")] [SerializeField]
    private List<CCTV_Panel> cctvPanels = new List<CCTV_Panel>();

    [Header(">>> CCTV全螢幕")] [SerializeField]
    private CCTVFullScreenPlayer cctvFullScreenPlayer;

    ///CCTV圖標Container
    private GameObject LandmarkContainer => cctvLandmarks[0].transform.parent.gameObject;
    #endregion

    #region ContextMenu

    [ContextMenu("- Find_CCTV_Landmark")]
    private void Find_CCTV_Landmark()
    {
        cctvLandmarks = FindObjectsOfType<CCTV_Landmark>().OrderBy(target => target.name).ToList();
        cctvLandmarks.Zip(rtspChannels, (target, rtspChannel) => target.RtspData = rtspChannel).ToList();
        cctvLandmarks.ForEach(target => EditorUtility.SetDirty(target));
    }

    [ContextMenu("- Find_CCTV_Panel")]
    private void Find_CCTV_Panel()
    {
        cctvPanels = FindObjectsOfType<CCTV_Panel>().OrderBy(target => target.name).ToList();
        cctvPanels.Zip(rtspChannels, (target, rtspChannel) => target.RtspData = rtspChannel).ToList();
        cctvPanels.ForEach(target => EditorUtility.SetDirty(target));
    }

    #endregion
}