using TMPro;
using UnityEngine.UI;
using VictorDev.Advanced;
using VictorDev.RTSP;

/// CCTV放大畫面視窗
public class CCTVFullScreenPlayer : PopUpWindow
{
    public void Show(string label, RtspScreen rtspScreen)
    {
        TxtTitle.SetText(label);
        _rtspScreen = rtspScreen;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _rtspScreen.AddRenderingTarget(RawImg.gameObject);
        gameObject.SetActive(true);
        RawImg.gameObject.SetActive(true);
        ToShow();
    }

    #region [Initialize]

    protected override void OnEnable()
    {
        ToShow();
        BtnClose.onClick.AddListener(ToClose);
    }

    protected override void OnDisable()
    {
        ToClose();
        RawImg.gameObject.SetActive(false);
        BtnClose.onClick.RemoveListener(ToClose);
        _rtspScreen.RemoveRenderingTarget(RawImg.gameObject);
    }

    #endregion

    #region [Components]

    private RtspScreen _rtspScreen;

    private RawImage RawImg => _rawImg ??= transform.Find("imgBkg").Find("rawImg").GetComponent<RawImage>();
    private RawImage _rawImg;
    private TextMeshProUGUI TxtTitle => _txtTitle ??= transform.Find("txtTitle").GetComponent<TextMeshProUGUI>();
    private TextMeshProUGUI _txtTitle;
    private Button BtnClose => _btnClose ??= transform.Find("Button關閉").GetComponent<Button>();
    private Button _btnClose;

    #endregion
}