using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VictorDev.RTSP;

public class CCTV_ModelHandler : CCTV_DataHandler
{
   private void OnToggleValueChanged(bool isOn)
    {
        if (isOn) RtspScreenInstance.Play(rtspData.RTSP_URL);
        else StopRtsp();
    }

    private void OnClickScaleButtonHandler()
    {
        onClickScaleButton?.Invoke(rtspData.name, RtspScreenInstance);
    }

    private void StopRtsp() => RtspScreenInstance.Stop();

    #region Initialize

    private void OnEnable()
    {
        ToggleInstance.onValueChanged.AddListener(OnToggleValueChanged);
        RtspScreenInstance.onPlayStatusEvent.AddListener((isOn) => BtnScale.interactable = isOn);
        BtnClose.onClick.AddListener(StopRtsp);
        BtnScale.onClick.AddListener(OnClickScaleButtonHandler);
    }

    private void OnDisable()
    {
        ToggleInstance.onValueChanged.RemoveListener(OnToggleValueChanged);
        RtspScreenInstance.onPlayStatusEvent.RemoveListener((isOn) => BtnScale.interactable = isOn);
        BtnClose.onClick.RemoveListener(StopRtsp);
        BtnScale.onClick.RemoveListener(OnClickScaleButtonHandler);
    }

    #endregion


    #region Variables

    public bool IsOn
    {
        set => ToggleInstance.isOn = value;
    }

    private Button BtnClose => _btnClose ??= transform.Find("串流畫面").Find("ButtonClose").GetComponent<Button>();
    private Button _btnClose;
    private Toggle ToggleInstance => _toggle ??= transform.Find("UI").Find("Toggle").GetComponent<Toggle>();
    private Toggle _toggle;

    private RtspScreen RtspScreenInstance =>
        _rtspScreen ??= transform.Find("串流畫面").Find("RTSP畫面").GetComponent<RtspScreen>();

    private RtspScreen _rtspScreen;

    private Button BtnScale => _btnScale ??= transform.Find("串流畫面").Find("ButtonScale").GetComponent<Button>();
    private Button _btnScale;

    #endregion
}