using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RefreshDistance", story: "Check distance beetween [Agent] and [Target] and save it to [Distance]", category: "Action", id: "8e5539649abf88958f680635dd8cf2ad")]
public partial class RefreshDistanceAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> Distance;

    protected override Status OnStart()
    {
        Distance.Value = Vector3.Distance(Agent.Value.position, Target.Value.position);
        return Status.Success;
    }
}

