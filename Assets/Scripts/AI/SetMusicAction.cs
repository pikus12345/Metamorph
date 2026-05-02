using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetMusic", story: "Set BattleMusic on to [Boolean]", category: "Action", id: "1d73423d0496f541bcd8a872f3d3b047")]
public partial class SetMusicAction : Action
{
    [SerializeReference] public BlackboardVariable<bool> Boolean;

    protected override Status OnStart()
    {
        MusicManager.isBattleMusic = Boolean;
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

