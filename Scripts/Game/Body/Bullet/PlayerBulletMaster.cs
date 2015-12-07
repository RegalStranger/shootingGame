using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PlayerBulletMasterData {

	public GameObject PleyerBulletPrefub { private set; get; }
    public Texture2D BulletIcon { private set; get; }
    public string BulletName { private set; get; }

    public PlayerBulletMasterData(string i_prefab, string i_icon, string i_name) {
        this.PleyerBulletPrefub = Resources.Load<GameObject>(i_prefab);
        this.BulletIcon = Resources.Load<Texture2D>(i_icon);
        this.BulletName = i_name;
    }
}

public class PlayerBulletMaster
{
    public static Dictionary<PlayerBulletType, PlayerBulletMasterData> playerBulletTable = new Dictionary<PlayerBulletType, PlayerBulletMasterData>();

    private static void CreatePlayerMasterData(List<string> master) {
        foreach (var data in master) {
            string[] group = data.Split(new char[] { ',' });
            playerBulletTable.Add((PlayerBulletType)int.Parse(group[0]), new PlayerBulletMasterData(group[1], group[2], group[3]));
        }
    }

    public static void CreatePlayerMasterData(string master = null) {
        if (playerBulletTable.Count > 0) return;
        List<string> groupList = new List<string>();
        if (master == null) {
            TextAsset masterData = Resources.Load<TextAsset>("PlayerBulletData/PlayerBulletData");
            groupList = CommonUtil.GetCsvTextToList(masterData);
        } else {
            groupList = CommonUtil.ArrayToList(master.Split(new char[] { '\n' }));
        }
        CreatePlayerMasterData(groupList);
    }

    public static IPlayerBulletCommand GetPlayerBulletType(PlayerBulletType type) {
        IPlayerBulletCommand command = null;

        switch (type) {
            case PlayerBulletType.TWO_WAY:
                command = new PlayerTwoWayBullet();
                break;
            case PlayerBulletType.WIDE_WAY:
                command = new PlayerWideWayBullet();
                break;
            case PlayerBulletType.SHELL:
                command = new PlayerShellBullet();
                break;
            case PlayerBulletType.THREE_WAY:
            default:
                command = new PlayerThreeWayBullet();
                break;
        }
        return command;
    }
}