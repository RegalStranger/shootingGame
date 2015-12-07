using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class IPlayerBulletCommand : PrimBase{

    public float Damage { protected set; get; }
    public float Speed { protected set; get; }
    public PlayerBulletBase BulletParent { protected set; get; }

    public override void Start() {
        base.Start();
    }

    public abstract void Init();
    public abstract void Move();
    public abstract void OnTriggerEnter2D(Collider2D col2);
}
