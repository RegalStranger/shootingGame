using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBulletBase : BulletBase {

    public List<GameObject> bulletList = new List<GameObject>();    //!< 弾丸リスト

    public override void Start() {
        enable = true;
    }

	void Update () {
        if (YkSys.Pose) {
            SetStopBullet();
        }
	}

    /// <summary>
    /// 弾丸をスタートさせる
    /// </summary>
    public void StartBullet() {
        base.StartBullet(ref bulletList);
    }

    public void SetStopBullet() {
        if (!base.CheckBulletEnable(bulletList)) {
            this.gameObject.SetActive(false);
        }
    }

    public bool GetUnenableTag(string tag) {
        return tag == "Enemy" || tag == "Wall" || tag == "Boss";
    }
}
