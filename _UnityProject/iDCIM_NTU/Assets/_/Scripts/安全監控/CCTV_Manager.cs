using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using VictorDev.RTSP;

public class CCTV_Manager : ModulePage
{
    [Header("[資料項] - RTSP資料設定")] [SerializeField]
    private List<SoData_RTSP_Channel> rtspChannels = new List<SoData_RTSP_Channel>();
    
    public override void OnInit(Action onInitComplete = null)
    {
    }

    private void OnClickScaleButtonHandler(string label, RtspScreen rtspScreen)
    {
        cctvFullScreenPlayer.Show(label, rtspScreen);
    }

    protected override void OnShowHandler()
    {
        cctvModelHandlers.ForEach(target =>
        {
            target.gameObject.SetActive(true);
        });
    }

    protected override void OnCloseHandler()
    {
        cctvModelHandlers.ForEach(target =>
        {
            target.gameObject.SetActive(false);
            target.IsOn = false;
        });
    }

    protected override void InitEventListener()
    {
        cctvModelHandlers.ForEach(target=> target.onClickScaleButton.AddListener(OnClickScaleButtonHandler));
        cctvPanels.ForEach(target=> target.onClickScaleButton.AddListener(OnClickScaleButtonHandler));
    }

    protected override void RemoveEventListener()
    {
        cctvModelHandlers.ForEach(target=> target.onClickScaleButton.RemoveListener(OnClickScaleButtonHandler));
        cctvPanels.ForEach(target=> target.onClickScaleButton.RemoveListener(OnClickScaleButtonHandler));
    }

    #region Variables
    [FormerlySerializedAs("cctvModelHandler")]
    [FormerlySerializedAs("cctvLandmarks")]
    [Header(">>> CCTV浮動圖標")]
    [SerializeField] private List<CCTV_ModelHandler> cctvModelHandlers = new List<CCTV_ModelHandler>();

    [Header(">>> CCTV視窗")]
    [SerializeField] private List<CCTV_Panel> cctvPanels = new List<CCTV_Panel>();
    
    [Header(">>> CCTV全螢幕")] [SerializeField]
    private CCTVFullScreenPlayer cctvFullScreenPlayer;
    #endregion
    
    #region ContextMenu
    [ContextMenu("- Find_CCTV_ModelHandler")]
    private void Find_CCTV_ModelHandler()
    {
        cctvModelHandlers = FindObjectsOfType<CCTV_ModelHandler>().OrderBy(target=>target.name).ToList();
        cctvModelHandlers.Zip(rtspChannels, (target, rtspChannel) => target.RtspData = rtspChannel).ToList();
        cctvModelHandlers.ForEach(target => EditorUtility.SetDirty(target));
    }
    [ContextMenu("- Find_CCTV_Panel")]
    private void Find_CCTV_Panel()
    {
        cctvPanels = FindObjectsOfType<CCTV_Panel>().OrderBy(target=>target.name).ToList();
        cctvPanels.Zip(rtspChannels, (target, rtspChannel) => target.RtspData = rtspChannel).ToList();
        cctvPanels.ForEach(target => EditorUtility.SetDirty(target));
    }
    #endregion
}