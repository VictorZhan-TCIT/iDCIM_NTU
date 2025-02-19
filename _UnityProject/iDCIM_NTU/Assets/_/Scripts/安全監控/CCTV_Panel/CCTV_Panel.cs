using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VictorDev.RTSP;

public class CCTV_Panel : CCTV_DataHandler
{
    private void Awake()
    {
        TxtLabel.SetText(rtspData.name);
        TxtNumber.SetText(rtspData.name.Split("-")[1].Trim());
    }

    public void PlayRtsp()
    {
        RtspScreenInstance.Play(rtspData.RTSP_URL);
    }

    private void OnClickScaleButtonHandler()
    {
        onClickScaleButton?.Invoke(rtspData.name, RtspScreenInstance);
    }
    
    #region Initialize

    private void OnEnable()
    {
        RtspScreenInstance.onPlayStatusEvent.AddListener((isOn) => BtnScale.interactable = isOn);
        BtnScale.onClick.AddListener(OnClickScaleButtonHandler);
    }

    private void OnDisable()
    {
        RtspScreenInstance.onPlayStatusEvent.RemoveListener((isOn) => BtnScale.interactable = isOn);
        BtnScale.onClick.RemoveListener(OnClickScaleButtonHandler);
        RtspScreenInstance.Stop();
    }

    #endregion


    #region Variables
    private RtspScreen RtspScreenInstance => _rtspScreen ??= transform.Find("RTSP畫面").GetComponent<RtspScreen>();
    private RtspScreen _rtspScreen;
    private Button BtnScale => _btnScale ??= transform.Find("ButtonScale").GetComponent<Button>();
    private Button _btnScale;
    private TextMeshProUGUI TxtLabel => _txtLabel ??= transform.Find("txtLabel").GetComponent<TextMeshProUGUI>();
    private TextMeshProUGUI _txtLabel;
    private TextMeshProUGUI TxtNumber => _txtNumber ??= TxtLabel.transform.GetChild(0).Find("txtNumber").GetComponent<TextMeshProUGUI>();
    private TextMeshProUGUI _txtNumber;
    #endregion
}