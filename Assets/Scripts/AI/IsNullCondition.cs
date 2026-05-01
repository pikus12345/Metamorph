using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsNull", story: "Check is [Object] not null", category: "Conditions", id: "859d9b100c34f7e2365b8e7c73f0fd8e")]
public partial class IsNullCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Object;

    public override bool IsTrue() => Object != null;
}
