using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VictorDev.RTSP;

public class CCTV_InstanceHandler : MonoBehaviour
{
    public SoData_RTSP_Channel rtspData;

    #region Initialize
    private void OnEnable()
    {
        ToggleInstance.onValueChanged.AddListener(OnToggleValueChanged);
        BtnClose.onClick.AddListener(StopRTSP);
        RtspScreenInstance.onPlayStatusEvent.AddListener((isOn)=>BtnScale.interactable = isOn);
    }

    private void OnDisable()
    {
        ToggleInstance.onValueChanged.RemoveListener(OnToggleValueChanged);
        BtnClose.onClick.RemoveListener(StopRTSP);
        RtspScreenInstance.onPlayStatusEvent.RemoveListener((isOn)=>BtnScale.interactable = isOn);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn) RtspScreenInstance.Play(rtspData.RTSP_URL);
        else StopRTSP();
    }
    #endregion

    private void StopRTSP()
    {
        RtspScreenInstance.Stop();
    }

    public bool IsOn
    {
        set => ToggleInstance.isOn = value;
    }

    #region Variables
    private Toggle ToggleInstance => _toggle ??= transform.Find("UI").Find("Toggle").GetComponent<Toggle>();
    private Toggle _toggle;
    
    private RtspScreen RtspScreenInstance => _rtspScreen ??= transform.Find("串流畫面").Find("RTSP畫面").GetComponent<RtspScreen>();
    private RtspScreen _rtspScreen;

    private Button BtnScale => _btnScale??=  transform.Find("串流畫面").Find("ButtonScale").GetComponent<Button>();
    private Button _btnScale;
    private Button BtnClose => _btnClose??=  transform.Find("串流畫面").Find("ButtonClose").GetComponent<Button>();
    private Button _btnClose;
    #endregion
}