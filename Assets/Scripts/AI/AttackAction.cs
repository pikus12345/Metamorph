using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "[Agent] attacks forward", category: "Action", id: "21b49806b1ae0e9a7f2b9ec6374beb0b")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    
    protected override Status OnStart()
    {
        Agent.Value.GetComponent<AttackController>().Attack();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

