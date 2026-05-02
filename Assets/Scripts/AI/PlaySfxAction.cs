using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlaySFX", story: "[Agent] plays audio on [AudioSource]", category: "Action", id: "22e747f268215c63ba2cbca9e5d84f86")]
public partial class PlaySfxAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<AudioSource> AudioSource;

    protected override Status OnStart()
    {
        AudioSource.Value.Play();
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

