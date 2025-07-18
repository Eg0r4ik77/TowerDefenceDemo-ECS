//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEntityViewPoolType;

    public static Entitas.IMatcher<GameEntity> EntityViewPoolType {
        get {
            if (_matcherEntityViewPoolType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EntityViewPoolType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEntityViewPoolType = matcher;
            }

            return _matcherEntityViewPoolType;
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

    public Infrastructure.View.EntityViewComponents.EntityViewPoolTypeComponent entityViewPoolType { get { return (Infrastructure.View.EntityViewComponents.EntityViewPoolTypeComponent)GetComponent(GameComponentsLookup.EntityViewPoolType); } }
    public Infrastructure.View.Pool.EntityViewPoolType EntityViewPoolType { get { return entityViewPoolType.Value; } }
    public bool hasEntityViewPoolType { get { return HasComponent(GameComponentsLookup.EntityViewPoolType); } }

    public GameEntity AddEntityViewPoolType(Infrastructure.View.Pool.EntityViewPoolType newValue) {
        var index = GameComponentsLookup.EntityViewPoolType;
        var component = (Infrastructure.View.EntityViewComponents.EntityViewPoolTypeComponent)CreateComponent(index, typeof(Infrastructure.View.EntityViewComponents.EntityViewPoolTypeComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEntityViewPoolType(Infrastructure.View.Pool.EntityViewPoolType newValue) {
        var index = GameComponentsLookup.EntityViewPoolType;
        var component = (Infrastructure.View.EntityViewComponents.EntityViewPoolTypeComponent)CreateComponent(index, typeof(Infrastructure.View.EntityViewComponents.EntityViewPoolTypeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEntityViewPoolType() {
        RemoveComponent(GameComponentsLookup.EntityViewPoolType);
        return this;
    }
}
