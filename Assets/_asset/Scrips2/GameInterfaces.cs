using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameInterfaces : MonoBehaviour { }

public interface IMove
{
    public void DoMove(CharacterController characterController, Vector3 moveDirection, float Speed, float deltaTime);
}

public interface IRotate
{
    public void DoRotate(Transform character, Vector3 faceDirect);
}

public interface IMoveInput
{
    public Vector3 MoveDirection();

    public Vector3 GetCurrentMoveDirect();
}

public interface ITurnInput
{
    public Vector3 GetFaceDirect();

    public Vector3 GetCurrentFaceDirect();
}

public interface INearestDetecter
{
    public bool GetNearest(Vector3 thisPos, out Transform result);

    public List<Vector3> GetManyNearest(int neededQuantity, Vector3 thisPos);
}
public interface ISphereDetecter
{
    public void LimitMaxRadius();
}

public interface IWeapon
{
    public void DoOneAttack(Vector3 targetPos);
}

public interface IHasBulletWeapon
{
    public void EmitAttack(Vector3 targetPos);
}

public interface IAttackObserver
{
    public void SubscribeAtkEvent(UnityAction WhenAttack);
}
public interface IEachAtkObserver
{
    public void SubscribeOnlyOneShotEvent(UnityAction WhenOneAttack);
}

public interface ISpeedChangable
{
    public void SpeedMultiplyWith(float amount);

    public void ResetSpeed();
}

