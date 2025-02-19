using System;
using UnityEngine;
using UnityEngine.Events;
using VictorDev.RTSP;

[Serializable]
public abstract class CCTV_DataHandler : MonoBehaviour
{
    [Header("[資料項] - RTSP設定")] [SerializeField]
    protected SoData_RTSP_Channel rtspData;

    [Header("[Event] - 點擊放大鈕時Invoke")]
    public UnityEvent<string, RtspScreen> onClickScaleButton = new UnityEvent<string, RtspScreen>();

    public SoData_RTSP_Channel RtspData { set=> rtspData=value; }
}