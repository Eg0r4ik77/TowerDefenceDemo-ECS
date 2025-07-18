//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMovementByRigidbody;

    public static Entitas.IMatcher<GameEntity> MovementByRigidbody {
        get {
            if (_matcherMovementByRigidbody == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovementByRigidbody);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovementByRigidbody = matcher;
            }

            return _matcherMovementByRigidbody;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Gameplay.Movement.MovementByRigidbody movementByRigidbodyComponent = new Gameplay.Movement.MovementByRigidbody();

    public bool isMovementByRigidbody {
        get { return HasComponent(GameComponentsLookup.MovementByRigidbody); }
        set {
            if (value != isMovementByRigidbody) {
                var index = GameComponentsLookup.MovementByRigidbody;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : movementByRigidbodyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
