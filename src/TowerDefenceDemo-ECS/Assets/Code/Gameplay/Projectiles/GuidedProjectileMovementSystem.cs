using Entitas;

namespace Code.Gameplay.Projectiles
{
    public class GuidedProjectileMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _projectiles;
        private readonly IGroup<GameEntity> _targets;

        public GuidedProjectileMovementSystem(GameContext game)
        {
            _projectiles = game.GetGroup(GameMatcher.AllOf(GameMatcher.WorldPosition, GameMatcher.GuidedProjectile));
            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition));
        }

        public void Execute()
        {

        }
    }
    
    
    // public void SetTarget(ITarget target)
    // {
    //     _target = target;
    // }
		  //
    // protected override void Translate()
    // {
    //     var direction = transform.forward;
			 //
    //     if (!_target.IsDead)
    //     {
    //         direction = (_target.Position - transform.position).normalized;
    //         transform.LookAt(_target.Position);
    //     }
			 //
    //     rigidbody.MovePosition(rigidbody.position + direction * (Speed * Time.fixedDeltaTime));
    // }
}