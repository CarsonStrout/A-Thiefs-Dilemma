using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LimitCamAxis : CinemachineExtension
{
    [SerializeField] private float yPosition;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = yPosition;
            state.RawPosition = pos;
        }
    }
}
