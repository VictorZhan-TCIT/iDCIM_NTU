using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VictorDev.Common;

namespace _VictorDEV.Common
{
    /// 對PositionTo2DPoint進行前後排序
    public class PositionTo2DPointSorter : MonoBehaviour
    {
        [SerializeField] private List<PositionTo2DPoint> landmarkList;

        private void Update()
        {
            // 根据攝影機距离对Landmark进行排序并调整Sibling Index
            landmarkList.Sort((a, b) => b.DistanceFromCamera.CompareTo(a.DistanceFromCamera));
            for (int i = 0; i < landmarkList.Count; i++)
            {
                landmarkList[i].transform.SetSiblingIndex(i);
            }
        }

        [ContextMenu("- 擷取場景上所有PositionTo2DPoint")]
        private void GetAllLandmarks()
        {
            //landmarkList = Resources.FindObjectsOfTypeAll<PositionTo2DPoint>().OrderBy(target=>target.name).ToList();
            landmarkList = ObjectHandler.FindAllObjectOfType<PositionTo2DPoint>();
        }
    }
}