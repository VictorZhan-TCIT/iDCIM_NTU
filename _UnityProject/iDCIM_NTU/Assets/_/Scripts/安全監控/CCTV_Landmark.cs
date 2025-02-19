using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VictorDev.RTSP;

public class CCTV_Landmark : CCTV_DataHandler
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
        
        TxtLabel.SetText(rtspData.name.Split("-")[0].Trim());
        TxtLabelSelected.SetText(rtspData.name.Split("-")[0].Trim());
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

    private TextMeshProUGUI TxtLabel => _txtLabel ??= transform.Find("UI").GetChild(0).Find("txtLabel").GetComponent<TextMeshProUGUI>();
    private TextMeshProUGUI _txtLabel;
    
    private TextMeshProUGUI TxtLabelSelected => _txtLabelSelected ??= transform.Find("UI").GetChild(0).GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
    private TextMeshProUGUI _txtLabelSelected;
    
    private Button BtnScale => _btnScale ??= transform.Find("串流畫面").Find("ButtonScale").GetComponent<Button>();
    private Button _btnScale;

    #endregion
}