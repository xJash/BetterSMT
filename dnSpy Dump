using System;

// Token: 0x02000001 RID: 1
internal class <Module>
{
}

using System;
using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class AchievementsManager : NetworkBehaviour
{
	// Token: 0x060000F2 RID: 242 RVA: 0x0000C2EC File Offset: 0x0000A4EC
	private void Awake()
	{
		if (AchievementsManager.Instance == null)
		{
			AchievementsManager.Instance = this;
		}
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0000C301 File Offset: 0x0000A501
	private void Start()
	{
		this.LoadbufferValues();
		base.StartCoroutine(this.DelayedAchievementCheck());
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000C316 File Offset: 0x0000A516
	private IEnumerator DelayedAchievementCheck()
	{
		yield return new WaitForSeconds(3f);
		if (GameData.Instance && GameData.Instance.gameDay > 1 && this.bufferValues[0] == 0)
		{
			this.bufferValues[0] += (int)GameData.Instance.gameFunds;
		}
		yield break;
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000C328 File Offset: 0x0000A528
	public void LoadbufferValues()
	{
		ES3Settings settings = new ES3Settings(ES3.EncryptionType.AES, "g#asojrtg@omos)^yq");
		string filePath = Application.persistentDataPath + "/buffervalues";
		if (ES3.FileExists(filePath))
		{
			int[] array = ES3.Load<int[]>("bValues", filePath, settings);
			for (int i = 0; i < array.Length; i++)
			{
				this.bufferValues[i] = array[i];
			}
		}
		this.loadedValues = true;
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x0000C388 File Offset: 0x0000A588
	public void SavebufferValues()
	{
		ES3Settings settings = new ES3Settings(ES3.EncryptionType.AES, "g#asojrtg@omos)^yq");
		string filePath = Application.persistentDataPath + "/buffervalues";
		ES3.Save<int[]>("bValues", this.bufferValues, filePath, settings);
		this.AchievementMainCheck();
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x0000C3CC File Offset: 0x0000A5CC
	public void AchievementMainCheck()
	{
		for (int i = 0; i < this.achievementStrings.Length; i++)
		{
			switch (i)
			{
			case 0:
				if (GameData.Instance.gameFunds >= 1000000f)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 1:
				if (this.bufferValues[1] >= 1000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 2:
				if (this.bufferValues[1] >= 10000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 3:
				if (this.bufferValues[1] >= 100000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 4:
				if (this.bufferValues[2] >= 50)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 5:
				if (this.bufferValues[2] >= 500)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 6:
				if (this.bufferValues[2] >= 2000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 7:
				if (this.bufferValues[3] >= 500)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 8:
				if (this.bufferValues[3] >= 2000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 9:
				if (this.bufferValues[3] >= 10000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 10:
				if (this.bufferValues[4] >= 500)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 11:
				if (this.bufferValues[4] >= 2500)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 12:
				if (this.bufferValues[4] >= 10000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 13:
				if (this.bufferValues[5] >= 50)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 14:
				if (this.bufferValues[5] >= 200)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 15:
				if (this.bufferValues[5] >= 500)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 16:
				if (this.bufferValues[6] >= 100)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 17:
				if (this.bufferValues[7] >= 500)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 18:
				if (this.bufferValues[8] >= 500)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 19:
				if (this.bufferValues[9] >= 100)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 20:
				if (this.bufferValues[10] >= 25000)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 21:
				if (this.bufferValues[11] >= 800)
				{
					this.SetSteamAchievement(i);
				}
				break;
			case 22:
				if (base.isServer)
				{
					int numberOfDecorations = this.GetNumberOfDecorations();
					this.RpcCheckDecorationOnClients(numberOfDecorations);
				}
				break;
			}
		}
		this.ResetDayStats();
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0000C6EC File Offset: 0x0000A8EC
	[ClientRpc]
	public void RpcCheckDecorationOnClients(int decorationsNumber)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(decorationsNumber);
		this.SendRPCInternal("System.Void AchievementsManager::RpcCheckDecorationOnClients(System.Int32)", 2081850589, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000C726 File Offset: 0x0000A926
	public void AddLocalAchievementPoint(int achievementIndex)
	{
		if (achievementIndex >= this.bufferValues.Length)
		{
			return;
		}
		this.bufferValues[achievementIndex]++;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000C745 File Offset: 0x0000A945
	public void ResetLocalAchievement(int achievementIndex)
	{
		if (achievementIndex >= this.bufferValues.Length)
		{
			return;
		}
		this.bufferValues[achievementIndex] = 0;
	}

	// Token: 0x060000FB RID: 251 RVA: 0x0000C75C File Offset: 0x0000A95C
	[Command(requiresAuthority = false)]
	public void CmdAddAchievementPoint(int achievementIndex, int quantity)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(achievementIndex);
		writer.WriteInt(quantity);
		base.SendCommandInternal("System.Void AchievementsManager::CmdAddAchievementPoint(System.Int32,System.Int32)", 535780112, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0000C7A0 File Offset: 0x0000A9A0
	[ClientRpc]
	private void RpcAddAchievementPoint(int achievementIndex, int quantity)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(achievementIndex);
		writer.WriteInt(quantity);
		this.SendRPCInternal("System.Void AchievementsManager::RpcAddAchievementPoint(System.Int32,System.Int32)", -1429731841, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0000C7E4 File Offset: 0x0000A9E4
	[Command(requiresAuthority = false)]
	public void CmdMaxFundsCheckouted(float moneyAmount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(moneyAmount);
		base.SendCommandInternal("System.Void AchievementsManager::CmdMaxFundsCheckouted(System.Single)", 2106461342, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060000FE RID: 254 RVA: 0x0000C820 File Offset: 0x0000AA20
	[ClientRpc]
	private void RpcMaxFundsCheckouted(float moneyAmount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(moneyAmount);
		this.SendRPCInternal("System.Void AchievementsManager::RpcMaxFundsCheckouted(System.Single)", -1627554837, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060000FF RID: 255 RVA: 0x0000C85A File Offset: 0x0000AA5A
	private int GetNumberOfDecorations()
	{
		return GameData.Instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(7).transform.childCount;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0000C880 File Offset: 0x0000AA80
	private void ResetDayStats()
	{
		foreach (int num in this.indexesToResetDaily)
		{
			this.bufferValues[num] = 0;
		}
	}

	// Token: 0x06000101 RID: 257 RVA: 0x0000C8B0 File Offset: 0x0000AAB0
	private void SetSteamAchievement(int stringIndex)
	{
		string text = this.achievementStrings[stringIndex];
		SteamUserStats.GetAchievementAndUnlockTime(text, out this.pbAchieved, out this.punUnlockTime);
		if (this.pbAchieved)
		{
			return;
		}
		if (SteamUserStats.SetAchievement(text))
		{
			SteamUserStats.StoreStats();
			return;
		}
		Debug.Log(text + " failed.");
	}

	// Token: 0x06000103 RID: 259 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000C917 File Offset: 0x0000AB17
	protected void UserCode_RpcCheckDecorationOnClients__Int32(int decorationsNumber)
	{
		if (decorationsNumber >= 50)
		{
			this.SetSteamAchievement(22);
		}
		if (decorationsNumber >= 100)
		{
			this.SetSteamAchievement(23);
		}
		if (decorationsNumber >= 100)
		{
			this.SetSteamAchievement(24);
		}
	}

	// Token: 0x06000105 RID: 261 RVA: 0x0000C940 File Offset: 0x0000AB40
	protected static void InvokeUserCode_RpcCheckDecorationOnClients__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCheckDecorationOnClients called on server.");
			return;
		}
		((AchievementsManager)obj).UserCode_RpcCheckDecorationOnClients__Int32(reader.ReadInt());
	}

	// Token: 0x06000106 RID: 262 RVA: 0x0000C969 File Offset: 0x0000AB69
	protected void UserCode_CmdAddAchievementPoint__Int32__Int32(int achievementIndex, int quantity)
	{
		if (achievementIndex >= this.bufferValues.Length)
		{
			return;
		}
		if (quantity <= 0)
		{
			quantity = 1;
		}
		this.RpcAddAchievementPoint(achievementIndex, quantity);
	}

	// Token: 0x06000107 RID: 263 RVA: 0x0000C986 File Offset: 0x0000AB86
	protected static void InvokeUserCode_CmdAddAchievementPoint__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddAchievementPoint called on client.");
			return;
		}
		((AchievementsManager)obj).UserCode_CmdAddAchievementPoint__Int32__Int32(reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x06000108 RID: 264 RVA: 0x0000C9B5 File Offset: 0x0000ABB5
	protected void UserCode_RpcAddAchievementPoint__Int32__Int32(int achievementIndex, int quantity)
	{
		if (!this.loadedValues)
		{
			return;
		}
		this.bufferValues[achievementIndex] += quantity;
	}

	// Token: 0x06000109 RID: 265 RVA: 0x0000C9D1 File Offset: 0x0000ABD1
	protected static void InvokeUserCode_RpcAddAchievementPoint__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAddAchievementPoint called on server.");
			return;
		}
		((AchievementsManager)obj).UserCode_RpcAddAchievementPoint__Int32__Int32(reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x0600010A RID: 266 RVA: 0x0000CA00 File Offset: 0x0000AC00
	protected void UserCode_CmdMaxFundsCheckouted__Single(float moneyAmount)
	{
		if (moneyAmount > this.maxMoneyAmount)
		{
			this.maxMoneyAmount = moneyAmount;
			this.RpcMaxFundsCheckouted(moneyAmount);
		}
	}

	// Token: 0x0600010B RID: 267 RVA: 0x0000CA19 File Offset: 0x0000AC19
	protected static void InvokeUserCode_CmdMaxFundsCheckouted__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdMaxFundsCheckouted called on client.");
			return;
		}
		((AchievementsManager)obj).UserCode_CmdMaxFundsCheckouted__Single(reader.ReadFloat());
	}

	// Token: 0x0600010C RID: 268 RVA: 0x0000CA43 File Offset: 0x0000AC43
	protected void UserCode_RpcMaxFundsCheckouted__Single(float moneyAmount)
	{
		this.bufferValues[11] = (int)moneyAmount;
	}

	// Token: 0x0600010D RID: 269 RVA: 0x0000CA50 File Offset: 0x0000AC50
	protected static void InvokeUserCode_RpcMaxFundsCheckouted__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcMaxFundsCheckouted called on server.");
			return;
		}
		((AchievementsManager)obj).UserCode_RpcMaxFundsCheckouted__Single(reader.ReadFloat());
	}

	// Token: 0x0600010E RID: 270 RVA: 0x0000CA7C File Offset: 0x0000AC7C
	static AchievementsManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(AchievementsManager), "System.Void AchievementsManager::CmdAddAchievementPoint(System.Int32,System.Int32)", new RemoteCallDelegate(AchievementsManager.InvokeUserCode_CmdAddAchievementPoint__Int32__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(AchievementsManager), "System.Void AchievementsManager::CmdMaxFundsCheckouted(System.Single)", new RemoteCallDelegate(AchievementsManager.InvokeUserCode_CmdMaxFundsCheckouted__Single), false);
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementsManager), "System.Void AchievementsManager::RpcCheckDecorationOnClients(System.Int32)", new RemoteCallDelegate(AchievementsManager.InvokeUserCode_RpcCheckDecorationOnClients__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementsManager), "System.Void AchievementsManager::RpcAddAchievementPoint(System.Int32,System.Int32)", new RemoteCallDelegate(AchievementsManager.InvokeUserCode_RpcAddAchievementPoint__Int32__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(AchievementsManager), "System.Void AchievementsManager::RpcMaxFundsCheckouted(System.Single)", new RemoteCallDelegate(AchievementsManager.InvokeUserCode_RpcMaxFundsCheckouted__Single));
	}

	// Token: 0x0400011E RID: 286
	public static AchievementsManager Instance;

	// Token: 0x0400011F RID: 287
	public int[] bufferValues;

	// Token: 0x04000120 RID: 288
	[Space(10f)]
	public string[] achievementStrings;

	// Token: 0x04000121 RID: 289
	[Space(10f)]
	public int[] indexesToResetDaily;

	// Token: 0x04000122 RID: 290
	[TextArea(10, 1000)]
	public string Comment = "Information Here.";

	// Token: 0x04000123 RID: 291
	private bool pbAchieved;

	// Token: 0x04000124 RID: 292
	private uint punUnlockTime;

	// Token: 0x04000125 RID: 293
	private float maxMoneyAmount;

	// Token: 0x04000126 RID: 294
	private bool loadedValues;
}

using System;
using System.Collections.Generic;
using J4F;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class AdditionnalQueueProvider : QueueProvider
{
	// Token: 0x0600005F RID: 95 RVA: 0x00006886 File Offset: 0x00004A86
	public override List<GameObject> GetPrefabs()
	{
		return this.addPrefabList;
	}

	// Token: 0x040000B0 RID: 176
	public List<GameObject> addPrefabList;
}

using System;
using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class AntiTheftBehaviour : NetworkBehaviour
{
	// Token: 0x06000115 RID: 277 RVA: 0x0000CBCE File Offset: 0x0000ADCE
	public override void OnStartServer()
	{
		base.OnStartServer();
		base.transform.Find("ThiefColliderTrigger").gameObject.SetActive(true);
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0000CBF4 File Offset: 0x0000ADF4
	public void CheckThief(GameObject otherOBJ)
	{
		if (otherOBJ == this.oldNPCOBJ)
		{
			return;
		}
		if (otherOBJ.name == "HitTrigger" && otherOBJ.transform.parent && otherOBJ.transform.parent.GetComponent<NPC_Info>())
		{
			NPC_Info component = otherOBJ.transform.parent.GetComponent<NPC_Info>();
			if (component.isAThief && component.thiefFleeing && component.productsIDCarrying.Count > 0)
			{
				this.RpcSoundAlarm();
				this.oldNPCOBJ = otherOBJ;
			}
		}
	}

	// Token: 0x06000117 RID: 279 RVA: 0x0000CC88 File Offset: 0x0000AE88
	[ClientRpc]
	private void RpcSoundAlarm()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void AntiTheftBehaviour::RpcSoundAlarm()", -1034966944, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000118 RID: 280 RVA: 0x0000CCB8 File Offset: 0x0000AEB8
	private IEnumerator AlarmBehaviour()
	{
		this.alarmIsPlaying = true;
		int iterations = 0;
		bool set = true;
		while (iterations < 20)
		{
			if (set)
			{
				this.lightOBJ1.GetComponent<MeshRenderer>().material = this.lightOn;
				this.lightOBJ2.GetComponent<MeshRenderer>().material = this.lightOn;
			}
			else
			{
				this.lightOBJ1.GetComponent<MeshRenderer>().material = this.lightOff;
				this.lightOBJ2.GetComponent<MeshRenderer>().material = this.lightOff;
			}
			yield return new WaitForSeconds(0.25f);
			int num = iterations;
			iterations = num + 1;
			set = !set;
		}
		yield return null;
		this.alarmIsPlaying = false;
		yield break;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0000CCCF File Offset: 0x0000AECF
	protected void UserCode_RpcSoundAlarm()
	{
		base.transform.Find("AlarmAudio").GetComponent<AudioSource>().Play();
		if (!this.alarmIsPlaying)
		{
			base.StartCoroutine(this.AlarmBehaviour());
		}
	}

	// Token: 0x0600011C RID: 284 RVA: 0x0000CD00 File Offset: 0x0000AF00
	protected static void InvokeUserCode_RpcSoundAlarm(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSoundAlarm called on server.");
			return;
		}
		((AntiTheftBehaviour)obj).UserCode_RpcSoundAlarm();
	}

	// Token: 0x0600011D RID: 285 RVA: 0x0000CD23 File Offset: 0x0000AF23
	static AntiTheftBehaviour()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(AntiTheftBehaviour), "System.Void AntiTheftBehaviour::RpcSoundAlarm()", new RemoteCallDelegate(AntiTheftBehaviour.InvokeUserCode_RpcSoundAlarm));
	}

	// Token: 0x0400012A RID: 298
	private bool alarmIsPlaying;

	// Token: 0x0400012B RID: 299
	public GameObject lightOBJ1;

	// Token: 0x0400012C RID: 300
	public GameObject lightOBJ2;

	// Token: 0x0400012D RID: 301
	public Material lightOn;

	// Token: 0x0400012E RID: 302
	public Material lightOff;

	// Token: 0x0400012F RID: 303
	private GameObject oldNPCOBJ;
}

using System;
using UnityEngine;

// Token: 0x0200001F RID: 31
public class ArrayListTable : MonoBehaviour
{
	// Token: 0x0600006C RID: 108 RVA: 0x00006C80 File Offset: 0x00004E80
	public string GetColumnHeader(int index)
	{
		if (this.HeaderProxy == null)
		{
			return string.Empty;
		}
		if (index < 0 || index >= this.HeaderProxy.arrayList.Count)
		{
			return string.Empty;
		}
		return this.HeaderProxy.arrayList[index].ToString();
	}

	// Token: 0x040000B8 RID: 184
	public PlayMakerArrayListProxy HeaderProxy;

	// Token: 0x040000B9 RID: 185
	public PlayMakerArrayListProxy[] ColumnData;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class AudiencePath : WalkPath
{
	// Token: 0x0600000B RID: 11 RVA: 0x00002620 File Offset: 0x00000820
	public override void DrawCurved(bool withDraw)
	{
		if (this.numberOfWays < 1)
		{
			this.numberOfWays = 1;
		}
		if (this.lineSpacing < 0.6f)
		{
			this.lineSpacing = 0.6f;
		}
		this._forward = new bool[this.numberOfWays];
		for (int i = 0; i < this.numberOfWays; i++)
		{
			this._forward[i] = true;
		}
		if (this.pathPoint.Count < 2)
		{
			return;
		}
		this.points = new Vector3[this.numberOfWays, this.pathPoint.Count + 2];
		this.pointLength[0] = this.pathPoint.Count + 2;
		for (int j = 0; j < this.pathPointTransform.Count; j++)
		{
			Vector3 a;
			Vector3 b;
			if (j == 0)
			{
				if (this.loopPath)
				{
					a = this.pathPointTransform[this.pathPointTransform.Count - 1].transform.position - this.pathPointTransform[j].transform.position;
				}
				else
				{
					a = Vector3.zero;
				}
				b = this.pathPointTransform[j].transform.position - this.pathPointTransform[j + 1].transform.position;
			}
			else if (j == this.pathPointTransform.Count - 1)
			{
				a = this.pathPointTransform[j - 1].transform.position - this.pathPointTransform[j].transform.position;
				if (this.loopPath)
				{
					b = this.pathPointTransform[j].transform.position - this.pathPointTransform[0].transform.position;
				}
				else
				{
					b = Vector3.zero;
				}
			}
			else
			{
				a = this.pathPointTransform[j - 1].transform.position - this.pathPointTransform[j].transform.position;
				b = this.pathPointTransform[j].transform.position - this.pathPointTransform[j + 1].transform.position;
			}
			Vector3 a2 = Vector3.Normalize(Quaternion.Euler(0f, 90f, 0f) * (a + b));
			this.points[0, j + 1] = ((this.numberOfWays % 2 == 1) ? this.pathPointTransform[j].transform.position : (this.pathPointTransform[j].transform.position + a2 * this.lineSpacing / 2f));
			if (this.numberOfWays > 1)
			{
				this.points[1, j + 1] = this.points[0, j + 1] - a2 * this.lineSpacing;
			}
			for (int k = 1; k < this.numberOfWays; k++)
			{
				this.points[k, j + 1] = this.points[0, j + 1] + a2 * this.lineSpacing * (float)Math.Pow(-1.0, (double)k) * (float)((k + 1) / 2);
			}
		}
		for (int l = 0; l < this.numberOfWays; l++)
		{
			this.points[l, 0] = this.points[l, 1];
			this.points[l, this.pointLength[0] - 1] = this.points[l, this.pointLength[0] - 2];
		}
		if (withDraw)
		{
			for (int m = 0; m < this.numberOfWays; m++)
			{
				if (this.loopPath)
				{
					Gizmos.color = (this._forward[m] ? Color.green : Color.red);
					Gizmos.DrawLine(this.points[m, 0], this.points[m, this.pathPoint.Count]);
				}
				for (int n = 1; n < this.pathPoint.Count; n++)
				{
					Gizmos.color = (this._forward[m] ? Color.green : Color.red);
					Gizmos.DrawLine(this.points[m, n + 1], this.points[m, n]);
				}
			}
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002AB4 File Offset: 0x00000CB4
	public override void SpawnPeople()
	{
		List<GameObject> list = new List<GameObject>(this.peoplePrefabs);
		for (int i = list.Count - 1; i >= 0; i--)
		{
			if (list[i] == null)
			{
				list.RemoveAt(i);
			}
		}
		this.peoplePrefabs = list.ToArray();
		if (this.points == null)
		{
			this.DrawCurved(false);
		}
		if (this.par == null)
		{
			this.par = new GameObject();
			this.par.transform.parent = base.gameObject.transform;
			this.par.name = "walkingObjects";
		}
		int num;
		if (!this.loopPath)
		{
			num = this.pointLength[0] - 2;
		}
		else
		{
			num = this.pointLength[0] - 1;
		}
		if (num < 2)
		{
			return;
		}
		int num2 = this.loopPath ? (this.pointLength[0] - 1) : (this.pointLength[0] - 2);
		for (int j = 0; j < this.numberOfWays; j++)
		{
			this._distances = new float[num2];
			float num3 = 0f;
			for (int k = 1; k < num2; k++)
			{
				Vector3 vector;
				if (this.loopPath && k == num2 - 1)
				{
					vector = this.points[j, 1] - this.points[j, num2];
				}
				else
				{
					vector = this.points[j, k + 1] - this.points[j, k];
				}
				num3 += vector.magnitude;
				this._distances[k] = num3;
			}
			int num4 = Mathf.FloorToInt(this.Density * num3 / this._minimalObjectLength);
			float num5 = this._minimalObjectLength + (num3 - (float)num4 * this._minimalObjectLength) / (float)num4;
			int[] randomPrefabIndexes = CommonUtils.GetRandomPrefabIndexes(num4, ref this.peoplePrefabs);
			Vector3[] array = new Vector3[this._distances.Length];
			for (int l = 1; l < this._distances.Length; l++)
			{
				array[l - 1] = this.points[j, l];
			}
			array[this._distances.Length - 1] = (this.loopPath ? this.points[j, 1] : this.points[j, this._distances.Length]);
			for (int m = 0; m < num4; m++)
			{
				GameObject gameObject = base.gameObject;
				float num6 = Random.Range(-num5 / 3f, num5 / 3f) + (float)j * num5;
				float distance = (float)(m + 1) * num5 + num6;
				Vector3 routePosition = base.GetRoutePosition(array, distance, num2, this.loopPath);
				routePosition = new Vector3(routePosition.x, routePosition.y, routePosition.z);
				RaycastHit raycastHit;
				if (Physics.Raycast(new Vector3(routePosition.x, routePosition.y + this.highToSpawn, routePosition.z), Vector3.down, out raycastHit, float.PositiveInfinity))
				{
					routePosition.y = raycastHit.point.y;
					gameObject = Object.Instantiate<GameObject>(this.peoplePrefabs[randomPrefabIndexes[m]], routePosition, Quaternion.identity);
					gameObject.transform.parent = this.par.transform;
					PeopleController peopleController = gameObject.AddComponent<PeopleController>();
					peopleController.animNames = new string[]
					{
						"idle1",
						"idle2",
						"cheer",
						"claphands"
					};
					if (this.looking)
					{
						peopleController.target = this.target;
						peopleController.damping = this.damping;
					}
					MovePath movePath = gameObject.AddComponent<MovePath>();
					movePath.walkPath = base.gameObject;
					movePath.MyStart(j, base.GetRoutePoint((float)(m + 1) * num5 + num6, j, num2, true, this.loopPath), "", this.loopPath, true, 0f, 0f);
					Vector3 worldPosition = new Vector3(movePath.finishPos.x, gameObject.transform.position.y, movePath.finishPos.z);
					Object.DestroyImmediate(movePath);
					gameObject.transform.LookAt(worldPosition);
					if (this.angle == AudiencePath.Angle.zero)
					{
						gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + this.peopleRotation, gameObject.transform.eulerAngles.z);
					}
					else
					{
						gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + (float)((this.angle == AudiencePath.Angle.plus90) ? 90 : -90) + this.peopleRotation, gameObject.transform.eulerAngles.z);
					}
					gameObject.transform.position += gameObject.transform.forward * Random.Range(-this.randZPos, this.randZPos);
					gameObject.transform.position += gameObject.transform.right * Random.Range(-this.randXPos, this.randXPos);
					if (Physics.Raycast(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + this.highToSpawn, gameObject.transform.position.z), Vector3.down, out raycastHit, float.PositiveInfinity))
					{
						gameObject.transform.position = new Vector3(gameObject.transform.position.x, raycastHit.point.y, gameObject.transform.position.z);
					}
				}
			}
		}
	}

	// Token: 0x0400001E RID: 30
	[Tooltip("Type of rotation / Вариант поворота")]
	[SerializeField]
	private AudiencePath.Angle angle = AudiencePath.Angle.plus90;

	// Token: 0x0400001F RID: 31
	[Range(-180f, 180f)]
	[Tooltip("Rotation of people / Поворот человека")]
	[SerializeField]
	private float peopleRotation;

	// Token: 0x04000020 RID: 32
	[Tooltip("Look for target / Слежение за таргетом")]
	[HideInInspector]
	[SerializeField]
	private bool looking;

	// Token: 0x04000021 RID: 33
	[Tooltip("Target / Цель")]
	[HideInInspector]
	[SerializeField]
	private Transform target;

	// Token: 0x04000022 RID: 34
	[Tooltip("Speed rotation (smooth) / Скорость поворота (смягчение)")]
	[HideInInspector]
	[SerializeField]
	private float damping = 5f;

	// Token: 0x02000005 RID: 5
	public enum Angle
	{
		// Token: 0x04000024 RID: 36
		zero,
		// Token: 0x04000025 RID: 37
		minus90,
		// Token: 0x04000026 RID: 38
		plus90
	}
}

using System;
using Cinemachine;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class AuxiliarChangeFOV : MonoBehaviour
{
	// Token: 0x06000124 RID: 292 RVA: 0x0000CE79 File Offset: 0x0000B079
	public void SetFOV(float fov)
	{
		fov = Mathf.Clamp(fov, 30f, 120f);
		base.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = fov;
	}
}

using System;
using System.Globalization;
using System.Threading;
using UnityEngine;

// Token: 0x0200003D RID: 61
public class AuxiliarMethods : MonoBehaviour
{
	// Token: 0x06000126 RID: 294 RVA: 0x0000CE9E File Offset: 0x0000B09E
	public bool CheckNullOrWhiteSpaces(string stringToCheck)
	{
		return string.IsNullOrWhiteSpace(stringToCheck);
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0000CEA6 File Offset: 0x0000B0A6
	public string ReturnDecimal()
	{
		return CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
	}

	// Token: 0x06000128 RID: 296 RVA: 0x0000CEB7 File Offset: 0x0000B0B7
	public string returnCurrentCulture()
	{
		return Thread.CurrentThread.CurrentCulture.Name;
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
	public void ChangeCulture()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
	}

	// Token: 0x0600012A RID: 298 RVA: 0x0000CEE0 File Offset: 0x0000B0E0
	public int ReturnMoneyCheckout(float checkoutValue)
	{
		int num = this.incrementsArray[Random.Range(0, this.incrementsArray.Length)];
		int num2 = 0;
		int num3 = 0;
		while ((float)num3 < float.PositiveInfinity)
		{
			num2 = num * num3;
			if ((float)num2 > checkoutValue)
			{
				break;
			}
			num3++;
		}
		return num2;
	}

	// Token: 0x04000135 RID: 309
	private int[] incrementsArray = new int[]
	{
		20,
		50,
		100
	};
}

using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class Billboard : MonoBehaviour
{
	// Token: 0x06000051 RID: 81 RVA: 0x0000662A File Offset: 0x0000482A
	private void Start()
	{
		this.mat = base.GetComponent<Renderer>().material;
		this.Scans = this.mat.GetFloat("_ScanAmount");
		this.ChangeAdd();
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00006659 File Offset: 0x00004859
	private IEnumerator StartEffect()
	{
		yield return new WaitForSeconds(Random.Range(this.MinimumAdvertTime, this.MaximumAdvertTime));
		this.mat.SetFloat("_ScanAmount", 160f);
		yield return new WaitForSeconds(0.5f);
		this.ChangeAdd();
		yield break;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00006668 File Offset: 0x00004868
	private void ChangeAdd()
	{
		int num = Random.Range(0, this.Adverts.Length);
		this.mat.SetTexture("_MainTexture", this.Adverts[num].Advert);
		this.mat.SetFloat("_ScanAmount", this.Scans);
		if (this.MainLight)
		{
			this.MainLight.color = this.Adverts[num].LightColor;
		}
		base.StartCoroutine(this.StartEffect());
	}

	// Token: 0x0400009E RID: 158
	public Billboard.AdvertList[] Adverts;

	// Token: 0x0400009F RID: 159
	public Light MainLight;

	// Token: 0x040000A0 RID: 160
	private Material mat;

	// Token: 0x040000A1 RID: 161
	private float Scans;

	// Token: 0x040000A2 RID: 162
	public float MinimumAdvertTime = 5f;

	// Token: 0x040000A3 RID: 163
	public float MaximumAdvertTime = 10f;

	// Token: 0x02000017 RID: 23
	[Serializable]
	public class AdvertList
	{
		// Token: 0x040000A4 RID: 164
		public Texture Advert;

		// Token: 0x040000A5 RID: 165
		public Color LightColor;
	}
}

using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

// Token: 0x0200003E RID: 62
public class BloomSet : MonoBehaviour
{
	// Token: 0x0600012C RID: 300 RVA: 0x0000CF40 File Offset: 0x0000B140
	public void SetBloomValue(float bloomValue)
	{
		Bloom bloom;
		this.bloomVolume.profile.TryGet<Bloom>(out bloom);
		bloom.intensity.value = bloomValue;
	}

	// Token: 0x04000136 RID: 310
	public Volume bloomVolume;
}

using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200003F RID: 63
public class BoxData : NetworkBehaviour
{
	// Token: 0x0600012E RID: 302 RVA: 0x0000CF6C File Offset: 0x0000B16C
	public override void OnStartClient()
	{
		this.SetBoxData();
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0000CF74 File Offset: 0x0000B174
	private void SetBoxData()
	{
		if (this.productID < 0 || this.productID >= ProductListing.Instance.productSprites.Length)
		{
			base.gameObject.SetActive(false);
			return;
		}
		Sprite sprite = ProductListing.Instance.productSprites[this.productID];
		base.transform.Find("Canvas/Image1").GetComponent<Image>().sprite = sprite;
		base.transform.Find("Canvas/Image2").GetComponent<Image>().sprite = sprite;
		ProductListing.Instance.SetBoxColor(base.gameObject, this.productID);
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000132 RID: 306 RVA: 0x0000D00C File Offset: 0x0000B20C
	// (set) Token: 0x06000133 RID: 307 RVA: 0x0000D01F File Offset: 0x0000B21F
	public int NetworkproductID
	{
		get
		{
			return this.productID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.productID, 1UL, null);
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000134 RID: 308 RVA: 0x0000D03C File Offset: 0x0000B23C
	// (set) Token: 0x06000135 RID: 309 RVA: 0x0000D04F File Offset: 0x0000B24F
	public int NetworknumberOfProducts
	{
		get
		{
			return this.numberOfProducts;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.numberOfProducts, 2UL, null);
		}
	}

	// Token: 0x06000136 RID: 310 RVA: 0x0000D06C File Offset: 0x0000B26C
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.productID);
			writer.WriteInt(this.numberOfProducts);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.productID);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteInt(this.numberOfProducts);
		}
	}

	// Token: 0x06000137 RID: 311 RVA: 0x0000D0F4 File Offset: 0x0000B2F4
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.productID, null, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<int>(ref this.numberOfProducts, null, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.productID, null, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.numberOfProducts, null, reader.ReadInt());
		}
	}

	// Token: 0x04000137 RID: 311
	[SyncVar]
	public int productID;

	// Token: 0x04000138 RID: 312
	[SyncVar]
	public int numberOfProducts;
}

using System;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class BuildableInfo : MonoBehaviour
{
	// Token: 0x04000139 RID: 313
	public int decorationID;

	// Token: 0x0400013A RID: 314
	public float cost = 50f;

	// Token: 0x0400013B RID: 315
	public float minY = -1f;

	// Token: 0x0400013C RID: 316
	public float maxY = 6f;

	// Token: 0x0400013D RID: 317
	public string[] buildableTags;

	// Token: 0x0400013E RID: 318
	public GameObject dummyPrefabOBJ;

	// Token: 0x0400013F RID: 319
	public Vector3 raycastDirection;

	// Token: 0x04000140 RID: 320
	public Vector3 raycastOffset;

	// Token: 0x04000141 RID: 321
	public bool isCool;
}

using System;
using HighlightPlus;
using Mirror;
using Rewired;
using TMPro;
using UnityEngine;

// Token: 0x02000041 RID: 65
public class Builder_Decoration : MonoBehaviour
{
	// Token: 0x06000139 RID: 313 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
	private void Start()
	{
		base.transform.Find("Canvas").gameObject.SetActive(true);
		this.MainPlayer = ReInput.players.GetPlayer(this.playerId);
		this.decorationPropsArray = GameData.Instance.GetComponent<NetworkSpawner>().decorationProps;
		this.SetDummy(0);
		this.SetPrices();
		this.isOwn = true;
		Camera.main.GetComponent<CustomCameraController>().ChangeLayerMask(true);
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0000D228 File Offset: 0x0000B428
	private void Update()
	{
		if (GameCanvas.Instance.transform.Find("Builder").gameObject.activeSelf)
		{
			GameCanvas.Instance.GetComponent<PlayMakerFSM>().SendEvent("Send_Data");
			return;
		}
		if (this.MainPlayer.GetButtonDown("Menu Next"))
		{
			this.currentIndex--;
			if (this.currentIndex < 0)
			{
				this.currentIndex = this.decorationPropsArray.Length - 1;
			}
			this.SetDummy(this.currentIndex);
		}
		else if (this.MainPlayer.GetButtonDown("Menu Previous"))
		{
			this.currentIndex++;
			if (this.currentIndex >= this.decorationPropsArray.Length)
			{
				this.currentIndex = 0;
			}
			this.SetDummy(this.currentIndex);
		}
		if (this.currentIndex == 0)
		{
			this.DeleterBehaviour();
			return;
		}
		if (this.dummyOBJ)
		{
			this.inCorrectBounds = this.InCorrectBounds();
			this.overlapping = this.fsm.FsmVariables.GetFsmBool("Overlapping").Value;
			this.raycastIsCorrect = this.RaycastCheck();
			if (this.inCorrectBounds && !this.overlapping && this.raycastIsCorrect && !this.canPlace)
			{
				this.canPlace = true;
				this.dummyOBJ.GetComponent<HighlightEffect>().glowHQColor = Color.green;
			}
			if ((!this.inCorrectBounds || this.overlapping || !this.raycastIsCorrect) && this.canPlace)
			{
				this.canPlace = false;
				this.dummyOBJ.GetComponent<HighlightEffect>().glowHQColor = Color.red;
			}
			if (this.MainPlayer.GetButtonDown("Build") && this.canPlace)
			{
				if (GameData.Instance.gameFunds < this.decorationCost)
				{
					GameCanvas.Instance.CreateCanvasNotification("message6");
				}
				else
				{
					GameData.Instance.CmdAlterFunds(-this.decorationCost);
					GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnDecoration(this.currentIndex, this.dummyOBJ.transform.position, this.dummyOBJ.transform.rotation.eulerAngles);
				}
			}
			if (this.MainPlayer.GetButtonDown("Main Action"))
			{
				this.dummyOBJ.transform.rotation = Quaternion.Euler(this.dummyOBJ.transform.rotation.eulerAngles + new Vector3(0f, 90f, 0f));
			}
			if (this.MainPlayer.GetButtonDown("Secondary Action"))
			{
				this.dummyOBJ.transform.rotation = Quaternion.Euler(this.dummyOBJ.transform.rotation.eulerAngles - new Vector3(0f, 90f, 0f));
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
			{
				this.dummyOBJ.transform.position = raycastHit.point;
				return;
			}
			this.dummyOBJ.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 4f;
		}
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0000D58C File Offset: 0x0000B78C
	private void SetPrices()
	{
		for (int i = 0; i < this.decorationPropsArray.Length; i++)
		{
			float num;
			if (i == 0)
			{
				num = 0f;
			}
			else
			{
				num = this.decorationPropsArray[i].GetComponent<BuildableInfo>().cost;
				if (this.decorationPropsArray[i].GetComponent<BuildableInfo>().isCool)
				{
					base.transform.Find("Canvas/Container/BCK").transform.GetChild(i).transform.Find("IsCool").gameObject.SetActive(true);
				}
			}
			base.transform.Find("Canvas/Container/BCK").transform.GetChild(i).transform.Find("Price").GetComponent<TextMeshProUGUI>().text = "$" + num.ToString();
		}
	}

	// Token: 0x0600013C RID: 316 RVA: 0x0000D664 File Offset: 0x0000B864
	private void SetDummy(int dummyIndex)
	{
		if (this.dummyOBJ)
		{
			Object.Destroy(this.dummyOBJ);
		}
		foreach (object obj in base.transform.Find("Canvas/Container/BCK"))
		{
			((Transform)obj).transform.Find("Highlight").gameObject.SetActive(false);
		}
		base.transform.Find("Canvas/Container/BCK").transform.GetChild(dummyIndex).transform.Find("Highlight").gameObject.SetActive(true);
		if (dummyIndex == 0)
		{
			this.isCool = false;
			return;
		}
		BuildableInfo component = this.decorationPropsArray[dummyIndex].GetComponent<BuildableInfo>();
		GameObject dummyPrefabOBJ = component.dummyPrefabOBJ;
		this.dummyOBJ = Object.Instantiate<GameObject>(dummyPrefabOBJ);
		this.minY = component.minY;
		this.maxY = component.maxY;
		this.raycastDirection = component.raycastDirection;
		this.raycastOffset = component.raycastOffset;
		this.buildableTags = component.buildableTags;
		this.decorationCost = component.cost;
		this.isCool = component.isCool;
		this.fsm = this.dummyOBJ.GetComponent<PlayMakerFSM>();
	}

	// Token: 0x0600013D RID: 317 RVA: 0x0000D7B8 File Offset: 0x0000B9B8
	private bool InCorrectBounds()
	{
		Vector3 position = this.dummyOBJ.transform.position;
		return position.x > -15f && position.x < 37f && position.z > -8.5f && position.z < 48f && position.y > this.minY && position.y < this.maxY;
	}

	// Token: 0x0600013E RID: 318 RVA: 0x0000D82C File Offset: 0x0000BA2C
	private bool RaycastCheck()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(this.dummyOBJ.transform.position + this.dummyOBJ.transform.TransformDirection(this.raycastOffset), this.dummyOBJ.transform.TransformDirection(this.raycastDirection), out raycastHit, 0.15f, this.lMask))
		{
			if (this.buildableTags.Length == 0)
			{
				return true;
			}
			string tag = raycastHit.transform.gameObject.tag;
			string[] array = this.buildableTags;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == tag)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0000D8D4 File Offset: 0x0000BAD4
	private void DeleterBehaviour()
	{
		if (GameData.Instance.timeOfDay < 8.05f && !GameData.Instance.isSupermarketOpen)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
			{
				if (raycastHit.transform.gameObject.tag == "Movable")
				{
					if (this.oldHitOBJ2 && raycastHit.transform.gameObject != this.oldHitOBJ2 && this.hEffect2)
					{
						this.hEffect2.highlighted = false;
					}
					this.hEffect2 = raycastHit.transform.GetComponent<HighlightEffect>();
					this.hEffect2.highlighted = true;
					if ((this.MainPlayer.GetButtonDown("Build") || this.MainPlayer.GetButtonDown("Main Action") || this.MainPlayer.GetButtonDown("Secondary Action")) && raycastHit.transform.GetComponent<NetworkIdentity>())
					{
						float fundsToAdd = (float)raycastHit.transform.GetComponent<Data_Container>().cost * 0.9f;
						GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd);
						GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(raycastHit.transform.gameObject);
					}
					this.oldHitOBJ2 = raycastHit.transform.gameObject;
				}
				else if (this.hEffect2)
				{
					this.hEffect2.highlighted = false;
				}
			}
			else if (this.hEffect2)
			{
				this.hEffect2.highlighted = false;
			}
		}
		else if (this.hEffect2)
		{
			this.hEffect2.highlighted = false;
		}
		RaycastHit raycastHit2;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit2, 4f, this.lMask))
		{
			if (raycastHit2.transform.gameObject.tag == "Decoration")
			{
				if (this.oldHitOBJ && raycastHit2.transform.gameObject != this.oldHitOBJ && this.hEffect)
				{
					this.hEffect.enabled = false;
				}
				this.hEffect = raycastHit2.transform.Find("Mesh").GetComponent<HighlightEffect>();
				this.hEffect.enabled = true;
				if ((this.MainPlayer.GetButtonDown("Build") || this.MainPlayer.GetButtonDown("Main Action") || this.MainPlayer.GetButtonDown("Secondary Action")) && raycastHit2.transform.GetComponent<NetworkIdentity>())
				{
					float fundsToAdd2 = raycastHit2.transform.GetComponent<BuildableInfo>().cost * 0.9f;
					GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd2);
					GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(raycastHit2.transform.gameObject);
				}
				this.oldHitOBJ = raycastHit2.transform.gameObject;
				return;
			}
			if (this.hEffect)
			{
				this.hEffect.enabled = false;
				return;
			}
		}
		else if (this.hEffect)
		{
			this.hEffect.enabled = false;
		}
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0000DC34 File Offset: 0x0000BE34
	private void OnDestroy()
	{
		if (this.dummyOBJ)
		{
			Object.Destroy(this.dummyOBJ);
		}
		if (this.hEffect)
		{
			this.hEffect.enabled = false;
		}
		if (this.hEffect2)
		{
			this.hEffect2.highlighted = false;
		}
		if (this.isOwn)
		{
			Camera.main.GetComponent<CustomCameraController>().ChangeLayerMask(false);
		}
	}

	// Token: 0x04000142 RID: 322
	public LayerMask lMask;

	// Token: 0x04000143 RID: 323
	private GameObject[] decorationPropsArray;

	// Token: 0x04000144 RID: 324
	private int currentIndex;

	// Token: 0x04000145 RID: 325
	private Player MainPlayer;

	// Token: 0x04000146 RID: 326
	private int playerId;

	// Token: 0x04000147 RID: 327
	private GameObject dummyOBJ;

	// Token: 0x04000148 RID: 328
	private bool inCorrectBounds;

	// Token: 0x04000149 RID: 329
	private bool overlapping;

	// Token: 0x0400014A RID: 330
	private bool raycastIsCorrect;

	// Token: 0x0400014B RID: 331
	private bool canPlace;

	// Token: 0x0400014C RID: 332
	private float minY;

	// Token: 0x0400014D RID: 333
	private float maxY;

	// Token: 0x0400014E RID: 334
	private Vector3 raycastDirection;

	// Token: 0x0400014F RID: 335
	private Vector3 raycastOffset;

	// Token: 0x04000150 RID: 336
	private string[] buildableTags;

	// Token: 0x04000151 RID: 337
	private float decorationCost;

	// Token: 0x04000152 RID: 338
	private bool isCool;

	// Token: 0x04000153 RID: 339
	private PlayMakerFSM fsm;

	// Token: 0x04000154 RID: 340
	private HighlightEffect hEffect;

	// Token: 0x04000155 RID: 341
	private HighlightEffect hEffect2;

	// Token: 0x04000156 RID: 342
	private GameObject oldHitOBJ;

	// Token: 0x04000157 RID: 343
	private GameObject oldHitOBJ2;

	// Token: 0x04000158 RID: 344
	private bool isOwn;
}

using System;
using System.Collections;
using HighlightPlus;
using Mirror;
using Rewired;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000042 RID: 66
public class Builder_Main : MonoBehaviour
{
	// Token: 0x06000142 RID: 322 RVA: 0x0000DCA3 File Offset: 0x0000BEA3
	private void Start()
	{
		this.MainPlayer = ReInput.players.GetPlayer(0);
		base.StartCoroutine(this.RetrieveInitialBehaviours());
	}

	// Token: 0x06000143 RID: 323 RVA: 0x0000DCC4 File Offset: 0x0000BEC4
	private void Update()
	{
		if (!this.initialConfiguration)
		{
			return;
		}
		if (this.recentlyMoved)
		{
			this.recentlyMoved = false;
			return;
		}
		if (this.canvasBuilderOBJ.activeSelf && this.cCameraController.isInCameraEvent)
		{
			this.DeactivateBuilder();
			return;
		}
		if (this.MainPlayer.GetButtonDown("Open Builder"))
		{
			if (!this.canvasBuilderOBJ.activeSelf)
			{
				if (this.cCameraController.isInCameraEvent || FirstPersonController.Instance.inVehicle || !this.pComponent.RequestGP())
				{
					return;
				}
				this.cCameraController.ChangeLayerMask(true);
				this.canvasBuilderOBJ.SetActive(true);
				this.SetDummy(this.currentTabIndex, this.currentElementIndex);
			}
			else
			{
				this.DeactivateBuilder();
			}
		}
		if (!this.canvasBuilderOBJ.activeSelf)
		{
			return;
		}
		if (!this.currentMovedOBJ)
		{
			if (this.MainPlayer.GetButtonDown("Menu Previous"))
			{
				this.currentElementIndex--;
				if (this.currentElementIndex < 0)
				{
					this.currentElementIndex = this.tabContainerOBJ.transform.GetChild(this.currentTabIndex).transform.Find("Container").transform.childCount - 1;
				}
				this.SetDummy(this.currentTabIndex, this.currentElementIndex);
			}
			else if (this.MainPlayer.GetButtonDown("Menu Next"))
			{
				this.currentElementIndex++;
				if (this.currentElementIndex >= this.tabContainerOBJ.transform.GetChild(this.currentTabIndex).transform.Find("Container").transform.childCount)
				{
					this.currentElementIndex = 0;
				}
				this.SetDummy(this.currentTabIndex, this.currentElementIndex);
			}
			else if (this.MainPlayer.GetButtonDown("Tab Previous"))
			{
				this.currentTabIndex--;
				if (this.currentTabIndex < 0)
				{
					this.currentTabIndex = this.tabsOrder.Length - 1;
				}
				this.currentElementIndex = 0;
				this.SetDummy(this.currentTabIndex, this.currentElementIndex);
			}
			else if (this.MainPlayer.GetButtonDown("Tab Next"))
			{
				this.currentTabIndex++;
				if (this.currentTabIndex >= this.tabsOrder.Length)
				{
					this.currentTabIndex = 0;
				}
				this.currentElementIndex = 0;
				this.SetDummy(this.currentTabIndex, this.currentElementIndex);
			}
		}
		if (this.currentTabIndex == 0 && this.currentElementIndex == 0)
		{
			if (this.currentMovedOBJ && this.dummyOBJ)
			{
				if (this.currentMovedOBJ.GetComponent<Data_Container>())
				{
					this.BuildableBehaviour();
				}
				else if (this.currentMovedOBJ.GetComponent<BuildableInfo>())
				{
					this.DecorationBehaviour();
				}
			}
			this.MoveBehaviour();
			return;
		}
		if (this.currentTabIndex == 0 && this.currentElementIndex == 1)
		{
			this.DeleteBehaviour();
			return;
		}
		if (this.dummyOBJ)
		{
			if (this.currentTabIndex == 0)
			{
				this.BuildableBehaviour();
				return;
			}
			this.DecorationBehaviour();
		}
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0000DFD0 File Offset: 0x0000C1D0
	private void DeactivateBuilder()
	{
		this.canvasBuilderOBJ.SetActive(false);
		this.cCameraController.ChangeLayerMask(false);
		if (this.dummyOBJ)
		{
			Object.Destroy(this.dummyOBJ);
		}
		if (this.hEffect)
		{
			this.hEffect.enabled = false;
		}
		if (this.hEffect2)
		{
			this.hEffect2.highlighted = false;
		}
		if (this.currentMovedOBJ)
		{
			if (this.currentMovedOBJ.GetComponent<Data_Container>())
			{
				this.currentMovedOBJ.GetComponent<Data_Container>().RemoveMoveEffect();
			}
			this.currentMovedOBJ = null;
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x0000E078 File Offset: 0x0000C278
	private void BuildableBehaviour()
	{
		this.overlapping = this.pmakerFSM.FsmVariables.GetFsmBool("Overlapping").Value;
		this.correctSector = this.CheckCorrectGround();
		if (this.correctSector && !this.overlapping && !this.canPlace)
		{
			this.canPlace = true;
			this.dummyOBJ.GetComponent<HighlightEffect>().glowHQColor = Color.green;
		}
		if ((!this.correctSector || this.overlapping) && this.canPlace)
		{
			this.canPlace = false;
			this.dummyOBJ.GetComponent<HighlightEffect>().glowHQColor = Color.red;
		}
		if (this.MainPlayer.GetButtonDown("Build") && this.canPlace)
		{
			if (this.currentTabIndex == 0 && this.currentElementIndex == 0)
			{
				if (this.currentMovedOBJ.GetComponent<NetworkIdentity>())
				{
					GameData.Instance.GetComponent<NetworkSpawner>().GetMoveData(this.currentMovedOBJ, this.dummyOBJ.transform.position, this.dummyOBJ.transform.rotation.eulerAngles);
					this.currentMovedOBJ.GetComponent<Data_Container>().RemoveMoveEffect();
					this.currentMovedOBJ = null;
					this.recentlyMoved = true;
					if (this.dummyOBJ)
					{
						Object.Destroy(this.dummyOBJ);
					}
				}
			}
			else if (GameData.Instance.gameFunds < this.buildableCost)
			{
				GameCanvas.Instance.CreateCanvasNotification("message6");
			}
			else
			{
				GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawn(this.currentPropIndex, this.dummyOBJ.transform.position, this.dummyOBJ.transform.rotation.eulerAngles);
			}
		}
		this.SharedBehaviour();
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0000E240 File Offset: 0x0000C440
	private void DecorationBehaviour()
	{
		this.inCorrectBounds = this.InCorrectBounds();
		this.overlapping = this.pmakerFSM.FsmVariables.GetFsmBool("Overlapping").Value;
		this.raycastIsCorrect = this.RaycastCheck();
		if (this.inCorrectBounds && !this.overlapping && this.raycastIsCorrect && !this.canPlace)
		{
			this.canPlace = true;
			this.dummyOBJ.GetComponent<HighlightEffect>().glowHQColor = Color.green;
		}
		if ((!this.inCorrectBounds || this.overlapping || !this.raycastIsCorrect) && this.canPlace)
		{
			this.canPlace = false;
			this.dummyOBJ.GetComponent<HighlightEffect>().glowHQColor = Color.red;
		}
		if (this.MainPlayer.GetButtonDown("Build") && this.canPlace)
		{
			if (this.currentTabIndex == 0 && this.currentElementIndex == 0)
			{
				if (!this.currentMovedOBJ.GetComponent<MiniTransportBehaviour>())
				{
					GameData.Instance.GetComponent<NetworkSpawner>().GetMoveData(this.currentMovedOBJ, this.dummyOBJ.transform.position, this.dummyOBJ.transform.rotation.eulerAngles);
				}
				this.currentMovedOBJ = null;
				this.recentlyMoved = true;
				if (this.dummyOBJ)
				{
					Object.Destroy(this.dummyOBJ);
				}
			}
			else if (GameData.Instance.gameFunds < this.decorationCost)
			{
				GameCanvas.Instance.CreateCanvasNotification("message6");
			}
			else
			{
				GameData.Instance.CmdAlterFunds(-this.decorationCost);
				GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnDecoration(this.currentPropIndex, this.dummyOBJ.transform.position, this.dummyOBJ.transform.rotation.eulerAngles);
			}
		}
		this.SharedBehaviour();
	}

	// Token: 0x06000147 RID: 327 RVA: 0x0000E41C File Offset: 0x0000C61C
	private void SharedBehaviour()
	{
		if (this.MainPlayer.GetButtonDown("Main Action"))
		{
			this.dummyOBJ.transform.rotation = Quaternion.Euler(this.dummyOBJ.transform.rotation.eulerAngles + new Vector3(0f, 90f, 0f));
		}
		if (this.MainPlayer.GetButtonDown("Secondary Action"))
		{
			this.dummyOBJ.transform.rotation = Quaternion.Euler(this.dummyOBJ.transform.rotation.eulerAngles - new Vector3(0f, 90f, 0f));
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
		{
			this.dummyOBJ.transform.position = raycastHit.point;
			return;
		}
		this.dummyOBJ.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 4f;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0000E568 File Offset: 0x0000C768
	private void SetDummy(int tabIndex, int elementIndex)
	{
		if (this.dummyOBJ)
		{
			Object.Destroy(this.dummyOBJ);
		}
		if (this.oldTabIndex != tabIndex)
		{
			foreach (object obj in this.tabContainerOBJ.transform)
			{
				((Transform)obj).gameObject.SetActive(false);
			}
			this.tabContainerOBJ.transform.GetChild(tabIndex).gameObject.SetActive(true);
			this.tabContainerOBJ.transform.GetChild(tabIndex).GetComponent<ScrollRect>().verticalScrollbar = this.scrollbarOBJ;
			string key = "tabtitle" + this.tabsOrder[tabIndex].ToString();
			this.builderTitleTMP.text = LocalizationManager.instance.GetLocalizationString(key);
			this.oldTabIndex = tabIndex;
		}
		Transform transform = this.tabContainerOBJ.transform.GetChild(tabIndex).transform.Find("Container");
		foreach (object obj2 in transform)
		{
			((Transform)obj2).transform.Find("Highlight").gameObject.SetActive(false);
		}
		transform.transform.GetChild(elementIndex).transform.Find("Highlight").gameObject.SetActive(true);
		this.ScrollRectBehaviour(transform, elementIndex);
		if (tabIndex == 0 && (elementIndex == 0 || elementIndex == 1))
		{
			return;
		}
		this.currentPropIndex = transform.transform.GetChild(elementIndex).GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("PropIndex").Value;
		this.canPlace = false;
		if (tabIndex == 0)
		{
			Data_Container component = this.buildablesArray[this.currentPropIndex].GetComponent<Data_Container>();
			GameObject dummyPrefab = component.dummyPrefab;
			this.dummyOBJ = Object.Instantiate<GameObject>(dummyPrefab);
			this.buildableTag = component.buildableTag;
			this.buildableCost = (float)component.cost;
			this.isCool = false;
			this.pmakerFSM = this.dummyOBJ.GetComponent<PlayMakerFSM>();
			return;
		}
		BuildableInfo component2 = this.decorationPropsArray[this.currentPropIndex].GetComponent<BuildableInfo>();
		GameObject dummyPrefabOBJ = component2.dummyPrefabOBJ;
		this.dummyOBJ = Object.Instantiate<GameObject>(dummyPrefabOBJ);
		this.RetrieveBuilderInfo(component2);
		this.pmakerFSM = this.dummyOBJ.GetComponent<PlayMakerFSM>();
	}

	// Token: 0x06000149 RID: 329 RVA: 0x0000E7E8 File Offset: 0x0000C9E8
	private void RetrieveBuilderInfo(BuildableInfo bInfo)
	{
		this.minY = bInfo.minY;
		this.maxY = bInfo.maxY;
		this.raycastDirection = bInfo.raycastDirection;
		this.raycastOffset = bInfo.raycastOffset;
		this.buildableTags = bInfo.buildableTags;
		this.decorationCost = bInfo.cost;
		this.isCool = bInfo.isCool;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x0000E84C File Offset: 0x0000CA4C
	private void ScrollRectBehaviour(Transform containerTransform, int currentIndex)
	{
		if (currentIndex <= 10)
		{
			this.scrollbarOBJ.value = 1f;
			return;
		}
		int childCount = containerTransform.childCount;
		float value = (float)(currentIndex / childCount);
		value = Mathf.Clamp(value, 0f, 1f);
		this.scrollbarOBJ.value = value;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x0000E898 File Offset: 0x0000CA98
	private void MoveBehaviour()
	{
		if (!this.currentMovedOBJ && !this.recentlyMoved)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
			{
				if (raycastHit.transform.CompareTag("Movable"))
				{
					if (this.oldHitOBJ2 && raycastHit.transform.gameObject != this.oldHitOBJ2 && this.hEffect2)
					{
						this.hEffect2.highlighted = false;
					}
					this.hEffect2 = raycastHit.transform.GetComponent<HighlightEffect>();
					this.hEffect2.highlighted = true;
					this.oldHitOBJ2 = raycastHit.transform.gameObject;
					if (this.MainPlayer.GetButtonDown("Build"))
					{
						this.currentMovedOBJ = raycastHit.transform.gameObject;
						Data_Container component = this.currentMovedOBJ.GetComponent<Data_Container>();
						component.AddMoveEffect();
						this.buildableTag = component.buildableTag;
						GameObject dummyPrefab = component.dummyPrefab;
						this.dummyOBJ = Object.Instantiate<GameObject>(dummyPrefab, Vector3.zero, this.currentMovedOBJ.transform.rotation);
						this.canPlace = false;
						this.pmakerFSM = this.dummyOBJ.GetComponent<PlayMakerFSM>();
						if (this.hEffect2)
						{
							this.hEffect2.highlighted = false;
							return;
						}
					}
				}
				else if (raycastHit.transform.CompareTag("Decoration"))
				{
					if (this.oldHitOBJ && raycastHit.transform.gameObject != this.oldHitOBJ && this.hEffect)
					{
						this.hEffect.enabled = false;
					}
					this.hEffect = raycastHit.transform.Find("Mesh").GetComponent<HighlightEffect>();
					this.hEffect.enabled = true;
					this.oldHitOBJ = raycastHit.transform.gameObject;
					if (this.MainPlayer.GetButtonDown("Build"))
					{
						this.currentMovedOBJ = raycastHit.transform.gameObject;
						BuildableInfo component2 = this.currentMovedOBJ.GetComponent<BuildableInfo>();
						GameObject dummyPrefabOBJ = component2.dummyPrefabOBJ;
						this.dummyOBJ = Object.Instantiate<GameObject>(dummyPrefabOBJ, Vector3.zero, this.currentMovedOBJ.transform.rotation);
						this.RetrieveBuilderInfo(component2);
						this.canPlace = false;
						this.pmakerFSM = this.dummyOBJ.GetComponent<PlayMakerFSM>();
						if (this.hEffect)
						{
							this.hEffect.enabled = false;
							return;
						}
					}
				}
				else
				{
					if (this.hEffect)
					{
						this.hEffect.enabled = false;
					}
					if (this.hEffect2)
					{
						this.hEffect2.highlighted = false;
						return;
					}
				}
			}
			else
			{
				if (this.hEffect)
				{
					this.hEffect.enabled = false;
				}
				if (this.hEffect2)
				{
					this.hEffect2.highlighted = false;
				}
			}
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0000EBAC File Offset: 0x0000CDAC
	private void DeleteBehaviour()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
		{
			if (raycastHit.transform.gameObject.CompareTag("Movable"))
			{
				if (this.oldHitOBJ2 && raycastHit.transform.gameObject != this.oldHitOBJ2 && this.hEffect2)
				{
					this.hEffect2.highlighted = false;
				}
				this.hEffect2 = raycastHit.transform.GetComponent<HighlightEffect>();
				this.hEffect2.highlighted = true;
				if (this.MainPlayer.GetButtonDown("Build") || this.MainPlayer.GetButtonDown("Main Action") || this.MainPlayer.GetButtonDown("Secondary Action"))
				{
					if (GameData.Instance.isSupermarketOpen)
					{
						GameCanvas.Instance.CreateCanvasNotification("message15");
						return;
					}
					if (NPC_Manager.Instance.customersnpcParentOBJ.transform.childCount > 0)
					{
						GameCanvas.Instance.CreateCanvasNotification("message16");
						return;
					}
					if (this.FurnitureContainsProduct(raycastHit.transform))
					{
						GameCanvas.Instance.CreateCanvasNotification("message17");
						return;
					}
					if (raycastHit.transform.GetComponent<NetworkIdentity>())
					{
						float fundsToAdd = (float)raycastHit.transform.GetComponent<Data_Container>().cost * 0.9f;
						GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd);
						GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(raycastHit.transform.gameObject);
					}
				}
				this.oldHitOBJ2 = raycastHit.transform.gameObject;
			}
			else if (this.hEffect2)
			{
				this.hEffect2.highlighted = false;
			}
		}
		else if (this.hEffect2)
		{
			this.hEffect2.highlighted = false;
		}
		RaycastHit raycastHit2;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit2, 4f, this.lMask))
		{
			if (raycastHit2.transform.gameObject.CompareTag("Decoration"))
			{
				if (this.oldHitOBJ && raycastHit2.transform.gameObject != this.oldHitOBJ && this.hEffect)
				{
					this.hEffect.enabled = false;
				}
				this.hEffect = raycastHit2.transform.Find("Mesh").GetComponent<HighlightEffect>();
				this.hEffect.enabled = true;
				if ((this.MainPlayer.GetButtonDown("Build") || this.MainPlayer.GetButtonDown("Main Action") || this.MainPlayer.GetButtonDown("Secondary Action")) && raycastHit2.transform.GetComponent<NetworkIdentity>())
				{
					float fundsToAdd2 = raycastHit2.transform.GetComponent<BuildableInfo>().cost * 0.9f;
					GameData.Instance.CmdAlterFundsWithoutExperience(fundsToAdd2);
					GameData.Instance.GetComponent<NetworkSpawner>().CmdDestroyBox(raycastHit2.transform.gameObject);
				}
				this.oldHitOBJ = raycastHit2.transform.gameObject;
				return;
			}
			if (this.hEffect)
			{
				this.hEffect.enabled = false;
				return;
			}
		}
		else if (this.hEffect)
		{
			this.hEffect.enabled = false;
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0000EF2C File Offset: 0x0000D12C
	private bool FurnitureContainsProduct(Transform hitTransform)
	{
		if (hitTransform.GetComponent<Data_Container>())
		{
			int[] productInfoArray = hitTransform.GetComponent<Data_Container>().productInfoArray;
			int num = productInfoArray.Length / 2;
			for (int i = 0; i < num; i++)
			{
				if (productInfoArray[i * 2 + 1] > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600014E RID: 334 RVA: 0x0000EF74 File Offset: 0x0000D174
	private bool InCorrectBounds()
	{
		Vector3 position = this.dummyOBJ.transform.position;
		return position.x > -15.1f && position.x < 37f && position.z > -8.5f && position.z < 48f && position.y > this.minY && position.y < this.maxY;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x0000EFE8 File Offset: 0x0000D1E8
	private bool RaycastCheck()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(this.dummyOBJ.transform.position + this.dummyOBJ.transform.TransformDirection(this.raycastOffset), this.dummyOBJ.transform.TransformDirection(this.raycastDirection), out raycastHit, 0.15f, this.lMask))
		{
			if (this.buildableTags.Length == 0)
			{
				return true;
			}
			string tag = raycastHit.transform.gameObject.tag;
			string[] array = this.buildableTags;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == tag)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x0000F090 File Offset: 0x0000D290
	private bool CheckCorrectGround()
	{
		RaycastHit raycastHit;
		return Physics.Raycast(this.dummyOBJ.transform.position + new Vector3(0f, 0.1f, 0f), Vector3.down, out raycastHit, 0.2f, this.lMask) && raycastHit.transform.gameObject.tag == this.buildableTag;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x0000F105 File Offset: 0x0000D305
	private IEnumerator RetrieveInitialBehaviours()
	{
		yield return new WaitForSeconds(2f);
		this.cCameraController = Camera.main.GetComponent<CustomCameraController>();
		this.pComponent = FirstPersonController.Instance.GetComponent<PlayerPermissions>();
		this.buildablesArray = GameData.Instance.GetComponent<NetworkSpawner>().buildables;
		this.decorationPropsArray = GameData.Instance.GetComponent<NetworkSpawner>().decorationProps;
		this.initialConfiguration = true;
		yield break;
	}

	// Token: 0x04000159 RID: 345
	private bool initialConfiguration;

	// Token: 0x0400015A RID: 346
	public int[] tabsOrder;

	// Token: 0x0400015B RID: 347
	public GameObject canvasBuilderOBJ;

	// Token: 0x0400015C RID: 348
	public GameObject tabContainerOBJ;

	// Token: 0x0400015D RID: 349
	public TextMeshProUGUI builderTitleTMP;

	// Token: 0x0400015E RID: 350
	public Scrollbar scrollbarOBJ;

	// Token: 0x0400015F RID: 351
	public LayerMask lMask;

	// Token: 0x04000160 RID: 352
	private GameObject[] buildablesArray;

	// Token: 0x04000161 RID: 353
	private GameObject[] decorationPropsArray;

	// Token: 0x04000162 RID: 354
	private Player MainPlayer;

	// Token: 0x04000163 RID: 355
	private CustomCameraController cCameraController;

	// Token: 0x04000164 RID: 356
	private PlayerPermissions pComponent;

	// Token: 0x04000165 RID: 357
	private GameObject dummyOBJ;

	// Token: 0x04000166 RID: 358
	private int currentTabIndex;

	// Token: 0x04000167 RID: 359
	private int oldTabIndex = -1;

	// Token: 0x04000168 RID: 360
	private int currentElementIndex;

	// Token: 0x04000169 RID: 361
	private int currentPropIndex;

	// Token: 0x0400016A RID: 362
	private bool inCorrectBounds;

	// Token: 0x0400016B RID: 363
	private bool overlapping;

	// Token: 0x0400016C RID: 364
	private bool raycastIsCorrect;

	// Token: 0x0400016D RID: 365
	private bool correctSector;

	// Token: 0x0400016E RID: 366
	private bool canPlace;

	// Token: 0x0400016F RID: 367
	private string buildableTag;

	// Token: 0x04000170 RID: 368
	private float buildableCost;

	// Token: 0x04000171 RID: 369
	private float minY;

	// Token: 0x04000172 RID: 370
	private float maxY;

	// Token: 0x04000173 RID: 371
	private Vector3 raycastDirection;

	// Token: 0x04000174 RID: 372
	private Vector3 raycastOffset;

	// Token: 0x04000175 RID: 373
	private string[] buildableTags;

	// Token: 0x04000176 RID: 374
	private float decorationCost;

	// Token: 0x04000177 RID: 375
	private PlayMakerFSM pmakerFSM;

	// Token: 0x04000178 RID: 376
	private bool isCool;

	// Token: 0x04000179 RID: 377
	private HighlightEffect hEffect;

	// Token: 0x0400017A RID: 378
	private HighlightEffect hEffect2;

	// Token: 0x0400017B RID: 379
	private GameObject oldHitOBJ;

	// Token: 0x0400017C RID: 380
	private GameObject oldHitOBJ2;

	// Token: 0x0400017D RID: 381
	private GameObject currentMovedOBJ;

	// Token: 0x0400017E RID: 382
	private bool recentlyMoved;
}

using System;
using System.Collections;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000044 RID: 68
public class Builder_Paintables : MonoBehaviour
{
	// Token: 0x06000159 RID: 345 RVA: 0x0000F1DC File Offset: 0x0000D3DC
	private void Start()
	{
		base.transform.Find("Canvas").gameObject.SetActive(true);
		this.materialsParentOBJ = base.transform.Find("Canvas/Container/ScrollArea/BCK").gameObject;
		this.UIcolorParentOBJ = base.transform.Find("Canvas/Container/BCK_2").gameObject;
		this.UIcolorParentOBJ.GetComponent<CanvasGroup>().alpha = 0.25f;
		this.MainPlayer = ReInput.players.GetPlayer(this.playerId);
		this.scrollstep = 1f / Mathf.Ceil((float)(this.materialsParentOBJ.transform.childCount / 5));
		this.paintablesDataParentOBJ = GameCanvas.Instance.paintablesReference;
		this.GetCurrentMaterialData(0);
		this.SetPricesAndNumbers();
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0000F2A6 File Offset: 0x0000D4A6
	private void AuxiliarDestroyFromHere(GameObject hitOBJ)
	{
		if (hitOBJ == null)
		{
			return;
		}
		if (hitOBJ.GetComponent<PaintableAuxiliarHighlight>())
		{
			hitOBJ.GetComponent<PaintableAuxiliarHighlight>().DestroyBehaviours();
		}
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000F2CC File Offset: 0x0000D4CC
	private void Update()
	{
		if (this.isCoroutineRunning)
		{
			return;
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask) && this.inColorMenu)
		{
			GameObject gameObject = raycastHit.transform.gameObject;
			if (gameObject.transform.parent != null && gameObject.transform.parent.GetComponent<Paintable>())
			{
				if (!gameObject.GetComponent<PaintableAuxiliarHighlight>())
				{
					gameObject.AddComponent<PaintableAuxiliarHighlight>();
					this.currentRaycastedOBJ = gameObject;
				}
			}
			else
			{
				this.AuxiliarDestroyFromHere(this.currentRaycastedOBJ);
				this.currentRaycastedOBJ = null;
			}
		}
		else
		{
			this.AuxiliarDestroyFromHere(this.currentRaycastedOBJ);
			this.currentRaycastedOBJ = null;
		}
		if (this.MainPlayer.GetButtonDown("Main Action"))
		{
			if (this.inColorMenu)
			{
				if (this.currentRaycastedOBJ)
				{
					MeshRenderer component = this.currentRaycastedOBJ.GetComponent<MeshRenderer>();
					Color color = component.material.GetColor("_BaseColor");
					string name = component.sharedMaterial.name;
					string name2 = this.currentMaterial.name;
					int siblingIndex = this.currentRaycastedOBJ.transform.GetSiblingIndex();
					int siblingIndex2 = this.currentRaycastedOBJ.transform.parent.transform.GetSiblingIndex();
					if (name.Contains(name2))
					{
						if (!(this.currentColor != color))
						{
							return;
						}
						if (GameData.Instance.gameFunds >= this.currentPrice * 0.3f)
						{
							GameData.Instance.CmdAlterFunds(-(this.currentPrice * 0.3f));
							this.CreateParticlePoof();
							GameData.Instance.GetComponent<PaintablesManager>().CmdUpdateSingleParentMaterial(siblingIndex2, siblingIndex, this.currentIndex, this.currentColorIndex);
						}
						else
						{
							GameCanvas.Instance.CreateCanvasNotification("message6");
						}
					}
					else if (GameData.Instance.gameFunds >= this.currentPrice)
					{
						GameData.Instance.CmdAlterFunds(-this.currentPrice);
						this.CreateParticlePoof();
						GameData.Instance.GetComponent<PaintablesManager>().CmdUpdateSingleParentMaterial(siblingIndex2, siblingIndex, this.currentIndex, this.currentColorIndex);
					}
					else
					{
						GameCanvas.Instance.CreateCanvasNotification("message6");
					}
				}
			}
			else
			{
				this.UIcolorParentOBJ.GetComponent<CanvasGroup>().alpha = 1f;
				this.materialsParentOBJ.GetComponent<CanvasGroup>().alpha = 0.25f;
				this.inColorMenu = true;
			}
		}
		else if (this.MainPlayer.GetButtonDown("Secondary Action"))
		{
			this.UIcolorParentOBJ.GetComponent<CanvasGroup>().alpha = 0.25f;
			this.materialsParentOBJ.GetComponent<CanvasGroup>().alpha = 1f;
			this.inColorMenu = false;
		}
		if (!this.MainPlayer.GetButtonDown("Menu Next"))
		{
			if (this.MainPlayer.GetButtonDown("Menu Previous"))
			{
				if (this.inColorMenu)
				{
					this.currentColorIndex++;
					if (this.currentColorIndex >= this.currentColorArray.Length)
					{
						this.currentColorIndex = 0;
					}
					this.SetColorData(this.currentColorIndex);
					return;
				}
				this.currentIndex++;
				if (this.currentIndex >= this.paintablesDataParentOBJ.transform.childCount)
				{
					this.currentIndex = 0;
				}
				this.GetCurrentMaterialData(this.currentIndex);
			}
			return;
		}
		if (this.inColorMenu)
		{
			this.currentColorIndex--;
			if (this.currentColorIndex < 0)
			{
				this.currentColorIndex = this.currentColorArray.Length - 1;
			}
			this.SetColorData(this.currentColorIndex);
			return;
		}
		this.currentIndex--;
		if (this.currentIndex < 0)
		{
			this.currentIndex = this.paintablesDataParentOBJ.transform.childCount - 1;
		}
		this.GetCurrentMaterialData(this.currentIndex);
	}

	// Token: 0x0600015C RID: 348 RVA: 0x0000F694 File Offset: 0x0000D894
	private void CreateParticlePoof()
	{
		Object.Instantiate<GameObject>(this.particlePrefab, this.currentRaycastedOBJ.transform.position, Random.rotation);
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
	private void SetPricesAndNumbers()
	{
		for (int i = 0; i < this.paintablesDataParentOBJ.transform.childCount; i++)
		{
			float price = this.paintablesDataParentOBJ.transform.GetChild(i).GetComponent<PaintableData>().price;
			this.materialsParentOBJ.transform.GetChild(i).transform.Find("Price").GetComponent<TextMeshProUGUI>().text = "$" + price.ToString();
			this.materialsParentOBJ.transform.GetChild(i).transform.Find("MaterialNumber").GetComponent<TextMeshProUGUI>().text = i.ToString();
		}
	}

	// Token: 0x0600015E RID: 350 RVA: 0x0000F770 File Offset: 0x0000D970
	private void GetCurrentMaterialData(int materialIndex)
	{
		if (materialIndex < this.paintablesDataParentOBJ.transform.childCount)
		{
			PaintableData component = this.paintablesDataParentOBJ.transform.GetChild(materialIndex).GetComponent<PaintableData>();
			foreach (object obj in this.materialsParentOBJ.transform)
			{
				((Transform)obj).transform.Find("Highlight").gameObject.SetActive(false);
			}
			this.materialsParentOBJ.transform.GetChild(materialIndex).transform.Find("Highlight").gameObject.SetActive(true);
			this.currentMaterial = component.material;
			this.currentPrice = component.price;
			if (component.allowCustomColors)
			{
				this.currentColorArray = this.paintablesDataParentOBJ.GetComponent<PaintableData>().ColorArray;
			}
			else
			{
				this.currentColorArray = component.ColorArray;
			}
			this.currentColorIndex = 0;
			if (this.currentColorArray.Length != 0)
			{
				this.ClearExistingColors();
				if (!this.isCoroutineRunning)
				{
					base.StartCoroutine(this.DelayColor());
				}
			}
			else
			{
				this.ClearExistingColors();
				this.currentColor = Color.white;
			}
			this.materialNameTMP.text = LocalizationManager.instance.GetLocalizationString("paintmat" + materialIndex.ToString());
			this.SetScrollbarStep(materialIndex);
			return;
		}
	}

	// Token: 0x0600015F RID: 351 RVA: 0x0000F8E8 File Offset: 0x0000DAE8
	private void SetScrollbarStep(int index)
	{
		float num = (float)index / ((float)this.materialsParentOBJ.transform.childCount - 1f);
		int num2 = Mathf.CeilToInt((float)(this.materialsParentOBJ.transform.childCount / 5));
		float num3 = 0f;
		for (int i = 1; i < num2; i++)
		{
			num3 = this.scrollstep * (float)i;
			if (num < num3)
			{
				break;
			}
		}
		if (num3 < 0.8f)
		{
			if (num3 >= 0.55f)
			{
				num3 -= this.scrollstep;
			}
			else
			{
				num3 -= this.scrollstep * 2f;
			}
		}
		float value = 1f - num3;
		value = Mathf.Clamp(value, 0f, 1f);
		this.scrollbarOBJ.GetComponent<Scrollbar>().value = value;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x0000F9A4 File Offset: 0x0000DBA4
	private void ClearExistingColors()
	{
		if (this.UIcolorParentOBJ.transform.childCount == 0)
		{
			return;
		}
		for (int i = 0; i < this.UIcolorParentOBJ.transform.childCount; i++)
		{
			Object.Destroy(this.UIcolorParentOBJ.transform.GetChild(this.UIcolorParentOBJ.transform.childCount - 1 - i).gameObject);
		}
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0000FA0D File Offset: 0x0000DC0D
	private IEnumerator DelayColor()
	{
		this.isCoroutineRunning = true;
		foreach (Color color in this.currentColorArray)
		{
			Object.Instantiate<GameObject>(this.UIColorPrefab, this.UIcolorParentOBJ.transform).GetComponent<Image>().color = color;
		}
		yield return null;
		this.SetColorData(0);
		this.isCoroutineRunning = false;
		yield break;
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0000FA1C File Offset: 0x0000DC1C
	private void SetColorData(int colorIndex)
	{
		this.currentColor = this.currentColorArray[colorIndex];
		foreach (object obj in this.UIcolorParentOBJ.transform)
		{
			((Transform)obj).transform.Find("Highlight").gameObject.SetActive(false);
		}
		this.UIcolorParentOBJ.transform.GetChild(colorIndex).transform.Find("Highlight").gameObject.SetActive(true);
	}

	// Token: 0x04000182 RID: 386
	[SerializeField]
	private LayerMask lMask;

	// Token: 0x04000183 RID: 387
	[SerializeField]
	private GameObject UIColorPrefab;

	// Token: 0x04000184 RID: 388
	[SerializeField]
	private GameObject particlePrefab;

	// Token: 0x04000185 RID: 389
	[SerializeField]
	private GameObject scrollbarOBJ;

	// Token: 0x04000186 RID: 390
	[SerializeField]
	private TextMeshProUGUI materialNameTMP;

	// Token: 0x04000187 RID: 391
	private int currentIndex;

	// Token: 0x04000188 RID: 392
	private int currentColorIndex;

	// Token: 0x04000189 RID: 393
	private float scrollstep;

	// Token: 0x0400018A RID: 394
	private Player MainPlayer;

	// Token: 0x0400018B RID: 395
	private int playerId;

	// Token: 0x0400018C RID: 396
	private GameObject paintablesDataParentOBJ;

	// Token: 0x0400018D RID: 397
	private GameObject materialsParentOBJ;

	// Token: 0x0400018E RID: 398
	private GameObject UIcolorParentOBJ;

	// Token: 0x0400018F RID: 399
	private GameObject currentRaycastedOBJ;

	// Token: 0x04000190 RID: 400
	private Material currentMaterial;

	// Token: 0x04000191 RID: 401
	private float currentPrice;

	// Token: 0x04000192 RID: 402
	private Color[] currentColorArray;

	// Token: 0x04000193 RID: 403
	private Color currentColor;

	// Token: 0x04000194 RID: 404
	private bool inColorMenu;

	// Token: 0x04000195 RID: 405
	private bool isCoroutineRunning;
}

using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class CamMouseOrbit : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Awake()
	{
		this.ChangeCursor();
		this.dist = this.distance;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002064 File Offset: 0x00000264
	private void Start()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		this.x = eulerAngles.y;
		this.y = eulerAngles.x;
		if (base.GetComponent<Rigidbody>())
		{
			base.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020AE File Offset: 0x000002AE
	private void ChangeCursor()
	{
		Cursor.lockState = (this.locked ? CursorLockMode.None : CursorLockMode.Locked);
		Cursor.visible = this.locked;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020CC File Offset: 0x000002CC
	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			this.locked = !this.locked;
			this.ChangeCursor();
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000020EC File Offset: 0x000002EC
	private void FixedUpdate()
	{
		if (!this.target || this.locked)
		{
			return;
		}
		this.x += Input.GetAxis("Mouse X") * this.xSpeed;
		this.y -= Input.GetAxis("Mouse Y") * this.ySpeed;
		this.distance -= Input.GetAxis("Mouse ScrollWheel") * this.distSpeed;
		this.y = this.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
		this.distance = Mathf.Clamp(this.distance, this.distMinLimit, this.distMaxLimit);
		this.dist = Mathf.Lerp(this.dist, this.distance, this.distDamping * Time.deltaTime);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.Euler(this.y, this.x, 0f), Time.deltaTime * this.orbitDamping);
		base.transform.position = base.transform.rotation * new Vector3(0f, 0f, -this.dist) + this.target.position;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002248 File Offset: 0x00000448
	private float ClampAngle(float a, float min, float max)
	{
		while (max < min)
		{
			max += 360f;
		}
		while (a > max)
		{
			a -= 360f;
		}
		while (a < min)
		{
			a += 360f;
		}
		if (a <= max)
		{
			return a;
		}
		if ((double)a - (double)(max + min) * 0.5 < 180.0)
		{
			return max;
		}
		return min;
	}

	// Token: 0x04000001 RID: 1
	private float x;

	// Token: 0x04000002 RID: 2
	private float y;

	// Token: 0x04000003 RID: 3
	private float dist;

	// Token: 0x04000004 RID: 4
	private bool locked;

	// Token: 0x04000005 RID: 5
	public Transform target;

	// Token: 0x04000006 RID: 6
	public float distance = 10f;

	// Token: 0x04000007 RID: 7
	public float xSpeed = 5f;

	// Token: 0x04000008 RID: 8
	public float ySpeed = 2.5f;

	// Token: 0x04000009 RID: 9
	public float distSpeed = 10f;

	// Token: 0x0400000A RID: 10
	public float yMinLimit = -20f;

	// Token: 0x0400000B RID: 11
	public float yMaxLimit = 80f;

	// Token: 0x0400000C RID: 12
	public float distMinLimit = 5f;

	// Token: 0x0400000D RID: 13
	public float distMaxLimit = 50f;

	// Token: 0x0400000E RID: 14
	public float orbitDamping = 4f;

	// Token: 0x0400000F RID: 15
	public float distDamping = 4f;
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020000D8 RID: 216
public class ChatController : MonoBehaviour
{
	// Token: 0x06000739 RID: 1849 RVA: 0x0002D87B File Offset: 0x0002BA7B
	private void OnEnable()
	{
		this.ChatInputField.onSubmit.AddListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x0002D899 File Offset: 0x0002BA99
	private void OnDisable()
	{
		this.ChatInputField.onSubmit.RemoveListener(new UnityAction<string>(this.AddToChatOutput));
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x0002D8B8 File Offset: 0x0002BAB8
	private void AddToChatOutput(string newText)
	{
		this.ChatInputField.text = string.Empty;
		DateTime now = DateTime.Now;
		string text = string.Concat(new string[]
		{
			"[<#FFFF80>",
			now.Hour.ToString("d2"),
			":",
			now.Minute.ToString("d2"),
			":",
			now.Second.ToString("d2"),
			"</color>] ",
			newText
		});
		if (this.ChatDisplayOutput != null)
		{
			if (this.ChatDisplayOutput.text == string.Empty)
			{
				this.ChatDisplayOutput.text = text;
			}
			else
			{
				TMP_Text chatDisplayOutput = this.ChatDisplayOutput;
				chatDisplayOutput.text = chatDisplayOutput.text + "\n" + text;
			}
		}
		this.ChatInputField.ActivateInputField();
		this.ChatScrollbar.value = 0f;
	}

	// Token: 0x040005AB RID: 1451
	public TMP_InputField ChatInputField;

	// Token: 0x040005AC RID: 1452
	public TMP_Text ChatDisplayOutput;

	// Token: 0x040005AD RID: 1453
	public Scrollbar ChatScrollbar;
}

using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000046 RID: 70
public class ColorPicker : MonoBehaviour
{
	// Token: 0x0600016A RID: 362 RVA: 0x0000FB7C File Offset: 0x0000DD7C
	public Color GetPixelColor()
	{
		this.tex = (this.ColorPallete.texture as Texture2D);
		this.r = this.ColorPallete.rectTransform.rect;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.ColorPallete.rectTransform, Input.mousePosition, null, out this.localPoint);
		if (this.localPoint.x > this.r.x && this.localPoint.y > this.r.y && this.localPoint.x < this.r.width + this.r.x && this.localPoint.y < this.r.height + this.r.y)
		{
			this.px = Mathf.Clamp(0, (int)((this.localPoint.x - this.r.x) * (float)this.tex.width / this.r.width), this.tex.width);
			this.py = Mathf.Clamp(0, (int)((this.localPoint.y - this.r.y) * (float)this.tex.height / this.r.height), this.tex.height);
			this.col = this.tex.GetPixel(this.px, this.py);
			return this.col;
		}
		return Color.black;
	}

	// Token: 0x04000199 RID: 409
	public RawImage ColorPallete;

	// Token: 0x0400019A RID: 410
	private Texture2D tex;

	// Token: 0x0400019B RID: 411
	private Color32 col;

	// Token: 0x0400019C RID: 412
	private Rect r;

	// Token: 0x0400019D RID: 413
	private Vector2 localPoint;

	// Token: 0x0400019E RID: 414
	private int px;

	// Token: 0x0400019F RID: 415
	private int py;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000014 RID: 20
public static class CommonUtils
{
	// Token: 0x0600004E RID: 78 RVA: 0x00006578 File Offset: 0x00004778
	public static int[] GetRandomPrefabIndexes(int numRequired, ref GameObject[] peoplePrefabs)
	{
		List<int> list = new List<int>();
		List<GameObject> list2 = new List<GameObject>(peoplePrefabs);
		list2.Shuffle<GameObject>();
		peoplePrefabs = list2.ToArray();
		int i = 0;
		int num = 0;
		while (i < numRequired)
		{
			List<int> list3 = list;
			int item;
			if (num >= peoplePrefabs.Length)
			{
				item = (num = 0);
			}
			else
			{
				num = (item = num) + 1;
			}
			list3.Add(item);
			i++;
		}
		list.Shuffle<int>();
		return list.ToArray();
	}
}

using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
public class CopyPasteClipboard : MonoBehaviour
{
	// Token: 0x0600016C RID: 364 RVA: 0x0000FD1E File Offset: 0x0000DF1E
	public void CopyToClipboard(string str)
	{
		GUIUtility.systemCopyBuffer = str;
	}

	// Token: 0x0600016D RID: 365 RVA: 0x0000FD26 File Offset: 0x0000DF26
	public string PasteFromClipboard()
	{
		return GUIUtility.systemCopyBuffer;
	}
}

using System;
using Cinemachine;
using HutongGames.PlayMaker;
using Rewired;
using StarterAssets;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x020000A4 RID: 164
public class CustomCameraController : MonoBehaviour
{
	// Token: 0x060005A0 RID: 1440 RVA: 0x00026B94 File Offset: 0x00024D94
	private void Start()
	{
		this.initialMask = base.GetComponent<Camera>().cullingMask;
		this.MainPlayer = ReInput.players.GetPlayer(this.playerId);
		this.IsInOptions = false;
		this.thirdPersonFollow = this.cineVCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x00026BE8 File Offset: 0x00024DE8
	private void LateUpdate()
	{
		if (!this.masterPlayerOBJ)
		{
			this.masterPlayerOBJ = FsmVariables.GlobalVariables.FindFsmGameObject("MasterPlayerOBJ").Value;
			return;
		}
		if (!this.cinemachineOBJ)
		{
			this.cinemachineOBJ = this.masterPlayerOBJ.transform.Find("Viewpoint_Pivot/Viewpoint").gameObject;
			this.cineVCamera.Follow = this.cinemachineOBJ.transform;
			this.cineVCamera.LookAt = this.cinemachineOBJ.transform;
			return;
		}
		this.IsInOptions = FsmVariables.GlobalVariables.FindFsmBool("InOptions").Value;
		if (this.IsInOptions)
		{
			return;
		}
		if (this.isInCameraEvent)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				this.RestoreCamera();
			}
			return;
		}
		if (this.inVehicle)
		{
			if (this.vehicleOBJ)
			{
				float num = this.vehicleOBJ.localEulerAngles.y;
				this.masterPlayerOBJ.transform.rotation = Quaternion.Euler(0f, num, 0f);
				this.cinemachineOBJ.transform.localRotation = Quaternion.Euler(22f, 0f, 0f);
			}
			return;
		}
		this.x += this.MainPlayer.GetAxis("MouseX") * this.baseXSpeed * this.XSensitivity * 0.02f;
		this.y -= this.MainPlayer.GetAxis("MouseY") * this.baseYSpeed * this.YSensitivity * 0.02f;
		Quaternion rotation = Quaternion.Euler(0f, this.x, 0f);
		this.masterPlayerOBJ.transform.rotation = rotation;
		this.y = CustomCameraController.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
		Quaternion localRotation = Quaternion.Euler(this.y, 0f, 0f);
		this.cinemachineOBJ.transform.localRotation = localRotation;
		if (this.inEmoteEvent)
		{
			float num2 = Mathf.Abs(this.MainPlayer.GetAxisRaw("MoveV"));
			float num3 = Mathf.Abs(this.MainPlayer.GetAxisRaw("MoveH"));
			if (num2 > 0.1f || num3 > 0.1f || this.MainPlayer.GetButton("Jump"))
			{
				this.thirdPersonFollow.CameraDistance = 0f;
				this.thirdPersonFollow.CameraCollisionFilter = this.thirdPersonNullLayerMask;
				this.ShowCharacter(false);
				this.inEmoteEvent = false;
			}
		}
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00026E6D File Offset: 0x0002506D
	public void ThirdPersonEmoteVisualize()
	{
		if (this.isInCameraEvent)
		{
			return;
		}
		this.inEmoteEvent = true;
		this.thirdPersonFollow.CameraDistance = 2f;
		this.thirdPersonFollow.CameraCollisionFilter = this.thirdPersonDefaultLayerMask;
		this.ShowCharacter(true);
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x00026EA8 File Offset: 0x000250A8
	private void ShowCharacter(bool set)
	{
		if (FirstPersonController.Instance)
		{
			if (FirstPersonController.Instance.transform.Find("Character/CharacterMesh").gameObject)
			{
				GameObject gameObject = FirstPersonController.Instance.transform.Find("Character/CharacterMesh").gameObject;
				if (set)
				{
					gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
				}
				else
				{
					gameObject.GetComponent<SkinnedMeshRenderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
				}
			}
			PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();
			if (component.hatOBJ)
			{
				if (set)
				{
					component.hatOBJ.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
					return;
				}
				component.hatOBJ.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
			}
		}
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00026F59 File Offset: 0x00025159
	public void ChangeLayerMask(bool set)
	{
		if (set)
		{
			base.GetComponent<Camera>().cullingMask = this.highlightMask;
			return;
		}
		base.GetComponent<Camera>().cullingMask = this.initialMask;
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x00026F8C File Offset: 0x0002518C
	public void CameraEvent(GameObject newViewpointOBJ)
	{
		this.isInCameraEvent = true;
		this.oldFOV = this.cineVCamera.m_Lens.FieldOfView;
		this.cineVCamera.m_Lens.FieldOfView = 60f;
		base.GetComponent<Camera>().cullingMask = this.cameraEventMask;
		this.cineVCamera.Follow = newViewpointOBJ.transform;
		this.cineVCamera.LookAt = newViewpointOBJ.transform;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		if (FirstPersonController.Instance)
		{
			FirstPersonController.Instance.inCameraEvent = true;
		}
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x00027028 File Offset: 0x00025228
	public void RestoreCamera()
	{
		this.isInCameraEvent = false;
		base.GetComponent<Camera>().cullingMask = this.initialMask;
		this.cineVCamera.Follow = this.cinemachineOBJ.transform;
		this.cineVCamera.LookAt = this.cinemachineOBJ.transform;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		this.oldFOV = Mathf.Clamp(this.oldFOV, 30f, 120f);
		this.cineVCamera.m_Lens.FieldOfView = this.oldFOV;
		if (FirstPersonController.Instance)
		{
			FirstPersonController.Instance.inCameraEvent = false;
		}
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x000270D2 File Offset: 0x000252D2
	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x04000482 RID: 1154
	public float baseXSpeed = 10f;

	// Token: 0x04000483 RID: 1155
	public float baseYSpeed = 10f;

	// Token: 0x04000484 RID: 1156
	public float smoothSpeed = 1f;

	// Token: 0x04000485 RID: 1157
	[Space(10f)]
	public float XSensitivity = 1f;

	// Token: 0x04000486 RID: 1158
	public float YSensitivity = 1f;

	// Token: 0x04000487 RID: 1159
	[Space(10f)]
	public float yMinLimit = 10f;

	// Token: 0x04000488 RID: 1160
	public float yMaxLimit = 80f;

	// Token: 0x04000489 RID: 1161
	[Space(10f)]
	public int playerId;

	// Token: 0x0400048A RID: 1162
	public CinemachineVirtualCamera cineVCamera;

	// Token: 0x0400048B RID: 1163
	private Cinemachine3rdPersonFollow thirdPersonFollow;

	// Token: 0x0400048C RID: 1164
	private float x;

	// Token: 0x0400048D RID: 1165
	private float y;

	// Token: 0x0400048E RID: 1166
	private GameObject cinemachineOBJ;

	// Token: 0x0400048F RID: 1167
	private GameObject masterPlayerOBJ;

	// Token: 0x04000490 RID: 1168
	private Player MainPlayer;

	// Token: 0x04000491 RID: 1169
	private bool IsInOptions;

	// Token: 0x04000492 RID: 1170
	private float oldFOV;

	// Token: 0x04000493 RID: 1171
	public bool isAiming;

	// Token: 0x04000494 RID: 1172
	public bool inVehicle;

	// Token: 0x04000495 RID: 1173
	public Transform vehicleOBJ;

	// Token: 0x04000496 RID: 1174
	public LayerMask highlightMask;

	// Token: 0x04000497 RID: 1175
	public LayerMask cameraEventMask;

	// Token: 0x04000498 RID: 1176
	private LayerMask initialMask;

	// Token: 0x04000499 RID: 1177
	private LayerMask thirdPersonNullLayerMask;

	// Token: 0x0400049A RID: 1178
	public LayerMask thirdPersonDefaultLayerMask;

	// Token: 0x0400049B RID: 1179
	public bool isInCameraEvent;

	// Token: 0x0400049C RID: 1180
	public bool inEmoteEvent;
}

using System;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using Mirror;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000073 RID: 115
public class CustomNetworkManager : NetworkManager
{
	// Token: 0x1700004F RID: 79
	// (get) Token: 0x06000371 RID: 881 RVA: 0x00019A46 File Offset: 0x00017C46
	public List<PlayerObjectController> GamePlayers { get; } = new List<PlayerObjectController>();

	// Token: 0x06000372 RID: 882 RVA: 0x00019A50 File Offset: 0x00017C50
	public override void OnServerAddPlayer(NetworkConnectionToClient conn)
	{
		if (SceneManager.GetActiveScene().name == "B_Main")
		{
			PlayerObjectController playerObjectController = Object.Instantiate<PlayerObjectController>(this.GamePlayerPrefab);
			playerObjectController.transform.position = new Vector3(5f + Random.Range(-2f, 2f), 0f, -20.5f + Random.Range(-2f, 2f));
			playerObjectController.NetworkConnectionID = conn.connectionId;
			playerObjectController.NetworkPlayerIdNumber = this.GamePlayers.Count + 1;
			if (base.name != "LocalNetworkManager")
			{
				playerObjectController.NetworkPlayerSteamID = (ulong)SteamMatchmaking.GetLobbyMemberByIndex((CSteamID)SteamLobby.Instance.CurrentLobbyID, this.GamePlayers.Count);
			}
			NetworkServer.AddPlayerForConnection(conn, playerObjectController.gameObject);
			this.numberOfPlayers = NetworkServer.connections.Count;
		}
	}

	// Token: 0x06000373 RID: 883 RVA: 0x00019B3C File Offset: 0x00017D3C
	public override void OnServerDisconnect(NetworkConnectionToClient conn)
	{
		base.OnServerDisconnect(conn);
		this.numberOfPlayers = NetworkServer.connections.Count;
		if (base.GetComponent<SteamLobby>())
		{
			base.GetComponent<SteamLobby>().ClosedLobbyListener();
		}
	}

	// Token: 0x06000374 RID: 884 RVA: 0x00019B70 File Offset: 0x00017D70
	public override void OnClientDisconnect()
	{
		base.OnClientDisconnect();
		GameObject value = FsmVariables.GlobalVariables.FindFsmGameObject("MasterOBJ").Value;
		if (!value.GetComponent<MasterLobbyData>().isHost)
		{
			value.transform.Find("MasterCanvas/HostDisconnect").gameObject.SetActive(true);
		}
	}

	// Token: 0x06000375 RID: 885 RVA: 0x00019BC0 File Offset: 0x00017DC0
	public int GetReturnConnections()
	{
		return NetworkServer.connections.Count;
	}

	// Token: 0x06000376 RID: 886 RVA: 0x00019BCC File Offset: 0x00017DCC
	public void LocalHost()
	{
		this.networkAddress = "localhost";
		base.StartHost();
		Debug.Log("Local host started from Manager");
	}

	// Token: 0x06000377 RID: 887 RVA: 0x00019BE9 File Offset: 0x00017DE9
	public void LocalJoin()
	{
		this.networkAddress = "localhost";
		base.StartClient();
		Debug.Log("Local join started from Manager");
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00019C06 File Offset: 0x00017E06
	public void LocalHostDisconnect()
	{
		base.StopHost();
		Debug.Log("Host stopped");
	}

	// Token: 0x040002FB RID: 763
	public int numberOfPlayers;

	// Token: 0x040002FC RID: 764
	[SerializeField]
	private PlayerObjectController GamePlayerPrefab;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class DataMakerCore
{
	// Token: 0x060000BA RID: 186 RVA: 0x00008B98 File Offset: 0x00006D98
	public static DataMakerProxyBase GetDataMakerProxyPointer<T>(T type, GameObject aProxy, string nameReference, bool silent)
	{
		if (aProxy == null)
		{
			if (!silent)
			{
				Debug.LogError("Null Proxy");
			}
			return null;
		}
		DataMakerProxyBase[] array = aProxy.GetComponents<DataMakerProxyBase>();
		List<DataMakerProxyBase> list = new List<DataMakerProxyBase>();
		foreach (DataMakerProxyBase dataMakerProxyBase in array)
		{
			if (dataMakerProxyBase.GetType().Equals(type))
			{
				list.Add(dataMakerProxyBase);
			}
		}
		array = list.ToArray();
		if (array.Length > 1)
		{
			if (nameReference == "" && !silent)
			{
				string str = "Several ";
				T t = type;
				string str2 = (t != null) ? t.ToString() : null;
				string str3 = " coexists on the same GameObject and no reference is given to find the expected ";
				t = type;
				Debug.LogError(str + str2 + str3 + ((t != null) ? t.ToString() : null));
			}
			foreach (DataMakerProxyBase dataMakerProxyBase2 in array)
			{
				if (dataMakerProxyBase2.referenceName == nameReference)
				{
					return dataMakerProxyBase2;
				}
			}
			if (nameReference != "")
			{
				if (!silent)
				{
					T t = type;
					Debug.LogError(((t != null) ? t.ToString() : null) + " not found for reference <" + nameReference + ">");
				}
				return null;
			}
		}
		else if (array.Length != 0)
		{
			if (nameReference != "" && nameReference != array[0].referenceName)
			{
				if (!silent)
				{
					T t = type;
					Debug.LogError(((t != null) ? t.ToString() : null) + " reference do not match");
				}
				return null;
			}
			return array[0];
		}
		if (!silent)
		{
			T t = type;
			Debug.LogError(((t != null) ? t.ToString() : null) + " not found");
		}
		return null;
	}
}

using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
public abstract class DataMakerProxyBase : MonoBehaviour
{
	// Token: 0x04000119 RID: 281
	public string referenceName = "";
}

using System;
using UnityEngine;

// Token: 0x0200002B RID: 43
public class DataMakerXmlNodeListProxy : DataMakerProxyBase
{
	// Token: 0x04000109 RID: 265
	[HideInInspector]
	public FsmXmlNodeList _FsmXmlNodeList;
}

using System;
using UnityEngine;

// Token: 0x0200002C RID: 44
public class DataMakerXmlNodeProxy : DataMakerProxyBase
{
	// Token: 0x0400010A RID: 266
	[HideInInspector]
	public FsmXmlNode _FsmXmlNode;
}

using System;
using System.Xml;
using UnityEngine;

// Token: 0x0200002D RID: 45
public class DataMakerXmlProxy : DataMakerProxyBase
{
	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000098 RID: 152 RVA: 0x000085D0 File Offset: 0x000067D0
	// (set) Token: 0x06000099 RID: 153 RVA: 0x000085D8 File Offset: 0x000067D8
	[HideInInspector]
	public XmlNode xmlNode
	{
		get
		{
			return this._xmlNode;
		}
		set
		{
			this._xmlNode = value;
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x000085E1 File Offset: 0x000067E1
	private void Awake()
	{
		if (this.useSource && this.XmlTextAsset != null)
		{
			this.InjectXmlString(this.XmlTextAsset.text);
		}
		this.RegisterEventHandlers();
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00008610 File Offset: 0x00006810
	public void RefreshStringVersion()
	{
		this.content = DataMakerXmlUtils.XmlNodeToString(this.xmlNode);
		this.isDirty = true;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000862A File Offset: 0x0000682A
	public void InjectXmlNode(XmlNode node)
	{
		this.xmlNode = node;
		this.RegisterEventHandlers();
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000863C File Offset: 0x0000683C
	public void InjectXmlNodeList(XmlNodeList nodeList)
	{
		XmlDocument xmlDocument = new XmlDocument();
		this.xmlNode = xmlDocument.CreateElement("root");
		foreach (object obj in nodeList)
		{
			XmlNode newChild = (XmlNode)obj;
			this.xmlNode.AppendChild(newChild);
		}
		if (!string.IsNullOrEmpty(this.storeInMemory))
		{
			DataMakerXmlUtils.XmlStoreNode(this.xmlNode, this.storeInMemory);
		}
		this.RegisterEventHandlers();
	}

	// Token: 0x0600009E RID: 158 RVA: 0x000086D4 File Offset: 0x000068D4
	public void InjectXmlString(string source)
	{
		this.xmlNode = DataMakerXmlUtils.StringToXmlNode(source);
		if (!string.IsNullOrEmpty(this.storeInMemory))
		{
			DataMakerXmlUtils.XmlStoreNode(this.xmlNode, this.storeInMemory);
		}
		this.RegisterEventHandlers();
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000465C File Offset: 0x0000285C
	private void UnregisterEventHandlers()
	{
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00008708 File Offset: 0x00006908
	private void RegisterEventHandlers()
	{
		if (this.xmlNode != null)
		{
			this.xmlNode.OwnerDocument.NodeChanged += this.NodeTouchedHandler;
			this.xmlNode.OwnerDocument.NodeInserted += this.NodeTouchedHandler;
			this.xmlNode.OwnerDocument.NodeRemoved += this.NodeTouchedHandler;
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00008774 File Offset: 0x00006974
	private void NodeTouchedHandler(object src, XmlNodeChangedEventArgs args)
	{
		if (this.FsmEventTarget == null || !DataMakerXmlProxy.delegationActive)
		{
			return;
		}
		if (args.Action == XmlNodeChangedAction.Insert)
		{
			PlayMakerUtils.SendEventToGameObject(this.FsmEventTarget, this.FsmEventTarget.gameObject, "XML / INSERTED");
			return;
		}
		if (args.Action == XmlNodeChangedAction.Change)
		{
			PlayMakerUtils.SendEventToGameObject(this.FsmEventTarget, this.FsmEventTarget.gameObject, "XML / CHANGED");
			return;
		}
		if (args.Action == XmlNodeChangedAction.Remove)
		{
			PlayMakerUtils.SendEventToGameObject(this.FsmEventTarget, this.FsmEventTarget.gameObject, "XML / REMOVED");
		}
	}

	// Token: 0x0400010B RID: 267
	public static bool delegationActive = true;

	// Token: 0x0400010C RID: 268
	public string storeInMemory = "";

	// Token: 0x0400010D RID: 269
	public bool useSource;

	// Token: 0x0400010E RID: 270
	public TextAsset XmlTextAsset;

	// Token: 0x0400010F RID: 271
	private XmlNode _xmlNode;

	// Token: 0x04000110 RID: 272
	[HideInInspector]
	[NonSerialized]
	public bool isDirty;

	// Token: 0x04000111 RID: 273
	[HideInInspector]
	[NonSerialized]
	public string content;

	// Token: 0x04000112 RID: 274
	public PlayMakerFSM FsmEventTarget;
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using UnityEngine;

// Token: 0x0200002E RID: 46
public class DataMakerXmlUtils
{
	// Token: 0x060000A4 RID: 164 RVA: 0x00008820 File Offset: 0x00006A20
	public static XmlNamespaceManager CreateNamespaceManager(XmlDocument Doc)
	{
		XPathNavigator xpathNavigator = Doc.SelectSingleNode("/*").CreateNavigator();
		XmlNamespaceManager xmlNamespaceManager = null;
		if (xpathNavigator.MoveToFirstNamespace())
		{
			xmlNamespaceManager = new XmlNamespaceManager(Doc.NameTable);
			do
			{
				xmlNamespaceManager.AddNamespace(string.IsNullOrEmpty(xpathNavigator.Name) ? "default" : xpathNavigator.Name, xpathNavigator.Value);
			}
			while (xpathNavigator.MoveToNextNamespace());
		}
		return xmlNamespaceManager;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00008883 File Offset: 0x00006A83
	public static void XmlStoreNode(XmlNode node, string reference)
	{
		DataMakerXmlUtils.IsDirty = true;
		if (string.IsNullOrEmpty(reference))
		{
			Debug.LogWarning("empty reference.");
		}
		if (DataMakerXmlUtils.xmlNodeLUT == null)
		{
			DataMakerXmlUtils.xmlNodeLUT = new Dictionary<string, XmlNode>();
		}
		DataMakerXmlUtils.xmlNodeLUT[reference] = node;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x000088BA File Offset: 0x00006ABA
	public static XmlNode XmlRetrieveNode(string reference)
	{
		if (string.IsNullOrEmpty(reference))
		{
			Debug.LogWarning("empty reference.");
		}
		if (DataMakerXmlUtils.xmlNodeLUT == null)
		{
			return null;
		}
		if (!DataMakerXmlUtils.xmlNodeLUT.ContainsKey(reference))
		{
			return null;
		}
		return DataMakerXmlUtils.xmlNodeLUT[reference];
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x000088F1 File Offset: 0x00006AF1
	public static bool DeleteXmlNodeReference(string reference)
	{
		DataMakerXmlUtils.IsDirty = true;
		if (string.IsNullOrEmpty(reference))
		{
			Debug.LogWarning("empty reference.");
		}
		return DataMakerXmlUtils.xmlNodeLUT.ContainsKey(reference) && DataMakerXmlUtils.xmlNodeLUT.Remove(reference);
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00008925 File Offset: 0x00006B25
	public static bool DeleteXmlNodListeReference(string reference)
	{
		DataMakerXmlUtils.IsDirty = true;
		if (string.IsNullOrEmpty(reference))
		{
			Debug.LogWarning("empty reference.");
		}
		return DataMakerXmlUtils.xmlNodeListLUT.ContainsKey(reference) && DataMakerXmlUtils.xmlNodeListLUT.Remove(reference);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00008959 File Offset: 0x00006B59
	public static void XmlStoreNodeList(XmlNodeList nodeList, string reference)
	{
		DataMakerXmlUtils.IsDirty = true;
		if (string.IsNullOrEmpty(reference))
		{
			Debug.LogWarning("empty reference.");
		}
		if (DataMakerXmlUtils.xmlNodeListLUT == null)
		{
			DataMakerXmlUtils.xmlNodeListLUT = new Dictionary<string, XmlNodeList>();
		}
		DataMakerXmlUtils.xmlNodeListLUT[reference] = nodeList;
	}

	// Token: 0x060000AA RID: 170 RVA: 0x00008990 File Offset: 0x00006B90
	public static XmlNodeList XmlRetrieveNodeList(string reference)
	{
		if (string.IsNullOrEmpty(reference))
		{
			Debug.LogWarning("empty reference.");
		}
		return DataMakerXmlUtils.xmlNodeListLUT[reference];
	}

	// Token: 0x060000AB RID: 171 RVA: 0x000089B0 File Offset: 0x00006BB0
	public static XmlNode StringToXmlNode(string content)
	{
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.LoadXml(content);
		}
		catch (XmlException ex)
		{
			DataMakerXmlUtils.lastError = ex.Message;
			return null;
		}
		return xmlDocument.DocumentElement;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x000089F4 File Offset: 0x00006BF4
	public static string XmlNodeListToString(XmlNodeList nodeList)
	{
		return DataMakerXmlUtils.XmlNodeListToString(nodeList, 2);
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00008A00 File Offset: 0x00006C00
	public static string XmlNodeListToString(XmlNodeList nodeList, int indentation)
	{
		if (nodeList == null)
		{
			return "-- NULL --";
		}
		string result;
		using (StringWriter stringWriter = new StringWriter())
		{
			using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
			{
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.Indentation = indentation;
				xmlTextWriter.WriteRaw("<result>");
				foreach (object obj in nodeList)
				{
					((XmlNode)obj).WriteTo(xmlTextWriter);
				}
				xmlTextWriter.WriteRaw("</result>");
			}
			result = stringWriter.ToString();
		}
		return result;
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00008AC8 File Offset: 0x00006CC8
	public static string XmlNodeToString(XmlNode node)
	{
		return DataMakerXmlUtils.XmlNodeToString(node, 2);
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00008AD4 File Offset: 0x00006CD4
	public static string XmlNodeToString(XmlNode node, int indentation)
	{
		if (node == null)
		{
			return "-- NULL --";
		}
		string result;
		using (StringWriter stringWriter = new StringWriter())
		{
			using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
			{
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.Indentation = indentation;
				node.WriteTo(xmlTextWriter);
			}
			result = stringWriter.ToString();
		}
		return result;
	}

	// Token: 0x04000113 RID: 275
	public static Dictionary<string, XmlNode> xmlNodeLUT;

	// Token: 0x04000114 RID: 276
	public static Dictionary<string, XmlNodeList> xmlNodeListLUT;

	// Token: 0x04000115 RID: 277
	public static bool IsDirty;

	// Token: 0x04000116 RID: 278
	public static string lastError = "";
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using Mirror;
using Mirror.RemoteCalls;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000048 RID: 72
public class Data_Container : NetworkBehaviour
{
	// Token: 0x0600016F RID: 367 RVA: 0x0000FD30 File Offset: 0x0000DF30
	public override void OnStartClient()
	{
		if (!base.isServer)
		{
			if (this.containerClass == 99)
			{
				if (this.containerID == 12)
				{
					return;
				}
				base.StartCoroutine(this.RequestAdditionalData());
				return;
			}
			else
			{
				if (this.containerClass == 69)
				{
					base.StartCoroutine(this.DelayActivationStorage(Random.Range(1f, 3f)));
					return;
				}
				base.StartCoroutine(this.DelayActivationShelves(Random.Range(1f, 3f)));
			}
		}
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0000FDAB File Offset: 0x0000DFAB
	private IEnumerator RequestAdditionalData()
	{
		yield return new WaitForSeconds(5f);
		this.CmdRequestCloseState();
		yield break;
	}

	// Token: 0x06000171 RID: 369 RVA: 0x0000FDBA File Offset: 0x0000DFBA
	private IEnumerator DelayActivationShelves(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Transform child = GameData.Instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(this.parentIndex);
		base.transform.SetParent(child);
		this.ItemSpawner();
		yield break;
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0000FDD0 File Offset: 0x0000DFD0
	private IEnumerator DelayActivationStorage(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Transform child = GameData.Instance.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(this.parentIndex);
		base.transform.SetParent(child);
		this.BoxSpawner();
		yield break;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x0000FDE8 File Offset: 0x0000DFE8
	[Command(requiresAuthority = false)]
	private void CmdUpdateArrayValues(int index, int PID, int PNUMBER)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteInt(PID);
		writer.WriteInt(PNUMBER);
		base.SendCommandInternal("System.Void Data_Container::CmdUpdateArrayValues(System.Int32,System.Int32,System.Int32)", -1665987912, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000174 RID: 372 RVA: 0x0000FE38 File Offset: 0x0000E038
	[Command(requiresAuthority = false)]
	public void CmdContainerClear(int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		base.SendCommandInternal("System.Void Data_Container::CmdContainerClear(System.Int32)", -1992885602, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000175 RID: 373 RVA: 0x0000FE74 File Offset: 0x0000E074
	[ClientRpc]
	private void RpcUpdateObjectOnClients(int index, int PID, int PNUMBER)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteInt(PID);
		writer.WriteInt(PNUMBER);
		this.SendRPCInternal("System.Void Data_Container::RpcUpdateObjectOnClients(System.Int32,System.Int32,System.Int32)", 1476679272, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000176 RID: 374 RVA: 0x0000FEC2 File Offset: 0x0000E0C2
	private IEnumerator HighLatencyCoroutine()
	{
		this.highLatencyCooldown = true;
		yield return new WaitForSeconds(0.75f);
		this.highLatencyCooldown = false;
		yield break;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x0000FED4 File Offset: 0x0000E0D4
	public void AddItemToRow(int containerNumber, int productIDToAdd)
	{
		bool flag = !base.isServer && FsmVariables.GlobalVariables.FindFsmBool("HighLatencyMode").Value;
		if (flag && this.highLatencyCooldown)
		{
			return;
		}
		if (!this.productlistComponent)
		{
			this.productlistComponent = GameData.Instance.GetComponent<ProductListing>();
		}
		GameObject gameObject = this.productlistComponent.productPrefabs[productIDToAdd];
		Vector3 size = gameObject.GetComponent<BoxCollider>().size;
		if (gameObject.GetComponent<Data_Product>().productContainerClass != this.containerClass)
		{
			GameCanvas.Instance.CreateCanvasNotification("message0");
			return;
		}
		bool isStackable = gameObject.GetComponent<Data_Product>().isStackable;
		int num = Mathf.FloorToInt(this.shelfLength / (size.x * 1.1f));
		num = Mathf.Clamp(num, 1, 100);
		int num2 = Mathf.FloorToInt(this.shelfWidth / (size.z * 1.1f));
		num2 = Mathf.Clamp(num2, 1, 100);
		int num3 = num * num2;
		if (isStackable)
		{
			int num4 = Mathf.FloorToInt(this.shelfHeight / (size.y * 1.1f));
			num4 = Mathf.Clamp(num4, 1, 100);
			num3 = num * num2 * num4;
		}
		int num5 = containerNumber * 2;
		int num6 = this.productInfoArray[num5];
		int num7 = this.productInfoArray[num5 + 1];
		if (num7 >= num3)
		{
			GameCanvas.Instance.CreateCanvasNotification("message1");
			return;
		}
		if (num6 != productIDToAdd && num6 != -1 && num7 != 0)
		{
			GameCanvas.Instance.CreateCanvasNotification("message2");
			return;
		}
		PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();
		if (flag)
		{
			base.StartCoroutine(this.HighLatencyCoroutine());
			int num8 = num3 - num7;
			num8 = Mathf.Clamp(num8, 1, 5);
			int num9 = component.extraParameter2;
			num9 = Mathf.Clamp(num9, 1, 5);
			int num10 = num9;
			if (num8 < num9)
			{
				num10 = num8;
			}
			component.extraParameter2 -= num10;
			num7 += num10;
			AchievementsManager.Instance.CmdAddAchievementPoint(1, num10);
		}
		else
		{
			AchievementsManager.Instance.CmdAddAchievementPoint(1, 1);
			component.extraParameter2--;
			num7++;
		}
		GameData.Instance.PlayPopSound();
		this.productInfoArray[num5 + 1] = num7;
		this.CmdUpdateArrayValues(num5, productIDToAdd, num7);
	}

	// Token: 0x06000178 RID: 376 RVA: 0x000100FC File Offset: 0x0000E2FC
	public void RemoveItemFromRow(int containerNumber)
	{
		bool flag = !base.isServer && FsmVariables.GlobalVariables.FindFsmBool("HighLatencyMode").Value;
		if (flag && this.highLatencyCooldown)
		{
			return;
		}
		int num = containerNumber * 2;
		int num2 = this.productInfoArray[num];
		int num3 = this.productInfoArray[num + 1];
		if (num2 == -1 || num3 <= 0)
		{
			return;
		}
		PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();
		if (component.equippedItem != 1)
		{
			return;
		}
		if (component.extraParameter1 != num2 && component.extraParameter2 > 0)
		{
			GameCanvas.Instance.CreateCanvasNotification("message13");
			return;
		}
		int maxItemsPerBox = ProductListing.Instance.productPrefabs[num2].GetComponent<Data_Product>().maxItemsPerBox;
		if (component.extraParameter2 >= maxItemsPerBox)
		{
			GameCanvas.Instance.CreateCanvasNotification("message12");
			return;
		}
		if (component.extraParameter2 == 0 && component.instantiatedOBJ)
		{
			component.extraParameter1 = num2;
			component.UpdateBoxContents(num2);
		}
		if (flag)
		{
			base.StartCoroutine(this.HighLatencyCoroutine());
			int num4 = maxItemsPerBox - component.extraParameter2;
			num4 = Mathf.Clamp(num4, 1, 5);
			int num5 = num4;
			if (num3 < num4)
			{
				num5 = num3;
			}
			component.extraParameter2 += num5;
			num3 -= num5;
		}
		else
		{
			component.extraParameter2++;
			num3--;
		}
		GameData.Instance.PlayPop2Sound();
		this.productInfoArray[num + 1] = num3;
		this.CmdUpdateArrayValues(num, num2, num3);
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00010268 File Offset: 0x0000E468
	public void EmployeeAddsItemToRow(int rowIndex)
	{
		int pid = this.productInfoArray[rowIndex];
		int num = this.productInfoArray[rowIndex + 1];
		num++;
		this.productInfoArray[rowIndex + 1] = num;
		AchievementsManager.Instance.CmdAddAchievementPoint(1, 1);
		this.RpcUpdateObjectOnClients(rowIndex, pid, num);
	}

	// Token: 0x0600017A RID: 378 RVA: 0x000102B0 File Offset: 0x0000E4B0
	public void NPCGetsItemFromRow(int productIDToBuyAndRemove)
	{
		int num = this.productInfoArray.Length / 2;
		for (int i = 0; i < num; i++)
		{
			if (this.productInfoArray[i * 2] == productIDToBuyAndRemove)
			{
				int num2 = this.productInfoArray[i * 2 + 1];
				if (num2 > 0)
				{
					num2--;
					this.productInfoArray[i * 2 + 1] = num2;
					this.RpcUpdateObjectOnClients(i * 2, productIDToBuyAndRemove, num2);
					return;
				}
			}
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00010310 File Offset: 0x0000E510
	private void ItemSpawner()
	{
		if (!this.productlistComponent)
		{
			this.productlistComponent = GameData.Instance.GetComponent<ProductListing>();
		}
		GameObject gameObject = base.transform.Find("ProductContainer").gameObject;
		int childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			int num = this.productInfoArray[i * 2];
			int num2 = this.productInfoArray[i * 2 + 1];
			Transform child = gameObject.transform.GetChild(i);
			int childCount2 = child.childCount;
			if (num != -1)
			{
				int num3 = num2 - childCount2;
				if (num3 != 0)
				{
					if (num3 > 0)
					{
						GameObject gameObject2 = this.productlistComponent.productPrefabs[num];
						Vector3 size = gameObject2.GetComponent<BoxCollider>().size;
						int num4 = Mathf.FloorToInt(this.shelfLength / (size.x * 1.1f));
						num4 = Mathf.Clamp(num4, 1, 100);
						int num5 = Mathf.FloorToInt(this.shelfWidth / (size.z * 1.1f));
						num5 = Mathf.Clamp(num5, 1, 100);
						bool isStackable = gameObject2.GetComponent<Data_Product>().isStackable;
						float num6 = (this.shelfLength - ((float)(num4 - 1) * (size.x * 1.1f) + size.x)) / 2f;
						float num7 = (this.shelfWidth - ((float)(num5 - 1) * (size.z * 1.1f) + size.z)) / 2f;
						for (int j = childCount2; j < num2; j++)
						{
							int num8 = 0;
							if (isStackable)
							{
								num8 = j / (num5 * num4);
							}
							int num9 = j / num4 - num8 * num5;
							int num10 = j % num4;
							GameObject gameObject3 = Object.Instantiate<GameObject>(gameObject2);
							gameObject3.transform.SetParent(child);
							gameObject3.transform.localPosition = new Vector3((float)num9 * size.z * 1.1f, (float)num8 * size.y, (float)num10 * size.x * 1.1f) + new Vector3(size.z / 2f + num7, 0f, size.x / 2f + num6);
							gameObject3.transform.localRotation = Quaternion.Euler(this.productAngleOffset);
						}
					}
					else
					{
						num3 = Mathf.Abs(num3);
						int num11 = 0;
						while (num11 < num3 && child.childCount != 0)
						{
							Object.Destroy(child.GetChild(child.childCount - 1 - num11).gameObject);
							num11++;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600017C RID: 380 RVA: 0x0001059C File Offset: 0x0000E79C
	public void GetStorageBox(int boxIndex)
	{
		int num = boxIndex * 2;
		int num2 = this.productInfoArray[num];
		int num3 = this.productInfoArray[num + 1];
		PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();
		if (component.equippedItem == 1 && num3 >= 0 && num2 == component.extraParameter1 && component.extraParameter2 > 0 && num2 >= 0 && num2 < ProductListing.Instance.productPrefabs.Length)
		{
			int maxItemsPerBox = ProductListing.Instance.productPrefabs[num2].GetComponent<Data_Product>().maxItemsPerBox;
			if (num3 == maxItemsPerBox)
			{
				GameCanvas.Instance.CreateCanvasNotification("message12");
				return;
			}
			if (num3 + component.extraParameter2 > maxItemsPerBox)
			{
				int num4 = maxItemsPerBox - num3;
				component.extraParameter2 -= num4;
				this.CmdUpdateArrayValuesStorage(num, component.extraParameter1, maxItemsPerBox);
				GameData.Instance.PlayPopSound();
				return;
			}
			this.CmdUpdateArrayValuesStorage(num, component.extraParameter1, num3 + component.extraParameter2);
			component.extraParameter2 = 0;
			GameData.Instance.PlayPopSound();
			return;
		}
		else if (num3 <= 0 && component.equippedItem == 1)
		{
			if (base.transform.Find("BoxContainer").gameObject.transform.GetChild(boxIndex).transform.childCount > 0)
			{
				return;
			}
			component.CmdChangeEquippedItem(0);
			this.CmdUpdateArrayValuesStorage(num, component.extraParameter1, component.extraParameter2);
			return;
		}
		else
		{
			if (num2 < 0 || num3 <= -1)
			{
				return;
			}
			if (component.equippedItem != 0)
			{
				GameCanvas.Instance.CreateCanvasNotification("message7");
				return;
			}
			component.CmdChangeEquippedItem(1);
			component.extraParameter1 = num2;
			component.extraParameter2 = num3;
			if (base.transform.Find("CanvasSigns"))
			{
				this.CmdUpdateArrayValuesStorage(num, num2, -1);
				return;
			}
			this.CmdUpdateArrayValuesStorage(num, -1, -1);
			return;
		}
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00010758 File Offset: 0x0000E958
	public void ClearStorageBox(int boxIndex)
	{
		int num = boxIndex * 2;
		int num2 = this.productInfoArray[num];
		int num3 = this.productInfoArray[num + 1];
		PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();
		if (component.equippedItem != 2)
		{
			return;
		}
		if (num2 >= 0 && num3 < 0)
		{
			component.transform.Find("ResetProductSound").GetComponent<AudioSource>().Play();
			this.CmdUpdateArrayValuesStorage(num, -1, -1);
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x000107BD File Offset: 0x0000E9BD
	public void EmployeeUpdateArrayValuesStorage(int index, int PID, int PNUMBER)
	{
		this.productInfoArray[index] = PID;
		this.productInfoArray[index + 1] = PNUMBER;
		this.RpcUpdateArrayValuesStorage(index, PID, PNUMBER);
	}

	// Token: 0x0600017F RID: 383 RVA: 0x000107DC File Offset: 0x0000E9DC
	[Command(requiresAuthority = false)]
	private void CmdUpdateArrayValuesStorage(int index, int PID, int PNUMBER)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteInt(PID);
		writer.WriteInt(PNUMBER);
		base.SendCommandInternal("System.Void Data_Container::CmdUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", -151239219, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000180 RID: 384 RVA: 0x0001082C File Offset: 0x0000EA2C
	[ClientRpc]
	private void RpcUpdateArrayValuesStorage(int index, int PID, int PNUMBER)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteInt(PID);
		writer.WriteInt(PNUMBER);
		this.SendRPCInternal("System.Void Data_Container::RpcUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", -584408438, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000181 RID: 385 RVA: 0x0001087C File Offset: 0x0000EA7C
	private void BoxSpawner()
	{
		GameObject gameObject = base.transform.Find("BoxContainer").gameObject;
		GameObject gameObject2 = null;
		if (base.transform.Find("CanvasSigns"))
		{
			gameObject2 = base.transform.Find("CanvasSigns").gameObject;
		}
		int childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			int num = this.productInfoArray[i * 2];
			int num2 = this.productInfoArray[i * 2 + 1];
			Transform transform = null;
			if (gameObject2)
			{
				transform = gameObject2.transform.GetChild(i);
			}
			bool flag = gameObject.transform.GetChild(i).childCount > 0;
			if (num2 <= -1)
			{
				if (flag)
				{
					Object.Destroy(gameObject.transform.GetChild(i).transform.GetChild(0).gameObject);
					if (num >= 0 && transform)
					{
						transform.gameObject.SetActive(true);
						transform.GetComponent<Image>().sprite = ProductListing.Instance.productSprites[num];
					}
				}
				else if (num >= 0 && transform)
				{
					transform.gameObject.SetActive(true);
					transform.GetComponent<Image>().sprite = ProductListing.Instance.productSprites[num];
				}
				else if (num < 0 && transform && gameObject2.activeSelf)
				{
					transform.gameObject.SetActive(false);
				}
			}
			else if (num >= 0 && !flag)
			{
				if (transform)
				{
					transform.gameObject.SetActive(false);
				}
				GameObject gameObject3 = Object.Instantiate<GameObject>(this.storageBoxPrefab, gameObject.transform.GetChild(i));
				gameObject3.transform.localPosition = Vector3.zero;
				ProductListing.Instance.SetBoxColor(gameObject3, num);
				gameObject3.transform.Find("ProductSprite").GetComponent<SpriteRenderer>().sprite = ProductListing.Instance.productSprites[num];
				gameObject3.transform.Find("ProductQuantity").GetComponent<TextMeshPro>().text = "x" + num2.ToString();
			}
			else if (num >= 0 && flag)
			{
				gameObject.transform.GetChild(i).transform.GetChild(0).transform.Find("ProductQuantity").GetComponent<TextMeshPro>().text = "x" + num2.ToString();
			}
		}
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00010B0C File Offset: 0x0000ED0C
	public void AddItemToCheckout(float ItemValue, GameObject NPCTrigger)
	{
		this.NetworkproductsLeft = this.productsLeft - 1;
		this.checkoutProductValue += ItemValue;
		this.checkoutProductValue = Mathf.Round(this.checkoutProductValue * 100f) / 100f;
		this.currentNPC = NPCTrigger;
		this.RpcAddItemToCheckout(this.checkoutProductValue, NPCTrigger);
	}

	// Token: 0x06000183 RID: 387 RVA: 0x00010B68 File Offset: 0x0000ED68
	[ClientRpc]
	private void RpcAddItemToCheckout(float productCost, GameObject NPC)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(productCost);
		writer.WriteGameObject(NPC);
		this.SendRPCInternal("System.Void Data_Container::RpcAddItemToCheckout(System.Single,UnityEngine.GameObject)", 101859644, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000184 RID: 388 RVA: 0x00010BAC File Offset: 0x0000EDAC
	private void BagsActivation()
	{
		this.productsCounterForBags++;
		int index = Mathf.Clamp(this.productsCounterForBags / 6, 0, 5);
		base.transform.Find("Bags").transform.GetChild(index).gameObject.SetActive(true);
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00010C00 File Offset: 0x0000EE00
	private void BagsDeactivation()
	{
		this.productsCounterForBags = 0;
		foreach (object obj in base.transform.Find("Bags"))
		{
			((Transform)obj).gameObject.SetActive(false);
		}
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00010C70 File Offset: 0x0000EE70
	[ClientRpc]
	public void SelfCheckoutActivateBag()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void Data_Container::SelfCheckoutActivateBag()", 1151481752, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00010CA0 File Offset: 0x0000EEA0
	[ClientRpc]
	public void SelfCheckoutDeactivateBag()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void Data_Container::SelfCheckoutDeactivateBag()", 252060505, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00010CD0 File Offset: 0x0000EED0
	[ClientRpc]
	public void RpcShowPaymentMethod(int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		this.SendRPCInternal("System.Void Data_Container::RpcShowPaymentMethod(System.Int32)", 66677187, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00010D0C File Offset: 0x0000EF0C
	[Command(requiresAuthority = false)]
	public void CmdActivateCashMethod(int amountToPay)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(amountToPay);
		base.SendCommandInternal("System.Void Data_Container::CmdActivateCashMethod(System.Int32)", -1046723695, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00010D48 File Offset: 0x0000EF48
	[Command(requiresAuthority = false)]
	public void CmdActivateCreditCardMethod()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void Data_Container::CmdActivateCreditCardMethod()", 893267412, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00010D78 File Offset: 0x0000EF78
	[ClientRpc]
	public void RpcHidePaymentMethod(int index, int amountGiven)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteInt(amountGiven);
		this.SendRPCInternal("System.Void Data_Container::RpcHidePaymentMethod(System.Int32,System.Int32)", 1704799803, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00010DBC File Offset: 0x0000EFBC
	public void UpdateCash(float amountToAdd)
	{
		TextMeshProUGUI component = base.transform.Find("CashRegisterCanvas/Container/CurrentAmount").GetComponent<TextMeshProUGUI>();
		GameObject gameObject = base.transform.Find("CashRegister/MoneyGivenBack").gameObject;
		amountToAdd = Mathf.Round(amountToAdd * 100f) / 100f;
		if ((double)Mathf.Abs(amountToAdd) < 0.9)
		{
			this.moneySoundAudioSource.clip = this.audioCoinsArray[Random.Range(0, this.audioCoinsArray.Length - 1)];
			this.moneySoundAudioSource.Play();
		}
		else
		{
			this.moneySoundAudioSource.clip = this.audioNotesArray[Random.Range(0, this.audioNotesArray.Length - 1)];
			this.moneySoundAudioSource.Play();
		}
		if (this.currentAmountToReturn + amountToAdd < 0f)
		{
			this.currentAmountToReturn = 0f;
			component.color = Color.red;
			component.text = "$" + this.currentAmountToReturn.ToString();
			gameObject.SetActive(false);
			this.allowMoneyReturn = false;
			return;
		}
		this.currentAmountToReturn += amountToAdd;
		component.text = ProductListing.Instance.ConvertFloatToTextPrice(this.currentAmountToReturn);
		this.currentAmountToReturn = Mathf.Round(this.currentAmountToReturn * 100f) / 100f;
		if (this.currentAmountToReturn < this.moneyToReturn)
		{
			gameObject.SetActive(false);
			component.color = Color.red;
			this.allowMoneyReturn = false;
			return;
		}
		gameObject.SetActive(true);
		component.color = Color.green;
		this.allowMoneyReturn = true;
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00010F48 File Offset: 0x0000F148
	[Command(requiresAuthority = false)]
	public void CmdReceivePayment(float returnDifference)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(returnDifference);
		base.SendCommandInternal("System.Void Data_Container::CmdReceivePayment(System.Single)", -1418628073, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00010F84 File Offset: 0x0000F184
	public void AuxReceivePayment(float returnDifference, bool applyEmployeeRate)
	{
		this.checkoutQueue[0] = false;
		if (this.currentNPC)
		{
			this.currentNPC.GetComponent<NPC_Info>().state = 10;
		}
		float num = applyEmployeeRate ? NPC_Manager.Instance.extraCheckoutMoney : 1f;
		returnDifference = Mathf.Round(returnDifference * 100f) / 100f;
		float num2 = this.checkoutProductValue * num - returnDifference;
		GameData.Instance.CmdAlterFunds(num2);
		this.checkoutProductValue = 0f;
		this.NetworkproductsLeft = 0;
		this.RpcClearCheckoutData();
		AchievementsManager.Instance.CmdMaxFundsCheckouted(num2);
		this.internalProductListForEmployees.Clear();
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00011028 File Offset: 0x0000F228
	[ClientRpc]
	public void RpcClearCheckoutData()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void Data_Container::RpcClearCheckoutData()", 2061937503, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00011058 File Offset: 0x0000F258
	public void ResetQueue()
	{
		this.RpcClearCheckoutData();
		this.BagsDeactivation();
		this.NetworkproductsLeft = 0;
		if (this.internalProductListForEmployees.Count > 0)
		{
			foreach (GameObject gameObject in this.internalProductListForEmployees)
			{
				if (gameObject)
				{
					gameObject.GetComponent<ProductCheckoutSpawn>().EndDayDestroy();
				}
			}
			this.internalProductListForEmployees.Clear();
		}
		for (int i = 0; i < this.checkoutQueue.Length; i++)
		{
			this.checkoutQueue[i] = false;
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00011100 File Offset: 0x0000F300
	public void ResetCheckoutQueue()
	{
		this.SelfCheckoutDeactivateBag();
		this.checkoutQueue[0] = false;
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00011114 File Offset: 0x0000F314
	[Command(requiresAuthority = false)]
	public void CmdCloseCheckout()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void Data_Container::CmdCloseCheckout()", -1341494929, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000193 RID: 403 RVA: 0x00011144 File Offset: 0x0000F344
	[Command(requiresAuthority = false)]
	public void CmdRequestCloseState()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void Data_Container::CmdRequestCloseState()", 2032648167, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000194 RID: 404 RVA: 0x00011174 File Offset: 0x0000F374
	[ClientRpc]
	private void RpcCloseCheckout(bool isClosed)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(isClosed);
		this.SendRPCInternal("System.Void Data_Container::RpcCloseCheckout(System.Boolean)", 1683512443, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000195 RID: 405 RVA: 0x000111AE File Offset: 0x0000F3AE
	public void ActivateShelvesFromLoad()
	{
		base.StartCoroutine(this.ActivateShelvesFromLoadCoroutine());
	}

	// Token: 0x06000196 RID: 406 RVA: 0x000111BD File Offset: 0x0000F3BD
	private IEnumerator ActivateShelvesFromLoadCoroutine()
	{
		yield return new WaitForSeconds(Random.Range(1f, 5f));
		if (this.containerClass == 69)
		{
			this.BoxSpawner();
		}
		else if (this.containerClass != 99)
		{
			this.ItemSpawner();
		}
		yield break;
	}

	// Token: 0x06000197 RID: 407 RVA: 0x000111CC File Offset: 0x0000F3CC
	public void AddMoveEffect()
	{
		this.ownerMaterial = base.GetComponent<MeshRenderer>().sharedMaterial;
		this.Effect(false);
	}

	// Token: 0x06000198 RID: 408 RVA: 0x000111E6 File Offset: 0x0000F3E6
	public void RemoveMoveEffect()
	{
		this.Effect(true);
	}

	// Token: 0x06000199 RID: 409 RVA: 0x000111F0 File Offset: 0x0000F3F0
	private void Effect(bool AddEffect)
	{
		this.movingMaterial = GameData.Instance.movingMaterial;
		Material material = AddEffect ? this.ownerMaterial : this.movingMaterial;
		this.colliderArray = base.GetComponents<BoxCollider>();
		if (base.transform.Find("OverlapCollider"))
		{
			this.overlapOBJ = base.transform.Find("OverlapCollider").gameObject;
			this.overlapOBJ.SetActive(AddEffect);
		}
		BoxCollider[] array = this.colliderArray;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = AddEffect;
		}
		MeshRenderer[] array2 = this.mRenderersArray;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].material = material;
		}
	}

	// Token: 0x0600019A RID: 410 RVA: 0x000112A5 File Offset: 0x0000F4A5
	public void DebugAdd(int productIDIndex, int productIDToAdd, int numberOfProducts)
	{
		this.CmdUpdateArrayValues(productIDIndex, productIDToAdd, numberOfProducts);
	}

	// Token: 0x0600019C RID: 412 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x0600019D RID: 413 RVA: 0x00011330 File Offset: 0x0000F530
	// (set) Token: 0x0600019E RID: 414 RVA: 0x00011343 File Offset: 0x0000F543
	public int[] NetworkproductInfoArray
	{
		get
		{
			return this.productInfoArray;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int[]>(value, ref this.productInfoArray, 1UL, null);
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600019F RID: 415 RVA: 0x00011360 File Offset: 0x0000F560
	// (set) Token: 0x060001A0 RID: 416 RVA: 0x00011373 File Offset: 0x0000F573
	public int NetworkproductsLeft
	{
		get
		{
			return this.productsLeft;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.productsLeft, 2UL, null);
		}
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x0001138D File Offset: 0x0000F58D
	protected void UserCode_CmdUpdateArrayValues__Int32__Int32__Int32(int index, int PID, int PNUMBER)
	{
		this.productInfoArray[index] = PID;
		this.productInfoArray[index + 1] = PNUMBER;
		this.RpcUpdateObjectOnClients(index, PID, PNUMBER);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x000113AC File Offset: 0x0000F5AC
	protected static void InvokeUserCode_CmdUpdateArrayValues__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateArrayValues called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdUpdateArrayValues__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x000113E1 File Offset: 0x0000F5E1
	protected void UserCode_CmdContainerClear__Int32(int index)
	{
		this.productInfoArray[index] = -1;
		this.productInfoArray[index + 1] = 0;
		this.RpcUpdateObjectOnClients(index, -1, 0);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00011400 File Offset: 0x0000F600
	protected static void InvokeUserCode_CmdContainerClear__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdContainerClear called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdContainerClear__Int32(reader.ReadInt());
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0001142C File Offset: 0x0000F62C
	protected void UserCode_RpcUpdateObjectOnClients__Int32__Int32__Int32(int index, int PID, int PNUMBER)
	{
		if (!base.isServer)
		{
			this.productInfoArray[index] = PID;
			this.productInfoArray[index + 1] = PNUMBER;
		}
		this.ItemSpawner();
		if (PNUMBER == 0 || PNUMBER == 1 || PNUMBER == 5)
		{
			if (!this.productlistComponent)
			{
				this.productlistComponent = GameData.Instance.GetComponent<ProductListing>();
			}
			this.productlistComponent.updateShelvesPrices();
		}
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x0001148E File Offset: 0x0000F68E
	protected static void InvokeUserCode_RpcUpdateObjectOnClients__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateObjectOnClients called on server.");
			return;
		}
		((Data_Container)obj).UserCode_RpcUpdateObjectOnClients__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x000107BD File Offset: 0x0000E9BD
	protected void UserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32(int index, int PID, int PNUMBER)
	{
		this.productInfoArray[index] = PID;
		this.productInfoArray[index + 1] = PNUMBER;
		this.RpcUpdateArrayValuesStorage(index, PID, PNUMBER);
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x000114C3 File Offset: 0x0000F6C3
	protected static void InvokeUserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateArrayValuesStorage called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x000114F8 File Offset: 0x0000F6F8
	protected void UserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32(int index, int PID, int PNUMBER)
	{
		if (!base.isServer)
		{
			this.productInfoArray[index] = PID;
			this.productInfoArray[index + 1] = PNUMBER;
		}
		this.BoxSpawner();
	}

	// Token: 0x060001AA RID: 426 RVA: 0x0001151C File Offset: 0x0000F71C
	protected static void InvokeUserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateArrayValuesStorage called on server.");
			return;
		}
		((Data_Container)obj).UserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x060001AB RID: 427 RVA: 0x00011554 File Offset: 0x0000F754
	protected void UserCode_RpcAddItemToCheckout__Single__GameObject(float productCost, GameObject NPC)
	{
		base.GetComponent<AudioSource>().Play();
		this.currentNPC = NPC;
		this.checkoutProductValue = productCost;
		base.transform.Find("CashRegisterCanvas/VisibleCheckoutCost").GetComponent<TextMeshProUGUI>().text = ProductListing.Instance.ConvertFloatToTextPrice(this.checkoutProductValue);
		base.transform.Find("CreditCardCanvas/VisibleCheckoutCost2").GetComponent<TextMeshProUGUI>().text = ProductListing.Instance.ConvertFloatToTextPrice(this.checkoutProductValue);
		this.BagsActivation();
	}

	// Token: 0x060001AC RID: 428 RVA: 0x000115D4 File Offset: 0x0000F7D4
	protected static void InvokeUserCode_RpcAddItemToCheckout__Single__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAddItemToCheckout called on server.");
			return;
		}
		((Data_Container)obj).UserCode_RpcAddItemToCheckout__Single__GameObject(reader.ReadFloat(), reader.ReadGameObject());
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00011604 File Offset: 0x0000F804
	protected void UserCode_SelfCheckoutActivateBag()
	{
		base.GetComponent<AudioSource>().Play();
		this.productsCounterForBags++;
		int index = Mathf.Clamp(this.productsCounterForBags / 6, 0, 3);
		base.transform.Find("Bags").transform.GetChild(index).gameObject.SetActive(true);
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00011660 File Offset: 0x0000F860
	protected static void InvokeUserCode_SelfCheckoutActivateBag(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SelfCheckoutActivateBag called on server.");
			return;
		}
		((Data_Container)obj).UserCode_SelfCheckoutActivateBag();
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00011684 File Offset: 0x0000F884
	protected void UserCode_SelfCheckoutDeactivateBag()
	{
		this.productsCounterForBags = 0;
		foreach (object obj in base.transform.Find("Bags"))
		{
			((Transform)obj).gameObject.SetActive(false);
		}
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x000116F4 File Offset: 0x0000F8F4
	protected static void InvokeUserCode_SelfCheckoutDeactivateBag(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SelfCheckoutDeactivateBag called on server.");
			return;
		}
		((Data_Container)obj).UserCode_SelfCheckoutDeactivateBag();
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00011717 File Offset: 0x0000F917
	protected void UserCode_RpcShowPaymentMethod__Int32(int index)
	{
		if (index == 0)
		{
			base.transform.Find("Payments/Payment_Money").gameObject.SetActive(true);
			return;
		}
		base.transform.Find("Payments/Payment_Card").gameObject.SetActive(true);
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00011753 File Offset: 0x0000F953
	protected static void InvokeUserCode_RpcShowPaymentMethod__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowPaymentMethod called on server.");
			return;
		}
		((Data_Container)obj).UserCode_RpcShowPaymentMethod__Int32(reader.ReadInt());
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0001177C File Offset: 0x0000F97C
	protected void UserCode_CmdActivateCashMethod__Int32(int amountToPay)
	{
		this.RpcHidePaymentMethod(0, amountToPay);
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00011786 File Offset: 0x0000F986
	protected static void InvokeUserCode_CmdActivateCashMethod__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdActivateCashMethod called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdActivateCashMethod__Int32(reader.ReadInt());
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x000117AF File Offset: 0x0000F9AF
	protected void UserCode_CmdActivateCreditCardMethod()
	{
		this.RpcHidePaymentMethod(1, 0);
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x000117B9 File Offset: 0x0000F9B9
	protected static void InvokeUserCode_CmdActivateCreditCardMethod(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdActivateCreditCardMethod called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdActivateCreditCardMethod();
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x000117DC File Offset: 0x0000F9DC
	protected void UserCode_RpcHidePaymentMethod__Int32__Int32(int index, int amountGiven)
	{
		this.currentAmountToReturn = 0f;
		this.moneyToReturn = 0f;
		if (index == 0)
		{
			base.transform.Find("Payments/Payment_Money").gameObject.SetActive(false);
			this.moneyToReturn = (float)amountGiven - this.checkoutProductValue;
			this.moneyToReturn = Mathf.Round(this.moneyToReturn * 100f) / 100f;
			base.transform.Find("CashRegister").GetComponent<AudioSource>().Play();
			base.transform.Find("CashRegister/CashRegisterDrawer").transform.localPosition = new Vector3(-0.28f, 0f, 0f);
			base.transform.Find("CashRegisterCanvas/Container").gameObject.SetActive(true);
			base.transform.Find("CashRegisterCanvas/Container/MoneyGiven").GetComponent<TextMeshProUGUI>().text = ProductListing.Instance.ConvertFloatToTextPrice((float)amountGiven);
			base.transform.Find("CashRegisterCanvas/Container/MoneyToReturn").GetComponent<TextMeshProUGUI>().text = ProductListing.Instance.ConvertFloatToTextPrice(this.moneyToReturn);
			base.transform.Find("CashRegisterCanvas/Container/CurrentAmount").GetComponent<TextMeshProUGUI>().text = "$0,00";
			return;
		}
		base.transform.Find("Payments/Payment_Card").gameObject.SetActive(false);
		base.transform.Find("CreditCardCanvas/Container").gameObject.SetActive(true);
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00011955 File Offset: 0x0000FB55
	protected static void InvokeUserCode_RpcHidePaymentMethod__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHidePaymentMethod called on server.");
			return;
		}
		((Data_Container)obj).UserCode_RpcHidePaymentMethod__Int32__Int32(reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00011984 File Offset: 0x0000FB84
	protected void UserCode_CmdReceivePayment__Single(float returnDifference)
	{
		this.AuxReceivePayment(returnDifference, false);
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0001198E File Offset: 0x0000FB8E
	protected static void InvokeUserCode_CmdReceivePayment__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdReceivePayment called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdReceivePayment__Single(reader.ReadFloat());
	}

	// Token: 0x060001BB RID: 443 RVA: 0x000119B8 File Offset: 0x0000FBB8
	protected void UserCode_RpcClearCheckoutData()
	{
		this.checkoutProductValue = 0f;
		this.allowMoneyReturn = false;
		base.transform.Find("CashRegisterCanvas/VisibleCheckoutCost").GetComponent<TextMeshProUGUI>().text = "$0,00";
		base.transform.Find("CreditCardCanvas/VisibleCheckoutCost2").GetComponent<TextMeshProUGUI>().text = "$0,00";
		base.transform.Find("CashRegisterCanvas/Container").gameObject.SetActive(false);
		base.transform.Find("CashRegisterCanvas/Container/CurrentAmount").GetComponent<TextMeshProUGUI>().color = Color.red;
		base.transform.Find("CashRegister/MoneyGivenBack").gameObject.SetActive(false);
		base.transform.Find("CashRegister/CashRegisterDrawer").transform.localPosition = new Vector3(0f, 0f, 0f);
		base.transform.Find("CreditCardCanvas/Container").gameObject.SetActive(false);
		base.transform.Find("Payments/Payment_Card").gameObject.SetActive(false);
		base.transform.Find("Payments/Payment_Money").gameObject.SetActive(false);
		this.BagsDeactivation();
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00011AEF File Offset: 0x0000FCEF
	protected static void InvokeUserCode_RpcClearCheckoutData(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcClearCheckoutData called on server.");
			return;
		}
		((Data_Container)obj).UserCode_RpcClearCheckoutData();
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00011B12 File Offset: 0x0000FD12
	protected void UserCode_CmdCloseCheckout()
	{
		this.isCheckoutClosed = !this.isCheckoutClosed;
		if (!this.isCheckoutClosed)
		{
			NPC_Manager.Instance.UpdateEmployeeCheckoutsFromDataContainer();
		}
		this.RpcCloseCheckout(this.isCheckoutClosed);
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00011B41 File Offset: 0x0000FD41
	protected static void InvokeUserCode_CmdCloseCheckout(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCloseCheckout called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdCloseCheckout();
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00011B64 File Offset: 0x0000FD64
	protected void UserCode_CmdRequestCloseState()
	{
		this.RpcCloseCheckout(this.isCheckoutClosed);
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00011B72 File Offset: 0x0000FD72
	protected static void InvokeUserCode_CmdRequestCloseState(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestCloseState called on client.");
			return;
		}
		((Data_Container)obj).UserCode_CmdRequestCloseState();
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x00011B98 File Offset: 0x0000FD98
	protected void UserCode_RpcCloseCheckout__Boolean(bool isClosed)
	{
		if (isClosed)
		{
			base.transform.Find("CheckoutLaneSign").GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red * 30f);
			base.transform.Find("CheckoutLaneSign/Canvas/Text1").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("checkoutlane");
			base.transform.Find("CheckoutLaneSign/Canvas/Text2").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("checkoutlane");
			GameData.Instance.PlayPop2Sound();
			return;
		}
		base.transform.Find("CheckoutLaneSign").GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green * 30f);
		base.transform.Find("CheckoutLaneSign/Canvas/Text1").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("checkoutlane1");
		base.transform.Find("CheckoutLaneSign/Canvas/Text2").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("checkoutlane1");
		GameData.Instance.PlayPopSound();
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00011CCA File Offset: 0x0000FECA
	protected static void InvokeUserCode_RpcCloseCheckout__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCloseCheckout called on server.");
			return;
		}
		((Data_Container)obj).UserCode_RpcCloseCheckout__Boolean(reader.ReadBool());
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x00011CF4 File Offset: 0x0000FEF4
	static Data_Container()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdUpdateArrayValues(System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdUpdateArrayValues__Int32__Int32__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdContainerClear(System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdContainerClear__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdActivateCashMethod(System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdActivateCashMethod__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdActivateCreditCardMethod()", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdActivateCreditCardMethod), false);
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdReceivePayment(System.Single)", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdReceivePayment__Single), false);
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdCloseCheckout()", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdCloseCheckout), false);
		RemoteProcedureCalls.RegisterCommand(typeof(Data_Container), "System.Void Data_Container::CmdRequestCloseState()", new RemoteCallDelegate(Data_Container.InvokeUserCode_CmdRequestCloseState), false);
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::RpcUpdateObjectOnClients(System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_RpcUpdateObjectOnClients__Int32__Int32__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::RpcUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::RpcAddItemToCheckout(System.Single,UnityEngine.GameObject)", new RemoteCallDelegate(Data_Container.InvokeUserCode_RpcAddItemToCheckout__Single__GameObject));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::SelfCheckoutActivateBag()", new RemoteCallDelegate(Data_Container.InvokeUserCode_SelfCheckoutActivateBag));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::SelfCheckoutDeactivateBag()", new RemoteCallDelegate(Data_Container.InvokeUserCode_SelfCheckoutDeactivateBag));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::RpcShowPaymentMethod(System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_RpcShowPaymentMethod__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::RpcHidePaymentMethod(System.Int32,System.Int32)", new RemoteCallDelegate(Data_Container.InvokeUserCode_RpcHidePaymentMethod__Int32__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::RpcClearCheckoutData()", new RemoteCallDelegate(Data_Container.InvokeUserCode_RpcClearCheckoutData));
		RemoteProcedureCalls.RegisterRpc(typeof(Data_Container), "System.Void Data_Container::RpcCloseCheckout(System.Boolean)", new RemoteCallDelegate(Data_Container.InvokeUserCode_RpcCloseCheckout__Boolean));
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x00011F2C File Offset: 0x0001012C
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			Mirror.GeneratedNetworkCode._Write_System.Int32[](writer, this.productInfoArray);
			writer.WriteInt(this.productsLeft);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.Int32[](writer, this.productInfoArray);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteInt(this.productsLeft);
		}
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x00011FB4 File Offset: 0x000101B4
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int[]>(ref this.productInfoArray, null, Mirror.GeneratedNetworkCode._Read_System.Int32[](reader));
			base.GeneratedSyncVarDeserialize<int>(ref this.productsLeft, null, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int[]>(ref this.productInfoArray, null, Mirror.GeneratedNetworkCode._Read_System.Int32[](reader));
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.productsLeft, null, reader.ReadInt());
		}
	}

	// Token: 0x040001A0 RID: 416
	[Header("Networked Info")]
	[SyncVar]
	public int[] productInfoArray = new int[]
	{
		-1,
		0,
		-1,
		0,
		-1,
		0,
		-1,
		0,
		-1,
		0
	};

	// Token: 0x040001A1 RID: 417
	[SyncVar]
	public int productsLeft;

	// Token: 0x040001A2 RID: 418
	public GameObject currentNPC;

	// Token: 0x040001A3 RID: 419
	public bool isCheckoutClosed;

	// Token: 0x040001A4 RID: 420
	public bool isOccupiedByNPCCashier;

	// Token: 0x040001A5 RID: 421
	public bool[] checkoutQueue;

	// Token: 0x040001A6 RID: 422
	public float checkoutProductValue;

	// Token: 0x040001A7 RID: 423
	public float currentAmountToReturn;

	// Token: 0x040001A8 RID: 424
	public float moneyToReturn;

	// Token: 0x040001A9 RID: 425
	public bool allowMoneyReturn;

	// Token: 0x040001AA RID: 426
	public List<GameObject> internalProductListForEmployees = new List<GameObject>();

	// Token: 0x040001AB RID: 427
	[Header("Static Info")]
	public int containerClass;

	// Token: 0x040001AC RID: 428
	public int containerID = 1;

	// Token: 0x040001AD RID: 429
	public int cost = 100;

	// Token: 0x040001AE RID: 430
	public float shelfLength = 1f;

	// Token: 0x040001AF RID: 431
	public float shelfWidth = 1f;

	// Token: 0x040001B0 RID: 432
	public float shelfHeight = 1f;

	// Token: 0x040001B1 RID: 433
	public int parentIndex;

	// Token: 0x040001B2 RID: 434
	public string buildableTag;

	// Token: 0x040001B3 RID: 435
	public AudioClip[] audioCoinsArray;

	// Token: 0x040001B4 RID: 436
	public AudioClip[] audioNotesArray;

	// Token: 0x040001B5 RID: 437
	public AudioSource moneySoundAudioSource;

	// Token: 0x040001B6 RID: 438
	[Space(10f)]
	public GameObject dummyPrefab;

	// Token: 0x040001B7 RID: 439
	public GameObject storageBoxPrefab;

	// Token: 0x040001B8 RID: 440
	public Vector3 productAngleOffset = new Vector3(0f, 90f, 0f);

	// Token: 0x040001B9 RID: 441
	private Material ownerMaterial;

	// Token: 0x040001BA RID: 442
	private Material movingMaterial;

	// Token: 0x040001BB RID: 443
	private BoxCollider[] colliderArray;

	// Token: 0x040001BC RID: 444
	public MeshRenderer[] mRenderersArray;

	// Token: 0x040001BD RID: 445
	private GameObject overlapOBJ;

	// Token: 0x040001BE RID: 446
	private ProductListing productlistComponent;

	// Token: 0x040001BF RID: 447
	private int productsCounterForBags;

	// Token: 0x040001C0 RID: 448
	private bool highLatencyCooldown;

	// Token: 0x040001C1 RID: 449
	private const float offsetFactor = 1.1f;
}

using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
public class Data_Product : MonoBehaviour
{
	// Token: 0x040001D3 RID: 467
	public int productID;

	// Token: 0x040001D4 RID: 468
	public int productContainerClass;

	// Token: 0x040001D5 RID: 469
	public int boxClass;

	// Token: 0x040001D6 RID: 470
	public int maxItemsPerBox = 20;

	// Token: 0x040001D7 RID: 471
	public float basePricePerUnit;

	// Token: 0x040001D8 RID: 472
	public string productBrand;

	// Token: 0x040001D9 RID: 473
	public int productTier;

	// Token: 0x040001DA RID: 474
	public bool isStackable;
}

using System;
using UnityEngine;

// Token: 0x02000019 RID: 25
public class DayNight : MonoBehaviour
{
	// Token: 0x0600005C RID: 92 RVA: 0x0000465C File Offset: 0x0000285C
	private void Start()
	{
	}

	// Token: 0x0600005D RID: 93 RVA: 0x000067D0 File Offset: 0x000049D0
	private void Update()
	{
		if (Input.GetKeyDown("t"))
		{
			if (this.Day.activeSelf)
			{
				RenderSettings.skybox = this.SkyboxNight;
				RenderSettings.fogColor = this.FogColorNight;
				this.Night.SetActive(true);
				this.Day.SetActive(false);
			}
			else
			{
				RenderSettings.skybox = this.SkyboxDay;
				RenderSettings.fogColor = this.FogColorDay;
				this.Night.SetActive(false);
				this.Day.SetActive(true);
			}
		}
		if (Input.GetKeyDown("r"))
		{
			if (this.Rain.activeSelf)
			{
				this.Rain.SetActive(false);
				return;
			}
			this.Rain.SetActive(true);
		}
	}

	// Token: 0x040000A9 RID: 169
	public GameObject Day;

	// Token: 0x040000AA RID: 170
	public GameObject Night;

	// Token: 0x040000AB RID: 171
	public GameObject Rain;

	// Token: 0x040000AC RID: 172
	public Material SkyboxNight;

	// Token: 0x040000AD RID: 173
	public Material SkyboxDay;

	// Token: 0x040000AE RID: 174
	public Color FogColorNight;

	// Token: 0x040000AF RID: 175
	public Color FogColorDay;
}

using System;
using UnityEngine;

// Token: 0x0200004F RID: 79
public class DEBUG_AutoFill : MonoBehaviour
{
	// Token: 0x060001E5 RID: 485 RVA: 0x000122F8 File Offset: 0x000104F8
	private void Update()
	{
		if (Input.GetKeyDown("f9"))
		{
			this.productID--;
			this.productID = Mathf.Clamp(this.productID, 0, 190);
		}
		if (Input.GetKeyDown("f11"))
		{
			this.productID++;
			this.productID = Mathf.Clamp(this.productID, 0, 190);
		}
		if (Input.GetKeyDown("f10"))
		{
			this.AddProduct();
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0001237C File Offset: 0x0001057C
	private void AddProduct()
	{
		foreach (object obj in this.shelvesOBJ.transform)
		{
			Transform transform = (Transform)obj;
			Data_Container component = transform.GetComponent<Data_Container>();
			int[] productInfoArray = component.productInfoArray;
			int num = productInfoArray.Length / 2;
			int containerClass = component.containerClass;
			int productContainerClass = ProductListing.Instance.productPrefabs[this.productID].GetComponent<Data_Product>().productContainerClass;
			if (containerClass == productContainerClass)
			{
				for (int i = 0; i < num; i++)
				{
					if (productInfoArray[i * 2] < 0)
					{
						float shelfLength = transform.GetComponent<Data_Container>().shelfLength;
						float shelfWidth = transform.GetComponent<Data_Container>().shelfWidth;
						float shelfHeight = transform.GetComponent<Data_Container>().shelfHeight;
						int maxProductsPerRow = this.GetMaxProductsPerRow(this.productID, shelfLength, shelfWidth, shelfHeight);
						component.DebugAdd(i * 2, this.productID, maxProductsPerRow);
						return;
					}
				}
			}
		}
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00012484 File Offset: 0x00010684
	private int GetMaxProductsPerRow(int ProductID, float shelfLength, float shelfWidth, float shelfHeight)
	{
		GameObject gameObject = ProductListing.Instance.productPrefabs[ProductID];
		Vector3 size = gameObject.GetComponent<BoxCollider>().size;
		bool isStackable = gameObject.GetComponent<Data_Product>().isStackable;
		int num = Mathf.FloorToInt(shelfLength / (size.x * 1.1f));
		num = Mathf.Clamp(num, 1, 100);
		int num2 = Mathf.FloorToInt(shelfWidth / (size.z * 1.1f));
		num2 = Mathf.Clamp(num2, 1, 100);
		int result = num * num2;
		if (isStackable)
		{
			int num3 = Mathf.FloorToInt(shelfHeight / (size.y * 1.1f));
			num3 = Mathf.Clamp(num3, 1, 100);
			result = num * num2 * num3;
		}
		return result;
	}

	// Token: 0x040001DB RID: 475
	public GameObject shelvesOBJ;

	// Token: 0x040001DC RID: 476
	public int productID;
}

using System;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

// Token: 0x02000050 RID: 80
public class DecorationExtraData : NetworkBehaviour
{
	// Token: 0x060001E9 RID: 489 RVA: 0x0001251F File Offset: 0x0001071F
	public override void OnStartClient()
	{
		this.OnChangeMainInt(0, this.intValue);
		if (this.stringValue == "")
		{
			this.NetworkstringValue = "?";
		}
		this.OnChangeMainString("", this.stringValue);
	}

	// Token: 0x060001EA RID: 490 RVA: 0x0001255C File Offset: 0x0001075C
	[Command(requiresAuthority = false)]
	public void CmdChangeColor(int colorIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(colorIndex);
		base.SendCommandInternal("System.Void DecorationExtraData::CmdChangeColor(System.Int32)", -1136098495, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00012598 File Offset: 0x00010798
	[Command(requiresAuthority = false)]
	public void CmdChangeText(string text)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(text);
		base.SendCommandInternal("System.Void DecorationExtraData::CmdChangeText(System.String)", -324514478, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060001EC RID: 492 RVA: 0x000125D4 File Offset: 0x000107D4
	private void OnChangeMainInt(int oldInt, int newInt)
	{
		newInt = Mathf.Clamp(newInt, 0, this.colorArray.Length);
		Color value = this.colorArray[newInt];
		GameObject[] array = this.signOBJs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<MeshRenderer>().material.SetColor("_BaseColor", value);
		}
	}

	// Token: 0x060001ED RID: 493 RVA: 0x0001262C File Offset: 0x0001082C
	private void OnChangeMainString(string oldString, string newString)
	{
		if (newString == "")
		{
			newString = "?";
		}
		GameObject[] array = this.textOBJs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].GetComponent<TextMeshProUGUI>().text = newString;
		}
	}

	// Token: 0x060001EE RID: 494 RVA: 0x00012670 File Offset: 0x00010870
	public DecorationExtraData()
	{
		this._Mirror_SyncVarHookDelegate_intValue = new Action<int, int>(this.OnChangeMainInt);
		this._Mirror_SyncVarHookDelegate_stringValue = new Action<string, string>(this.OnChangeMainString);
	}

	// Token: 0x060001EF RID: 495 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060001F0 RID: 496 RVA: 0x0001269C File Offset: 0x0001089C
	// (set) Token: 0x060001F1 RID: 497 RVA: 0x000126AF File Offset: 0x000108AF
	public int NetworkintValue
	{
		get
		{
			return this.intValue;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.intValue, 1UL, this._Mirror_SyncVarHookDelegate_intValue);
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060001F2 RID: 498 RVA: 0x000126D0 File Offset: 0x000108D0
	// (set) Token: 0x060001F3 RID: 499 RVA: 0x000126E3 File Offset: 0x000108E3
	public string NetworkstringValue
	{
		get
		{
			return this.stringValue;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<string>(value, ref this.stringValue, 2UL, this._Mirror_SyncVarHookDelegate_stringValue);
		}
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00012702 File Offset: 0x00010902
	protected void UserCode_CmdChangeColor__Int32(int colorIndex)
	{
		this.NetworkintValue = colorIndex;
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x0001270B File Offset: 0x0001090B
	protected static void InvokeUserCode_CmdChangeColor__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdChangeColor called on client.");
			return;
		}
		((DecorationExtraData)obj).UserCode_CmdChangeColor__Int32(reader.ReadInt());
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00012734 File Offset: 0x00010934
	protected void UserCode_CmdChangeText__String(string text)
	{
		this.NetworkstringValue = text;
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x0001273D File Offset: 0x0001093D
	protected static void InvokeUserCode_CmdChangeText__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdChangeText called on client.");
			return;
		}
		((DecorationExtraData)obj).UserCode_CmdChangeText__String(reader.ReadString());
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00012768 File Offset: 0x00010968
	static DecorationExtraData()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DecorationExtraData), "System.Void DecorationExtraData::CmdChangeColor(System.Int32)", new RemoteCallDelegate(DecorationExtraData.InvokeUserCode_CmdChangeColor__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(DecorationExtraData), "System.Void DecorationExtraData::CmdChangeText(System.String)", new RemoteCallDelegate(DecorationExtraData.InvokeUserCode_CmdChangeText__String), false);
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x000127B8 File Offset: 0x000109B8
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.intValue);
			writer.WriteString(this.stringValue);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.intValue);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteString(this.stringValue);
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00012840 File Offset: 0x00010A40
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.intValue, this._Mirror_SyncVarHookDelegate_intValue, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<string>(ref this.stringValue, this._Mirror_SyncVarHookDelegate_stringValue, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.intValue, this._Mirror_SyncVarHookDelegate_intValue, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<string>(ref this.stringValue, this._Mirror_SyncVarHookDelegate_stringValue, reader.ReadString());
		}
	}

	// Token: 0x040001DD RID: 477
	[SyncVar(hook = "OnChangeMainInt")]
	public int intValue;

	// Token: 0x040001DE RID: 478
	[SyncVar(hook = "OnChangeMainString")]
	public string stringValue;

	// Token: 0x040001DF RID: 479
	public Color[] colorArray;

	// Token: 0x040001E0 RID: 480
	public GameObject[] signOBJs;

	// Token: 0x040001E1 RID: 481
	public GameObject[] textOBJs;

	// Token: 0x040001E2 RID: 482
	public Action<int, int> _Mirror_SyncVarHookDelegate_intValue;

	// Token: 0x040001E3 RID: 483
	public Action<string, string> _Mirror_SyncVarHookDelegate_stringValue;
}

using System;
using UnityEngine;

// Token: 0x02000051 RID: 81
public class DelayBoxMesh : MonoBehaviour
{
	// Token: 0x060001FB RID: 507 RVA: 0x0000465C File Offset: 0x0000285C
	private void Start()
	{
	}

	// Token: 0x060001FC RID: 508 RVA: 0x0000465C File Offset: 0x0000285C
	private void Update()
	{
	}
}

using System;
using TMPro;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class DropdownSample : MonoBehaviour
{
	// Token: 0x0600073D RID: 1853 RVA: 0x0002D9BC File Offset: 0x0002BBBC
	public void OnButtonClick()
	{
		this.text.text = ((this.dropdownWithPlaceholder.value > -1) ? ("Selected values:\n" + this.dropdownWithoutPlaceholder.value.ToString() + " - " + this.dropdownWithPlaceholder.value.ToString()) : "Error: Please make a selection");
	}

	// Token: 0x040005AE RID: 1454
	[SerializeField]
	private TextMeshProUGUI text;

	// Token: 0x040005AF RID: 1455
	[SerializeField]
	private TMP_Dropdown dropdownWithoutPlaceholder;

	// Token: 0x040005B0 RID: 1456
	[SerializeField]
	private TMP_Dropdown dropdownWithPlaceholder;
}

using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000052 RID: 82
public class DummyStuff : MonoBehaviour
{
	// Token: 0x060001FE RID: 510 RVA: 0x000128E6 File Offset: 0x00010AE6
	private void Start()
	{
		base.StartCoroutine(this.meowRoutine());
	}

	// Token: 0x060001FF RID: 511 RVA: 0x000128F5 File Offset: 0x00010AF5
	private IEnumerator meowRoutine()
	{
		yield return new WaitForSeconds(Random.Range(1f, 10f));
		this.FillRows();
		yield break;
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00012904 File Offset: 0x00010B04
	public void FillRows()
	{
		if (!this.productlistComponent)
		{
			this.productlistComponent = GameData.Instance.GetComponent<ProductListing>();
		}
		for (int i = 0; i < this.productArray.Length; i++)
		{
			GameObject gameObject = this.productlistComponent.productPrefabs[Random.Range(0, 175)];
			Vector3 size = gameObject.GetComponent<BoxCollider>().size;
			int num = Mathf.FloorToInt(this.shelfLength / (size.x * 1.1f));
			int num2 = Mathf.FloorToInt(this.shelfWidth / (size.z * 1.1f));
			int num3 = num * num2;
			Transform child = base.transform.Find("ProductContainer").gameObject.transform.GetChild(i);
			for (int j = 0; j < num3; j++)
			{
				int num4 = j / num;
				int num5 = j % num;
				GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
				gameObject2.transform.SetParent(child);
				gameObject2.transform.localPosition = new Vector3((float)num4 * size.z * 1.1f, 0f, (float)num5 * size.x * 1.1f) + new Vector3(size.z / 2f, 0f, size.x / 2f);
				gameObject2.transform.localRotation = Quaternion.Euler(this.productAngleOffset);
			}
		}
	}

	// Token: 0x040001E4 RID: 484
	public int[] productArray = new int[]
	{
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x040001E5 RID: 485
	public float shelfLength = 1f;

	// Token: 0x040001E6 RID: 486
	public float shelfWidth = 1f;

	// Token: 0x040001E7 RID: 487
	public Vector3 productAngleOffset = new Vector3(0f, 90f, 0f);

	// Token: 0x040001E8 RID: 488
	private ProductListing productlistComponent;

	// Token: 0x040001E9 RID: 489
	private const float offsetFactor = 1.1f;
}

using System;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000054 RID: 84
public class EasterBehaviour : NetworkBehaviour
{
	// Token: 0x06000208 RID: 520 RVA: 0x00012B40 File Offset: 0x00010D40
	public override void OnStartClient()
	{
		base.OnStartClient();
		this.CreateObject(this.easterID);
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00012B54 File Offset: 0x00010D54
	private void CreateObject(int arrayIndex)
	{
		if (arrayIndex >= this.eastersArray.Length)
		{
			return;
		}
		GameObject gameObject = this.eastersArray[arrayIndex];
		if (gameObject)
		{
			Object.Instantiate<GameObject>(gameObject, base.transform).transform.localPosition = Vector3.zero;
			if (arrayIndex == 0)
			{
				if (base.isServer)
				{
					base.GetComponent<NavMeshAgent>().enabled = true;
					base.GetComponent<PlayMakerFSM>().enabled = true;
				}
				base.transform.position = new Vector3(0f, 0f, -6f);
			}
		}
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00012BDC File Offset: 0x00010DDC
	[Command(requiresAuthority = false)]
	public void CmdFredString()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void EasterBehaviour::CmdFredString()", 2063726036, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00012C0C File Offset: 0x00010E0C
	[ClientRpc]
	private void RpcFredString(int indexValue)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(indexValue);
		this.SendRPCInternal("System.Void EasterBehaviour::RpcFredString(System.Int32)", 951635282, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00012C48 File Offset: 0x00010E48
	[Command(requiresAuthority = false)]
	public void CmdFredWalkState(bool set)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(set);
		base.SendCommandInternal("System.Void EasterBehaviour::CmdFredWalkState(System.Boolean)", -2118329798, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x0600020F RID: 527 RVA: 0x00012C84 File Offset: 0x00010E84
	// (set) Token: 0x06000210 RID: 528 RVA: 0x00012C97 File Offset: 0x00010E97
	public int NetworkeasterID
	{
		get
		{
			return this.easterID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.easterID, 1UL, null);
		}
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00012CB1 File Offset: 0x00010EB1
	protected void UserCode_CmdFredString()
	{
		if (this.fredCounter >= this.fredStrings.Length)
		{
			this.fredCounter = 0;
		}
		this.RpcFredString(this.fredCounter);
		this.fredCounter++;
	}

	// Token: 0x06000212 RID: 530 RVA: 0x00012CE4 File Offset: 0x00010EE4
	protected static void InvokeUserCode_CmdFredString(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdFredString called on client.");
			return;
		}
		((EasterBehaviour)obj).UserCode_CmdFredString();
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00012D07 File Offset: 0x00010F07
	protected void UserCode_RpcFredString__Int32(int indexValue)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.textPrefabOBJ, base.transform.position + Vector3.up, Quaternion.identity);
		gameObject.GetComponent<TextMeshPro>().text = this.fredStrings[indexValue];
		gameObject.SetActive(true);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00012D47 File Offset: 0x00010F47
	protected static void InvokeUserCode_RpcFredString__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcFredString called on server.");
			return;
		}
		((EasterBehaviour)obj).UserCode_RpcFredString__Int32(reader.ReadInt());
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00012D70 File Offset: 0x00010F70
	protected void UserCode_CmdFredWalkState__Boolean(bool set)
	{
		base.transform.GetChild(0).GetComponent<Animator>().SetBool("Walking", set);
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00012D8E File Offset: 0x00010F8E
	protected static void InvokeUserCode_CmdFredWalkState__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdFredWalkState called on client.");
			return;
		}
		((EasterBehaviour)obj).UserCode_CmdFredWalkState__Boolean(reader.ReadBool());
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00012DB8 File Offset: 0x00010FB8
	static EasterBehaviour()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(EasterBehaviour), "System.Void EasterBehaviour::CmdFredString()", new RemoteCallDelegate(EasterBehaviour.InvokeUserCode_CmdFredString), false);
		RemoteProcedureCalls.RegisterCommand(typeof(EasterBehaviour), "System.Void EasterBehaviour::CmdFredWalkState(System.Boolean)", new RemoteCallDelegate(EasterBehaviour.InvokeUserCode_CmdFredWalkState__Boolean), false);
		RemoteProcedureCalls.RegisterRpc(typeof(EasterBehaviour), "System.Void EasterBehaviour::RpcFredString(System.Int32)", new RemoteCallDelegate(EasterBehaviour.InvokeUserCode_RpcFredString__Int32));
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00012E28 File Offset: 0x00011028
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.easterID);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.easterID);
		}
	}

	// Token: 0x06000219 RID: 537 RVA: 0x00012E80 File Offset: 0x00011080
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.easterID, null, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.easterID, null, reader.ReadInt());
		}
	}

	// Token: 0x040001ED RID: 493
	[SyncVar]
	public int easterID;

	// Token: 0x040001EE RID: 494
	public GameObject[] eastersArray;

	// Token: 0x040001EF RID: 495
	public GameObject textPrefabOBJ;

	// Token: 0x040001F0 RID: 496
	public string[] fredStrings;

	// Token: 0x040001F1 RID: 497
	private int fredCounter;
}

using System;
using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x02000055 RID: 85
public class EasterChecker : NetworkBehaviour
{
	// Token: 0x0600021A RID: 538 RVA: 0x00012EDC File Offset: 0x000110DC
	public void StringChecker(string message)
	{
		if (this.spawnCooldown || message == "" || !base.isServer)
		{
			return;
		}
		for (int i = 0; i < this.checkersArray.Length; i++)
		{
			if (!this.alreadySpawned[i] && message.Contains(this.checkersArray[i]))
			{
				this.CmdSpawnEaster(i);
				base.StartCoroutine(this.SpawnCooldown());
				this.alreadySpawned[i] = true;
				return;
			}
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00012F54 File Offset: 0x00011154
	[Command(requiresAuthority = false)]
	private void CmdSpawnEaster(int easterIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(easterIndex);
		base.SendCommandInternal("System.Void EasterChecker::CmdSpawnEaster(System.Int32)", 2083728754, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00012F8E File Offset: 0x0001118E
	private IEnumerator SpawnCooldown()
	{
		this.spawnCooldown = true;
		yield return new WaitForSeconds(5f);
		this.spawnCooldown = false;
		yield break;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x00012F9D File Offset: 0x0001119D
	protected void UserCode_CmdSpawnEaster__Int32(int easterIndex)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.easterPrefab);
		gameObject.GetComponent<EasterBehaviour>().NetworkeasterID = easterIndex;
		NetworkServer.Spawn(gameObject, null);
	}

	// Token: 0x06000220 RID: 544 RVA: 0x00012FBC File Offset: 0x000111BC
	protected static void InvokeUserCode_CmdSpawnEaster__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnEaster called on client.");
			return;
		}
		((EasterChecker)obj).UserCode_CmdSpawnEaster__Int32(reader.ReadInt());
	}

	// Token: 0x06000221 RID: 545 RVA: 0x00012FE5 File Offset: 0x000111E5
	static EasterChecker()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(EasterChecker), "System.Void EasterChecker::CmdSpawnEaster(System.Int32)", new RemoteCallDelegate(EasterChecker.InvokeUserCode_CmdSpawnEaster__Int32), false);
	}

	// Token: 0x040001F2 RID: 498
	public string[] checkersArray;

	// Token: 0x040001F3 RID: 499
	public bool[] alreadySpawned;

	// Token: 0x040001F4 RID: 500
	public GameObject easterPrefab;

	// Token: 0x040001F5 RID: 501
	private bool spawnCooldown;
}

using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class EnvMapAnimator : MonoBehaviour
{
	// Token: 0x0600073F RID: 1855 RVA: 0x0002DA1E File Offset: 0x0002BC1E
	private void Awake()
	{
		this.m_textMeshPro = base.GetComponent<TMP_Text>();
		this.m_material = this.m_textMeshPro.fontSharedMaterial;
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x0002DA3D File Offset: 0x0002BC3D
	private IEnumerator Start()
	{
		Matrix4x4 matrix = default(Matrix4x4);
		for (;;)
		{
			matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * this.RotationSpeeds.x, Time.time * this.RotationSpeeds.y, Time.time * this.RotationSpeeds.z), Vector3.one);
			this.m_material.SetMatrix("_EnvMatrix", matrix);
			yield return null;
		}
		yield break;
	}

	// Token: 0x040005B1 RID: 1457
	public Vector3 RotationSpeeds;

	// Token: 0x040005B2 RID: 1458
	private TMP_Text m_textMeshPro;

	// Token: 0x040005B3 RID: 1459
	private Material m_material;
}

using System;
using HutongGames.PlayMaker;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class EventDataSenderProxy : ScriptableObject
{
	// Token: 0x0400011C RID: 284
	public FsmEventTarget EventTarget = new FsmEventTarget();
}

using System;
using UnityEngine;

// Token: 0x02000057 RID: 87
public class ExpansionAuxiliar : MonoBehaviour
{
	// Token: 0x040001F9 RID: 505
	public GameObject[] relatedPaintablesOBJs;
}

using System;

// Token: 0x0200001C RID: 28
[AttributeUsage(AttributeTargets.Method)]
public class ExposeMethodInEditorAttribute : Attribute
{
}

using System;
using System.Collections;
using StarterAssets;
using UnityEngine;

// Token: 0x020000A5 RID: 165
public class FirstPersonTransform : MonoBehaviour
{
	// Token: 0x060005A9 RID: 1449 RVA: 0x00027160 File Offset: 0x00025360
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.PController = base.GetComponent<FirstPersonController>();
		this.safeBool = false;
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00027184 File Offset: 0x00025384
	public void coroutineActivator(Vector3 position, float Yrotation)
	{
		if (this.PController.inVehicle && this.PController.vehicleSpot && this.PController.vehicleSpot.transform.parent.GetComponent<MiniTransportBehaviour>())
		{
			this.PController.vehicleSpot.transform.parent.GetComponent<MiniTransportBehaviour>().RemoveOwnershipFromTeleport();
		}
		if (!this.safeBool)
		{
			base.StartCoroutine(this.RepositionRoutine(position, Yrotation));
		}
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x00027207 File Offset: 0x00025407
	private IEnumerator RepositionRoutine(Vector3 position, float Yrotation)
	{
		if (this.PController == null)
		{
			this.rb = base.GetComponent<Rigidbody>();
			this.PController = base.GetComponent<FirstPersonController>();
		}
		this.safeBool = true;
		this.PController.isTeleporting = true;
		this.rb.useGravity = false;
		yield return new WaitForFixedUpdate();
		base.transform.position = position;
		base.transform.localRotation = Quaternion.Euler(0f, Yrotation, 0f);
		yield return new WaitForFixedUpdate();
		this.rb.useGravity = true;
		this.PController.isTeleporting = false;
		this.safeBool = false;
		yield break;
	}

	// Token: 0x0400049D RID: 1181
	private FirstPersonController PController;

	// Token: 0x0400049E RID: 1182
	private Rigidbody rb;

	// Token: 0x0400049F RID: 1183
	private bool safeBool;
}

using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class FreeCamera : MonoBehaviour
{
	// Token: 0x06000064 RID: 100 RVA: 0x000068B0 File Offset: 0x00004AB0
	private void Update()
	{
		float d = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? this.fastMovementSpeed : this.movementSpeed;
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			base.transform.position = base.transform.position + -base.transform.right * d * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			base.transform.position = base.transform.position + base.transform.right * d * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			base.transform.position = base.transform.position + base.transform.forward * d * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			base.transform.position = base.transform.position + -base.transform.forward * d * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.Q))
		{
			base.transform.position = base.transform.position + base.transform.up * d * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.E))
		{
			base.transform.position = base.transform.position + -base.transform.up * d * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
		{
			base.transform.position = base.transform.position + Vector3.up * d * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
		{
			base.transform.position = base.transform.position + -Vector3.up * d * Time.deltaTime;
		}
		if (this.looking)
		{
			float y = base.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * this.freeLookSensitivity;
			float x = base.transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * this.freeLookSensitivity;
			base.transform.localEulerAngles = new Vector3(x, y, 0f);
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis > 0f)
		{
			Camera component = base.GetComponent<Camera>();
			float fieldOfView = component.fieldOfView;
			component.fieldOfView = fieldOfView - 1f;
		}
		else if (axis < 0f)
		{
			Camera component2 = base.GetComponent<Camera>();
			float fieldOfView = component2.fieldOfView;
			component2.fieldOfView = fieldOfView + 1f;
		}
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			this.StartLooking();
			return;
		}
		if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			this.StopLooking();
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00006C0C File Offset: 0x00004E0C
	private void OnDisable()
	{
		this.StopLooking();
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00006C14 File Offset: 0x00004E14
	public void StartLooking()
	{
		this.looking = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00006C29 File Offset: 0x00004E29
	public void StopLooking()
	{
		this.looking = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	// Token: 0x040000B2 RID: 178
	public float movementSpeed = 10f;

	// Token: 0x040000B3 RID: 179
	public float fastMovementSpeed = 100f;

	// Token: 0x040000B4 RID: 180
	public float freeLookSensitivity = 3f;

	// Token: 0x040000B5 RID: 181
	public float zoomSensitivity = 10f;

	// Token: 0x040000B6 RID: 182
	public float fastZoomSensitivity = 50f;

	// Token: 0x040000B7 RID: 183
	private bool looking;
}

using System;
using UnityEngine;
using UnityEngine.AI;

// Token: 0x02000033 RID: 51
public class FsmNavMeshPath : MonoBehaviour
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060000BD RID: 189 RVA: 0x00008D6B File Offset: 0x00006F6B
	public NavMeshPathStatus status
	{
		get
		{
			if (this.path == null)
			{
				return NavMeshPathStatus.PathInvalid;
			}
			return this.path.status;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x060000BF RID: 191 RVA: 0x00008D9C File Offset: 0x00006F9C
	// (set) Token: 0x060000BE RID: 190 RVA: 0x00008D82 File Offset: 0x00006F82
	public NavMeshPath path
	{
		get
		{
			return this._path;
		}
		set
		{
			this._path = value;
			this.corners = this._path.corners;
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x0000465C File Offset: 0x0000285C
	private void Start()
	{
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00008DA4 File Offset: 0x00006FA4
	private void ClearCorners()
	{
		this.path.ClearCorners();
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00008DB4 File Offset: 0x00006FB4
	public string GetStatusString()
	{
		if (this.path == null)
		{
			return "n/a";
		}
		return this.path.status.ToString();
	}

	// Token: 0x0400011A RID: 282
	public Vector3[] corners;

	// Token: 0x0400011B RID: 283
	private NavMeshPath _path;
}

using System;
using System.Xml;
using UnityEngine;

// Token: 0x0200002F RID: 47
public class FsmXmlNode : Object
{
	// Token: 0x17000007 RID: 7
	// (get) Token: 0x060000B2 RID: 178 RVA: 0x00008B54 File Offset: 0x00006D54
	// (set) Token: 0x060000B3 RID: 179 RVA: 0x00008B5C File Offset: 0x00006D5C
	public XmlNode Value
	{
		get
		{
			return this._xmlNode;
		}
		set
		{
			this._xmlNode = value;
		}
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00008B65 File Offset: 0x00006D65
	public override string ToString()
	{
		return "FsmXmlNode";
	}

	// Token: 0x04000117 RID: 279
	private XmlNode _xmlNode;
}

using System;
using System.Xml;
using UnityEngine;

// Token: 0x02000030 RID: 48
public class FsmXmlNodeList : Object
{
	// Token: 0x17000008 RID: 8
	// (get) Token: 0x060000B6 RID: 182 RVA: 0x00008B74 File Offset: 0x00006D74
	// (set) Token: 0x060000B7 RID: 183 RVA: 0x00008B7C File Offset: 0x00006D7C
	public XmlNodeList Value
	{
		get
		{
			return this._xmlNodeList;
		}
		set
		{
			Debug.Log(DataMakerXmlUtils.XmlNodeListToString(value));
			this._xmlNodeList = value;
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00008B90 File Offset: 0x00006D90
	public override string ToString()
	{
		return "FsmXmlNodeList";
	}

	// Token: 0x04000118 RID: 280
	private XmlNodeList _xmlNodeList;
}

using System;
using System.Xml;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

// Token: 0x02000026 RID: 38
public class FsmXmlPropertiesStorage : FsmStateAction
{
	// Token: 0x0600008A RID: 138 RVA: 0x000082A0 File Offset: 0x000064A0
	public void StoreNodeProperties(Fsm fsm, XmlNode node)
	{
		int num = 0;
		foreach (FsmString fsmString in this.properties)
		{
			string nodeProperty = DataMakerXmlActions.GetNodeProperty(node, fsmString.Value);
			PlayMakerUtils.ApplyValueToFsmVar(fsm, this.propertiesVariables[num], PlayMakerUtils.ParseValueFromString(nodeProperty, this.propertiesVariables[num].Type));
			num++;
		}
	}

	// Token: 0x040000F3 RID: 243
	public FsmString[] properties;

	// Token: 0x040000F4 RID: 244
	public FsmVar[] propertiesVariables;
}

using System;
using System.Collections.Generic;
using HutongGames.PlayMaker;

// Token: 0x02000027 RID: 39
public class FsmXmlPropertiesTypes : FsmStateAction
{
	// Token: 0x0600008C RID: 140 RVA: 0x00008308 File Offset: 0x00006508
	public void cacheTypes()
	{
		this._cache = new Dictionary<string, VariableType>();
		int num = 0;
		foreach (FsmString fsmString in this.properties)
		{
			this._cache.Add(fsmString.Value, this.propertiesTypes[num]);
			num++;
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00008358 File Offset: 0x00006558
	public VariableType GetPropertyType(string property)
	{
		if (this._cache == null)
		{
			this.cacheTypes();
		}
		if (this._cache.ContainsKey(property))
		{
			return this._cache[property];
		}
		return VariableType.Unknown;
	}

	// Token: 0x040000F5 RID: 245
	public FsmString[] properties;

	// Token: 0x040000F6 RID: 246
	public VariableType[] propertiesTypes;

	// Token: 0x040000F7 RID: 247
	private Dictionary<string, VariableType> _cache;
}

using System;
using System.Xml;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

// Token: 0x02000028 RID: 40
public class FsmXmlProperty : FsmStateAction
{
	// Token: 0x0600008F RID: 143 RVA: 0x00008384 File Offset: 0x00006584
	public static void StoreNodeProperties(Fsm fsm, XmlNode node, FsmXmlProperty[] properties)
	{
		int num = 0;
		foreach (FsmXmlProperty fsmXmlProperty in properties)
		{
			string nodeProperty = DataMakerXmlActions.GetNodeProperty(node, fsmXmlProperty.property.Value);
			PlayMakerUtils.ApplyValueToFsmVar(fsm, fsmXmlProperty.variable, PlayMakerUtils.ParseValueFromString(nodeProperty, fsmXmlProperty.variable.Type));
			num++;
		}
	}

	// Token: 0x040000F8 RID: 248
	public FsmString property;

	// Token: 0x040000F9 RID: 249
	[UIHint(UIHint.Variable)]
	public FsmVar variable;
}

using System;
using System.Xml;
using HutongGames.PlayMaker;
using UnityEngine;

// Token: 0x02000029 RID: 41
public class FsmXmlSource : FsmStateAction
{
	// Token: 0x06000091 RID: 145 RVA: 0x000083E0 File Offset: 0x000065E0
	private XmlNode GetXmlNodeFromString(string source)
	{
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.LoadXml(source);
		}
		catch (XmlException ex)
		{
			Debug.Log(source);
			Debug.LogWarning(ex.Message);
			return null;
		}
		return xmlDocument.DocumentElement;
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000092 RID: 146 RVA: 0x00008428 File Offset: 0x00006628
	public XmlNode Value
	{
		get
		{
			switch (this.sourceSelection)
			{
			case 0:
			case 2:
				return this.GetXmlNodeFromString(this.sourceString.Value);
			case 1:
				if (this.sourcetextAsset == null)
				{
					return null;
				}
				return this.GetXmlNodeFromString(this.sourcetextAsset.text);
			case 3:
			{
				DataMakerXmlProxy dataMakerXmlProxy = DataMakerCore.GetDataMakerProxyPointer<Type>(typeof(DataMakerXmlProxy), this.sourceProxyGameObject.Value, this.sourceProxyReference.Value, false) as DataMakerXmlProxy;
				if (dataMakerXmlProxy != null)
				{
					return dataMakerXmlProxy.xmlNode;
				}
				break;
			}
			case 4:
				return DataMakerXmlUtils.XmlRetrieveNode(this.inMemoryReference.Value);
			}
			return null;
		}
	}

	// Token: 0x040000FA RID: 250
	public string[] sourceTypes = new string[]
	{
		"Plain Text",
		"Text Asset",
		"Use Variable",
		"Use Proxy",
		"In Memory"
	};

	// Token: 0x040000FB RID: 251
	public int sourceSelection;

	// Token: 0x040000FC RID: 252
	public TextAsset sourcetextAsset;

	// Token: 0x040000FD RID: 253
	public FsmString sourceString;

	// Token: 0x040000FE RID: 254
	public FsmGameObject sourceProxyGameObject;

	// Token: 0x040000FF RID: 255
	public FsmString sourceProxyReference;

	// Token: 0x04000100 RID: 256
	public FsmString inMemoryReference;

	// Token: 0x04000101 RID: 257
	public bool _minimized;

	// Token: 0x04000102 RID: 258
	public Vector2 _scroll;

	// Token: 0x04000103 RID: 259
	public bool _sourcePreview = true;

	// Token: 0x04000104 RID: 260
	public bool _sourceEdit = true;
}

using System;
using HutongGames.PlayMaker;

// Token: 0x0200002A RID: 42
public class FsmXpathQuery : FsmStateAction
{
	// Token: 0x06000094 RID: 148 RVA: 0x00008538 File Offset: 0x00006738
	public string ParseXpathQuery(Fsm fsm)
	{
		this.parsedQuery = this.xPathQuery.Value;
		if (this.xPathVariables != null)
		{
			int num = 0;
			foreach (FsmVar fsmVar in this.xPathVariables)
			{
				if (!fsmVar.IsNone)
				{
					this.parsedQuery = this.parsedQuery.Replace("_" + num.ToString() + "_", PlayMakerUtils.ParseFsmVarToString(fsm, fsmVar));
				}
				num++;
			}
		}
		return this.parsedQuery;
	}

	// Token: 0x04000105 RID: 261
	public FsmString xPathQuery;

	// Token: 0x04000106 RID: 262
	public FsmVar[] xPathVariables;

	// Token: 0x04000107 RID: 263
	public bool _foldout = true;

	// Token: 0x04000108 RID: 264
	public string parsedQuery;
}

using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x02000058 RID: 88
public class GameCanvas : MonoBehaviour
{
	// Token: 0x06000229 RID: 553 RVA: 0x0001307A File Offset: 0x0001127A
	private void Awake()
	{
		if (GameCanvas.Instance == null)
		{
			GameCanvas.Instance = this;
		}
	}

	// Token: 0x0600022A RID: 554 RVA: 0x00013090 File Offset: 0x00011290
	public void CreateCanvasNotification(string hash)
	{
		if (this.inCooldown)
		{
			return;
		}
		string localizationString = LocalizationManager.instance.GetLocalizationString(hash);
		GameObject gameObject = Object.Instantiate<GameObject>(this.notificationPrefab, this.notificationParentTransform);
		gameObject.GetComponent<TextMeshProUGUI>().text = localizationString;
		gameObject.SetActive(true);
		base.StartCoroutine(this.NotificationCooldown());
	}

	// Token: 0x0600022B RID: 555 RVA: 0x000130E4 File Offset: 0x000112E4
	public void CreateImportantNotification(string hash)
	{
		if (this.inCooldown)
		{
			return;
		}
		string localizationString = LocalizationManager.instance.GetLocalizationString(hash);
		GameObject gameObject = Object.Instantiate<GameObject>(this.importantNotificationPrefab, this.importantNotificationParentTransform);
		gameObject.GetComponent<TextMeshProUGUI>().text = localizationString;
		gameObject.SetActive(true);
		base.StartCoroutine(this.NotificationCooldown());
	}

	// Token: 0x0600022C RID: 556 RVA: 0x00013138 File Offset: 0x00011338
	public void TriggerEndDayStats(int dCustomers, float dBenefits, int tRobbed, float mLostBecauseRobbing, int nFoundProducts, int tExpensiveProducts, float lCost, float rCost, float emploCost, float mSpentOnProducts, float oCosts, int filthComplaints, int todaysFranchiseExperience)
	{
		dBenefits = Mathf.Round(dBenefits * 100f) / 100f;
		mLostBecauseRobbing = Mathf.Round(mLostBecauseRobbing * 100f) / 100f;
		lCost = Mathf.Round(lCost * 100f) / 100f;
		rCost = Mathf.Round(rCost * 100f) / 100f;
		emploCost = Mathf.Round(emploCost * 100f) / 100f;
		mSpentOnProducts = Mathf.Round(mSpentOnProducts * 100f) / 100f;
		oCosts = Mathf.Round(oCosts * 100f) / 100f;
		this.dayTMP.text = LocalizationManager.instance.GetLocalizationString("day") + GameData.Instance.gameDay.ToString();
		this.dailyCustomersTMP.text = LocalizationManager.instance.GetLocalizationString("totalcustomers") + dCustomers.ToString();
		this.dayBenefitsTMP.text = LocalizationManager.instance.GetLocalizationString("income") + ": " + dBenefits.ToString();
		this.timesRobbedTMP.text = LocalizationManager.instance.GetLocalizationString("timesrobbed") + tRobbed.ToString();
		this.complaintsAboutFilthTMP.text = LocalizationManager.instance.GetLocalizationString("complaintsfilth") + filthComplaints.ToString();
		this.franchiseLevelTMP.text = LocalizationManager.instance.GetLocalizationString("franchiselevel") + GameData.Instance.gameFranchiseLevel.ToString();
		this.franchiseExperienceTMP.text = LocalizationManager.instance.GetLocalizationString("franchiseexperience") + "+" + todaysFranchiseExperience.ToString();
		this.moneyLostBecauseRobbingTMP.text = LocalizationManager.instance.GetLocalizationString("moneylostbecauserobbing") + mLostBecauseRobbing.ToString();
		this.notFoundProductsTMP.text = LocalizationManager.instance.GetLocalizationString("notfoundproducts") + nFoundProducts.ToString();
		this.tooExpensiveProductsTMP.text = LocalizationManager.instance.GetLocalizationString("tooexpensiveproducts") + tExpensiveProducts.ToString();
		this.lightCostTMP.text = LocalizationManager.instance.GetLocalizationString("electricitycost") + "-$" + lCost.ToString();
		this.rentCostTMP.text = LocalizationManager.instance.GetLocalizationString("rentcost") + "-$" + rCost.ToString();
		this.employeesCostTMP.text = LocalizationManager.instance.GetLocalizationString("employeeswages") + "-$" + emploCost.ToString();
		this.moneySpentOnProductsTMP.text = LocalizationManager.instance.GetLocalizationString("boughtproductscost") + "-$" + mSpentOnProducts.ToString();
		float num = Mathf.Abs(oCosts + mSpentOnProducts);
		this.otherCostsTMP.text = LocalizationManager.instance.GetLocalizationString("othercosts") + "-$" + Mathf.Abs(num).ToString();
		float num2 = dBenefits - mLostBecauseRobbing - lCost - rCost - emploCost - mSpentOnProducts - num;
		num2 = Mathf.Round(num2 * 100f) / 100f;
		if (num2 >= 0f)
		{
			this.dayBalanceTMP.text = "+$" + num2.ToString();
		}
		else
		{
			this.dayBalanceTMP.text = "-$" + Mathf.Abs(num2).ToString();
		}
		base.StartCoroutine(this.EndDayCoroutine());
	}

	// Token: 0x0600022D RID: 557 RVA: 0x000134D2 File Offset: 0x000116D2
	private IEnumerator EndDayCoroutine()
	{
		GameObject gameObject = base.transform.Find("EndDayStats").gameObject;
		GameObject containerOBJ = base.transform.Find("EndDayStats/Container").gameObject;
		CanvasGroup cGroup = gameObject.GetComponent<CanvasGroup>();
		CanvasGroup cGroup2 = containerOBJ.GetComponent<CanvasGroup>();
		containerOBJ.SetActive(false);
		gameObject.SetActive(true);
		cGroup.alpha = 0f;
		float elapsedTime = 0f;
		float waitTime = 2f;
		while (elapsedTime < waitTime)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / waitTime);
			cGroup.alpha = alpha;
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		cGroup.alpha = 1f;
		yield return new WaitForSeconds(1f);
		containerOBJ.SetActive(true);
		cGroup2.alpha = 0f;
		elapsedTime = 0f;
		while (elapsedTime < waitTime)
		{
			float alpha2 = Mathf.Lerp(0f, 1f, elapsedTime / waitTime);
			cGroup2.alpha = alpha2;
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		cGroup2.alpha = 1f;
		yield return null;
		yield break;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x000134E1 File Offset: 0x000116E1
	public void StartEndCoroutine()
	{
		base.StartCoroutine(this.EndDayCoroutineSecond());
	}

	// Token: 0x0600022F RID: 559 RVA: 0x000134F0 File Offset: 0x000116F0
	private IEnumerator EndDayCoroutineSecond()
	{
		GameObject endDayStatsOBJ = base.transform.Find("EndDayStats").gameObject;
		CanvasGroup cGroup = endDayStatsOBJ.GetComponent<CanvasGroup>();
		float elapsedTime = 0f;
		float waitTime = 2f;
		yield return new WaitForSeconds(1f);
		while (elapsedTime < waitTime)
		{
			float alpha = Mathf.Lerp(1f, 0f, elapsedTime / waitTime);
			cGroup.alpha = alpha;
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		endDayStatsOBJ.SetActive(false);
		yield break;
	}

	// Token: 0x06000230 RID: 560 RVA: 0x000134FF File Offset: 0x000116FF
	private IEnumerator NotificationCooldown()
	{
		this.inCooldown = true;
		yield return new WaitForSeconds(0.5f);
		this.inCooldown = false;
		yield break;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0001350E File Offset: 0x0001170E
	private void Update()
	{
		this.ShowInteractableInfo();
	}

	// Token: 0x06000232 RID: 562 RVA: 0x00013518 File Offset: 0x00011718
	private void ShowInteractableInfo()
	{
		RaycastHit raycastHit;
		if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 2.5f, this.lMask))
		{
			this.infoContainer.SetActive(false);
			return;
		}
		GameObject gameObject = raycastHit.transform.gameObject;
		if (gameObject.tag == "Interactable" && gameObject.GetComponent<InteractableData>() != null && gameObject.GetComponent<InteractableData>().hasInteractableData)
		{
			if (this.unlockContainerParent.transform.childCount > 0)
			{
				int childCount = this.unlockContainerParent.transform.childCount;
				for (int i = 0; i < childCount; i++)
				{
					Object.Destroy(this.unlockContainerParent.transform.GetChild(this.unlockContainerParent.transform.childCount - 1 - i).gameObject);
				}
			}
			if (this.requireContainerParent.transform.childCount > 0)
			{
				int childCount2 = this.requireContainerParent.transform.childCount;
				for (int j = 0; j < childCount2; j++)
				{
					Object.Destroy(this.requireContainerParent.transform.GetChild(this.requireContainerParent.transform.childCount - 1 - j).gameObject);
				}
			}
			this.mainTitleTMP.text = LocalizationManager.instance.GetLocalizationString(gameObject.GetComponent<InteractableData>().mainTitleString);
			string[] unlockStrings = gameObject.GetComponent<InteractableData>().unlockStrings;
			string[] requireStrings = gameObject.GetComponent<InteractableData>().requireStrings;
			for (int k = 0; k < unlockStrings.Length; k++)
			{
				GameObject gameObject2 = Object.Instantiate<GameObject>(this.UIInfoPrefab, this.unlockContainerParent.transform);
				string key = unlockStrings[k];
				gameObject2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString(key);
			}
			for (int l = 0; l < requireStrings.Length; l++)
			{
				GameObject gameObject3 = Object.Instantiate<GameObject>(this.UIInfoPrefab, this.requireContainerParent.transform);
				string key2 = requireStrings[l];
				gameObject3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString(key2);
			}
			this.infoContainer.SetActive(true);
			return;
		}
		this.infoContainer.SetActive(false);
	}

	// Token: 0x040001FA RID: 506
	public static GameCanvas Instance;

	// Token: 0x040001FB RID: 507
	public bool isCool;

	// Token: 0x040001FC RID: 508
	public GameObject notificationPrefab;

	// Token: 0x040001FD RID: 509
	public Transform notificationParentTransform;

	// Token: 0x040001FE RID: 510
	public GameObject importantNotificationPrefab;

	// Token: 0x040001FF RID: 511
	public Transform importantNotificationParentTransform;

	// Token: 0x04000200 RID: 512
	[Space(10f)]
	public GameObject infoContainer;

	// Token: 0x04000201 RID: 513
	public TextMeshProUGUI mainTitleTMP;

	// Token: 0x04000202 RID: 514
	public GameObject unlockContainerParent;

	// Token: 0x04000203 RID: 515
	public GameObject requireContainerParent;

	// Token: 0x04000204 RID: 516
	public GameObject UIInfoPrefab;

	// Token: 0x04000205 RID: 517
	public LayerMask lMask;

	// Token: 0x04000206 RID: 518
	[Space(10f)]
	public TextMeshProUGUI dayTMP;

	// Token: 0x04000207 RID: 519
	public TextMeshProUGUI dailyCustomersTMP;

	// Token: 0x04000208 RID: 520
	public TextMeshProUGUI dayBenefitsTMP;

	// Token: 0x04000209 RID: 521
	public TextMeshProUGUI timesRobbedTMP;

	// Token: 0x0400020A RID: 522
	public TextMeshProUGUI complaintsAboutFilthTMP;

	// Token: 0x0400020B RID: 523
	public TextMeshProUGUI franchiseLevelTMP;

	// Token: 0x0400020C RID: 524
	public TextMeshProUGUI franchiseExperienceTMP;

	// Token: 0x0400020D RID: 525
	public TextMeshProUGUI moneyLostBecauseRobbingTMP;

	// Token: 0x0400020E RID: 526
	public TextMeshProUGUI notFoundProductsTMP;

	// Token: 0x0400020F RID: 527
	public TextMeshProUGUI tooExpensiveProductsTMP;

	// Token: 0x04000210 RID: 528
	public TextMeshProUGUI lightCostTMP;

	// Token: 0x04000211 RID: 529
	public TextMeshProUGUI rentCostTMP;

	// Token: 0x04000212 RID: 530
	public TextMeshProUGUI employeesCostTMP;

	// Token: 0x04000213 RID: 531
	public TextMeshProUGUI otherCostsTMP;

	// Token: 0x04000214 RID: 532
	public TextMeshProUGUI moneySpentOnProductsTMP;

	// Token: 0x04000215 RID: 533
	public TextMeshProUGUI dayBalanceTMP;

	// Token: 0x04000216 RID: 534
	[Space(10f)]
	public GameObject jReference;

	// Token: 0x04000217 RID: 535
	public GameObject paintablesReference;

	// Token: 0x04000218 RID: 536
	private bool inCooldown;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using Mirror;
using Mirror.RemoteCalls;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

// Token: 0x0200005C RID: 92
public class GameData : NetworkBehaviour
{
	// Token: 0x06000246 RID: 582 RVA: 0x00013B1E File Offset: 0x00011D1E
	private void Awake()
	{
		if (GameData.Instance == null)
		{
			GameData.Instance = this;
		}
	}

	// Token: 0x06000247 RID: 583 RVA: 0x00013B33 File Offset: 0x00011D33
	public override void OnStartClient()
	{
		this.UpdateUIFunds(0f, this.gameFunds);
		this.UpdateDayName(0, this.gameDay);
		this.CalculateFranchiseLevel(0, this.gameFranchiseExperience);
		this.UpdateFranchisePoints(0, this.gameFranchisePoints);
	}

	// Token: 0x06000248 RID: 584 RVA: 0x00013B70 File Offset: 0x00011D70
	[Command(requiresAuthority = false)]
	public void CmdAlterFunds(float fundsToAdd)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(fundsToAdd);
		base.SendCommandInternal("System.Void GameData::CmdAlterFunds(System.Single)", -879922250, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000249 RID: 585 RVA: 0x00013BAC File Offset: 0x00011DAC
	[Command(requiresAuthority = false)]
	public void CmdAlterFundsWithoutExperience(float fundsToAdd)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(fundsToAdd);
		base.SendCommandInternal("System.Void GameData::CmdAlterFundsWithoutExperience(System.Single)", 1076011894, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00013BE8 File Offset: 0x00011DE8
	public void AlterFundsFromEmployee(float fundsToAdd)
	{
		float num = this.gameFunds + fundsToAdd;
		num = Mathf.Clamp(num, 0f, float.PositiveInfinity);
		this.NetworkgameFunds = Mathf.Round(num * 100f) / 100f;
		this.RpcAlterFunds(fundsToAdd);
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00013C30 File Offset: 0x00011E30
	[ClientRpc]
	private void RpcAlterFunds(float funds)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(funds);
		this.SendRPCInternal("System.Void GameData::RpcAlterFunds(System.Single)", -678382561, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00013C6C File Offset: 0x00011E6C
	private void CalculateFranchiseLevel(int oldExp, int newExp)
	{
		int num = 0;
		int num2 = 1;
		while ((float)num2 < float.PositiveInfinity)
		{
			num += num2 * 100;
			if (num > newExp)
			{
				float num3 = (float)(newExp - (num - num2 * 100));
				float num4 = (float)(num2 * 100);
				this.gameFranchiseLevel = num2;
				this.UIFranchiseLevelOBJ.text = num2.ToString();
				this.franchiseProgressionImage.fillAmount = 0.2f + 0.62f * num3 / num4;
				return;
			}
			num2++;
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x00013CDC File Offset: 0x00011EDC
	[Command(requiresAuthority = false)]
	public void CmdAcquireFranchise(int franchiseIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(franchiseIndex);
		base.SendCommandInternal("System.Void GameData::CmdAcquireFranchise(System.Int32)", -1415997053, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00013D18 File Offset: 0x00011F18
	[ClientRpc]
	private void RpcAcquireFranchise(int franchiseIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(franchiseIndex);
		this.SendRPCInternal("System.Void GameData::RpcAcquireFranchise(System.Int32)", 649000700, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600024F RID: 591 RVA: 0x00013D52 File Offset: 0x00011F52
	private new void OnValidate()
	{
		this.UpdateSunPosition();
		this.UpdateTime();
		this.UpdateUIHour();
	}

	// Token: 0x06000250 RID: 592 RVA: 0x00013D68 File Offset: 0x00011F68
	[Command(requiresAuthority = false)]
	public void CmdOpenSupermarket()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void GameData::CmdOpenSupermarket()", -1444783162, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000251 RID: 593 RVA: 0x00013D98 File Offset: 0x00011F98
	[ClientRpc]
	private void RpcOpenSupermarket()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void GameData::RpcOpenSupermarket()", -1099022317, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000252 RID: 594 RVA: 0x00013DC8 File Offset: 0x00011FC8
	[ClientRpc]
	private void RpcNoCheckoutsMessage()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void GameData::RpcNoCheckoutsMessage()", -552657247, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000253 RID: 595 RVA: 0x00013DF8 File Offset: 0x00011FF8
	[ClientRpc]
	private void RpcEndDay(int dCustomers, float dBenefits, int tRobbed, float mLostBecauseRobbing, int nFoundProducts, int tExpensiveProducts, float lCost, float rCost, float emploCost, float mSpentOnProducts, float oCosts, int complaintsAboutFilth, int tFranchiseExperience)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(dCustomers);
		writer.WriteFloat(dBenefits);
		writer.WriteInt(tRobbed);
		writer.WriteFloat(mLostBecauseRobbing);
		writer.WriteInt(nFoundProducts);
		writer.WriteInt(tExpensiveProducts);
		writer.WriteFloat(lCost);
		writer.WriteFloat(rCost);
		writer.WriteFloat(emploCost);
		writer.WriteFloat(mSpentOnProducts);
		writer.WriteFloat(oCosts);
		writer.WriteInt(complaintsAboutFilth);
		writer.WriteInt(tFranchiseExperience);
		this.SendRPCInternal("System.Void GameData::RpcEndDay(System.Int32,System.Single,System.Int32,System.Single,System.Int32,System.Int32,System.Single,System.Single,System.Single,System.Single,System.Single,System.Int32,System.Int32)", -1771083600, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000254 RID: 596 RVA: 0x00013EAC File Offset: 0x000120AC
	[ClientRpc]
	private void RpcStartDay()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void GameData::RpcStartDay()", -1375695896, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000255 RID: 597 RVA: 0x00013EDC File Offset: 0x000120DC
	private void UpdateUIFunds(float oldFunds, float newFunds)
	{
		int num = (int)Mathf.Floor(newFunds);
		int length = num.ToString().Length;
		string text = newFunds.ToString();
		string currencyDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
		if (currencyDecimalSeparator != "," && text.Contains(currencyDecimalSeparator))
		{
			string[] array = text.Split(char.Parse(currencyDecimalSeparator), StringSplitOptions.None);
			text = array[0] + "," + array[1];
		}
		string[] array2 = text.Split(char.Parse(","), StringSplitOptions.None);
		if (array2.Length > 1)
		{
			string text2 = array2[1];
			if (text2.Length == 1)
			{
				this.UIFundsCentsOBJ.text = "." + text2 + "0";
			}
			else
			{
				this.UIFundsCentsOBJ.text = "." + text2;
			}
		}
		else
		{
			this.UIFundsCentsOBJ.text = ".00";
		}
		if (length != this.oldStringLength)
		{
			int num2 = 7 - length;
			this.zeroesToAdd = "";
			for (int i = 0; i < num2; i++)
			{
				this.zeroesToAdd += "0";
			}
			this.oldStringLength = length;
		}
		this.UIFundsOBJ.text = "$" + this.zeroesToAdd + num.ToString();
	}

	// Token: 0x06000256 RID: 598 RVA: 0x00014028 File Offset: 0x00012228
	private void UpdateDayName(int oldDay, int newDay)
	{
		int num = newDay % 7;
		string localizationString = LocalizationManager.instance.GetLocalizationString("weekday" + num.ToString());
		this.UIWeekDayOBJ.text = localizationString;
		this.currentDayOBJ.text = this.gameDay.ToString();
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00014077 File Offset: 0x00012277
	private void UpdateFranchisePoints(int oldPoints, int newPoints)
	{
		this.UIFranchisePointsOBJ.text = this.gameFranchisePoints.ToString();
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0001408F File Offset: 0x0001228F
	private void Update()
	{
		if (base.isServer && !this.keyPress && Input.anyKeyDown)
		{
			this.keyPress = true;
		}
	}

	// Token: 0x06000259 RID: 601 RVA: 0x000140B0 File Offset: 0x000122B0
	private void FixedUpdate()
	{
		if (base.isServer)
		{
			if (this.timeFactor < 10f)
			{
				this.NetworktimeOfDay = this.timeOfDay + 1f / this.timeFactor * Time.fixedDeltaTime / 60f;
			}
			this.WorkingDayControl();
			this.TrashManager();
		}
		if (base.isClient)
		{
			this.LightsOnControl();
		}
		if (this.timeOfDay > 24f)
		{
			this.NetworktimeOfDay = 0f;
		}
		this.UpdateSunPosition();
		this.UpdateUIHour();
		this.innerCounter++;
		if (this.innerCounter > this.counterLimit)
		{
			this.innerCounter = 0;
			this.UpdateTime();
		}
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00014160 File Offset: 0x00012360
	private void LightsOnControl()
	{
		if (this.timeOfDay > 19f)
		{
			this.NightExposureControl();
			if (!this.alreadyTurnedOff)
			{
				this.alreadyTurnedOff = true;
				this.soundsOffOBJ.SetActive(false);
				foreach (object obj in this.lightsOBJ.transform)
				{
					Transform transform = (Transform)obj;
					transform.transform.Find("StreetLight").GetComponent<MeshRenderer>().material = this.lightsOn;
					transform.transform.Find("Light_1").gameObject.SetActive(true);
					transform.transform.Find("Light_2").gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x0600025B RID: 603 RVA: 0x00014240 File Offset: 0x00012440
	private void LightsOffControl()
	{
		this.exposureNightCorrection = 0f;
		this.alreadyTurnedOff = false;
		this.soundsOffOBJ.SetActive(true);
		foreach (object obj in this.lightsOBJ.transform)
		{
			Transform transform = (Transform)obj;
			transform.transform.Find("StreetLight").GetComponent<MeshRenderer>().material = this.lightsOff;
			transform.transform.Find("Light_1").gameObject.SetActive(false);
			transform.transform.Find("Light_2").gameObject.SetActive(false);
		}
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0001430C File Offset: 0x0001250C
	private void NightExposureControl()
	{
		if (FirstPersonController.Instance)
		{
			bool isIndoors = FirstPersonController.Instance.isIndoors;
			if (isIndoors && !this.alreadyInDoors && !this.coroutineRunning)
			{
				base.StartCoroutine(this.InterpolateExposure(true));
			}
			if (!isIndoors && !this.alreadyOutDoors && !this.coroutineRunning)
			{
				base.StartCoroutine(this.InterpolateExposure(false));
			}
		}
	}

	// Token: 0x0600025D RID: 605 RVA: 0x00014370 File Offset: 0x00012570
	private IEnumerator InterpolateExposure(bool goingIndoors)
	{
		this.coroutineRunning = true;
		float inFactor = 0f;
		float outFactor = 0f;
		if (goingIndoors)
		{
			this.alreadyInDoors = true;
			this.alreadyOutDoors = false;
			inFactor = 0f;
			outFactor = 1f;
		}
		else
		{
			this.alreadyInDoors = false;
			this.alreadyOutDoors = true;
			inFactor = 1f;
			outFactor = 0f;
		}
		float elapsedTime = 0f;
		float waitTime = 1f;
		while (elapsedTime < waitTime)
		{
			this.exposureNightCorrection = Mathf.Lerp(inFactor, outFactor, elapsedTime / waitTime);
			float time = this.timeOfDay / 24f;
			ColorAdjustments colorAdjustments;
			this.exposureVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
			colorAdjustments.postExposure.value = this.exposureCurve.Evaluate(time) + this.exposureAdd + this.exposureNightCorrection;
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		yield return null;
		this.coroutineRunning = false;
		yield break;
	}

	// Token: 0x0600025E RID: 606 RVA: 0x00014388 File Offset: 0x00012588
	private void TrashManager()
	{
		if (this.gameDay < 7 || !this.isSupermarketOpen || this.timeOfDay > 22f)
		{
			return;
		}
		int num = Mathf.Clamp(this.gameDay, 0, 50);
		if (this.timeOfDay > this.nextTimeToSpawnTrash)
		{
			if (base.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(6).childCount >= num)
			{
				return;
			}
			float num2 = 25f / ((float)this.gameDay + (float)(this.difficulty + (NetworkServer.connections.Count - 1)));
			num2 = Mathf.Clamp(num2, 0.3f - (float)NetworkServer.connections.Count * 0.01f, float.PositiveInfinity);
			this.nextTimeToSpawnTrash += num2;
			base.StartCoroutine(this.SpawnTrash());
		}
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00014454 File Offset: 0x00012654
	private IEnumerator SpawnTrash()
	{
		int maxExclusive = 6 + base.GetComponent<UpgradesManager>().spaceBought;
		int index = Random.Range(0, maxExclusive);
		Transform baseRaycastSpot = this.trashSpotsParent.transform.GetChild(index);
		Vector3 spawnSpot = Vector3.zero;
		bool foundRaycastSpot = false;
		while (!foundRaycastSpot)
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(baseRaycastSpot.position + new Vector3(Random.Range(-2.4f, 2.4f), 0f, Random.Range(-1.9f, 1.9f)), -Vector3.up, out raycastHit, 5f, this.lMask) && raycastHit.transform.gameObject.tag == "Buildable")
			{
				spawnSpot = raycastHit.point;
				foundRaycastSpot = true;
			}
			yield return null;
		}
		int networktrashID = Random.Range(0, 5);
		GameObject gameObject = Object.Instantiate<GameObject>(this.trashSpawnPrefab, base.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(6).transform);
		gameObject.transform.position = spawnSpot;
		gameObject.GetComponent<TrashSpawn>().NetworktrashID = networktrashID;
		gameObject.GetComponent<PlayMakerFSM>().enabled = true;
		NetworkServer.Spawn(gameObject, null);
		yield return null;
		yield break;
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00014464 File Offset: 0x00012664
	private void ClearExistingTrash()
	{
		Transform transform = base.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(6).transform;
		if (transform.childCount == 0)
		{
			return;
		}
		for (int i = 0; i < transform.childCount; i++)
		{
			Object.Destroy(transform.GetChild(transform.childCount - 1 - i).gameObject);
		}
	}

	// Token: 0x06000261 RID: 609 RVA: 0x000144C4 File Offset: 0x000126C4
	private void WorkingDayControl()
	{
		if (this.timeOfDay > 22.5f && this.isSupermarketOpen)
		{
			this.NetworkisSupermarketOpen = false;
			this.timeFactor = 50f;
			UpgradesManager component = base.GetComponent<UpgradesManager>();
			this.lightCost = 10f + (float)component.spaceBought + (float)component.storageBought;
			this.rentCost = 15f + (float)(component.spaceBought * 5) + (float)(component.storageBought * 10);
			this.employeesCost = (float)(NPC_Manager.Instance.maxEmployees * 60);
		}
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00014550 File Offset: 0x00012750
	[Command(requiresAuthority = false)]
	public void CmdEndDayFromButton()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void GameData::CmdEndDayFromButton()", -1086413400, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x00014580 File Offset: 0x00012780
	private IEnumerator WaitUntilNewDay()
	{
		yield return new WaitForSeconds(2f);
		this.DoDaySaveBackup();
		yield return new WaitForSeconds(8f);
		this.NetworkgameDay = this.gameDay + 1;
		this.NetworktimeOfDay = 8f;
		this.nextTimeToSpawnTrash = 10f;
		this.ResetCheckoutQueues();
		this.ServerCalculateNewInflation();
		this.ClearExistingTrash();
		this.dailyCustomers = 0;
		this.dayBenefits = 0f;
		this.timesRobbed = 0;
		this.moneyLostBecauseRobbing = 0f;
		this.productsTooExpensiveList.Clear();
		this.productsNotFoundList.Clear();
		this.moneySpentOnProducts = 0f;
		this.otherCosts = 0f;
		this.complainedAboutFilth = 0;
		this.todaysFranchiseExperience = 0;
		PlayMakerFSM fsm = this.SaveOBJ.GetComponent<PlayMakerFSM>();
		fsm.FsmVariables.GetFsmBool("IsSaving").Value = true;
		fsm.SendEvent("Send_Data");
		while (fsm.FsmVariables.GetFsmBool("IsSaving").Value)
		{
			yield return null;
		}
		NetworkSpawner nSpawnerComponent = base.GetComponent<NetworkSpawner>();
		nSpawnerComponent.SaveProps();
		yield return new WaitForSeconds(0.25f);
		while (nSpawnerComponent.isSaving)
		{
			yield return null;
		}
		this.pressAnyKeyOBJ.SetActive(true);
		yield return new WaitForSeconds(0.25f);
		this.keyPress = false;
		while (!this.keyPress)
		{
			yield return null;
		}
		this.pressAnyKeyOBJ.SetActive(false);
		this.RpcStartDay();
		yield break;
	}

	// Token: 0x06000264 RID: 612 RVA: 0x00014590 File Offset: 0x00012790
	private void DoDaySaveBackup()
	{
		string value = FsmVariables.GlobalVariables.GetFsmString("CurrentFilename").Value;
		string oldFilePath = Application.persistentDataPath + "/" + value;
		string[] array = value.Split(".", StringSplitOptions.None);
		string newFilePath = string.Concat(new string[]
		{
			Application.persistentDataPath,
			"/",
			array[0],
			"Day",
			this.gameDay.ToString(),
			".es3"
		});
		ES3.CopyFile(oldFilePath, newFilePath);
	}

	// Token: 0x06000265 RID: 613 RVA: 0x00014618 File Offset: 0x00012818
	private void UpdateSunPosition()
	{
		float t = this.timeOfDay / 24f;
		float num = Mathf.Lerp(-90f, 270f, t);
		float x = num - 180f;
		this.sunLight.transform.rotation = Quaternion.Euler(num, 80f, 0f);
		this.moonLight.transform.rotation = Quaternion.Euler(x, 80f, 0f);
	}

	// Token: 0x06000266 RID: 614 RVA: 0x0001468C File Offset: 0x0001288C
	private void UpdateTime()
	{
		float time = this.timeOfDay / 24f;
		float num = this.skyBoxTintFactorCurve.Evaluate(time);
		RenderSettings.skybox.SetFloat("_Exposure", num);
		RenderSettings.fogColor = Color.Lerp(Color.black, new Color(178f, 192f, 200f) * 0.005f, num);
		ColorAdjustments colorAdjustments;
		this.exposureVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
		colorAdjustments.postExposure.value = this.exposureCurve.Evaluate(time) + this.exposureAdd + this.exposureNightCorrection;
		if (this.timeOfDay > 6f && this.timeOfDay < 18f && this.isNight)
		{
			this.isNight = false;
			this.sunLight.gameObject.SetActive(true);
			this.moonLight.gameObject.SetActive(false);
			return;
		}
		if ((this.timeOfDay < 6f || this.timeOfDay > 18f) && !this.isNight)
		{
			this.isNight = true;
			this.sunLight.gameObject.SetActive(false);
			this.moonLight.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000267 RID: 615 RVA: 0x000147C0 File Offset: 0x000129C0
	private void UpdateUIHour()
	{
		string text = Mathf.FloorToInt(this.timeOfDay).ToString();
		if (text.Length < 2)
		{
			text = "0" + text;
		}
		float num = (float)Mathf.FloorToInt(this.timeOfDay);
		string text2 = ((int)((this.timeOfDay - num) * 60f)).ToString();
		if (text2.Length < 2)
		{
			text2 = "0" + text2;
		}
		this.UITimeOBJ.text = text + ":" + text2;
	}

	// Token: 0x06000268 RID: 616 RVA: 0x00014848 File Offset: 0x00012A48
	public void ServerCalculateNewInflation()
	{
		if (this.gameDay % 7 != 4)
		{
			return;
		}
		float[] tierInflation = ProductListing.Instance.GetComponent<ProductListing>().tierInflation;
		for (int i = 0; i < tierInflation.Length; i++)
		{
			float num = Random.Range(0.05f, 0.15f) + Random.Range(0.04f, 0.08f) * ((float)this.gameDay / 40f);
			float num2 = tierInflation[i] + num;
			num2 = Mathf.Round(num2 * 100f) / 100f;
			ProductListing.Instance.GetComponent<ProductListing>().tierInflation[i] = num2;
			this.RpcUpdateInflationOnClient(i, num2);
			if (i >= this.gameDay / 2)
			{
				break;
			}
		}
	}

	// Token: 0x06000269 RID: 617 RVA: 0x000148EC File Offset: 0x00012AEC
	[ClientRpc]
	private void RpcUpdateInflationOnClient(int inflationIndex, float newInflation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(inflationIndex);
		writer.WriteFloat(newInflation);
		this.SendRPCInternal("System.Void GameData::RpcUpdateInflationOnClient(System.Int32,System.Single)", 2017206061, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600026A RID: 618 RVA: 0x00014930 File Offset: 0x00012B30
	private void ResetCheckoutQueues()
	{
		Transform child = base.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(2);
		if (child.childCount > 0)
		{
			foreach (object obj in child)
			{
				((Transform)obj).GetComponent<Data_Container>().ResetQueue();
			}
		}
		Transform child2 = base.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(3);
		if (child.childCount > 0)
		{
			foreach (object obj2 in child2)
			{
				((Transform)obj2).GetComponent<Data_Container>().ResetCheckoutQueue();
			}
		}
	}

	// Token: 0x0600026B RID: 619 RVA: 0x00014A0C File Offset: 0x00012C0C
	public void AddExpensiveList(int productID)
	{
		if (this.productsTooExpensiveList.Count == 0)
		{
			this.productsTooExpensiveList.Add(productID);
		}
		using (List<int>.Enumerator enumerator = this.productsTooExpensiveList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == productID)
				{
					return;
				}
			}
		}
		this.productsTooExpensiveList.Add(productID);
	}

	// Token: 0x0600026C RID: 620 RVA: 0x00014A84 File Offset: 0x00012C84
	public void AddNotFoundList(int productID)
	{
		if (this.productsNotFoundList.Count == 0)
		{
			this.productsNotFoundList.Add(productID);
		}
		using (List<int>.Enumerator enumerator = this.productsNotFoundList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == productID)
				{
					return;
				}
			}
		}
		this.productsNotFoundList.Add(productID);
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00014AFC File Offset: 0x00012CFC
	public void PlayPopSound()
	{
		base.transform.Find("Audio_PlaceItemPop").GetComponent<AudioSource>().clip = this.popsArray[Random.Range(0, this.popsArray.Length - 1)];
		base.transform.Find("Audio_PlaceItemPop").GetComponent<AudioSource>().Play();
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00014B54 File Offset: 0x00012D54
	public void PlayPop2Sound()
	{
		base.transform.Find("Audio_RemoveItem").GetComponent<AudioSource>().Play();
	}

	// Token: 0x0600026F RID: 623 RVA: 0x00014B70 File Offset: 0x00012D70
	public void PlayBroomSound()
	{
		base.transform.Find("Audio_Broom").GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000270 RID: 624 RVA: 0x00014B8C File Offset: 0x00012D8C
	[Command(requiresAuthority = false)]
	public void CmdmoneySpentOnProducts(float fundsToAdd)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(fundsToAdd);
		base.SendCommandInternal("System.Void GameData::CmdmoneySpentOnProducts(System.Single)", 56512713, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00014BC8 File Offset: 0x00012DC8
	[Command(requiresAuthority = false)]
	public void CmdHostDisconnect()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void GameData::CmdHostDisconnect()", 1002367509, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00014BF8 File Offset: 0x00012DF8
	[ClientRpc]
	private void RpcHostDisconnect()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void GameData::RpcHostDisconnect()", 495782178, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00014C28 File Offset: 0x00012E28
	public GameData()
	{
		this._Mirror_SyncVarHookDelegate_gameFunds = new Action<float, float>(this.UpdateUIFunds);
		this._Mirror_SyncVarHookDelegate_gameFranchiseExperience = new Action<int, int>(this.CalculateFranchiseLevel);
		this._Mirror_SyncVarHookDelegate_gameFranchisePoints = new Action<int, int>(this.UpdateFranchisePoints);
		this._Mirror_SyncVarHookDelegate_gameDay = new Action<int, int>(this.UpdateDayName);
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x06000275 RID: 629 RVA: 0x00014CD0 File Offset: 0x00012ED0
	// (set) Token: 0x06000276 RID: 630 RVA: 0x00014CE3 File Offset: 0x00012EE3
	public float NetworkgameFunds
	{
		get
		{
			return this.gameFunds;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<float>(value, ref this.gameFunds, 1UL, this._Mirror_SyncVarHookDelegate_gameFunds);
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x06000277 RID: 631 RVA: 0x00014D04 File Offset: 0x00012F04
	// (set) Token: 0x06000278 RID: 632 RVA: 0x00014D17 File Offset: 0x00012F17
	public int NetworkgameFranchiseExperience
	{
		get
		{
			return this.gameFranchiseExperience;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.gameFranchiseExperience, 2UL, this._Mirror_SyncVarHookDelegate_gameFranchiseExperience);
		}
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x06000279 RID: 633 RVA: 0x00014D38 File Offset: 0x00012F38
	// (set) Token: 0x0600027A RID: 634 RVA: 0x00014D4B File Offset: 0x00012F4B
	public int NetworkgameFranchisePoints
	{
		get
		{
			return this.gameFranchisePoints;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.gameFranchisePoints, 4UL, this._Mirror_SyncVarHookDelegate_gameFranchisePoints);
		}
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x0600027B RID: 635 RVA: 0x00014D6C File Offset: 0x00012F6C
	// (set) Token: 0x0600027C RID: 636 RVA: 0x00014D7F File Offset: 0x00012F7F
	public int NetworkgameDay
	{
		get
		{
			return this.gameDay;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.gameDay, 8UL, this._Mirror_SyncVarHookDelegate_gameDay);
		}
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x0600027D RID: 637 RVA: 0x00014DA0 File Offset: 0x00012FA0
	// (set) Token: 0x0600027E RID: 638 RVA: 0x00014DB3 File Offset: 0x00012FB3
	public bool NetworkisSupermarketOpen
	{
		get
		{
			return this.isSupermarketOpen;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.isSupermarketOpen, 16UL, null);
		}
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x0600027F RID: 639 RVA: 0x00014DD0 File Offset: 0x00012FD0
	// (set) Token: 0x06000280 RID: 640 RVA: 0x00014DE3 File Offset: 0x00012FE3
	public float NetworktimeOfDay
	{
		get
		{
			return this.timeOfDay;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<float>(value, ref this.timeOfDay, 32UL, null);
		}
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00014E00 File Offset: 0x00013000
	protected void UserCode_CmdAlterFunds__Single(float fundsToAdd)
	{
		float num = this.gameFunds + fundsToAdd;
		num = Mathf.Clamp(num, 0f, float.PositiveInfinity);
		this.NetworkgameFunds = Mathf.Round(num * 100f) / 100f;
		if (fundsToAdd > 0f)
		{
			float num2 = 0.5f - (float)this.gameDay * 0.007f;
			num2 = Mathf.Clamp(num2, 0.04f, 1f);
			this.NetworkgameFranchiseExperience = this.gameFranchiseExperience + (int)(fundsToAdd * num2);
			this.todaysFranchiseExperience += (int)(fundsToAdd * num2);
			this.dayBenefits += (float)((int)fundsToAdd);
		}
		else
		{
			this.otherCosts += fundsToAdd;
		}
		this.RpcAlterFunds(fundsToAdd);
		int num3 = 0;
		int num4 = 1;
		while ((float)num4 < float.PositiveInfinity)
		{
			num3 += num4 * 100;
			if (num3 > this.gameFranchiseExperience)
			{
				if (num4 > this.lastAwardedFranchiseLevel)
				{
					this.NetworkgameFranchisePoints = this.gameFranchisePoints + 1;
					this.lastAwardedFranchiseLevel = num4;
					return;
				}
				break;
			}
			else
			{
				num4++;
			}
		}
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00014EF7 File Offset: 0x000130F7
	protected static void InvokeUserCode_CmdAlterFunds__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAlterFunds called on client.");
			return;
		}
		((GameData)obj).UserCode_CmdAlterFunds__Single(reader.ReadFloat());
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00014F24 File Offset: 0x00013124
	protected void UserCode_CmdAlterFundsWithoutExperience__Single(float fundsToAdd)
	{
		float num = this.gameFunds + fundsToAdd;
		num = Mathf.Clamp(num, 0f, float.PositiveInfinity);
		this.NetworkgameFunds = Mathf.Round(num * 100f) / 100f;
		this.RpcAlterFunds(fundsToAdd);
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00014F6A File Offset: 0x0001316A
	protected static void InvokeUserCode_CmdAlterFundsWithoutExperience__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAlterFundsWithoutExperience called on client.");
			return;
		}
		((GameData)obj).UserCode_CmdAlterFundsWithoutExperience__Single(reader.ReadFloat());
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00014F94 File Offset: 0x00013194
	protected void UserCode_RpcAlterFunds__Single(float funds)
	{
		funds = Mathf.Round(funds * 100f) / 100f;
		base.transform.Find("Audio_Kaching").GetComponent<AudioSource>().Play();
		GameObject gameObject = Object.Instantiate<GameObject>(this.prefabNotificationOBJ, this.UIFundsNotificationParentOBJ.transform);
		string text;
		if (funds > 0f)
		{
			text = "+$" + funds.ToString();
		}
		else
		{
			text = "-$" + Mathf.Abs(funds).ToString();
		}
		gameObject.GetComponent<TextMeshProUGUI>().text = text;
		gameObject.SetActive(true);
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00015032 File Offset: 0x00013232
	protected static void InvokeUserCode_RpcAlterFunds__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAlterFunds called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcAlterFunds__Single(reader.ReadFloat());
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0001505C File Offset: 0x0001325C
	protected void UserCode_CmdAcquireFranchise__Int32(int franchiseIndex)
	{
		base.GetComponent<ProductListing>().unlockedProductTiers[franchiseIndex] = true;
		this.NetworkgameFranchisePoints = this.gameFranchisePoints - 1;
		this.NetworkgameFranchisePoints = Mathf.Clamp(this.gameFranchisePoints, 0, 1000);
		this.RpcAcquireFranchise(franchiseIndex);
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00015098 File Offset: 0x00013298
	protected static void InvokeUserCode_CmdAcquireFranchise__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAcquireFranchise called on client.");
			return;
		}
		((GameData)obj).UserCode_CmdAcquireFranchise__Int32(reader.ReadInt());
	}

	// Token: 0x06000289 RID: 649 RVA: 0x000150C4 File Offset: 0x000132C4
	protected void UserCode_RpcAcquireFranchise__Int32(int franchiseIndex)
	{
		base.GetComponent<ProductListing>().unlockedProductTiers[franchiseIndex] = true;
		base.GetComponent<ProductListing>().updateSkillState();
		base.GetComponent<ProductListing>().updateProductList();
		base.GetComponent<ManagerBlackboard>().UpdateUnlockedFranchises();
		base.transform.Find("Audio_AcquirePerk").GetComponent<AudioSource>().Play();
		GameCanvas.Instance.CreateImportantNotification("messagei2");
	}

	// Token: 0x0600028A RID: 650 RVA: 0x00015129 File Offset: 0x00013329
	protected static void InvokeUserCode_RpcAcquireFranchise__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAcquireFranchise called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcAcquireFranchise__Int32(reader.ReadInt());
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00015154 File Offset: 0x00013354
	protected void UserCode_CmdOpenSupermarket()
	{
		if (base.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(2).childCount == 0)
		{
			this.RpcNoCheckoutsMessage();
			return;
		}
		if (!this.isSupermarketOpen || this.timeOfDay > 23f || this.timeOfDay < 8f)
		{
			this.NetworkisSupermarketOpen = true;
			this.timeFactor = 1f;
			this.maxProductsCustomersToBuy = 5 + this.gameDay / 2 + NetworkServer.connections.Count + this.difficulty;
			this.maxProductsCustomersToBuy = Mathf.Clamp(this.maxProductsCustomersToBuy, 5, 25 + NetworkServer.connections.Count + this.difficulty);
			this.maxCustomersNPCs = 3 + this.gameDay + (NetworkServer.connections.Count - 1) * 4 + this.extraCustomersPerk + this.difficulty * 2;
			this.maxCustomersNPCs = Mathf.Clamp(this.maxCustomersNPCs, 5, 70 + NetworkServer.connections.Count);
			this.RpcOpenSupermarket();
		}
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00015256 File Offset: 0x00013456
	protected static void InvokeUserCode_CmdOpenSupermarket(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdOpenSupermarket called on client.");
			return;
		}
		((GameData)obj).UserCode_CmdOpenSupermarket();
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00015279 File Offset: 0x00013479
	protected void UserCode_RpcOpenSupermarket()
	{
		base.transform.Find("Audio_Special").GetComponent<AudioSource>().Play();
		GameCanvas.Instance.CreateImportantNotification("messagei0");
	}

	// Token: 0x0600028E RID: 654 RVA: 0x000152A4 File Offset: 0x000134A4
	protected static void InvokeUserCode_RpcOpenSupermarket(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOpenSupermarket called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcOpenSupermarket();
	}

	// Token: 0x0600028F RID: 655 RVA: 0x000152C7 File Offset: 0x000134C7
	protected void UserCode_RpcNoCheckoutsMessage()
	{
		GameCanvas.Instance.CreateCanvasNotification("message18");
	}

	// Token: 0x06000290 RID: 656 RVA: 0x000152D8 File Offset: 0x000134D8
	protected static void InvokeUserCode_RpcNoCheckoutsMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcNoCheckoutsMessage called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcNoCheckoutsMessage();
	}

	// Token: 0x06000291 RID: 657 RVA: 0x000152FC File Offset: 0x000134FC
	protected void UserCode_RpcEndDay__Int32__Single__Int32__Single__Int32__Int32__Single__Single__Single__Single__Single__Int32__Int32(int dCustomers, float dBenefits, int tRobbed, float mLostBecauseRobbing, int nFoundProducts, int tExpensiveProducts, float lCost, float rCost, float emploCost, float mSpentOnProducts, float oCosts, int complaintsAboutFilth, int tFranchiseExperience)
	{
		GameCanvas.Instance.TriggerEndDayStats(dCustomers, dBenefits, tRobbed, mLostBecauseRobbing, nFoundProducts, tExpensiveProducts, lCost, rCost, emploCost, mSpentOnProducts, oCosts, complaintsAboutFilth, tFranchiseExperience);
		FirstPersonController.Instance.inEvent = true;
	}

	// Token: 0x06000292 RID: 658 RVA: 0x00015338 File Offset: 0x00013538
	protected static void InvokeUserCode_RpcEndDay__Int32__Single__Int32__Single__Int32__Int32__Single__Single__Single__Single__Single__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEndDay called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcEndDay__Int32__Single__Int32__Single__Int32__Int32__Single__Single__Single__Single__Single__Int32__Int32(reader.ReadInt(), reader.ReadFloat(), reader.ReadInt(), reader.ReadFloat(), reader.ReadInt(), reader.ReadInt(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x06000293 RID: 659 RVA: 0x000153BC File Offset: 0x000135BC
	protected void UserCode_RpcStartDay()
	{
		AchievementsManager.Instance.SavebufferValues();
		GameCanvas.Instance.StartEndCoroutine();
		FirstPersonController.Instance.inEvent = false;
		FirstPersonController.Instance.GetComponent<FirstPersonTransform>().coroutineActivator(new Vector3(5f + Random.Range(-2f, 2f), 0f, -20.5f + Random.Range(-2f, 2f)), 0f);
		this.LightsOffControl();
	}

	// Token: 0x06000294 RID: 660 RVA: 0x00015436 File Offset: 0x00013636
	protected static void InvokeUserCode_RpcStartDay(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcStartDay called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcStartDay();
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0001545C File Offset: 0x0001365C
	protected void UserCode_CmdEndDayFromButton()
	{
		if (this.timeOfDay > 22f && !this.isSupermarketOpen)
		{
			NPC_Manager.Instance.RemoveCustomers();
			this.RpcEndDay(this.dailyCustomers, this.dayBenefits, this.timesRobbed, this.moneyLostBecauseRobbing, this.productsNotFoundList.Count, this.productsTooExpensiveList.Count, this.lightCost, this.rentCost, this.employeesCost, this.moneySpentOnProducts, this.otherCosts, this.complainedAboutFilth, this.todaysFranchiseExperience);
			base.StartCoroutine(this.WaitUntilNewDay());
			AchievementsManager.Instance.CmdAddAchievementPoint(0, (int)this.dayBenefits);
			AchievementsManager.Instance.CmdAddAchievementPoint(10, (int)this.dayBenefits);
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x0001551E File Offset: 0x0001371E
	protected static void InvokeUserCode_CmdEndDayFromButton(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdEndDayFromButton called on client.");
			return;
		}
		((GameData)obj).UserCode_CmdEndDayFromButton();
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00015541 File Offset: 0x00013741
	protected void UserCode_RpcUpdateInflationOnClient__Int32__Single(int inflationIndex, float newInflation)
	{
		if (!base.isServer)
		{
			ProductListing.Instance.GetComponent<ProductListing>().tierInflation[inflationIndex] = newInflation;
		}
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0001555D File Offset: 0x0001375D
	protected static void InvokeUserCode_RpcUpdateInflationOnClient__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateInflationOnClient called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcUpdateInflationOnClient__Int32__Single(reader.ReadInt(), reader.ReadFloat());
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0001558D File Offset: 0x0001378D
	protected void UserCode_CmdmoneySpentOnProducts__Single(float fundsToAdd)
	{
		this.moneySpentOnProducts += fundsToAdd;
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0001559D File Offset: 0x0001379D
	protected static void InvokeUserCode_CmdmoneySpentOnProducts__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdmoneySpentOnProducts called on client.");
			return;
		}
		((GameData)obj).UserCode_CmdmoneySpentOnProducts__Single(reader.ReadFloat());
	}

	// Token: 0x0600029B RID: 667 RVA: 0x000155C7 File Offset: 0x000137C7
	protected void UserCode_CmdHostDisconnect()
	{
		this.RpcHostDisconnect();
	}

	// Token: 0x0600029C RID: 668 RVA: 0x000155CF File Offset: 0x000137CF
	protected static void InvokeUserCode_CmdHostDisconnect(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdHostDisconnect called on client.");
			return;
		}
		((GameData)obj).UserCode_CmdHostDisconnect();
	}

	// Token: 0x0600029D RID: 669 RVA: 0x000155F2 File Offset: 0x000137F2
	protected void UserCode_RpcHostDisconnect()
	{
		if (base.isServer)
		{
			return;
		}
		GameCanvas.Instance.transform.Find("HostDisconnect").gameObject.SetActive(true);
	}

	// Token: 0x0600029E RID: 670 RVA: 0x0001561C File Offset: 0x0001381C
	protected static void InvokeUserCode_RpcHostDisconnect(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHostDisconnect called on server.");
			return;
		}
		((GameData)obj).UserCode_RpcHostDisconnect();
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00015640 File Offset: 0x00013840
	static GameData()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(GameData), "System.Void GameData::CmdAlterFunds(System.Single)", new RemoteCallDelegate(GameData.InvokeUserCode_CmdAlterFunds__Single), false);
		RemoteProcedureCalls.RegisterCommand(typeof(GameData), "System.Void GameData::CmdAlterFundsWithoutExperience(System.Single)", new RemoteCallDelegate(GameData.InvokeUserCode_CmdAlterFundsWithoutExperience__Single), false);
		RemoteProcedureCalls.RegisterCommand(typeof(GameData), "System.Void GameData::CmdAcquireFranchise(System.Int32)", new RemoteCallDelegate(GameData.InvokeUserCode_CmdAcquireFranchise__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(GameData), "System.Void GameData::CmdOpenSupermarket()", new RemoteCallDelegate(GameData.InvokeUserCode_CmdOpenSupermarket), false);
		RemoteProcedureCalls.RegisterCommand(typeof(GameData), "System.Void GameData::CmdEndDayFromButton()", new RemoteCallDelegate(GameData.InvokeUserCode_CmdEndDayFromButton), false);
		RemoteProcedureCalls.RegisterCommand(typeof(GameData), "System.Void GameData::CmdmoneySpentOnProducts(System.Single)", new RemoteCallDelegate(GameData.InvokeUserCode_CmdmoneySpentOnProducts__Single), false);
		RemoteProcedureCalls.RegisterCommand(typeof(GameData), "System.Void GameData::CmdHostDisconnect()", new RemoteCallDelegate(GameData.InvokeUserCode_CmdHostDisconnect), false);
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcAlterFunds(System.Single)", new RemoteCallDelegate(GameData.InvokeUserCode_RpcAlterFunds__Single));
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcAcquireFranchise(System.Int32)", new RemoteCallDelegate(GameData.InvokeUserCode_RpcAcquireFranchise__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcOpenSupermarket()", new RemoteCallDelegate(GameData.InvokeUserCode_RpcOpenSupermarket));
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcNoCheckoutsMessage()", new RemoteCallDelegate(GameData.InvokeUserCode_RpcNoCheckoutsMessage));
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcEndDay(System.Int32,System.Single,System.Int32,System.Single,System.Int32,System.Int32,System.Single,System.Single,System.Single,System.Single,System.Single,System.Int32,System.Int32)", new RemoteCallDelegate(GameData.InvokeUserCode_RpcEndDay__Int32__Single__Int32__Single__Int32__Int32__Single__Single__Single__Single__Single__Int32__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcStartDay()", new RemoteCallDelegate(GameData.InvokeUserCode_RpcStartDay));
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcUpdateInflationOnClient(System.Int32,System.Single)", new RemoteCallDelegate(GameData.InvokeUserCode_RpcUpdateInflationOnClient__Int32__Single));
		RemoteProcedureCalls.RegisterRpc(typeof(GameData), "System.Void GameData::RpcHostDisconnect()", new RemoteCallDelegate(GameData.InvokeUserCode_RpcHostDisconnect));
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x00015834 File Offset: 0x00013A34
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(this.gameFunds);
			writer.WriteInt(this.gameFranchiseExperience);
			writer.WriteInt(this.gameFranchisePoints);
			writer.WriteInt(this.gameDay);
			writer.WriteBool(this.isSupermarketOpen);
			writer.WriteFloat(this.timeOfDay);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteFloat(this.gameFunds);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteInt(this.gameFranchiseExperience);
		}
		if ((this.syncVarDirtyBits & 4UL) != 0UL)
		{
			writer.WriteInt(this.gameFranchisePoints);
		}
		if ((this.syncVarDirtyBits & 8UL) != 0UL)
		{
			writer.WriteInt(this.gameDay);
		}
		if ((this.syncVarDirtyBits & 16UL) != 0UL)
		{
			writer.WriteBool(this.isSupermarketOpen);
		}
		if ((this.syncVarDirtyBits & 32UL) != 0UL)
		{
			writer.WriteFloat(this.timeOfDay);
		}
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00015974 File Offset: 0x00013B74
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<float>(ref this.gameFunds, this._Mirror_SyncVarHookDelegate_gameFunds, reader.ReadFloat());
			base.GeneratedSyncVarDeserialize<int>(ref this.gameFranchiseExperience, this._Mirror_SyncVarHookDelegate_gameFranchiseExperience, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<int>(ref this.gameFranchisePoints, this._Mirror_SyncVarHookDelegate_gameFranchisePoints, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<int>(ref this.gameDay, this._Mirror_SyncVarHookDelegate_gameDay, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<bool>(ref this.isSupermarketOpen, null, reader.ReadBool());
			base.GeneratedSyncVarDeserialize<float>(ref this.timeOfDay, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<float>(ref this.gameFunds, this._Mirror_SyncVarHookDelegate_gameFunds, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.gameFranchiseExperience, this._Mirror_SyncVarHookDelegate_gameFranchiseExperience, reader.ReadInt());
		}
		if ((num & 4L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.gameFranchisePoints, this._Mirror_SyncVarHookDelegate_gameFranchisePoints, reader.ReadInt());
		}
		if ((num & 8L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.gameDay, this._Mirror_SyncVarHookDelegate_gameDay, reader.ReadInt());
		}
		if ((num & 16L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.isSupermarketOpen, null, reader.ReadBool());
		}
		if ((num & 32L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<float>(ref this.timeOfDay, null, reader.ReadFloat());
		}
	}

	// Token: 0x0400022B RID: 555
	public static GameData Instance;

	// Token: 0x0400022C RID: 556
	[SyncVar(hook = "UpdateUIFunds")]
	public float gameFunds;

	// Token: 0x0400022D RID: 557
	[SyncVar(hook = "CalculateFranchiseLevel")]
	public int gameFranchiseExperience;

	// Token: 0x0400022E RID: 558
	[SyncVar(hook = "UpdateFranchisePoints")]
	public int gameFranchisePoints;

	// Token: 0x0400022F RID: 559
	[SyncVar(hook = "UpdateDayName")]
	public int gameDay = 1;

	// Token: 0x04000230 RID: 560
	[SyncVar]
	public bool isSupermarketOpen;

	// Token: 0x04000231 RID: 561
	[SyncVar]
	[Range(0f, 24f)]
	public float timeOfDay;

	// Token: 0x04000232 RID: 562
	public int maxCustomersNPCs = 5;

	// Token: 0x04000233 RID: 563
	public int extraCustomersPerk;

	// Token: 0x04000234 RID: 564
	public int maxProductsCustomersToBuy = 5;

	// Token: 0x04000235 RID: 565
	public int gameFranchiseLevel;

	// Token: 0x04000236 RID: 566
	public int lastAwardedFranchiseLevel;

	// Token: 0x04000237 RID: 567
	public int difficulty;

	// Token: 0x04000238 RID: 568
	public float exposureAdd;

	// Token: 0x04000239 RID: 569
	public float exposureNightCorrection;

	// Token: 0x0400023A RID: 570
	private bool alreadyInDoors;

	// Token: 0x0400023B RID: 571
	private bool alreadyOutDoors;

	// Token: 0x0400023C RID: 572
	private float nextTimeToSpawnTrash = 10f;

	// Token: 0x0400023D RID: 573
	private bool coroutineRunning;

	// Token: 0x0400023E RID: 574
	private int todaysFranchiseExperience;

	// Token: 0x0400023F RID: 575
	[Header("Day Report")]
	[Space(10f)]
	public int dailyCustomers;

	// Token: 0x04000240 RID: 576
	public float dayBenefits;

	// Token: 0x04000241 RID: 577
	public int timesRobbed;

	// Token: 0x04000242 RID: 578
	public float moneyLostBecauseRobbing;

	// Token: 0x04000243 RID: 579
	public float lightCost;

	// Token: 0x04000244 RID: 580
	public float rentCost;

	// Token: 0x04000245 RID: 581
	public float employeesCost;

	// Token: 0x04000246 RID: 582
	public float otherCosts;

	// Token: 0x04000247 RID: 583
	public float moneySpentOnProducts;

	// Token: 0x04000248 RID: 584
	public int complainedAboutFilth;

	// Token: 0x04000249 RID: 585
	[Space(10f)]
	[Range(0.05f, 50f)]
	public float timeFactor = 2f;

	// Token: 0x0400024A RID: 586
	public Light sunLight;

	// Token: 0x0400024B RID: 587
	public Light moonLight;

	// Token: 0x0400024C RID: 588
	public GameObject UIFundsNotificationParentOBJ;

	// Token: 0x0400024D RID: 589
	public GameObject prefabNotificationOBJ;

	// Token: 0x0400024E RID: 590
	public GameObject trashSpotsParent;

	// Token: 0x0400024F RID: 591
	public GameObject trashSpawnPrefab;

	// Token: 0x04000250 RID: 592
	public TextMeshProUGUI UIFundsOBJ;

	// Token: 0x04000251 RID: 593
	public TextMeshProUGUI UIFundsCentsOBJ;

	// Token: 0x04000252 RID: 594
	public TextMeshProUGUI UITimeOBJ;

	// Token: 0x04000253 RID: 595
	public TextMeshProUGUI UIWeekDayOBJ;

	// Token: 0x04000254 RID: 596
	public TextMeshProUGUI currentDayOBJ;

	// Token: 0x04000255 RID: 597
	public TextMeshProUGUI UIFranchiseLevelOBJ;

	// Token: 0x04000256 RID: 598
	public TextMeshProUGUI UIFranchisePointsOBJ;

	// Token: 0x04000257 RID: 599
	public GameObject pressAnyKeyOBJ;

	// Token: 0x04000258 RID: 600
	public Image franchiseProgressionImage;

	// Token: 0x04000259 RID: 601
	public Volume exposureVolume;

	// Token: 0x0400025A RID: 602
	public int counterLimit = 150;

	// Token: 0x0400025B RID: 603
	public LayerMask lMask;

	// Token: 0x0400025C RID: 604
	[Space(10f)]
	public AnimationCurve skyBoxTintFactorCurve;

	// Token: 0x0400025D RID: 605
	public AnimationCurve exposureCurve;

	// Token: 0x0400025E RID: 606
	[Space(10f)]
	public Material movingMaterial;

	// Token: 0x0400025F RID: 607
	public AudioClip[] popsArray;

	// Token: 0x04000260 RID: 608
	public GameObject SaveOBJ;

	// Token: 0x04000261 RID: 609
	private int innerCounter;

	// Token: 0x04000262 RID: 610
	private bool isNight;

	// Token: 0x04000263 RID: 611
	private int oldStringLength;

	// Token: 0x04000264 RID: 612
	private string zeroesToAdd;

	// Token: 0x04000265 RID: 613
	private bool keyPress;

	// Token: 0x04000266 RID: 614
	public GameObject lightsOBJ;

	// Token: 0x04000267 RID: 615
	public GameObject soundsOffOBJ;

	// Token: 0x04000268 RID: 616
	public Material lightsOff;

	// Token: 0x04000269 RID: 617
	public Material lightsOn;

	// Token: 0x0400026A RID: 618
	private bool alreadyTurnedOff;

	// Token: 0x0400026B RID: 619
	private List<int> productsTooExpensiveList = new List<int>();

	// Token: 0x0400026C RID: 620
	private List<int> productsNotFoundList = new List<int>();

	// Token: 0x0400026D RID: 621
	public Action<float, float> _Mirror_SyncVarHookDelegate_gameFunds;

	// Token: 0x0400026E RID: 622
	public Action<int, int> _Mirror_SyncVarHookDelegate_gameFranchiseExperience;

	// Token: 0x0400026F RID: 623
	public Action<int, int> _Mirror_SyncVarHookDelegate_gameFranchisePoints;

	// Token: 0x04000270 RID: 624
	public Action<int, int> _Mirror_SyncVarHookDelegate_gameDay;
}

using System;
using Rewired;
using UnityEngine;

// Token: 0x02000060 RID: 96
public class GetRewiredKeyName : MonoBehaviour
{
	// Token: 0x060002B4 RID: 692 RVA: 0x000160D4 File Offset: 0x000142D4
	public string GetButtonName(string ActionLinked)
	{
		if (this.player == null)
		{
			this.player = ReInput.players.GetPlayer(0);
		}
		return this.player.controllers.maps.GetFirstButtonMapWithAction(ActionLinked, this.skipDisabledMaps).elementIdentifierName.ToString();
	}

	// Token: 0x04000284 RID: 644
	private Player player;

	// Token: 0x04000285 RID: 645
	private bool skipDisabledMaps = true;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x02000061 RID: 97
public class HalloweenGhost : NetworkBehaviour
{
	// Token: 0x060002B6 RID: 694 RVA: 0x0001612F File Offset: 0x0001432F
	public override void OnStartClient()
	{
		base.OnStartClient();
		this.SetColor();
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x0001613D File Offset: 0x0001433D
	public override void OnStartServer()
	{
		base.OnStartServer();
		this.shelvesOBJ = NPC_Manager.Instance.shelvesOBJ;
		this.fsmVectorVariable = this.lookAtFSM.FsmVariables.GetFsmVector3("Target");
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x00016170 File Offset: 0x00014370
	private void Update()
	{
		if (!base.isServer)
		{
			return;
		}
		if (GameData.Instance.timeOfDay < 8.05f)
		{
			base.StopAllCoroutines();
			NetworkServer.Destroy(base.gameObject);
		}
		if (this.state == -1)
		{
			return;
		}
		switch (this.state)
		{
		case 0:
			this.currentContainerIndex = this.GetContainerWithProducts();
			if (this.currentContainerIndex > -1)
			{
				this.productsToDrop = Random.Range(2, 5);
				Vector3 position = this.shelvesOBJ.transform.GetChild(this.currentContainerIndex).transform.Find("Standspot").transform.position;
				this.fsmVectorVariable.Value = position;
				base.StartCoroutine(this.MoveTowardsTarget(position, 1));
				return;
			}
			base.StartCoroutine(this.WaitState(1.5f, 0));
			return;
		case 1:
		{
			int num = this.ContainerStillHasProducts(this.currentContainerIndex);
			if (num <= -1)
			{
				base.StartCoroutine(this.WaitState(1.5f, 0));
				return;
			}
			if (this.productsToDrop <= 0)
			{
				Vector3 vector = base.transform.position + new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f));
				base.StartCoroutine(this.MoveTowardsTarget(vector, 0));
				this.fsmVectorVariable.Value = vector;
				return;
			}
			this.productsToDrop--;
			this.shelvesOBJ.transform.GetChild(this.currentContainerIndex).GetComponent<Data_Container>().NPCGetsItemFromRow(num);
			GameObject gameObject = Object.Instantiate<GameObject>(this.stolenProductPrefab);
			gameObject.transform.position = base.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), 0f, Random.Range(-0.25f, 0.25f));
			gameObject.GetComponent<StolenProductSpawn>().NetworkproductID = num;
			Data_Product component = ProductListing.Instance.productPrefabs[num].GetComponent<Data_Product>();
			int productTier = component.productTier;
			float num2 = component.basePricePerUnit * ProductListing.Instance.tierInflation[productTier];
			gameObject.GetComponent<StolenProductSpawn>().NetworkproductCarryingPrice = num2 * 1.5f;
			NetworkServer.Spawn(gameObject, null);
			base.StartCoroutine(this.WaitState(1f, 1));
			return;
		}
		case 2:
			break;
		default:
			Debug.Log("Ghost case error");
			break;
		}
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x000163C8 File Offset: 0x000145C8
	private int GetContainerWithProducts()
	{
		if (this.shelvesOBJ.transform.childCount == 0)
		{
			return -1;
		}
		this.containersIndexes.Clear();
		int num = 0;
		while (num < this.shelvesOBJ.transform.childCount && this.containersIndexes.Count < 35)
		{
			int[] productInfoArray = this.shelvesOBJ.transform.GetChild(num).GetComponent<Data_Container>().productInfoArray;
			int num2 = productInfoArray.Length / 2;
			for (int i = 0; i < num2; i++)
			{
				if (productInfoArray[i * 2] >= 0 && productInfoArray[i * 2 + 1] > 0)
				{
					this.containersIndexes.Add(num);
				}
			}
			num++;
		}
		if (this.containersIndexes.Count > 0)
		{
			int index = Random.Range(0, this.containersIndexes.Count - 1);
			return this.containersIndexes[index];
		}
		return -1;
	}

	// Token: 0x060002BA RID: 698 RVA: 0x0001649C File Offset: 0x0001469C
	private int ContainerStillHasProducts(int containerIndex)
	{
		if (containerIndex >= this.shelvesOBJ.transform.childCount)
		{
			return -1;
		}
		this.productsIDsInContainer.Clear();
		int[] productInfoArray = this.shelvesOBJ.transform.GetChild(containerIndex).GetComponent<Data_Container>().productInfoArray;
		int num = productInfoArray.Length / 2;
		for (int i = 0; i < num; i++)
		{
			int num2 = productInfoArray[i * 2];
			if (num2 >= 0 && productInfoArray[i * 2 + 1] > 0)
			{
				this.productsIDsInContainer.Add(num2);
			}
		}
		if (this.productsIDsInContainer.Count > 0)
		{
			int index = Random.Range(0, this.productsIDsInContainer.Count - 1);
			return this.productsIDsInContainer[index];
		}
		return -1;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x00016549 File Offset: 0x00014749
	private IEnumerator MoveTowardsTarget(Vector3 destination, int targetState)
	{
		this.state = -1;
		float speedStep = this.speed * Time.deltaTime;
		while (Vector3.Distance(base.transform.position, destination) > 0.05f)
		{
			if (!this.beingHit)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, destination, speedStep);
			}
			yield return null;
		}
		yield return null;
		this.state = targetState;
		yield break;
	}

	// Token: 0x060002BC RID: 700 RVA: 0x00016566 File Offset: 0x00014766
	private IEnumerator WaitState(float waitTime, int targetState)
	{
		this.state = -1;
		yield return new WaitForSeconds(waitTime);
		this.state = targetState;
		yield break;
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00016584 File Offset: 0x00014784
	[Command(requiresAuthority = false)]
	public void CmdHitFromPlayer(Vector3 direction)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(direction);
		base.SendCommandInternal("System.Void HalloweenGhost::CmdHitFromPlayer(UnityEngine.Vector3)", 1303164378, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x000165C0 File Offset: 0x000147C0
	private void HitsCheck()
	{
		this.hits--;
		if (this.hits <= 0)
		{
			this.state = 2;
			GameObject gameObject = Object.Instantiate<GameObject>(this.stolenProductPrefab);
			gameObject.transform.position = base.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), 0f, Random.Range(-0.25f, 0.25f));
			gameObject.GetComponent<StolenProductSpawn>().NetworkproductID = 212;
			gameObject.GetComponent<StolenProductSpawn>().NetworkproductCarryingPrice = 100f + (float)(GameData.Instance.gameDay * 5);
			NetworkServer.Spawn(gameObject, null);
			this.speed = 0f;
			base.StartCoroutine(this.TimedDestroy());
			this.RpcDestroyPoof();
		}
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0001668E File Offset: 0x0001488E
	private IEnumerator TimedDestroy()
	{
		yield return new WaitForSeconds(2f);
		base.StopAllCoroutines();
		NetworkServer.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x000166A0 File Offset: 0x000148A0
	[ClientRpc]
	private void RpcDestroyPoof()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void HalloweenGhost::RpcDestroyPoof()", 1946251910, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x000166D0 File Offset: 0x000148D0
	private IEnumerator ScaleDown()
	{
		float elapsedTime = 0f;
		float waitTime = 1f;
		while (elapsedTime < waitTime)
		{
			float t = Mathf.Lerp(0f, 1f, elapsedTime / waitTime);
			float num = Mathf.Lerp(1f, 0f, t);
			base.transform.localScale = new Vector3(num, num, num);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		yield return null;
		yield break;
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x000166DF File Offset: 0x000148DF
	private IEnumerator HitDisplacement(Vector3 direction)
	{
		this.beingHit = true;
		float elapsedTime = 0f;
		float displacementTime = 1.5f;
		while (elapsedTime < displacementTime)
		{
			base.transform.Translate(direction.normalized * Time.deltaTime * this.speed);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		this.beingHit = false;
		yield break;
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x000166F8 File Offset: 0x000148F8
	[ClientRpc]
	private void RpcHitFromPlayer()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void HalloweenGhost::RpcHitFromPlayer()", -567655476, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x00016728 File Offset: 0x00014928
	private IEnumerator HitRotationEffect()
	{
		this.rotationEffect = true;
		Transform pivotTransform = base.transform.Find("Pivot");
		float elapsedTime = 0f;
		float displacementTime = 1.5f;
		while (elapsedTime < displacementTime)
		{
			pivotTransform.Rotate(-15f, 0f, 0f, Space.Self);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		pivotTransform.localRotation = Quaternion.identity;
		yield return null;
		this.rotationEffect = false;
		yield break;
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x00016737 File Offset: 0x00014937
	private void SetColor()
	{
		base.transform.Find("Pivot/Ghost").GetComponent<SkinnedMeshRenderer>().material.color = this.ghostColor;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x060002C8 RID: 712 RVA: 0x00016790 File Offset: 0x00014990
	// (set) Token: 0x060002C9 RID: 713 RVA: 0x000167A3 File Offset: 0x000149A3
	public Color NetworkghostColor
	{
		get
		{
			return this.ghostColor;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<Color>(value, ref this.ghostColor, 1UL, null);
		}
	}

	// Token: 0x060002CA RID: 714 RVA: 0x000167BD File Offset: 0x000149BD
	protected void UserCode_CmdHitFromPlayer__Vector3(Vector3 direction)
	{
		direction = new Vector3(direction.x, 0f, direction.z);
		if (!this.beingHit)
		{
			base.StartCoroutine(this.HitDisplacement(direction));
		}
		this.RpcHitFromPlayer();
		this.HitsCheck();
	}

	// Token: 0x060002CB RID: 715 RVA: 0x000167F9 File Offset: 0x000149F9
	protected static void InvokeUserCode_CmdHitFromPlayer__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdHitFromPlayer called on client.");
			return;
		}
		((HalloweenGhost)obj).UserCode_CmdHitFromPlayer__Vector3(reader.ReadVector3());
	}

	// Token: 0x060002CC RID: 716 RVA: 0x00016824 File Offset: 0x00014A24
	protected void UserCode_RpcDestroyPoof()
	{
		base.transform.Find("GhostPoof").gameObject.SetActive(true);
		AudioSource component = base.transform.Find("LaughSound").GetComponent<AudioSource>();
		component.clip = this.ghostsLaugh[Random.Range(0, this.ghostsLaugh.Length)];
		component.Play();
		base.StartCoroutine(this.ScaleDown());
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0001688E File Offset: 0x00014A8E
	protected static void InvokeUserCode_RpcDestroyPoof(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcDestroyPoof called on server.");
			return;
		}
		((HalloweenGhost)obj).UserCode_RpcDestroyPoof();
	}

	// Token: 0x060002CE RID: 718 RVA: 0x000168B1 File Offset: 0x00014AB1
	protected void UserCode_RpcHitFromPlayer()
	{
		base.transform.Find("HitSound").GetComponent<AudioSource>().Play();
		if (!this.rotationEffect)
		{
			base.StartCoroutine(this.HitRotationEffect());
		}
	}

	// Token: 0x060002CF RID: 719 RVA: 0x000168E2 File Offset: 0x00014AE2
	protected static void InvokeUserCode_RpcHitFromPlayer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHitFromPlayer called on server.");
			return;
		}
		((HalloweenGhost)obj).UserCode_RpcHitFromPlayer();
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x00016908 File Offset: 0x00014B08
	static HalloweenGhost()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(HalloweenGhost), "System.Void HalloweenGhost::CmdHitFromPlayer(UnityEngine.Vector3)", new RemoteCallDelegate(HalloweenGhost.InvokeUserCode_CmdHitFromPlayer__Vector3), false);
		RemoteProcedureCalls.RegisterRpc(typeof(HalloweenGhost), "System.Void HalloweenGhost::RpcDestroyPoof()", new RemoteCallDelegate(HalloweenGhost.InvokeUserCode_RpcDestroyPoof));
		RemoteProcedureCalls.RegisterRpc(typeof(HalloweenGhost), "System.Void HalloweenGhost::RpcHitFromPlayer()", new RemoteCallDelegate(HalloweenGhost.InvokeUserCode_RpcHitFromPlayer));
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x00016978 File Offset: 0x00014B78
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteColor(this.ghostColor);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteColor(this.ghostColor);
		}
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x000169D0 File Offset: 0x00014BD0
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<Color>(ref this.ghostColor, null, reader.ReadColor());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<Color>(ref this.ghostColor, null, reader.ReadColor());
		}
	}

	// Token: 0x04000286 RID: 646
	[SyncVar]
	public Color ghostColor;

	// Token: 0x04000287 RID: 647
	[Space(10f)]
	public float speed = 3f;

	// Token: 0x04000288 RID: 648
	public int hits;

	// Token: 0x04000289 RID: 649
	[Space(10f)]
	public int state;

	// Token: 0x0400028A RID: 650
	public PlayMakerFSM lookAtFSM;

	// Token: 0x0400028B RID: 651
	public GameObject stolenProductPrefab;

	// Token: 0x0400028C RID: 652
	public AudioClip[] ghostsLaugh;

	// Token: 0x0400028D RID: 653
	private int currentContainerIndex = -1;

	// Token: 0x0400028E RID: 654
	private int productsToDrop;

	// Token: 0x0400028F RID: 655
	private bool beingHit;

	// Token: 0x04000290 RID: 656
	private bool rotationEffect;

	// Token: 0x04000291 RID: 657
	private GameObject shelvesOBJ;

	// Token: 0x04000292 RID: 658
	private FsmVector3 fsmVectorVariable;

	// Token: 0x04000293 RID: 659
	private List<int> containersIndexes = new List<int>();

	// Token: 0x04000294 RID: 660
	private List<int> productsIDsInContainer = new List<int>();
}

using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class HashTableSortKeysfromValues : MonoBehaviour
{
	// Token: 0x06000069 RID: 105 RVA: 0x0000465C File Offset: 0x0000285C
	private void Start()
	{
	}

	// Token: 0x0600006A RID: 106 RVA: 0x0000465C File Offset: 0x0000285C
	private void Update()
	{
	}
}

using System;
using UnityEngine;

// Token: 0x02000068 RID: 104
public class HatInfo : MonoBehaviour
{
	// Token: 0x040002B4 RID: 692
	public Vector3 offset;

	// Token: 0x040002B5 RID: 693
	public Vector3 rotation;
}

using System;
using StarterAssets;
using UnityEngine;

// Token: 0x02000069 RID: 105
public class InteractableContainer : MonoBehaviour
{
	// Token: 0x060002F8 RID: 760 RVA: 0x00016ED0 File Offset: 0x000150D0
	public void ContainerAddItem()
	{
		if (!FirstPersonController.Instance)
		{
			return;
		}
		if (this.isStorageShelf)
		{
			this.StorageAddBox();
			return;
		}
		int extraParameter = FirstPersonController.Instance.GetComponent<PlayerNetwork>().extraParameter1;
		if (extraParameter > -1)
		{
			if (FirstPersonController.Instance.GetComponent<PlayerNetwork>().extraParameter2 > 0)
			{
				base.transform.parent.transform.parent.GetComponent<Data_Container>().AddItemToRow(base.transform.GetSiblingIndex(), extraParameter);
				return;
			}
			GameCanvas.Instance.CreateCanvasNotification("message8");
		}
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x00016F5A File Offset: 0x0001515A
	public void ContainerRemoveItem()
	{
		if (this.isStorageShelf)
		{
			this.ClearStorageBox();
			return;
		}
		base.transform.parent.transform.parent.GetComponent<Data_Container>().RemoveItemFromRow(base.transform.GetSiblingIndex());
	}

	// Token: 0x060002FA RID: 762 RVA: 0x00016F95 File Offset: 0x00015195
	public void StorageAddBox()
	{
		base.transform.parent.transform.parent.GetComponent<Data_Container>().GetStorageBox(base.transform.GetSiblingIndex());
	}

	// Token: 0x060002FB RID: 763 RVA: 0x00016FC1 File Offset: 0x000151C1
	public void ClearStorageBox()
	{
		base.transform.parent.transform.parent.GetComponent<Data_Container>().ClearStorageBox(base.transform.GetSiblingIndex());
	}

	// Token: 0x040002B6 RID: 694
	public bool isStorageShelf;
}

using System;
using UnityEngine;

// Token: 0x0200006A RID: 106
public class InteractableData : MonoBehaviour
{
	// Token: 0x040002B7 RID: 695
	public int thisSkillIndex;

	// Token: 0x040002B8 RID: 696
	public int[] previousSkillRequirements;

	// Token: 0x040002B9 RID: 697
	[Space(10f)]
	public bool hasInteractableData;

	// Token: 0x040002BA RID: 698
	public string mainTitleString;

	// Token: 0x040002BB RID: 699
	public string[] unlockStrings;

	// Token: 0x040002BC RID: 700
	public string[] requireStrings;
}

using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class LobbiesListManager : MonoBehaviour
{
	// Token: 0x0600037A RID: 890 RVA: 0x00019C2B File Offset: 0x00017E2B
	private void Start()
	{
		this.onCooldown = false;
		this.LobbyList = Callback<LobbyMatchList_t>.Create(new Callback<LobbyMatchList_t>.DispatchDelegate(this.OnGetLobbyList));
		this.LobbyDataUpdated = Callback<LobbyDataUpdate_t>.Create(new Callback<LobbyDataUpdate_t>.DispatchDelegate(this.OnGetLobbyData));
	}

	// Token: 0x0600037B RID: 891 RVA: 0x00019C62 File Offset: 0x00017E62
	public void GetListOfLobbies()
	{
		this.lobbiesMenu.SetActive(true);
		this.GetLobbiesList();
	}

	// Token: 0x0600037C RID: 892 RVA: 0x00019C78 File Offset: 0x00017E78
	public void DisplayLobbies(List<CSteamID> lobbyIDs, LobbyDataUpdate_t result)
	{
		if (!this)
		{
			return;
		}
		int num = 0;
		while (num < lobbyIDs.Count && this.lobbyListContent.transform.childCount < 36)
		{
			if (lobbyIDs[num].m_SteamID == result.m_ulSteamIDLobby && this.lobbyListContent)
			{
				string lobbyData = SteamMatchmaking.GetLobbyData((CSteamID)lobbyIDs[num].m_SteamID, "name");
				if (lobbyData.Contains("'s Supermarket") && !lobbyData.Contains("</color>"))
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.lobbyDataItemPrefab);
					gameObject.GetComponent<LobbyDataEntry>().lobbyID = (CSteamID)lobbyIDs[num].m_SteamID;
					gameObject.GetComponent<LobbyDataEntry>().lobbyName = lobbyData;
					gameObject.GetComponent<LobbyDataEntry>().SetLobbyData();
					gameObject.transform.SetParent(this.lobbyListContent.transform);
					gameObject.transform.localScale = Vector3.one;
					this.listOfLobbies.Add(gameObject);
				}
			}
			num++;
		}
	}

	// Token: 0x0600037D RID: 893 RVA: 0x00019D8C File Offset: 0x00017F8C
	public void DestroyLobbies()
	{
		foreach (GameObject obj in this.listOfLobbies)
		{
			Object.Destroy(obj);
		}
		this.listOfLobbies.Clear();
	}

	// Token: 0x0600037E RID: 894 RVA: 0x00019DE8 File Offset: 0x00017FE8
	public void GetLobbiesList()
	{
		if (this.lobbyIDs.Count > 0)
		{
			this.lobbyIDs.Clear();
		}
		SteamMatchmaking.AddRequestLobbyListResultCountFilter(36);
		SteamMatchmaking.RequestLobbyList();
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00019E10 File Offset: 0x00018010
	private void OnGetLobbyList(LobbyMatchList_t result)
	{
		if (this.listOfLobbies.Count > 0)
		{
			this.DestroyLobbies();
		}
		int num = 0;
		while ((long)num < (long)((ulong)result.m_nLobbiesMatching))
		{
			CSteamID lobbyByIndex = SteamMatchmaking.GetLobbyByIndex(num);
			this.lobbyIDs.Add(lobbyByIndex);
			SteamMatchmaking.RequestLobbyData(lobbyByIndex);
			num++;
		}
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00019E5E File Offset: 0x0001805E
	private void OnGetLobbyData(LobbyDataUpdate_t result)
	{
		this.DisplayLobbies(this.lobbyIDs, result);
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00019E6D File Offset: 0x0001806D
	private IEnumerator OnCooldown()
	{
		yield return new WaitForSeconds(1f);
		this.onCooldown = false;
		yield break;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00019E7C File Offset: 0x0001807C
	private void OnDisable()
	{
		base.StopAllCoroutines();
	}

	// Token: 0x040002FE RID: 766
	public GameObject lobbiesMenu;

	// Token: 0x040002FF RID: 767
	public GameObject lobbyDataItemPrefab;

	// Token: 0x04000300 RID: 768
	public GameObject lobbyListContent;

	// Token: 0x04000301 RID: 769
	protected Callback<LobbyMatchList_t> LobbyList;

	// Token: 0x04000302 RID: 770
	protected Callback<LobbyDataUpdate_t> LobbyDataUpdated;

	// Token: 0x04000303 RID: 771
	public List<CSteamID> lobbyIDs = new List<CSteamID>();

	// Token: 0x04000304 RID: 772
	public List<GameObject> listOfLobbies = new List<GameObject>();

	// Token: 0x04000305 RID: 773
	private bool onCooldown;
}

using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using TMPro;
using UnityEngine;

// Token: 0x02000076 RID: 118
public class LobbyController : MonoBehaviour
{
	// Token: 0x17000052 RID: 82
	// (get) Token: 0x0600038A RID: 906 RVA: 0x00019F10 File Offset: 0x00018110
	private CustomNetworkManager Manager
	{
		get
		{
			if (this.manager != null)
			{
				return this.manager;
			}
			return this.manager = (NetworkManager.singleton as CustomNetworkManager);
		}
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00019F45 File Offset: 0x00018145
	private void Awake()
	{
		if (LobbyController.Instance == null)
		{
			LobbyController.Instance = this;
		}
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00019F5A File Offset: 0x0001815A
	public void SendChatMessage(string message)
	{
		if (string.IsNullOrWhiteSpace(message))
		{
			return;
		}
		this.LocalplayerController.SendChatMsg(message);
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00019F71 File Offset: 0x00018171
	public void UpdateLobbyName()
	{
		this.CurrentLobbyID = this.Manager.GetComponent<SteamLobby>().CurrentLobbyID;
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00019F8C File Offset: 0x0001818C
	public void UpdatePlayerList()
	{
		if (!this.PlayerItemCreated)
		{
			this.CreateHostPlayerItem();
		}
		if (this.PlayerListItems.Count < this.Manager.GamePlayers.Count)
		{
			this.CreateClientPlayerItem();
		}
		if (this.PlayerListItems.Count > this.Manager.GamePlayers.Count)
		{
			this.RemovePlayerItem();
		}
		if (this.PlayerListItems.Count == this.Manager.GamePlayers.Count)
		{
			this.UpdatePlayerItem();
		}
	}

	// Token: 0x0600038F RID: 911 RVA: 0x0001A010 File Offset: 0x00018210
	public void FindLocalPlayer()
	{
		this.LocalPlayerObject = GameObject.Find("LocalGamePlayer");
		this.LocalplayerController = this.LocalPlayerObject.GetComponent<PlayerObjectController>();
	}

	// Token: 0x06000390 RID: 912 RVA: 0x0001A034 File Offset: 0x00018234
	public void CreateHostPlayerItem()
	{
		foreach (PlayerObjectController playerObjectController in this.Manager.GamePlayers)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.PlayerListItemPrefab);
			PlayerListItem component = gameObject.GetComponent<PlayerListItem>();
			component.playerOBJ = playerObjectController.gameObject;
			component.PlayerName = playerObjectController.PlayerName;
			component.ConnectionID = playerObjectController.ConnectionID;
			component.PlayerSteamID = playerObjectController.PlayerSteamID;
			component.SetPlayerValues();
			gameObject.transform.SetParent(this.PlayerListViewContent.transform);
			gameObject.transform.localScale = Vector3.one;
			this.PlayerListItems.Add(component);
		}
		this.PlayerItemCreated = true;
	}

	// Token: 0x06000391 RID: 913 RVA: 0x0001A10C File Offset: 0x0001830C
	public void CreateClientPlayerItem()
	{
		using (List<PlayerObjectController>.Enumerator enumerator = this.Manager.GamePlayers.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PlayerObjectController player = enumerator.Current;
				if (!this.PlayerListItems.Any((PlayerListItem b) => b.ConnectionID == player.ConnectionID))
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.PlayerListItemPrefab);
					PlayerListItem component = gameObject.GetComponent<PlayerListItem>();
					component.playerOBJ = player.gameObject;
					component.PlayerName = player.PlayerName;
					component.ConnectionID = player.ConnectionID;
					component.PlayerSteamID = player.PlayerSteamID;
					component.SetPlayerValues();
					gameObject.transform.SetParent(this.PlayerListViewContent.transform);
					gameObject.transform.localScale = Vector3.one;
					this.PlayerListItems.Add(component);
				}
			}
		}
	}

	// Token: 0x06000392 RID: 914 RVA: 0x0001A218 File Offset: 0x00018418
	public void UpdatePlayerItem()
	{
		foreach (PlayerObjectController playerObjectController in this.Manager.GamePlayers)
		{
			foreach (PlayerListItem playerListItem in this.PlayerListItems)
			{
				if (playerListItem.ConnectionID == playerObjectController.ConnectionID)
				{
					playerListItem.PlayerName = playerObjectController.PlayerName;
					playerListItem.SetPlayerValues();
				}
			}
		}
	}

	// Token: 0x06000393 RID: 915 RVA: 0x0001A2C4 File Offset: 0x000184C4
	public void RemovePlayerItem()
	{
		List<PlayerListItem> list = new List<PlayerListItem>();
		using (List<PlayerListItem>.Enumerator enumerator = this.PlayerListItems.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PlayerListItem playerlistItem = enumerator.Current;
				if (!this.Manager.GamePlayers.Any((PlayerObjectController b) => b.ConnectionID == playerlistItem.ConnectionID))
				{
					list.Add(playerlistItem);
				}
			}
		}
		if (list.Count > 0)
		{
			foreach (PlayerListItem playerListItem in list)
			{
				Object gameObject = playerListItem.gameObject;
				this.PlayerListItems.Remove(playerListItem);
				Object.Destroy(gameObject);
			}
		}
	}

	// Token: 0x04000309 RID: 777
	public static LobbyController Instance;

	// Token: 0x0400030A RID: 778
	public TextMeshProUGUI LobbyNameText;

	// Token: 0x0400030B RID: 779
	public TextMeshProUGUI LobbyIDText;

	// Token: 0x0400030C RID: 780
	public GameObject PlayerListViewContent;

	// Token: 0x0400030D RID: 781
	public GameObject PlayerListItemPrefab;

	// Token: 0x0400030E RID: 782
	public GameObject LocalPlayerObject;

	// Token: 0x0400030F RID: 783
	public ulong CurrentLobbyID;

	// Token: 0x04000310 RID: 784
	public bool PlayerItemCreated;

	// Token: 0x04000311 RID: 785
	private List<PlayerListItem> PlayerListItems = new List<PlayerListItem>();

	// Token: 0x04000312 RID: 786
	public PlayerObjectController LocalplayerController;

	// Token: 0x04000313 RID: 787
	private CustomNetworkManager manager;

	// Token: 0x04000314 RID: 788
	public GameObject ChatContainerOBJ;
}

using System;
using Steamworks;
using TMPro;
using UnityEngine;

// Token: 0x02000079 RID: 121
public class LobbyDataEntry : MonoBehaviour
{
	// Token: 0x06000399 RID: 921 RVA: 0x0001A3E1 File Offset: 0x000185E1
	public void SetLobbyData()
	{
		if (this.lobbyName == "")
		{
			this.lobbyNameText.text = "Empty";
			return;
		}
		this.lobbyNameText.text = this.lobbyName;
	}

	// Token: 0x0600039A RID: 922 RVA: 0x0001A417 File Offset: 0x00018617
	public string GetLobbyIdStr()
	{
		return this.lobbyID.ToString();
	}

	// Token: 0x0600039B RID: 923 RVA: 0x0001A42A File Offset: 0x0001862A
	public void JoinLobby()
	{
		SteamLobby.Instance.JoinLobby(this.lobbyID);
	}

	// Token: 0x04000317 RID: 791
	public CSteamID lobbyID;

	// Token: 0x04000318 RID: 792
	public string lobbyName;

	// Token: 0x04000319 RID: 793
	public TextMeshProUGUI lobbyNameText;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200006B RID: 107
public class LocalizationManager : MonoBehaviour
{
	// Token: 0x060002FE RID: 766 RVA: 0x00016FED File Offset: 0x000151ED
	private void Awake()
	{
		if (LocalizationManager.instance == null)
		{
			LocalizationManager.instance = this;
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x00017002 File Offset: 0x00015202
	public void ClearDictionary()
	{
		this.LocalizationDictionary.Clear();
	}

	// Token: 0x06000300 RID: 768 RVA: 0x0001700F File Offset: 0x0001520F
	public void AddDictionaryEntry(string key, string value)
	{
		this.LocalizationDictionary.Add(key, value);
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00017020 File Offset: 0x00015220
	public string GetLocalizationString(string key)
	{
		string result = "";
		if (this.LocalizationDictionary.TryGetValue(key, out result))
		{
			return result;
		}
		return "LocError";
	}

	// Token: 0x040002BD RID: 701
	public static LocalizationManager instance;

	// Token: 0x040002BE RID: 702
	public Dictionary<string, string> LocalizationDictionary = new Dictionary<string, string>();
}

using System;
using UnityEngine;

// Token: 0x0200006C RID: 108
public class Main_Data : MonoBehaviour
{
	// Token: 0x040002BF RID: 703
	public Material[] floorMaterialArray;
}

using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200006D RID: 109
public class ManagerBlackboard : NetworkBehaviour
{
	// Token: 0x06000304 RID: 772 RVA: 0x00017060 File Offset: 0x00015260
	private void FixedUpdate()
	{
		if (this.tabsOBJ.activeSelf)
		{
			string text = this.searchInputFieldOBJ.text;
			if (text != "" && text != this.oldInputString)
			{
				if (text.Length >= 2)
				{
					this.UpdateVisibleProductsOnSearch(text);
				}
				this.oldInputString = text;
			}
		}
		if (this.tabsOBJ.activeSelf && this.shopItemsParent.transform.childCount > 0)
		{
			if (this.fixedCounter == 0)
			{
				foreach (object obj in this.shopItemsParent.transform)
				{
					Transform transform = (Transform)obj;
					int productID = transform.GetComponent<Data_Product>().productID;
					int[] productsExistences = this.GetProductsExistences(productID);
					transform.transform.Find("InShelvesBCK/ShelvesQuantity").GetComponent<TextMeshProUGUI>().text = productsExistences[0].ToString();
					transform.transform.Find("InStorageBCK/StorageQuantity").GetComponent<TextMeshProUGUI>().text = productsExistences[1].ToString();
					transform.transform.Find("InBoxesBCK/BoxesQuantity").GetComponent<TextMeshProUGUI>().text = productsExistences[2].ToString();
				}
			}
			this.fixedCounter++;
			if (this.fixedCounter >= 15)
			{
				this.fixedCounter = 0;
			}
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x000171E0 File Offset: 0x000153E0
	public void UpdateUnlockedFranchises()
	{
		this.unlockedFranchises = base.GetComponent<ProductListing>().unlockedProductTiers;
		this.tiers = base.GetComponent<ProductListing>().tiers;
		if (this.shortcutsParent.transform.childCount > 0)
		{
			int childCount = this.shortcutsParent.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Object.Destroy(this.shortcutsParent.transform.GetChild(this.shortcutsParent.transform.childCount - 1 - i).gameObject);
			}
		}
		int num = -1;
		for (int j = 0; j < this.unlockedFranchises.Length; j++)
		{
			if (this.unlockedFranchises[j])
			{
				int num2 = ProductListing.Instance.productGroups[j];
				if (num != num2)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.UIShortcutPrefab, this.shortcutsParent.transform);
					this.fsm = gameObject.GetComponent<PlayMakerFSM>();
					this.fsm.FsmVariables.GetFsmInt("GroupIndex").Value = num2;
					string key = "productGroup" + num2.ToString();
					string localizationString = LocalizationManager.instance.GetLocalizationString(key);
					gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = localizationString;
					gameObject.transform.GetChild(1).GetComponent<Image>().color = ProductListing.Instance.groupsColors[num2];
					num = num2;
				}
			}
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x00017354 File Offset: 0x00015554
	private void UpdateVisibleProductsOnSearch(string stringContained)
	{
		this.SetShortcutHighlight(-1);
		this.ClearItems();
		ProductListing component = base.GetComponent<ProductListing>();
		stringContained = stringContained.ToLower();
		string localizationString = LocalizationManager.instance.GetLocalizationString("productRelated0");
		foreach (int num in component.availableProducts)
		{
			if (LocalizationManager.instance.GetLocalizationString("product" + num.ToString()).ToLower().Contains(stringContained))
			{
				float tinflactionFactor = component.tierInflation[component.productPrefabs[num].GetComponent<Data_Product>().productTier];
				this.CreateUIShopItem(num, component, tinflactionFactor, localizationString);
			}
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0001741C File Offset: 0x0001561C
	public void UpdateVisibleProducts(int groupTier)
	{
		this.SetShortcutHighlight(groupTier);
		this.ClearItems();
		this.oldGroupTier = groupTier;
		ProductListing component = base.GetComponent<ProductListing>();
		for (int i = 0; i < this.unlockedFranchises.Length; i++)
		{
			if (this.unlockedFranchises[i] && ProductListing.Instance.productGroups[i] == groupTier)
			{
				string[] array = this.tiers[i].Split(char.Parse("-"), StringSplitOptions.None);
				float tinflactionFactor = component.tierInflation[i];
				string localizationString = LocalizationManager.instance.GetLocalizationString("productRelated0");
				int num = int.Parse(array[0]);
				int num2 = int.Parse(array[1]);
				for (int j = num; j < num2 + 1; j++)
				{
					this.CreateUIShopItem(j, component, tinflactionFactor, localizationString);
				}
			}
		}
	}

	// Token: 0x06000308 RID: 776 RVA: 0x000174D9 File Offset: 0x000156D9
	public void ReupdateVisibleProducts()
	{
		if (this.oldGroupTier > -1)
		{
			this.UpdateVisibleProducts(this.oldGroupTier);
		}
	}

	// Token: 0x06000309 RID: 777 RVA: 0x000174F0 File Offset: 0x000156F0
	private void SetShortcutHighlight(int currentIndex)
	{
		foreach (object obj in this.shortcutsParent.transform)
		{
			Transform transform = (Transform)obj;
			if (transform.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("GroupIndex").Value == currentIndex)
			{
				transform.transform.Find("Highlight").gameObject.SetActive(true);
			}
			else
			{
				transform.transform.Find("Highlight").gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0001759C File Offset: 0x0001579C
	private void ClearItems()
	{
		if (this.shopItemsParent.transform.childCount > 0)
		{
			int childCount = this.shopItemsParent.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Object.Destroy(this.shopItemsParent.transform.GetChild(this.shopItemsParent.transform.childCount - 1 - i).gameObject);
			}
		}
	}

	// Token: 0x0600030B RID: 779 RVA: 0x00017608 File Offset: 0x00015808
	private void CreateUIShopItem(int productIndex, ProductListing pListingReference, float tinflactionFactor, string pricePerUnitLocalized)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.UIShopItemPrefab, this.shopItemsParent.transform);
		gameObject.transform.Find("ProductIcon").GetComponent<Image>().sprite = pListingReference.productSprites[productIndex];
		string key = "product" + productIndex.ToString();
		string localizationString = LocalizationManager.instance.GetLocalizationString(key);
		gameObject.transform.Find("ProductName").GetComponent<TextMeshProUGUI>().text = localizationString;
		GameObject gameObject2 = pListingReference.productPrefabs[productIndex];
		int maxItemsPerBox = gameObject2.GetComponent<Data_Product>().maxItemsPerBox;
		string productBrand = gameObject2.GetComponent<Data_Product>().productBrand;
		float num = gameObject2.GetComponent<Data_Product>().basePricePerUnit;
		num *= tinflactionFactor;
		num = Mathf.Round(num * 100f) / 100f;
		float num2 = num * (float)maxItemsPerBox;
		num2 = Mathf.Round(num2 * 100f) / 100f;
		gameObject.transform.Find("ProductIcon/BoxQuantity").GetComponent<TextMeshProUGUI>().text = "x" + maxItemsPerBox.ToString();
		gameObject.transform.Find("BrandName").GetComponent<TextMeshProUGUI>().text = productBrand;
		gameObject.transform.Find("PricePerUnit").GetComponent<TextMeshProUGUI>().text = pricePerUnitLocalized + " $" + num.ToString();
		gameObject.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text = " $" + num2.ToString();
		this.fsm = gameObject.transform.Find("AddButton").GetComponent<PlayMakerFSM>();
		this.fsm.FsmVariables.GetFsmInt("ProductID").Value = productIndex;
		this.fsm.FsmVariables.GetFsmFloat("BoxPrice").Value = num2;
		gameObject.GetComponent<Data_Product>().productID = productIndex;
		int productContainerClass = gameObject2.GetComponent<Data_Product>().productContainerClass;
		if (productContainerClass < this.containerTypeSprites.Length)
		{
			Sprite sprite = this.containerTypeSprites[productContainerClass];
			gameObject.transform.Find("ContainerTypeBCK/ContainerImage").GetComponent<Image>().sprite = sprite;
			gameObject.transform.Find("ContainerTypeBCK").gameObject.SetActive(true);
		}
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00017844 File Offset: 0x00015A44
	private int[] GetProductsExistences(int productIDToCompare)
	{
		int[] array = new int[3];
		for (int i = 0; i < this.dummyArrayExistences.Length; i++)
		{
			GameObject gameObject = this.dummyArrayExistences[i];
			if (gameObject.transform.childCount != 0)
			{
				if (i != 2)
				{
					using (IEnumerator enumerator = gameObject.transform.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							int[] productInfoArray = ((Transform)obj).GetComponent<Data_Container>().productInfoArray;
							int num = productInfoArray.Length / 2;
							for (int j = 0; j < num; j++)
							{
								int num2 = productInfoArray[j * 2];
								if (productIDToCompare == num2)
								{
									int num3 = productInfoArray[j * 2 + 1];
									if (num3 > 0)
									{
										array[i] += num3;
									}
								}
							}
						}
						goto IL_11C;
					}
				}
				foreach (object obj2 in gameObject.transform)
				{
					BoxData component = ((Transform)obj2).GetComponent<BoxData>();
					int productID = component.productID;
					if (productIDToCompare == productID)
					{
						int numberOfProducts = component.numberOfProducts;
						if (numberOfProducts > 0)
						{
							array[i] += numberOfProducts;
						}
					}
				}
			}
			IL_11C:;
		}
		return array;
	}

	// Token: 0x0600030D RID: 781 RVA: 0x0001799C File Offset: 0x00015B9C
	public void AddShoppingListProduct(int productID, float boxPrice)
	{
		ProductListing component = base.GetComponent<ProductListing>();
		GameObject gameObject = Object.Instantiate<GameObject>(this.UIShoppingListPrefab, this.shoppingListParent.transform);
		string key = "product" + productID.ToString();
		string localizationString = LocalizationManager.instance.GetLocalizationString(key);
		gameObject.transform.Find("ProductName").GetComponent<TextMeshProUGUI>().text = localizationString;
		GameObject gameObject2 = component.productPrefabs[productID];
		string productBrand = gameObject2.GetComponent<Data_Product>().productBrand;
		gameObject.transform.Find("BrandName").GetComponent<TextMeshProUGUI>().text = productBrand;
		int maxItemsPerBox = gameObject2.GetComponent<Data_Product>().maxItemsPerBox;
		gameObject.transform.Find("BoxQuantity").GetComponent<TextMeshProUGUI>().text = "x" + maxItemsPerBox.ToString();
		gameObject.transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text = " $" + boxPrice.ToString();
		gameObject.GetComponent<InteractableData>().thisSkillIndex = productID;
		base.StartCoroutine(this.CalculateShoppingListTotal());
	}

	// Token: 0x0600030E RID: 782 RVA: 0x00017AA8 File Offset: 0x00015CA8
	public void RemoveShoppingListProduct(int indexToRemove)
	{
		if (this.shoppingListParent.transform.childCount > 0)
		{
			Object.Destroy(this.shoppingListParent.transform.GetChild(indexToRemove).gameObject);
		}
		base.StartCoroutine(this.CalculateShoppingListTotal());
	}

	// Token: 0x0600030F RID: 783 RVA: 0x00017AE5 File Offset: 0x00015CE5
	private IEnumerator CalculateShoppingListTotal()
	{
		yield return new WaitForEndOfFrame();
		this.shoppingTotalCharge = 0f;
		if (this.shoppingListParent.transform.childCount > 0)
		{
			foreach (object obj in this.shoppingListParent.transform)
			{
				string text = ((Transform)obj).transform.Find("BoxPrice").GetComponent<TextMeshProUGUI>().text;
				text = text.Substring(2);
				this.shoppingTotalCharge += float.Parse(text);
			}
		}
		this.totalChargeOBJ.text = ProductListing.Instance.ConvertFloatToTextPrice(this.shoppingTotalCharge);
		yield break;
	}

	// Token: 0x06000310 RID: 784 RVA: 0x00017AF4 File Offset: 0x00015CF4
	public void BuyCargo()
	{
		if (this.shoppingListParent.transform.childCount == 0 || this.shoppingTotalCharge == 0f)
		{
			GameCanvas.Instance.CreateCanvasNotification("message5");
			return;
		}
		if (base.GetComponent<GameData>().gameFunds < this.shoppingTotalCharge)
		{
			GameCanvas.Instance.CreateCanvasNotification("message6");
			return;
		}
		foreach (object obj in this.shoppingListParent.transform)
		{
			int thisSkillIndex = ((Transform)obj).GetComponent<InteractableData>().thisSkillIndex;
			this.CmdAddProductToSpawnList(thisSkillIndex);
		}
		int childCount = this.shoppingListParent.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Object.Destroy(this.shoppingListParent.transform.GetChild(this.shoppingListParent.transform.childCount - 1 - i).gameObject);
		}
		base.GetComponent<GameData>().CmdAlterFunds(-this.shoppingTotalCharge);
		base.GetComponent<GameData>().CmdmoneySpentOnProducts(this.shoppingTotalCharge);
		this.shoppingTotalCharge = 0f;
		this.totalChargeOBJ.text = "$0,00";
	}

	// Token: 0x06000311 RID: 785 RVA: 0x00017C3C File Offset: 0x00015E3C
	[Command(requiresAuthority = false)]
	private void CmdAddProductToSpawnList(int productIDToAdd)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(productIDToAdd);
		base.SendCommandInternal("System.Void ManagerBlackboard::CmdAddProductToSpawnList(System.Int32)", 2005032198, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000312 RID: 786 RVA: 0x00017C76 File Offset: 0x00015E76
	private IEnumerator ServerCargoSpawner()
	{
		this.isSpawning = true;
		while (this.idsToSpawn.Count > 0)
		{
			yield return new WaitForSeconds(0.5f);
			int num = this.idsToSpawn[0];
			Vector3 b = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
			GameObject gameObject = Object.Instantiate<GameObject>(this.boxPrefab, this.merchandiseSpawnpoint.transform.position + b, Quaternion.identity);
			gameObject.GetComponent<BoxData>().NetworkproductID = num;
			int maxItemsPerBox = base.GetComponent<ProductListing>().productPrefabs[num].GetComponent<Data_Product>().maxItemsPerBox;
			gameObject.GetComponent<BoxData>().NetworknumberOfProducts = maxItemsPerBox;
			Sprite sprite = base.GetComponent<ProductListing>().productSprites[num];
			gameObject.transform.Find("Canvas/Image1").GetComponent<Image>().sprite = sprite;
			gameObject.transform.Find("Canvas/Image2").GetComponent<Image>().sprite = sprite;
			gameObject.transform.SetParent(this.boxParent);
			NetworkServer.Spawn(gameObject, null);
			this.RpcParentBoxOnClient(gameObject);
			this.idsToSpawn.RemoveAt(0);
		}
		yield return new WaitForSeconds(0.1f);
		this.isSpawning = false;
		yield break;
	}

	// Token: 0x06000313 RID: 787 RVA: 0x00017C85 File Offset: 0x00015E85
	public void BuyEmptyBox()
	{
		if (base.GetComponent<GameData>().gameFunds >= 8f)
		{
			base.GetComponent<GameData>().CmdAlterFunds(-8f);
			this.CmdSpawnBoxEmpty();
			return;
		}
		GameCanvas.Instance.CreateCanvasNotification("message6");
	}

	// Token: 0x06000314 RID: 788 RVA: 0x00017CC0 File Offset: 0x00015EC0
	[Command(requiresAuthority = false)]
	public void CmdSpawnBoxEmpty()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void ManagerBlackboard::CmdSpawnBoxEmpty()", 947669664, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000315 RID: 789 RVA: 0x00017CF0 File Offset: 0x00015EF0
	[Command(requiresAuthority = false)]
	public void CmdSpawnBoxFromPlayer(Vector3 spawnpoint, int productID, int numberOfProductsInBox, float YRotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(spawnpoint);
		writer.WriteInt(productID);
		writer.WriteInt(numberOfProductsInBox);
		writer.WriteFloat(YRotation);
		base.SendCommandInternal("System.Void ManagerBlackboard::CmdSpawnBoxFromPlayer(UnityEngine.Vector3,System.Int32,System.Int32,System.Single)", -1046098784, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000316 RID: 790 RVA: 0x00017D48 File Offset: 0x00015F48
	public void SpawnBoxFromEmployee(Vector3 spawnpoint, int productID, int numberOfProductsInBox)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.boxPrefab, spawnpoint, Quaternion.identity);
		gameObject.GetComponent<BoxData>().NetworkproductID = productID;
		gameObject.GetComponent<BoxData>().NetworknumberOfProducts = numberOfProductsInBox;
		gameObject.transform.SetParent(this.boxParent);
		NetworkServer.Spawn(gameObject, null);
		this.RpcParentBoxOnClient(gameObject);
	}

	// Token: 0x06000317 RID: 791 RVA: 0x00017DA0 File Offset: 0x00015FA0
	[ClientRpc]
	private void RpcParentBoxOnClient(GameObject boxOBJ)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(boxOBJ);
		this.SendRPCInternal("System.Void ManagerBlackboard::RpcParentBoxOnClient(UnityEngine.GameObject)", -1079222151, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x0600031A RID: 794 RVA: 0x00017DF4 File Offset: 0x00015FF4
	protected void UserCode_CmdAddProductToSpawnList__Int32(int productIDToAdd)
	{
		this.idsToSpawn.Add(productIDToAdd);
		if (base.isServer && !this.isSpawning)
		{
			base.StartCoroutine(this.ServerCargoSpawner());
		}
	}

	// Token: 0x0600031B RID: 795 RVA: 0x00017E1F File Offset: 0x0001601F
	protected static void InvokeUserCode_CmdAddProductToSpawnList__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddProductToSpawnList called on client.");
			return;
		}
		((ManagerBlackboard)obj).UserCode_CmdAddProductToSpawnList__Int32(reader.ReadInt());
	}

	// Token: 0x0600031C RID: 796 RVA: 0x00017E48 File Offset: 0x00016048
	protected void UserCode_CmdSpawnBoxEmpty()
	{
		Vector3 b = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
		GameObject gameObject = Object.Instantiate<GameObject>(this.boxPrefab, this.emptyBoxSpawnpoint.transform.position + b, Quaternion.identity);
		gameObject.GetComponent<BoxData>().NetworkproductID = Random.Range(0, base.GetComponent<ProductListing>().productPrefabs.Length);
		gameObject.GetComponent<BoxData>().NetworknumberOfProducts = 0;
		NetworkServer.Spawn(gameObject, null);
	}

	// Token: 0x0600031D RID: 797 RVA: 0x00017ED5 File Offset: 0x000160D5
	protected static void InvokeUserCode_CmdSpawnBoxEmpty(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnBoxEmpty called on client.");
			return;
		}
		((ManagerBlackboard)obj).UserCode_CmdSpawnBoxEmpty();
	}

	// Token: 0x0600031E RID: 798 RVA: 0x00017EF8 File Offset: 0x000160F8
	protected void UserCode_CmdSpawnBoxFromPlayer__Vector3__Int32__Int32__Single(Vector3 spawnpoint, int productID, int numberOfProductsInBox, float YRotation)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.boxPrefab, spawnpoint, Quaternion.Euler(0f, YRotation + 90f, 0f));
		gameObject.GetComponent<BoxData>().NetworkproductID = productID;
		gameObject.GetComponent<BoxData>().NetworknumberOfProducts = numberOfProductsInBox;
		gameObject.transform.SetParent(this.boxParent);
		NetworkServer.Spawn(gameObject, null);
		this.RpcParentBoxOnClient(gameObject);
	}

	// Token: 0x0600031F RID: 799 RVA: 0x00017F60 File Offset: 0x00016160
	protected static void InvokeUserCode_CmdSpawnBoxFromPlayer__Vector3__Int32__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnBoxFromPlayer called on client.");
			return;
		}
		((ManagerBlackboard)obj).UserCode_CmdSpawnBoxFromPlayer__Vector3__Int32__Int32__Single(reader.ReadVector3(), reader.ReadInt(), reader.ReadInt(), reader.ReadFloat());
	}

	// Token: 0x06000320 RID: 800 RVA: 0x00017F9C File Offset: 0x0001619C
	protected void UserCode_RpcParentBoxOnClient__GameObject(GameObject boxOBJ)
	{
		if (!base.isServer)
		{
			boxOBJ.transform.SetParent(this.boxParent);
		}
	}

	// Token: 0x06000321 RID: 801 RVA: 0x00017FB7 File Offset: 0x000161B7
	protected static void InvokeUserCode_RpcParentBoxOnClient__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcParentBoxOnClient called on server.");
			return;
		}
		((ManagerBlackboard)obj).UserCode_RpcParentBoxOnClient__GameObject(reader.ReadGameObject());
	}

	// Token: 0x06000322 RID: 802 RVA: 0x00017FE0 File Offset: 0x000161E0
	static ManagerBlackboard()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ManagerBlackboard), "System.Void ManagerBlackboard::CmdAddProductToSpawnList(System.Int32)", new RemoteCallDelegate(ManagerBlackboard.InvokeUserCode_CmdAddProductToSpawnList__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(ManagerBlackboard), "System.Void ManagerBlackboard::CmdSpawnBoxEmpty()", new RemoteCallDelegate(ManagerBlackboard.InvokeUserCode_CmdSpawnBoxEmpty), false);
		RemoteProcedureCalls.RegisterCommand(typeof(ManagerBlackboard), "System.Void ManagerBlackboard::CmdSpawnBoxFromPlayer(UnityEngine.Vector3,System.Int32,System.Int32,System.Single)", new RemoteCallDelegate(ManagerBlackboard.InvokeUserCode_CmdSpawnBoxFromPlayer__Vector3__Int32__Int32__Single), false);
		RemoteProcedureCalls.RegisterRpc(typeof(ManagerBlackboard), "System.Void ManagerBlackboard::RpcParentBoxOnClient(UnityEngine.GameObject)", new RemoteCallDelegate(ManagerBlackboard.InvokeUserCode_RpcParentBoxOnClient__GameObject));
	}

	// Token: 0x040002C0 RID: 704
	public GameObject UIShortcutPrefab;

	// Token: 0x040002C1 RID: 705
	public GameObject UIShopItemPrefab;

	// Token: 0x040002C2 RID: 706
	public GameObject UIShoppingListPrefab;

	// Token: 0x040002C3 RID: 707
	public GameObject shortcutsParent;

	// Token: 0x040002C4 RID: 708
	public GameObject shopItemsParent;

	// Token: 0x040002C5 RID: 709
	public GameObject shoppingListParent;

	// Token: 0x040002C6 RID: 710
	[Space(10f)]
	public GameObject boxPrefab;

	// Token: 0x040002C7 RID: 711
	public GameObject merchandiseSpawnpoint;

	// Token: 0x040002C8 RID: 712
	public GameObject emptyBoxSpawnpoint;

	// Token: 0x040002C9 RID: 713
	public Transform boxParent;

	// Token: 0x040002CA RID: 714
	[Space(10f)]
	public TextMeshProUGUI totalChargeOBJ;

	// Token: 0x040002CB RID: 715
	public float shoppingTotalCharge;

	// Token: 0x040002CC RID: 716
	private bool[] unlockedFranchises;

	// Token: 0x040002CD RID: 717
	private string[] tiers;

	// Token: 0x040002CE RID: 718
	private PlayMakerFSM fsm;

	// Token: 0x040002CF RID: 719
	private bool isSpawning;

	// Token: 0x040002D0 RID: 720
	public GameObject[] dummyArrayExistences;

	// Token: 0x040002D1 RID: 721
	public List<int> idsToSpawn = new List<int>();

	// Token: 0x040002D2 RID: 722
	public GameObject tabsOBJ;

	// Token: 0x040002D3 RID: 723
	public Sprite[] containerTypeSprites;

	// Token: 0x040002D4 RID: 724
	public TMP_InputField searchInputFieldOBJ;

	// Token: 0x040002D5 RID: 725
	private int oldGroupTier = -1;

	// Token: 0x040002D6 RID: 726
	private string oldInputString;

	// Token: 0x040002D7 RID: 727
	private int fixedCounter;
}

using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MaskEffect : MonoBehaviour
{
	// Token: 0x06000061 RID: 97 RVA: 0x00006896 File Offset: 0x00004A96
	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, this.mat);
	}

	// Token: 0x040000B1 RID: 177
	public Material mat;
}

using System;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200007A RID: 122
public class MasterLobbyData : MonoBehaviour
{
	// Token: 0x0600039D RID: 925 RVA: 0x0001A43C File Offset: 0x0001863C
	private void Start()
	{
		this.LobbyDataUpdated = Callback<LobbyDataUpdate_t>.Create(new Callback<LobbyDataUpdate_t>.DispatchDelegate(this.OnGetLobbyData));
	}

	// Token: 0x0600039E RID: 926 RVA: 0x0001A455 File Offset: 0x00018655
	public void CheckIfLobbyExists(string lobbyIDstr)
	{
		this.lobbyStr = lobbyIDstr;
		SteamMatchmaking.RequestLobbyData((CSteamID)ulong.Parse(lobbyIDstr));
	}

	// Token: 0x0600039F RID: 927 RVA: 0x0001A470 File Offset: 0x00018670
	private void OnGetLobbyData(LobbyDataUpdate_t result)
	{
		if (SceneManager.GetActiveScene().name != "A_Intro")
		{
			return;
		}
		this.GetLobbyResult(result);
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x0001A4A0 File Offset: 0x000186A0
	public void GetLobbyResult(LobbyDataUpdate_t result)
	{
		if (SceneManager.GetActiveScene().name != "A_Intro")
		{
			return;
		}
		bool value = false;
		if (result.m_bSuccess == 1 && result.m_ulSteamIDLobby.ToString() == this.lobbyStr && SteamMatchmaking.GetLobbyData((CSteamID)result.m_ulSteamIDLobby, "status") == "true")
		{
			value = true;
		}
		if (this.fsmCallbackOBJ)
		{
			PlayMakerFSM component = this.fsmCallbackOBJ.GetComponent<PlayMakerFSM>();
			component.FsmVariables.GetFsmBool("boolCallback").Value = value;
			component.SendEvent("Send_Data");
		}
	}

	// Token: 0x0400031A RID: 794
	public ulong CurrentLobbyID;

	// Token: 0x0400031B RID: 795
	public string lobbyStr;

	// Token: 0x0400031C RID: 796
	public bool isHost;

	// Token: 0x0400031D RID: 797
	protected Callback<LobbyDataUpdate_t> LobbyDataUpdated;

	// Token: 0x0400031E RID: 798
	public GameObject fsmCallbackOBJ;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using Mirror;
using Mirror.RemoteCalls;
using Rewired;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000070 RID: 112
public class MiniTransportBehaviour : NetworkBehaviour
{
	// Token: 0x0600032F RID: 815 RVA: 0x00018349 File Offset: 0x00016549
	private void Start()
	{
		this.thisIdentity = base.GetComponent<NetworkIdentity>();
		this.thisRigidbody = base.GetComponent<Rigidbody>();
		this.MainPlayer = ReInput.players.GetPlayer(0);
	}

	// Token: 0x06000330 RID: 816 RVA: 0x00018374 File Offset: 0x00016574
	public override void OnStartClient()
	{
		base.OnStartClient();
		this.BoxSpawner();
	}

	// Token: 0x06000331 RID: 817 RVA: 0x00018384 File Offset: 0x00016584
	[Command(requiresAuthority = false)]
	public void CmdRequestOwnership(GameObject requesterOBJ)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(requesterOBJ);
		base.SendCommandInternal("System.Void MiniTransportBehaviour::CmdRequestOwnership(UnityEngine.GameObject)", -1536541062, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000332 RID: 818 RVA: 0x000183C0 File Offset: 0x000165C0
	[ClientRpc]
	private void RpcRequestOwnership(GameObject requesterOBJ)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(requesterOBJ);
		this.SendRPCInternal("System.Void MiniTransportBehaviour::RpcRequestOwnership(UnityEngine.GameObject)", 1667153321, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000333 RID: 819 RVA: 0x000183FC File Offset: 0x000165FC
	[Command(requiresAuthority = false)]
	private void CmdRemoveOwnership()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void MiniTransportBehaviour::CmdRemoveOwnership()", 1364822105, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0001842C File Offset: 0x0001662C
	public void LocalRemoveOwnership()
	{
		FirstPersonController.Instance.inVehicle = false;
		FirstPersonController.Instance.vehicleSpot = null;
		if (FirstPersonController.Instance.footstepsFSM)
		{
			FirstPersonController.Instance.footstepsFSM.enabled = true;
		}
		if (FirstPersonController.Instance)
		{
			if (FirstPersonController.Instance.GetComponent<NetworkIdentity>().connectionToServer != null)
			{
				FirstPersonController.Instance.GetComponent<PlayerNetwork>().CmdChangeEquippedItem(0);
			}
			FirstPersonController.Instance.GetComponent<PlayerSyncCharacter>().NetworkinVehicle = false;
		}
		base.transform.Find("PlayerInteractDrive").gameObject.SetActive(true);
		base.transform.Find("ExtraColliders").gameObject.SetActive(true);
		base.transform.Find("PushEntities").gameObject.SetActive(false);
		if (Camera.main)
		{
			Camera.main.GetComponent<CustomCameraController>().inVehicle = false;
			Camera.main.GetComponent<CustomCameraController>().vehicleOBJ = null;
		}
		this.thisRigidbody.isKinematic = true;
	}

	// Token: 0x06000335 RID: 821 RVA: 0x00018536 File Offset: 0x00016736
	public void RemoveAuthorityFromNetworkManager()
	{
		this.CmdRemoveOwnership();
	}

	// Token: 0x06000336 RID: 822 RVA: 0x0001853E File Offset: 0x0001673E
	public void RemoveOwnershipFromTeleport()
	{
		if (this.hasAuthority)
		{
			this.LocalRemoveOwnership();
			this.CmdRemoveOwnership();
		}
	}

	// Token: 0x06000337 RID: 823 RVA: 0x00018554 File Offset: 0x00016754
	private void Update()
	{
		this.velocity = this.thisRigidbody.velocity.magnitude;
		float volume = Mathf.Clamp(this.velocity / 7f, 0f, 1f);
		this.engineAudio.volume = volume;
		if (!this.hasAuthority)
		{
			return;
		}
		base.transform.rotation = Quaternion.Euler(new Vector3(0f, base.transform.rotation.eulerAngles.y, 0f));
		if (!FsmVariables.GlobalVariables.GetFsmBool("InChat").Value && this.MainPlayer.GetButtonDown("Build"))
		{
			this.hasAuthority = false;
			this.LocalRemoveOwnership();
			this.CmdRemoveOwnership();
			return;
		}
		if (this.MainPlayer.GetButtonDown("Drop Item"))
		{
			this.CmdHorn();
		}
		if (this.MainPlayer.GetButtonDown("Jump") && !this.hopCooldown)
		{
			base.StartCoroutine(this.UnstuckingHop(true));
		}
		else if (this.MainPlayer.GetButtonDown("Secondary Action") && !this.hopCooldown)
		{
			base.StartCoroutine(this.UnstuckingHop(false));
		}
		float axis = this.MainPlayer.GetAxis("MoveH");
		float axis2 = this.MainPlayer.GetAxis("MoveV");
		if (this.velocity < 0.5f && axis2 > 0f)
		{
			this.addForceForwards = true;
		}
		else
		{
			this.addForceForwards = false;
		}
		if (this.velocity < 0.5f && axis2 < 0f)
		{
			this.addForceBackwards = true;
		}
		else
		{
			this.addForceBackwards = false;
		}
		float num = Vector3.Dot(base.transform.forward, this.thisRigidbody.velocity);
		float t = Mathf.InverseLerp(0f, this.maxSpeed, num);
		float num2 = Mathf.Lerp(this.motorTorque, 0f, t);
		float num3 = Mathf.Lerp(this.steeringRange, this.steeringRangeAtMaxSpeed, t);
		bool flag = Mathf.Sign(axis2) == Mathf.Sign(num);
		if ((this.velocity > 4.5f && axis2 > 0f) || (this.velocity > 2.5f && axis2 < 0f))
		{
			num2 = 0f;
		}
		foreach (WheelControl wheelControl in this.wheels)
		{
			if (wheelControl.steerable)
			{
				wheelControl.WheelCollider.steerAngle = axis * num3;
			}
			if (flag)
			{
				if (wheelControl.motorized)
				{
					wheelControl.WheelCollider.motorTorque = axis2 * num2;
				}
				wheelControl.WheelCollider.brakeTorque = 0f;
			}
			else
			{
				wheelControl.WheelCollider.brakeTorque = Mathf.Abs(axis2) * this.brakeTorque;
				wheelControl.WheelCollider.motorTorque = 0f;
			}
		}
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0001882C File Offset: 0x00016A2C
	private void FixedUpdate()
	{
		if (this.hasAuthority)
		{
			return;
		}
		if (this.addForceForwards)
		{
			this.thisRigidbody.AddForce(base.transform.forward * 500f);
		}
		if (this.addForceBackwards)
		{
			this.thisRigidbody.AddForce(-base.transform.forward * 500f);
		}
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00018898 File Offset: 0x00016A98
	public void CheckCollision(GameObject otherOBJ)
	{
		if (this.velocity < 1f)
		{
			return;
		}
		if (otherOBJ.name == "HitTrigger" && otherOBJ.transform.parent && otherOBJ.transform.parent.GetComponent<NPC_Info>())
		{
			this.CmdOnPeopleHit(otherOBJ.transform.position);
			base.transform.Find("Mesh").GetComponent<Animator>().Play("Vehicle_Shake");
			otherOBJ.transform.parent.GetComponent<NPC_Info>().CmdAnimationPlay(0);
			return;
		}
		if (otherOBJ.name == "HitTrigger" && otherOBJ.transform.parent && otherOBJ.transform.parent.transform.parent && otherOBJ.transform.parent.transform.parent.GetComponent<PlayerNetwork>())
		{
			this.CmdOnPeopleHit(otherOBJ.transform.position);
			base.transform.Find("Mesh").GetComponent<Animator>().Play("Vehicle_Shake");
			Vector3 vector = otherOBJ.transform.position - base.transform.position;
			otherOBJ.transform.parent.transform.parent.GetComponent<PlayerNetwork>().PushPlayer(vector.normalized);
			return;
		}
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00018A14 File Offset: 0x00016C14
	[Command]
	private void CmdOnPeopleHit(Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		base.SendCommandInternal("System.Void MiniTransportBehaviour::CmdOnPeopleHit(UnityEngine.Vector3)", 1858657720, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600033B RID: 827 RVA: 0x00018A50 File Offset: 0x00016C50
	[ClientRpc]
	private void RpcOnPeopleHit(Vector3 position)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		this.SendRPCInternal("System.Void MiniTransportBehaviour::RpcOnPeopleHit(UnityEngine.Vector3)", 1013729855, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600033C RID: 828 RVA: 0x00018A8C File Offset: 0x00016C8C
	private void OnCollisionEnter(Collision collision)
	{
		if (!this.hasAuthority)
		{
			return;
		}
		if (collision.contactCount > 0 && Vector3.Dot(collision.GetContact(0).normal, Vector3.up) < 0.8f)
		{
			float magnitude = collision.relativeVelocity.magnitude;
			if (magnitude > 1f)
			{
				base.transform.Find("Mesh").GetComponent<Animator>().Play("Vehicle_Shake");
				float audioVolume = Mathf.Clamp(magnitude / 7f, 0.1f, 1f);
				Vector3 point = collision.GetContact(0).point;
				this.CmdCollisionHit(point, audioVolume);
			}
		}
	}

	// Token: 0x0600033D RID: 829 RVA: 0x00018B38 File Offset: 0x00016D38
	[Command]
	private void CmdCollisionHit(Vector3 position, float audioVolume)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteFloat(audioVolume);
		base.SendCommandInternal("System.Void MiniTransportBehaviour::CmdCollisionHit(UnityEngine.Vector3,System.Single)", -299580789, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600033E RID: 830 RVA: 0x00018B7C File Offset: 0x00016D7C
	[ClientRpc]
	private void RpcCollisionHit(Vector3 position, float audioVolume, int audioIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteFloat(audioVolume);
		writer.WriteInt(audioIndex);
		this.SendRPCInternal("System.Void MiniTransportBehaviour::RpcCollisionHit(UnityEngine.Vector3,System.Single,System.Int32)", -2142235395, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600033F RID: 831 RVA: 0x00018BCC File Offset: 0x00016DCC
	[Command]
	private void CmdHorn()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void MiniTransportBehaviour::CmdHorn()", -1465750109, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000340 RID: 832 RVA: 0x00018BFC File Offset: 0x00016DFC
	[ClientRpc]
	private void RpcHorn()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void MiniTransportBehaviour::RpcHorn()", 385170484, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000341 RID: 833 RVA: 0x00018C2C File Offset: 0x00016E2C
	private IEnumerator UnstuckingHop(bool front)
	{
		this.hopCooldown = true;
		if (front)
		{
			Vector3 vector = base.transform.forward + new Vector3(0f, 2.5f, 0f);
			this.thisRigidbody.AddForce(vector.normalized * this.bonkForce, ForceMode.Impulse);
		}
		else
		{
			Vector3 vector2 = -base.transform.forward + new Vector3(0f, 2.5f, 0f);
			this.thisRigidbody.AddForce(vector2.normalized * this.bonkForce, ForceMode.Impulse);
		}
		yield return new WaitForSeconds(1f);
		this.hopCooldown = false;
		yield break;
	}

	// Token: 0x06000342 RID: 834 RVA: 0x00018C44 File Offset: 0x00016E44
	public void GetStorageBox(int boxIndex)
	{
		int num = boxIndex * 2;
		int num2 = this.productInfoArray[num];
		int num3 = this.productInfoArray[num + 1];
		PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();
		if (component.equippedItem == 1 && num3 >= 0 && num2 == component.extraParameter1 && component.extraParameter2 > 0 && num2 >= 0 && num2 < ProductListing.Instance.productPrefabs.Length)
		{
			int maxItemsPerBox = ProductListing.Instance.productPrefabs[num2].GetComponent<Data_Product>().maxItemsPerBox;
			if (num3 == maxItemsPerBox)
			{
				GameCanvas.Instance.CreateCanvasNotification("message12");
				return;
			}
			if (num3 + component.extraParameter2 > maxItemsPerBox)
			{
				int num4 = maxItemsPerBox - num3;
				component.extraParameter2 -= num4;
				this.CmdUpdateArrayValuesStorage(num, component.extraParameter1, maxItemsPerBox);
				GameData.Instance.PlayPopSound();
				return;
			}
			this.CmdUpdateArrayValuesStorage(num, component.extraParameter1, num3 + component.extraParameter2);
			component.extraParameter2 = 0;
			GameData.Instance.PlayPopSound();
			return;
		}
		else if (num3 <= 0 && component.equippedItem == 1)
		{
			if (base.transform.Find("BoxContainer").gameObject.transform.GetChild(boxIndex).transform.childCount > 0)
			{
				return;
			}
			component.CmdChangeEquippedItem(0);
			this.CmdUpdateArrayValuesStorage(num, component.extraParameter1, component.extraParameter2);
			return;
		}
		else
		{
			if (num2 < 0 || num3 <= -1)
			{
				return;
			}
			if (component.equippedItem != 0)
			{
				GameCanvas.Instance.CreateCanvasNotification("message7");
				return;
			}
			component.CmdChangeEquippedItem(1);
			component.extraParameter1 = num2;
			component.extraParameter2 = num3;
			if (base.transform.Find("CanvasSigns"))
			{
				this.CmdUpdateArrayValuesStorage(num, num2, -1);
				return;
			}
			this.CmdUpdateArrayValuesStorage(num, -1, -1);
			return;
		}
	}

	// Token: 0x06000343 RID: 835 RVA: 0x00018E00 File Offset: 0x00017000
	public void ClearStorageBox(int boxIndex)
	{
		int num = boxIndex * 2;
		int num2 = this.productInfoArray[num];
		int num3 = this.productInfoArray[num + 1];
		PlayerNetwork component = FirstPersonController.Instance.GetComponent<PlayerNetwork>();
		if (component.equippedItem != 2)
		{
			return;
		}
		if (num2 >= 0 && num3 < 0)
		{
			component.transform.Find("ResetProductSound").GetComponent<AudioSource>().Play();
			this.CmdUpdateArrayValuesStorage(num, -1, -1);
		}
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00018E65 File Offset: 0x00017065
	public void EmployeeUpdateArrayValuesStorage(int index, int PID, int PNUMBER)
	{
		this.productInfoArray[index] = PID;
		this.productInfoArray[index + 1] = PNUMBER;
		this.RpcUpdateArrayValuesStorage(index, PID, PNUMBER);
	}

	// Token: 0x06000345 RID: 837 RVA: 0x00018E84 File Offset: 0x00017084
	[Command(requiresAuthority = false)]
	private void CmdUpdateArrayValuesStorage(int index, int PID, int PNUMBER)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteInt(PID);
		writer.WriteInt(PNUMBER);
		base.SendCommandInternal("System.Void MiniTransportBehaviour::CmdUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", -1448121176, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000346 RID: 838 RVA: 0x00018ED4 File Offset: 0x000170D4
	[ClientRpc]
	private void RpcUpdateArrayValuesStorage(int index, int PID, int PNUMBER)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		writer.WriteInt(PID);
		writer.WriteInt(PNUMBER);
		this.SendRPCInternal("System.Void MiniTransportBehaviour::RpcUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", -827169613, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00018F24 File Offset: 0x00017124
	private void BoxSpawner()
	{
		GameObject gameObject = base.transform.Find("BoxContainer").gameObject;
		GameObject gameObject2 = null;
		if (base.transform.Find("CanvasSigns"))
		{
			gameObject2 = base.transform.Find("CanvasSigns").gameObject;
		}
		int childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			int num = this.productInfoArray[i * 2];
			int num2 = this.productInfoArray[i * 2 + 1];
			Transform transform = null;
			if (gameObject2)
			{
				transform = gameObject2.transform.GetChild(i);
			}
			bool flag = gameObject.transform.GetChild(i).childCount > 0;
			if (num2 <= -1)
			{
				if (flag)
				{
					Object.Destroy(gameObject.transform.GetChild(i).transform.GetChild(0).gameObject);
					if (num >= 0 && transform)
					{
						transform.gameObject.SetActive(true);
						transform.GetComponent<Image>().sprite = ProductListing.Instance.productSprites[num];
					}
				}
				else if (num >= 0 && transform)
				{
					transform.gameObject.SetActive(true);
					transform.GetComponent<Image>().sprite = ProductListing.Instance.productSprites[num];
				}
				else if (num < 0 && transform && gameObject2.activeSelf)
				{
					transform.gameObject.SetActive(false);
				}
			}
			else if (num >= 0 && !flag)
			{
				if (transform)
				{
					transform.gameObject.SetActive(false);
				}
				GameObject gameObject3 = Object.Instantiate<GameObject>(this.storageBoxPrefab, gameObject.transform.GetChild(i));
				gameObject3.transform.localPosition = Vector3.zero;
				ProductListing.Instance.SetBoxColor(gameObject3, num);
				gameObject3.transform.Find("ProductSprite").GetComponent<SpriteRenderer>().sprite = ProductListing.Instance.productSprites[num];
				gameObject3.transform.Find("ProductQuantity").GetComponent<TextMeshPro>().text = "x" + num2.ToString();
			}
			else if (num >= 0 && flag)
			{
				gameObject.transform.GetChild(i).transform.GetChild(0).transform.Find("ProductQuantity").GetComponent<TextMeshPro>().text = "x" + num2.ToString();
			}
		}
	}

	// Token: 0x06000348 RID: 840 RVA: 0x000191B4 File Offset: 0x000173B4
	private void OnDestroy()
	{
		if (this.hasAuthority)
		{
			base.StopAllCoroutines();
			this.LocalRemoveOwnership();
		}
	}

	// Token: 0x0600034A RID: 842 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x0600034B RID: 843 RVA: 0x00019224 File Offset: 0x00017424
	// (set) Token: 0x0600034C RID: 844 RVA: 0x00019237 File Offset: 0x00017437
	public int[] NetworkproductInfoArray
	{
		get
		{
			return this.productInfoArray;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int[]>(value, ref this.productInfoArray, 1UL, null);
		}
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x0600034D RID: 845 RVA: 0x00019254 File Offset: 0x00017454
	// (set) Token: 0x0600034E RID: 846 RVA: 0x00019267 File Offset: 0x00017467
	public bool NetworkhasDriver
	{
		get
		{
			return this.hasDriver;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.hasDriver, 2UL, null);
		}
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00019281 File Offset: 0x00017481
	protected void UserCode_CmdRequestOwnership__GameObject(GameObject requesterOBJ)
	{
		if (this.thisIdentity.connectionToClient != null)
		{
			return;
		}
		this.currentPlayerOBJ = requesterOBJ;
		this.NetworkhasDriver = true;
		this.thisIdentity.AssignClientAuthority(requesterOBJ.GetComponent<NetworkIdentity>().connectionToClient);
		this.RpcRequestOwnership(requesterOBJ);
	}

	// Token: 0x06000350 RID: 848 RVA: 0x000192BD File Offset: 0x000174BD
	protected static void InvokeUserCode_CmdRequestOwnership__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestOwnership called on client.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_CmdRequestOwnership__GameObject(reader.ReadGameObject());
	}

	// Token: 0x06000351 RID: 849 RVA: 0x000192E8 File Offset: 0x000174E8
	protected void UserCode_RpcRequestOwnership__GameObject(GameObject requesterOBJ)
	{
		if (requesterOBJ.name == "LocalGamePlayer")
		{
			this.hasAuthority = true;
			FirstPersonController.Instance.inVehicle = true;
			FirstPersonController.Instance.vehicleSpot = base.transform.Find("PlayerSpot").gameObject;
			FirstPersonController.Instance.footstepsFSM.enabled = false;
			FirstPersonController.Instance.GetComponent<PlayerNetwork>().CmdChangeEquippedItem(4);
			FirstPersonController.Instance.GetComponent<PlayerSyncCharacter>().NetworkinVehicle = true;
			base.transform.Find("PlayerInteractDrive").gameObject.SetActive(false);
			base.transform.Find("ExtraColliders").gameObject.SetActive(false);
			base.transform.Find("PushEntities").gameObject.SetActive(true);
			Camera.main.GetComponent<CustomCameraController>().inVehicle = true;
			Camera.main.GetComponent<CustomCameraController>().vehicleOBJ = base.transform;
			this.thisRigidbody.isKinematic = false;
			return;
		}
		this.hasAuthority = false;
	}

	// Token: 0x06000352 RID: 850 RVA: 0x000193F5 File Offset: 0x000175F5
	protected static void InvokeUserCode_RpcRequestOwnership__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRequestOwnership called on server.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_RpcRequestOwnership__GameObject(reader.ReadGameObject());
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0001941E File Offset: 0x0001761E
	protected void UserCode_CmdRemoveOwnership()
	{
		this.thisIdentity.RemoveClientAuthority();
		this.currentPlayerOBJ = null;
		this.NetworkhasDriver = false;
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00019439 File Offset: 0x00017639
	protected static void InvokeUserCode_CmdRemoveOwnership(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRemoveOwnership called on client.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_CmdRemoveOwnership();
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0001945C File Offset: 0x0001765C
	protected void UserCode_CmdOnPeopleHit__Vector3(Vector3 position)
	{
		this.RpcOnPeopleHit(position);
	}

	// Token: 0x06000356 RID: 854 RVA: 0x00019465 File Offset: 0x00017665
	protected static void InvokeUserCode_CmdOnPeopleHit__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdOnPeopleHit called on client.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_CmdOnPeopleHit__Vector3(reader.ReadVector3());
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0001948E File Offset: 0x0001768E
	protected void UserCode_RpcOnPeopleHit__Vector3(Vector3 position)
	{
		this.peopleHitAudio.clip = this.peopleHitAudioArray[Random.Range(0, this.peopleHitAudioArray.Length)];
		this.peopleHitAudio.transform.position = position;
		this.peopleHitAudio.Play();
	}

	// Token: 0x06000358 RID: 856 RVA: 0x000194CC File Offset: 0x000176CC
	protected static void InvokeUserCode_RpcOnPeopleHit__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnPeopleHit called on server.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_RpcOnPeopleHit__Vector3(reader.ReadVector3());
	}

	// Token: 0x06000359 RID: 857 RVA: 0x000194F8 File Offset: 0x000176F8
	protected void UserCode_CmdCollisionHit__Vector3__Single(Vector3 position, float audioVolume)
	{
		int audioIndex = Random.Range(0, this.hitAudioArray.Length);
		this.RpcCollisionHit(position, audioVolume, audioIndex);
	}

	// Token: 0x0600035A RID: 858 RVA: 0x0001951D File Offset: 0x0001771D
	protected static void InvokeUserCode_CmdCollisionHit__Vector3__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCollisionHit called on client.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_CmdCollisionHit__Vector3__Single(reader.ReadVector3(), reader.ReadFloat());
	}

	// Token: 0x0600035B RID: 859 RVA: 0x0001954D File Offset: 0x0001774D
	protected void UserCode_RpcCollisionHit__Vector3__Single__Int32(Vector3 position, float audioVolume, int audioIndex)
	{
		this.hitAudio.clip = this.hitAudioArray[audioIndex];
		this.hitAudio.transform.position = position;
		this.hitAudio.volume = audioVolume;
		this.hitAudio.Play();
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0001958A File Offset: 0x0001778A
	protected static void InvokeUserCode_RpcCollisionHit__Vector3__Single__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcCollisionHit called on server.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_RpcCollisionHit__Vector3__Single__Int32(reader.ReadVector3(), reader.ReadFloat(), reader.ReadInt());
	}

	// Token: 0x0600035D RID: 861 RVA: 0x000195C0 File Offset: 0x000177C0
	protected void UserCode_CmdHorn()
	{
		this.RpcHorn();
	}

	// Token: 0x0600035E RID: 862 RVA: 0x000195C8 File Offset: 0x000177C8
	protected static void InvokeUserCode_CmdHorn(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdHorn called on client.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_CmdHorn();
	}

	// Token: 0x0600035F RID: 863 RVA: 0x000195EB File Offset: 0x000177EB
	protected void UserCode_RpcHorn()
	{
		this.honkAudio.Play();
	}

	// Token: 0x06000360 RID: 864 RVA: 0x000195F8 File Offset: 0x000177F8
	protected static void InvokeUserCode_RpcHorn(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHorn called on server.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_RpcHorn();
	}

	// Token: 0x06000361 RID: 865 RVA: 0x00018E65 File Offset: 0x00017065
	protected void UserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32(int index, int PID, int PNUMBER)
	{
		this.productInfoArray[index] = PID;
		this.productInfoArray[index + 1] = PNUMBER;
		this.RpcUpdateArrayValuesStorage(index, PID, PNUMBER);
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0001961B File Offset: 0x0001781B
	protected static void InvokeUserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateArrayValuesStorage called on client.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x06000363 RID: 867 RVA: 0x00019650 File Offset: 0x00017850
	protected void UserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32(int index, int PID, int PNUMBER)
	{
		if (!base.isServer)
		{
			this.productInfoArray[index] = PID;
			this.productInfoArray[index + 1] = PNUMBER;
		}
		this.BoxSpawner();
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00019674 File Offset: 0x00017874
	protected static void InvokeUserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateArrayValuesStorage called on server.");
			return;
		}
		((MiniTransportBehaviour)obj).UserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000196AC File Offset: 0x000178AC
	static MiniTransportBehaviour()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::CmdRequestOwnership(UnityEngine.GameObject)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_CmdRequestOwnership__GameObject), false);
		RemoteProcedureCalls.RegisterCommand(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::CmdRemoveOwnership()", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_CmdRemoveOwnership), false);
		RemoteProcedureCalls.RegisterCommand(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::CmdOnPeopleHit(UnityEngine.Vector3)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_CmdOnPeopleHit__Vector3), true);
		RemoteProcedureCalls.RegisterCommand(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::CmdCollisionHit(UnityEngine.Vector3,System.Single)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_CmdCollisionHit__Vector3__Single), true);
		RemoteProcedureCalls.RegisterCommand(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::CmdHorn()", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_CmdHorn), true);
		RemoteProcedureCalls.RegisterCommand(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::CmdUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_CmdUpdateArrayValuesStorage__Int32__Int32__Int32), false);
		RemoteProcedureCalls.RegisterRpc(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::RpcRequestOwnership(UnityEngine.GameObject)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_RpcRequestOwnership__GameObject));
		RemoteProcedureCalls.RegisterRpc(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::RpcOnPeopleHit(UnityEngine.Vector3)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_RpcOnPeopleHit__Vector3));
		RemoteProcedureCalls.RegisterRpc(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::RpcCollisionHit(UnityEngine.Vector3,System.Single,System.Int32)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_RpcCollisionHit__Vector3__Single__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::RpcHorn()", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_RpcHorn));
		RemoteProcedureCalls.RegisterRpc(typeof(MiniTransportBehaviour), "System.Void MiniTransportBehaviour::RpcUpdateArrayValuesStorage(System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(MiniTransportBehaviour.InvokeUserCode_RpcUpdateArrayValuesStorage__Int32__Int32__Int32));
	}

	// Token: 0x06000366 RID: 870 RVA: 0x00019820 File Offset: 0x00017A20
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			Mirror.GeneratedNetworkCode._Write_System.Int32[](writer, this.productInfoArray);
			writer.WriteBool(this.hasDriver);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.Int32[](writer, this.productInfoArray);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteBool(this.hasDriver);
		}
	}

	// Token: 0x06000367 RID: 871 RVA: 0x000198A8 File Offset: 0x00017AA8
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int[]>(ref this.productInfoArray, null, Mirror.GeneratedNetworkCode._Read_System.Int32[](reader));
			base.GeneratedSyncVarDeserialize<bool>(ref this.hasDriver, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int[]>(ref this.productInfoArray, null, Mirror.GeneratedNetworkCode._Read_System.Int32[](reader));
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.hasDriver, null, reader.ReadBool());
		}
	}

	// Token: 0x040002DE RID: 734
	[SyncVar]
	public int[] productInfoArray;

	// Token: 0x040002DF RID: 735
	[SyncVar]
	public bool hasDriver;

	// Token: 0x040002E0 RID: 736
	public bool hasAuthority;

	// Token: 0x040002E1 RID: 737
	public GameObject currentPlayerOBJ;

	// Token: 0x040002E2 RID: 738
	[Space(10f)]
	public AudioSource engineAudio;

	// Token: 0x040002E3 RID: 739
	public AudioSource honkAudio;

	// Token: 0x040002E4 RID: 740
	public AudioSource hitAudio;

	// Token: 0x040002E5 RID: 741
	public AudioSource peopleHitAudio;

	// Token: 0x040002E6 RID: 742
	public float velocity;

	// Token: 0x040002E7 RID: 743
	[Space(10f)]
	public float motorTorque = 2000f;

	// Token: 0x040002E8 RID: 744
	public float brakeTorque = 2000f;

	// Token: 0x040002E9 RID: 745
	public float maxSpeed = 20f;

	// Token: 0x040002EA RID: 746
	public float steeringRange = 30f;

	// Token: 0x040002EB RID: 747
	public float steeringRangeAtMaxSpeed = 10f;

	// Token: 0x040002EC RID: 748
	public float bonkForce = 50f;

	// Token: 0x040002ED RID: 749
	public WheelControl[] wheels;

	// Token: 0x040002EE RID: 750
	public AudioClip[] hitAudioArray;

	// Token: 0x040002EF RID: 751
	public AudioClip[] peopleHitAudioArray;

	// Token: 0x040002F0 RID: 752
	public GameObject storageBoxPrefab;

	// Token: 0x040002F1 RID: 753
	private NetworkIdentity thisIdentity;

	// Token: 0x040002F2 RID: 754
	private Rigidbody thisRigidbody;

	// Token: 0x040002F3 RID: 755
	private Player MainPlayer;

	// Token: 0x040002F4 RID: 756
	private bool hopCooldown;

	// Token: 0x040002F5 RID: 757
	private bool addForceForwards;

	// Token: 0x040002F6 RID: 758
	private bool addForceBackwards;
}

using System;
using UnityEngine;

// Token: 0x02000072 RID: 114
public class MiniTransportListener : MonoBehaviour
{
	// Token: 0x0600036E RID: 878 RVA: 0x0000465C File Offset: 0x0000285C
	private void Start()
	{
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0000465C File Offset: 0x0000285C
	private void Update()
	{
	}
}

using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLookAdvanced : MonoBehaviour
{
	// Token: 0x06000008 RID: 8 RVA: 0x0000232C File Offset: 0x0000052C
	private void Start()
	{
		this.rotationY = -base.transform.localEulerAngles.x;
		this.rotationX = base.transform.localEulerAngles.y;
		this.smoothRotationX = base.transform.localEulerAngles.y;
		this.smoothRotationY = -base.transform.localEulerAngles.x;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002394 File Offset: 0x00000594
	private void Update()
	{
		this.verticalAcceleration = 0f;
		if (Input.GetMouseButtonDown(1))
		{
			if (Cursor.lockState == CursorLockMode.Locked)
			{
				Cursor.lockState = CursorLockMode.None;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
			}
			Cursor.visible = !Cursor.visible;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			this.verticalAcceleration = 1f;
		}
		if (Input.GetKey(KeyCode.LeftShift))
		{
			this.verticalAcceleration = -1f;
		}
		if (Cursor.lockState != CursorLockMode.Locked)
		{
			return;
		}
		this.rotationX += Input.GetAxis("Mouse X") * this.sensitivityX;
		this.rotationY += Input.GetAxis("Mouse Y") * this.sensitivityY;
		this.rotationY = Mathf.Clamp(this.rotationY, this.minimumY, this.maximumY);
		this.smoothRotationX += (this.rotationX - this.smoothRotationX) * this.smoothSpeed * Time.smoothDeltaTime;
		this.smoothRotationY += (this.rotationY - this.smoothRotationY) * this.smoothSpeed * Time.smoothDeltaTime;
		base.transform.localEulerAngles = new Vector3(-this.smoothRotationY, this.smoothRotationX, 0f);
		Vector3 point = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		Vector3 a = base.transform.rotation * point;
		base.transform.position += a * this.Speed * Time.smoothDeltaTime;
		base.transform.position += new Vector3(0f, this.Speed / 2f * this.verticalAcceleration * Time.smoothDeltaTime, 0f);
		base.transform.position += base.transform.rotation * Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * 200f;
	}

	// Token: 0x04000010 RID: 16
	public float sensitivityX = 5f;

	// Token: 0x04000011 RID: 17
	public float sensitivityY = 5f;

	// Token: 0x04000012 RID: 18
	public float minimumX = -360f;

	// Token: 0x04000013 RID: 19
	public float maximumX = 360f;

	// Token: 0x04000014 RID: 20
	public float minimumY = -90f;

	// Token: 0x04000015 RID: 21
	public float maximumY = 90f;

	// Token: 0x04000016 RID: 22
	public float smoothSpeed = 20f;

	// Token: 0x04000017 RID: 23
	private float verticalAcceleration;

	// Token: 0x04000018 RID: 24
	private float rotationX;

	// Token: 0x04000019 RID: 25
	private float smoothRotationX;

	// Token: 0x0400001A RID: 26
	private float rotationY;

	// Token: 0x0400001B RID: 27
	private float smoothRotationY;

	// Token: 0x0400001C RID: 28
	private Vector3 vMousePos;

	// Token: 0x0400001D RID: 29
	public float Speed = 100f;
}

using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
[Serializable]
public class MovePath : MonoBehaviour
{
	// Token: 0x0600000E RID: 14 RVA: 0x000030B9 File Offset: 0x000012B9
	public void InitializeAnimation(bool overrideAnimation, float walk, float run)
	{
		this._overrideDefaultAnimationMultiplier = overrideAnimation;
		this._customWalkAnimationMultiplier = walk;
		this._customRunAnimationMultiplier = run;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000030D0 File Offset: 0x000012D0
	public void MyStart(int _w, int _i, string anim, bool _loop, bool _forward, float _walkSpeed, float _runSpeed)
	{
		this.forward = _forward;
		this.walkSpeed = _walkSpeed;
		this.runSpeed = _runSpeed;
		WalkPath component = this.walkPath.GetComponent<WalkPath>();
		this.w = _w;
		this.targetPointsTotal = component.getPointsTotal(0) - 2;
		this.loop = _loop;
		this.animName = anim;
		if (this.loop)
		{
			if (_i < this.targetPointsTotal && _i > 0)
			{
				if (this.forward)
				{
					this.targetPoint = _i + 1;
					this.finishPos = component.getNextPoint(this.w, _i + 1);
					return;
				}
				this.targetPoint = _i;
				this.finishPos = component.getNextPoint(this.w, _i);
				return;
			}
			else
			{
				if (this.forward)
				{
					this.targetPoint = 1;
					this.finishPos = component.getNextPoint(this.w, 1);
					return;
				}
				this.targetPoint = this.targetPointsTotal;
				this.finishPos = component.getNextPoint(this.w, this.targetPointsTotal);
				return;
			}
		}
		else
		{
			if (this.forward)
			{
				this.targetPoint = _i + 1;
				this.finishPos = component.getNextPoint(this.w, _i + 1);
				return;
			}
			this.targetPoint = _i;
			this.finishPos = component.getNextPoint(this.w, _i);
			return;
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x0000320C File Offset: 0x0000140C
	public void SetLookPosition()
	{
		Vector3 worldPosition = new Vector3(this.finishPos.x, base.transform.position.y, this.finishPos.z);
		base.transform.LookAt(worldPosition);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00003254 File Offset: 0x00001454
	private void Start()
	{
		Animator component = base.GetComponent<Animator>();
		component.CrossFade(this.animName, 0.1f, 0, Random.Range(0f, 1f));
		if (!(this.animName == "walk"))
		{
			if (this.animName == "run")
			{
				if (this._overrideDefaultAnimationMultiplier)
				{
					component.speed = this.runSpeed * this._customRunAnimationMultiplier;
					return;
				}
				component.speed = this.runSpeed / 3f;
			}
			return;
		}
		if (this._overrideDefaultAnimationMultiplier)
		{
			component.speed = this.walkSpeed * this._customWalkAnimationMultiplier;
			return;
		}
		component.speed = this.walkSpeed * 1.2f;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x0000330C File Offset: 0x0000150C
	private void Update()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position + new Vector3(0f, 2f, 0f), -base.transform.up, out raycastHit))
		{
			this.finishPos.y = raycastHit.point.y;
			base.transform.position = new Vector3(base.transform.position.x, raycastHit.point.y, base.transform.position.z);
		}
		Vector3 vector = new Vector3(this.finishPos.x + this.randXFinish, this.finishPos.y, this.finishPos.z + this.randZFinish);
		Vector3 nextPoint = new Vector3(vector.x, base.transform.position.y, vector.z);
		WalkPath component = this.walkPath.GetComponent<WalkPath>();
		float num = Vector3.Distance(Vector3.ProjectOnPlane(base.transform.position, Vector3.up), Vector3.ProjectOnPlane(vector, Vector3.up));
		if (num < 0.2f && this.animName == "walk" && (this.loop || (!this.loop && this.targetPoint > 0 && this.targetPoint < this.targetPointsTotal)))
		{
			if (this.forward)
			{
				if (this.targetPoint < this.targetPointsTotal)
				{
					nextPoint = component.getNextPoint(this.w, this.targetPoint + 1);
				}
				else
				{
					nextPoint = component.getNextPoint(this.w, 0);
				}
				nextPoint.y = base.transform.position.y;
			}
			else
			{
				if (this.targetPoint > 0)
				{
					nextPoint = component.getNextPoint(this.w, this.targetPoint - 1);
				}
				else
				{
					nextPoint = component.getNextPoint(this.w, this.targetPointsTotal);
				}
				nextPoint.y = base.transform.position.y;
			}
		}
		if (num < 0.5f && this.animName == "run" && (this.loop || (!this.loop && this.targetPoint > 0 && this.targetPoint < this.targetPointsTotal)))
		{
			if (this.forward)
			{
				if (this.targetPoint < this.targetPointsTotal)
				{
					nextPoint = component.getNextPoint(this.w, this.targetPoint + 1);
				}
				else
				{
					nextPoint = component.getNextPoint(this.w, 0);
				}
				nextPoint.y = base.transform.position.y;
			}
			else
			{
				if (this.targetPoint > 0)
				{
					nextPoint = component.getNextPoint(this.w, this.targetPoint - 1);
				}
				else
				{
					nextPoint = component.getNextPoint(this.w, this.targetPointsTotal);
				}
				nextPoint.y = base.transform.position.y;
			}
		}
		Vector3 vector2 = nextPoint - base.transform.position;
		if (vector2 != Vector3.zero)
		{
			Vector3 vector3 = Vector3.zero;
			vector3 = Vector3.RotateTowards(base.transform.forward, vector2, 2f * Time.deltaTime, 0f);
			base.transform.rotation = Quaternion.LookRotation(vector3);
		}
		if (num > 1f)
		{
			if (Time.deltaTime > 0f)
			{
				base.transform.position = Vector3.MoveTowards(base.transform.position, this.finishPos, Time.deltaTime * 1f * ((this.animName == "walk") ? this.walkSpeed : this.runSpeed));
				return;
			}
		}
		else if (num <= 1f && this.forward)
		{
			if (this.targetPoint != this.targetPointsTotal)
			{
				this.targetPoint++;
				this.finishPos = component.getNextPoint(this.w, this.targetPoint);
				return;
			}
			if (this.targetPoint == this.targetPointsTotal)
			{
				if (this.loop)
				{
					this.finishPos = component.getStartPoint(this.w);
					this.targetPoint = 0;
					return;
				}
				component.SpawnOnePeople(this.w, this.forward, this.walkSpeed, this.runSpeed);
				Object.Destroy(base.gameObject);
				return;
			}
		}
		else if (num <= 1f && !this.forward)
		{
			if (this.targetPoint > 0)
			{
				this.targetPoint--;
				this.finishPos = component.getNextPoint(this.w, this.targetPoint);
				return;
			}
			if (this.targetPoint == 0)
			{
				if (this.loop)
				{
					this.finishPos = component.getNextPoint(this.w, this.targetPointsTotal);
					this.targetPoint = this.targetPointsTotal;
					return;
				}
				component.SpawnOnePeople(this.w, this.forward, this.walkSpeed, this.runSpeed);
				Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04000027 RID: 39
	[SerializeField]
	public Vector3 startPos;

	// Token: 0x04000028 RID: 40
	[SerializeField]
	public Vector3 finishPos;

	// Token: 0x04000029 RID: 41
	[SerializeField]
	public int w;

	// Token: 0x0400002A RID: 42
	[SerializeField]
	public int targetPoint;

	// Token: 0x0400002B RID: 43
	[SerializeField]
	public int targetPointsTotal;

	// Token: 0x0400002C RID: 44
	[SerializeField]
	public string animName;

	// Token: 0x0400002D RID: 45
	[SerializeField]
	public float walkSpeed;

	// Token: 0x0400002E RID: 46
	[SerializeField]
	public float runSpeed;

	// Token: 0x0400002F RID: 47
	[SerializeField]
	public bool loop;

	// Token: 0x04000030 RID: 48
	[SerializeField]
	public bool forward;

	// Token: 0x04000031 RID: 49
	[SerializeField]
	public GameObject walkPath;

	// Token: 0x04000032 RID: 50
	[HideInInspector]
	public float randXFinish;

	// Token: 0x04000033 RID: 51
	[HideInInspector]
	public float randZFinish;

	// Token: 0x04000034 RID: 52
	[SerializeField]
	[Tooltip("Set your animation speed / Установить свою скорость анимации?")]
	private bool _overrideDefaultAnimationMultiplier;

	// Token: 0x04000035 RID: 53
	[SerializeField]
	[Tooltip("Speed animation walking / Скорость анимации ходьбы")]
	private float _customWalkAnimationMultiplier = 1f;

	// Token: 0x04000036 RID: 54
	[SerializeField]
	[Tooltip("Running animation speed / Скорость анимации бега")]
	private float _customRunAnimationMultiplier = 1f;
}

using System;
using System.Collections;
using HutongGames.PlayMaker;
using Mirror;
using StarterAssets;
using TMPro;
using UnityEngine;

// Token: 0x0200007B RID: 123
public class MultiplayerInitialization : NetworkBehaviour
{
	// Token: 0x060003A2 RID: 930 RVA: 0x0001A548 File Offset: 0x00018748
	private void Start()
	{
		if (base.isLocalPlayer)
		{
			this.EnableLocalBehaviours();
		}
		else
		{
			this.capsuleCollider = base.GetComponent<CapsuleCollider>();
			this.capsuleCollider.enabled = true;
			base.transform.Find("OtherPlayerBehaviours").gameObject.SetActive(true);
			base.StartCoroutine(this.SetNameCoroutine());
		}
		if (base.isServer || base.isLocalPlayer)
		{
			base.GetComponent<PlayerPermissions>().enabled = true;
		}
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0001A5C4 File Offset: 0x000187C4
	public void EnableLocalBehaviours()
	{
		this.IsLocalPlayer = true;
		base.GetComponent<CharacterController>().enabled = true;
		base.GetComponent<FirstPersonController>().enabled = true;
		base.GetComponent<FirstPersonTransform>().enabled = true;
		base.GetComponent<PlayerCrouch>().enabled = true;
		base.transform.Find("ExtraLocalBehaviours").gameObject.SetActive(true);
		this.masterPlayerOBJ = FsmVariables.GlobalVariables.FindFsmGameObject("MasterPlayerOBJ");
		this.masterPlayerOBJ.Value = base.transform.gameObject;
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x0001A64E File Offset: 0x0001884E
	private IEnumerator SetNameCoroutine()
	{
		PlayerObjectController pController = base.GetComponent<PlayerObjectController>();
		string playerName = "";
		while (playerName == "")
		{
			playerName = pController.PlayerName;
			yield return null;
		}
		base.transform.Find("PlayerCanvas").gameObject.SetActive(true);
		base.transform.Find("PlayerCanvas/PlayerName").GetComponent<TextMeshProUGUI>().text = playerName;
		base.transform.Find("PlayerCanvas/PlayerName").GetComponent<TextMeshProUGUI>().isOverlay = true;
		yield return null;
		if (base.isServer && LobbyController.Instance)
		{
			PlayMakerFSM component = LobbyController.Instance.ChatContainerOBJ.GetComponent<PlayMakerFSM>();
			component.FsmVariables.GetFsmString("Message").Value = LocalizationManager.instance.GetLocalizationString("nplayer") + playerName;
			component.SendEvent("Send_Data");
		}
		yield break;
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x0400031F RID: 799
	private FsmGameObject masterPlayerOBJ;

	// Token: 0x04000320 RID: 800
	private PlayerObjectController playerObjectController;

	// Token: 0x04000321 RID: 801
	private CapsuleCollider capsuleCollider;

	// Token: 0x04000322 RID: 802
	public bool IsLocalPlayer;
}

using System;
using System.Runtime.InteropServices;
using Dissonance.Integrations.MirrorIgnorance;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x0200008D RID: 141
public class NetworkGameBehaviors : NetworkBehaviour
{
	// Token: 0x060004A8 RID: 1192 RVA: 0x0001FF78 File Offset: 0x0001E178
	public override void OnStartClient()
	{
		if (this.voiceChatEnabled && !base.isServer)
		{
			this.CmdRefreshStatus();
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0001FF90 File Offset: 0x0001E190
	[Command(requiresAuthority = false)]
	public void CmdServerEnableVoiceChat()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void NetworkGameBehaviors::CmdServerEnableVoiceChat()", 618377256, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x0001FFC0 File Offset: 0x0001E1C0
	[Command(requiresAuthority = false)]
	private void CmdRefreshStatus()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void NetworkGameBehaviors::CmdRefreshStatus()", 297219801, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x0001FFF0 File Offset: 0x0001E1F0
	[ClientRpc]
	private void RpcEnableVoiceChat()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void NetworkGameBehaviors::RpcEnableVoiceChat()", -1595055040, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x00020020 File Offset: 0x0001E220
	private void MainBehaviour()
	{
		if (!this.createdVoiceChatMainOBJ)
		{
			this.createdVoiceChatMainOBJ = Object.Instantiate<GameObject>(this.voiceChatMainPrefab);
		}
		this.AddVoiceChatProximityComponents();
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x00020048 File Offset: 0x0001E248
	private void AddVoiceChatProximityComponents()
	{
		foreach (PlayerObjectController playerObjectController in this.networkManager.GamePlayers)
		{
			if (!playerObjectController.GetComponent<MirrorIgnorancePlayer>())
			{
				playerObjectController.gameObject.AddComponent<MirrorIgnorancePlayer>();
			}
		}
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x060004B0 RID: 1200 RVA: 0x000200B4 File Offset: 0x0001E2B4
	// (set) Token: 0x060004B1 RID: 1201 RVA: 0x000200C7 File Offset: 0x0001E2C7
	public bool NetworkvoiceChatEnabled
	{
		get
		{
			return this.voiceChatEnabled;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.voiceChatEnabled, 1UL, null);
		}
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x000200E1 File Offset: 0x0001E2E1
	protected void UserCode_CmdServerEnableVoiceChat()
	{
		if (!base.isServer || this.voiceChatEnabled)
		{
			return;
		}
		this.NetworkvoiceChatEnabled = true;
		this.RpcEnableVoiceChat();
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x00020101 File Offset: 0x0001E301
	protected static void InvokeUserCode_CmdServerEnableVoiceChat(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdServerEnableVoiceChat called on client.");
			return;
		}
		((NetworkGameBehaviors)obj).UserCode_CmdServerEnableVoiceChat();
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x00020124 File Offset: 0x0001E324
	protected void UserCode_CmdRefreshStatus()
	{
		this.RpcEnableVoiceChat();
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x0002012C File Offset: 0x0001E32C
	protected static void InvokeUserCode_CmdRefreshStatus(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRefreshStatus called on client.");
			return;
		}
		((NetworkGameBehaviors)obj).UserCode_CmdRefreshStatus();
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x0002014F File Offset: 0x0001E34F
	protected void UserCode_RpcEnableVoiceChat()
	{
		this.MainBehaviour();
	}

	// Token: 0x060004B7 RID: 1207 RVA: 0x00020157 File Offset: 0x0001E357
	protected static void InvokeUserCode_RpcEnableVoiceChat(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEnableVoiceChat called on server.");
			return;
		}
		((NetworkGameBehaviors)obj).UserCode_RpcEnableVoiceChat();
	}

	// Token: 0x060004B8 RID: 1208 RVA: 0x0002017C File Offset: 0x0001E37C
	static NetworkGameBehaviors()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkGameBehaviors), "System.Void NetworkGameBehaviors::CmdServerEnableVoiceChat()", new RemoteCallDelegate(NetworkGameBehaviors.InvokeUserCode_CmdServerEnableVoiceChat), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkGameBehaviors), "System.Void NetworkGameBehaviors::CmdRefreshStatus()", new RemoteCallDelegate(NetworkGameBehaviors.InvokeUserCode_CmdRefreshStatus), false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkGameBehaviors), "System.Void NetworkGameBehaviors::RpcEnableVoiceChat()", new RemoteCallDelegate(NetworkGameBehaviors.InvokeUserCode_RpcEnableVoiceChat));
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x000201EC File Offset: 0x0001E3EC
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(this.voiceChatEnabled);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteBool(this.voiceChatEnabled);
		}
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x00020244 File Offset: 0x0001E444
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.voiceChatEnabled, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.voiceChatEnabled, null, reader.ReadBool());
		}
	}

	// Token: 0x040003CC RID: 972
	[SyncVar]
	public bool voiceChatEnabled;

	// Token: 0x040003CD RID: 973
	[Space(10f)]
	public GameObject voiceChatMainPrefab;

	// Token: 0x040003CE RID: 974
	public CustomNetworkManager networkManager;

	// Token: 0x040003CF RID: 975
	private GameObject createdVoiceChatMainOBJ;
}

using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using HutongGames.PlayMaker;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x0200007D RID: 125
public class NetworkSpawner : NetworkBehaviour
{
	// Token: 0x060003AD RID: 941 RVA: 0x0001A7C7 File Offset: 0x000189C7
	public override void OnStartClient()
	{
		this.UpdateSupermarketName(this.SuperMarketName);
	}

	// Token: 0x060003AE RID: 942 RVA: 0x0001A7D8 File Offset: 0x000189D8
	[ClientRpc]
	public void RpcProductAnimation(int productID, Vector3 startPosition, Vector3 destination)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(productID);
		writer.WriteVector3(startPosition);
		writer.WriteVector3(destination);
		this.SendRPCInternal("System.Void NetworkSpawner::RpcProductAnimation(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", 1618108428, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003AF RID: 943 RVA: 0x0001A828 File Offset: 0x00018A28
	[Command(requiresAuthority = false)]
	public void CmdSpawn(int prefabID, Vector3 pos, Vector3 rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(prefabID);
		writer.WriteVector3(pos);
		writer.WriteVector3(rot);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdSpawn(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", -503450129, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x0001A878 File Offset: 0x00018A78
	[Command(requiresAuthority = false)]
	public void CmdSpawnProp(int prefabID, Vector3 pos, Vector3 rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(prefabID);
		writer.WriteVector3(pos);
		writer.WriteVector3(rot);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdSpawnProp(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", -1804378598, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x0001A8C8 File Offset: 0x00018AC8
	[Command(requiresAuthority = false)]
	public void CmdSpawnDecoration(int prefabID, Vector3 pos, Vector3 rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(prefabID);
		writer.WriteVector3(pos);
		writer.WriteVector3(rot);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdSpawnDecoration(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", -1893520475, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x0001A916 File Offset: 0x00018B16
	public void GetMoveData(GameObject OBJToMove, Vector3 pos, Vector3 rot)
	{
		if (OBJToMove.GetComponent<NetworkIdentity>() != null)
		{
			this.CmdObjectMove(OBJToMove, pos, Quaternion.Euler(rot));
		}
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x0001A934 File Offset: 0x00018B34
	[Command(requiresAuthority = false)]
	private void CmdObjectMove(GameObject objToMove, Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(objToMove);
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdObjectMove(UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion)", -1401052095, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x0001A984 File Offset: 0x00018B84
	[ClientRpc]
	private void RpcUpdateObjectOnClients(GameObject objToMove, Vector3 pos, Quaternion rot)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(objToMove);
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		this.SendRPCInternal("System.Void NetworkSpawner::RpcUpdateObjectOnClients(UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion)", -104213225, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0001A9D4 File Offset: 0x00018BD4
	[Command(requiresAuthority = false)]
	public void CmdSpawnBox(int boxID, Vector3 pos, int ProductID, int numberOfProducts)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(boxID);
		writer.WriteVector3(pos);
		writer.WriteInt(ProductID);
		writer.WriteInt(numberOfProducts);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdSpawnBox(System.Int32,UnityEngine.Vector3,System.Int32,System.Int32)", -1959037611, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0001AA2C File Offset: 0x00018C2C
	[Command(requiresAuthority = false)]
	public void CmdDestroyBox(GameObject BoxToDestroy)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteGameObject(BoxToDestroy);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdDestroyBox(UnityEngine.GameObject)", 571244344, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0001AA66 File Offset: 0x00018C66
	public void EmployeeDestroyBox(GameObject BoxToDestroy)
	{
		NetworkServer.Destroy(BoxToDestroy);
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x0001AA70 File Offset: 0x00018C70
	[Command(requiresAuthority = false)]
	public void CmdSetSupermarketText(string SuperMarketText)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(SuperMarketText);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdSetSupermarketText(System.String)", -727745423, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x0001AAAC File Offset: 0x00018CAC
	[ClientRpc]
	private void RpcUpdateSuperMarketName(string SuperMarketText)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(SuperMarketText);
		this.SendRPCInternal("System.Void NetworkSpawner::RpcUpdateSuperMarketName(System.String)", -700807513, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003BA RID: 954 RVA: 0x0001AAE8 File Offset: 0x00018CE8
	[Command(requiresAuthority = false)]
	public void CmdSetSupermarketColor(Color SMarketColor)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteColor(SMarketColor);
		base.SendCommandInternal("System.Void NetworkSpawner::CmdSetSupermarketColor(UnityEngine.Color)", -824406067, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003BB RID: 955 RVA: 0x0001AB24 File Offset: 0x00018D24
	[ClientRpc]
	private void RpcUpdateSuperMarketColor(Color SMarketColor)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteColor(SMarketColor);
		this.SendRPCInternal("System.Void NetworkSpawner::RpcUpdateSuperMarketColor(UnityEngine.Color)", -1299855253, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060003BC RID: 956 RVA: 0x0001AB60 File Offset: 0x00018D60
	private void UpdateSuperMarketColor(Color SMarketColor)
	{
		foreach (object obj in this.currentTextContainerOBJ.transform)
		{
			((Transform)obj).GetComponent<MeshRenderer>().material.SetColor("_BaseColor", SMarketColor);
		}
	}

	// Token: 0x060003BD RID: 957 RVA: 0x0001ABCC File Offset: 0x00018DCC
	private void UpdateSupermarketName(string SuperMarketText)
	{
		if (this.currentTextContainerOBJ)
		{
			Object.Destroy(this.currentTextContainerOBJ);
		}
		this.currentTextContainerOBJ = Object.Instantiate<GameObject>(this.containerPrefabOBJ, this.containerParentOBJ.transform);
		float num = 0f;
		float num2 = 0.11111111f;
		float num3 = 0f;
		bool flag = true;
		SuperMarketText = SuperMarketText.ToUpper();
		string text = SuperMarketText;
		for (int i = 0; i < text.Length; i++)
		{
			string a = text[i].ToString();
			for (int j = 0; j < this.lettersArray.Length; j++)
			{
				string b = this.lettersArray[j];
				if (a == b)
				{
					GameObject gameObject = this.lettersPrefabsArray[j];
					float x = gameObject.GetComponent<BoxCollider>().size.x;
					if (!flag)
					{
						num += (num3 / 2f + num2 + x / 2f) * 2.25f;
					}
					flag = false;
					GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject, this.currentTextContainerOBJ.transform);
					gameObject2.transform.localPosition = new Vector3(num, 0f, 0f);
					gameObject2.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
					gameObject2.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", this.SuperMarketColor);
					num3 = x;
					break;
				}
			}
		}
		this.currentTextContainerOBJ.transform.position -= new Vector3(num / 2f, 0f, 0f);
	}

	// Token: 0x060003BE RID: 958 RVA: 0x0001AD6C File Offset: 0x00018F6C
	public void HalloweenGhostSpawn()
	{
		if (!base.isServer)
		{
			return;
		}
		if (!this.ghostSpawned)
		{
			base.StartCoroutine(this.CreateGhosts());
		}
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0001AD8C File Offset: 0x00018F8C
	private IEnumerator CreateGhosts()
	{
		this.ghostSpawned = true;
		int maxGhosts = 1;
		if (NetworkServer.connections.Count > 1)
		{
			maxGhosts = Mathf.Clamp(GameData.Instance.gameDay / 7, 1, 6 + NetworkServer.connections.Count);
		}
		while (maxGhosts > 0 && GameData.Instance.timeOfDay > 18f)
		{
			int num = maxGhosts;
			maxGhosts = num - 1;
			yield return new WaitForSeconds(Random.Range(30f, 90f));
			Vector3 position = this.ghostsSpawnpoint.transform.GetChild(Random.Range(0, this.ghostsSpawnpoint.transform.childCount)).transform.position;
			GameObject gameObject = Object.Instantiate<GameObject>(this.ghostPrefabOBJ, position, Quaternion.identity);
			HalloweenGhost component = gameObject.GetComponent<HalloweenGhost>();
			component.NetworkghostColor = this.ghostsColors[Random.Range(0, this.ghostsColors.Length)];
			component.hits = Random.Range(3, 5);
			NetworkServer.Spawn(gameObject, null);
			yield return null;
		}
		this.ghostSpawned = false;
		yield return null;
		yield break;
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x0001AD9B File Offset: 0x00018F9B
	public override void OnStartServer()
	{
		base.StartCoroutine(this.LoadSpawnCoroutine());
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x0001ADAA File Offset: 0x00018FAA
	private IEnumerator LoadSpawnCoroutine()
	{
		string value = FsmVariables.GlobalVariables.GetFsmString("CurrentFilename").Value;
		string filepath = Application.persistentDataPath + "/" + value;
		ES3Settings settings2 = new ES3Settings(ES3.EncryptionType.AES, "g#asojrtg@omos)^yq");
		ES3.CacheFile(filepath, settings2);
		ES3Settings settings = new ES3Settings(filepath, new Enum[]
		{
			ES3.Location.Cache
		});
		CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
		if (cultureInfo.NumberFormat.NumberDecimalSeparator != ",")
		{
			cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
			Thread.CurrentThread.CurrentCulture = cultureInfo;
		}
		for (int i = 0; i < 5000; i++)
		{
			string key = "propdata" + i.ToString();
			string key2 = "propinfoproduct" + i.ToString();
			if (!ES3.KeyExists(key, filepath, settings))
			{
				break;
			}
			string[] array = ES3.Load<string>(key, filepath, settings).Split(char.Parse("|"), StringSplitOptions.None);
			int index = int.Parse(array[0]);
			int num = int.Parse(array[1]);
			float x = float.Parse(array[2]);
			float y = float.Parse(array[3]);
			float z = float.Parse(array[4]);
			float y2 = float.Parse(array[5]);
			GameObject gameObject = Object.Instantiate<GameObject>(this.buildables[num]);
			gameObject.transform.SetParent(this.levelPropsOBJ.transform.GetChild(index));
			gameObject.transform.position = new Vector3(x, y, z);
			gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, y2, 0f));
			int[] networkproductInfoArray = ES3.Load<int[]>(key2, filepath, settings);
			gameObject.GetComponent<Data_Container>().NetworkproductInfoArray = networkproductInfoArray;
			NetworkServer.Spawn(gameObject, null);
			gameObject.GetComponent<Data_Container>().ActivateShelvesFromLoad();
		}
		yield return null;
		for (int j = 0; j < 5000; j++)
		{
			string key3 = "decopropdata" + j.ToString();
			if (!ES3.KeyExists(key3, filepath, settings))
			{
				break;
			}
			string[] array2 = ES3.Load<string>(key3, filepath, settings).Split(char.Parse("|"), StringSplitOptions.None);
			int index2 = int.Parse(array2[0]);
			int num2 = int.Parse(array2[1]);
			float x2 = float.Parse(array2[2]);
			float y3 = float.Parse(array2[3]);
			float z2 = float.Parse(array2[4]);
			float y4 = float.Parse(array2[5]);
			GameObject gameObject2 = Object.Instantiate<GameObject>(this.decorationProps[num2]);
			gameObject2.transform.SetParent(this.levelPropsOBJ.transform.GetChild(index2));
			gameObject2.transform.position = new Vector3(x2, y3, z2);
			gameObject2.transform.rotation = Quaternion.Euler(new Vector3(0f, y4, 0f));
			if (num2 == 4)
			{
				string[] array3 = ES3.Load<string>("decopropdataextra" + j.ToString(), filepath, settings).Split(char.Parse("|"), StringSplitOptions.None);
				gameObject2.GetComponent<DecorationExtraData>().NetworkintValue = int.Parse(array3[0]);
				gameObject2.GetComponent<DecorationExtraData>().NetworkstringValue = array3[1];
			}
			NetworkServer.Spawn(gameObject2, null);
		}
		yield break;
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x0001ADB9 File Offset: 0x00018FB9
	public void SaveProps()
	{
		if (!this.isSaving)
		{
			base.StartCoroutine(this.SavePropsCoroutine());
		}
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x0001ADD0 File Offset: 0x00018FD0
	private IEnumerator SavePropsCoroutine()
	{
		this.isSaving = true;
		GameCanvas.Instance.transform.Find("SavingContainer").gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		int counter = 0;
		string value = FsmVariables.GlobalVariables.GetFsmString("CurrentFilename").Value;
		string filepath = Application.persistentDataPath + "/" + value;
		ES3Settings cacheSettings = new ES3Settings(ES3.EncryptionType.AES, "g#asojrtg@omos)^yq");
		ES3.CacheFile(filepath, cacheSettings);
		ES3Settings settings = new ES3Settings(filepath, new Enum[]
		{
			ES3.Location.Cache
		});
		CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
		if (cultureInfo.NumberFormat.NumberDecimalSeparator != ",")
		{
			cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
			Thread.CurrentThread.CurrentCulture = cultureInfo;
		}
		for (int i = 0; i < 4; i++)
		{
			GameObject gameObject = this.levelPropsOBJ.transform.GetChild(i).gameObject;
			if (gameObject.transform.childCount != 0)
			{
				for (int j = 0; j < gameObject.transform.childCount; j++)
				{
					GameObject gameObject2 = gameObject.transform.GetChild(j).gameObject;
					string[] array = new string[11];
					array[0] = i.ToString();
					array[1] = "|";
					array[2] = gameObject2.GetComponent<Data_Container>().containerID.ToString();
					array[3] = "|";
					int num = 4;
					Vector3 vector = gameObject2.transform.position;
					array[num] = vector.x.ToString();
					array[5] = "|";
					int num2 = 6;
					vector = gameObject2.transform.position;
					array[num2] = vector.y.ToString();
					array[7] = "|";
					int num3 = 8;
					vector = gameObject2.transform.position;
					array[num3] = vector.z.ToString();
					array[9] = "|";
					int num4 = 10;
					vector = gameObject2.transform.rotation.eulerAngles;
					array[num4] = vector.y.ToString();
					string value2 = string.Concat(array);
					ES3.Save<string>("propdata" + counter.ToString(), value2, filepath, settings);
					string key = "propinfoproduct" + counter.ToString();
					int[] productInfoArray = gameObject2.GetComponent<Data_Container>().productInfoArray;
					ES3.Save<int[]>(key, productInfoArray, filepath, settings);
					int num5 = counter;
					counter = num5 + 1;
				}
			}
		}
		yield return null;
		int num6 = counter;
		while ((float)num6 < float.PositiveInfinity)
		{
			string key2 = "propdata" + counter.ToString();
			if (!ES3.KeyExists(key2, filepath, settings))
			{
				break;
			}
			ES3.DeleteKey(key2, filepath, settings);
			num6++;
		}
		yield return null;
		counter = 0;
		int num7 = 0;
		GameObject parentOBJ2 = this.levelPropsOBJ.transform.GetChild(7).gameObject;
		int num8 = 0;
		while ((float)num8 < float.PositiveInfinity)
		{
			string key3 = "decopropdata" + num7.ToString();
			if (!ES3.KeyExists(key3, filepath, settings))
			{
				break;
			}
			ES3.DeleteKey(key3, filepath, settings);
			num7++;
			num8++;
		}
		yield return null;
		for (int k = 0; k < parentOBJ2.transform.childCount; k++)
		{
			GameObject gameObject3 = parentOBJ2.transform.GetChild(k).gameObject;
			string[] array2 = new string[10];
			array2[0] = "7|";
			array2[1] = gameObject3.GetComponent<BuildableInfo>().decorationID.ToString();
			array2[2] = "|";
			int num9 = 3;
			Vector3 vector = gameObject3.transform.position;
			array2[num9] = vector.x.ToString();
			array2[4] = "|";
			int num10 = 5;
			vector = gameObject3.transform.position;
			array2[num10] = vector.y.ToString();
			array2[6] = "|";
			int num11 = 7;
			vector = gameObject3.transform.position;
			array2[num11] = vector.z.ToString();
			array2[8] = "|";
			int num12 = 9;
			vector = gameObject3.transform.rotation.eulerAngles;
			array2[num12] = vector.y.ToString();
			string value3 = string.Concat(array2);
			ES3.Save<string>("decopropdata" + counter.ToString(), value3, filepath, settings);
			if (gameObject3.GetComponent<BuildableInfo>().decorationID == 4)
			{
				string key4 = "decopropdataextra" + counter.ToString();
				string value4 = gameObject3.GetComponent<DecorationExtraData>().intValue.ToString() + "|" + gameObject3.GetComponent<DecorationExtraData>().stringValue;
				ES3.Save<string>(key4, value4, filepath, settings);
			}
			int num5 = counter;
			counter = num5 + 1;
		}
		yield return null;
		ES3.StoreCachedFile(filepath, cacheSettings);
		yield return null;
		GameCanvas.Instance.transform.Find("SavingContainer").gameObject.SetActive(false);
		this.isSaving = false;
		yield break;
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x060003C6 RID: 966 RVA: 0x0001AF08 File Offset: 0x00019108
	// (set) Token: 0x060003C7 RID: 967 RVA: 0x0001AF1B File Offset: 0x0001911B
	public string NetworkSuperMarketName
	{
		get
		{
			return this.SuperMarketName;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<string>(value, ref this.SuperMarketName, 1UL, null);
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x060003C8 RID: 968 RVA: 0x0001AF38 File Offset: 0x00019138
	// (set) Token: 0x060003C9 RID: 969 RVA: 0x0001AF4B File Offset: 0x0001914B
	public Color NetworkSuperMarketColor
	{
		get
		{
			return this.SuperMarketColor;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<Color>(value, ref this.SuperMarketColor, 2UL, null);
		}
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0001AF65 File Offset: 0x00019165
	protected void UserCode_RpcProductAnimation__Int32__Vector3__Vector3(int productID, Vector3 startPosition, Vector3 destination)
	{
		Object.Instantiate<GameObject>(this.productAnimationPrefabOBJ, startPosition, Quaternion.identity).GetComponent<ProductAnimation>().ExecuteAnimation(productID, destination);
	}

	// Token: 0x060003CB RID: 971 RVA: 0x0001AF84 File Offset: 0x00019184
	protected static void InvokeUserCode_RpcProductAnimation__Int32__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcProductAnimation called on server.");
			return;
		}
		((NetworkSpawner)obj).UserCode_RpcProductAnimation__Int32__Vector3__Vector3(reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3());
	}

	// Token: 0x060003CC RID: 972 RVA: 0x0001AFBC File Offset: 0x000191BC
	protected void UserCode_CmdSpawn__Int32__Vector3__Vector3(int prefabID, Vector3 pos, Vector3 rot)
	{
		GameObject gameObject = this.buildables[prefabID];
		int cost = gameObject.GetComponent<Data_Container>().cost;
		int parentIndex = gameObject.GetComponent<Data_Container>().parentIndex;
		if (gameObject.GetComponent<Data_Container>())
		{
			parentIndex = gameObject.GetComponent<Data_Container>().parentIndex;
		}
		GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject, pos, Quaternion.Euler(rot));
		gameObject2.transform.SetParent(this.levelPropsOBJ.transform.GetChild(parentIndex));
		NetworkServer.Spawn(gameObject2, null);
		base.GetComponent<GameData>().CmdAlterFunds((float)(-(float)cost));
	}

	// Token: 0x060003CD RID: 973 RVA: 0x0001B040 File Offset: 0x00019240
	protected static void InvokeUserCode_CmdSpawn__Int32__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawn called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdSpawn__Int32__Vector3__Vector3(reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3());
	}

	// Token: 0x060003CE RID: 974 RVA: 0x0001B075 File Offset: 0x00019275
	protected void UserCode_CmdSpawnProp__Int32__Vector3__Vector3(int prefabID, Vector3 pos, Vector3 rot)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.props[prefabID], pos, Quaternion.Euler(rot));
		gameObject.transform.SetParent(this.levelPropsOBJ.transform.GetChild(5));
		NetworkServer.Spawn(gameObject, null);
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0001B0AD File Offset: 0x000192AD
	protected static void InvokeUserCode_CmdSpawnProp__Int32__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnProp called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdSpawnProp__Int32__Vector3__Vector3(reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3());
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x0001B0E2 File Offset: 0x000192E2
	protected void UserCode_CmdSpawnDecoration__Int32__Vector3__Vector3(int prefabID, Vector3 pos, Vector3 rot)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.decorationProps[prefabID], pos, Quaternion.Euler(rot));
		gameObject.transform.SetParent(this.levelPropsOBJ.transform.GetChild(7));
		NetworkServer.Spawn(gameObject, null);
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x0001B11A File Offset: 0x0001931A
	protected static void InvokeUserCode_CmdSpawnDecoration__Int32__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnDecoration called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdSpawnDecoration__Int32__Vector3__Vector3(reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3());
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x0001B14F File Offset: 0x0001934F
	protected void UserCode_CmdObjectMove__GameObject__Vector3__Quaternion(GameObject objToMove, Vector3 pos, Quaternion rot)
	{
		objToMove.transform.position = pos;
		objToMove.transform.rotation = rot;
		this.RpcUpdateObjectOnClients(objToMove, pos, rot);
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0001B172 File Offset: 0x00019372
	protected static void InvokeUserCode_CmdObjectMove__GameObject__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdObjectMove called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdObjectMove__GameObject__Vector3__Quaternion(reader.ReadGameObject(), reader.ReadVector3(), reader.ReadQuaternion());
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x0001B1A7 File Offset: 0x000193A7
	protected void UserCode_RpcUpdateObjectOnClients__GameObject__Vector3__Quaternion(GameObject objToMove, Vector3 pos, Quaternion rot)
	{
		objToMove.transform.position = pos;
		objToMove.transform.rotation = rot;
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x0001B1C1 File Offset: 0x000193C1
	protected static void InvokeUserCode_RpcUpdateObjectOnClients__GameObject__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateObjectOnClients called on server.");
			return;
		}
		((NetworkSpawner)obj).UserCode_RpcUpdateObjectOnClients__GameObject__Vector3__Quaternion(reader.ReadGameObject(), reader.ReadVector3(), reader.ReadQuaternion());
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x0000465C File Offset: 0x0000285C
	protected void UserCode_CmdSpawnBox__Int32__Vector3__Int32__Int32(int boxID, Vector3 pos, int ProductID, int numberOfProducts)
	{
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0001B1F6 File Offset: 0x000193F6
	protected static void InvokeUserCode_CmdSpawnBox__Int32__Vector3__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnBox called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdSpawnBox__Int32__Vector3__Int32__Int32(reader.ReadInt(), reader.ReadVector3(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0001AA66 File Offset: 0x00018C66
	protected void UserCode_CmdDestroyBox__GameObject(GameObject BoxToDestroy)
	{
		NetworkServer.Destroy(BoxToDestroy);
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0001B231 File Offset: 0x00019431
	protected static void InvokeUserCode_CmdDestroyBox__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdDestroyBox called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdDestroyBox__GameObject(reader.ReadGameObject());
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0001B25A File Offset: 0x0001945A
	protected void UserCode_CmdSetSupermarketText__String(string SuperMarketText)
	{
		this.NetworkSuperMarketName = SuperMarketText;
		this.RpcUpdateSuperMarketName(SuperMarketText);
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0001B26A File Offset: 0x0001946A
	protected static void InvokeUserCode_CmdSetSupermarketText__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetSupermarketText called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdSetSupermarketText__String(reader.ReadString());
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0001B293 File Offset: 0x00019493
	protected void UserCode_RpcUpdateSuperMarketName__String(string SuperMarketText)
	{
		this.UpdateSupermarketName(SuperMarketText);
	}

	// Token: 0x060003DD RID: 989 RVA: 0x0001B29C File Offset: 0x0001949C
	protected static void InvokeUserCode_RpcUpdateSuperMarketName__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateSuperMarketName called on server.");
			return;
		}
		((NetworkSpawner)obj).UserCode_RpcUpdateSuperMarketName__String(reader.ReadString());
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0001B2C5 File Offset: 0x000194C5
	protected void UserCode_CmdSetSupermarketColor__Color(Color SMarketColor)
	{
		this.NetworkSuperMarketColor = SMarketColor;
		this.RpcUpdateSuperMarketColor(SMarketColor);
	}

	// Token: 0x060003DF RID: 991 RVA: 0x0001B2D5 File Offset: 0x000194D5
	protected static void InvokeUserCode_CmdSetSupermarketColor__Color(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetSupermarketColor called on client.");
			return;
		}
		((NetworkSpawner)obj).UserCode_CmdSetSupermarketColor__Color(reader.ReadColor());
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0001B2FE File Offset: 0x000194FE
	protected void UserCode_RpcUpdateSuperMarketColor__Color(Color SMarketColor)
	{
		this.UpdateSuperMarketColor(SMarketColor);
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x0001B307 File Offset: 0x00019507
	protected static void InvokeUserCode_RpcUpdateSuperMarketColor__Color(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateSuperMarketColor called on server.");
			return;
		}
		((NetworkSpawner)obj).UserCode_RpcUpdateSuperMarketColor__Color(reader.ReadColor());
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0001B330 File Offset: 0x00019530
	static NetworkSpawner()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdSpawn(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdSpawn__Int32__Vector3__Vector3), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdSpawnProp(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdSpawnProp__Int32__Vector3__Vector3), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdSpawnDecoration(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdSpawnDecoration__Int32__Vector3__Vector3), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdObjectMove(UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdObjectMove__GameObject__Vector3__Quaternion), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdSpawnBox(System.Int32,UnityEngine.Vector3,System.Int32,System.Int32)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdSpawnBox__Int32__Vector3__Int32__Int32), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdDestroyBox(UnityEngine.GameObject)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdDestroyBox__GameObject), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdSetSupermarketText(System.String)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdSetSupermarketText__String), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkSpawner), "System.Void NetworkSpawner::CmdSetSupermarketColor(UnityEngine.Color)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_CmdSetSupermarketColor__Color), false);
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSpawner), "System.Void NetworkSpawner::RpcProductAnimation(System.Int32,UnityEngine.Vector3,UnityEngine.Vector3)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_RpcProductAnimation__Int32__Vector3__Vector3));
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSpawner), "System.Void NetworkSpawner::RpcUpdateObjectOnClients(UnityEngine.GameObject,UnityEngine.Vector3,UnityEngine.Quaternion)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_RpcUpdateObjectOnClients__GameObject__Vector3__Quaternion));
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSpawner), "System.Void NetworkSpawner::RpcUpdateSuperMarketName(System.String)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_RpcUpdateSuperMarketName__String));
		RemoteProcedureCalls.RegisterRpc(typeof(NetworkSpawner), "System.Void NetworkSpawner::RpcUpdateSuperMarketColor(UnityEngine.Color)", new RemoteCallDelegate(NetworkSpawner.InvokeUserCode_RpcUpdateSuperMarketColor__Color));
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0001B4C8 File Offset: 0x000196C8
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(this.SuperMarketName);
			writer.WriteColor(this.SuperMarketColor);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteString(this.SuperMarketName);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteColor(this.SuperMarketColor);
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0001B550 File Offset: 0x00019750
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<string>(ref this.SuperMarketName, null, reader.ReadString());
			base.GeneratedSyncVarDeserialize<Color>(ref this.SuperMarketColor, null, reader.ReadColor());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<string>(ref this.SuperMarketName, null, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<Color>(ref this.SuperMarketColor, null, reader.ReadColor());
		}
	}

	// Token: 0x04000328 RID: 808
	[SyncVar]
	public string SuperMarketName = "Supermarket";

	// Token: 0x04000329 RID: 809
	[SyncVar]
	public Color SuperMarketColor = new Color(155f, 255f, 11f);

	// Token: 0x0400032A RID: 810
	public GameObject levelPropsOBJ;

	// Token: 0x0400032B RID: 811
	public GameObject containerParentOBJ;

	// Token: 0x0400032C RID: 812
	public GameObject containerPrefabOBJ;

	// Token: 0x0400032D RID: 813
	private GameObject currentTextContainerOBJ;

	// Token: 0x0400032E RID: 814
	[Space(10f)]
	public GameObject[] buildables;

	// Token: 0x0400032F RID: 815
	public GameObject[] props;

	// Token: 0x04000330 RID: 816
	public GameObject[] decorationProps;

	// Token: 0x04000331 RID: 817
	[Space(10f)]
	private string[] lettersArray = new string[]
	{
		"A",
		"B",
		"C",
		"D",
		"E",
		"F",
		"G",
		"H",
		"I",
		"J",
		"K",
		"L",
		"M",
		"N",
		"O",
		"P",
		"Q",
		"R",
		"S",
		"T",
		"U",
		"V",
		"W",
		"X",
		"Y",
		"Z"
	};

	// Token: 0x04000332 RID: 818
	public GameObject[] lettersPrefabsArray;

	// Token: 0x04000333 RID: 819
	public GameObject[] boxesPrefabsArray;

	// Token: 0x04000334 RID: 820
	[Space(10f)]
	public GameObject productAnimationPrefabOBJ;

	// Token: 0x04000335 RID: 821
	[Space(10f)]
	public GameObject ghostsSpawnpoint;

	// Token: 0x04000336 RID: 822
	public GameObject ghostPrefabOBJ;

	// Token: 0x04000337 RID: 823
	public Color[] ghostsColors;

	// Token: 0x04000338 RID: 824
	private bool ghostSpawned;

	// Token: 0x04000339 RID: 825
	public bool isSaving;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class NewPath : MonoBehaviour
{
	// Token: 0x06000014 RID: 20 RVA: 0x00003843 File Offset: 0x00001A43
	public List<Vector3> PointsGet()
	{
		return this.points;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000384C File Offset: 0x00001A4C
	public void PointSet(int index, Vector3 pos)
	{
		this.points.Add(pos);
		if (this.par == null)
		{
			this.par = new GameObject();
			this.par.name = "New path points";
			this.par.transform.parent = base.gameObject.transform;
		}
		GameObject gameObject = Object.Instantiate<GameObject>(GameObject.Find("Population System").GetComponent<PopulationSystemManager>().pointPrefab, pos, Quaternion.identity);
		gameObject.name = "p" + index.ToString();
		gameObject.transform.parent = this.par.transform;
	}

	// Token: 0x04000037 RID: 55
	private List<Vector3> points = new List<Vector3>();

	// Token: 0x04000038 RID: 56
	public int pointLenght;

	// Token: 0x04000039 RID: 57
	public Vector3 mousePos;

	// Token: 0x0400003A RID: 58
	public string pathName;

	// Token: 0x0400003B RID: 59
	public bool errors;

	// Token: 0x0400003C RID: 60
	public bool exit;

	// Token: 0x0400003D RID: 61
	public GameObject par;

	// Token: 0x0400003E RID: 62
	[HideInInspector]
	[SerializeField]
	public PathType PathType;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

// Token: 0x0200008E RID: 142
public class NPC_Info : NetworkBehaviour
{
	// Token: 0x060004BB RID: 1211 RVA: 0x0002029F File Offset: 0x0001E49F
	public override void OnStartClient()
	{
		this.CreateNPCCharacter();
		base.StartCoroutine(this.AddHalloweenHead());
		if (!base.isServer && this.isCustomer)
		{
			this.ClientParentNPC();
		}
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x000202CA File Offset: 0x0001E4CA
	private IEnumerator AddHalloweenHead()
	{
		yield return new WaitForSeconds(2f);
		if (GameData.Instance.timeOfDay > 18.75f && this.characterOBJ && this.characterOBJ.transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Neck/Bip01 Head"))
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.halloweenHeadPrefabOBJ);
			gameObject.transform.SetParent(this.characterOBJ.transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Neck/Bip01 Head"));
			gameObject.transform.localPosition = new Vector3(0.075f, 0f, 0f);
			gameObject.transform.localRotation = Quaternion.Euler(new Vector3(270f, 90f, 0f));
		}
		yield break;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x000202DC File Offset: 0x0001E4DC
	private void CreateNPCCharacter()
	{
		GameObject original = NPC_Manager.Instance.NPCsArray[this.NPCID];
		if (this.isEmployee)
		{
			original = NPC_Manager.Instance.NPCsEmployeesArray[this.NPCID];
		}
		this.characterOBJ = Object.Instantiate<GameObject>(original);
		this.characterOBJ.transform.SetParent(base.transform);
		this.characterOBJ.transform.localPosition = Vector3.zero;
		this.characterOBJ.transform.localRotation = Quaternion.identity;
		this.npcAnimator = this.characterOBJ.GetComponent<Animator>();
		if (this.isEmployee)
		{
			this.rightHandOBJ = this.characterOBJ.transform.Find("IKOBJs/RightHandTarget");
			this.leftHandOBJ = this.characterOBJ.transform.Find("IKOBJs/LeftHandTarget");
			this.rightHandConstraint = this.characterOBJ.transform.Find("Rig/RigHandIK").GetComponent<TwoBoneIKConstraint>();
			this.leftHandConstraint = this.characterOBJ.transform.Find("Rig/LeftHandIK").GetComponent<TwoBoneIKConstraint>();
			this.employeeBroomOBJ = this.characterOBJ.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("BroomOBJ").Value;
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x00020418 File Offset: 0x0001E618
	private void ClientParentNPC()
	{
		if (NPC_Manager.Instance)
		{
			base.transform.SetParent(NPC_Manager.Instance.customersnpcParentOBJ.transform);
			return;
		}
		base.StartCoroutine(this.DelayedClientParentNPC());
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x0002044E File Offset: 0x0001E64E
	private IEnumerator DelayedClientParentNPC()
	{
		yield return new WaitForSeconds(2f);
		if (NPC_Manager.Instance)
		{
			base.transform.SetParent(NPC_Manager.Instance.customersnpcParentOBJ.transform);
		}
		yield break;
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x00020460 File Offset: 0x0001E660
	private void FixedUpdate()
	{
		if (this.npcAnimator)
		{
			this.npcAnimator.SetFloat("MoveFactor", base.GetComponent<NPC_Speed>().velocity);
		}
		if (this.isEmployee)
		{
			if (this.equippedItem > 0 && this.instantiatedOBJ)
			{
				if (!this.rightHandDestinationOBJ)
				{
					this.rightHandDestinationOBJ = this.instantiatedOBJ.transform.Find("RightHandIK");
					this.rightHandConstraint.weight = 1f;
				}
				if (!this.leftHandDestinationOBJ)
				{
					this.leftHandDestinationOBJ = this.instantiatedOBJ.transform.Find("LeftHandIK");
					this.leftHandConstraint.weight = 1f;
				}
				this.rightHandOBJ.position = this.rightHandDestinationOBJ.position;
				this.rightHandOBJ.rotation = this.rightHandDestinationOBJ.rotation;
				this.leftHandOBJ.position = this.leftHandDestinationOBJ.position;
				this.leftHandOBJ.rotation = this.leftHandDestinationOBJ.rotation;
				return;
			}
			if (this.rightHandConstraint && this.rightHandConstraint.weight == 1f)
			{
				this.rightHandConstraint.weight = 0f;
			}
			if (this.leftHandConstraint && this.leftHandConstraint.weight == 1f)
			{
				this.leftHandConstraint.weight = 0f;
			}
		}
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x000205E4 File Offset: 0x0001E7E4
	[Command(requiresAuthority = false)]
	public void CmdAnimationPlay(int animationIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(animationIndex);
		base.SendCommandInternal("System.Void NPC_Info::CmdAnimationPlay(System.Int32)", -403099646, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00020620 File Offset: 0x0001E820
	public void AuxiliarAnimationPlay(int animationIndex)
	{
		if (!this.beingPushed)
		{
			base.StartCoroutine(this.StopSpeed());
		}
		int num = (int)Mathf.Floor((float)this.thiefProductsNumber / 4f);
		num = Mathf.Clamp(num, 1, 5);
		if (this.isAThief && this.productsIDCarrying.Count > 0 && this.thiefProductsNumber > 0)
		{
			int num2 = 0;
			while (num2 < num + 1 && num2 < this.productsIDCarrying.Count)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.stolenProductPrefab, NPC_Manager.Instance.droppedProductsParentOBJ.transform);
				gameObject.transform.position = base.transform.position + new Vector3(Random.Range(-0.4f, 0.4f), 0f, Random.Range(-0.4f, 0.4f));
				gameObject.GetComponent<StolenProductSpawn>().NetworkproductID = this.productsIDCarrying[0];
				gameObject.GetComponent<StolenProductSpawn>().NetworkproductCarryingPrice = this.productsCarryingPrice[0] * 0.8f;
				NetworkServer.Spawn(gameObject, null);
				this.productsIDCarrying.RemoveAt(num2);
				this.productsCarryingPrice.RemoveAt(num2);
				num2++;
			}
		}
		if (this.isAThief && this.productsIDCarrying.Count == 0 && base.transform.Find("ThiefCanvas").gameObject && base.transform.Find("ThiefCanvas").gameObject.activeSelf)
		{
			this.RpcHideThief();
		}
		int num3 = Random.Range(0, 9);
		this.RpcAnimationPlay(animationIndex);
		this.RPCNotificationAboveHead("NPCmessagehit" + num3.ToString(), "");
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x000207DC File Offset: 0x0001E9DC
	[ClientRpc]
	public void RpcShowThief()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void NPC_Info::RpcShowThief()", -1373127503, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x0002080C File Offset: 0x0001EA0C
	[ClientRpc]
	public void RpcHideThief()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void NPC_Info::RpcHideThief()", -1402377378, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x0002083C File Offset: 0x0001EA3C
	[ClientRpc]
	public void RpcEmployeeHitThief()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void NPC_Info::RpcEmployeeHitThief()", 34869927, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x0002086C File Offset: 0x0001EA6C
	[ClientRpc]
	private void RpcAnimationPlay(int animationIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(animationIndex);
		this.SendRPCInternal("System.Void NPC_Info::RpcAnimationPlay(System.Int32)", 1467481995, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x000208A6 File Offset: 0x0001EAA6
	private IEnumerator StopSpeed()
	{
		float speedToRestore = base.GetComponent<NavMeshAgent>().speed;
		this.beingPushed = true;
		base.GetComponent<NavMeshAgent>().speed = 0f;
		yield return new WaitForSeconds(1.5f);
		base.GetComponent<NavMeshAgent>().speed = speedToRestore;
		this.beingPushed = false;
		yield break;
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x000208B5 File Offset: 0x0001EAB5
	public void CallPathing()
	{
		if (!this.chaserUpdatingPathing)
		{
			base.StartCoroutine(this.PathingCooldown());
		}
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x000208CC File Offset: 0x0001EACC
	private IEnumerator PathingCooldown()
	{
		this.chaserUpdatingPathing = true;
		NavMeshAgent component = base.GetComponent<NavMeshAgent>();
		if (!component.pathPending)
		{
			component.SetDestination(this.currentChasedThiefOBJ.transform.position);
		}
		yield return new WaitForSeconds(0.25f);
		this.chaserUpdatingPathing = false;
		yield break;
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x000208DC File Offset: 0x0001EADC
	[ClientRpc]
	public void RpcShowBroom(bool set)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(set);
		this.SendRPCInternal("System.Void NPC_Info::RpcShowBroom(System.Boolean)", 1757357061, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x00020916 File Offset: 0x0001EB16
	public void EquipNPCItem(int index)
	{
		this.equippedItem = index;
		this.RpcEquipNPCItem(index, this.boxProductID);
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x0002092C File Offset: 0x0001EB2C
	[ClientRpc]
	private void RpcEquipNPCItem(int equippedIndex, int productID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(equippedIndex);
		writer.WriteInt(productID);
		this.SendRPCInternal("System.Void NPC_Info::RpcEquipNPCItem(System.Int32,System.Int32)", -701976784, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x00020970 File Offset: 0x0001EB70
	public void PlaceProducts(GameObject checkoutOBJ)
	{
		base.StartCoroutine(this.PlaceProductsCoroutine(checkoutOBJ));
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x00020980 File Offset: 0x0001EB80
	private IEnumerator PlaceProductsCoroutine(GameObject checkoutOBJ)
	{
		while (this.productsIDCarrying.Count > 0)
		{
			yield return new WaitForSeconds(this.productItemPlaceWait);
			int num = this.productsIDCarrying[0];
			float networkproductCarryingPrice = this.productsCarryingPrice[0];
			this.productsIDCarrying.RemoveAt(0);
			this.productsCarryingPrice.RemoveAt(0);
			GameObject gameObject = Object.Instantiate<GameObject>(this.productCheckoutPrefab);
			ProductCheckoutSpawn component = gameObject.GetComponent<ProductCheckoutSpawn>();
			component.NetworkproductID = num;
			component.NetworkcheckoutOBJ = checkoutOBJ.transform.GetChild(this.currentCheckoutIndex).gameObject;
			component.NetworkNPCOBJ = base.gameObject;
			component.NetworkproductCarryingPrice = networkproductCarryingPrice;
			component.internalDataContainerListIndex = this.productsIDInCheckout.Count;
			this.productsIDInCheckout.Add(num);
			int num2 = 0;
			float num3 = 0f;
			float num4 = 0f;
			foreach (int num5 in this.productsIDInCheckout)
			{
				float x = ProductListing.Instance.productPrefabs[num5].GetComponent<BoxCollider>().size.x;
				if (this.productsIDInCheckout.Count == 1)
				{
					num3 = x / 2f;
					break;
				}
				num3 += x / 2f + num4 / 2f + 0.01f;
				if (num3 + x / 2f > 0.5f)
				{
					num2++;
					num3 = x / 2f;
					if (num2 > 6)
					{
						num2 = 0;
					}
				}
				num4 = x;
			}
			gameObject.transform.position = checkoutOBJ.transform.GetChild(this.currentCheckoutIndex).transform.Find("CheckoutItemPosition").transform.TransformPoint(new Vector3(num3, 0f, (float)num2 * 0.15f));
			gameObject.transform.rotation = checkoutOBJ.transform.GetChild(this.currentCheckoutIndex).rotation;
			checkoutOBJ.transform.GetChild(this.currentCheckoutIndex).GetComponent<Data_Container>().internalProductListForEmployees.Add(gameObject);
			NetworkServer.Spawn(gameObject, null);
		}
		yield return null;
		yield break;
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x00020996 File Offset: 0x0001EB96
	public void StartCustomerSelfCheckout(GameObject selfCheckoutOBJ)
	{
		base.StartCoroutine(this.CustomerSelfCheckout(selfCheckoutOBJ));
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x000209A6 File Offset: 0x0001EBA6
	private IEnumerator CustomerSelfCheckout(GameObject selfCheckoutOBJ)
	{
		Data_Container dContainer = selfCheckoutOBJ.GetComponent<Data_Container>();
		Transform bagsTransform = selfCheckoutOBJ.transform.Find("Bags");
		Vector3 originPosition = selfCheckoutOBJ.transform.Find("CheckoutItemPosition").transform.position;
		while (this.productsIDCarrying.Count > 0)
		{
			yield return new WaitForSeconds(Random.Range(1.1f, 2.25f));
			int productID = this.productsIDCarrying[0];
			float num = this.productsCarryingPrice[0];
			this.productsIDCarrying.RemoveAt(0);
			this.productsCarryingPrice.RemoveAt(0);
			this.selfCheckoutSum += num;
			dContainer.SelfCheckoutActivateBag();
			if (bagsTransform)
			{
				int index = 0;
				int num2 = 0;
				while (num2 < bagsTransform.childCount && bagsTransform.transform.GetChild(num2).gameObject.activeSelf)
				{
					index = num2;
					num2++;
				}
				Vector3 destination = bagsTransform.transform.GetChild(index).transform.position + new Vector3(0f, 0.3f, 0f);
				GameData.Instance.GetComponent<NetworkSpawner>().RpcProductAnimation(productID, originPosition, destination);
			}
		}
		yield return new WaitForSeconds(1.5f);
		dContainer.SelfCheckoutDeactivateBag();
		GameData.Instance.CmdAlterFunds(this.selfCheckoutSum);
		this.selfCheckoutSum = 0f;
		this.state = -1;
		this.StartWaitState(1f, 3);
		yield return null;
		yield break;
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x000209BC File Offset: 0x0001EBBC
	public void StartWaitState(float TimeToWait, int targetState)
	{
		base.StartCoroutine(this.WaitState(TimeToWait, targetState));
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x000209CD File Offset: 0x0001EBCD
	private IEnumerator WaitState(float TimeToWait, int targetState)
	{
		this.playingCoroutine = true;
		yield return new WaitForSeconds(TimeToWait);
		this.state = targetState;
		yield return null;
		this.playingCoroutine = false;
		yield break;
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x000209EA File Offset: 0x0001EBEA
	public void StopCoroutinesFromManager()
	{
		if (this.playingCoroutine)
		{
			base.StopAllCoroutines();
			this.playingCoroutine = false;
		}
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x00020A01 File Offset: 0x0001EC01
	public void StartPlayAnimationState(int targetState)
	{
		base.StartCoroutine(this.PlayAnimationState(targetState));
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x00020A11 File Offset: 0x0001EC11
	private IEnumerator PlayAnimationState(int targetState)
	{
		yield return new WaitForSeconds(1f);
		this.state = targetState;
		yield return null;
		yield break;
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x00020A27 File Offset: 0x0001EC27
	public void ComplainAboutFilth()
	{
		if (this.isAThief)
		{
			return;
		}
		GameData.Instance.complainedAboutFilth++;
		this.hasComplainedAboutFilth = true;
		this.RPCNotificationAboveHead("NPCmessage5", "");
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x00020A5C File Offset: 0x0001EC5C
	[ClientRpc]
	public void RPCNotificationAboveHead(string message1, string messageAddon)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(message1);
		writer.WriteString(messageAddon);
		this.SendRPCInternal("System.Void NPC_Info::RPCNotificationAboveHead(System.String,System.String)", -2110386630, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x00020AA0 File Offset: 0x0001ECA0
	public void ChangeEmployeeHat(int hatIndex)
	{
		this.RPCChangeEmployeeHat(hatIndex);
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x00020AAC File Offset: 0x0001ECAC
	[ClientRpc]
	public void RPCChangeEmployeeHat(int hatIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(hatIndex);
		this.SendRPCInternal("System.Void NPC_Info::RPCChangeEmployeeHat(System.Int32)", -942160518, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x00020AE8 File Offset: 0x0001ECE8
	private void OnDestroy()
	{
		if (base.isServer && this.isAThief && this.productsIDCarrying.Count > 0)
		{
			GameData.Instance.timesRobbed++;
			float num = 0f;
			foreach (float num2 in this.productsCarryingPrice)
			{
				num += num2;
			}
			GameData.Instance.moneyLostBecauseRobbing += num;
		}
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x060004DD RID: 1245 RVA: 0x00020BD8 File Offset: 0x0001EDD8
	// (set) Token: 0x060004DE RID: 1246 RVA: 0x00020BEB File Offset: 0x0001EDEB
	public int NetworkNPCID
	{
		get
		{
			return this.NPCID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.NPCID, 1UL, null);
		}
	}

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x060004DF RID: 1247 RVA: 0x00020C08 File Offset: 0x0001EE08
	// (set) Token: 0x060004E0 RID: 1248 RVA: 0x00020C1B File Offset: 0x0001EE1B
	public bool NetworkisEmployee
	{
		get
		{
			return this.isEmployee;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.isEmployee, 2UL, null);
		}
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x060004E1 RID: 1249 RVA: 0x00020C38 File Offset: 0x0001EE38
	// (set) Token: 0x060004E2 RID: 1250 RVA: 0x00020C4B File Offset: 0x0001EE4B
	public bool NetworkisCustomer
	{
		get
		{
			return this.isCustomer;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.isCustomer, 4UL, null);
		}
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x00020C65 File Offset: 0x0001EE65
	protected void UserCode_CmdAnimationPlay__Int32(int animationIndex)
	{
		this.AuxiliarAnimationPlay(animationIndex);
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00020C6E File Offset: 0x0001EE6E
	protected static void InvokeUserCode_CmdAnimationPlay__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAnimationPlay called on client.");
			return;
		}
		((NPC_Info)obj).UserCode_CmdAnimationPlay__Int32(reader.ReadInt());
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x00020C97 File Offset: 0x0001EE97
	protected void UserCode_RpcShowThief()
	{
		base.transform.Find("ThiefCanvas").gameObject.SetActive(true);
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x00020CB4 File Offset: 0x0001EEB4
	protected static void InvokeUserCode_RpcShowThief(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowThief called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RpcShowThief();
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00020CD7 File Offset: 0x0001EED7
	protected void UserCode_RpcHideThief()
	{
		base.transform.Find("ThiefCanvas").gameObject.SetActive(false);
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x00020CF4 File Offset: 0x0001EEF4
	protected static void InvokeUserCode_RpcHideThief(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcHideThief called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RpcHideThief();
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x00020D18 File Offset: 0x0001EF18
	protected void UserCode_RpcEmployeeHitThief()
	{
		if (this.npcAnimator)
		{
			this.npcAnimator.SetFloat("AnimationFloat", 1f);
			this.npcAnimator.Play("Animation");
			base.transform.Find("HitSound").GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x00020D71 File Offset: 0x0001EF71
	protected static void InvokeUserCode_RpcEmployeeHitThief(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEmployeeHitThief called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RpcEmployeeHitThief();
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00020D94 File Offset: 0x0001EF94
	protected void UserCode_RpcAnimationPlay__Int32(int animationIndex)
	{
		if (this.npcAnimator)
		{
			this.npcAnimator.SetFloat("AnimationFloat", (float)animationIndex);
			this.npcAnimator.Play("Animation");
			base.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x00020DD0 File Offset: 0x0001EFD0
	protected static void InvokeUserCode_RpcAnimationPlay__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAnimationPlay called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RpcAnimationPlay__Int32(reader.ReadInt());
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x00020DF9 File Offset: 0x0001EFF9
	protected void UserCode_RpcShowBroom__Boolean(bool set)
	{
		if (this.employeeBroomOBJ)
		{
			this.employeeBroomOBJ.SetActive(set);
		}
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x00020E14 File Offset: 0x0001F014
	protected static void InvokeUserCode_RpcShowBroom__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowBroom called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RpcShowBroom__Boolean(reader.ReadBool());
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x00020E40 File Offset: 0x0001F040
	protected void UserCode_RpcEquipNPCItem__Int32__Int32(int equippedIndex, int productID)
	{
		this.equippedItem = equippedIndex;
		if (equippedIndex != 0)
		{
			if (equippedIndex != 1)
			{
				return;
			}
			this.instantiatedOBJ = Object.Instantiate<GameObject>(this.dummyBoxPrefab);
			this.instantiatedOBJ.transform.parent = base.transform.Find("EquippedItem").transform;
			this.instantiatedOBJ.transform.localPosition = Vector3.zero;
			this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			this.instantiatedOBJ.transform.Find("Canvas").gameObject.SetActive(false);
			if (this.instantiatedOBJ.transform.Find("BoxMesh") && ProductListing.Instance)
			{
				this.instantiatedOBJ.transform.Find("BoxMesh").gameObject.SetActive(true);
				ProductListing.Instance.SetBoxColor(this.instantiatedOBJ, productID);
			}
		}
		else if (base.transform.Find("EquippedItem").transform.childCount > 0)
		{
			Object.Destroy(base.transform.Find("EquippedItem").transform.GetChild(0).gameObject);
			this.instantiatedOBJ = null;
			return;
		}
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x00020F91 File Offset: 0x0001F191
	protected static void InvokeUserCode_RpcEquipNPCItem__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcEquipNPCItem called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RpcEquipNPCItem__Int32__Int32(reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x00020FC0 File Offset: 0x0001F1C0
	protected void UserCode_RPCNotificationAboveHead__String__String(string message1, string messageAddon)
	{
		GameObject gameObject = Object.Instantiate<GameObject>(this.messagePrefab, base.transform.position + Vector3.up * 1.8f, Quaternion.identity);
		string text = LocalizationManager.instance.GetLocalizationString(message1);
		if (messageAddon != "")
		{
			text += LocalizationManager.instance.GetLocalizationString(messageAddon);
		}
		gameObject.GetComponent<TextMeshPro>().text = text;
		gameObject.SetActive(true);
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x00021039 File Offset: 0x0001F239
	protected static void InvokeUserCode_RPCNotificationAboveHead__String__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RPCNotificationAboveHead called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RPCNotificationAboveHead__String__String(reader.ReadString(), reader.ReadString());
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00021068 File Offset: 0x0001F268
	protected void UserCode_RPCChangeEmployeeHat__Int32(int hatIndex)
	{
		GameObject gameObject = null;
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			if (transform.GetComponent<Animator>())
			{
				gameObject = transform.gameObject;
				break;
			}
		}
		if (gameObject == null)
		{
			return;
		}
		if (this.employeeHatOBJ)
		{
			Object.Destroy(this.employeeHatOBJ);
		}
		if (hatIndex == 0 || !FirstPersonController.Instance)
		{
			return;
		}
		hatIndex = Mathf.Clamp(hatIndex, 0, FirstPersonController.Instance.GetComponent<PlayerNetwork>().hatsArray.Length - 1);
		GameObject value = gameObject.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("HatSpot").Value;
		this.employeeHatOBJ = Object.Instantiate<GameObject>(FirstPersonController.Instance.GetComponent<PlayerNetwork>().hatsArray[hatIndex], value.transform);
		this.employeeHatOBJ.transform.localPosition = this.employeeHatOBJ.GetComponent<HatInfo>().offset;
		this.employeeHatOBJ.transform.localRotation = Quaternion.Euler(this.employeeHatOBJ.GetComponent<HatInfo>().rotation);
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x000211A8 File Offset: 0x0001F3A8
	protected static void InvokeUserCode_RPCChangeEmployeeHat__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RPCChangeEmployeeHat called on server.");
			return;
		}
		((NPC_Info)obj).UserCode_RPCChangeEmployeeHat__Int32(reader.ReadInt());
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x000211D4 File Offset: 0x0001F3D4
	static NPC_Info()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NPC_Info), "System.Void NPC_Info::CmdAnimationPlay(System.Int32)", new RemoteCallDelegate(NPC_Info.InvokeUserCode_CmdAnimationPlay__Int32), false);
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RpcShowThief()", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RpcShowThief));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RpcHideThief()", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RpcHideThief));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RpcEmployeeHitThief()", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RpcEmployeeHitThief));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RpcAnimationPlay(System.Int32)", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RpcAnimationPlay__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RpcShowBroom(System.Boolean)", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RpcShowBroom__Boolean));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RpcEquipNPCItem(System.Int32,System.Int32)", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RpcEquipNPCItem__Int32__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RPCNotificationAboveHead(System.String,System.String)", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RPCNotificationAboveHead__String__String));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Info), "System.Void NPC_Info::RPCChangeEmployeeHat(System.Int32)", new RemoteCallDelegate(NPC_Info.InvokeUserCode_RPCChangeEmployeeHat__Int32));
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x00021304 File Offset: 0x0001F504
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.NPCID);
			writer.WriteBool(this.isEmployee);
			writer.WriteBool(this.isCustomer);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.NPCID);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteBool(this.isEmployee);
		}
		if ((this.syncVarDirtyBits & 4UL) != 0UL)
		{
			writer.WriteBool(this.isCustomer);
		}
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x000213B8 File Offset: 0x0001F5B8
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.NPCID, null, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<bool>(ref this.isEmployee, null, reader.ReadBool());
			base.GeneratedSyncVarDeserialize<bool>(ref this.isCustomer, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.NPCID, null, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.isEmployee, null, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.isCustomer, null, reader.ReadBool());
		}
	}

	// Token: 0x040003D0 RID: 976
	[SyncVar]
	public int NPCID;

	// Token: 0x040003D1 RID: 977
	[SyncVar]
	public bool isEmployee;

	// Token: 0x040003D2 RID: 978
	[SyncVar]
	public bool isCustomer;

	// Token: 0x040003D3 RID: 979
	public int state;

	// Token: 0x040003D4 RID: 980
	public bool isAThief;

	// Token: 0x040003D5 RID: 981
	public bool alreadyGaveMoney;

	// Token: 0x040003D6 RID: 982
	public bool hasComplainedAboutFilth;

	// Token: 0x040003D7 RID: 983
	public int shelfThatHasTheItem;

	// Token: 0x040003D8 RID: 984
	public GameObject halloweenHeadPrefabOBJ;

	// Token: 0x040003D9 RID: 985
	[Space(10f)]
	public int taskPriority;

	// Token: 0x040003DA RID: 986
	public float productItemPlaceWait = 0.5f;

	// Token: 0x040003DB RID: 987
	public int[] productAvailableArray;

	// Token: 0x040003DC RID: 988
	public int equippedItem;

	// Token: 0x040003DD RID: 989
	public GameObject dummyBoxPrefab;

	// Token: 0x040003DE RID: 990
	public int boxProductID;

	// Token: 0x040003DF RID: 991
	public int boxNumberOfProducts;

	// Token: 0x040003E0 RID: 992
	public GameObject randomBox;

	// Token: 0x040003E1 RID: 993
	public bool playingCoroutine;

	// Token: 0x040003E2 RID: 994
	public int thiefProductsNumber;

	// Token: 0x040003E3 RID: 995
	public bool thiefFleeing;

	// Token: 0x040003E4 RID: 996
	public bool thiefAssignedChaser;

	// Token: 0x040003E5 RID: 997
	public GameObject currentChasedThiefOBJ;

	// Token: 0x040003E6 RID: 998
	public bool chasingThief;

	// Token: 0x040003E7 RID: 999
	public bool chaserUpdatingPathing;

	// Token: 0x040003E8 RID: 1000
	public int employeeAssignedCheckoutIndex = -1;

	// Token: 0x040003E9 RID: 1001
	public GameObject droppedProductOBJ;

	// Token: 0x040003EA RID: 1002
	public int currentFreeStorageIndex;

	// Token: 0x040003EB RID: 1003
	public GameObject currentFreeStorageOBJ;

	// Token: 0x040003EC RID: 1004
	public bool selfcheckoutAssigned;

	// Token: 0x040003ED RID: 1005
	public int selfcheckoutIndex = -1;

	// Token: 0x040003EE RID: 1006
	public bool isCurrentlySelfcheckouting;

	// Token: 0x040003EF RID: 1007
	private float selfCheckoutSum;

	// Token: 0x040003F0 RID: 1008
	public bool placingProducts;

	// Token: 0x040003F1 RID: 1009
	[Space(10f)]
	public GameObject messagePrefab;

	// Token: 0x040003F2 RID: 1010
	public GameObject stolenProductPrefab;

	// Token: 0x040003F3 RID: 1011
	public GameObject productCheckoutPrefab;

	// Token: 0x040003F4 RID: 1012
	[Space(10f)]
	public int currentCheckoutIndex;

	// Token: 0x040003F5 RID: 1013
	public int currentQueueNumber;

	// Token: 0x040003F6 RID: 1014
	[Space(10f)]
	public float carryingProductsPrice;

	// Token: 0x040003F7 RID: 1015
	public bool paidForItsBelongings;

	// Token: 0x040003F8 RID: 1016
	[Space(10f)]
	public List<int> productsIDToBuy = new List<int>();

	// Token: 0x040003F9 RID: 1017
	public List<int> productsIDCarrying = new List<int>();

	// Token: 0x040003FA RID: 1018
	public List<int> productsIDInCheckout = new List<int>();

	// Token: 0x040003FB RID: 1019
	public List<float> productsCarryingPrice = new List<float>();

	// Token: 0x040003FC RID: 1020
	public int numberOfProductsCarried;

	// Token: 0x040003FD RID: 1021
	private GameObject characterOBJ;

	// Token: 0x040003FE RID: 1022
	private Animator npcAnimator;

	// Token: 0x040003FF RID: 1023
	public float xzSpeed;

	// Token: 0x04000400 RID: 1024
	private bool beingPushed;

	// Token: 0x04000401 RID: 1025
	public GameObject instantiatedOBJ;

	// Token: 0x04000402 RID: 1026
	public GameObject employeeHatOBJ;

	// Token: 0x04000403 RID: 1027
	public GameObject employeeBroomOBJ;

	// Token: 0x04000404 RID: 1028
	private TwoBoneIKConstraint rightHandConstraint;

	// Token: 0x04000405 RID: 1029
	private TwoBoneIKConstraint leftHandConstraint;

	// Token: 0x04000406 RID: 1030
	private Transform rightHandOBJ;

	// Token: 0x04000407 RID: 1031
	private Transform rightHandDestinationOBJ;

	// Token: 0x04000408 RID: 1032
	private Transform leftHandOBJ;

	// Token: 0x04000409 RID: 1033
	private Transform leftHandDestinationOBJ;
}

using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

// Token: 0x02000097 RID: 151
public class NPC_Manager : NetworkBehaviour
{
	// Token: 0x06000528 RID: 1320 RVA: 0x00021D85 File Offset: 0x0001FF85
	private void Awake()
	{
		if (NPC_Manager.Instance == null)
		{
			NPC_Manager.Instance = this;
		}
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00021D9A File Offset: 0x0001FF9A
	private void Start()
	{
		this.UpdateEmployeesNumberInBlackboard();
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x00021DA2 File Offset: 0x0001FFA2
	public override void OnStartClient()
	{
		if (!base.isServer)
		{
			base.StartCoroutine(this.RequestRecycleStatus());
		}
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x00021DBC File Offset: 0x0001FFBC
	private void FixedUpdate()
	{
		if (!base.isServer)
		{
			return;
		}
		if (this.dummynpcParentOBJ.transform.childCount < this.maxDummyNPCs && !this.dummySpawnCooldown)
		{
			base.StartCoroutine(this.SpawnDummyNCP());
		}
		this.DummyNPCControl();
		if (this.shelvesOBJ.transform.childCount < 1 || this.checkoutOBJ.transform.childCount < 1 || !ProductListing.Instance.unlockedProductTiers[0])
		{
			return;
		}
		int childCount = this.employeeParentOBJ.transform.childCount;
		if (this.maxEmployees != 0 && childCount < this.maxEmployees)
		{
			this.SpawnEmployee();
		}
		if (childCount > 0)
		{
			this.EmployeeNPCControl(this.counter2);
			this.counter2++;
			if (this.counter2 >= childCount)
			{
				this.counter2 = 0;
			}
		}
		if (!GameData.Instance.isSupermarketOpen && GameData.Instance.timeOfDay < 8.05f)
		{
			return;
		}
		if (this.customersnpcParentOBJ.transform.childCount < GameData.Instance.maxCustomersNPCs && !this.spawnCooldown && GameData.Instance.timeOfDay < 22f)
		{
			base.StartCoroutine(this.SpawnCustomerNCP());
		}
		int childCount2 = this.customersnpcParentOBJ.transform.childCount;
		if (childCount2 == 0)
		{
			return;
		}
		if (this.counter >= childCount2 - 1)
		{
			this.counter = 0;
		}
		else
		{
			this.counter++;
		}
		this.CustomerNPCControl(this.counter);
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00021F33 File Offset: 0x00020133
	private IEnumerator RequestRecycleStatus()
	{
		yield return new WaitForSeconds(5f);
		this.CmdRequestRecycleStatus();
		yield break;
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x00021F44 File Offset: 0x00020144
	[Command(requiresAuthority = false)]
	public void CmdUpdateRecycleStatus()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void NPC_Manager::CmdUpdateRecycleStatus()", -234006800, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x00021F74 File Offset: 0x00020174
	[Command(requiresAuthority = false)]
	public void CmdRequestRecycleStatus()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void NPC_Manager::CmdRequestRecycleStatus()", 615025302, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00021FA4 File Offset: 0x000201A4
	[ClientRpc]
	private void RpcUpdateRecycleStatus(bool value)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(value);
		this.SendRPCInternal("System.Void NPC_Manager::RpcUpdateRecycleStatus(System.Boolean)", 2009389500, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x00021FE0 File Offset: 0x000201E0
	private void SpawnEmployee()
	{
		Vector3 position = this.employeeSpawnpoint.transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
		GameObject gameObject = Object.Instantiate<GameObject>(this.npcAgentPrefab, position, Quaternion.identity);
		gameObject.transform.SetParent(this.employeeParentOBJ.transform);
		NPC_Info component = gameObject.GetComponent<NPC_Info>();
		component.NetworkNPCID = Random.Range(0, this.NPCsEmployeesArray.Length - 1);
		component.NetworkisEmployee = true;
		NetworkServer.Spawn(gameObject, null);
		NavMeshAgent component2 = gameObject.GetComponent<NavMeshAgent>();
		component2.agentTypeID = base.transform.Find("AgentSample").GetComponent<NavMeshAgent>().agentTypeID;
		component2.enabled = true;
		component2.speed = 2.5f + 2.5f * this.extraEmployeeSpeedFactor;
		component2.radius = 0.14f;
		this.AssignEmployeePriorities();
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x000220D0 File Offset: 0x000202D0
	[Command(requiresAuthority = false)]
	public void CmdAlterPriority(int priorityIndex, bool Add)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(priorityIndex);
		writer.WriteBool(Add);
		base.SendCommandInternal("System.Void NPC_Manager::CmdAlterPriority(System.Int32,System.Boolean)", -1078371872, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x00022114 File Offset: 0x00020314
	[ClientRpc]
	private void RpcUpdateBlackboard(int checkout, int restock, int storage, int security)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(checkout);
		writer.WriteInt(restock);
		writer.WriteInt(storage);
		writer.WriteInt(security);
		this.SendRPCInternal("System.Void NPC_Manager::RpcUpdateBlackboard(System.Int32,System.Int32,System.Int32,System.Int32)", 785400729, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x0002216C File Offset: 0x0002036C
	public void UpdateEmployeesNumberInBlackboard()
	{
		this.employeesBlackboardOBJ.transform.Find("Container/EmployeesText").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("employees") + this.maxEmployees.ToString();
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x000221AC File Offset: 0x000203AC
	private void AssignEmployeePriorities()
	{
		this.employeePriorities.Clear();
		if (this.checkoutPriority > 0)
		{
			for (int i = 0; i < this.checkoutPriority; i++)
			{
				this.employeePriorities.Add(1);
			}
		}
		if (this.restockPriority > 0)
		{
			for (int j = 0; j < this.restockPriority; j++)
			{
				this.employeePriorities.Add(2);
			}
		}
		if (this.storagePriority > 0)
		{
			for (int k = 0; k < this.storagePriority; k++)
			{
				this.employeePriorities.Add(3);
			}
		}
		if (this.securityPriority > 0)
		{
			for (int l = 0; l < this.securityPriority; l++)
			{
				this.employeePriorities.Add(4);
			}
		}
		for (int m = 0; m < this.employeeParentOBJ.transform.childCount; m++)
		{
			NPC_Info component = this.employeeParentOBJ.transform.GetChild(m).gameObject.GetComponent<NPC_Info>();
			int taskPriority = component.taskPriority;
			if (m >= this.employeePriorities.Count && taskPriority == 1)
			{
				component.employeeAssignedCheckoutIndex = -1;
			}
			if (taskPriority != 1)
			{
				component.employeeAssignedCheckoutIndex = -1;
			}
			if (m >= this.employeePriorities.Count || this.employeePriorities[m] != taskPriority)
			{
				if (component.playingCoroutine)
				{
					component.StopCoroutinesFromManager();
				}
				if (m < this.employeePriorities.Count)
				{
					component.taskPriority = this.employeePriorities[m];
					component.state = 0;
				}
				else
				{
					component.taskPriority = 0;
					component.state = 0;
				}
			}
		}
		this.UpdateEmployeeStats();
		this.UpdateEmployeeCheckouts();
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x0002234C File Offset: 0x0002054C
	public void UpdateEmployeeStats()
	{
		foreach (object obj in this.employeeParentOBJ.transform)
		{
			Transform transform = (Transform)obj;
			NPC_Info component = transform.GetComponent<NPC_Info>();
			NavMeshAgent component2 = transform.GetComponent<NavMeshAgent>();
			component2.speed = 2.5f + 2.5f * this.extraEmployeeSpeedFactor;
			GameObject employeeBroomOBJ = component.employeeBroomOBJ;
			if (component.taskPriority == 4)
			{
				component2.speed *= 1.85f;
				component.RpcShowBroom(true);
			}
			else if (employeeBroomOBJ && employeeBroomOBJ.activeSelf)
			{
				component.RpcShowBroom(false);
			}
		}
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x0002240C File Offset: 0x0002060C
	public void UpdateEmployeeCheckoutsFromDataContainer()
	{
		this.UpdateEmployeeCheckouts();
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x00022414 File Offset: 0x00020614
	private void UpdateEmployeeCheckouts()
	{
		if (this.checkoutOBJ.transform.childCount == 0 || this.employeeParentOBJ.transform.childCount == 0)
		{
			return;
		}
		this.employeesCheckoutIndexes.Clear();
		foreach (object obj in this.employeeParentOBJ.transform)
		{
			Transform transform = (Transform)obj;
			this.employeesCheckoutIndexes.Add(transform.GetComponent<NPC_Info>().employeeAssignedCheckoutIndex);
		}
		for (int i = 0; i < this.checkoutOBJ.transform.childCount; i++)
		{
			Data_Container component = this.checkoutOBJ.transform.GetChild(i).GetComponent<Data_Container>();
			bool flag = false;
			for (int j = 0; j < this.employeesCheckoutIndexes.Count; j++)
			{
				if (this.employeesCheckoutIndexes[j] == i)
				{
					flag = true;
					component.isOccupiedByNPCCashier = true;
				}
			}
			if (!flag)
			{
				component.isOccupiedByNPCCashier = false;
			}
		}
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x00022528 File Offset: 0x00020728
	private void EmployeeNPCControl(int employeeIndex)
	{
		GameObject gameObject = this.employeeParentOBJ.transform.GetChild(employeeIndex).gameObject;
		NPC_Info component = gameObject.GetComponent<NPC_Info>();
		int state = component.state;
		NavMeshAgent component2 = gameObject.GetComponent<NavMeshAgent>();
		int taskPriority = component.taskPriority;
		if (state == -1)
		{
			return;
		}
		if (taskPriority == 4 && state == 2)
		{
			if (component.currentChasedThiefOBJ)
			{
				if (component.currentChasedThiefOBJ.transform.position.x < -15f || component.currentChasedThiefOBJ.transform.position.x > 38f || component.currentChasedThiefOBJ.GetComponent<NPC_Info>().productsIDCarrying.Count == 0)
				{
					component.state = 0;
					return;
				}
				if (Vector3.Distance(gameObject.transform.position, component.currentChasedThiefOBJ.transform.position) < 2f)
				{
					component2.SetDestination(gameObject.transform.position);
					component.state = 3;
				}
				else
				{
					component.CallPathing();
				}
			}
			else
			{
				component.state = 0;
			}
		}
		if (!component2.pathPending && component2.remainingDistance <= component2.stoppingDistance && (!component2.hasPath || component2.velocity.sqrMagnitude == 0f))
		{
			switch (taskPriority)
			{
			case 0:
				if (state != 0)
				{
					if (state != 1)
					{
						component.state = 0;
						return;
					}
				}
				else
				{
					if (component.equippedItem > 0)
					{
						Vector3 spawnpoint = component.transform.position + component.transform.forward * 0.5f + new Vector3(0f, 1f, 0f);
						GameData.Instance.GetComponent<ManagerBlackboard>().SpawnBoxFromEmployee(spawnpoint, component.boxProductID, component.boxNumberOfProducts);
						component.EquipNPCItem(0);
						component.boxProductID = 0;
						component.boxNumberOfProducts = 0;
						component.StartWaitState(1.5f, 0);
						component.state = -1;
						return;
					}
					component2.destination = this.restSpotOBJ.transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
					component.state = 1;
					return;
				}
				break;
			case 1:
			{
				switch (state)
				{
				case 0:
				case 1:
				{
					if (component.equippedItem > 0)
					{
						Vector3 spawnpoint2 = component.transform.position + component.transform.forward * 0.5f + new Vector3(0f, 1f, 0f);
						GameData.Instance.GetComponent<ManagerBlackboard>().SpawnBoxFromEmployee(spawnpoint2, component.boxProductID, component.boxNumberOfProducts);
						component.EquipNPCItem(0);
						component.boxProductID = 0;
						component.boxNumberOfProducts = 0;
						component.StartWaitState(1.5f, 0);
						component.state = -1;
						return;
					}
					int num = this.CashierGetAvailableCheckout(employeeIndex);
					if (num != -1)
					{
						component.employeeAssignedCheckoutIndex = num;
						this.UpdateEmployeeCheckouts();
						component2.destination = this.checkoutOBJ.transform.GetChild(num).transform.Find("EmployeePosition").transform.position;
						component.state = 2;
						return;
					}
					component.state = 10;
					return;
				}
				case 2:
					component.RPCNotificationAboveHead("NPCemployee0", "");
					component.StartWaitState(1.5f, 3);
					component.state = -1;
					return;
				case 3:
					if (this.CheckIfCustomerInQueue(component.employeeAssignedCheckoutIndex))
					{
						if (!this.checkoutOBJ.transform.GetChild(component.employeeAssignedCheckoutIndex).GetComponent<Data_Container>().checkoutQueue[0])
						{
							component.state = 4;
							return;
						}
						if (this.checkoutOBJ.transform.GetChild(component.employeeAssignedCheckoutIndex).GetComponent<Data_Container>().productsLeft > 0)
						{
							component.state = 5;
							return;
						}
						component.state = 4;
						return;
					}
					else
					{
						if (this.checkoutOBJ.transform.GetChild(component.employeeAssignedCheckoutIndex).GetComponent<Data_Container>().isCheckoutClosed)
						{
							component.employeeAssignedCheckoutIndex = -1;
							component.state = 0;
							return;
						}
						component.state = 4;
						return;
					}
					break;
				case 4:
					component.StartWaitState(1.5f, 3);
					component.state = -1;
					return;
				case 5:
					if (this.checkoutOBJ.transform.GetChild(component.employeeAssignedCheckoutIndex).GetComponent<Data_Container>().productsLeft == 0)
					{
						component.state = 7;
						return;
					}
					component.StartWaitState(this.productCheckoutWait, 6);
					component.state = -1;
					return;
				case 6:
					using (List<GameObject>.Enumerator enumerator = this.checkoutOBJ.transform.GetChild(component.employeeAssignedCheckoutIndex).GetComponent<Data_Container>().internalProductListForEmployees.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							GameObject gameObject2 = enumerator.Current;
							if (gameObject2 != null)
							{
								gameObject2.GetComponent<ProductCheckoutSpawn>().AddProductFromNPCEmployee();
								break;
							}
							component.state = 5;
						}
						return;
					}
					break;
				case 7:
					break;
				case 8:
				case 9:
					goto IL_602;
				case 10:
					if (Vector3.Distance(component.transform.position, this.restSpotOBJ.transform.position) > 3f)
					{
						component2.destination = this.restSpotOBJ.transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
						return;
					}
					component.StartWaitState(2f, 0);
					component.state = -1;
					return;
				default:
					goto IL_602;
				}
				GameObject currentNPC = this.checkoutOBJ.transform.GetChild(component.employeeAssignedCheckoutIndex).GetComponent<Data_Container>().currentNPC;
				if (!currentNPC)
				{
					component.state = 3;
				}
				if (currentNPC.GetComponent<NPC_Info>().alreadyGaveMoney)
				{
					this.checkoutOBJ.transform.GetChild(component.employeeAssignedCheckoutIndex).GetComponent<Data_Container>().AuxReceivePayment(0f, true);
					component.state = 3;
					return;
				}
				component.StartWaitState(this.productCheckoutWait, 7);
				component.state = -1;
				return;
				IL_602:
				component.state = 0;
				return;
			}
			case 2:
				switch (state)
				{
				case 0:
					if (component.equippedItem > 0)
					{
						Vector3 spawnpoint3 = component.transform.position + component.transform.forward * 0.5f + new Vector3(0f, 1f, 0f);
						GameData.Instance.GetComponent<ManagerBlackboard>().SpawnBoxFromEmployee(spawnpoint3, component.boxProductID, component.boxNumberOfProducts);
						component.EquipNPCItem(0);
						component.boxProductID = 0;
						component.boxNumberOfProducts = 0;
						component.StartWaitState(1.5f, 0);
						component.state = -1;
						return;
					}
					component.productAvailableArray = this.CheckProductAvailability();
					if (component.productAvailableArray[0] != -1)
					{
						component2.destination = this.storageOBJ.transform.GetChild(component.productAvailableArray[2]).transform.Find("Standspot").transform.position;
						component.state = 2;
						return;
					}
					if (Vector3.Distance(component.transform.position, this.restSpotOBJ.transform.position) > 3f)
					{
						component2.destination = this.restSpotOBJ.transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
						return;
					}
					component.StartWaitState(2f, 0);
					component.state = -1;
					return;
				case 1:
					return;
				case 2:
				{
					Data_Container component3 = this.storageOBJ.transform.GetChild(component.productAvailableArray[2]).GetComponent<Data_Container>();
					int[] productInfoArray = component3.productInfoArray;
					int num2 = productInfoArray[component.productAvailableArray[3]];
					if (num2 != component.productAvailableArray[5])
					{
						component.StartWaitState(2f, 0);
						component.state = -1;
						return;
					}
					int num3 = productInfoArray[component.productAvailableArray[3] + 1];
					if (num3 <= 0)
					{
						component.StartWaitState(2f, 0);
						component.state = -1;
						return;
					}
					if (this.storageOBJ.transform.GetChild(component.productAvailableArray[2]).transform.Find("CanvasSigns"))
					{
						component3.EmployeeUpdateArrayValuesStorage(component.productAvailableArray[3], num2, -1);
					}
					else
					{
						component3.EmployeeUpdateArrayValuesStorage(component.productAvailableArray[3], -1, -1);
					}
					component.boxProductID = num2;
					component.boxNumberOfProducts = num3;
					component.EquipNPCItem(1);
					component2.destination = this.shelvesOBJ.transform.GetChild(component.productAvailableArray[0]).transform.Find("Standspot").transform.position;
					component.state = 3;
					return;
				}
				case 3:
					if (this.shelvesOBJ.transform.GetChild(component.productAvailableArray[0]).GetComponent<Data_Container>().productInfoArray[component.productAvailableArray[1]] == component.productAvailableArray[4])
					{
						component.state = 4;
						return;
					}
					component.state = 5;
					return;
				case 4:
				{
					Data_Container component4 = this.shelvesOBJ.transform.GetChild(component.productAvailableArray[0]).GetComponent<Data_Container>();
					int num4 = component4.productInfoArray[component.productAvailableArray[1] + 1];
					int maxProductsPerRow = this.GetMaxProductsPerRow(component.productAvailableArray[0], component.productAvailableArray[4]);
					if (component.boxNumberOfProducts > 0 && num4 < maxProductsPerRow)
					{
						component4.EmployeeAddsItemToRow(component.productAvailableArray[1]);
						component.boxNumberOfProducts--;
						component.StartWaitState(this.employeeItemPlaceWait, 4);
						component.state = -1;
						return;
					}
					if (component.boxNumberOfProducts > 0 && this.CheckIfShelfWithSameProduct(component.productAvailableArray[4], component, component.productAvailableArray[0]))
					{
						component2.destination = this.shelvesOBJ.transform.GetChild(component.productAvailableArray[0]).transform.Find("Standspot").transform.position;
						component.state = 3;
						return;
					}
					component.state = 5;
					return;
				}
				case 5:
					if (component.boxNumberOfProducts <= 0)
					{
						if (!this.employeeRecycleBoxes || this.interruptBoxRecycling)
						{
							component2.destination = this.trashSpotOBJ.transform.position;
							component.state = 6;
							return;
						}
						float num5 = Vector3.Distance(gameObject.transform.position, this.recycleSpot1OBJ.transform.position);
						float num6 = Vector3.Distance(gameObject.transform.position, this.recycleSpot2OBJ.transform.position);
						if (num5 < num6)
						{
							component2.destination = this.recycleSpot1OBJ.transform.position;
							component.state = 9;
							return;
						}
						component2.destination = this.recycleSpot2OBJ.transform.position;
						component.state = 9;
						return;
					}
					else
					{
						int storageContainerWithBoxToMerge = this.GetStorageContainerWithBoxToMerge(component.boxProductID);
						if (storageContainerWithBoxToMerge >= 0)
						{
							component.currentFreeStorageIndex = storageContainerWithBoxToMerge;
							component2.destination = this.storageOBJ.transform.GetChild(storageContainerWithBoxToMerge).transform.Find("Standspot").transform.position;
							component.state = 20;
							return;
						}
						int freeStorageContainer = this.GetFreeStorageContainer(component.boxProductID);
						if (freeStorageContainer >= 0)
						{
							component2.destination = this.storageOBJ.transform.GetChild(freeStorageContainer).transform.Find("Standspot").transform.position;
							component.state = 7;
							return;
						}
						component2.destination = this.leftoverBoxesSpotOBJ.transform.position;
						component.state = 8;
						return;
					}
					break;
				case 6:
					component.EquipNPCItem(0);
					component.boxProductID = 0;
					component.boxNumberOfProducts = 0;
					component.StartWaitState(1.5f, 0);
					component.state = -1;
					return;
				case 7:
				{
					int freeStorageContainer2 = this.GetFreeStorageContainer(component.boxProductID);
					if (freeStorageContainer2 < 0)
					{
						component.StartWaitState(1.5f, 5);
						component.state = -1;
						return;
					}
					int freeStorageRow = this.GetFreeStorageRow(freeStorageContainer2, component.boxProductID);
					if (freeStorageRow >= 0)
					{
						this.storageOBJ.transform.GetChild(freeStorageContainer2).GetComponent<Data_Container>().EmployeeUpdateArrayValuesStorage(freeStorageRow * 2, component.boxProductID, component.boxNumberOfProducts);
						component.state = 6;
						return;
					}
					component.StartWaitState(1.5f, 5);
					component.state = -1;
					return;
				}
				case 8:
				{
					Vector3 spawnpoint4 = this.leftoverBoxesSpotOBJ.transform.position + new Vector3(Random.Range(-1f, 1f), 4f, Random.Range(-1f, 1f));
					GameData.Instance.GetComponent<ManagerBlackboard>().SpawnBoxFromEmployee(spawnpoint4, component.boxProductID, component.boxNumberOfProducts);
					component.state = 6;
					return;
				}
				case 9:
				{
					float fundsToAdd = 1.5f * (float)GameData.Instance.GetComponent<UpgradesManager>().boxRecycleFactor;
					AchievementsManager.Instance.CmdAddAchievementPoint(2, 1);
					GameData.Instance.CmdAlterFunds(fundsToAdd);
					component.state = 6;
					return;
				}
				case 20:
				{
					int storageRowWithBoxToMerge = this.GetStorageRowWithBoxToMerge(component.currentFreeStorageIndex, component.boxProductID);
					if (storageRowWithBoxToMerge >= 0)
					{
						this.EmployeeMergeBoxContents(component, component.currentFreeStorageIndex, component.boxProductID, storageRowWithBoxToMerge);
						component.StartWaitState(1.5f, 5);
						component.state = -1;
						return;
					}
					component.StartWaitState(1.5f, 5);
					component.state = -1;
					return;
				}
				}
				component.state = 0;
				return;
			case 3:
				switch (state)
				{
				case 0:
					if (component.equippedItem > 0)
					{
						Vector3 spawnpoint5 = component.transform.position + component.transform.forward * 0.5f + new Vector3(0f, 1f, 0f);
						GameData.Instance.GetComponent<ManagerBlackboard>().SpawnBoxFromEmployee(spawnpoint5, component.boxProductID, component.boxNumberOfProducts);
						component.EquipNPCItem(0);
						component.boxProductID = 0;
						component.boxNumberOfProducts = 0;
						component.StartWaitState(1.5f, 0);
						component.state = -1;
						return;
					}
					if (this.GetFreeStorageContainer(10000) < 0)
					{
						GameObject randomGroundBoxAllowedInStorage = this.GetRandomGroundBoxAllowedInStorage();
						if (randomGroundBoxAllowedInStorage)
						{
							component.randomBox = randomGroundBoxAllowedInStorage;
							component2.destination = randomGroundBoxAllowedInStorage.transform.position;
							component.state = 1;
							return;
						}
						component.state = 10;
						return;
					}
					else
					{
						GameObject randomGroundBox = this.GetRandomGroundBox();
						if (randomGroundBox)
						{
							component.randomBox = randomGroundBox;
							component2.destination = randomGroundBox.transform.position;
							component.state = 1;
							return;
						}
						component.state = 10;
						return;
					}
					break;
				case 1:
				{
					if (!component.randomBox || Vector3.Distance(component.randomBox.transform.position, component.transform.position) >= 2f)
					{
						component.StartWaitState(2f, 0);
						component.state = -1;
						return;
					}
					BoxData component5 = component.randomBox.GetComponent<BoxData>();
					component.boxProductID = component5.productID;
					component.boxNumberOfProducts = component5.numberOfProducts;
					component.EquipNPCItem(1);
					GameData.Instance.GetComponent<NetworkSpawner>().EmployeeDestroyBox(component.randomBox);
					if (component5.numberOfProducts > 0)
					{
						component.state = 2;
						return;
					}
					component.state = 6;
					return;
				}
				case 2:
				{
					int freeStorageContainer3 = this.GetFreeStorageContainer(component.boxProductID);
					if (freeStorageContainer3 >= 0)
					{
						component.currentFreeStorageIndex = freeStorageContainer3;
						component.currentFreeStorageOBJ = this.storageOBJ.transform.GetChild(freeStorageContainer3).gameObject;
						component2.destination = this.storageOBJ.transform.GetChild(freeStorageContainer3).transform.Find("Standspot").transform.position;
						component.state = 3;
						return;
					}
					component2.destination = this.leftoverBoxesSpotOBJ.transform.position;
					component.state = 4;
					return;
				}
				case 3:
				{
					int freeStorageContainer4 = this.GetFreeStorageContainer(component.boxProductID);
					if (freeStorageContainer4 < 0 || component.currentFreeStorageIndex != freeStorageContainer4 || !component.currentFreeStorageOBJ)
					{
						component.StartWaitState(1.5f, 2);
						component.state = -1;
						return;
					}
					int freeStorageRow2 = this.GetFreeStorageRow(freeStorageContainer4, component.boxProductID);
					if (freeStorageRow2 >= 0)
					{
						this.storageOBJ.transform.GetChild(freeStorageContainer4).GetComponent<Data_Container>().EmployeeUpdateArrayValuesStorage(freeStorageRow2 * 2, component.boxProductID, component.boxNumberOfProducts);
						component.state = 5;
						return;
					}
					component.StartWaitState(1.5f, 2);
					component.state = -1;
					return;
				}
				case 4:
				{
					Vector3 spawnpoint6 = this.leftoverBoxesSpotOBJ.transform.position + new Vector3(Random.Range(-1f, 1f), 3f, Random.Range(-1f, 1f));
					GameData.Instance.GetComponent<ManagerBlackboard>().SpawnBoxFromEmployee(spawnpoint6, component.boxProductID, component.boxNumberOfProducts);
					component.state = 5;
					return;
				}
				case 5:
					component.EquipNPCItem(0);
					component.boxProductID = 0;
					component.boxNumberOfProducts = 0;
					component.StartWaitState(1.5f, 0);
					component.state = -1;
					return;
				case 6:
				{
					if (!this.employeeRecycleBoxes || this.interruptBoxRecycling)
					{
						component2.destination = this.trashSpotOBJ.transform.position;
						component.state = 5;
						return;
					}
					float num7 = Vector3.Distance(gameObject.transform.position, this.recycleSpot1OBJ.transform.position);
					float num8 = Vector3.Distance(gameObject.transform.position, this.recycleSpot2OBJ.transform.position);
					if (num7 < num8)
					{
						component2.destination = this.recycleSpot1OBJ.transform.position;
						component.state = 7;
						return;
					}
					component2.destination = this.recycleSpot2OBJ.transform.position;
					component.state = 7;
					return;
				}
				case 7:
				{
					float fundsToAdd2 = 1.5f * (float)GameData.Instance.GetComponent<UpgradesManager>().boxRecycleFactor;
					AchievementsManager.Instance.CmdAddAchievementPoint(2, 1);
					GameData.Instance.CmdAlterFunds(fundsToAdd2);
					component.state = 5;
					return;
				}
				case 10:
					if (Vector3.Distance(component.transform.position, this.restSpotOBJ.transform.position) > 3f)
					{
						component2.destination = this.restSpotOBJ.transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
						return;
					}
					component.StartWaitState(2f, 0);
					component.state = -1;
					return;
				}
				component.state = 0;
				return;
			case 4:
				switch (state)
				{
				case 0:
				{
					if (component.equippedItem > 0)
					{
						Vector3 spawnpoint7 = component.transform.position + component.transform.forward * 0.5f + new Vector3(0f, 1f, 0f);
						GameData.Instance.GetComponent<ManagerBlackboard>().SpawnBoxFromEmployee(spawnpoint7, component.boxProductID, component.boxNumberOfProducts);
						component.EquipNPCItem(0);
						component.boxProductID = 0;
						component.boxNumberOfProducts = 0;
						component.StartWaitState(1.5f, 0);
						component.state = -1;
						return;
					}
					GameObject thiefTarget = this.GetThiefTarget();
					if (thiefTarget != null)
					{
						component.currentChasedThiefOBJ = thiefTarget;
						component.state = 2;
						return;
					}
					if (!this.IsFirstSecurityEmployee(employeeIndex))
					{
						component.state = 1;
						return;
					}
					GameObject closestDropProduct = this.GetClosestDropProduct(gameObject);
					if (closestDropProduct != null)
					{
						component.droppedProductOBJ = closestDropProduct;
						component.state = 4;
						component2.destination = closestDropProduct.transform.position;
						return;
					}
					component.state = 1;
					return;
				}
				case 1:
				{
					Transform child;
					if (employeeIndex < this.patrolPositionOBJ.transform.childCount)
					{
						child = this.patrolPositionOBJ.transform.GetChild(employeeIndex);
					}
					else
					{
						child = this.patrolPositionOBJ.transform.GetChild(0);
					}
					if (Vector3.Distance(component.transform.position, child.position) > 3f)
					{
						component2.destination = child.position;
						return;
					}
					component.StartWaitState(1f, 0);
					component.state = -1;
					return;
				}
				case 2:
					break;
				case 3:
					if (component.currentChasedThiefOBJ && component.currentChasedThiefOBJ.GetComponent<NPC_Info>().productsIDCarrying.Count > 0)
					{
						component.currentChasedThiefOBJ.GetComponent<NPC_Info>().AuxiliarAnimationPlay(0);
						component.RpcEmployeeHitThief();
						component.StartWaitState(1.45f, 2);
						component.state = -1;
						return;
					}
					component.StartWaitState(0.5f, 0);
					component.state = -1;
					return;
				case 4:
					if (component.droppedProductOBJ != null)
					{
						component.droppedProductOBJ.GetComponent<StolenProductSpawn>().RecoverStolenProductFromEmployee();
						component.StartWaitState(0.5f, 0);
						component.state = -1;
						return;
					}
					component.state = 0;
					return;
				default:
					component.state = 0;
					return;
				}
				break;
			default:
				Debug.Log("Impossible employee current task case. Check logs.");
				break;
			}
		}
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x00023A14 File Offset: 0x00021C14
	private int CashierGetAvailableCheckout(int employeeIndexCheck)
	{
		if (this.checkoutOBJ.transform.childCount == 0 || employeeIndexCheck >= this.checkoutOBJ.transform.childCount)
		{
			return -1;
		}
		for (int i = 0; i < this.checkoutOBJ.transform.childCount; i++)
		{
			Data_Container component = this.checkoutOBJ.transform.GetChild(i).GetComponent<Data_Container>();
			if (!component.isCheckoutClosed && !component.isOccupiedByNPCCashier)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x00023A90 File Offset: 0x00021C90
	private bool CheckIfCustomerInQueue(int checkoutIndex)
	{
		if (checkoutIndex >= this.checkoutOBJ.transform.childCount || checkoutIndex < 0)
		{
			return false;
		}
		bool[] checkoutQueue = this.checkoutOBJ.transform.GetChild(checkoutIndex).GetComponent<Data_Container>().checkoutQueue;
		for (int i = 0; i < checkoutQueue.Length; i++)
		{
			if (checkoutQueue[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x00023AE8 File Offset: 0x00021CE8
	private int[] CheckProductAvailability()
	{
		int[] array = new int[]
		{
			-1,
			-1,
			-1,
			-1,
			-1,
			-1
		};
		this.productsPriority.Clear();
		if (this.storageOBJ.transform.childCount == 0 || this.shelvesOBJ.transform.childCount == 0)
		{
			return array;
		}
		for (int i = 0; i < this.productsThreshholdArray.Length; i++)
		{
			this.productsPriority.Clear();
			for (int j = 0; j < this.shelvesOBJ.transform.childCount; j++)
			{
				int[] productInfoArray = this.shelvesOBJ.transform.GetChild(j).GetComponent<Data_Container>().productInfoArray;
				int num = productInfoArray.Length / 2;
				for (int k = 0; k < num; k++)
				{
					this.productsPrioritySecondary.Clear();
					int num2 = productInfoArray[k * 2];
					if (num2 >= 0)
					{
						int num3 = productInfoArray[k * 2 + 1];
						int num4 = Mathf.FloorToInt((float)this.GetMaxProductsPerRow(j, num2) * this.productsThreshholdArray[i]);
						if (num3 == 0 || num3 < num4)
						{
							for (int l = 0; l < this.storageOBJ.transform.childCount; l++)
							{
								int[] productInfoArray2 = this.storageOBJ.transform.GetChild(l).GetComponent<Data_Container>().productInfoArray;
								int num5 = productInfoArray2.Length / 2;
								for (int m = 0; m < num5; m++)
								{
									int num6 = productInfoArray2[m * 2];
									if (num6 >= 0 && num6 == num2 && productInfoArray2[m * 2 + 1] > 0)
									{
										string item = string.Concat(new string[]
										{
											j.ToString(),
											"|",
											(k * 2).ToString(),
											"|",
											l.ToString(),
											"|",
											(m * 2).ToString(),
											"|",
											num2.ToString(),
											"|",
											num6.ToString()
										});
										this.productsPrioritySecondary.Add(item);
									}
								}
							}
						}
						if (this.productsPrioritySecondary.Count > 0)
						{
							this.productsPriority.Add(this.productsPrioritySecondary[Random.Range(0, this.productsPrioritySecondary.Count)]);
						}
					}
				}
			}
			if (this.productsPriority.Count > 0)
			{
				break;
			}
		}
		if (this.productsPriority.Count > 0)
		{
			string[] array2 = this.productsPriority[Random.Range(0, this.productsPriority.Count)].Split("|", StringSplitOptions.None);
			array[0] = int.Parse(array2[0]);
			array[1] = int.Parse(array2[1]);
			array[2] = int.Parse(array2[2]);
			array[3] = int.Parse(array2[3]);
			array[4] = int.Parse(array2[4]);
			array[5] = int.Parse(array2[5]);
			return array;
		}
		return array;
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x00023DE0 File Offset: 0x00021FE0
	private int GetMaxProductsPerRow(int containerIndex, int ProductID)
	{
		float shelfLength = this.shelvesOBJ.transform.GetChild(containerIndex).GetComponent<Data_Container>().shelfLength;
		float shelfWidth = this.shelvesOBJ.transform.GetChild(containerIndex).GetComponent<Data_Container>().shelfWidth;
		float shelfHeight = this.shelvesOBJ.transform.GetChild(containerIndex).GetComponent<Data_Container>().shelfHeight;
		GameObject gameObject = ProductListing.Instance.productPrefabs[ProductID];
		Vector3 size = gameObject.GetComponent<BoxCollider>().size;
		bool isStackable = gameObject.GetComponent<Data_Product>().isStackable;
		int num = Mathf.FloorToInt(shelfLength / (size.x * 1.1f));
		num = Mathf.Clamp(num, 1, 100);
		int num2 = Mathf.FloorToInt(shelfWidth / (size.z * 1.1f));
		num2 = Mathf.Clamp(num2, 1, 100);
		int result = num * num2;
		if (isStackable)
		{
			int num3 = Mathf.FloorToInt(shelfHeight / (size.y * 1.1f));
			num3 = Mathf.Clamp(num3, 1, 100);
			result = num * num2 * num3;
		}
		return result;
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x00023EDC File Offset: 0x000220DC
	private int GetFreeStorageContainer(int boxIDProduct)
	{
		if (this.storageOBJ.transform.childCount == 0)
		{
			return -1;
		}
		for (int i = 0; i < this.storageOBJ.transform.childCount; i++)
		{
			int[] productInfoArray = this.storageOBJ.transform.GetChild(i).GetComponent<Data_Container>().productInfoArray;
			int num = productInfoArray.Length / 2;
			for (int j = 0; j < num; j++)
			{
				int num2 = productInfoArray[j * 2];
				int num3 = productInfoArray[j * 2 + 1];
				if (this.storageOBJ.transform.GetChild(i).transform.Find("BoxContainer").gameObject.transform.GetChild(j).transform.childCount <= 0 && num2 == boxIDProduct && num3 <= 0)
				{
					return i;
				}
			}
		}
		for (int k = 0; k < this.storageOBJ.transform.childCount; k++)
		{
			int[] productInfoArray2 = this.storageOBJ.transform.GetChild(k).GetComponent<Data_Container>().productInfoArray;
			int num4 = productInfoArray2.Length / 2;
			for (int l = 0; l < num4; l++)
			{
				if (productInfoArray2[l * 2] == -1)
				{
					return k;
				}
			}
		}
		return -1;
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x0002400C File Offset: 0x0002220C
	private int GetFreeStorageRow(int storageContainerIndex, int boxIDProduct)
	{
		int[] productInfoArray = this.storageOBJ.transform.GetChild(storageContainerIndex).GetComponent<Data_Container>().productInfoArray;
		int num = productInfoArray.Length / 2;
		for (int i = 0; i < num; i++)
		{
			int num2 = productInfoArray[i * 2];
			int num3 = productInfoArray[i * 2 + 1];
			if (this.storageOBJ.transform.GetChild(storageContainerIndex).transform.Find("BoxContainer").gameObject.transform.GetChild(i).transform.childCount <= 0 && num2 == boxIDProduct && num3 <= 0)
			{
				return i;
			}
		}
		for (int j = 0; j < num; j++)
		{
			if (productInfoArray[j * 2] == -1)
			{
				return j;
			}
		}
		return -1;
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x000240BC File Offset: 0x000222BC
	private int GetStorageContainerWithBoxToMerge(int boxIDProduct)
	{
		if (this.storageOBJ.transform.childCount == 0)
		{
			return -1;
		}
		for (int i = 0; i < this.storageOBJ.transform.childCount; i++)
		{
			int[] productInfoArray = this.storageOBJ.transform.GetChild(i).GetComponent<Data_Container>().productInfoArray;
			int num = productInfoArray.Length / 2;
			for (int j = 0; j < num; j++)
			{
				int num2 = productInfoArray[j * 2];
				int num3 = productInfoArray[j * 2 + 1];
				if (num2 == boxIDProduct && this.storageOBJ.transform.GetChild(i).transform.Find("BoxContainer").transform.GetChild(j).transform.childCount > 0 && num3 < ProductListing.Instance.productPrefabs[num2].GetComponent<Data_Product>().maxItemsPerBox)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x00024198 File Offset: 0x00022398
	private int GetStorageRowWithBoxToMerge(int storageContainerIndex, int boxIDProduct)
	{
		int[] productInfoArray = this.storageOBJ.transform.GetChild(storageContainerIndex).GetComponent<Data_Container>().productInfoArray;
		int num = productInfoArray.Length / 2;
		for (int i = 0; i < num; i++)
		{
			int num2 = productInfoArray[i * 2];
			int num3 = productInfoArray[i * 2 + 1];
			if (num2 == boxIDProduct && this.storageOBJ.transform.GetChild(storageContainerIndex).transform.Find("BoxContainer").transform.GetChild(i).transform.childCount > 0 && num3 < ProductListing.Instance.productPrefabs[num2].GetComponent<Data_Product>().maxItemsPerBox)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x0002423C File Offset: 0x0002243C
	private void EmployeeMergeBoxContents(NPC_Info npcInfoComponent, int storageContainerIndex, int BoxIDProduct, int rowIndex)
	{
		Data_Container component = this.storageOBJ.transform.GetChild(storageContainerIndex).GetComponent<Data_Container>();
		int maxItemsPerBox = ProductListing.Instance.productPrefabs[BoxIDProduct].GetComponent<Data_Product>().maxItemsPerBox;
		int num = component.productInfoArray[rowIndex * 2 + 1];
		if (num + npcInfoComponent.boxNumberOfProducts > maxItemsPerBox)
		{
			int num2 = maxItemsPerBox - num;
			npcInfoComponent.boxNumberOfProducts -= num2;
			component.EmployeeUpdateArrayValuesStorage(rowIndex * 2, BoxIDProduct, maxItemsPerBox);
			return;
		}
		component.EmployeeUpdateArrayValuesStorage(rowIndex * 2, BoxIDProduct, num + npcInfoComponent.boxNumberOfProducts);
		npcInfoComponent.boxNumberOfProducts = 0;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x000242CC File Offset: 0x000224CC
	private GameObject GetRandomGroundBox()
	{
		if (this.boxesOBJ.transform.childCount <= 0)
		{
			return null;
		}
		if (this.boxesOBJ.transform.childCount == 1)
		{
			return this.boxesOBJ.transform.GetChild(0).gameObject;
		}
		int index = Random.Range(0, this.boxesOBJ.transform.childCount);
		return this.boxesOBJ.transform.GetChild(index).gameObject;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x00024348 File Offset: 0x00022548
	private GameObject GetRandomGroundBoxAllowedInStorage()
	{
		if (this.storageOBJ.transform.childCount == 0 || this.boxesOBJ.transform.childCount == 0)
		{
			return null;
		}
		this.indexedBoxesList.Clear();
		for (int i = 0; i < this.boxesOBJ.transform.childCount; i++)
		{
			GameObject gameObject = this.boxesOBJ.transform.GetChild(i).gameObject;
			int productID = gameObject.GetComponent<BoxData>().productID;
			if (this.indexedBoxesList.Count >= 25)
			{
				break;
			}
			for (int j = 0; j < this.storageOBJ.transform.childCount; j++)
			{
				int[] productInfoArray = this.storageOBJ.transform.GetChild(j).GetComponent<Data_Container>().productInfoArray;
				int num = productInfoArray.Length / 2;
				for (int k = 0; k < num; k++)
				{
					int num2 = productInfoArray[k * 2];
					int num3 = productInfoArray[k * 2 + 1];
					if (this.storageOBJ.transform.GetChild(j).transform.Find("BoxContainer").gameObject.transform.GetChild(k).transform.childCount <= 0 && num2 == productID && num3 <= 0)
					{
						this.indexedBoxesList.Add(gameObject);
					}
				}
			}
		}
		if (this.indexedBoxesList.Count > 0)
		{
			return this.indexedBoxesList[Random.Range(0, this.indexedBoxesList.Count)];
		}
		return null;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x000244C8 File Offset: 0x000226C8
	private bool CheckIfShelfWithSameProduct(int productIDToCheck, NPC_Info npcInfoComponent, int currentShelfIndex)
	{
		for (int i = 0; i < this.productsThreshholdArray.Length; i++)
		{
			this.auxiliarList.Clear();
			for (int j = 0; j < this.shelvesOBJ.transform.childCount; j++)
			{
				int[] productInfoArray = this.shelvesOBJ.transform.GetChild(j).GetComponent<Data_Container>().productInfoArray;
				int num = productInfoArray.Length / 2;
				for (int k = 0; k < num; k++)
				{
					int num2 = productInfoArray[k * 2];
					if (num2 == productIDToCheck)
					{
						int num3 = productInfoArray[k * 2 + 1];
						int num4 = Mathf.FloorToInt((float)this.GetMaxProductsPerRow(j, num2) * this.productsThreshholdArray[i]);
						if (num3 == 0 || num3 < num4)
						{
							if (j == currentShelfIndex)
							{
								npcInfoComponent.productAvailableArray[1] = k * 2;
								return true;
							}
							string item = j.ToString() + "|" + (k * 2).ToString();
							this.auxiliarList.Add(item);
						}
					}
				}
			}
			if (this.auxiliarList.Count > 0)
			{
				string[] array = this.auxiliarList[Random.Range(0, this.auxiliarList.Count)].Split("|", StringSplitOptions.None);
				npcInfoComponent.productAvailableArray[0] = int.Parse(array[0]);
				npcInfoComponent.productAvailableArray[1] = int.Parse(array[1]);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x00024628 File Offset: 0x00022828
	private GameObject GetThiefTarget()
	{
		if (this.customersnpcParentOBJ.transform.childCount == 0)
		{
			return null;
		}
		this.thievesList.Clear();
		foreach (object obj in this.customersnpcParentOBJ.transform)
		{
			Transform transform = (Transform)obj;
			NPC_Info component = transform.GetComponent<NPC_Info>();
			if (component.isAThief && component.thiefFleeing && component.productsIDCarrying.Count > 0 && transform.position.z < -3f && transform.position.x > -15f && transform.position.x < 38f)
			{
				this.thievesList.Add(transform.gameObject);
				if (!component.thiefAssignedChaser)
				{
					component.thiefAssignedChaser = true;
					return transform.gameObject;
				}
			}
		}
		if (this.thievesList.Count > 0)
		{
			return this.thievesList[Random.Range(0, this.thievesList.Count)];
		}
		return null;
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x0002475C File Offset: 0x0002295C
	private bool IsFirstSecurityEmployee(int employeeIndex)
	{
		int num = this.checkoutPriority + this.restockPriority + this.storagePriority;
		return num < this.employeeParentOBJ.transform.childCount && num == employeeIndex;
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x0002479C File Offset: 0x0002299C
	private GameObject GetClosestDropProduct(GameObject currentEmployeeOBJ)
	{
		if (this.droppedProductsParentOBJ.transform.childCount == 0)
		{
			return null;
		}
		float num = 100f;
		GameObject gameObject = null;
		foreach (object obj in this.droppedProductsParentOBJ.transform)
		{
			Transform transform = (Transform)obj;
			float num2 = Vector3.Distance(transform.position, currentEmployeeOBJ.transform.position);
			if (num2 < num)
			{
				num = num2;
				gameObject = transform.gameObject;
			}
		}
		if (gameObject != null)
		{
			return gameObject;
		}
		return null;
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x00024848 File Offset: 0x00022A48
	public void RemoveCustomers()
	{
		if (this.customersnpcParentOBJ.transform.childCount > 0 && !this.coroutinePlaying)
		{
			base.StartCoroutine(this.RemoveCustomersCoroutine());
		}
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x00024872 File Offset: 0x00022A72
	private IEnumerator RemoveCustomersCoroutine()
	{
		this.coroutinePlaying = true;
		yield return new WaitForSeconds(3f);
		while (this.customersnpcParentOBJ.transform.childCount > 0)
		{
			Object.Destroy(this.customersnpcParentOBJ.transform.GetChild(this.customersnpcParentOBJ.transform.childCount - 1).gameObject);
			yield return null;
		}
		yield return null;
		this.coroutinePlaying = false;
		yield break;
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x00024881 File Offset: 0x00022A81
	private IEnumerator SpawnCustomerNCP()
	{
		this.spawnCooldown = true;
		float num = 5f - (float)(GameData.Instance.gameDay + GameData.Instance.difficulty + NetworkServer.connections.Count) * 0.05f;
		float num2 = 12f - (float)(GameData.Instance.gameDay + GameData.Instance.difficulty + NetworkServer.connections.Count) * 0.12f;
		num = Mathf.Clamp(num, 2f, float.PositiveInfinity);
		num2 = Mathf.Clamp(num2, 4f, float.PositiveInfinity);
		yield return new WaitForSeconds(Random.Range(num, num2));
		int gameDay = GameData.Instance.gameDay;
		float num3;
		if (NetworkServer.connections.Count <= 1)
		{
			num3 = ((float)gameDay - 7f) * 0.05f + (float)GameData.Instance.difficulty * 0.1f;
			num3 = Mathf.Clamp(num3, 0f, 1.25f + (float)GameData.Instance.difficulty);
		}
		else
		{
			num3 = ((float)gameDay - 7f) * 0.15f + (float)GameData.Instance.difficulty * 0.15f;
			num3 = Mathf.Clamp(num3, 0f, 2f + (float)GameData.Instance.difficulty + (float)NetworkServer.connections.Count);
		}
		float num4 = Random.Range(0.1f, 100f);
		Vector3 position = this.spawnPointsOBJ.transform.GetChild(Random.Range(0, this.spawnPointsOBJ.transform.childCount - 1)).transform.position;
		GameObject gameObject = Object.Instantiate<GameObject>(this.npcAgentPrefab, position, Quaternion.identity);
		gameObject.transform.SetParent(this.customersnpcParentOBJ.transform);
		NPC_Info component = gameObject.GetComponent<NPC_Info>();
		component.NetworkNPCID = Random.Range(0, this.NPCsArray.Length - 1);
		component.NetworkisCustomer = true;
		component.productItemPlaceWait = Mathf.Clamp(0.5f - (float)GameData.Instance.gameDay * 0.003f, 0.1f, 0.5f);
		if (num4 < num3)
		{
			component.isAThief = true;
		}
		NetworkServer.Spawn(gameObject, null);
		int num5 = Random.Range(2 + GameData.Instance.difficulty, GameData.Instance.maxProductsCustomersToBuy);
		for (int i = 0; i < num5; i++)
		{
			int item = ProductListing.Instance.availableProducts[Random.Range(0, ProductListing.Instance.availableProducts.Count)];
			component.productsIDToBuy.Add(item);
		}
		component.productsIDToBuy.Sort();
		if ((double)Random.value < 0.5)
		{
			component.productsIDToBuy.Reverse();
		}
		NavMeshAgent component2 = gameObject.GetComponent<NavMeshAgent>();
		component2.enabled = true;
		component2.stoppingDistance = 1f;
		component2.speed = 1.9f + (float)Mathf.Clamp(GameData.Instance.gameDay - 7, 0, 40) * 0.07f + (float)NetworkServer.connections.Count * 0.1f + (float)GameData.Instance.difficulty * 0.15f;
		Vector3 position2 = this.shelvesOBJ.transform.GetChild(Random.Range(0, this.shelvesOBJ.transform.childCount - 1)).Find("Standspot").transform.position;
		component2.destination = position2;
		this.spawnCooldown = false;
		yield break;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x00024890 File Offset: 0x00022A90
	private void CustomerNPCControl(int NPCIndex)
	{
		GameObject gameObject = this.customersnpcParentOBJ.transform.GetChild(NPCIndex).gameObject;
		NPC_Info component = gameObject.GetComponent<NPC_Info>();
		int state = component.state;
		NavMeshAgent component2 = gameObject.GetComponent<NavMeshAgent>();
		if (state == -1)
		{
			return;
		}
		if (!component2.pathPending && component2.remainingDistance <= component2.stoppingDistance && (!component2.hasPath || component2.velocity.sqrMagnitude == 0f))
		{
			if (component.productsIDToBuy.Count > 0)
			{
				if (state != 0)
				{
					if (state != 1)
					{
						Debug.Log("npc case error");
						return;
					}
					int num = component.productsIDToBuy[0];
					if (this.IsItemInShelf(component.shelfThatHasTheItem, num))
					{
						float num2 = ProductListing.Instance.productPlayerPricing[num];
						Data_Product component3 = ProductListing.Instance.productPrefabs[num].GetComponent<Data_Product>();
						int productTier = component3.productTier;
						float num3 = component3.basePricePerUnit * ProductListing.Instance.tierInflation[productTier] * Random.Range(2f, 2.5f);
						component.productsIDToBuy.RemoveAt(0);
						if (num2 > num3)
						{
							component.StartWaitState(1.5f, 0);
							component.RPCNotificationAboveHead("NPCmessage1", "product" + num.ToString());
							GameData.Instance.AddExpensiveList(num);
						}
						else
						{
							component.productsIDCarrying.Add(num);
							component.productsCarryingPrice.Add(num2);
							component.numberOfProductsCarried++;
							component.StartWaitState(1.5f, 0);
							this.shelvesOBJ.transform.GetChild(component.shelfThatHasTheItem).GetComponent<Data_Container>().NPCGetsItemFromRow(num);
						}
						component.state = -1;
						return;
					}
					component.state = 0;
					return;
				}
				else
				{
					int productID = component.productsIDToBuy[0];
					int num4 = this.WhichShelfHasItem(productID);
					if (num4 == -1)
					{
						GameData.Instance.AddNotFoundList(productID);
						component.productsIDToBuy.RemoveAt(0);
						component.RPCNotificationAboveHead("NPCmessage0", "product" + productID.ToString());
						component.StartWaitState(1.5f, 0);
						component.state = -1;
						return;
					}
					component.shelfThatHasTheItem = num4;
					Vector3 position = this.shelvesOBJ.transform.GetChild(num4).Find("Standspot").transform.position;
					component2.destination = position;
					component.state = 1;
					return;
				}
			}
			else
			{
				if (component.isAThief && state < 2)
				{
					component2.destination = this.exitPoints.GetChild(Random.Range(0, this.exitPoints.childCount - 1)).transform.position;
					component2.speed *= 1.25f;
					component.RPCNotificationAboveHead("NPCmessage4", "");
					component.RpcShowThief();
					component.thiefFleeing = true;
					component.thiefProductsNumber = component.productsIDCarrying.Count;
					component.StartWaitState(2f, 11);
					component.state = -1;
					return;
				}
				if (component.productsIDCarrying.Count == 0 && state < 2)
				{
					component2.destination = this.exitPoints.GetChild(Random.Range(0, this.exitPoints.childCount - 1)).transform.position;
					component.RPCNotificationAboveHead("NPCmessage2", "");
					component.StartWaitState(2f, 10);
					component.state = -1;
					return;
				}
				if (!component.selfcheckoutAssigned && this.selfCheckoutOBJ.transform.childCount > 0 && !component.isAThief)
				{
					int availableSelfCheckout = this.GetAvailableSelfCheckout(component);
					if (availableSelfCheckout > -1)
					{
						component.selfcheckoutIndex = availableSelfCheckout;
						this.selfCheckoutOBJ.transform.GetChild(availableSelfCheckout).GetComponent<Data_Container>().checkoutQueue[0] = true;
					}
					component.selfcheckoutAssigned = true;
				}
				if (component.selfcheckoutIndex > -1)
				{
					switch (state)
					{
					case 0:
					case 1:
						component2.destination = this.selfCheckoutOBJ.transform.GetChild(component.selfcheckoutIndex).transform.Find("Standspot").transform.position;
						component.state = 2;
						return;
					case 2:
						if (!component.isCurrentlySelfcheckouting)
						{
							component.isCurrentlySelfcheckouting = true;
							component.StartCustomerSelfCheckout(this.selfCheckoutOBJ.transform.GetChild(component.selfcheckoutIndex).gameObject);
							return;
						}
						break;
					case 3:
						component.paidForItsBelongings = true;
						GameData.Instance.dailyCustomers++;
						AchievementsManager.Instance.CmdAddAchievementPoint(3, 1);
						component2.destination = this.destroyPointsOBJ.transform.GetChild(Random.Range(0, this.destroyPointsOBJ.transform.childCount - 1)).transform.position;
						this.selfCheckoutOBJ.transform.GetChild(component.selfcheckoutIndex).GetComponent<Data_Container>().checkoutQueue[0] = false;
						component.state = 99;
						return;
					default:
						if (state == 99)
						{
							Object.Destroy(gameObject);
							return;
						}
						Debug.Log("npc case error selfcheckout");
						break;
					}
					return;
				}
				switch (state)
				{
				case 0:
				case 1:
				{
					component.selfcheckoutAssigned = true;
					int num5 = this.CheckForAFreeCheckout();
					if (num5 == -1)
					{
						component.isAThief = true;
						component.RPCNotificationAboveHead("NPCmessage3", "");
						component.StartWaitState(2f, 1);
						component.state = -1;
						return;
					}
					Transform transform = this.checkoutOBJ.transform.GetChild(num5).transform.Find("QueueAssign");
					component2.destination = transform.position;
					component.state = 2;
					return;
				}
				case 2:
				{
					int num6 = this.CheckForAFreeCheckout();
					if (num6 == -1)
					{
						component.state = 1;
						return;
					}
					int checkoutQueueNumber = this.GetCheckoutQueueNumber(num6);
					component.currentCheckoutIndex = num6;
					component.currentQueueNumber = checkoutQueueNumber;
					Transform child = this.checkoutOBJ.transform.GetChild(num6).transform.Find("QueuePositions").transform.GetChild(checkoutQueueNumber);
					component2.destination = child.position;
					component.state = 3;
					return;
				}
				case 3:
					if (component.currentQueueNumber == 0)
					{
						if (component.productsIDCarrying.Count == component.numberOfProductsCarried)
						{
							this.checkoutOBJ.transform.GetChild(component.currentCheckoutIndex).GetComponent<Data_Container>().NetworkproductsLeft = component.numberOfProductsCarried;
						}
						if (component.productsIDCarrying.Count == 0)
						{
							component.state = 4;
							return;
						}
						if (!component.placingProducts)
						{
							component.PlaceProducts(this.checkoutOBJ);
							component.placingProducts = true;
							return;
						}
						return;
					}
					else
					{
						int num7 = component.currentQueueNumber - 1;
						Data_Container component4 = this.checkoutOBJ.transform.GetChild(component.currentCheckoutIndex).GetComponent<Data_Container>();
						if (!component4.checkoutQueue[num7])
						{
							component4.checkoutQueue[component.currentQueueNumber] = false;
							component.currentQueueNumber = num7;
							component4.checkoutQueue[component.currentQueueNumber] = true;
							Transform child2 = this.checkoutOBJ.transform.GetChild(component.currentCheckoutIndex).transform.Find("QueuePositions").transform.GetChild(component.currentQueueNumber);
							component2.destination = child2.position;
							return;
						}
						return;
					}
					break;
				case 4:
					if (this.checkoutOBJ.transform.GetChild(component.currentCheckoutIndex).GetComponent<Data_Container>().productsLeft == 0)
					{
						component.state = 5;
						return;
					}
					return;
				case 5:
					if (!component.alreadyGaveMoney)
					{
						component.alreadyGaveMoney = true;
						int index = Random.Range(0, 2);
						this.checkoutOBJ.transform.GetChild(component.currentCheckoutIndex).GetComponent<Data_Container>().RpcShowPaymentMethod(index);
						return;
					}
					return;
				case 6:
				case 7:
				case 8:
				case 9:
					break;
				case 10:
					component.paidForItsBelongings = true;
					GameData.Instance.dailyCustomers++;
					AchievementsManager.Instance.CmdAddAchievementPoint(3, 1);
					component2.destination = this.destroyPointsOBJ.transform.GetChild(Random.Range(0, this.destroyPointsOBJ.transform.childCount - 1)).transform.position;
					component.state = 99;
					return;
				case 11:
					component2.destination = base.transform.Find("ThiefRoamSpots").transform.GetChild(Random.Range(0, base.transform.Find("ThiefRoamSpots").transform.childCount - 1)).transform.position + new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f));
					component.StartWaitState(1f, 12);
					component.state = -1;
					return;
				case 12:
					component2.destination = base.transform.Find("ThiefRoamSpots").transform.GetChild(Random.Range(0, base.transform.Find("ThiefRoamSpots").transform.childCount - 1)).transform.position + new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f));
					component.StartWaitState(1f, 13);
					component.state = -1;
					return;
				case 13:
					component2.destination = this.destroyPointsOBJ.transform.GetChild(Random.Range(0, this.destroyPointsOBJ.transform.childCount - 1)).transform.position;
					component.state = 99;
					return;
				default:
					if (state == 99)
					{
						Object.Destroy(gameObject);
						return;
					}
					break;
				}
				Debug.Log("npc case error 2");
			}
		}
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x00025218 File Offset: 0x00023418
	private int WhichShelfHasItem(int productID)
	{
		for (int i = 0; i < this.shelvesOBJ.transform.childCount; i++)
		{
			int[] productInfoArray = this.shelvesOBJ.transform.GetChild(i).gameObject.GetComponent<Data_Container>().productInfoArray;
			int num = productInfoArray.Length / 2;
			for (int j = 0; j < num; j++)
			{
				int num2 = productInfoArray[j * 2];
				int num3 = productInfoArray[j * 2 + 1];
				if (num2 == productID && num3 > 0)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x00025290 File Offset: 0x00023490
	private bool IsItemInShelf(int shelfToCheck, int productID)
	{
		if (shelfToCheck == -1)
		{
			Debug.Log("NPC IsItem InShelf Returning Shelf Error");
			return false;
		}
		int[] productInfoArray = this.shelvesOBJ.transform.GetChild(shelfToCheck).gameObject.GetComponent<Data_Container>().productInfoArray;
		int num = productInfoArray.Length / 2;
		for (int i = 0; i < num; i++)
		{
			int num2 = productInfoArray[i * 2];
			int num3 = productInfoArray[i * 2 + 1];
			if (num2 == productID && num3 != 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x000252FC File Offset: 0x000234FC
	private int CheckForAFreeCheckout()
	{
		int result = 0;
		int num = 100;
		bool flag = true;
		for (int i = 0; i < this.checkoutOBJ.transform.childCount; i++)
		{
			int num2 = 0;
			Data_Container component = this.checkoutOBJ.transform.GetChild(i).GetComponent<Data_Container>();
			bool[] checkoutQueue = component.checkoutQueue;
			if (!checkoutQueue[checkoutQueue.Length - 1] && !component.isCheckoutClosed)
			{
				bool[] array = checkoutQueue;
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j])
					{
						num2++;
					}
				}
				if (num2 != checkoutQueue.Length)
				{
					flag = false;
					if (num2 < num)
					{
						num = num2;
						result = i;
					}
				}
			}
		}
		if (flag)
		{
			return -1;
		}
		return result;
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x000253A4 File Offset: 0x000235A4
	private int GetCheckoutQueueNumber(int freeCheckoutIndex)
	{
		bool[] checkoutQueue = this.checkoutOBJ.transform.GetChild(freeCheckoutIndex).GetComponent<Data_Container>().checkoutQueue;
		int num = 69;
		for (int i = checkoutQueue.Length - 1; i >= 0; i--)
		{
			if (checkoutQueue[i])
			{
				checkoutQueue[num] = true;
				return num;
			}
			num = i;
		}
		checkoutQueue[0] = true;
		return 0;
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x000253F4 File Offset: 0x000235F4
	private int GetAvailableSelfCheckout(NPC_Info npcInfo)
	{
		if (npcInfo.productsIDCarrying.Count > 18 || npcInfo.productsIDCarrying.Count == 0)
		{
			return -1;
		}
		float time = Mathf.Clamp((float)(18 / npcInfo.productsIDCarrying.Count), 0f, 1f);
		if (this.selfcheckoutChanceCurve.Evaluate(time) < Random.value)
		{
			for (int i = 0; i < this.selfCheckoutOBJ.transform.childCount; i++)
			{
				if (!this.selfCheckoutOBJ.transform.GetChild(i).GetComponent<Data_Container>().checkoutQueue[0])
				{
					if (npcInfo.productsIDCarrying.Count > 6 && Random.value < 0.02f + (float)GameData.Instance.difficulty * 0.005f)
					{
						int index = Random.Range(0, npcInfo.productsIDCarrying.Count);
						npcInfo.productsIDCarrying.RemoveAt(index);
						npcInfo.productsCarryingPrice.RemoveAt(index);
					}
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x000254EA File Offset: 0x000236EA
	private IEnumerator SpawnDummyNCP()
	{
		this.dummySpawnCooldown = true;
		yield return new WaitForSeconds(Random.Range(1f, 6f));
		Vector3 position = this.spawnPointsOBJ.transform.GetChild(Random.Range(0, this.spawnPointsOBJ.transform.childCount - 1)).transform.position;
		GameObject gameObject = Object.Instantiate<GameObject>(this.npcAgentPrefab, position, Quaternion.identity);
		gameObject.transform.SetParent(this.dummynpcParentOBJ.transform);
		gameObject.GetComponent<NPC_Info>().NetworkNPCID = Random.Range(0, this.NPCsArray.Length - 1);
		NetworkServer.Spawn(gameObject, null);
		NavMeshAgent component = gameObject.GetComponent<NavMeshAgent>();
		component.enabled = true;
		component.destination = this.randomPointsOBJ.transform.GetChild(Random.Range(0, this.randomPointsOBJ.transform.childCount - 1)).transform.position;
		yield return new WaitForSeconds(0.3f);
		this.dummySpawnCooldown = false;
		yield break;
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x000254FC File Offset: 0x000236FC
	private void DummyNPCControl()
	{
		if (this.dummynpcParentOBJ.transform.childCount > 0)
		{
			for (int i = 0; i < this.dummynpcParentOBJ.transform.childCount; i++)
			{
				GameObject gameObject = this.dummynpcParentOBJ.transform.GetChild(i).gameObject;
				NPC_Info component = gameObject.GetComponent<NPC_Info>();
				int state = component.state;
				NavMeshAgent component2 = gameObject.GetComponent<NavMeshAgent>();
				if (state != -1 && !component2.pathPending && component2.remainingDistance <= component2.stoppingDistance && (!component2.hasPath || component2.velocity.sqrMagnitude == 0f))
				{
					if (state == 0)
					{
						component.StartWaitState(Random.Range(4f, 12f), 1);
					}
					else if (state == 1)
					{
						component2.destination = this.destroyPointsOBJ.transform.GetChild(Random.Range(0, this.destroyPointsOBJ.transform.childCount - 1)).transform.position;
						component.state = 99;
					}
					else if (state == 99)
					{
						Object.Destroy(gameObject);
					}
				}
			}
		}
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x00025620 File Offset: 0x00023820
	public void SetEmployeesHats(int hatIndex)
	{
		if (!base.isServer || this.employeeParentOBJ.transform.childCount == 0)
		{
			return;
		}
		foreach (object obj in this.employeeParentOBJ.transform)
		{
			((Transform)obj).GetComponent<NPC_Info>().ChangeEmployeeHat(hatIndex);
		}
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x0002573F File Offset: 0x0002393F
	protected void UserCode_CmdUpdateRecycleStatus()
	{
		this.interruptBoxRecycling = !this.interruptBoxRecycling;
		this.RpcUpdateRecycleStatus(this.interruptBoxRecycling);
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x0002575C File Offset: 0x0002395C
	protected static void InvokeUserCode_CmdUpdateRecycleStatus(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateRecycleStatus called on client.");
			return;
		}
		((NPC_Manager)obj).UserCode_CmdUpdateRecycleStatus();
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0002577F File Offset: 0x0002397F
	protected void UserCode_CmdRequestRecycleStatus()
	{
		this.RpcUpdateRecycleStatus(this.interruptBoxRecycling);
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x0002578D File Offset: 0x0002398D
	protected static void InvokeUserCode_CmdRequestRecycleStatus(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestRecycleStatus called on client.");
			return;
		}
		((NPC_Manager)obj).UserCode_CmdRequestRecycleStatus();
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x000257B0 File Offset: 0x000239B0
	protected void UserCode_RpcUpdateRecycleStatus__Boolean(bool value)
	{
		if (!base.isServer)
		{
			this.interruptBoxRecycling = value;
		}
		if (this.interruptBoxRecycling)
		{
			this.interruptRecyclingButtonOBJ.GetComponent<Image>().color = Color.green;
			this.interruptRecyclingButtonOBJ.GetComponent<Image>().sprite = this.buttonOn;
			this.interruptRecyclingButtonOBJ.transform.Find("Highlight").GetComponent<Image>().sprite = this.buttonOn;
			return;
		}
		this.interruptRecyclingButtonOBJ.GetComponent<Image>().color = Color.red;
		this.interruptRecyclingButtonOBJ.GetComponent<Image>().sprite = this.buttonOff;
		this.interruptRecyclingButtonOBJ.transform.Find("Highlight").GetComponent<Image>().sprite = this.buttonOff;
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x00025875 File Offset: 0x00023A75
	protected static void InvokeUserCode_RpcUpdateRecycleStatus__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateRecycleStatus called on server.");
			return;
		}
		((NPC_Manager)obj).UserCode_RpcUpdateRecycleStatus__Boolean(reader.ReadBool());
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x000258A0 File Offset: 0x00023AA0
	protected void UserCode_CmdAlterPriority__Int32__Boolean(int priorityIndex, bool Add)
	{
		if (Add && this.checkoutPriority + this.restockPriority + this.storagePriority + this.securityPriority == this.maxEmployees)
		{
			return;
		}
		if (!Add && this.checkoutPriority + this.restockPriority + this.storagePriority + this.securityPriority == 0)
		{
			return;
		}
		int num = Add ? 1 : -1;
		switch (priorityIndex)
		{
		case 0:
			if (!Add && this.checkoutPriority == 0)
			{
				return;
			}
			if (Add && this.checkoutPriority >= this.checkoutOBJ.transform.childCount)
			{
				return;
			}
			this.checkoutPriority += num;
			break;
		case 1:
			if (!Add && this.restockPriority == 0)
			{
				return;
			}
			this.restockPriority += num;
			break;
		case 2:
			if (!Add && this.storagePriority == 0)
			{
				return;
			}
			this.storagePriority += num;
			break;
		case 3:
			if (!Add && this.securityPriority == 0)
			{
				return;
			}
			this.securityPriority += num;
			break;
		}
		this.AssignEmployeePriorities();
		this.RpcUpdateBlackboard(this.checkoutPriority, this.restockPriority, this.storagePriority, this.securityPriority);
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x000259C6 File Offset: 0x00023BC6
	protected static void InvokeUserCode_CmdAlterPriority__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAlterPriority called on client.");
			return;
		}
		((NPC_Manager)obj).UserCode_CmdAlterPriority__Int32__Boolean(reader.ReadInt(), reader.ReadBool());
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x000259F8 File Offset: 0x00023BF8
	protected void UserCode_RpcUpdateBlackboard__Int32__Int32__Int32__Int32(int checkout, int restock, int storage, int security)
	{
		this.employeesBlackboardOBJ.transform.Find("Container/CashiersNumber").GetComponent<TextMeshProUGUI>().text = checkout.ToString();
		this.employeesBlackboardOBJ.transform.Find("Container/RestockNumber").GetComponent<TextMeshProUGUI>().text = restock.ToString();
		this.employeesBlackboardOBJ.transform.Find("Container/StorageNumber").GetComponent<TextMeshProUGUI>().text = storage.ToString();
		this.employeesBlackboardOBJ.transform.Find("Container/SecurityNumber").GetComponent<TextMeshProUGUI>().text = security.ToString();
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x00025A9D File Offset: 0x00023C9D
	protected static void InvokeUserCode_RpcUpdateBlackboard__Int32__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateBlackboard called on server.");
			return;
		}
		((NPC_Manager)obj).UserCode_RpcUpdateBlackboard__Int32__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x00025AD8 File Offset: 0x00023CD8
	static NPC_Manager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NPC_Manager), "System.Void NPC_Manager::CmdUpdateRecycleStatus()", new RemoteCallDelegate(NPC_Manager.InvokeUserCode_CmdUpdateRecycleStatus), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NPC_Manager), "System.Void NPC_Manager::CmdRequestRecycleStatus()", new RemoteCallDelegate(NPC_Manager.InvokeUserCode_CmdRequestRecycleStatus), false);
		RemoteProcedureCalls.RegisterCommand(typeof(NPC_Manager), "System.Void NPC_Manager::CmdAlterPriority(System.Int32,System.Boolean)", new RemoteCallDelegate(NPC_Manager.InvokeUserCode_CmdAlterPriority__Int32__Boolean), false);
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Manager), "System.Void NPC_Manager::RpcUpdateRecycleStatus(System.Boolean)", new RemoteCallDelegate(NPC_Manager.InvokeUserCode_RpcUpdateRecycleStatus__Boolean));
		RemoteProcedureCalls.RegisterRpc(typeof(NPC_Manager), "System.Void NPC_Manager::RpcUpdateBlackboard(System.Int32,System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(NPC_Manager.InvokeUserCode_RpcUpdateBlackboard__Int32__Int32__Int32__Int32));
	}

	// Token: 0x0400042B RID: 1067
	public static NPC_Manager Instance;

	// Token: 0x0400042C RID: 1068
	public int maxDummyNPCs;

	// Token: 0x0400042D RID: 1069
	public GameObject[] NPCsArray;

	// Token: 0x0400042E RID: 1070
	public bool interruptBoxRecycling;

	// Token: 0x0400042F RID: 1071
	public Sprite buttonOff;

	// Token: 0x04000430 RID: 1072
	public Sprite buttonOn;

	// Token: 0x04000431 RID: 1073
	public AnimationCurve selfcheckoutChanceCurve;

	// Token: 0x04000432 RID: 1074
	[Space(10f)]
	public GameObject[] NPCsEmployeesArray;

	// Token: 0x04000433 RID: 1075
	public GameObject employeeParentOBJ;

	// Token: 0x04000434 RID: 1076
	public GameObject restSpotOBJ;

	// Token: 0x04000435 RID: 1077
	public GameObject employeeSpawnpoint;

	// Token: 0x04000436 RID: 1078
	public GameObject trashSpotOBJ;

	// Token: 0x04000437 RID: 1079
	public GameObject recycleSpot1OBJ;

	// Token: 0x04000438 RID: 1080
	public GameObject recycleSpot2OBJ;

	// Token: 0x04000439 RID: 1081
	public GameObject leftoverBoxesSpotOBJ;

	// Token: 0x0400043A RID: 1082
	public GameObject employeesBlackboardOBJ;

	// Token: 0x0400043B RID: 1083
	public GameObject patrolPositionOBJ;

	// Token: 0x0400043C RID: 1084
	public GameObject droppedProductsParentOBJ;

	// Token: 0x0400043D RID: 1085
	public GameObject interruptRecyclingButtonOBJ;

	// Token: 0x0400043E RID: 1086
	public int maxEmployees;

	// Token: 0x0400043F RID: 1087
	public float extraEmployeeSpeedFactor;

	// Token: 0x04000440 RID: 1088
	public float extraCheckoutMoney = 1f;

	// Token: 0x04000441 RID: 1089
	public float employeeItemPlaceWait = 0.2f;

	// Token: 0x04000442 RID: 1090
	public float productCheckoutWait = 0.75f;

	// Token: 0x04000443 RID: 1091
	public bool employeeRecycleBoxes;

	// Token: 0x04000444 RID: 1092
	public int checkoutPriority;

	// Token: 0x04000445 RID: 1093
	public int restockPriority;

	// Token: 0x04000446 RID: 1094
	public int storagePriority;

	// Token: 0x04000447 RID: 1095
	public int securityPriority;

	// Token: 0x04000448 RID: 1096
	private List<int> employeePriorities = new List<int>();

	// Token: 0x04000449 RID: 1097
	private List<string> productsPriority = new List<string>();

	// Token: 0x0400044A RID: 1098
	private List<string> productsPrioritySecondary = new List<string>();

	// Token: 0x0400044B RID: 1099
	private List<string> auxiliarList = new List<string>();

	// Token: 0x0400044C RID: 1100
	private List<GameObject> indexedBoxesList = new List<GameObject>();

	// Token: 0x0400044D RID: 1101
	private List<int> indexedBoxIDsList = new List<int>();

	// Token: 0x0400044E RID: 1102
	private List<GameObject> thievesList = new List<GameObject>();

	// Token: 0x0400044F RID: 1103
	private float[] productsThreshholdArray = new float[]
	{
		0.25f,
		0.5f,
		0.75f,
		1f
	};

	// Token: 0x04000450 RID: 1104
	private List<int> employeesCheckoutIndexes = new List<int>();

	// Token: 0x04000451 RID: 1105
	[Space(10f)]
	public GameObject dummynpcParentOBJ;

	// Token: 0x04000452 RID: 1106
	public GameObject customersnpcParentOBJ;

	// Token: 0x04000453 RID: 1107
	public GameObject spawnPointsOBJ;

	// Token: 0x04000454 RID: 1108
	public GameObject destroyPointsOBJ;

	// Token: 0x04000455 RID: 1109
	public GameObject randomPointsOBJ;

	// Token: 0x04000456 RID: 1110
	public Transform exitPoints;

	// Token: 0x04000457 RID: 1111
	[Space(10f)]
	public GameObject shelvesOBJ;

	// Token: 0x04000458 RID: 1112
	public GameObject checkoutOBJ;

	// Token: 0x04000459 RID: 1113
	public GameObject storageOBJ;

	// Token: 0x0400045A RID: 1114
	public GameObject boxesOBJ;

	// Token: 0x0400045B RID: 1115
	public GameObject selfCheckoutOBJ;

	// Token: 0x0400045C RID: 1116
	[Space(10f)]
	public GameObject npcAgentPrefab;

	// Token: 0x0400045D RID: 1117
	public GameObject productCheckoutPrefab;

	// Token: 0x0400045E RID: 1118
	private bool dummySpawnCooldown;

	// Token: 0x0400045F RID: 1119
	private bool spawnCooldown;

	// Token: 0x04000460 RID: 1120
	private bool coroutinePlaying;

	// Token: 0x04000461 RID: 1121
	public int counter;

	// Token: 0x04000462 RID: 1122
	private int counter2;
}

using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class NPC_Speed : MonoBehaviour
{
	// Token: 0x06000579 RID: 1401 RVA: 0x000261FA File Offset: 0x000243FA
	private void Start()
	{
		base.StartCoroutine(this.CalculateVelocity());
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x00026209 File Offset: 0x00024409
	private IEnumerator CalculateVelocity()
	{
		while (Application.isPlaying)
		{
			Vector3 prevPos = base.transform.position;
			yield return new WaitForEndOfFrame();
			this.velocity = (prevPos - base.transform.position).magnitude / Time.deltaTime;
			this.velocity = Mathf.Round(this.velocity * 10f) / 10f;
			prevPos = default(Vector3);
		}
		yield break;
	}

	// Token: 0x0400046F RID: 1135
	public float velocity;
}

using System;
using UnityEngine;

// Token: 0x0200009E RID: 158
public class OnEnableSetParent : MonoBehaviour
{
	// Token: 0x06000582 RID: 1410 RVA: 0x000262E7 File Offset: 0x000244E7
	private void OnEnable()
	{
		base.transform.parent = base.transform.parent.transform;
	}
}

using System;
using UnityEngine;

// Token: 0x0200009F RID: 159
public class Paintable : MonoBehaviour
{
}

using System;
using HighlightPlus;
using UnityEngine;

// Token: 0x020000A0 RID: 160
public class PaintableAuxiliarHighlight : MonoBehaviour
{
	// Token: 0x06000585 RID: 1413 RVA: 0x00026304 File Offset: 0x00024504
	private void Start()
	{
		this.lMask = LayerMask.GetMask(new string[]
		{
			"Default"
		});
		this.hEffect = base.gameObject.AddComponent<HighlightEffect>();
		this.hEffect.outline = 0f;
		this.hEffect.glow = 1f;
		this.hEffect.glowWidth = 1.5f;
		this.hEffect.glowQuality = HighlightPlus.QualityLevel.Highest;
		this.hEffect.highlighted = true;
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x00026388 File Offset: 0x00024588
	private void Update()
	{
		RaycastHit raycastHit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
		{
			if (raycastHit.transform.gameObject != base.gameObject)
			{
				this.DestroyBehaviours();
				return;
			}
		}
		else
		{
			this.DestroyBehaviours();
		}
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x000263F2 File Offset: 0x000245F2
	public void DestroyBehaviours()
	{
		if (this.hEffect)
		{
			Object.Destroy(this.hEffect);
		}
		Object.Destroy(this);
	}

	// Token: 0x04000474 RID: 1140
	[SerializeField]
	private LayerMask lMask;

	// Token: 0x04000475 RID: 1141
	private HighlightEffect hEffect;
}

using System;
using UnityEngine;

// Token: 0x020000A1 RID: 161
public class PaintableData : MonoBehaviour
{
	// Token: 0x04000476 RID: 1142
	public Material material;

	// Token: 0x04000477 RID: 1143
	public float price = 50f;

	// Token: 0x04000478 RID: 1144
	public Color[] ColorArray = new Color[]
	{
		Color.white
	};

	// Token: 0x04000479 RID: 1145
	public bool allowCustomColors;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class PaintablesManager : NetworkBehaviour
{
	// Token: 0x0600058A RID: 1418 RVA: 0x0002643D File Offset: 0x0002463D
	public override void OnStartClient()
	{
		this.mainPaintableData = this.materialsDataRootOBJ.GetComponent<PaintableData>();
		this.InitAssignPaintables();
		base.StartCoroutine(this.InitAssignMaterials());
	}

	// Token: 0x0600058B RID: 1419 RVA: 0x00026464 File Offset: 0x00024664
	private void InitAssignPaintables()
	{
		foreach (object obj in this.paintablesRootOBJ.transform)
		{
			((Transform)obj).gameObject.AddComponent<Paintable>();
		}
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x000264C8 File Offset: 0x000246C8
	private IEnumerator InitAssignMaterials()
	{
		yield return new WaitForSeconds(8.5f);
		int num2;
		for (int i = 0; i < this.paintablesValuesArray.Length; i = num2 + 1)
		{
			string text = this.paintablesValuesArray[i];
			if (!(text == ""))
			{
				if (!this.paintablesRootOBJ.transform.GetChild(i).gameObject)
				{
					yield return null;
					break;
				}
				GameObject gameObject = this.paintablesRootOBJ.transform.GetChild(i).gameObject;
				string[] array = text.Split("|", StringSplitOptions.None);
				for (int j = 0; j < array.Length; j++)
				{
					string text2 = array[j];
					if (!(text2 == ""))
					{
						if (!gameObject.transform.GetChild(j))
						{
							break;
						}
						string[] array2 = text2.Split("_", StringSplitOptions.None);
						int index = int.Parse(array2[0]);
						if (!this.materialsDataRootOBJ.transform.GetChild(index))
						{
							break;
						}
						int num = int.Parse(array2[1]);
						MeshRenderer component = gameObject.transform.GetChild(j).GetComponent<MeshRenderer>();
						component.material = this.materialsDataRootOBJ.transform.GetChild(index).GetComponent<PaintableData>().material;
						if (num > 0 && num < this.mainPaintableData.ColorArray.Length)
						{
							component.material.SetColor("_BaseColor", this.mainPaintableData.ColorArray[num]);
						}
					}
				}
				yield return null;
			}
			num2 = i;
		}
		yield break;
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x000264D8 File Offset: 0x000246D8
	[Command(requiresAuthority = false)]
	public void CmdUpdateSingleParentMaterial(int parentIndex, int particularOBJIndex, int materialIndex, int colorIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(parentIndex);
		writer.WriteInt(particularOBJIndex);
		writer.WriteInt(materialIndex);
		writer.WriteInt(colorIndex);
		base.SendCommandInternal("System.Void PaintablesManager::CmdUpdateSingleParentMaterial(System.Int32,System.Int32,System.Int32,System.Int32)", 1648917459, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x00026530 File Offset: 0x00024730
	[ClientRpc]
	private void RpcUpdateSingleParentMaterial(string stringValue, int parentIndex, int particularOBJIndex, int materialIndex, int colorIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(stringValue);
		writer.WriteInt(parentIndex);
		writer.WriteInt(particularOBJIndex);
		writer.WriteInt(materialIndex);
		writer.WriteInt(colorIndex);
		this.SendRPCInternal("System.Void PaintablesManager::RpcUpdateSingleParentMaterial(System.String,System.Int32,System.Int32,System.Int32,System.Int32)", -59225074, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000094 RID: 148
	// (get) Token: 0x06000591 RID: 1425 RVA: 0x00026594 File Offset: 0x00024794
	// (set) Token: 0x06000592 RID: 1426 RVA: 0x000265A7 File Offset: 0x000247A7
	public string[] NetworkpaintablesValuesArray
	{
		get
		{
			return this.paintablesValuesArray;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<string[]>(value, ref this.paintablesValuesArray, 1UL, null);
		}
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x000265C4 File Offset: 0x000247C4
	protected void UserCode_CmdUpdateSingleParentMaterial__Int32__Int32__Int32__Int32(int parentIndex, int particularOBJIndex, int materialIndex, int colorIndex)
	{
		if (!this.paintablesRootOBJ.transform.GetChild(parentIndex).gameObject || parentIndex >= this.paintablesValuesArray.Length)
		{
			return;
		}
		GameObject gameObject = this.paintablesRootOBJ.transform.GetChild(parentIndex).gameObject;
		StringBuilder stringBuilder = new StringBuilder();
		string text;
		if (this.paintablesValuesArray[parentIndex] == "")
		{
			for (int i = 0; i < gameObject.transform.childCount - 1; i++)
			{
				stringBuilder.Append("|");
			}
			text = stringBuilder.ToString();
		}
		else
		{
			text = this.paintablesValuesArray[parentIndex];
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		string[] array = text.Split("|", StringSplitOptions.None);
		for (int j = 0; j < array.Length; j++)
		{
			if (j == particularOBJIndex)
			{
				string value = materialIndex.ToString() + "_" + colorIndex.ToString();
				stringBuilder2.Append(value);
			}
			else
			{
				stringBuilder2.Append(array[j]);
			}
			if (j != array.Length - 1)
			{
				stringBuilder2.Append("|");
			}
		}
		this.paintablesValuesArray[parentIndex] = stringBuilder2.ToString();
		this.RpcUpdateSingleParentMaterial(stringBuilder2.ToString(), parentIndex, particularOBJIndex, materialIndex, colorIndex);
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x000266F7 File Offset: 0x000248F7
	protected static void InvokeUserCode_CmdUpdateSingleParentMaterial__Int32__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateSingleParentMaterial called on client.");
			return;
		}
		((PaintablesManager)obj).UserCode_CmdUpdateSingleParentMaterial__Int32__Int32__Int32__Int32(reader.ReadInt(), reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00026734 File Offset: 0x00024934
	protected void UserCode_RpcUpdateSingleParentMaterial__String__Int32__Int32__Int32__Int32(string stringValue, int parentIndex, int particularOBJIndex, int materialIndex, int colorIndex)
	{
		if (!base.isServer)
		{
			this.paintablesValuesArray[parentIndex] = stringValue;
		}
		MeshRenderer component = this.paintablesRootOBJ.transform.GetChild(parentIndex).gameObject.transform.GetChild(particularOBJIndex).GetComponent<MeshRenderer>();
		component.material = this.materialsDataRootOBJ.transform.GetChild(materialIndex).GetComponent<PaintableData>().material;
		if (colorIndex > 0 && colorIndex < this.mainPaintableData.ColorArray.Length)
		{
			component.material.SetColor("_BaseColor", this.mainPaintableData.ColorArray[colorIndex]);
			return;
		}
		component.material.SetColor("_BaseColor", this.materialsDataRootOBJ.transform.GetChild(materialIndex).GetComponent<PaintableData>().ColorArray[0]);
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x00026808 File Offset: 0x00024A08
	protected static void InvokeUserCode_RpcUpdateSingleParentMaterial__String__Int32__Int32__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateSingleParentMaterial called on server.");
			return;
		}
		((PaintablesManager)obj).UserCode_RpcUpdateSingleParentMaterial__String__Int32__Int32__Int32__Int32(reader.ReadString(), reader.ReadInt(), reader.ReadInt(), reader.ReadInt(), reader.ReadInt());
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x00026854 File Offset: 0x00024A54
	static PaintablesManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PaintablesManager), "System.Void PaintablesManager::CmdUpdateSingleParentMaterial(System.Int32,System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(PaintablesManager.InvokeUserCode_CmdUpdateSingleParentMaterial__Int32__Int32__Int32__Int32), false);
		RemoteProcedureCalls.RegisterRpc(typeof(PaintablesManager), "System.Void PaintablesManager::RpcUpdateSingleParentMaterial(System.String,System.Int32,System.Int32,System.Int32,System.Int32)", new RemoteCallDelegate(PaintablesManager.InvokeUserCode_RpcUpdateSingleParentMaterial__String__Int32__Int32__Int32__Int32));
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x000268A4 File Offset: 0x00024AA4
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			Mirror.GeneratedNetworkCode._Write_System.String[](writer, this.paintablesValuesArray);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.String[](writer, this.paintablesValuesArray);
		}
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x000268FC File Offset: 0x00024AFC
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<string[]>(ref this.paintablesValuesArray, null, Mirror.GeneratedNetworkCode._Read_System.String[](reader));
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<string[]>(ref this.paintablesValuesArray, null, Mirror.GeneratedNetworkCode._Read_System.String[](reader));
		}
	}

	// Token: 0x0400047A RID: 1146
	[SyncVar]
	public string[] paintablesValuesArray;

	// Token: 0x0400047B RID: 1147
	public GameObject materialsDataRootOBJ;

	// Token: 0x0400047C RID: 1148
	public GameObject paintablesRootOBJ;

	// Token: 0x0400047D RID: 1149
	private PaintableData mainPaintableData;
}

using System;

// Token: 0x02000008 RID: 8
public enum PathType
{
	// Token: 0x04000040 RID: 64
	PeoplePath,
	// Token: 0x04000041 RID: 65
	AudiencePath
}

using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class PeopleController : MonoBehaviour
{
	// Token: 0x0600002D RID: 45 RVA: 0x000049B5 File Offset: 0x00002BB5
	private void Start()
	{
		this.Tick();
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000049C0 File Offset: 0x00002BC0
	private void Tick()
	{
		this.timer = 0f;
		int num = Random.Range(0, this.animNames.Length);
		this.SetAnimClip(this.animNames[num]);
		this.timer = Random.Range(3f, 5f);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00004A0C File Offset: 0x00002C0C
	public void SetTarget(Vector3 _target)
	{
		Vector3 worldPosition = new Vector3(_target.x, base.transform.position.y, _target.z);
		base.transform.LookAt(worldPosition);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00004A48 File Offset: 0x00002C48
	private void Update()
	{
		if (this.timer >= 0f)
		{
			this.timer -= Time.deltaTime;
		}
		else
		{
			this.Tick();
		}
		if (this.target != null)
		{
			Vector3 forward = this.target.position - base.transform.position;
			forward.y = 0f;
			Quaternion b = Quaternion.LookRotation(forward);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * this.damping);
		}
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00004AE1 File Offset: 0x00002CE1
	public void SetAnimClip(string animName)
	{
		base.GetComponent<Animator>().CrossFade(animName, 0.1f, 0, Random.Range(0f, 1f));
	}

	// Token: 0x04000070 RID: 112
	[HideInInspector]
	public float timer;

	// Token: 0x04000071 RID: 113
	[HideInInspector]
	public string[] animNames;

	// Token: 0x04000072 RID: 114
	[HideInInspector]
	public float damping;

	// Token: 0x04000073 RID: 115
	[HideInInspector]
	public Transform target;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class PeopleWalkPath : WalkPath
{
	// Token: 0x06000017 RID: 23 RVA: 0x00003908 File Offset: 0x00001B08
	public override void DrawCurved(bool withDraw)
	{
		if (this.numberOfWays < 1)
		{
			this.numberOfWays = 1;
		}
		if (this.lineSpacing < 0.6f)
		{
			this.lineSpacing = 0.6f;
		}
		this._forward = new bool[this.numberOfWays];
		this.isWalk = (this._moveType.ToString() == "Walk");
		for (int i = 0; i < this.numberOfWays; i++)
		{
			if (this.direction.ToString() == "Forward")
			{
				this._forward[i] = true;
			}
			else if (this.direction.ToString() == "Backward")
			{
				this._forward[i] = false;
			}
			else if (this.direction.ToString() == "HugLeft")
			{
				if ((i + 2) % 2 == 0)
				{
					this._forward[i] = true;
				}
				else
				{
					this._forward[i] = false;
				}
			}
			else if (this.direction.ToString() == "HugRight")
			{
				if ((i + 2) % 2 == 0)
				{
					this._forward[i] = false;
				}
				else
				{
					this._forward[i] = true;
				}
			}
			else if (this.direction.ToString() == "WeaveLeft")
			{
				if (i == 1 || i == 2 || (i - 1) % 4 == 0 || (i - 2) % 4 == 0)
				{
					this._forward[i] = false;
				}
				else
				{
					this._forward[i] = true;
				}
			}
			else if (this.direction.ToString() == "WeaveRight")
			{
				if (i == 1 || i == 2 || (i - 1) % 4 == 0 || (i - 2) % 4 == 0)
				{
					this._forward[i] = true;
				}
				else
				{
					this._forward[i] = false;
				}
			}
		}
		if (this.pathPoint.Count < 2)
		{
			return;
		}
		this.points = new Vector3[this.numberOfWays, this.pathPoint.Count + 2];
		this.pointLength[0] = this.pathPoint.Count + 2;
		for (int j = 0; j < this.pathPointTransform.Count; j++)
		{
			Vector3 a;
			Vector3 b;
			if (j == 0)
			{
				if (this.loopPath)
				{
					a = this.pathPointTransform[this.pathPointTransform.Count - 1].transform.position - this.pathPointTransform[j].transform.position;
				}
				else
				{
					a = Vector3.zero;
				}
				b = this.pathPointTransform[j].transform.position - this.pathPointTransform[j + 1].transform.position;
			}
			else if (j == this.pathPointTransform.Count - 1)
			{
				a = this.pathPointTransform[j - 1].transform.position - this.pathPointTransform[j].transform.position;
				if (this.loopPath)
				{
					b = this.pathPointTransform[j].transform.position - this.pathPointTransform[0].transform.position;
				}
				else
				{
					b = Vector3.zero;
				}
			}
			else
			{
				a = this.pathPointTransform[j - 1].transform.position - this.pathPointTransform[j].transform.position;
				b = this.pathPointTransform[j].transform.position - this.pathPointTransform[j + 1].transform.position;
			}
			Vector3 a2 = Vector3.Normalize(Quaternion.Euler(0f, 90f, 0f) * (a + b));
			this.points[0, j + 1] = ((this.numberOfWays % 2 == 1) ? this.pathPointTransform[j].transform.position : (this.pathPointTransform[j].transform.position + a2 * this.lineSpacing / 2f));
			if (this.numberOfWays > 1)
			{
				this.points[1, j + 1] = this.points[0, j + 1] - a2 * this.lineSpacing;
			}
			for (int k = 1; k < this.numberOfWays; k++)
			{
				this.points[k, j + 1] = this.points[0, j + 1] + a2 * this.lineSpacing * (float)Math.Pow(-1.0, (double)k) * (float)((k + 1) / 2);
			}
		}
		for (int l = 0; l < this.numberOfWays; l++)
		{
			this.points[l, 0] = this.points[l, 1];
			this.points[l, this.pointLength[0] - 1] = this.points[l, this.pointLength[0] - 2];
		}
		if (withDraw)
		{
			for (int m = 0; m < this.numberOfWays; m++)
			{
				if (this.loopPath)
				{
					Gizmos.color = (this._forward[m] ? Color.green : Color.red);
					Gizmos.DrawLine(this.points[m, 0], this.points[m, this.pathPoint.Count]);
				}
				for (int n = 1; n < this.pathPoint.Count; n++)
				{
					Gizmos.color = (this._forward[m] ? Color.green : Color.red);
					Gizmos.DrawLine(this.points[m, n + 1], this.points[m, n]);
				}
			}
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00003F24 File Offset: 0x00002124
	public override void SpawnOnePeople(int w, bool forward, float walkSpeed, float runSpeed)
	{
		int num = Random.Range(0, this.peoplePrefabs.Length);
		GameObject gameObject = base.gameObject;
		if (!forward)
		{
			gameObject = Object.Instantiate<GameObject>(this.peoplePrefabs[num], this.points[w, this.pointLength[0] - 2], Quaternion.identity);
		}
		else
		{
			gameObject = Object.Instantiate<GameObject>(this.peoplePrefabs[num], this.points[w, 1], Quaternion.identity);
		}
		MovePath movePath = gameObject.AddComponent<MovePath>();
		movePath.randXFinish = Random.Range(-this.randXPos, this.randXPos);
		movePath.randZFinish = Random.Range(-this.randZPos, this.randZPos);
		gameObject.transform.parent = this.par.transform;
		movePath.walkPath = base.gameObject;
		string anim;
		if (this.isWalk)
		{
			anim = "walk";
		}
		else
		{
			anim = "run";
		}
		movePath.InitializeAnimation(this._overrideDefaultAnimationMultiplier, this._customWalkAnimationMultiplier, this._customRunAnimationMultiplier);
		if (!forward)
		{
			movePath.MyStart(w, this.pointLength[0] - 2, anim, this.loopPath, forward, walkSpeed, runSpeed);
			gameObject.transform.LookAt(this.points[w, this.pointLength[0] - 3]);
			return;
		}
		movePath.MyStart(w, 1, anim, this.loopPath, forward, walkSpeed, runSpeed);
		gameObject.transform.LookAt(this.points[w, 2]);
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00004088 File Offset: 0x00002288
	public override void SpawnPeople()
	{
		List<GameObject> list = new List<GameObject>(this.peoplePrefabs);
		for (int i = list.Count - 1; i >= 0; i--)
		{
			if (list[i] == null)
			{
				list.RemoveAt(i);
			}
		}
		this.peoplePrefabs = list.ToArray();
		if (this.points == null)
		{
			this.DrawCurved(false);
		}
		if (this.par == null)
		{
			this.par = new GameObject();
			this.par.transform.parent = base.gameObject.transform;
			this.par.name = "people";
		}
		int num;
		if (!this.loopPath)
		{
			num = this.pointLength[0] - 2;
		}
		else
		{
			num = this.pointLength[0] - 1;
		}
		if (num < 2)
		{
			return;
		}
		int num2 = this.loopPath ? (this.pointLength[0] - 1) : (this.pointLength[0] - 2);
		for (int j = 0; j < this.numberOfWays; j++)
		{
			this._distances = new float[num2];
			float num3 = 0f;
			for (int k = 1; k < num2; k++)
			{
				Vector3 vector;
				if (this.loopPath && k == num2 - 1)
				{
					vector = this.points[j, 1] - this.points[j, num2];
				}
				else
				{
					vector = this.points[j, k + 1] - this.points[j, k];
				}
				num3 += vector.magnitude;
				this._distances[k] = num3;
			}
			bool forward = false;
			string a = this.direction.ToString();
			if (!(a == "Forward"))
			{
				if (!(a == "Backward"))
				{
					if (!(a == "HugLeft"))
					{
						if (!(a == "HugRight"))
						{
							if (!(a == "WeaveLeft"))
							{
								if (a == "WeaveRight")
								{
									forward = (j == 1 || j == 2 || (j - 1) % 4 == 0 || (j - 2) % 4 == 0);
								}
							}
							else
							{
								forward = (j != 1 && j != 2 && (j - 1) % 4 != 0 && (j - 2) % 4 != 0);
							}
						}
						else
						{
							forward = ((j + 2) % 2 != 0);
						}
					}
					else
					{
						forward = ((j + 2) % 2 == 0);
					}
				}
				else
				{
					forward = false;
				}
			}
			else
			{
				forward = true;
			}
			int num4 = Mathf.FloorToInt(this.Density * num3 / this._minimalObjectLength);
			float num5 = this._minimalObjectLength + (num3 - (float)num4 * this._minimalObjectLength) / (float)num4;
			int[] randomPrefabIndexes = CommonUtils.GetRandomPrefabIndexes(num4, ref this.peoplePrefabs);
			Vector3[] array = new Vector3[this._distances.Length];
			for (int l = 1; l < this._distances.Length; l++)
			{
				array[l - 1] = this.points[j, l];
			}
			array[this._distances.Length - 1] = (this.loopPath ? this.points[j, 1] : this.points[j, this._distances.Length]);
			for (int m = 0; m < num4; m++)
			{
				GameObject gameObject = base.gameObject;
				float num6 = Random.Range(-num5 / 3f, num5 / 3f) + (float)j * num5;
				float distance = (float)(m + 1) * num5 + num6;
				Vector3 routePosition = base.GetRoutePosition(array, distance, num2, this.loopPath);
				float num7 = Random.Range(-this.randXPos, this.randXPos);
				float num8 = Random.Range(-this.randZPos, this.randZPos);
				routePosition = new Vector3(routePosition.x + num7, routePosition.y, routePosition.z + num8);
				Vector3 vector2 = new Vector3(routePosition.x, routePosition.y + 10000f, routePosition.z);
				RaycastHit[] array2 = Physics.RaycastAll(vector2, Vector3.down, float.PositiveInfinity);
				float num9 = 0f;
				int num10 = 0;
				vector2 = new Vector3(routePosition.x, routePosition.y + 10000f, routePosition.z);
				array2 = Physics.RaycastAll(vector2, Vector3.down, float.PositiveInfinity);
				for (int n = 0; n < array2.Length; n++)
				{
					if (num9 < Vector3.Distance(array2[0].point, vector2))
					{
						num10 = n;
						num9 = Vector3.Distance(array2[0].point, vector2);
					}
				}
				if (array2.Length != 0)
				{
					routePosition.y = array2[num10].point.y;
				}
				gameObject = Object.Instantiate<GameObject>(this.peoplePrefabs[randomPrefabIndexes[m]], routePosition, Quaternion.identity);
				MovePath movePath = gameObject.AddComponent<MovePath>();
				movePath.randXFinish = num7;
				movePath.randZFinish = num8;
				gameObject.transform.parent = this.par.transform;
				movePath.walkPath = base.gameObject;
				string anim;
				if (this.isWalk)
				{
					anim = "walk";
				}
				else
				{
					anim = "run";
				}
				movePath.MyStart(j, base.GetRoutePoint((float)(m + 1) * num5 + num6, j, num2, forward, this.loopPath), anim, this.loopPath, forward, this.walkSpeed, this.runSpeed);
				movePath.InitializeAnimation(this._overrideDefaultAnimationMultiplier, this._customWalkAnimationMultiplier, this._customRunAnimationMultiplier);
				movePath.SetLookPosition();
			}
		}
	}

	// Token: 0x04000042 RID: 66
	[HideInInspector]
	[Tooltip("Type of movement / Тип движения")]
	[SerializeField]
	private PeopleWalkPath.EnumMove _moveType;

	// Token: 0x04000043 RID: 67
	[Tooltip("Direction of movement / Направление движения. Левостороннее, правостороннее, итд.")]
	[SerializeField]
	private PeopleWalkPath.EnumDir direction;

	// Token: 0x04000044 RID: 68
	[HideInInspector]
	[Tooltip("Speed of walk / Скорость ходьбы")]
	[SerializeField]
	private float walkSpeed = 1f;

	// Token: 0x04000045 RID: 69
	[HideInInspector]
	[Tooltip("Speed of run / Скорость бега")]
	[SerializeField]
	private float runSpeed = 4f;

	// Token: 0x04000046 RID: 70
	[HideInInspector]
	public bool isWalk;

	// Token: 0x04000047 RID: 71
	[HideInInspector]
	[SerializeField]
	[Tooltip("Set your animation speed? / Установить свою скорость анимации?")]
	private bool _overrideDefaultAnimationMultiplier = true;

	// Token: 0x04000048 RID: 72
	[HideInInspector]
	[SerializeField]
	[Tooltip("Speed animation of walking / Скорость анимации ходьбы")]
	private float _customWalkAnimationMultiplier = 1.1f;

	// Token: 0x04000049 RID: 73
	[HideInInspector]
	[SerializeField]
	[Tooltip("Running animation speed / Скорость анимации бега")]
	private float _customRunAnimationMultiplier = 0.3f;

	// Token: 0x0200000A RID: 10
	public enum EnumMove
	{
		// Token: 0x0400004B RID: 75
		Walk,
		// Token: 0x0400004C RID: 76
		Run
	}

	// Token: 0x0200000B RID: 11
	public enum EnumDir
	{
		// Token: 0x0400004E RID: 78
		Forward,
		// Token: 0x0400004F RID: 79
		Backward,
		// Token: 0x04000050 RID: 80
		HugLeft,
		// Token: 0x04000051 RID: 81
		HugRight,
		// Token: 0x04000052 RID: 82
		WeaveLeft,
		// Token: 0x04000053 RID: 83
		WeaveRight
	}
}

using System;
using System.Collections;
using Rewired;
using StarterAssets;
using UnityEngine;

// Token: 0x020000A7 RID: 167
public class PlayerCrouch : MonoBehaviour
{
	// Token: 0x060005B3 RID: 1459 RVA: 0x00027340 File Offset: 0x00025540
	private void Start()
	{
		this.m_CharacterController = base.GetComponent<CharacterController>();
		this.m_OriginalHeight = this.m_CharacterController.height;
		this.m_OriginalCenter = this.m_CharacterController.center.y;
		this.canCrouch = true;
		this.MainPlayer = ReInput.players.GetPlayer(this.playerId);
		this.viewpointOBJ = base.transform.Find("Viewpoint_Pivot/Viewpoint").gameObject;
		this.viewpointStandHeight = this.viewpointOBJ.transform.localPosition.y;
		this.pController = base.GetComponent<FirstPersonController>();
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x000273E0 File Offset: 0x000255E0
	private void Update()
	{
		if (this.MainPlayer.GetButtonDown("Crouch") && this.pController.allowPlayerInput && !Camera.main.GetComponent<CustomCameraController>().inEmoteEvent)
		{
			this.m_Crouch = !this.m_Crouch;
			this.CheckCrouch();
		}
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x00027434 File Offset: 0x00025634
	private void CheckCrouch()
	{
		if (!this.canCrouch)
		{
			return;
		}
		GameObject gameObject = null;
		using (IEnumerator enumerator = base.transform.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (((Transform)enumerator.Current).name == "Character")
				{
					gameObject = base.transform.Find("Character").gameObject;
					break;
				}
			}
		}
		if (gameObject == null)
		{
			return;
		}
		if (this.m_Crouch)
		{
			this.m_CharacterController.height = this.m_OriginalHeight * 0.7f;
			this.m_CharacterController.center = new Vector3(0f, this.m_OriginalCenter * 0.7f, 0f);
			this.pController.IsCrouching = true;
			base.GetComponent<PlayerNetwork>().ChangeCrouchValue(true);
			base.StartCoroutine(this.LerpFloat(gameObject, true));
			return;
		}
		this.canStand = this.PreventStandingInLowHeadRoom();
		if (!this.canStand)
		{
			this.m_Crouch = !this.m_Crouch;
			return;
		}
		this.m_CharacterController.height = this.m_OriginalHeight;
		this.m_CharacterController.center = new Vector3(0f, this.m_OriginalCenter, 0f);
		this.pController.IsCrouching = false;
		base.GetComponent<PlayerNetwork>().ChangeCrouchValue(false);
		base.StartCoroutine(this.LerpFloat(gameObject, false));
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x000275AC File Offset: 0x000257AC
	private IEnumerator LerpFloat(GameObject characterOBJ, bool set)
	{
		this.canCrouch = false;
		float lerpInValue = set ? this.viewpointStandHeight : (this.viewpointStandHeight * 0.7f);
		float lerpOutValue = set ? (this.viewpointStandHeight * 0.7f) : this.viewpointStandHeight;
		float animInValue = set ? 0f : 1f;
		float animOutValue = set ? 1f : 0f;
		float crouchInValue = set ? 1f : 0.49f;
		float crouchOutValue = set ? 0.49f : 1f;
		float elapsedTime = 0f;
		float waitTime = 0.15f;
		while (elapsedTime < waitTime)
		{
			float y = Mathf.Lerp(lerpInValue, lerpOutValue, elapsedTime / waitTime);
			float value = Mathf.Lerp(animInValue, animOutValue, elapsedTime / waitTime);
			float y2 = Mathf.Lerp(crouchInValue, crouchOutValue, elapsedTime / waitTime);
			this.viewpointOBJ.transform.localPosition = new Vector3(0f, y, 0f);
			characterOBJ.GetComponent<Animator>().SetFloat("CrouchFactor", value);
			this.equippedParentOBJ.transform.localPosition = new Vector3(0f, y2, 0.4f);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		this.viewpointOBJ.transform.localPosition = new Vector3(0f, lerpOutValue, 0f);
		characterOBJ.GetComponent<Animator>().SetFloat("CrouchFactor", animOutValue);
		this.equippedParentOBJ.transform.localPosition = new Vector3(0f, crouchOutValue, 0.4f);
		yield return null;
		this.canCrouch = true;
		yield break;
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x000275CC File Offset: 0x000257CC
	private bool PreventStandingInLowHeadRoom()
	{
		Ray ray = new Ray(base.transform.position + Vector3.up * this.m_CharacterController.radius * 0.5f, Vector3.up);
		float maxDistance = this.m_CharacterController.height - this.m_CharacterController.radius * 0.5f + 0.5f;
		return !Physics.SphereCast(ray, this.m_CharacterController.radius * 0.5f, maxDistance, -1, QueryTriggerInteraction.Ignore);
	}

	// Token: 0x040004A5 RID: 1189
	public GameObject equippedParentOBJ;

	// Token: 0x040004A6 RID: 1190
	private CharacterController m_CharacterController;

	// Token: 0x040004A7 RID: 1191
	private FirstPersonController pController;

	// Token: 0x040004A8 RID: 1192
	private bool m_Crouch;

	// Token: 0x040004A9 RID: 1193
	private bool canCrouch;

	// Token: 0x040004AA RID: 1194
	private float m_OriginalHeight;

	// Token: 0x040004AB RID: 1195
	private float m_OriginalCenter;

	// Token: 0x040004AC RID: 1196
	private GameObject viewpointOBJ;

	// Token: 0x040004AD RID: 1197
	private float viewpointStandHeight;

	// Token: 0x040004AE RID: 1198
	private Player MainPlayer;

	// Token: 0x040004AF RID: 1199
	private int playerId;

	// Token: 0x040004B0 RID: 1200
	private const float k_Half = 0.5f;

	// Token: 0x040004B1 RID: 1201
	private const float k_HeightReduction = 0.7f;

	// Token: 0x040004B2 RID: 1202
	private bool canStand;
}

using System;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000081 RID: 129
public class PlayerListItem : MonoBehaviour
{
	// Token: 0x060003F7 RID: 1015 RVA: 0x0001C184 File Offset: 0x0001A384
	private void Start()
	{
		this.ImageLoaded = Callback<AvatarImageLoaded_t>.Create(new Callback<AvatarImageLoaded_t>.DispatchDelegate(this.OnImageLoaded));
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0001C19D File Offset: 0x0001A39D
	private void OnImageLoaded(AvatarImageLoaded_t callback)
	{
		if (callback.m_steamID.m_SteamID == this.PlayerSteamID)
		{
			this.PlayerIcon.texture = this.GetSteamImageAsTexture(callback.m_iImage);
			return;
		}
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0001C1CC File Offset: 0x0001A3CC
	private void GetPlayerIcon()
	{
		int largeFriendAvatar = SteamFriends.GetLargeFriendAvatar((CSteamID)this.PlayerSteamID);
		if (largeFriendAvatar == -1)
		{
			return;
		}
		this.PlayerIcon.texture = this.GetSteamImageAsTexture(largeFriendAvatar);
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0001C201 File Offset: 0x0001A401
	public void SetPlayerValues()
	{
		this.PlayerNameText.text = this.PlayerName;
		if (!this.AvatarReceived)
		{
			this.GetPlayerIcon();
		}
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0001C224 File Offset: 0x0001A424
	private Texture2D GetSteamImageAsTexture(int iImage)
	{
		Texture2D texture2D = null;
		uint num;
		uint num2;
		if (SteamUtils.GetImageSize(iImage, out num, out num2))
		{
			byte[] array = new byte[num * num2 * 4U];
			if (SteamUtils.GetImageRGBA(iImage, array, (int)(num * num2 * 4U)))
			{
				texture2D = new Texture2D((int)num, (int)num2, TextureFormat.RGBA32, false, true);
				texture2D.LoadRawTextureData(array);
				texture2D.Apply();
			}
		}
		this.AvatarReceived = true;
		return texture2D;
	}

	// Token: 0x0400034B RID: 843
	public GameObject playerOBJ;

	// Token: 0x0400034C RID: 844
	public string PlayerName;

	// Token: 0x0400034D RID: 845
	public int ConnectionID;

	// Token: 0x0400034E RID: 846
	public ulong PlayerSteamID;

	// Token: 0x0400034F RID: 847
	public bool AvatarReceived;

	// Token: 0x04000350 RID: 848
	public TextMeshProUGUI PlayerNameText;

	// Token: 0x04000351 RID: 849
	public RawImage PlayerIcon;

	// Token: 0x04000352 RID: 850
	protected Callback<AvatarImageLoaded_t> ImageLoaded;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using Mirror;
using Mirror.RemoteCalls;
using Rewired;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Token: 0x02000082 RID: 130
public class PlayerNetwork : NetworkBehaviour
{
	// Token: 0x060003FD RID: 1021 RVA: 0x0001C278 File Offset: 0x0001A478
	private void Start()
	{
		if (base.isLocalPlayer)
		{
			this.MainPlayer = ReInput.players.GetPlayer(this.playerId);
		}
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0001C298 File Offset: 0x0001A498
	public override void OnStartClient()
	{
		this.OnChangeCharacter(-1, this.characterID);
		this.OnChangeHat(-1, this.hatID);
		this.OnCrouch(false, this.isCrouching);
		if (base.isLocalPlayer)
		{
			base.StartCoroutine(this.LoadSkin());
		}
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x0001C2D6 File Offset: 0x0001A4D6
	private IEnumerator LoadSkin()
	{
		yield return new WaitForSeconds(8f);
		string filepath = Application.persistentDataPath + "/GameOptions.es3";
		if (ES3.KeyExists("localizationhash3", filepath))
		{
			int[] array = ES3.Load<int[]>("localizationhash3", filepath);
			this.posesArray = array;
		}
		if (ES3.KeyExists("localizationhash1", filepath))
		{
			int newCharacter = ES3.Load<int>("localizationhash1", filepath);
			this.CmdChangeCharacter(newCharacter);
		}
		yield return new WaitForSeconds(1.5f);
		if (ES3.KeyExists("localizationhash2", filepath))
		{
			int newHat = ES3.Load<int>("localizationhash2", filepath);
			this.CmdChangeHat(newHat);
		}
		yield break;
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0001C2E8 File Offset: 0x0001A4E8
	public void SavePlayerSkins()
	{
		if (base.isLocalPlayer)
		{
			string filePath = Application.persistentDataPath + "/GameOptions.es3";
			ES3.Save<int>("localizationhash1", this.characterID, filePath);
			ES3.Save<int>("localizationhash2", this.hatID, filePath);
			ES3.Save<int[]>("localizationhash3", this.posesArray, filePath);
		}
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0001C340 File Offset: 0x0001A540
	private void OnChangeCharacter(int oldID, int newID)
	{
		using (IEnumerator enumerator = base.transform.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (((Transform)enumerator.Current).name == "Character")
				{
					Object.Destroy(base.transform.Find("Character").gameObject);
				}
			}
		}
		newID = Mathf.Clamp(newID, 0, this.playerCharacter.Length - 1);
		GameObject gameObject = Object.Instantiate<GameObject>(this.playerCharacter[newID], base.transform);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.name = "Character";
		if (base.isLocalPlayer)
		{
			gameObject.transform.Find("CharacterMesh").GetComponent<SkinnedMeshRenderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
		}
		if (this.hatOBJ)
		{
			Object.Destroy(this.hatOBJ);
		}
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0001C43C File Offset: 0x0001A63C
	private void OnChangeHat(int oldID, int newID)
	{
		if (this.hatOBJ)
		{
			Object.Destroy(this.hatOBJ);
		}
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0001C456 File Offset: 0x0001A656
	public void ChangeCrouchValue(bool crouchValue)
	{
		if (base.isOwned)
		{
			this.CmdCrouch(crouchValue);
		}
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0001C468 File Offset: 0x0001A668
	[Command]
	private void CmdCrouch(bool crouchValue)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(crouchValue);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdCrouch(System.Boolean)", -96825597, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0001C4A4 File Offset: 0x0001A6A4
	private void OnCrouch(bool oldValue, bool newValue)
	{
		if (base.isLocalPlayer)
		{
			return;
		}
		GameObject gameObject = null;
		using (IEnumerator enumerator = base.transform.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (((Transform)enumerator.Current).name == "Character")
				{
					gameObject = base.transform.Find("Character").gameObject;
					break;
				}
			}
		}
		if (gameObject == null)
		{
			return;
		}
		if (this.crouchCoroutineRunning)
		{
			base.StopCoroutine(this.coroutineVariable);
		}
		if (newValue)
		{
			this.coroutineVariable = base.StartCoroutine(this.CrouchLerpCoroutine(gameObject, true));
			return;
		}
		this.coroutineVariable = base.StartCoroutine(this.CrouchLerpCoroutine(gameObject, false));
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0001C574 File Offset: 0x0001A774
	private IEnumerator CrouchLerpCoroutine(GameObject characterOBJ, bool set)
	{
		this.crouchCoroutineRunning = true;
		float animInValue = set ? 0f : 1f;
		float animOutValue = set ? 1f : 0f;
		float crouchInValue = set ? 1f : 0.49f;
		float crouchOutValue = set ? 0.49f : 1f;
		float elapsedTime = 0f;
		float waitTime = 0.15f;
		Animator charAnimator = characterOBJ.GetComponent<Animator>();
		while (elapsedTime < waitTime)
		{
			float value = Mathf.Lerp(animInValue, animOutValue, elapsedTime / waitTime);
			float y = Mathf.Lerp(crouchInValue, crouchOutValue, elapsedTime / waitTime);
			if (charAnimator)
			{
				charAnimator.SetFloat("CrouchFactor", value);
			}
			this.equippedParentOBJ.transform.localPosition = new Vector3(0f, y, 0.4f);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		if (charAnimator)
		{
			characterOBJ.GetComponent<Animator>().SetFloat("CrouchFactor", animOutValue);
		}
		this.equippedParentOBJ.transform.localPosition = new Vector3(0f, crouchOutValue, 0.4f);
		yield return null;
		this.crouchCoroutineRunning = false;
		yield break;
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0001C594 File Offset: 0x0001A794
	private void Update()
	{
		if (this.hatID > 0 && !this.hatOBJ)
		{
			GameObject gameObject = null;
			using (IEnumerator enumerator = base.transform.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (((Transform)enumerator.Current).name == "Character")
					{
						gameObject = base.transform.Find("Character").gameObject;
						break;
					}
				}
			}
			if (gameObject == null)
			{
				return;
			}
			int num = this.hatID;
			num = Mathf.Clamp(num, 0, this.hatsArray.Length - 1);
			GameObject value = gameObject.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("HatSpot").Value;
			this.hatOBJ = Object.Instantiate<GameObject>(this.hatsArray[num], value.transform);
			this.hatOBJ.transform.localPosition = this.hatOBJ.GetComponent<HatInfo>().offset;
			this.hatOBJ.transform.localRotation = Quaternion.Euler(this.hatOBJ.GetComponent<HatInfo>().rotation);
			if (base.isLocalPlayer)
			{
				this.hatOBJ.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
				if (this.hatOBJ.transform.childCount > 0)
				{
					this.hatOBJ.transform.GetChild(0).gameObject.SetActive(false);
				}
			}
		}
		if (!base.isLocalPlayer)
		{
			return;
		}
		this.PoseBehaviour();
		if (this.MainPlayer.GetButtonDown("Drop Item") && this.equippedItem > 0)
		{
			if (this.dropCooldown)
			{
				return;
			}
			if (FsmVariables.GlobalVariables.GetFsmBool("InChat").Value || FsmVariables.GlobalVariables.GetFsmBool("InOptions").Value)
			{
				return;
			}
			Vector3 vector = Vector3.zero;
			RaycastHit raycastHit;
			if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 4f, this.lMask))
			{
				vector = raycastHit.point + raycastHit.normal.normalized * 0.5f;
				if (raycastHit.transform.gameObject.tag == "Interactable" && !raycastHit.transform.GetComponent<BoxData>())
				{
					return;
				}
				RaycastHit raycastHit2;
				if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit2, 4f, this.interactableMask) && raycastHit2.transform.gameObject.tag == "Interactable")
				{
					return;
				}
			}
			else
			{
				vector = Camera.main.transform.position + Camera.main.transform.forward * 3.5f;
			}
			if (this.equippedItem > 0)
			{
				base.StartCoroutine(this.DropCooldown());
			}
			switch (this.equippedItem)
			{
			case 0:
			case 4:
				break;
			case 1:
				this.CmdChangeEquippedItem(0);
				GameData.Instance.GetComponent<ManagerBlackboard>().CmdSpawnBoxFromPlayer(vector, this.extraParameter1, this.extraParameter2, base.transform.rotation.eulerAngles.y);
				break;
			case 2:
				this.CmdChangeEquippedItem(0);
				GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnProp(2, vector, new Vector3(0f, 0f, 90f));
				break;
			case 3:
				this.CmdChangeEquippedItem(0);
				GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnProp(3, vector, new Vector3(270f, 0f, 0f));
				break;
			case 5:
				this.CmdChangeEquippedItem(0);
				GameData.Instance.GetComponent<NetworkSpawner>().CmdSpawnProp(5, vector, new Vector3(270f, 0f, 0f));
				break;
			default:
				MonoBehaviour.print("Equipped item error");
				break;
			}
		}
		if (!this.gameCanvasProductOBJ && GameCanvas.Instance)
		{
			this.gameCanvasProductOBJ = GameCanvas.Instance.transform.Find("ProductShow").gameObject;
		}
		RaycastHit raycastHit3;
		if (this.gameCanvasProductOBJ && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit3, 4f, this.interactableMask))
		{
			if (raycastHit3.transform.gameObject.name == "SubContainer")
			{
				int siblingIndex = raycastHit3.transform.GetSiblingIndex();
				Data_Container component = raycastHit3.transform.parent.transform.parent.GetComponent<Data_Container>();
				if (component.containerClass < 20)
				{
					int num2 = component.productInfoArray[siblingIndex * 2];
					if (num2 < 0)
					{
						this.oldCanvasProductID = -2;
						this.gameCanvasProductOBJ.SetActive(false);
					}
					if (num2 >= 0 && this.oldCanvasProductID != num2)
					{
						this.gameCanvasProductOBJ.SetActive(true);
						this.gameCanvasProductOBJ.transform.Find("Container/ProductName").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("product" + num2.ToString());
						this.gameCanvasProductOBJ.transform.Find("Container/ProductBrand").GetComponent<TextMeshProUGUI>().text = ProductListing.Instance.productPrefabs[num2].GetComponent<Data_Product>().productBrand;
						this.gameCanvasProductOBJ.transform.Find("Container/ProductImage").GetComponent<Image>().sprite = ProductListing.Instance.productSprites[num2];
						this.oldCanvasProductID = num2;
					}
				}
				else
				{
					this.oldCanvasProductID = -3;
					this.gameCanvasProductOBJ.SetActive(false);
				}
			}
			else
			{
				this.oldCanvasProductID = -4;
				this.gameCanvasProductOBJ.SetActive(false);
			}
		}
		else if (this.gameCanvasProductOBJ)
		{
			this.oldCanvasProductID = -5;
			this.gameCanvasProductOBJ.SetActive(false);
		}
		if (this.instantiatedOBJ)
		{
			switch (this.equippedItem)
			{
			case 0:
			case 3:
			case 4:
			case 5:
				break;
			case 1:
			{
				float num3 = Camera.main.transform.localEulerAngles.x;
				if (num3 > 90f)
				{
					this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
					this.instantiatedOBJ.transform.localPosition = new Vector3(0f, 0.1f, 0f);
				}
				else
				{
					num3 = Mathf.Clamp(num3, 0f, 20f);
					this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(0f, 90f, num3);
					float t = num3 / 20f;
					float y = Mathf.Lerp(0.1f, -0.3f, t);
					float x = Mathf.Lerp(0f, 0.55f, t);
					this.instantiatedOBJ.transform.localPosition = new Vector3(x, y, 0f);
				}
				this.canvasTMP.text = "x" + this.extraParameter2.ToString();
				return;
			}
			case 2:
			{
				RaycastHit raycastHit4;
				if (!Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit4, 4f, this.interactableMask))
				{
					this.oldProductID = -5;
					this.pricingCanvas.SetActive(false);
					this.basefloatString = "";
					return;
				}
				if (!(raycastHit4.transform.gameObject.name == "SubContainer"))
				{
					this.oldProductID = -4;
					this.pricingCanvas.SetActive(false);
					this.basefloatString = "";
					return;
				}
				int siblingIndex2 = raycastHit4.transform.GetSiblingIndex();
				Data_Container component2 = raycastHit4.transform.parent.transform.parent.GetComponent<Data_Container>();
				if (component2.containerClass >= 20)
				{
					this.oldProductID = -3;
					this.pricingCanvas.SetActive(false);
					this.basefloatString = "";
					return;
				}
				int num4 = component2.productInfoArray[siblingIndex2 * 2];
				if (num4 < 0)
				{
					this.oldProductID = -2;
					this.pricingCanvas.SetActive(false);
					this.basefloatString = "";
					return;
				}
				if (this.oldProductID != num4)
				{
					this.productNameTMP.text = LocalizationManager.instance.GetLocalizationString("product" + num4.ToString());
					this.productBrandTMP.text = ProductListing.Instance.productPrefabs[num4].GetComponent<Data_Product>().productBrand;
					this.productImage.sprite = ProductListing.Instance.productSprites[num4];
					float num5 = ProductListing.Instance.tierInflation[ProductListing.Instance.productPrefabs[num4].GetComponent<Data_Product>().productTier];
					float num6 = ProductListing.Instance.productPrefabs[num4].GetComponent<Data_Product>().basePricePerUnit * num5;
					num6 = Mathf.Round(num6 * 100f) / 100f;
					this.marketPriceTMP.text = "$" + num6.ToString();
					float num7 = ProductListing.Instance.productPlayerPricing[num4];
					num7 = Mathf.Round(num7 * 100f) / 100f;
					this.yourPriceTMP.text = "$" + num7.ToString();
					this.pPrice = num7;
					this.pricingCanvas.SetActive(true);
					this.oldProductID = num4;
					this.basefloatString = "";
				}
				this.PriceSetFromNumpad(num4);
				if (this.MainPlayer.GetButtonDown("Menu Previous"))
				{
					this.pPrice += (this.MainPlayer.GetButton("Build") ? 0.2f : 0.01f);
					this.yourPriceTMP.text = ProductListing.Instance.ConvertFloatToTextPrice(this.pPrice);
				}
				else if (this.MainPlayer.GetButtonDown("Menu Next"))
				{
					this.pPrice -= (this.MainPlayer.GetButton("Build") ? 0.2f : 0.01f);
					this.pPrice = Mathf.Clamp(this.pPrice, 0f, float.PositiveInfinity);
					this.yourPriceTMP.text = ProductListing.Instance.ConvertFloatToTextPrice(this.pPrice);
				}
				if (this.MainPlayer.GetButtonDown("Main Action") && ProductListing.Instance.productPlayerPricing[num4] != this.pPrice)
				{
					this.CmdPlayPricingSound();
					ProductListing.Instance.CmdUpdateProductPrice(num4, this.pPrice);
				}
				if (this.MainPlayer.GetButtonDown("Secondary Action") && component2.productInfoArray[siblingIndex2 * 2 + 1] <= 0)
				{
					base.transform.Find("ResetProductSound").GetComponent<AudioSource>().Play();
					component2.CmdContainerClear(siblingIndex2 * 2);
					return;
				}
				break;
			}
			default:
				MonoBehaviour.print("Equipped item error");
				break;
			}
		}
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0001D0F0 File Offset: 0x0001B2F0
	private IEnumerator DropCooldown()
	{
		this.dropCooldown = true;
		yield return new WaitForSeconds(0.33f);
		this.dropCooldown = false;
		yield break;
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x0001D100 File Offset: 0x0001B300
	private void PriceSetFromNumpad(int productID)
	{
		if (this.MainPlayer.GetButtonDown("Numpad Delete"))
		{
			if (this.basefloatString.Length == 0)
			{
				return;
			}
			this.basefloatString = this.basefloatString.Substring(0, this.basefloatString.Length - 1);
			this.yourPriceTMP.text = "$" + this.basefloatString;
			return;
		}
		else
		{
			if (this.basefloatString.Length >= 7)
			{
				return;
			}
			for (int i = 0; i < this.keyCodes.Length; i++)
			{
				if (this.MainPlayer.GetButtonDown(this.keyCodes[i]))
				{
					if (this.basefloatString.Contains(","))
					{
						string[] array = this.basefloatString.Split(",", StringSplitOptions.None);
						if (array.Length > 1 && array[1].Length >= 2)
						{
							return;
						}
					}
					this.basefloatString += i.ToString();
					this.yourPriceTMP.text = "$" + this.basefloatString;
					return;
				}
			}
			if (!this.MainPlayer.GetButtonDown("Numpad Period"))
			{
				if (this.MainPlayer.GetButtonDown("Numpad Accept"))
				{
					if (this.basefloatString.Length == 0 || this.basefloatString.Substring(this.basefloatString.Length - 1, 1) == ",")
					{
						return;
					}
					float num;
					if (!float.TryParse(this.basefloatString, out num))
					{
						return;
					}
					num = Mathf.Round(num * 100f) / 100f;
					if (ProductListing.Instance.productPlayerPricing[productID] != num)
					{
						this.CmdPlayPricingSound();
						this.pPrice = num;
						ProductListing.Instance.CmdUpdateProductPrice(productID, this.pPrice);
					}
				}
				return;
			}
			if (this.basefloatString.Length == 0 || this.basefloatString.Contains(","))
			{
				return;
			}
			this.basefloatString += ",";
			this.yourPriceTMP.text = "$" + this.basefloatString;
			return;
		}
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0001D310 File Offset: 0x0001B510
	private void PoseBehaviour()
	{
		for (int i = 1; i < this.poseKeyCodes.Length; i++)
		{
			if (this.MainPlayer.GetButtonDown(this.poseKeyCodes[i]))
			{
				if (FirstPersonController.Instance.inVehicle)
				{
					return;
				}
				int num = this.posesArray[i];
				if (num == 0)
				{
					return;
				}
				if (Camera.main)
				{
					CustomCameraController component = Camera.main.GetComponent<CustomCameraController>();
					if (!component.inEmoteEvent)
					{
						component.ThirdPersonEmoteVisualize();
					}
				}
				this.CmdPlayPose(num);
			}
		}
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x0001D38B File Offset: 0x0001B58B
	private void OnChangeEquipment(int oldEquippedItem, int newEquippedItem)
	{
		base.StartCoroutine(this.ChangeEquipment(newEquippedItem));
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x0001D39B File Offset: 0x0001B59B
	private IEnumerator ChangeEquipment(int newEquippedItem)
	{
		while (this.equippedParentOBJ.transform.childCount > 0)
		{
			Object.Destroy(this.equippedParentOBJ.transform.GetChild(0).gameObject);
			yield return null;
		}
		switch (newEquippedItem)
		{
		case 0:
			this.extraParameter1 = -1;
			this.extraParameter2 = -1;
			break;
		case 1:
		{
			GameObject original = this.equippedPrefabs[newEquippedItem];
			this.instantiatedOBJ = Object.Instantiate<GameObject>(original, this.equippedParentOBJ.transform);
			this.instantiatedOBJ.transform.localPosition = Vector3.zero;
			this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
			if (base.isLocalPlayer && this.extraParameter1 >= 0)
			{
				this.UpdateBoxContents(this.extraParameter1);
				this.CmdSetBoxColorToEveryone(this.extraParameter1);
			}
			else
			{
				this.instantiatedOBJ.transform.localPosition = new Vector3(0f, 0f, 0.1f);
				this.instantiatedOBJ.transform.Find("Canvas").gameObject.SetActive(false);
			}
			break;
		}
		case 2:
		{
			GameObject original2 = this.equippedPrefabs[newEquippedItem];
			this.instantiatedOBJ = Object.Instantiate<GameObject>(original2, this.equippedParentOBJ.transform);
			if (base.isLocalPlayer)
			{
				this.instantiatedOBJ.transform.localPosition = new Vector3(0.12f, 0.5f, -0.24f);
				this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(-18f, 0f, 0f);
				this.pricingCanvas = this.instantiatedOBJ.transform.Find("Canvas").gameObject;
				this.productImage = this.instantiatedOBJ.transform.Find("Canvas/Container/ProductImage").GetComponent<Image>();
				this.productNameTMP = this.instantiatedOBJ.transform.Find("Canvas/Container/ProductName").GetComponent<TextMeshProUGUI>();
				this.marketPriceTMP = this.instantiatedOBJ.transform.Find("Canvas/Container/MarketPrice").GetComponent<TextMeshProUGUI>();
				this.yourPriceTMP = this.instantiatedOBJ.transform.Find("Canvas/Container/YourPrice").GetComponent<TextMeshProUGUI>();
				this.productBrandTMP = this.instantiatedOBJ.transform.Find("Canvas/Container/BrandName").GetComponent<TextMeshProUGUI>();
			}
			else
			{
				this.instantiatedOBJ.transform.localPosition = new Vector3(0.275f, 0f, -0.1f);
				this.instantiatedOBJ.transform.localRotation = Quaternion.identity;
			}
			break;
		}
		case 3:
		{
			GameObject original3 = this.equippedPrefabs[newEquippedItem];
			this.instantiatedOBJ = Object.Instantiate<GameObject>(original3, this.equippedParentOBJ.transform);
			this.instantiatedOBJ.transform.localPosition = new Vector3(0.42f, -0.92f, 0.15f);
			this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
			break;
		}
		case 4:
		{
			GameObject original4 = this.equippedPrefabs[newEquippedItem];
			this.instantiatedOBJ = Object.Instantiate<GameObject>(original4, this.equippedParentOBJ.transform);
			this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(290f, 180f, 0f);
			this.instantiatedOBJ.transform.localPosition = new Vector3(0f, 0.165f, -0.066f);
			break;
		}
		case 5:
		{
			GameObject original5 = this.equippedPrefabs[newEquippedItem];
			this.instantiatedOBJ = Object.Instantiate<GameObject>(original5, this.equippedParentOBJ.transform);
			this.instantiatedOBJ.transform.localRotation = Quaternion.Euler(290f, 180f, 0f);
			if (base.isLocalPlayer)
			{
				this.instantiatedOBJ.transform.localPosition = new Vector3(0f, 0.3f, -0.3f);
				if (GameCanvas.Instance.isCool)
				{
					this.instantiatedOBJ.GetComponent<Builder_Paintables>().enabled = true;
				}
			}
			else
			{
				this.instantiatedOBJ.transform.localPosition = new Vector3(-0.05f, 0.42f, 0.015f);
			}
			break;
		}
		default:
			MonoBehaviour.print("Equipped item error");
			break;
		}
		yield break;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0001D3B4 File Offset: 0x0001B5B4
	public void UpdateBoxContents(int productIndex)
	{
		Sprite sprite = ProductListing.Instance.productSprites[productIndex];
		this.instantiatedOBJ.transform.Find("Canvas/Image").GetComponent<Image>().sprite = sprite;
		this.canvasTMP = this.instantiatedOBJ.transform.Find("Canvas/Quantity").GetComponent<TextMeshProUGUI>();
		this.canvasTMP.text = "x" + this.extraParameter2.ToString();
		this.instantiatedOBJ.transform.Find("Canvas/ProductName").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("product" + productIndex.ToString());
		this.instantiatedOBJ.transform.Find("Canvas/BrandName").GetComponent<TextMeshProUGUI>().text = ProductListing.Instance.productPrefabs[productIndex].GetComponent<Data_Product>().productBrand;
		int productContainerClass = ProductListing.Instance.productPrefabs[productIndex].GetComponent<Data_Product>().productContainerClass;
		if (productContainerClass < GameData.Instance.GetComponent<ManagerBlackboard>().containerTypeSprites.Length)
		{
			this.instantiatedOBJ.transform.Find("Canvas/ContainerType").GetComponent<Image>().sprite = GameData.Instance.GetComponent<ManagerBlackboard>().containerTypeSprites[productContainerClass];
		}
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0001D4F8 File Offset: 0x0001B6F8
	[Command]
	private void CmdSetBoxColorToEveryone(int productID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(productID);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdSetBoxColorToEveryone(System.Int32)", 669426771, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0001D534 File Offset: 0x0001B734
	[ClientRpc]
	private void RpcSetBoxColorToEveryone(int productID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(productID);
		this.SendRPCInternal("System.Void PlayerNetwork::RpcSetBoxColorToEveryone(System.Int32)", 194907278, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x0001D56E File Offset: 0x0001B76E
	private IEnumerator WaitForBox(int productID)
	{
		while (!this.instantiatedOBJ)
		{
			yield return null;
		}
		if (this.instantiatedOBJ.transform.Find("BoxMesh"))
		{
			this.instantiatedOBJ.transform.Find("BoxMesh").gameObject.SetActive(true);
			ProductListing.Instance.SetBoxColor(this.instantiatedOBJ, productID);
		}
		yield return null;
		yield break;
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x0001D584 File Offset: 0x0001B784
	[Command]
	public void CmdChangeCharacter(int newCharacter)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(newCharacter);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdChangeCharacter(System.Int32)", -2046995048, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x0001D5C0 File Offset: 0x0001B7C0
	[Command]
	public void CmdChangeHat(int newHat)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(newHat);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdChangeHat(System.Int32)", -700731694, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0001D5FC File Offset: 0x0001B7FC
	[Command]
	public void CmdChangeEquippedItem(int selectedItem)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(selectedItem);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdChangeEquippedItem(System.Int32)", 1644862315, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0001D638 File Offset: 0x0001B838
	[Command]
	public void CmdPlayAnimation(int animationIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(animationIndex);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdPlayAnimation(System.Int32)", -2042617229, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0001D674 File Offset: 0x0001B874
	[ClientRpc]
	public void RpcPlayAnimation(int animationIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(animationIndex);
		this.SendRPCInternal("System.Void PlayerNetwork::RpcPlayAnimation(System.Int32)", -792377770, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0001D6AE File Offset: 0x0001B8AE
	public void PushPlayer(Vector3 direction)
	{
		if (Vector3.Distance(FirstPersonController.Instance.gameObject.transform.position, base.gameObject.transform.position) < 3f)
		{
			this.CmdPushPlayer(direction);
		}
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0001D6E8 File Offset: 0x0001B8E8
	[Command(requiresAuthority = false)]
	private void CmdPushPlayer(Vector3 direction)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(direction);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdPushPlayer(UnityEngine.Vector3)", -59686282, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0001D724 File Offset: 0x0001B924
	[ClientRpc]
	private void RpcPushPlayer(Vector3 direction)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(direction);
		this.SendRPCInternal("System.Void PlayerNetwork::RpcPushPlayer(UnityEngine.Vector3)", 509548111, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x0001D760 File Offset: 0x0001B960
	[ClientRpc]
	private void RpcPlayPlayerAnimation(int animationIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(animationIndex);
		this.SendRPCInternal("System.Void PlayerNetwork::RpcPlayPlayerAnimation(System.Int32)", 1373518161, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x0001D79A File Offset: 0x0001B99A
	private IEnumerator PushCoroutine(Vector3 direction)
	{
		base.GetComponent<FirstPersonController>().isBeingPushed = true;
		base.GetComponent<FirstPersonController>().pushDirection = direction;
		yield return new WaitForSeconds(1.5f);
		base.GetComponent<FirstPersonController>().pushDirection = Vector3.zero;
		base.GetComponent<FirstPersonController>().isBeingPushed = false;
		yield break;
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0001D7B0 File Offset: 0x0001B9B0
	[Command]
	public void CmdPlayPricingSound()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void PlayerNetwork::CmdPlayPricingSound()", -601007885, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0001D7E0 File Offset: 0x0001B9E0
	[ClientRpc]
	private void RpcPlayPricingSound()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void PlayerNetwork::RpcPlayPricingSound()", -57655740, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0001D810 File Offset: 0x0001BA10
	[Command]
	public void CmdPlayPose(int poseIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(poseIndex);
		base.SendCommandInternal("System.Void PlayerNetwork::CmdPlayPose(System.Int32)", -1421798086, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0001D84C File Offset: 0x0001BA4C
	[ClientRpc]
	private void RpcPlayPose(int poseIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(poseIndex);
		this.SendRPCInternal("System.Void PlayerNetwork::RpcPlayPose(System.Int32)", -1705214667, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0001D888 File Offset: 0x0001BA88
	public PlayerNetwork()
	{
		this._Mirror_SyncVarHookDelegate_equippedItem = new Action<int, int>(this.OnChangeEquipment);
		this._Mirror_SyncVarHookDelegate_characterID = new Action<int, int>(this.OnChangeCharacter);
		this._Mirror_SyncVarHookDelegate_hatID = new Action<int, int>(this.OnChangeHat);
		this._Mirror_SyncVarHookDelegate_isCrouching = new Action<bool, bool>(this.OnCrouch);
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x06000421 RID: 1057 RVA: 0x0001D9AC File Offset: 0x0001BBAC
	// (set) Token: 0x06000422 RID: 1058 RVA: 0x0001D9BF File Offset: 0x0001BBBF
	public int NetworkequippedItem
	{
		get
		{
			return this.equippedItem;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.equippedItem, 1UL, this._Mirror_SyncVarHookDelegate_equippedItem);
		}
	}

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x06000423 RID: 1059 RVA: 0x0001D9E0 File Offset: 0x0001BBE0
	// (set) Token: 0x06000424 RID: 1060 RVA: 0x0001D9F3 File Offset: 0x0001BBF3
	public int NetworkcharacterID
	{
		get
		{
			return this.characterID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.characterID, 2UL, this._Mirror_SyncVarHookDelegate_characterID);
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x06000425 RID: 1061 RVA: 0x0001DA14 File Offset: 0x0001BC14
	// (set) Token: 0x06000426 RID: 1062 RVA: 0x0001DA27 File Offset: 0x0001BC27
	public int NetworkhatID
	{
		get
		{
			return this.hatID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.hatID, 4UL, this._Mirror_SyncVarHookDelegate_hatID);
		}
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x06000427 RID: 1063 RVA: 0x0001DA48 File Offset: 0x0001BC48
	// (set) Token: 0x06000428 RID: 1064 RVA: 0x0001DA5B File Offset: 0x0001BC5B
	public bool NetworkisCrouching
	{
		get
		{
			return this.isCrouching;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.isCrouching, 8UL, this._Mirror_SyncVarHookDelegate_isCrouching);
		}
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x0001DA7A File Offset: 0x0001BC7A
	protected void UserCode_CmdCrouch__Boolean(bool crouchValue)
	{
		this.NetworkisCrouching = crouchValue;
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0001DA83 File Offset: 0x0001BC83
	protected static void InvokeUserCode_CmdCrouch__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCrouch called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdCrouch__Boolean(reader.ReadBool());
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x0001DAAC File Offset: 0x0001BCAC
	protected void UserCode_CmdSetBoxColorToEveryone__Int32(int productID)
	{
		this.RpcSetBoxColorToEveryone(productID);
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0001DAB5 File Offset: 0x0001BCB5
	protected static void InvokeUserCode_CmdSetBoxColorToEveryone__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetBoxColorToEveryone called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdSetBoxColorToEveryone__Int32(reader.ReadInt());
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0001DADE File Offset: 0x0001BCDE
	protected void UserCode_RpcSetBoxColorToEveryone__Int32(int productID)
	{
		if (ProductListing.Instance)
		{
			base.StartCoroutine(this.WaitForBox(productID));
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0001DAFA File Offset: 0x0001BCFA
	protected static void InvokeUserCode_RpcSetBoxColorToEveryone__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetBoxColorToEveryone called on server.");
			return;
		}
		((PlayerNetwork)obj).UserCode_RpcSetBoxColorToEveryone__Int32(reader.ReadInt());
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0001DB23 File Offset: 0x0001BD23
	protected void UserCode_CmdChangeCharacter__Int32(int newCharacter)
	{
		this.NetworkcharacterID = newCharacter;
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0001DB2C File Offset: 0x0001BD2C
	protected static void InvokeUserCode_CmdChangeCharacter__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdChangeCharacter called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdChangeCharacter__Int32(reader.ReadInt());
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0001DB55 File Offset: 0x0001BD55
	protected void UserCode_CmdChangeHat__Int32(int newHat)
	{
		this.NetworkhatID = newHat;
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0001DB5E File Offset: 0x0001BD5E
	protected static void InvokeUserCode_CmdChangeHat__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdChangeHat called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdChangeHat__Int32(reader.ReadInt());
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0001DB87 File Offset: 0x0001BD87
	protected void UserCode_CmdChangeEquippedItem__Int32(int selectedItem)
	{
		this.NetworkequippedItem = selectedItem;
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x0001DB90 File Offset: 0x0001BD90
	protected static void InvokeUserCode_CmdChangeEquippedItem__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdChangeEquippedItem called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdChangeEquippedItem__Int32(reader.ReadInt());
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x0001DBB9 File Offset: 0x0001BDB9
	protected void UserCode_CmdPlayAnimation__Int32(int animationIndex)
	{
		this.RpcPlayAnimation(animationIndex);
		this.RpcPlayPlayerAnimation(1);
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0001DBC9 File Offset: 0x0001BDC9
	protected static void InvokeUserCode_CmdPlayAnimation__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayAnimation called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdPlayAnimation__Int32(reader.ReadInt());
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0001DBF4 File Offset: 0x0001BDF4
	protected void UserCode_RpcPlayAnimation__Int32(int animationIndex)
	{
		if (this.equippedItem == 3 && this.instantiatedOBJ)
		{
			Animator component = this.instantiatedOBJ.GetComponent<Animator>();
			component.SetFloat("AnimationFloat", (float)animationIndex);
			component.Play("Animation");
			if (animationIndex == 0)
			{
				this.instantiatedOBJ.GetComponent<AudioSource>().Play();
			}
		}
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0001DC4C File Offset: 0x0001BE4C
	protected static void InvokeUserCode_RpcPlayAnimation__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayAnimation called on server.");
			return;
		}
		((PlayerNetwork)obj).UserCode_RpcPlayAnimation__Int32(reader.ReadInt());
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0001DC75 File Offset: 0x0001BE75
	protected void UserCode_CmdPushPlayer__Vector3(Vector3 direction)
	{
		this.RpcPushPlayer(direction);
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0001DC7E File Offset: 0x0001BE7E
	protected static void InvokeUserCode_CmdPushPlayer__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPushPlayer called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdPushPlayer__Vector3(reader.ReadVector3());
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0001DCA8 File Offset: 0x0001BEA8
	protected void UserCode_RpcPushPlayer__Vector3(Vector3 direction)
	{
		if (base.isLocalPlayer && !base.GetComponent<FirstPersonController>().isBeingPushed)
		{
			base.StartCoroutine(this.PushCoroutine(direction));
			if (base.GetComponent<FirstPersonController>().IsCrouching)
			{
				base.transform.Find("Viewpoint_Pivot").GetComponent<Animator>().Play("ViewpointHitCrouch");
			}
			else
			{
				base.transform.Find("Viewpoint_Pivot").GetComponent<Animator>().Play("ViewpointHit");
			}
		}
		GameObject gameObject = null;
		using (IEnumerator enumerator = base.transform.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (((Transform)enumerator.Current).name == "Character")
				{
					gameObject = base.transform.Find("Character").gameObject;
					break;
				}
			}
		}
		if (gameObject)
		{
			gameObject.GetComponent<Animator>().SetFloat("AnimationFloat", 0f);
			gameObject.GetComponent<Animator>().Play("Animation");
			base.transform.Find("HitSound").GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x0001DDDC File Offset: 0x0001BFDC
	protected static void InvokeUserCode_RpcPushPlayer__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPushPlayer called on server.");
			return;
		}
		((PlayerNetwork)obj).UserCode_RpcPushPlayer__Vector3(reader.ReadVector3());
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0001DE08 File Offset: 0x0001C008
	protected void UserCode_RpcPlayPlayerAnimation__Int32(int animationIndex)
	{
		GameObject gameObject = null;
		using (IEnumerator enumerator = base.transform.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (((Transform)enumerator.Current).name == "Character")
				{
					gameObject = base.transform.Find("Character").gameObject;
					break;
				}
			}
		}
		if (gameObject)
		{
			gameObject.GetComponent<Animator>().SetFloat("AnimationFloat", (float)animationIndex);
			gameObject.GetComponent<Animator>().Play("Animation");
		}
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x0001DEB0 File Offset: 0x0001C0B0
	protected static void InvokeUserCode_RpcPlayPlayerAnimation__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayPlayerAnimation called on server.");
			return;
		}
		((PlayerNetwork)obj).UserCode_RpcPlayPlayerAnimation__Int32(reader.ReadInt());
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0001DED9 File Offset: 0x0001C0D9
	protected void UserCode_CmdPlayPricingSound()
	{
		this.RpcPlayPricingSound();
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0001DEE1 File Offset: 0x0001C0E1
	protected static void InvokeUserCode_CmdPlayPricingSound(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayPricingSound called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdPlayPricingSound();
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0001DF04 File Offset: 0x0001C104
	protected void UserCode_RpcPlayPricingSound()
	{
		AudioClip clip = this.pricingSoundsArray[Random.Range(0, this.pricingSoundsArray.Length - 1)];
		AudioSource component = base.transform.Find("PricingSound").GetComponent<AudioSource>();
		component.clip = clip;
		component.Play();
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0001DF4A File Offset: 0x0001C14A
	protected static void InvokeUserCode_RpcPlayPricingSound(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayPricingSound called on server.");
			return;
		}
		((PlayerNetwork)obj).UserCode_RpcPlayPricingSound();
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0001DF6D File Offset: 0x0001C16D
	protected void UserCode_CmdPlayPose__Int32(int poseIndex)
	{
		this.RpcPlayPose(poseIndex);
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0001DF76 File Offset: 0x0001C176
	protected static void InvokeUserCode_CmdPlayPose__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdPlayPose called on client.");
			return;
		}
		((PlayerNetwork)obj).UserCode_CmdPlayPose__Int32(reader.ReadInt());
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0001DFA0 File Offset: 0x0001C1A0
	protected void UserCode_RpcPlayPose__Int32(int poseIndex)
	{
		GameObject gameObject = null;
		using (IEnumerator enumerator = base.transform.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (((Transform)enumerator.Current).name == "Character")
				{
					gameObject = base.transform.Find("Character").gameObject;
					break;
				}
			}
		}
		if (gameObject)
		{
			gameObject.GetComponent<Animator>().SetFloat("PoseFloat", (float)poseIndex);
			gameObject.GetComponent<Animator>().Play("Pose");
		}
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0001E048 File Offset: 0x0001C248
	protected static void InvokeUserCode_RpcPlayPose__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayPose called on server.");
			return;
		}
		((PlayerNetwork)obj).UserCode_RpcPlayPose__Int32(reader.ReadInt());
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0001E074 File Offset: 0x0001C274
	static PlayerNetwork()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdCrouch(System.Boolean)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdCrouch__Boolean), true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdSetBoxColorToEveryone(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdSetBoxColorToEveryone__Int32), true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdChangeCharacter(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdChangeCharacter__Int32), true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdChangeHat(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdChangeHat__Int32), true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdChangeEquippedItem(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdChangeEquippedItem__Int32), true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdPlayAnimation(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdPlayAnimation__Int32), true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdPushPlayer(UnityEngine.Vector3)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdPushPlayer__Vector3), false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdPlayPricingSound()", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdPlayPricingSound), true);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerNetwork), "System.Void PlayerNetwork::CmdPlayPose(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_CmdPlayPose__Int32), true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerNetwork), "System.Void PlayerNetwork::RpcSetBoxColorToEveryone(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_RpcSetBoxColorToEveryone__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerNetwork), "System.Void PlayerNetwork::RpcPlayAnimation(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_RpcPlayAnimation__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerNetwork), "System.Void PlayerNetwork::RpcPushPlayer(UnityEngine.Vector3)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_RpcPushPlayer__Vector3));
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerNetwork), "System.Void PlayerNetwork::RpcPlayPlayerAnimation(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_RpcPlayPlayerAnimation__Int32));
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerNetwork), "System.Void PlayerNetwork::RpcPlayPricingSound()", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_RpcPlayPricingSound));
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerNetwork), "System.Void PlayerNetwork::RpcPlayPose(System.Int32)", new RemoteCallDelegate(PlayerNetwork.InvokeUserCode_RpcPlayPose__Int32));
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0001E26C File Offset: 0x0001C46C
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.equippedItem);
			writer.WriteInt(this.characterID);
			writer.WriteInt(this.hatID);
			writer.WriteBool(this.isCrouching);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.equippedItem);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteInt(this.characterID);
		}
		if ((this.syncVarDirtyBits & 4UL) != 0UL)
		{
			writer.WriteInt(this.hatID);
		}
		if ((this.syncVarDirtyBits & 8UL) != 0UL)
		{
			writer.WriteBool(this.isCrouching);
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0001E350 File Offset: 0x0001C550
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.equippedItem, this._Mirror_SyncVarHookDelegate_equippedItem, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<int>(ref this.characterID, this._Mirror_SyncVarHookDelegate_characterID, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<int>(ref this.hatID, this._Mirror_SyncVarHookDelegate_hatID, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<bool>(ref this.isCrouching, this._Mirror_SyncVarHookDelegate_isCrouching, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.equippedItem, this._Mirror_SyncVarHookDelegate_equippedItem, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.characterID, this._Mirror_SyncVarHookDelegate_characterID, reader.ReadInt());
		}
		if ((num & 4L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.hatID, this._Mirror_SyncVarHookDelegate_hatID, reader.ReadInt());
		}
		if ((num & 8L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.isCrouching, this._Mirror_SyncVarHookDelegate_isCrouching, reader.ReadBool());
		}
	}

	// Token: 0x04000353 RID: 851
	[SyncVar(hook = "OnChangeEquipment")]
	public int equippedItem;

	// Token: 0x04000354 RID: 852
	[SyncVar(hook = "OnChangeCharacter")]
	public int characterID;

	// Token: 0x04000355 RID: 853
	[SyncVar(hook = "OnChangeHat")]
	public int hatID;

	// Token: 0x04000356 RID: 854
	[SyncVar(hook = "OnCrouch")]
	public bool isCrouching;

	// Token: 0x04000357 RID: 855
	public GameObject dummyBoxPrefab;

	// Token: 0x04000358 RID: 856
	public GameObject[] equippedPrefabs;

	// Token: 0x04000359 RID: 857
	public GameObject[] playerCharacter;

	// Token: 0x0400035A RID: 858
	public GameObject[] hatsArray;

	// Token: 0x0400035B RID: 859
	public GameObject equippedParentOBJ;

	// Token: 0x0400035C RID: 860
	public GameObject hatSpawnspot;

	// Token: 0x0400035D RID: 861
	public int extraParameter1;

	// Token: 0x0400035E RID: 862
	public int extraParameter2;

	// Token: 0x0400035F RID: 863
	public LayerMask lMask;

	// Token: 0x04000360 RID: 864
	public LayerMask interactableMask;

	// Token: 0x04000361 RID: 865
	public LayerMask playerRaycastMask;

	// Token: 0x04000362 RID: 866
	private Player MainPlayer;

	// Token: 0x04000363 RID: 867
	private int playerId;

	// Token: 0x04000364 RID: 868
	public GameObject instantiatedOBJ;

	// Token: 0x04000365 RID: 869
	private TextMeshProUGUI canvasTMP;

	// Token: 0x04000366 RID: 870
	private GameObject pricingCanvas;

	// Token: 0x04000367 RID: 871
	private TextMeshProUGUI productNameTMP;

	// Token: 0x04000368 RID: 872
	private TextMeshProUGUI productBrandTMP;

	// Token: 0x04000369 RID: 873
	private Image productImage;

	// Token: 0x0400036A RID: 874
	private TextMeshProUGUI marketPriceTMP;

	// Token: 0x0400036B RID: 875
	private TextMeshProUGUI yourPriceTMP;

	// Token: 0x0400036C RID: 876
	private float pPrice;

	// Token: 0x0400036D RID: 877
	public int oldProductID;

	// Token: 0x0400036E RID: 878
	private int oldCanvasProductID;

	// Token: 0x0400036F RID: 879
	public GameObject hatOBJ;

	// Token: 0x04000370 RID: 880
	private GameObject gameCanvasProductOBJ;

	// Token: 0x04000371 RID: 881
	private bool dropCooldown;

	// Token: 0x04000372 RID: 882
	private bool backupBool;

	// Token: 0x04000373 RID: 883
	private bool crouchCoroutineRunning;

	// Token: 0x04000374 RID: 884
	private Coroutine coroutineVariable;

	// Token: 0x04000375 RID: 885
	public AudioClip[] pricingSoundsArray;

	// Token: 0x04000376 RID: 886
	private string[] keyCodes = new string[]
	{
		"Numpad 0",
		"Numpad 1",
		"Numpad 2",
		"Numpad 3",
		"Numpad 4",
		"Numpad 5",
		"Numpad 6",
		"Numpad 7",
		"Numpad 8",
		"Numpad 9"
	};

	// Token: 0x04000377 RID: 887
	private string[] poseKeyCodes = new string[]
	{
		"NoOwo",
		"Dance 1",
		"Dance 2",
		"Dance 3",
		"Dance 4",
		"Dance 5",
		"Dance 6",
		"Dance 7",
		"Dance 8",
		"Dance 9"
	};

	// Token: 0x04000378 RID: 888
	public int[] posesArray = new int[10];

	// Token: 0x04000379 RID: 889
	private string basefloatString;

	// Token: 0x0400037A RID: 890
	public Action<int, int> _Mirror_SyncVarHookDelegate_equippedItem;

	// Token: 0x0400037B RID: 891
	public Action<int, int> _Mirror_SyncVarHookDelegate_characterID;

	// Token: 0x0400037C RID: 892
	public Action<int, int> _Mirror_SyncVarHookDelegate_hatID;

	// Token: 0x0400037D RID: 893
	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isCrouching;
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HutongGames.PlayMaker;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using UnityEngine;

// Token: 0x02000089 RID: 137
public class PlayerObjectController : NetworkBehaviour
{
	// Token: 0x1700006D RID: 109
	// (get) Token: 0x0600046E RID: 1134 RVA: 0x0001EE60 File Offset: 0x0001D060
	private CustomNetworkManager Manager
	{
		get
		{
			if (this.manager != null)
			{
				return this.manager;
			}
			return this.manager = (NetworkManager.singleton as CustomNetworkManager);
		}
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x0001EE95 File Offset: 0x0001D095
	public void SendChatMsg(string message)
	{
		this.CmdSendMessage(message, null);
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x0001EEA0 File Offset: 0x0001D0A0
	[Command(requiresAuthority = false)]
	private void CmdSendMessage(string message, NetworkConnectionToClient sender = null)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(message);
		base.SendCommandInternal("System.Void PlayerObjectController::CmdSendMessage(System.String,Mirror.NetworkConnectionToClient)", 1630221023, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0001EEDC File Offset: 0x0001D0DC
	[ClientRpc]
	private void RpcReceiveChatMsg(string playerName, string message)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(playerName);
		writer.WriteString(message);
		this.SendRPCInternal("System.Void PlayerObjectController::RpcReceiveChatMsg(System.String,System.String)", -446234640, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x0001EF20 File Offset: 0x0001D120
	public override void OnStartAuthority()
	{
		this.CmdSetPlayerName(SteamFriends.GetPersonaName().ToString());
		base.gameObject.name = "LocalGamePlayer";
		LobbyController.Instance.FindLocalPlayer();
		LobbyController.Instance.UpdateLobbyName();
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x0001EF56 File Offset: 0x0001D156
	public override void OnStartClient()
	{
		this.Manager.GamePlayers.Add(this);
		LobbyController.Instance.UpdateLobbyName();
		LobbyController.Instance.UpdatePlayerList();
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x0001EF7D File Offset: 0x0001D17D
	public override void OnStopClient()
	{
		this.Manager.GamePlayers.Remove(this);
		LobbyController.Instance.UpdatePlayerList();
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x0001EF9C File Offset: 0x0001D19C
	[Command]
	private void CmdSetPlayerName(string PlayerName)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(PlayerName);
		base.SendCommandInternal("System.Void PlayerObjectController::CmdSetPlayerName(System.String)", 1583141151, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0001EFD6 File Offset: 0x0001D1D6
	public void PlayerNameUpdate(string OldValue, string NewValue)
	{
		if (base.isServer)
		{
			this.NetworkPlayerName = NewValue;
		}
		if (base.isClient)
		{
			LobbyController.Instance.UpdatePlayerList();
		}
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0001EFF9 File Offset: 0x0001D1F9
	public PlayerObjectController()
	{
		this._Mirror_SyncVarHookDelegate_PlayerName = new Action<string, string>(this.PlayerNameUpdate);
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x0001F014 File Offset: 0x0001D214
	static PlayerObjectController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerObjectController), "System.Void PlayerObjectController::CmdSendMessage(System.String,Mirror.NetworkConnectionToClient)", new RemoteCallDelegate(PlayerObjectController.InvokeUserCode_CmdSendMessage__String__NetworkConnectionToClient), false);
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerObjectController), "System.Void PlayerObjectController::CmdSetPlayerName(System.String)", new RemoteCallDelegate(PlayerObjectController.InvokeUserCode_CmdSetPlayerName__String), true);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerObjectController), "System.Void PlayerObjectController::RpcReceiveChatMsg(System.String,System.String)", new RemoteCallDelegate(PlayerObjectController.InvokeUserCode_RpcReceiveChatMsg__String__String));
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x0600047A RID: 1146 RVA: 0x0001F090 File Offset: 0x0001D290
	// (set) Token: 0x0600047B RID: 1147 RVA: 0x0001F0A3 File Offset: 0x0001D2A3
	public int NetworkConnectionID
	{
		get
		{
			return this.ConnectionID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.ConnectionID, 1UL, null);
		}
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x0600047C RID: 1148 RVA: 0x0001F0C0 File Offset: 0x0001D2C0
	// (set) Token: 0x0600047D RID: 1149 RVA: 0x0001F0D3 File Offset: 0x0001D2D3
	public int NetworkPlayerIdNumber
	{
		get
		{
			return this.PlayerIdNumber;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.PlayerIdNumber, 2UL, null);
		}
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x0600047E RID: 1150 RVA: 0x0001F0F0 File Offset: 0x0001D2F0
	// (set) Token: 0x0600047F RID: 1151 RVA: 0x0001F103 File Offset: 0x0001D303
	public ulong NetworkPlayerSteamID
	{
		get
		{
			return this.PlayerSteamID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<ulong>(value, ref this.PlayerSteamID, 4UL, null);
		}
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001F120 File Offset: 0x0001D320
	// (set) Token: 0x06000481 RID: 1153 RVA: 0x0001F133 File Offset: 0x0001D333
	public string NetworkPlayerName
	{
		get
		{
			return this.PlayerName;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<string>(value, ref this.PlayerName, 8UL, this._Mirror_SyncVarHookDelegate_PlayerName);
		}
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0001F154 File Offset: 0x0001D354
	protected void UserCode_CmdSendMessage__String__NetworkConnectionToClient(string message, NetworkConnectionToClient sender)
	{
		if (!PlayerObjectController.connNames.ContainsKey(sender))
		{
			PlayerObjectController.connNames.Add(sender, sender.identity.GetComponent<PlayerObjectController>().PlayerName);
		}
		if (!string.IsNullOrWhiteSpace(message))
		{
			this.RpcReceiveChatMsg(PlayerObjectController.connNames[sender], message.Trim());
		}
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0001F1A8 File Offset: 0x0001D3A8
	protected static void InvokeUserCode_CmdSendMessage__String__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSendMessage called on client.");
			return;
		}
		((PlayerObjectController)obj).UserCode_CmdSendMessage__String__NetworkConnectionToClient(reader.ReadString(), senderConnection);
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0001F1D4 File Offset: 0x0001D3D4
	protected void UserCode_RpcReceiveChatMsg__String__String(string playerName, string message)
	{
		if (message.Contains("</color>") || message.Contains("</size>") || message.Contains("</material>") || message.Contains("</b>") || message.Contains("</i>"))
		{
			return;
		}
		string value = (playerName == this.PlayerName) ? ("<color=red>" + playerName + ":</color> " + message) : ("<color=blue>" + playerName + ":</color> " + message);
		this.chatFSM = LobbyController.Instance.ChatContainerOBJ.GetComponent<PlayMakerFSM>();
		this.chatFSM.FsmVariables.GetFsmString("Message").Value = value;
		this.chatFSM.SendEvent("Send_Data");
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0001F296 File Offset: 0x0001D496
	protected static void InvokeUserCode_RpcReceiveChatMsg__String__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcReceiveChatMsg called on server.");
			return;
		}
		((PlayerObjectController)obj).UserCode_RpcReceiveChatMsg__String__String(reader.ReadString(), reader.ReadString());
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0001F2C5 File Offset: 0x0001D4C5
	protected void UserCode_CmdSetPlayerName__String(string PlayerName)
	{
		this.PlayerNameUpdate(this.PlayerName, PlayerName);
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0001F2D4 File Offset: 0x0001D4D4
	protected static void InvokeUserCode_CmdSetPlayerName__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSetPlayerName called on client.");
			return;
		}
		((PlayerObjectController)obj).UserCode_CmdSetPlayerName__String(reader.ReadString());
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0001F300 File Offset: 0x0001D500
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.ConnectionID);
			writer.WriteInt(this.PlayerIdNumber);
			writer.WriteULong(this.PlayerSteamID);
			writer.WriteString(this.PlayerName);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.ConnectionID);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteInt(this.PlayerIdNumber);
		}
		if ((this.syncVarDirtyBits & 4UL) != 0UL)
		{
			writer.WriteULong(this.PlayerSteamID);
		}
		if ((this.syncVarDirtyBits & 8UL) != 0UL)
		{
			writer.WriteString(this.PlayerName);
		}
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x0001F3E4 File Offset: 0x0001D5E4
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.ConnectionID, null, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<int>(ref this.PlayerIdNumber, null, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<ulong>(ref this.PlayerSteamID, null, reader.ReadULong());
			base.GeneratedSyncVarDeserialize<string>(ref this.PlayerName, this._Mirror_SyncVarHookDelegate_PlayerName, reader.ReadString());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.ConnectionID, null, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.PlayerIdNumber, null, reader.ReadInt());
		}
		if ((num & 4L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<ulong>(ref this.PlayerSteamID, null, reader.ReadULong());
		}
		if ((num & 8L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<string>(ref this.PlayerName, this._Mirror_SyncVarHookDelegate_PlayerName, reader.ReadString());
		}
	}

	// Token: 0x0400039D RID: 925
	[SyncVar]
	public int ConnectionID;

	// Token: 0x0400039E RID: 926
	[SyncVar]
	public int PlayerIdNumber;

	// Token: 0x0400039F RID: 927
	[SyncVar]
	public ulong PlayerSteamID;

	// Token: 0x040003A0 RID: 928
	[SyncVar(hook = "PlayerNameUpdate")]
	public string PlayerName;

	// Token: 0x040003A1 RID: 929
	public string PlayerSteamIDString;

	// Token: 0x040003A2 RID: 930
	private CustomNetworkManager manager;

	// Token: 0x040003A3 RID: 931
	private GameObject masterOBJ;

	// Token: 0x040003A4 RID: 932
	private GameObject playmakerDataManager;

	// Token: 0x040003A5 RID: 933
	private PlayMakerFSM dataPlayerFSM;

	// Token: 0x040003A6 RID: 934
	private FsmArray fsmArray;

	// Token: 0x040003A7 RID: 935
	internal static readonly Dictionary<NetworkConnectionToClient, string> connNames = new Dictionary<NetworkConnectionToClient, string>();

	// Token: 0x040003A8 RID: 936
	public GameObject chatContainerOBJ;

	// Token: 0x040003A9 RID: 937
	private PlayMakerFSM chatFSM;

	// Token: 0x040003AA RID: 938
	public Action<string, string> _Mirror_SyncVarHookDelegate_PlayerName;
}

using System;
using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class PlayerPermissions : NetworkBehaviour
{
	// Token: 0x060005BF RID: 1471 RVA: 0x000278E3 File Offset: 0x00025AE3
	public bool RequestGP()
	{
		return this.hasGP;
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x000278EB File Offset: 0x00025AEB
	public void PPlayer()
	{
		if (base.isServer)
		{
			this.hasGP = !this.hasGP;
			this.RpcPPlayer(this.hasGP);
		}
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x00027910 File Offset: 0x00025B10
	[ClientRpc]
	private void RpcPPlayer(bool set)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(set);
		this.SendRPCInternal("System.Void PlayerPermissions::RpcPPlayer(System.Boolean)", -1309257383, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x0002794A File Offset: 0x00025B4A
	public void JPlayer(int times)
	{
		if (!this.onCooldown && base.isServer)
		{
			this.RpcJPlayer(times);
			base.StartCoroutine(this.JCooldown());
		}
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x00027970 File Offset: 0x00025B70
	[ClientRpc]
	private void RpcJPlayer(int times)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(times);
		this.SendRPCInternal("System.Void PlayerPermissions::RpcJPlayer(System.Int32)", 368754251, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x000279AA File Offset: 0x00025BAA
	public void KPlayer()
	{
		if (base.GetComponent<PlayerObjectController>().ConnectionID != 0 && base.isServer)
		{
			base.GetComponent<NetworkIdentity>().connectionToClient.Disconnect();
		}
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x000279D1 File Offset: 0x00025BD1
	private IEnumerator JCooldown()
	{
		this.onCooldown = true;
		yield return new WaitForSeconds(10f);
		this.onCooldown = false;
		yield break;
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x000279EF File Offset: 0x00025BEF
	protected void UserCode_RpcPPlayer__Boolean(bool set)
	{
		this.hasGP = set;
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x000279F8 File Offset: 0x00025BF8
	protected static void InvokeUserCode_RpcPPlayer__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPPlayer called on server.");
			return;
		}
		((PlayerPermissions)obj).UserCode_RpcPPlayer__Boolean(reader.ReadBool());
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x00027A24 File Offset: 0x00025C24
	protected void UserCode_RpcJPlayer__Int32(int times)
	{
		if (base.isLocalPlayer && GameCanvas.Instance)
		{
			times = Mathf.Clamp(times, 10, 1000);
			PlayMakerFSM component = GameCanvas.Instance.jReference.GetComponent<PlayMakerFSM>();
			component.FsmVariables.GetFsmInt("Times").Value = times;
			component.SendEvent("Send_Data");
			if (Camera.main)
			{
				CustomCameraController component2 = Camera.main.GetComponent<CustomCameraController>();
				if (component2.isInCameraEvent)
				{
					component2.RestoreCamera();
				}
			}
			base.GetComponent<FirstPersonTransform>().coroutineActivator(new Vector3(29f, 0.25f, 10f), 0f);
		}
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x00027AD2 File Offset: 0x00025CD2
	protected static void InvokeUserCode_RpcJPlayer__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcJPlayer called on server.");
			return;
		}
		((PlayerPermissions)obj).UserCode_RpcJPlayer__Int32(reader.ReadInt());
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x00027AFC File Offset: 0x00025CFC
	static PlayerPermissions()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerPermissions), "System.Void PlayerPermissions::RpcPPlayer(System.Boolean)", new RemoteCallDelegate(PlayerPermissions.InvokeUserCode_RpcPPlayer__Boolean));
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerPermissions), "System.Void PlayerPermissions::RpcJPlayer(System.Int32)", new RemoteCallDelegate(PlayerPermissions.InvokeUserCode_RpcJPlayer__Int32));
	}

	// Token: 0x040004C0 RID: 1216
	private bool onCooldown;

	// Token: 0x040004C1 RID: 1217
	private bool hasGP = true;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;
using UnityEngine.Animations.Rigging;

// Token: 0x0200008A RID: 138
public class PlayerSyncCharacter : NetworkBehaviour
{
	// Token: 0x0600048A RID: 1162 RVA: 0x0001F4EE File Offset: 0x0001D6EE
	private void Start()
	{
		this.pNetwork = base.GetComponent<PlayerNetwork>();
		base.StartCoroutine(this.CalculateVelocity());
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x0001F509 File Offset: 0x0001D709
	private IEnumerator CalculateVelocity()
	{
		while (Application.isPlaying)
		{
			Vector3 prevPos = base.transform.position;
			yield return new WaitForEndOfFrame();
			this.playerVelocity = (prevPos - base.transform.position).magnitude / Time.deltaTime;
			this.playerVelocity = Mathf.Round(this.playerVelocity * 10f) / 10f;
			if (this.animator)
			{
				if (this.inVehicle)
				{
					this.animator.SetFloat("MoveFactor", 0f);
				}
				else
				{
					this.animator.SetFloat("MoveFactor", this.playerVelocity);
				}
			}
			prevPos = default(Vector3);
		}
		yield break;
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0001F518 File Offset: 0x0001D718
	private void LateUpdate()
	{
		if (!this.characterOBJ)
		{
			using (IEnumerator enumerator = base.transform.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (((Transform)enumerator.Current).name == "Character")
					{
						this.characterOBJ = base.transform.Find("Character").gameObject;
						break;
					}
				}
			}
			if (!this.characterOBJ)
			{
				return;
			}
			this.animator = this.characterOBJ.GetComponent<Animator>();
			this.rightHandConstraint = this.characterOBJ.transform.Find("Rig/RigHandIK").GetComponent<TwoBoneIKConstraint>();
			this.leftHandConstraint = this.characterOBJ.transform.Find("Rig/LeftHandIK").GetComponent<TwoBoneIKConstraint>();
			this.rightHandOBJ = this.characterOBJ.transform.Find("IKOBJs/RightHandTarget");
			this.leftHandOBJ = this.characterOBJ.transform.Find("IKOBJs/LeftHandTarget");
			return;
		}
		else
		{
			if (!this.headOBJ)
			{
				this.headOBJ = this.characterOBJ.transform.Find("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Spine2/Bip01 Neck/Bip01 Head").gameObject;
				return;
			}
			if (base.isLocalPlayer)
			{
				float num = Camera.main.transform.localEulerAngles.x;
				if (num > 180f)
				{
					num -= 360f;
				}
				num *= -1f;
				num = Mathf.Clamp(num, -45f, 45f);
				this.NetworkheadAngle = Mathf.Round(num * 100f) / 100f;
			}
			else
			{
				this.headOBJ.transform.localRotation = Quaternion.Euler(0f, 0f, this.headAngle);
			}
			int equippedItem = this.pNetwork.equippedItem;
			if (equippedItem > 0)
			{
				switch (equippedItem)
				{
				case 1:
				case 4:
					if (!this.rightHandDestinationOBJ && this.pNetwork.instantiatedOBJ && this.pNetwork.instantiatedOBJ.transform.Find("RightHandIK"))
					{
						this.rightHandDestinationOBJ = this.pNetwork.instantiatedOBJ.transform.Find("RightHandIK");
						this.rightHandConstraint.weight = 1f;
					}
					if (!this.leftHandDestinationOBJ && this.pNetwork.instantiatedOBJ && this.pNetwork.instantiatedOBJ.transform.Find("LeftHandIK"))
					{
						this.leftHandDestinationOBJ = this.pNetwork.instantiatedOBJ.transform.Find("LeftHandIK");
						this.leftHandConstraint.weight = 1f;
					}
					if (this.rightHandOBJ)
					{
						this.rightHandOBJ.position = this.rightHandDestinationOBJ.position;
						this.rightHandOBJ.rotation = this.rightHandDestinationOBJ.rotation;
					}
					if (this.leftHandOBJ)
					{
						this.leftHandOBJ.position = this.leftHandDestinationOBJ.position;
						this.leftHandOBJ.rotation = this.leftHandDestinationOBJ.rotation;
						return;
					}
					break;
				case 2:
				case 3:
				case 5:
					if (!this.rightHandDestinationOBJ && this.pNetwork.instantiatedOBJ && this.pNetwork.instantiatedOBJ.transform.Find("RightHandIK"))
					{
						this.rightHandDestinationOBJ = this.pNetwork.instantiatedOBJ.transform.Find("RightHandIK");
						this.rightHandConstraint.weight = 1f;
					}
					this.rightHandOBJ.position = this.rightHandDestinationOBJ.position;
					this.rightHandOBJ.rotation = this.rightHandDestinationOBJ.rotation;
					return;
				default:
					return;
				}
			}
			else
			{
				if (this.rightHandConstraint.weight == 1f)
				{
					this.rightHandConstraint.weight = 0f;
				}
				if (this.leftHandConstraint.weight == 1f)
				{
					this.leftHandConstraint.weight = 0f;
				}
			}
			return;
		}
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x0600048F RID: 1167 RVA: 0x0001F954 File Offset: 0x0001DB54
	// (set) Token: 0x06000490 RID: 1168 RVA: 0x0001F967 File Offset: 0x0001DB67
	public float NetworkheadAngle
	{
		get
		{
			return this.headAngle;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<float>(value, ref this.headAngle, 1UL, null);
		}
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x06000491 RID: 1169 RVA: 0x0001F984 File Offset: 0x0001DB84
	// (set) Token: 0x06000492 RID: 1170 RVA: 0x0001F997 File Offset: 0x0001DB97
	public bool NetworkinVehicle
	{
		get
		{
			return this.inVehicle;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.inVehicle, 2UL, null);
		}
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0001F9B4 File Offset: 0x0001DBB4
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(this.headAngle);
			writer.WriteBool(this.inVehicle);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteFloat(this.headAngle);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteBool(this.inVehicle);
		}
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x0001FA3C File Offset: 0x0001DC3C
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<float>(ref this.headAngle, null, reader.ReadFloat());
			base.GeneratedSyncVarDeserialize<bool>(ref this.inVehicle, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<float>(ref this.headAngle, null, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.inVehicle, null, reader.ReadBool());
		}
	}

	// Token: 0x040003AB RID: 939
	[SyncVar]
	public float headAngle;

	// Token: 0x040003AC RID: 940
	[SyncVar]
	public bool inVehicle;

	// Token: 0x040003AD RID: 941
	public byte characterNumber;

	// Token: 0x040003AE RID: 942
	public GameObject characterOBJ;

	// Token: 0x040003AF RID: 943
	private Animator animator;

	// Token: 0x040003B0 RID: 944
	public GameObject headOBJ;

	// Token: 0x040003B1 RID: 945
	private PlayerNetwork pNetwork;

	// Token: 0x040003B2 RID: 946
	private TwoBoneIKConstraint rightHandConstraint;

	// Token: 0x040003B3 RID: 947
	private TwoBoneIKConstraint leftHandConstraint;

	// Token: 0x040003B4 RID: 948
	private Transform rightHandOBJ;

	// Token: 0x040003B5 RID: 949
	private Transform rightHandDestinationOBJ;

	// Token: 0x040003B6 RID: 950
	private Transform rightHandHintDestinationOBJ;

	// Token: 0x040003B7 RID: 951
	private Transform leftHandOBJ;

	// Token: 0x040003B8 RID: 952
	private Transform leftHandDestinationOBJ;

	// Token: 0x040003B9 RID: 953
	private Transform leftHandHintDestinationOBJ;

	// Token: 0x040003BA RID: 954
	public float playerVelocity;
}

using System;

// Token: 0x02000024 RID: 36
public class PlayMakerActionsUtils
{
	// Token: 0x02000025 RID: 37
	public enum EveryFrameUpdateSelector
	{
		// Token: 0x040000F0 RID: 240
		OnUpdate,
		// Token: 0x040000F1 RID: 241
		OnLateUpdate,
		// Token: 0x040000F2 RID: 242
		OnFixedUpdate
	}
}

using System;
using System.Collections;
using System.Linq;
using UnityEngine;

// Token: 0x02000020 RID: 32
public class PlayMakerArrayListProxy : PlayMakerCollectionProxy
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600006E RID: 110 RVA: 0x00006CD4 File Offset: 0x00004ED4
	public ArrayList arrayList
	{
		get
		{
			return this._arrayList;
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00006CDC File Offset: 0x00004EDC
	public void Awake()
	{
		this._arrayList = new ArrayList();
		this.PreFillArrayList();
		this.TakeSnapShot();
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00006CF5 File Offset: 0x00004EF5
	public bool isCollectionDefined()
	{
		return this.arrayList != null;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00006D00 File Offset: 0x00004F00
	public void TakeSnapShot()
	{
		this._snapShot = new ArrayList();
		this._snapShot.AddRange(this._arrayList);
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00006D1E File Offset: 0x00004F1E
	public void RevertToSnapShot()
	{
		this._arrayList = new ArrayList();
		this._arrayList.AddRange(this._snapShot);
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00006D3C File Offset: 0x00004F3C
	public void Add(object value, string type, bool silent = false)
	{
		this.arrayList.Add(value);
		if (!silent)
		{
			base.dispatchEvent(this.addEvent, value, type);
		}
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00006D5C File Offset: 0x00004F5C
	public int AddRange(ICollection collection, string type)
	{
		this.arrayList.AddRange(collection);
		return this.arrayList.Count;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00006D75 File Offset: 0x00004F75
	public void InspectorEdit(int index)
	{
		base.dispatchEvent(this.setEvent, index, "int");
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00006D8E File Offset: 0x00004F8E
	public void Set(int index, object value, string type)
	{
		this.arrayList[index] = value;
		base.dispatchEvent(this.setEvent, index, "int");
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00006DB4 File Offset: 0x00004FB4
	public bool Remove(object value, string type, bool silent = false)
	{
		if (this.arrayList.Contains(value))
		{
			this.arrayList.Remove(value);
			if (!silent)
			{
				base.dispatchEvent(this.removeEvent, value, type);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00006DE4 File Offset: 0x00004FE4
	[ContextMenu("Copy ArrayList Content")]
	private void CopyContentToPrefill()
	{
		this.preFillCount = this.arrayList.Count;
		switch (this.preFillType)
		{
		case PlayMakerCollectionProxy.VariableEnum.GameObject:
			this.preFillGameObjectList = this.arrayList.OfType<GameObject>().ToList<GameObject>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Int:
			this.preFillIntList = this.arrayList.OfType<int>().ToList<int>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Float:
			this.preFillFloatList = this.arrayList.OfType<float>().ToList<float>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.String:
			this.preFillStringList = this.arrayList.OfType<string>().ToList<string>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Bool:
			this.preFillBoolList = this.arrayList.OfType<bool>().ToList<bool>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Vector3:
			this.preFillVector3List = this.arrayList.OfType<Vector3>().ToList<Vector3>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Rect:
			this.preFillRectList = this.arrayList.OfType<Rect>().ToList<Rect>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Quaternion:
			this.preFillQuaternionList = this.arrayList.OfType<Quaternion>().ToList<Quaternion>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Color:
			this.preFillColorList = this.arrayList.OfType<Color>().ToList<Color>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Material:
			this.preFillMaterialList = this.arrayList.OfType<Material>().ToList<Material>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Texture:
			this.preFillTextureList = this.arrayList.OfType<Texture2D>().ToList<Texture2D>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Vector2:
			this.preFillVector2List = this.arrayList.OfType<Vector2>().ToList<Vector2>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.AudioClip:
			this.preFillAudioClipList = this.arrayList.OfType<AudioClip>().ToList<AudioClip>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Byte:
			this.preFillByteList = this.arrayList.OfType<byte>().ToList<byte>();
			return;
		case PlayMakerCollectionProxy.VariableEnum.Sprite:
			this.preFillSpriteList = this.arrayList.OfType<Sprite>().ToList<Sprite>();
			return;
		default:
			return;
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00006FA4 File Offset: 0x000051A4
	private void PreFillArrayList()
	{
		switch (this.preFillType)
		{
		case PlayMakerCollectionProxy.VariableEnum.GameObject:
			this.arrayList.InsertRange(0, this.preFillGameObjectList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Int:
			this.arrayList.InsertRange(0, this.preFillIntList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Float:
			this.arrayList.InsertRange(0, this.preFillFloatList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.String:
			this.arrayList.InsertRange(0, this.preFillStringList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Bool:
			this.arrayList.InsertRange(0, this.preFillBoolList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Vector3:
			this.arrayList.InsertRange(0, this.preFillVector3List);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Rect:
			this.arrayList.InsertRange(0, this.preFillRectList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Quaternion:
			this.arrayList.InsertRange(0, this.preFillQuaternionList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Color:
			this.arrayList.InsertRange(0, this.preFillColorList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Material:
			this.arrayList.InsertRange(0, this.preFillMaterialList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Texture:
			this.arrayList.InsertRange(0, this.preFillTextureList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Vector2:
			this.arrayList.InsertRange(0, this.preFillVector2List);
			return;
		case PlayMakerCollectionProxy.VariableEnum.AudioClip:
			this.arrayList.InsertRange(0, this.preFillAudioClipList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Byte:
			this.arrayList.InsertRange(0, this.preFillByteList);
			return;
		case PlayMakerCollectionProxy.VariableEnum.Sprite:
			this.arrayList.InsertRange(0, this.preFillSpriteList);
			return;
		default:
			return;
		}
	}

	// Token: 0x040000BA RID: 186
	public ArrayList _arrayList;

	// Token: 0x040000BB RID: 187
	private ArrayList _snapShot;
}

using System;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using UnityEngine;

// Token: 0x02000021 RID: 33
public abstract class PlayMakerCollectionProxy : MonoBehaviour
{
	// Token: 0x0600007B RID: 123 RVA: 0x0000711F File Offset: 0x0000531F
	internal string getFsmVariableType(VariableType _type)
	{
		return _type.ToString();
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00007130 File Offset: 0x00005330
	internal void dispatchEvent(string anEvent, object value, string type)
	{
		if (!this.enablePlayMakerEvents)
		{
			return;
		}
		uint num = <PrivateImplementationDetails>.ComputeStringHash(type);
		if (num <= 1707186308U)
		{
			if (num <= 655918371U)
			{
				if (num != 398550328U)
				{
					if (num != 639140752U)
					{
						if (num == 655918371U)
						{
							if (type == "vector3")
							{
								Fsm.EventData.Vector3Data = (Vector3)value;
							}
						}
					}
					else if (type == "vector2")
					{
						Fsm.EventData.Vector3Data = (Vector3)value;
					}
				}
				else if (type == "string")
				{
					Fsm.EventData.StringData = (string)value;
				}
			}
			else if (num != 1013213428U)
			{
				if (num != 1031692888U)
				{
					if (num == 1707186308U)
					{
						if (type == "gameObject")
						{
							Fsm.EventData.GameObjectData = (GameObject)value;
						}
					}
				}
				else if (type == "color")
				{
					Fsm.EventData.ColorData = (Color)value;
				}
			}
			else if (type == "texture")
			{
				Fsm.EventData.TextureData = (Texture)value;
			}
		}
		else if (num <= 3099987130U)
		{
			if (num != 2515107422U)
			{
				if (num != 2797886853U)
				{
					if (num == 3099987130U)
					{
						if (type == "object")
						{
							Fsm.EventData.ObjectData = (Object)value;
						}
					}
				}
				else if (type == "float")
				{
					Fsm.EventData.FloatData = (float)value;
				}
			}
			else if (type == "int")
			{
				Fsm.EventData.IntData = (int)value;
			}
		}
		else if (num <= 3538210912U)
		{
			if (num != 3365180733U)
			{
				if (num == 3538210912U)
				{
					if (type == "material")
					{
						Fsm.EventData.MaterialData = (Material)value;
					}
				}
			}
			else if (type == "bool")
			{
				Fsm.EventData.BoolData = (bool)value;
			}
		}
		else if (num != 3940830471U)
		{
			if (num == 4091954829U)
			{
				if (type == "quaternion")
				{
					Fsm.EventData.QuaternionData = (Quaternion)value;
				}
			}
		}
		else if (type == "rect")
		{
			Fsm.EventData.RectData = (Rect)value;
		}
		FsmEventTarget fsmEventTarget = new FsmEventTarget();
		if (this.localOnly)
		{
			PlayMakerUtils.SendEventToTarget(null, FsmEventTarget.Self, anEvent, null);
			return;
		}
		fsmEventTarget.target = FsmEventTarget.EventTarget.BroadcastAll;
		List<Fsm> list = new List<Fsm>(Fsm.FsmList);
		if (list.Count > 0)
		{
			list[0].Event(fsmEventTarget, anEvent);
		}
	}

	// Token: 0x0600007D RID: 125 RVA: 0x0000745C File Offset: 0x0000565C
	public void cleanPrefilledLists()
	{
		if (this.preFillKeyList.Count > this.preFillCount)
		{
			this.preFillKeyList.RemoveRange(this.preFillCount, this.preFillKeyList.Count - this.preFillCount);
		}
		if (this.preFillBoolList.Count > this.preFillCount)
		{
			this.preFillBoolList.RemoveRange(this.preFillCount, this.preFillBoolList.Count - this.preFillCount);
		}
		if (this.preFillColorList.Count > this.preFillCount)
		{
			this.preFillColorList.RemoveRange(this.preFillCount, this.preFillColorList.Count - this.preFillCount);
		}
		if (this.preFillFloatList.Count > this.preFillCount)
		{
			this.preFillFloatList.RemoveRange(this.preFillCount, this.preFillFloatList.Count - this.preFillCount);
		}
		if (this.preFillIntList.Count > this.preFillCount)
		{
			this.preFillIntList.RemoveRange(this.preFillCount, this.preFillIntList.Count - this.preFillCount);
		}
		if (this.preFillMaterialList.Count > this.preFillCount)
		{
			this.preFillMaterialList.RemoveRange(this.preFillCount, this.preFillMaterialList.Count - this.preFillCount);
		}
		if (this.preFillGameObjectList.Count > this.preFillCount)
		{
			this.preFillGameObjectList.RemoveRange(this.preFillCount, this.preFillGameObjectList.Count - this.preFillCount);
		}
		if (this.preFillObjectList.Count > this.preFillCount)
		{
			this.preFillObjectList.RemoveRange(this.preFillCount, this.preFillObjectList.Count - this.preFillCount);
		}
		if (this.preFillQuaternionList.Count > this.preFillCount)
		{
			this.preFillQuaternionList.RemoveRange(this.preFillCount, this.preFillQuaternionList.Count - this.preFillCount);
		}
		if (this.preFillRectList.Count > this.preFillCount)
		{
			this.preFillRectList.RemoveRange(this.preFillCount, this.preFillRectList.Count - this.preFillCount);
		}
		if (this.preFillStringList.Count > this.preFillCount)
		{
			this.preFillStringList.RemoveRange(this.preFillCount, this.preFillStringList.Count - this.preFillCount);
		}
		if (this.preFillTextureList.Count > this.preFillCount)
		{
			this.preFillTextureList.RemoveRange(this.preFillCount, this.preFillTextureList.Count - this.preFillCount);
		}
		if (this.preFillVector2List.Count > this.preFillCount)
		{
			this.preFillVector2List.RemoveRange(this.preFillCount, this.preFillVector2List.Count - this.preFillCount);
		}
		if (this.preFillVector3List.Count > this.preFillCount)
		{
			this.preFillVector3List.RemoveRange(this.preFillCount, this.preFillVector3List.Count - this.preFillCount);
		}
		if (this.preFillAudioClipList.Count > this.preFillCount)
		{
			this.preFillAudioClipList.RemoveRange(this.preFillCount, this.preFillAudioClipList.Count - this.preFillCount);
		}
		if (this.preFillByteList.Count > this.preFillCount)
		{
			this.preFillByteList.RemoveRange(this.preFillCount, this.preFillByteList.Count - this.preFillCount);
		}
		if (this.preFillSpriteList.Count > this.preFillCount)
		{
			this.preFillSpriteList.RemoveRange(this.preFillCount, this.preFillSpriteList.Count - this.preFillCount);
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00007800 File Offset: 0x00005A00
	public static PlayMakerCollectionProxy.VariableEnum GetObjectVariableType(object value)
	{
		if (value is Vector3)
		{
			return PlayMakerCollectionProxy.VariableEnum.Vector3;
		}
		if (value is Rect)
		{
			return PlayMakerCollectionProxy.VariableEnum.Rect;
		}
		if (value is Quaternion)
		{
			return PlayMakerCollectionProxy.VariableEnum.Quaternion;
		}
		if (value is Material)
		{
			return PlayMakerCollectionProxy.VariableEnum.Material;
		}
		if (value is Texture)
		{
			return PlayMakerCollectionProxy.VariableEnum.Texture;
		}
		if (value is Vector2)
		{
			return PlayMakerCollectionProxy.VariableEnum.Vector2;
		}
		if (value is Sprite)
		{
			return PlayMakerCollectionProxy.VariableEnum.Sprite;
		}
		if (value is AudioClip)
		{
			return PlayMakerCollectionProxy.VariableEnum.AudioClip;
		}
		if (value is bool)
		{
			return PlayMakerCollectionProxy.VariableEnum.Bool;
		}
		if (value is byte)
		{
			return PlayMakerCollectionProxy.VariableEnum.Byte;
		}
		if (value is Color)
		{
			return PlayMakerCollectionProxy.VariableEnum.Color;
		}
		if (value is GameObject)
		{
			return PlayMakerCollectionProxy.VariableEnum.GameObject;
		}
		if (value is float)
		{
			return PlayMakerCollectionProxy.VariableEnum.Float;
		}
		if (value is int)
		{
			return PlayMakerCollectionProxy.VariableEnum.Int;
		}
		if (value is string)
		{
			return PlayMakerCollectionProxy.VariableEnum.String;
		}
		return PlayMakerCollectionProxy.VariableEnum.GameObject;
	}

	// Token: 0x040000BC RID: 188
	public bool showEvents;

	// Token: 0x040000BD RID: 189
	public bool showContent;

	// Token: 0x040000BE RID: 190
	public bool TextureElementSmall;

	// Token: 0x040000BF RID: 191
	public bool condensedView;

	// Token: 0x040000C0 RID: 192
	public bool liveUpdate;

	// Token: 0x040000C1 RID: 193
	public string referenceName = "";

	// Token: 0x040000C2 RID: 194
	public bool enablePlayMakerEvents;

	// Token: 0x040000C3 RID: 195
	public string addEvent;

	// Token: 0x040000C4 RID: 196
	public string setEvent;

	// Token: 0x040000C5 RID: 197
	public string removeEvent;

	// Token: 0x040000C6 RID: 198
	public bool localOnly;

	// Token: 0x040000C7 RID: 199
	public int contentPreviewStartIndex;

	// Token: 0x040000C8 RID: 200
	public int contentPreviewMaxRows = 10;

	// Token: 0x040000C9 RID: 201
	public PlayMakerCollectionProxy.VariableEnum preFillType;

	// Token: 0x040000CA RID: 202
	public int preFillObjectTypeIndex;

	// Token: 0x040000CB RID: 203
	public int preFillCount;

	// Token: 0x040000CC RID: 204
	public List<string> preFillKeyList = new List<string>();

	// Token: 0x040000CD RID: 205
	public List<bool> preFillBoolList = new List<bool>();

	// Token: 0x040000CE RID: 206
	public List<Color> preFillColorList = new List<Color>();

	// Token: 0x040000CF RID: 207
	public List<float> preFillFloatList = new List<float>();

	// Token: 0x040000D0 RID: 208
	public List<GameObject> preFillGameObjectList = new List<GameObject>();

	// Token: 0x040000D1 RID: 209
	public List<int> preFillIntList = new List<int>();

	// Token: 0x040000D2 RID: 210
	public List<Material> preFillMaterialList = new List<Material>();

	// Token: 0x040000D3 RID: 211
	public List<Object> preFillObjectList = new List<Object>();

	// Token: 0x040000D4 RID: 212
	public List<Quaternion> preFillQuaternionList = new List<Quaternion>();

	// Token: 0x040000D5 RID: 213
	public List<Rect> preFillRectList = new List<Rect>();

	// Token: 0x040000D6 RID: 214
	public List<string> preFillStringList = new List<string>();

	// Token: 0x040000D7 RID: 215
	public List<Texture2D> preFillTextureList = new List<Texture2D>();

	// Token: 0x040000D8 RID: 216
	public List<Vector2> preFillVector2List = new List<Vector2>();

	// Token: 0x040000D9 RID: 217
	public List<Vector3> preFillVector3List = new List<Vector3>();

	// Token: 0x040000DA RID: 218
	public List<AudioClip> preFillAudioClipList = new List<AudioClip>();

	// Token: 0x040000DB RID: 219
	public List<byte> preFillByteList = new List<byte>();

	// Token: 0x040000DC RID: 220
	public List<Sprite> preFillSpriteList = new List<Sprite>();

	// Token: 0x02000022 RID: 34
	public enum VariableEnum
	{
		// Token: 0x040000DE RID: 222
		GameObject,
		// Token: 0x040000DF RID: 223
		Int,
		// Token: 0x040000E0 RID: 224
		Float,
		// Token: 0x040000E1 RID: 225
		String,
		// Token: 0x040000E2 RID: 226
		Bool,
		// Token: 0x040000E3 RID: 227
		Vector3,
		// Token: 0x040000E4 RID: 228
		Rect,
		// Token: 0x040000E5 RID: 229
		Quaternion,
		// Token: 0x040000E6 RID: 230
		Color,
		// Token: 0x040000E7 RID: 231
		Material,
		// Token: 0x040000E8 RID: 232
		Texture,
		// Token: 0x040000E9 RID: 233
		Vector2,
		// Token: 0x040000EA RID: 234
		AudioClip,
		// Token: 0x040000EB RID: 235
		Byte,
		// Token: 0x040000EC RID: 236
		Sprite
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class PlayMakerHashTableProxy : PlayMakerCollectionProxy
{
	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000080 RID: 128 RVA: 0x0000798D File Offset: 0x00005B8D
	public Hashtable hashTable
	{
		get
		{
			return this._hashTable;
		}
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00007995 File Offset: 0x00005B95
	public void Awake()
	{
		this._hashTable = new Hashtable();
		this.PreFillHashTable();
		this.TakeSnapShot();
	}

	// Token: 0x06000082 RID: 130 RVA: 0x000079AE File Offset: 0x00005BAE
	public bool isCollectionDefined()
	{
		return this.hashTable != null;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x000079BC File Offset: 0x00005BBC
	public void TakeSnapShot()
	{
		this._snapShot = new Hashtable();
		foreach (object key in this._hashTable.Keys)
		{
			this._snapShot[key] = this._hashTable[key];
		}
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00007A34 File Offset: 0x00005C34
	public void RevertToSnapShot()
	{
		this._hashTable = new Hashtable();
		foreach (object key in this._snapShot.Keys)
		{
			this._hashTable[key] = this._snapShot[key];
		}
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00006D75 File Offset: 0x00004F75
	public void InspectorEdit(int index)
	{
		base.dispatchEvent(this.setEvent, index, "int");
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00007AAC File Offset: 0x00005CAC
	[ContextMenu("Copy HashTable Content")]
	private void CopyContentToPrefill()
	{
		this.preFillCount = this.hashTable.Count;
		this.preFillKeyList = this.hashTable.Keys.OfType<string>().ToList<string>();
		switch (this.preFillType)
		{
		case PlayMakerCollectionProxy.VariableEnum.GameObject:
			this.preFillGameObjectList = new List<GameObject>(new GameObject[this.preFillCount]);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Int:
			this.preFillIntList = new List<int>(new int[this.preFillCount]);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Float:
			this.preFillFloatList = new List<float>(new float[this.preFillCount]);
			break;
		case PlayMakerCollectionProxy.VariableEnum.String:
			this.preFillStringList = new List<string>(new string[this.preFillCount]);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Bool:
			this.preFillBoolList = new List<bool>(new bool[this.preFillCount]);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Vector3:
			this.preFillVector3List = new List<Vector3>(new Vector3[this.preFillCount]);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Rect:
			this.preFillRectList = new List<Rect>(this.preFillCount);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Quaternion:
			this.preFillQuaternionList = new List<Quaternion>(this.preFillCount);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Color:
			this.preFillColorList = new List<Color>(new Color[this.preFillCount]);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Material:
			this.preFillMaterialList = new List<Material>(this.preFillCount);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Texture:
			this.preFillTextureList = new List<Texture2D>(this.preFillCount);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Vector2:
			this.preFillVector2List = new List<Vector2>(this.preFillCount);
			break;
		case PlayMakerCollectionProxy.VariableEnum.AudioClip:
			this.preFillAudioClipList = new List<AudioClip>(this.preFillCount);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Byte:
			this.preFillByteList = new List<byte>(this.preFillCount);
			break;
		case PlayMakerCollectionProxy.VariableEnum.Sprite:
			this.preFillSpriteList = new List<Sprite>(this.preFillCount);
			break;
		}
		for (int i = 0; i < this.preFillKeyList.Count; i++)
		{
			switch (this.preFillType)
			{
			case PlayMakerCollectionProxy.VariableEnum.GameObject:
				this.preFillGameObjectList[i] = (this.hashTable[this.preFillKeyList[i]] as GameObject);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Int:
				this.preFillIntList[i] = Convert.ToInt32(this.hashTable[this.preFillKeyList[i]]);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Float:
				this.preFillFloatList[i] = Convert.ToSingle(this.hashTable[this.preFillKeyList[i]]);
				break;
			case PlayMakerCollectionProxy.VariableEnum.String:
				this.preFillStringList[i] = Convert.ToString(this.hashTable[this.preFillKeyList[i]]);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Bool:
				this.preFillBoolList[i] = Convert.ToBoolean(this.hashTable[this.preFillKeyList[i]]);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Vector3:
				this.preFillVector3List[i] = PlayMakerUtils.ConvertToVector3(this.hashTable[this.preFillKeyList[i]], default(Vector3));
				break;
			case PlayMakerCollectionProxy.VariableEnum.Rect:
				this.preFillRectList[i] = PlayMakerUtils.ConvertToRect(this.hashTable[this.preFillKeyList[i]], default(Rect));
				break;
			case PlayMakerCollectionProxy.VariableEnum.Quaternion:
				this.preFillQuaternionList[i] = PlayMakerUtils.ConvertToQuaternion(this.hashTable[this.preFillKeyList[i]], default(Quaternion));
				break;
			case PlayMakerCollectionProxy.VariableEnum.Color:
				this.preFillColorList[i] = PlayMakerUtils.ConvertToColor(this.hashTable[this.preFillKeyList[i]], default(Color));
				break;
			case PlayMakerCollectionProxy.VariableEnum.Material:
				this.preFillMaterialList[i] = (this.hashTable[this.preFillKeyList[i]] as Material);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Texture:
				this.preFillTextureList[i] = (this.hashTable[this.preFillKeyList[i]] as Texture2D);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Vector2:
				this.preFillVector2List[i] = (Vector2)this.hashTable[this.preFillKeyList[i]];
				break;
			case PlayMakerCollectionProxy.VariableEnum.AudioClip:
				this.preFillAudioClipList[i] = (this.hashTable[this.preFillKeyList[i]] as AudioClip);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Byte:
				this.preFillByteList[i] = Convert.ToByte(this.hashTable[this.preFillKeyList[i]]);
				break;
			case PlayMakerCollectionProxy.VariableEnum.Sprite:
				this.preFillSpriteList[i] = (this.hashTable[this.preFillKeyList[i]] as Sprite);
				break;
			}
		}
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00007FB0 File Offset: 0x000061B0
	private void PreFillHashTable()
	{
		for (int i = 0; i < this.preFillKeyList.Count; i++)
		{
			switch (this.preFillType)
			{
			case PlayMakerCollectionProxy.VariableEnum.GameObject:
				this.hashTable[this.preFillKeyList[i]] = this.preFillGameObjectList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Int:
				this.hashTable[this.preFillKeyList[i]] = this.preFillIntList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Float:
				this.hashTable[this.preFillKeyList[i]] = this.preFillFloatList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.String:
				this.hashTable[this.preFillKeyList[i]] = this.preFillStringList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Bool:
				this.hashTable[this.preFillKeyList[i]] = this.preFillBoolList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Vector3:
				this.hashTable[this.preFillKeyList[i]] = this.preFillVector3List[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Rect:
				this.hashTable[this.preFillKeyList[i]] = this.preFillRectList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Quaternion:
				this.hashTable[this.preFillKeyList[i]] = this.preFillQuaternionList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Color:
				this.hashTable[this.preFillKeyList[i]] = this.preFillColorList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Material:
				this.hashTable[this.preFillKeyList[i]] = this.preFillMaterialList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Texture:
				this.hashTable[this.preFillKeyList[i]] = this.preFillTextureList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Vector2:
				this.hashTable[this.preFillKeyList[i]] = this.preFillVector2List[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.AudioClip:
				this.hashTable[this.preFillKeyList[i]] = this.preFillAudioClipList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Byte:
				this.hashTable[this.preFillKeyList[i]] = this.preFillByteList[i];
				break;
			case PlayMakerCollectionProxy.VariableEnum.Sprite:
				this.hashTable[this.preFillKeyList[i]] = this.preFillSpriteList[i];
				break;
			}
		}
	}

	// Token: 0x040000ED RID: 237
	public Hashtable _hashTable;

	// Token: 0x040000EE RID: 238
	private Hashtable _snapShot;
}

using System;
using System.Text.RegularExpressions;
using HutongGames.PlayMaker;
using UnityEngine;

// Token: 0x02000037 RID: 55
public class PlayMakerUtils
{
	// Token: 0x060000CF RID: 207 RVA: 0x00009075 File Offset: 0x00007275
	public static Quaternion ConvertToQuaternion(object value, Quaternion defaultValue = default(Quaternion))
	{
		if (value is Quaternion)
		{
			return (Quaternion)value;
		}
		return defaultValue;
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00009087 File Offset: 0x00007287
	public static Rect ConvertToRect(object value, Rect defaultValue = default(Rect))
	{
		if (value is Rect)
		{
			return (Rect)value;
		}
		return defaultValue;
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00009099 File Offset: 0x00007299
	public static Color ConvertToColor(object value, Color defaultValue = default(Color))
	{
		if (value is Color)
		{
			return (Color)value;
		}
		return defaultValue;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x000090AB File Offset: 0x000072AB
	public static Vector3 ConvertToVector3(object value, Vector3 defaultValue = default(Vector3))
	{
		if (value is Vector3)
		{
			return (Vector3)value;
		}
		return defaultValue;
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x000090BD File Offset: 0x000072BD
	public static Vector2 ConvertToVector2(object value, Vector2 defaultValue = default(Vector2))
	{
		if (value is Vector2)
		{
			return (Vector2)value;
		}
		return defaultValue;
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x000090CF File Offset: 0x000072CF
	public static Vector4 ConvertToVector2(object value, Vector4 defaultValue = default(Vector4))
	{
		if (value is Vector4)
		{
			return (Vector4)value;
		}
		return defaultValue;
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000090E4 File Offset: 0x000072E4
	public static PlayMakerFSM GetFsmEventSender()
	{
		if (PlayMakerUtils.FsmEventSender == null)
		{
			PlayMakerUtils.FsmEventSender = new GameObject("PlayMaker Send Event Proxy").AddComponent<PlayMakerFSM>();
			PlayMakerUtils.FsmEventSender.FsmName = "Send Event Proxy";
			PlayMakerUtils.FsmEventSender.FsmDescription = "This Fsm was created at runtime, because a script or component is willing to send a PlayMaker event";
		}
		return PlayMakerUtils.FsmEventSender;
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00009135 File Offset: 0x00007335
	public static void SendEventToTarget(PlayMakerFSM fromFsm, FsmEventTarget target, string fsmEvent, FsmEventData eventData)
	{
		if (fromFsm == null)
		{
			fromFsm = PlayMakerUtils.GetFsmEventSender();
		}
		if (eventData != null)
		{
			Fsm.EventData = eventData;
		}
		if (fromFsm == null)
		{
			return;
		}
		fromFsm.Fsm.Event(target, fsmEvent);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00009167 File Offset: 0x00007367
	public static void SendEventToGameObject(PlayMakerFSM fromFsm, GameObject target, string fsmEvent, bool includeChildren)
	{
		PlayMakerUtils.SendEventToGameObject(fromFsm, target, fsmEvent, includeChildren, null);
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00009173 File Offset: 0x00007373
	public static void SendEventToGameObject(PlayMakerFSM fromFsm, GameObject target, string fsmEvent)
	{
		PlayMakerUtils.SendEventToGameObject(fromFsm, target, fsmEvent, false, null);
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000917F File Offset: 0x0000737F
	public static void SendEventToGameObject(PlayMakerFSM fromFsm, GameObject target, string fsmEvent, FsmEventData eventData)
	{
		PlayMakerUtils.SendEventToGameObject(fromFsm, target, fsmEvent, false, eventData);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0000918C File Offset: 0x0000738C
	public static void SendEventToGameObject(PlayMakerFSM fromFsm, GameObject target, string fsmEvent, bool includeChildren, FsmEventData eventData)
	{
		if (fromFsm == null)
		{
			fromFsm = PlayMakerUtils.GetFsmEventSender();
		}
		if (eventData != null)
		{
			Fsm.EventData = eventData;
		}
		if (fromFsm == null)
		{
			return;
		}
		FsmEventTarget fsmEventTarget = new FsmEventTarget();
		fsmEventTarget.excludeSelf = false;
		fsmEventTarget.sendToChildren = includeChildren;
		fsmEventTarget.target = FsmEventTarget.EventTarget.GameObject;
		fsmEventTarget.gameObject = new FsmOwnerDefault
		{
			OwnerOption = OwnerDefaultOption.SpecifyGameObject,
			GameObject = new FsmGameObject(),
			GameObject = 
			{
				Value = target
			}
		};
		fromFsm.Fsm.Event(fsmEventTarget, fsmEvent);
	}

	// Token: 0x060000DB RID: 219 RVA: 0x0000921C File Offset: 0x0000741C
	public static void SendEventToGameObjectFsmByName(PlayMakerFSM fromFsm, GameObject target, string fsmName, string fsmEvent, FsmEventData eventData)
	{
		PlayMakerUtils.SendEventToTarget(fromFsm, new FsmEventTarget
		{
			target = FsmEventTarget.EventTarget.GameObjectFSM,
			gameObject = new FsmOwnerDefault(),
			gameObject = 
			{
				OwnerOption = OwnerDefaultOption.SpecifyGameObject,
				GameObject = target
			},
			fsmName = fsmName
		}, fsmEvent, eventData);
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00009274 File Offset: 0x00007474
	public static bool DoesTargetImplementsEvent(FsmEventTarget target, string eventName)
	{
		if (target.target == FsmEventTarget.EventTarget.BroadcastAll)
		{
			return FsmEvent.IsEventGlobal(eventName);
		}
		if (target.target == FsmEventTarget.EventTarget.FSMComponent)
		{
			return PlayMakerUtils.DoesFsmImplementsEvent(target.fsmComponent, eventName);
		}
		if (target.target == FsmEventTarget.EventTarget.GameObject)
		{
			return PlayMakerUtils.DoesGameObjectImplementsEvent(target.gameObject.GameObject.Value, eventName, false);
		}
		if (target.target == FsmEventTarget.EventTarget.GameObjectFSM)
		{
			return PlayMakerUtils.DoesGameObjectImplementsEvent(target.gameObject.GameObject.Value, target.fsmName.Value, eventName);
		}
		if (target.target == FsmEventTarget.EventTarget.Self)
		{
			Debug.LogError("Self target not supported yet");
		}
		if (target.target == FsmEventTarget.EventTarget.SubFSMs)
		{
			Debug.LogError("subFsms target not supported yet");
		}
		if (target.target == FsmEventTarget.EventTarget.HostFSM)
		{
			Debug.LogError("HostFSM target not supported yet");
		}
		return false;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x0000932C File Offset: 0x0000752C
	public static bool DoesGameObjectImplementsEvent(GameObject go, string fsmEvent, bool includeChildren = false)
	{
		if (go == null || string.IsNullOrEmpty(fsmEvent))
		{
			return false;
		}
		if (includeChildren)
		{
			PlayMakerFSM[] array = go.GetComponentsInChildren<PlayMakerFSM>();
			for (int i = 0; i < array.Length; i++)
			{
				if (PlayMakerUtils.DoesFsmImplementsEvent(array[i], fsmEvent))
				{
					return true;
				}
			}
		}
		else
		{
			PlayMakerFSM[] array = go.GetComponents<PlayMakerFSM>();
			for (int i = 0; i < array.Length; i++)
			{
				if (PlayMakerUtils.DoesFsmImplementsEvent(array[i], fsmEvent))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00009398 File Offset: 0x00007598
	public static bool DoesGameObjectImplementsEvent(GameObject go, string fsmName, string fsmEvent)
	{
		if (go == null || string.IsNullOrEmpty(fsmEvent))
		{
			return false;
		}
		bool flag = !string.IsNullOrEmpty(fsmName);
		foreach (PlayMakerFSM playMakerFSM in go.GetComponents<PlayMakerFSM>())
		{
			if (flag && object.Equals(playMakerFSM, fsmName) && PlayMakerUtils.DoesFsmImplementsEvent(playMakerFSM, fsmEvent))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060000DF RID: 223 RVA: 0x000093F4 File Offset: 0x000075F4
	public static bool DoesFsmImplementsEvent(PlayMakerFSM fsm, string fsmEvent)
	{
		if (fsm == null || string.IsNullOrEmpty(fsmEvent))
		{
			return false;
		}
		FsmTransition[] array = fsm.FsmGlobalTransitions;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].EventName.Equals(fsmEvent))
			{
				return true;
			}
		}
		FsmState[] fsmStates = fsm.FsmStates;
		for (int i = 0; i < fsmStates.Length; i++)
		{
			array = fsmStates[i].Transitions;
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j].EventName.Equals(fsmEvent))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x0000947C File Offset: 0x0000767C
	public static bool CreateIfNeededGlobalEvent(string globalEventName)
	{
		bool result = false;
		if (FsmEvent.GetFsmEvent(globalEventName) == null)
		{
			Debug.Log("Adding event to FsmEvent:" + globalEventName);
			FsmEvent.AddFsmEvent(new FsmEvent(globalEventName)
			{
				IsGlobal = true
			});
		}
		if (!FsmEvent.IsEventGlobal(globalEventName))
		{
			if (!FsmEvent.globalEvents.Contains(globalEventName))
			{
				Debug.Log("adding global event to  FsmEvent.globalEvents:" + globalEventName);
				FsmEvent.globalEvents.Add(globalEventName);
			}
			else
			{
				Debug.Log("event already defined in FsmEvent.globalEvents:" + globalEventName);
			}
			result = true;
		}
		else
		{
			Debug.Log("event already global:" + globalEventName);
		}
		return result;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00009510 File Offset: 0x00007710
	public static Fsm GetFsmOnGameObject(GameObject go, string fsmName)
	{
		if (go == null || string.IsNullOrEmpty(fsmName))
		{
			return null;
		}
		foreach (PlayMakerFSM playMakerFSM in go.GetComponents<PlayMakerFSM>())
		{
			if (string.Equals(playMakerFSM.FsmName, fsmName))
			{
				return playMakerFSM.Fsm;
			}
		}
		return null;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00009560 File Offset: 0x00007760
	public static PlayMakerFSM FindFsmOnGameObject(GameObject go, string fsmName)
	{
		if (go == null || string.IsNullOrEmpty(fsmName))
		{
			return null;
		}
		foreach (PlayMakerFSM playMakerFSM in go.GetComponents<PlayMakerFSM>())
		{
			if (string.Equals(playMakerFSM.FsmName, fsmName))
			{
				return playMakerFSM;
			}
		}
		return null;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x000095AC File Offset: 0x000077AC
	public static string LogFullPathToAction(FsmStateAction action)
	{
		return string.Concat(new string[]
		{
			PlayMakerUtils.GetGameObjectPath(action.Fsm.GameObject),
			":Fsm(",
			action.Fsm.Name,
			"):State(",
			action.State.Name,
			"):Action(",
			action.GetType().Name,
			")"
		});
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00009624 File Offset: 0x00007824
	public static string GetGameObjectPath(GameObject obj)
	{
		string text = "/" + obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			text = "/" + obj.name + text;
		}
		return text;
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x0000967C File Offset: 0x0000787C
	public static void RefreshValueFromFsmVar(Fsm fromFsm, FsmVar fsmVar)
	{
		if (fromFsm == null)
		{
			return;
		}
		if (fsmVar == null)
		{
			return;
		}
		if (!fsmVar.useVariable)
		{
			return;
		}
		switch (fsmVar.Type)
		{
		case VariableType.Float:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmFloat(fsmVar.variableName));
			return;
		case VariableType.Int:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmInt(fsmVar.variableName));
			return;
		case VariableType.Bool:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmBool(fsmVar.variableName));
			return;
		case VariableType.GameObject:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmGameObject(fsmVar.variableName));
			return;
		case VariableType.String:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmString(fsmVar.variableName));
			return;
		case VariableType.Vector2:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmVector2(fsmVar.variableName));
			return;
		case VariableType.Vector3:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmVector3(fsmVar.variableName));
			return;
		case VariableType.Color:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmColor(fsmVar.variableName));
			return;
		case VariableType.Rect:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmRect(fsmVar.variableName));
			return;
		case VariableType.Material:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmMaterial(fsmVar.variableName));
			return;
		case VariableType.Texture:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmVector3(fsmVar.variableName));
			return;
		case VariableType.Quaternion:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmQuaternion(fsmVar.variableName));
			return;
		case VariableType.Object:
			break;
		case VariableType.Array:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmArray(fsmVar.variableName));
			break;
		case VariableType.Enum:
			fsmVar.GetValueFrom(fromFsm.Variables.GetFsmEnum(fsmVar.variableName));
			return;
		default:
			return;
		}
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00009834 File Offset: 0x00007A34
	public static object GetValueFromFsmVar(Fsm fromFsm, FsmVar fsmVar)
	{
		if (fromFsm == null)
		{
			return null;
		}
		if (fsmVar == null)
		{
			return null;
		}
		if (fsmVar.useVariable)
		{
			string variableName = fsmVar.variableName;
			switch (fsmVar.Type)
			{
			case VariableType.Float:
				return fromFsm.Variables.GetFsmFloat(variableName).Value;
			case VariableType.Int:
				return fromFsm.Variables.GetFsmInt(variableName).Value;
			case VariableType.Bool:
				return fromFsm.Variables.GetFsmBool(variableName).Value;
			case VariableType.GameObject:
				return fromFsm.Variables.GetFsmGameObject(variableName).Value;
			case VariableType.String:
				return fromFsm.Variables.GetFsmString(variableName).Value;
			case VariableType.Vector2:
				return fromFsm.Variables.GetFsmVector2(variableName).Value;
			case VariableType.Vector3:
				return fromFsm.Variables.GetFsmVector3(variableName).Value;
			case VariableType.Color:
				return fromFsm.Variables.GetFsmColor(variableName).Value;
			case VariableType.Rect:
				return fromFsm.Variables.GetFsmRect(variableName).Value;
			case VariableType.Material:
				return fromFsm.Variables.GetFsmMaterial(variableName).Value;
			case VariableType.Texture:
				return fromFsm.Variables.GetFsmTexture(variableName).Value;
			case VariableType.Quaternion:
				return fromFsm.Variables.GetFsmQuaternion(variableName).Value;
			case VariableType.Object:
				return fromFsm.Variables.GetFsmObject(variableName).Value;
			case VariableType.Array:
				return fromFsm.Variables.GetFsmArray(variableName).Values;
			case VariableType.Enum:
				return fromFsm.Variables.GetFsmEnum(variableName).Value;
			}
		}
		else
		{
			switch (fsmVar.Type)
			{
			case VariableType.Float:
				return fsmVar.floatValue;
			case VariableType.Int:
				return fsmVar.intValue;
			case VariableType.Bool:
				return fsmVar.boolValue;
			case VariableType.GameObject:
				return fsmVar.gameObjectValue;
			case VariableType.String:
				return fsmVar.stringValue;
			case VariableType.Vector2:
				return fsmVar.vector2Value;
			case VariableType.Vector3:
				return fsmVar.vector3Value;
			case VariableType.Color:
				return fsmVar.colorValue;
			case VariableType.Rect:
				return fsmVar.rectValue;
			case VariableType.Material:
				return fsmVar.materialValue;
			case VariableType.Texture:
				return fsmVar.textureValue;
			case VariableType.Quaternion:
				return fsmVar.quaternionValue;
			case VariableType.Object:
				return fsmVar.objectReference;
			case VariableType.Array:
				return fsmVar.arrayValue;
			case VariableType.Enum:
				return fsmVar.EnumValue;
			}
		}
		return null;
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00009AC4 File Offset: 0x00007CC4
	public static bool ApplyValueToFsmVar(Fsm fromFsm, FsmVar fsmVar, object[] value)
	{
		if (fromFsm == null)
		{
			return false;
		}
		if (fsmVar == null)
		{
			return false;
		}
		if (value == null || value.Length == 0)
		{
			if (fsmVar.Type == VariableType.Array)
			{
				fromFsm.Variables.GetFsmArray(fsmVar.variableName).Reset();
			}
			return true;
		}
		if (fsmVar.Type != VariableType.Array)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"The fsmVar value <",
				fsmVar.Type.ToString(),
				"> doesn't match the value <FsmArray> on state",
				fromFsm.ActiveStateName,
				" on fsm:",
				fromFsm.Name,
				" on GameObject:",
				fromFsm.GameObjectName
			}));
			return false;
		}
		fromFsm.Variables.GetFsmArray(fsmVar.variableName).Values = value;
		return true;
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00009B8C File Offset: 0x00007D8C
	public static bool ApplyValueToFsmVar(Fsm fromFsm, FsmVar fsmVar, object value)
	{
		if (fromFsm == null)
		{
			return false;
		}
		if (fsmVar == null)
		{
			return false;
		}
		if (value == null)
		{
			if (fsmVar.Type == VariableType.Bool)
			{
				fromFsm.Variables.GetFsmBool(fsmVar.variableName).Value = false;
			}
			else if (fsmVar.Type == VariableType.Color)
			{
				fromFsm.Variables.GetFsmColor(fsmVar.variableName).Value = Color.black;
			}
			else if (fsmVar.Type == VariableType.Int)
			{
				fromFsm.Variables.GetFsmInt(fsmVar.variableName).Value = 0;
			}
			else if (fsmVar.Type == VariableType.Float)
			{
				fromFsm.Variables.GetFsmFloat(fsmVar.variableName).Value = 0f;
			}
			else if (fsmVar.Type == VariableType.GameObject)
			{
				fromFsm.Variables.GetFsmGameObject(fsmVar.variableName).Value = null;
			}
			else if (fsmVar.Type == VariableType.Material)
			{
				fromFsm.Variables.GetFsmMaterial(fsmVar.variableName).Value = null;
			}
			else if (fsmVar.Type == VariableType.Object)
			{
				fromFsm.Variables.GetFsmObject(fsmVar.variableName).Value = null;
			}
			else if (fsmVar.Type == VariableType.Quaternion)
			{
				fromFsm.Variables.GetFsmQuaternion(fsmVar.variableName).Value = Quaternion.identity;
			}
			else if (fsmVar.Type == VariableType.Rect)
			{
				fromFsm.Variables.GetFsmRect(fsmVar.variableName).Value = new Rect(0f, 0f, 0f, 0f);
			}
			else if (fsmVar.Type == VariableType.String)
			{
				fromFsm.Variables.GetFsmString(fsmVar.variableName).Value = "";
			}
			else if (fsmVar.Type == VariableType.String)
			{
				fromFsm.Variables.GetFsmTexture(fsmVar.variableName).Value = null;
			}
			else if (fsmVar.Type == VariableType.Vector2)
			{
				fromFsm.Variables.GetFsmVector2(fsmVar.variableName).Value = Vector2.zero;
			}
			else if (fsmVar.Type == VariableType.Vector3)
			{
				fromFsm.Variables.GetFsmVector3(fsmVar.variableName).Value = Vector3.zero;
			}
			else if (fsmVar.Type == VariableType.Enum)
			{
				fromFsm.Variables.GetFsmEnum(fsmVar.variableName).ResetValue();
			}
			else if (fsmVar.Type == VariableType.Array)
			{
				fromFsm.Variables.GetFsmArray(fsmVar.variableName).Reset();
			}
			return true;
		}
		Type type = value.GetType();
		Type type2 = null;
		switch (fsmVar.Type)
		{
		case VariableType.Float:
			type2 = typeof(float);
			break;
		case VariableType.Int:
			type2 = typeof(int);
			break;
		case VariableType.Bool:
			type2 = typeof(bool);
			break;
		case VariableType.GameObject:
			type2 = typeof(GameObject);
			break;
		case VariableType.String:
			type2 = typeof(string);
			break;
		case VariableType.Vector2:
			type2 = typeof(Vector2);
			break;
		case VariableType.Vector3:
			type2 = typeof(Vector3);
			break;
		case VariableType.Color:
			type2 = typeof(Color);
			break;
		case VariableType.Rect:
			type2 = typeof(Rect);
			break;
		case VariableType.Material:
			type2 = typeof(Material);
			break;
		case VariableType.Texture:
			type2 = typeof(Texture2D);
			break;
		case VariableType.Quaternion:
			type2 = typeof(Quaternion);
			break;
		case VariableType.Object:
			type2 = typeof(Object);
			break;
		case VariableType.Array:
			type2 = typeof(Array);
			break;
		case VariableType.Enum:
			type2 = typeof(Enum);
			break;
		}
		bool flag = true;
		if (!type2.Equals(type))
		{
			flag = false;
			if (type2.Equals(typeof(Object)))
			{
				flag = true;
			}
			if (type2.Equals(typeof(Enum)))
			{
				flag = true;
			}
			if (!flag)
			{
				if (type.Equals(typeof(double)))
				{
					flag = true;
				}
				if (type.Equals(typeof(long)))
				{
					flag = true;
				}
				if (type.Equals(typeof(byte)))
				{
					flag = true;
				}
			}
		}
		if (!flag)
		{
			string[] array = new string[10];
			array[0] = "The fsmVar value <";
			int num = 1;
			Type type3 = type2;
			array[num] = ((type3 != null) ? type3.ToString() : null);
			array[2] = "> doesn't match the value <";
			int num2 = 3;
			Type type4 = type;
			array[num2] = ((type4 != null) ? type4.ToString() : null);
			array[4] = "> on state";
			array[5] = fromFsm.ActiveStateName;
			array[6] = " on fsm:";
			array[7] = fromFsm.Name;
			array[8] = " on GameObject:";
			array[9] = fromFsm.GameObjectName;
			Debug.LogError(string.Concat(array));
			return false;
		}
		if (type == typeof(bool))
		{
			fromFsm.Variables.GetFsmBool(fsmVar.variableName).Value = (bool)value;
		}
		else if (type == typeof(Color))
		{
			fromFsm.Variables.GetFsmColor(fsmVar.variableName).Value = (Color)value;
		}
		else if (type == typeof(int))
		{
			fromFsm.Variables.GetFsmInt(fsmVar.variableName).Value = Convert.ToInt32(value);
		}
		else if (type == typeof(byte))
		{
			fromFsm.Variables.GetFsmInt(fsmVar.variableName).Value = Convert.ToInt32(value);
		}
		else if (type == typeof(long))
		{
			if (fsmVar.Type == VariableType.Int)
			{
				fromFsm.Variables.GetFsmInt(fsmVar.variableName).Value = Convert.ToInt32(value);
			}
			else if (fsmVar.Type == VariableType.Float)
			{
				fromFsm.Variables.GetFsmFloat(fsmVar.variableName).Value = Convert.ToSingle(value);
			}
		}
		else if (type == typeof(float))
		{
			fromFsm.Variables.GetFsmFloat(fsmVar.variableName).Value = (float)value;
		}
		else if (type == typeof(double))
		{
			fromFsm.Variables.GetFsmFloat(fsmVar.variableName).Value = Convert.ToSingle(value);
		}
		else if (type == typeof(GameObject))
		{
			fromFsm.Variables.GetFsmGameObject(fsmVar.variableName).Value = (GameObject)value;
		}
		else if (type == typeof(Material))
		{
			fromFsm.Variables.GetFsmMaterial(fsmVar.variableName).Value = (Material)value;
		}
		else if (type == typeof(Object) || type2 == typeof(Object))
		{
			fromFsm.Variables.GetFsmObject(fsmVar.variableName).Value = (Object)value;
		}
		else if (type == typeof(Quaternion))
		{
			fromFsm.Variables.GetFsmQuaternion(fsmVar.variableName).Value = (Quaternion)value;
		}
		else if (type == typeof(Rect))
		{
			fromFsm.Variables.GetFsmRect(fsmVar.variableName).Value = (Rect)value;
		}
		else if (type == typeof(string))
		{
			fromFsm.Variables.GetFsmString(fsmVar.variableName).Value = (string)value;
		}
		else if (type == typeof(Texture2D))
		{
			fromFsm.Variables.GetFsmTexture(fsmVar.variableName).Value = (Texture2D)value;
		}
		else if (type == typeof(Vector2))
		{
			fromFsm.Variables.GetFsmVector2(fsmVar.variableName).Value = (Vector2)value;
		}
		else if (type == typeof(Vector3))
		{
			fromFsm.Variables.GetFsmVector3(fsmVar.variableName).Value = (Vector3)value;
		}
		else if (value is Enum)
		{
			fromFsm.Variables.GetFsmEnum(fsmVar.variableName).Value = (Enum)value;
		}
		else
		{
			string str = "?!?!";
			Type type5 = type;
			Debug.LogWarning(str + ((type5 != null) ? type5.ToString() : null));
		}
		return true;
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x0000A3C4 File Offset: 0x000085C4
	public static float GetFloatFromObject(object _obj, VariableType targetType, bool fastProcessingIfPossible)
	{
		if (targetType == VariableType.Int || targetType == VariableType.Float)
		{
			return Convert.ToSingle(_obj);
		}
		if (targetType == VariableType.Vector2)
		{
			Vector2 lhs = (Vector2)_obj;
			if (lhs != Vector2.zero)
			{
				if (!fastProcessingIfPossible)
				{
					return lhs.magnitude;
				}
				return lhs.sqrMagnitude;
			}
		}
		if (targetType == VariableType.Vector3)
		{
			Vector3 lhs2 = (Vector3)_obj;
			if (lhs2 != Vector3.zero)
			{
				if (!fastProcessingIfPossible)
				{
					return lhs2.magnitude;
				}
				return lhs2.sqrMagnitude;
			}
		}
		if (targetType == VariableType.GameObject)
		{
			GameObject gameObject = (GameObject)_obj;
			if (gameObject != null)
			{
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				if (component != null)
				{
					return component.bounds.size.x * component.bounds.size.y * component.bounds.size.z;
				}
			}
		}
		if (targetType == VariableType.Rect)
		{
			Rect rect = (Rect)_obj;
			return rect.width * rect.height;
		}
		if (targetType == VariableType.String)
		{
			string text = (string)_obj;
			if (text != null)
			{
				return float.Parse(text);
			}
		}
		return 0f;
	}

	// Token: 0x060000EA RID: 234 RVA: 0x0000A4D4 File Offset: 0x000086D4
	public static string ParseFsmVarToString(Fsm fsm, FsmVar fsmVar)
	{
		if (fsmVar == null)
		{
			return "";
		}
		object valueFromFsmVar = PlayMakerUtils.GetValueFromFsmVar(fsm, fsmVar);
		if (valueFromFsmVar == null)
		{
			return "";
		}
		if (fsmVar.Type == VariableType.String)
		{
			return (string)valueFromFsmVar;
		}
		if (fsmVar.Type == VariableType.Bool)
		{
			if (!(bool)valueFromFsmVar)
			{
				return "0";
			}
			return "1";
		}
		else
		{
			if (fsmVar.Type == VariableType.Float)
			{
				return float.Parse(valueFromFsmVar.ToString()).ToString();
			}
			if (fsmVar.Type == VariableType.Int)
			{
				return int.Parse(valueFromFsmVar.ToString()).ToString();
			}
			if (fsmVar.Type == VariableType.Vector2)
			{
				Vector2 vector = (Vector2)valueFromFsmVar;
				return vector.x.ToString() + "," + vector.y.ToString();
			}
			if (fsmVar.Type == VariableType.Vector3)
			{
				Vector3 vector2 = (Vector3)valueFromFsmVar;
				return string.Concat(new string[]
				{
					vector2.x.ToString(),
					",",
					vector2.y.ToString(),
					",",
					vector2.z.ToString()
				});
			}
			if (fsmVar.Type == VariableType.Quaternion)
			{
				Quaternion quaternion = (Quaternion)valueFromFsmVar;
				return string.Concat(new string[]
				{
					quaternion.x.ToString(),
					",",
					quaternion.y.ToString(),
					",",
					quaternion.z.ToString(),
					",",
					quaternion.w.ToString()
				});
			}
			if (fsmVar.Type == VariableType.Rect)
			{
				Rect rect = (Rect)valueFromFsmVar;
				return string.Concat(new string[]
				{
					rect.x.ToString(),
					",",
					rect.y.ToString(),
					",",
					rect.width.ToString(),
					",",
					rect.height.ToString()
				});
			}
			if (fsmVar.Type == VariableType.Color)
			{
				Color color = (Color)valueFromFsmVar;
				return string.Concat(new string[]
				{
					color.r.ToString(),
					",",
					color.g.ToString(),
					",",
					color.b.ToString(),
					",",
					color.a.ToString()
				});
			}
			if (fsmVar.Type == VariableType.GameObject)
			{
				return ((GameObject)valueFromFsmVar).name;
			}
			if (fsmVar.Type == VariableType.Material)
			{
				return ((Material)valueFromFsmVar).name;
			}
			if (fsmVar.Type == VariableType.Texture)
			{
				return ((Texture2D)valueFromFsmVar).name;
			}
			string str = "ParseValueToString type not supported ";
			Type type = valueFromFsmVar.GetType();
			Debug.LogWarning(str + ((type != null) ? type.ToString() : null));
			return "<" + fsmVar.Type.ToString() + "> not supported";
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x0000A7D8 File Offset: 0x000089D8
	public static string ParseValueToString(object item, bool useBytes)
	{
		return "";
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000A7E0 File Offset: 0x000089E0
	public static string ParseValueToString(object item)
	{
		if (item == null)
		{
			return "";
		}
		if (item.GetType() == typeof(string))
		{
			return "string(" + item.ToString() + ")";
		}
		if (item.GetType() == typeof(bool))
		{
			return "bool(" + (((bool)item) ? 1 : 0).ToString() + ")";
		}
		if (item.GetType() == typeof(float))
		{
			return "float(" + float.Parse(item.ToString()).ToString() + ")";
		}
		if (item.GetType() == typeof(int))
		{
			return "int(" + int.Parse(item.ToString()).ToString() + ")";
		}
		if (item.GetType() == typeof(Vector2))
		{
			Vector2 vector = (Vector2)item;
			return string.Concat(new string[]
			{
				"vector2(",
				vector.x.ToString(),
				",",
				vector.y.ToString(),
				")"
			});
		}
		if (item.GetType() == typeof(Vector3))
		{
			Vector3 vector2 = (Vector3)item;
			return string.Concat(new string[]
			{
				"vector3(",
				vector2.x.ToString(),
				",",
				vector2.y.ToString(),
				",",
				vector2.z.ToString(),
				")"
			});
		}
		if (item.GetType() == typeof(Vector4))
		{
			Vector4 vector3 = (Vector4)item;
			return string.Concat(new string[]
			{
				"vector4(",
				vector3.x.ToString(),
				",",
				vector3.y.ToString(),
				",",
				vector3.z.ToString(),
				",",
				vector3.w.ToString(),
				")"
			});
		}
		if (item.GetType() == typeof(Quaternion))
		{
			Quaternion quaternion = (Quaternion)item;
			return string.Concat(new string[]
			{
				"quaternion(",
				quaternion.x.ToString(),
				",",
				quaternion.y.ToString(),
				",",
				quaternion.z.ToString(),
				",",
				quaternion.w.ToString(),
				")"
			});
		}
		if (item.GetType() == typeof(Rect))
		{
			Rect rect = (Rect)item;
			return string.Concat(new string[]
			{
				"rect(",
				rect.x.ToString(),
				",",
				rect.y.ToString(),
				",",
				rect.width.ToString(),
				",",
				rect.height.ToString(),
				")"
			});
		}
		if (item.GetType() == typeof(Color))
		{
			Color color = (Color)item;
			return string.Concat(new string[]
			{
				"color(",
				color.r.ToString(),
				",",
				color.g.ToString(),
				",",
				color.b.ToString(),
				",",
				color.a.ToString(),
				")"
			});
		}
		if (item.GetType() == typeof(Texture2D))
		{
			byte[] inArray = ((Texture2D)item).EncodeToPNG();
			return "texture(" + Convert.ToBase64String(inArray) + ")";
		}
		if (item.GetType() == typeof(GameObject))
		{
			GameObject gameObject = (GameObject)item;
			return "gameObject(" + gameObject.name + ")";
		}
		string str = "ParseValueToString type not supported ";
		Type type = item.GetType();
		Debug.LogWarning(str + ((type != null) ? type.ToString() : null));
		string str2 = "<";
		Type type2 = item.GetType();
		return str2 + ((type2 != null) ? type2.ToString() : null) + "> not supported";
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000ACB0 File Offset: 0x00008EB0
	public static object ParseValueFromString(string source, bool useBytes)
	{
		return null;
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000ACB4 File Offset: 0x00008EB4
	public static object ParseValueFromString(string source, VariableType type)
	{
		Type typeFromHandle = typeof(string);
		switch (type)
		{
		case VariableType.Unknown:
			return PlayMakerUtils.ParseValueFromString(source);
		case VariableType.Float:
			typeFromHandle = typeof(float);
			break;
		case VariableType.Int:
			typeFromHandle = typeof(int);
			break;
		case VariableType.Bool:
			typeFromHandle = typeof(bool);
			break;
		case VariableType.GameObject:
			typeFromHandle = typeof(GameObject);
			break;
		case VariableType.Vector2:
			typeFromHandle = typeof(Vector2);
			break;
		case VariableType.Vector3:
			typeFromHandle = typeof(Vector3);
			break;
		case VariableType.Color:
			typeFromHandle = typeof(Color);
			break;
		case VariableType.Rect:
			typeFromHandle = typeof(Rect);
			break;
		case VariableType.Quaternion:
			typeFromHandle = typeof(Quaternion);
			break;
		}
		return PlayMakerUtils.ParseValueFromString(source, typeFromHandle);
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0000AD90 File Offset: 0x00008F90
	public static object ParseValueFromString(string source, Type type)
	{
		if (source == null)
		{
			return null;
		}
		if (type == typeof(string))
		{
			return source;
		}
		if (type == typeof(bool))
		{
			if (string.Equals(source, "true", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			if (string.Equals(source, "false", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			return int.Parse(source) != 0;
		}
		else
		{
			if (type == typeof(int))
			{
				return int.Parse(source);
			}
			if (type == typeof(float))
			{
				return float.Parse(source);
			}
			if (type == typeof(Vector2))
			{
				string text = "vector2\\([x],[y]\\)";
				string str = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
				text = text.Replace("[x]", "(?<x>" + str + ")");
				text = text.Replace("[y]", "(?<y>" + str + ")");
				text = "^\\s*" + text;
				Match match = new Regex(text).Match(source);
				if (match.Groups["x"].Value != "" && match.Groups["y"].Value != "")
				{
					return new Vector2(float.Parse(match.Groups["x"].Value), float.Parse(match.Groups["y"].Value));
				}
				return Vector2.zero;
			}
			else if (type == typeof(Vector3))
			{
				string text2 = "vector3\\([x],[y],[z]\\)";
				string str2 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
				text2 = text2.Replace("[x]", "(?<x>" + str2 + ")");
				text2 = text2.Replace("[y]", "(?<y>" + str2 + ")");
				text2 = text2.Replace("[z]", "(?<z>" + str2 + ")");
				text2 = "^\\s*" + text2;
				Match match2 = new Regex(text2).Match(source);
				if (match2.Groups["x"].Value != "" && match2.Groups["y"].Value != "" && match2.Groups["z"].Value != "")
				{
					return new Vector3(float.Parse(match2.Groups["x"].Value), float.Parse(match2.Groups["y"].Value), float.Parse(match2.Groups["z"].Value));
				}
				return Vector3.zero;
			}
			else if (type == typeof(Vector4))
			{
				string text3 = "vector4\\([x],[y],[z],[w]\\)";
				string str3 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
				text3 = text3.Replace("[x]", "(?<x>" + str3 + ")");
				text3 = text3.Replace("[y]", "(?<y>" + str3 + ")");
				text3 = text3.Replace("[z]", "(?<z>" + str3 + ")");
				text3 = text3.Replace("[w]", "(?<w>" + str3 + ")");
				text3 = "^\\s*" + text3;
				Match match3 = new Regex(text3).Match(source);
				if (match3.Groups["x"].Value != "" && match3.Groups["y"].Value != "" && match3.Groups["z"].Value != "" && match3.Groups["z"].Value != "")
				{
					return new Vector4(float.Parse(match3.Groups["x"].Value), float.Parse(match3.Groups["y"].Value), float.Parse(match3.Groups["z"].Value), float.Parse(match3.Groups["w"].Value));
				}
				return Vector4.zero;
			}
			else if (type == typeof(Rect))
			{
				string text4 = "rect\\([x],[y],[w],[h]\\)";
				string str4 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
				text4 = text4.Replace("[x]", "(?<x>" + str4 + ")");
				text4 = text4.Replace("[y]", "(?<y>" + str4 + ")");
				text4 = text4.Replace("[w]", "(?<w>" + str4 + ")");
				text4 = text4.Replace("[h]", "(?<h>" + str4 + ")");
				text4 = "^\\s*" + text4;
				Match match4 = new Regex(text4).Match(source);
				if (match4.Groups["x"].Value != "" && match4.Groups["y"].Value != "" && match4.Groups["w"].Value != "" && match4.Groups["h"].Value != "")
				{
					return new Rect(float.Parse(match4.Groups["x"].Value), float.Parse(match4.Groups["y"].Value), float.Parse(match4.Groups["w"].Value), float.Parse(match4.Groups["h"].Value));
				}
				return new Rect(0f, 0f, 0f, 0f);
			}
			else if (type == typeof(Quaternion))
			{
				string text5 = "quaternion\\([x],[y],[z],[w]\\)";
				string str5 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
				text5 = text5.Replace("[x]", "(?<x>" + str5 + ")");
				text5 = text5.Replace("[y]", "(?<y>" + str5 + ")");
				text5 = text5.Replace("[z]", "(?<z>" + str5 + ")");
				text5 = text5.Replace("[w]", "(?<w>" + str5 + ")");
				text5 = "^\\s*" + text5;
				Match match5 = new Regex(text5).Match(source);
				if (match5.Groups["x"].Value != "" && match5.Groups["y"].Value != "" && match5.Groups["z"].Value != "" && match5.Groups["z"].Value != "")
				{
					return new Quaternion(float.Parse(match5.Groups["x"].Value), float.Parse(match5.Groups["y"].Value), float.Parse(match5.Groups["z"].Value), float.Parse(match5.Groups["w"].Value));
				}
				return Quaternion.identity;
			}
			else if (type == typeof(Color))
			{
				string text6 = "color\\([r],[g],[b],[a]\\)";
				string str6 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
				text6 = text6.Replace("[r]", "(?<r>" + str6 + ")");
				text6 = text6.Replace("[g]", "(?<g>" + str6 + ")");
				text6 = text6.Replace("[b]", "(?<b>" + str6 + ")");
				text6 = text6.Replace("[a]", "(?<a>" + str6 + ")");
				text6 = "^\\s*" + text6;
				Match match6 = new Regex(text6).Match(source);
				if (match6.Groups["r"].Value != "" && match6.Groups["g"].Value != "" && match6.Groups["b"].Value != "" && match6.Groups["a"].Value != "")
				{
					return new Color(float.Parse(match6.Groups["r"].Value), float.Parse(match6.Groups["g"].Value), float.Parse(match6.Groups["b"].Value), float.Parse(match6.Groups["a"].Value));
				}
				return Color.black;
			}
			else
			{
				if (type == typeof(GameObject))
				{
					source = source.Substring(11, source.Length - 12);
					return GameObject.Find(source);
				}
				Debug.LogWarning("ParseValueFromString failed for " + source);
				return null;
			}
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0000B830 File Offset: 0x00009A30
	public static object ParseValueFromString(string source)
	{
		if (source == null)
		{
			return null;
		}
		if (source.StartsWith("string("))
		{
			source = source.Substring(7, source.Length - 8);
			return source;
		}
		if (source.StartsWith("bool("))
		{
			source = source.Substring(5, source.Length - 6);
			return int.Parse(source) == 1;
		}
		if (source.StartsWith("int("))
		{
			source = source.Substring(4, source.Length - 5);
			return int.Parse(source);
		}
		if (source.StartsWith("float("))
		{
			source = source.Substring(6, source.Length - 7);
			return float.Parse(source);
		}
		if (source.StartsWith("vector2("))
		{
			string text = "vector2\\([x],[y]\\)";
			string str = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
			text = text.Replace("[x]", "(?<x>" + str + ")");
			text = text.Replace("[y]", "(?<y>" + str + ")");
			text = "^\\s*" + text;
			Match match = new Regex(text).Match(source);
			if (match.Groups["x"].Value != "" && match.Groups["y"].Value != "")
			{
				return new Vector2(float.Parse(match.Groups["x"].Value), float.Parse(match.Groups["y"].Value));
			}
			return Vector2.zero;
		}
		else if (source.StartsWith("vector3("))
		{
			string text2 = "vector3\\([x],[y],[z]\\)";
			string str2 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
			text2 = text2.Replace("[x]", "(?<x>" + str2 + ")");
			text2 = text2.Replace("[y]", "(?<y>" + str2 + ")");
			text2 = text2.Replace("[z]", "(?<z>" + str2 + ")");
			text2 = "^\\s*" + text2;
			Match match2 = new Regex(text2).Match(source);
			if (match2.Groups["x"].Value != "" && match2.Groups["y"].Value != "" && match2.Groups["z"].Value != "")
			{
				return new Vector3(float.Parse(match2.Groups["x"].Value), float.Parse(match2.Groups["y"].Value), float.Parse(match2.Groups["z"].Value));
			}
			return Vector3.zero;
		}
		else if (source.StartsWith("vector4("))
		{
			string text3 = "vector4\\([x],[y],[z],[w]\\)";
			string str3 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
			text3 = text3.Replace("[x]", "(?<x>" + str3 + ")");
			text3 = text3.Replace("[y]", "(?<y>" + str3 + ")");
			text3 = text3.Replace("[z]", "(?<z>" + str3 + ")");
			text3 = text3.Replace("[w]", "(?<w>" + str3 + ")");
			text3 = "^\\s*" + text3;
			Match match3 = new Regex(text3).Match(source);
			if (match3.Groups["x"].Value != "" && match3.Groups["y"].Value != "" && match3.Groups["z"].Value != "" && match3.Groups["z"].Value != "")
			{
				return new Vector4(float.Parse(match3.Groups["x"].Value), float.Parse(match3.Groups["y"].Value), float.Parse(match3.Groups["z"].Value), float.Parse(match3.Groups["w"].Value));
			}
			return Vector4.zero;
		}
		else if (source.StartsWith("rect("))
		{
			string text4 = "rect\\([x],[y],[w],[h]\\)";
			string str4 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
			text4 = text4.Replace("[x]", "(?<x>" + str4 + ")");
			text4 = text4.Replace("[y]", "(?<y>" + str4 + ")");
			text4 = text4.Replace("[w]", "(?<w>" + str4 + ")");
			text4 = text4.Replace("[h]", "(?<h>" + str4 + ")");
			text4 = "^\\s*" + text4;
			Match match4 = new Regex(text4).Match(source);
			if (match4.Groups["x"].Value != "" && match4.Groups["y"].Value != "" && match4.Groups["w"].Value != "" && match4.Groups["h"].Value != "")
			{
				return new Rect(float.Parse(match4.Groups["x"].Value), float.Parse(match4.Groups["y"].Value), float.Parse(match4.Groups["w"].Value), float.Parse(match4.Groups["h"].Value));
			}
			return new Rect(0f, 0f, 0f, 0f);
		}
		else if (source.StartsWith("quaternion("))
		{
			string text5 = "quaternion\\([x],[y],[z],[w]\\)";
			string str5 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
			text5 = text5.Replace("[x]", "(?<x>" + str5 + ")");
			text5 = text5.Replace("[y]", "(?<y>" + str5 + ")");
			text5 = text5.Replace("[z]", "(?<z>" + str5 + ")");
			text5 = text5.Replace("[w]", "(?<w>" + str5 + ")");
			text5 = "^\\s*" + text5;
			Match match5 = new Regex(text5).Match(source);
			if (match5.Groups["x"].Value != "" && match5.Groups["y"].Value != "" && match5.Groups["z"].Value != "" && match5.Groups["z"].Value != "")
			{
				return new Quaternion(float.Parse(match5.Groups["x"].Value), float.Parse(match5.Groups["y"].Value), float.Parse(match5.Groups["z"].Value), float.Parse(match5.Groups["w"].Value));
			}
			return Quaternion.identity;
		}
		else if (source.StartsWith("color("))
		{
			string text6 = "color\\([r],[g],[b],[a]\\)";
			string str6 = "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?";
			text6 = text6.Replace("[r]", "(?<r>" + str6 + ")");
			text6 = text6.Replace("[g]", "(?<g>" + str6 + ")");
			text6 = text6.Replace("[b]", "(?<b>" + str6 + ")");
			text6 = text6.Replace("[a]", "(?<a>" + str6 + ")");
			text6 = "^\\s*" + text6;
			Match match6 = new Regex(text6).Match(source);
			if (match6.Groups["r"].Value != "" && match6.Groups["g"].Value != "" && match6.Groups["b"].Value != "" && match6.Groups["a"].Value != "")
			{
				return new Color(float.Parse(match6.Groups["r"].Value), float.Parse(match6.Groups["g"].Value), float.Parse(match6.Groups["b"].Value), float.Parse(match6.Groups["a"].Value));
			}
			return Color.black;
		}
		else
		{
			if (source.StartsWith("texture("))
			{
				source = source.Substring(8, source.Length - 9);
				byte[] data = Convert.FromBase64String(source);
				Texture2D texture2D = new Texture2D(16, 16);
				texture2D.LoadImage(data);
				return texture2D;
			}
			if (source.StartsWith("gameObject("))
			{
				source = source.Substring(11, source.Length - 12);
				return GameObject.Find(source);
			}
			Debug.LogWarning("ParseValueFromString failed for " + source);
			return null;
		}
	}

	// Token: 0x0400011D RID: 285
	public static PlayMakerFSM FsmEventSender;
}

using System;
using HutongGames.PlayMaker;

// Token: 0x02000036 RID: 54
public static class PlayMakerUtilsDotNetExtensions
{
	// Token: 0x060000CE RID: 206 RVA: 0x0000904C File Offset: 0x0000724C
	public static bool Contains(this VariableType[] target, VariableType vType)
	{
		if (target == null)
		{
			return false;
		}
		for (int i = 0; i < target.Length; i++)
		{
			if (target[i] == vType)
			{
				return true;
			}
		}
		return false;
	}
}

using System;
using System.Collections;
using HutongGames.PlayMaker;
using UnityEngine;

// Token: 0x02000034 RID: 52
public static class PlayMakerUtils_Extensions
{
	// Token: 0x060000C4 RID: 196 RVA: 0x00008DE8 File Offset: 0x00006FE8
	public static int IndexOf(ArrayList target, object value)
	{
		return PlayMakerUtils_Extensions.IndexOf(target, value, 0, target.Count);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00008DF8 File Offset: 0x00006FF8
	public static int IndexOf(ArrayList target, object value, int startIndex)
	{
		if (startIndex > target.Count)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_Index");
		}
		return PlayMakerUtils_Extensions.IndexOf(target, value, startIndex, target.Count - startIndex);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00008E24 File Offset: 0x00007024
	public static int IndexOf(ArrayList target, object value, int startIndex, int count)
	{
		if (startIndex < 0 || startIndex >= target.Count)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_Index");
		}
		if (count < 0 || startIndex > target.Count - count)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_Count");
		}
		if (target.Count == 0)
		{
			return -1;
		}
		int num = startIndex + count;
		if (value == null)
		{
			for (int i = startIndex; i < num; i++)
			{
				if (target[i] == null)
				{
					return i;
				}
			}
			return -1;
		}
		for (int j = startIndex; j < num; j++)
		{
			if (target[j] != null && target[j].Equals(value))
			{
				return j;
			}
		}
		return -1;
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00008EBE File Offset: 0x000070BE
	public static int LastIndexOf(ArrayList target, object value)
	{
		return PlayMakerUtils_Extensions.LastIndexOf(target, value, target.Count - 1, target.Count);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00008ED5 File Offset: 0x000070D5
	public static int LastIndexOf(ArrayList target, object value, int startIndex)
	{
		return PlayMakerUtils_Extensions.LastIndexOf(target, value, startIndex, startIndex + 1);
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00008EE4 File Offset: 0x000070E4
	public static int LastIndexOf(ArrayList target, object value, int startIndex, int count)
	{
		if (target.Count == 0)
		{
			return -1;
		}
		if (startIndex < 0 || startIndex >= target.Count)
		{
			throw new ArgumentOutOfRangeException("startIndex", "ArgumentOutOfRange_Index");
		}
		if (count < 0 || startIndex > target.Count - count)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_Count");
		}
		int num = startIndex + count - 1;
		if (value == null)
		{
			for (int i = num; i >= startIndex; i--)
			{
				if (target[i] == null)
				{
					return i;
				}
			}
			return -1;
		}
		for (int j = num; j >= startIndex; j--)
		{
			if (target[j] != null && target[j].Equals(value))
			{
				return j;
			}
		}
		return -1;
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00008F82 File Offset: 0x00007182
	public static string GetPath(this Transform current)
	{
		if (current.parent == null)
		{
			return "/" + current.name;
		}
		return current.parent.GetPath() + "/" + current.name;
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00008FBE File Offset: 0x000071BE
	public static string GetPath(this Component component)
	{
		return component.transform.GetPath();
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00008FCC File Offset: 0x000071CC
	public static string GetActionPath(this FsmStateAction action)
	{
		return string.Concat(new string[]
		{
			action.Fsm.GameObject.transform.GetPath(),
			"/",
			action.Fsm.Name,
			":",
			action.State.Name,
			":",
			action.Name
		});
	}
}

using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class PopulationSystemManager : MonoBehaviour
{
	// Token: 0x06000033 RID: 51 RVA: 0x00004B04 File Offset: 0x00002D04
	public void Concert(Vector3 pos)
	{
		this.isConcert = false;
		GameObject gameObject = new GameObject();
		gameObject.transform.position = pos;
		gameObject.name = "Audience";
		gameObject.AddComponent<StandingPeopleConcert>();
		StandingPeopleConcert component = gameObject.GetComponent<StandingPeopleConcert>();
		component.planePrefab = this.planePrefab;
		component.circlePrefab = this.circlePrefab;
		component.SpawnRectangleSurface();
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00004B60 File Offset: 0x00002D60
	public void Street(Vector3 pos)
	{
		this.isStreet = false;
		GameObject gameObject = new GameObject();
		gameObject.transform.position = pos;
		gameObject.name = "Talking people";
		gameObject.AddComponent<StandingPeopleStreet>();
		StandingPeopleStreet component = gameObject.GetComponent<StandingPeopleStreet>();
		component.planePrefab = this.planePrefab;
		component.circlePrefab = this.circlePrefab;
		component.SpawnRectangleSurface();
	}

	// Token: 0x04000074 RID: 116
	[SerializeField]
	private GameObject planePrefab;

	// Token: 0x04000075 RID: 117
	[SerializeField]
	private GameObject circlePrefab;

	// Token: 0x04000076 RID: 118
	public GameObject pointPrefab;

	// Token: 0x04000077 RID: 119
	[HideInInspector]
	public bool isConcert;

	// Token: 0x04000078 RID: 120
	[HideInInspector]
	public bool isStreet;

	// Token: 0x04000079 RID: 121
	[HideInInspector]
	public Vector3 mousePos;
}

using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AB RID: 171
public class PricingMachine : MonoBehaviour
{
	// Token: 0x060005D3 RID: 1491 RVA: 0x00027BBA File Offset: 0x00025DBA
	private void Start()
	{
		this.MainPlayer = ReInput.players.GetPlayer(0);
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x00027BD0 File Offset: 0x00025DD0
	private void OnEnable()
	{
		this.currentProductID = -1;
		this.pricingImage.sprite = null;
		this.pricingMarketPrice.text = "$0,00";
		this.pricingYourPrice.text = "$0,00";
		this.pricingCurrentPrice.text = "$0,00";
		this.pricingProductName.text = "";
		this.pricingBrandName.text = "";
		this.basefloatString = "";
		if (!this.pListing)
		{
			this.pListing = ProductListing.Instance;
		}
		this.GenerateUIPrefabs();
		this.canvasOBJ.SetActive(true);
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x00027C75 File Offset: 0x00025E75
	private void OnDisable()
	{
		if (this.generating)
		{
			base.StopAllCoroutines();
			this.generating = false;
		}
		this.canvasOBJ.SetActive(false);
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x00027C98 File Offset: 0x00025E98
	private void Update()
	{
		if (this.generating || this.currentProductID == -1)
		{
			return;
		}
		this.NumpadSetPricing();
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x00027CB4 File Offset: 0x00025EB4
	private void GenerateUIPrefabs()
	{
		if (this.UIproductsContainer.transform.childCount > 0)
		{
			int childCount = this.UIproductsContainer.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Object.Destroy(this.UIproductsContainer.transform.GetChild(childCount - 1 - i).gameObject);
			}
		}
		if (!this.generating)
		{
			base.StartCoroutine(this.Generation());
		}
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x00027D25 File Offset: 0x00025F25
	private IEnumerator Generation()
	{
		this.generating = true;
		List<int> availableProducts = this.pListing.availableProducts;
		int counter = 0;
		foreach (int num in availableProducts)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.UIPricingPrefabOBJ, this.UIproductsContainer.transform);
			gameObject.transform.Find("ProductName").GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString("product" + num.ToString());
			gameObject.transform.Find("BrandName").GetComponent<TextMeshProUGUI>().text = this.pListing.productPrefabs[num].GetComponent<Data_Product>().productBrand;
			gameObject.transform.Find("ProductBCK/ProductImage").GetComponent<Image>().sprite = this.pListing.productSprites[num];
			float num2 = this.pListing.tierInflation[this.pListing.productPrefabs[num].GetComponent<Data_Product>().productTier];
			float price = this.pListing.productPrefabs[num].GetComponent<Data_Product>().basePricePerUnit * num2;
			gameObject.transform.Find("MarketPriceBCK/MarketPrice").GetComponent<TextMeshProUGUI>().text = this.pListing.ConvertFloatToTextPrice(price);
			float price2 = this.pListing.productPlayerPricing[num];
			gameObject.transform.Find("YourPriceBCK/YourPrice").GetComponent<TextMeshProUGUI>().text = this.pListing.ConvertFloatToTextPrice(price2);
			gameObject.transform.Find("SelectionButton").GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("ProductID").Value = num;
			int productTier = this.pListing.productPrefabs[num].GetComponent<Data_Product>().productTier;
			int num3 = this.pListing.productGroups[productTier];
			gameObject.GetComponent<Image>().color = this.pListing.groupsColors[num3];
			if (counter >= 20)
			{
				counter = 0;
				yield return null;
			}
			int num4 = counter;
			counter = num4 + 1;
		}
		List<int>.Enumerator enumerator = default(List<int>.Enumerator);
		yield return null;
		this.generating = false;
		yield break;
		yield break;
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x00027D34 File Offset: 0x00025F34
	public void ShowPriceInfo(int productID, GameObject buttonOBJ)
	{
		this.currentProductID = productID;
		this.currentTMPToUpdate = buttonOBJ.transform.Find("YourPriceBCK/YourPrice").GetComponent<TextMeshProUGUI>();
		this.pricingImage.sprite = this.pListing.productSprites[productID];
		float num = this.pListing.tierInflation[this.pListing.productPrefabs[productID].GetComponent<Data_Product>().productTier];
		float price = this.pListing.productPrefabs[productID].GetComponent<Data_Product>().basePricePerUnit * num;
		this.pricingMarketPrice.text = this.pListing.ConvertFloatToTextPrice(price);
		float price2 = this.pListing.productPlayerPricing[productID];
		this.pricingYourPrice.text = this.pListing.ConvertFloatToTextPrice(price2);
		this.pricingCurrentPrice.text = "$0,00";
		this.pricingProductName.text = LocalizationManager.instance.GetLocalizationString("product" + productID.ToString());
		this.pricingBrandName.text = this.pListing.productPrefabs[productID].GetComponent<Data_Product>().productBrand;
		this.basefloatString = "";
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00027E58 File Offset: 0x00026058
	private void NumpadSetPricing()
	{
		if (this.MainPlayer.GetButtonDown("Numpad Delete"))
		{
			this.NumberDelete();
			return;
		}
		for (int i = 0; i < this.keyCodes.Length; i++)
		{
			if (this.MainPlayer.GetButtonDown(this.keyCodes[i]))
			{
				this.NumberPricing(i);
				return;
			}
		}
		if (this.MainPlayer.GetButtonDown("Numpad Period"))
		{
			this.NumberPeriod();
			return;
		}
		if (this.MainPlayer.GetButtonDown("Numpad Accept"))
		{
			this.NumberAccept();
		}
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x00027EE0 File Offset: 0x000260E0
	public void NumberPricing(int intNumber)
	{
		if (this.basefloatString.Length >= 7)
		{
			return;
		}
		if (this.basefloatString.Contains(","))
		{
			string[] array = this.basefloatString.Split(",", StringSplitOptions.None);
			if (array.Length > 1 && array[1].Length >= 2)
			{
				return;
			}
		}
		this.basefloatString += intNumber.ToString();
		this.pricingCurrentPrice.text = "$" + this.basefloatString;
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x00027F68 File Offset: 0x00026168
	public void NumberDelete()
	{
		if (this.basefloatString.Length == 0)
		{
			return;
		}
		this.basefloatString = this.basefloatString.Substring(0, this.basefloatString.Length - 1);
		this.pricingCurrentPrice.text = "$" + this.basefloatString;
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x00027FC0 File Offset: 0x000261C0
	public void NumberPeriod()
	{
		if (this.basefloatString.Length >= 7)
		{
			return;
		}
		if (this.basefloatString.Length == 0 || this.basefloatString.Contains(","))
		{
			return;
		}
		this.basefloatString += ",";
		this.pricingCurrentPrice.text = "$" + this.basefloatString;
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x00028030 File Offset: 0x00026230
	public void NumberAccept()
	{
		if (this.currentProductID == -1)
		{
			return;
		}
		if (this.basefloatString.Length == 0 || this.basefloatString.Substring(this.basefloatString.Length - 1, 1) == ",")
		{
			return;
		}
		float num;
		if (float.TryParse(this.basefloatString, out num))
		{
			num = Mathf.Round(num * 100f) / 100f;
			if (this.pListing.productPlayerPricing[this.currentProductID] != num)
			{
				this.currentTMPToUpdate.text = this.pListing.ConvertFloatToTextPrice(num);
				this.pricingYourPrice.text = this.pListing.ConvertFloatToTextPrice(num);
				FirstPersonController.Instance.GetComponent<PlayerNetwork>().CmdPlayPricingSound();
				this.pListing.CmdUpdateProductPrice(this.currentProductID, num);
			}
			return;
		}
	}

	// Token: 0x040004C5 RID: 1221
	public GameObject canvasOBJ;

	// Token: 0x040004C6 RID: 1222
	public GameObject UIproductsContainer;

	// Token: 0x040004C7 RID: 1223
	public GameObject UIPricingPrefabOBJ;

	// Token: 0x040004C8 RID: 1224
	[Space(10f)]
	public Image pricingImage;

	// Token: 0x040004C9 RID: 1225
	public TextMeshProUGUI pricingMarketPrice;

	// Token: 0x040004CA RID: 1226
	public TextMeshProUGUI pricingYourPrice;

	// Token: 0x040004CB RID: 1227
	public TextMeshProUGUI pricingCurrentPrice;

	// Token: 0x040004CC RID: 1228
	public TextMeshProUGUI pricingProductName;

	// Token: 0x040004CD RID: 1229
	public TextMeshProUGUI pricingBrandName;

	// Token: 0x040004CE RID: 1230
	private TextMeshProUGUI currentTMPToUpdate;

	// Token: 0x040004CF RID: 1231
	private int currentProductID;

	// Token: 0x040004D0 RID: 1232
	private string basefloatString;

	// Token: 0x040004D1 RID: 1233
	private ProductListing pListing;

	// Token: 0x040004D2 RID: 1234
	private bool generating;

	// Token: 0x040004D3 RID: 1235
	private Player MainPlayer;

	// Token: 0x040004D4 RID: 1236
	private string[] keyCodes = new string[]
	{
		"Numpad 0",
		"Numpad 1",
		"Numpad 2",
		"Numpad 3",
		"Numpad 4",
		"Numpad 5",
		"Numpad 6",
		"Numpad 7",
		"Numpad 8",
		"Numpad 9"
	};
}

using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class ProductAnimation : MonoBehaviour
{
	// Token: 0x060005E7 RID: 1511 RVA: 0x000284BA File Offset: 0x000266BA
	public void ExecuteAnimation(int ProductID, Vector3 destination)
	{
		base.StartCoroutine(this.CreateProductObject(ProductID));
		base.StartCoroutine(this.MoveProductToDestination(destination));
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x000284D8 File Offset: 0x000266D8
	private IEnumerator CreateProductObject(int productID)
	{
		yield return new WaitUntil(() => ProductListing.Instance);
		Object.Instantiate<GameObject>(ProductListing.Instance.productPrefabs[productID], base.transform).transform.localPosition = Vector3.zero;
		yield break;
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x000284EE File Offset: 0x000266EE
	private IEnumerator MoveProductToDestination(Vector3 destination)
	{
		float timePassed = 0f;
		float duration = 0.5f;
		Vector3 currentPosition = base.transform.position;
		while (timePassed < duration)
		{
			timePassed += Time.deltaTime;
			float num = timePassed / duration;
			float num2 = this.scaleCurve.Evaluate(num);
			float y = this.parabolaCurve.Evaluate(num) * 0.5f;
			base.transform.position = Vector3.Lerp(currentPosition, destination, num) + new Vector3(0f, y, 0f);
			base.transform.localScale = new Vector3(num2, num2, num2);
			yield return null;
		}
		Object.Destroy(base.gameObject);
		yield return null;
		yield break;
	}

	// Token: 0x040004DA RID: 1242
	public AnimationCurve parabolaCurve;

	// Token: 0x040004DB RID: 1243
	public AnimationCurve scaleCurve;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using HighlightPlus;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class ProductCheckoutSpawn : NetworkBehaviour
{
	// Token: 0x060005FA RID: 1530 RVA: 0x00028710 File Offset: 0x00026910
	public override void OnStartClient()
	{
		base.StartCoroutine(this.CreateProductObject());
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x0002871F File Offset: 0x0002691F
	private IEnumerator CreateProductObject()
	{
		yield return new WaitUntil(() => ProductListing.Instance);
		GameObject gameObject = Object.Instantiate<GameObject>(ProductListing.Instance.productPrefabs[this.productID], base.transform);
		gameObject.transform.localPosition = Vector3.zero;
		BoxCollider component = base.GetComponent<BoxCollider>();
		component.center = gameObject.GetComponent<BoxCollider>().center;
		component.size = gameObject.GetComponent<BoxCollider>().size;
		base.GetComponent<HighlightEffect>().enabled = true;
		this.isFinished = true;
		yield return null;
		yield break;
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x00028730 File Offset: 0x00026930
	[Command(requiresAuthority = false)]
	public void CmdAddProductValueToCheckout()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void ProductCheckoutSpawn::CmdAddProductValueToCheckout()", 908204039, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x00028760 File Offset: 0x00026960
	public void AddProductFromNPCEmployee()
	{
		AchievementsManager.Instance.CmdAddAchievementPoint(4, 1);
		this.NetworkcheckoutOBJ.GetComponent<Data_Container>().internalProductListForEmployees[this.internalDataContainerListIndex] = null;
		this.NetworkcheckoutOBJ.GetComponent<Data_Container>().AddItemToCheckout(this.productCarryingPrice, this.NetworkNPCOBJ);
		this.CheckoutProductAnimation();
		NetworkServer.Destroy(base.gameObject);
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x000287C4 File Offset: 0x000269C4
	public void CheckoutProductAnimation()
	{
		if (this.NetworkcheckoutOBJ && this.NetworkcheckoutOBJ.transform.Find("Bags"))
		{
			Transform transform = this.NetworkcheckoutOBJ.transform.Find("Bags");
			int index = 0;
			int num = 0;
			while (num < transform.childCount && transform.transform.GetChild(num).gameObject.activeSelf)
			{
				index = num;
				num++;
			}
			Vector3 destination = transform.transform.GetChild(index).transform.position + new Vector3(0f, 0.3f, 0f);
			GameData.Instance.GetComponent<NetworkSpawner>().RpcProductAnimation(this.productID, base.transform.position, destination);
		}
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x00028894 File Offset: 0x00026A94
	public void EndDayDestroy()
	{
		NetworkServer.Destroy(base.gameObject);
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x06000602 RID: 1538 RVA: 0x000288A4 File Offset: 0x00026AA4
	// (set) Token: 0x06000603 RID: 1539 RVA: 0x000288B7 File Offset: 0x00026AB7
	public int NetworkproductID
	{
		get
		{
			return this.productID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.productID, 1UL, null);
		}
	}

	// Token: 0x170000A4 RID: 164
	// (get) Token: 0x06000604 RID: 1540 RVA: 0x000288D4 File Offset: 0x00026AD4
	// (set) Token: 0x06000605 RID: 1541 RVA: 0x000288F3 File Offset: 0x00026AF3
	public GameObject NetworkcheckoutOBJ
	{
		get
		{
			return base.GetSyncVarGameObject(this.___checkoutOBJNetId, ref this.checkoutOBJ);
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter_GameObject(value, ref this.checkoutOBJ, 2UL, null, ref this.___checkoutOBJNetId);
		}
	}

	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x06000606 RID: 1542 RVA: 0x00028914 File Offset: 0x00026B14
	// (set) Token: 0x06000607 RID: 1543 RVA: 0x00028933 File Offset: 0x00026B33
	public GameObject NetworkNPCOBJ
	{
		get
		{
			return base.GetSyncVarGameObject(this.___NPCOBJNetId, ref this.NPCOBJ);
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter_GameObject(value, ref this.NPCOBJ, 4UL, null, ref this.___NPCOBJNetId);
		}
	}

	// Token: 0x170000A6 RID: 166
	// (get) Token: 0x06000608 RID: 1544 RVA: 0x00028954 File Offset: 0x00026B54
	// (set) Token: 0x06000609 RID: 1545 RVA: 0x00028967 File Offset: 0x00026B67
	public float NetworkproductCarryingPrice
	{
		get
		{
			return this.productCarryingPrice;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<float>(value, ref this.productCarryingPrice, 8UL, null);
		}
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x00028984 File Offset: 0x00026B84
	protected void UserCode_CmdAddProductValueToCheckout()
	{
		AchievementsManager.Instance.CmdAddAchievementPoint(4, 1);
		this.NetworkcheckoutOBJ.GetComponent<Data_Container>().internalProductListForEmployees[this.internalDataContainerListIndex] = null;
		this.NetworkcheckoutOBJ.GetComponent<Data_Container>().AddItemToCheckout(this.productCarryingPrice, this.NetworkNPCOBJ);
		this.CheckoutProductAnimation();
		NetworkServer.Destroy(base.gameObject);
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x000289E6 File Offset: 0x00026BE6
	protected static void InvokeUserCode_CmdAddProductValueToCheckout(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddProductValueToCheckout called on client.");
			return;
		}
		((ProductCheckoutSpawn)obj).UserCode_CmdAddProductValueToCheckout();
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x00028A09 File Offset: 0x00026C09
	static ProductCheckoutSpawn()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ProductCheckoutSpawn), "System.Void ProductCheckoutSpawn::CmdAddProductValueToCheckout()", new RemoteCallDelegate(ProductCheckoutSpawn.InvokeUserCode_CmdAddProductValueToCheckout), false);
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x00028A2C File Offset: 0x00026C2C
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.productID);
			writer.WriteGameObject(this.NetworkcheckoutOBJ);
			writer.WriteGameObject(this.NetworkNPCOBJ);
			writer.WriteFloat(this.productCarryingPrice);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.productID);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteGameObject(this.NetworkcheckoutOBJ);
		}
		if ((this.syncVarDirtyBits & 4UL) != 0UL)
		{
			writer.WriteGameObject(this.NetworkNPCOBJ);
		}
		if ((this.syncVarDirtyBits & 8UL) != 0UL)
		{
			writer.WriteFloat(this.productCarryingPrice);
		}
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x00028B10 File Offset: 0x00026D10
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.productID, null, reader.ReadInt());
			base.GeneratedSyncVarDeserialize_GameObject(ref this.checkoutOBJ, null, reader, ref this.___checkoutOBJNetId);
			base.GeneratedSyncVarDeserialize_GameObject(ref this.NPCOBJ, null, reader, ref this.___NPCOBJNetId);
			base.GeneratedSyncVarDeserialize<float>(ref this.productCarryingPrice, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.productID, null, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize_GameObject(ref this.checkoutOBJ, null, reader, ref this.___checkoutOBJNetId);
		}
		if ((num & 4L) != 0L)
		{
			base.GeneratedSyncVarDeserialize_GameObject(ref this.NPCOBJ, null, reader, ref this.___NPCOBJNetId);
		}
		if ((num & 8L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<float>(ref this.productCarryingPrice, null, reader.ReadFloat());
		}
	}

	// Token: 0x040004E9 RID: 1257
	[SyncVar]
	public int productID;

	// Token: 0x040004EA RID: 1258
	[SyncVar]
	public GameObject checkoutOBJ;

	// Token: 0x040004EB RID: 1259
	[SyncVar]
	public GameObject NPCOBJ;

	// Token: 0x040004EC RID: 1260
	[SyncVar]
	public float productCarryingPrice;

	// Token: 0x040004ED RID: 1261
	public int internalDataContainerListIndex;

	// Token: 0x040004EE RID: 1262
	public bool isFinished;

	// Token: 0x040004EF RID: 1263
	protected uint ___checkoutOBJNetId;

	// Token: 0x040004F0 RID: 1264
	protected uint ___NPCOBJNetId;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class ProductListing : NetworkBehaviour
{
	// Token: 0x06000618 RID: 1560 RVA: 0x00028D27 File Offset: 0x00026F27
	private void Awake()
	{
		if (ProductListing.Instance == null)
		{
			ProductListing.Instance = this;
		}
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x00028D3C File Offset: 0x00026F3C
	public override void OnStartClient()
	{
		this.updateSkillState();
		this.updateProductList();
		base.StartCoroutine(this.DelayUpdateShelveActivation());
		base.GetComponent<ManagerBlackboard>().UpdateUnlockedFranchises();
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x00028D64 File Offset: 0x00026F64
	[Command(requiresAuthority = false)]
	public void CmdUpdateProductPrice(int productID, float newPrice)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(productID);
		writer.WriteFloat(newPrice);
		base.SendCommandInternal("System.Void ProductListing::CmdUpdateProductPrice(System.Int32,System.Single)", -2105090285, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x00028DA8 File Offset: 0x00026FA8
	[ClientRpc]
	private void RpcUpdateProductPricer(int productID, float newPrice)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(productID);
		writer.WriteFloat(newPrice);
		this.SendRPCInternal("System.Void ProductListing::RpcUpdateProductPricer(System.Int32,System.Single)", -25779752, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x00028DEC File Offset: 0x00026FEC
	[Command(requiresAuthority = false)]
	public void CmdUnlockProductTier(int tierIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(tierIndex);
		base.SendCommandInternal("System.Void ProductListing::CmdUnlockProductTier(System.Int32)", -1210391744, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x00028E28 File Offset: 0x00027028
	[ClientRpc]
	private void RpcUnlockProductTier(int tierIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(tierIndex);
		this.SendRPCInternal("System.Void ProductListing::RpcUnlockProductTier(System.Int32)", -142498995, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x00028E64 File Offset: 0x00027064
	public void updateSkillState()
	{
		for (int i = 0; i < this.unlockedProductTiers.Length; i++)
		{
			GameObject gameObject = this.skillTreeOBJ.transform.GetChild(i).gameObject;
			if (this.unlockedProductTiers[i])
			{
				gameObject.GetComponent<CanvasGroup>().alpha = 1f;
				gameObject.tag = "Untagged";
				gameObject.transform.Find("Highlight2").gameObject.SetActive(true);
			}
			else
			{
				int[] previousSkillRequirements = gameObject.GetComponent<InteractableData>().previousSkillRequirements;
				bool flag = true;
				if (previousSkillRequirements.Length != 0)
				{
					foreach (int num in previousSkillRequirements)
					{
						if (!this.unlockedProductTiers[num])
						{
							flag = false;
						}
					}
					if (flag)
					{
						gameObject.transform.Find("Highlight2").gameObject.SetActive(true);
					}
				}
			}
		}
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x00028F40 File Offset: 0x00027140
	public void updateProductList()
	{
		this.availableProducts.Clear();
		for (int i = 0; i < this.unlockedProductTiers.Length; i++)
		{
			if (this.unlockedProductTiers[i])
			{
				string[] array = this.tiers[i].Split(char.Parse("-"), StringSplitOptions.None);
				int num = int.Parse(array[0]);
				int num2 = int.Parse(array[1]);
				for (int j = num; j < num2 + 1; j++)
				{
					this.availableProducts.Add(j);
				}
			}
		}
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x00028FB8 File Offset: 0x000271B8
	private IEnumerator DelayUpdateShelveActivation()
	{
		yield return new WaitForSeconds(5f);
		this.updateShelvesPrices();
		yield break;
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x00028FC8 File Offset: 0x000271C8
	public void updateShelvesPrices()
	{
		Transform child = base.GetComponent<NetworkSpawner>().levelPropsOBJ.transform.GetChild(0);
		if (child.childCount == 0)
		{
			return;
		}
		foreach (object obj in child)
		{
			Transform transform = (Transform)obj;
			int[] productInfoArray = transform.GetComponent<Data_Container>().productInfoArray;
			int num = productInfoArray.Length / 2;
			for (int i = 0; i < num; i++)
			{
				int num2 = productInfoArray[i * 2];
				if (num2 >= 0)
				{
					TextMeshPro component = transform.Find("Labels").GetChild(i).GetChild(0).GetComponent<TextMeshPro>();
					if (productInfoArray[i * 2 + 1] == 0)
					{
						component.text = "$0,00";
					}
					else
					{
						component.text = this.ConvertFloatToTextPrice(this.productPlayerPricing[num2]).ToString();
					}
				}
			}
		}
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x000290C4 File Offset: 0x000272C4
	public void SetBoxColor(GameObject boxOBJ, int productID)
	{
		int productTier = this.productPrefabs[productID].GetComponent<Data_Product>().productTier;
		int num = this.productGroups[productTier];
		Color color = this.groupsColors[num];
		boxOBJ.transform.Find("BoxMesh").GetComponent<SkinnedMeshRenderer>().material.color = color;
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x0002911C File Offset: 0x0002731C
	public string ConvertFloatToTextPrice(float price)
	{
		price = Mathf.Round(price * 100f) / 100f;
		string text = price.ToString();
		string currencyDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
		if (currencyDecimalSeparator != "," && text.Contains(currencyDecimalSeparator))
		{
			string[] array = text.Split(char.Parse(currencyDecimalSeparator), StringSplitOptions.None);
			text = array[0] + "," + array[1];
		}
		string[] array2 = text.Split(char.Parse(","), StringSplitOptions.None);
		if (array2.Length <= 1)
		{
			return "$" + array2[0] + ",00";
		}
		string text2 = array2[1];
		if (text2.Length == 1)
		{
			return string.Concat(new string[]
			{
				"$",
				array2[0],
				",",
				text2,
				"0"
			});
		}
		return "$" + text;
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x170000A9 RID: 169
	// (get) Token: 0x06000626 RID: 1574 RVA: 0x00029214 File Offset: 0x00027414
	// (set) Token: 0x06000627 RID: 1575 RVA: 0x00029227 File Offset: 0x00027427
	public float[] NetworkproductPlayerPricing
	{
		get
		{
			return this.productPlayerPricing;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<float[]>(value, ref this.productPlayerPricing, 1UL, null);
		}
	}

	// Token: 0x170000AA RID: 170
	// (get) Token: 0x06000628 RID: 1576 RVA: 0x00029244 File Offset: 0x00027444
	// (set) Token: 0x06000629 RID: 1577 RVA: 0x00029257 File Offset: 0x00027457
	public float[] NetworktierInflation
	{
		get
		{
			return this.tierInflation;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<float[]>(value, ref this.tierInflation, 2UL, null);
		}
	}

	// Token: 0x170000AB RID: 171
	// (get) Token: 0x0600062A RID: 1578 RVA: 0x00029274 File Offset: 0x00027474
	// (set) Token: 0x0600062B RID: 1579 RVA: 0x00029287 File Offset: 0x00027487
	public bool[] NetworkunlockedProductTiers
	{
		get
		{
			return this.unlockedProductTiers;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool[]>(value, ref this.unlockedProductTiers, 4UL, null);
		}
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x000292A1 File Offset: 0x000274A1
	protected void UserCode_CmdUpdateProductPrice__Int32__Single(int productID, float newPrice)
	{
		this.productPlayerPricing[productID] = newPrice;
		this.RpcUpdateProductPricer(productID, newPrice);
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x000292B4 File Offset: 0x000274B4
	protected static void InvokeUserCode_CmdUpdateProductPrice__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUpdateProductPrice called on client.");
			return;
		}
		((ProductListing)obj).UserCode_CmdUpdateProductPrice__Int32__Single(reader.ReadInt(), reader.ReadFloat());
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x000292E4 File Offset: 0x000274E4
	protected void UserCode_RpcUpdateProductPricer__Int32__Single(int productID, float newPrice)
	{
		this.productPlayerPricing[productID] = newPrice;
		this.updateShelvesPrices();
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x000292F5 File Offset: 0x000274F5
	protected static void InvokeUserCode_RpcUpdateProductPricer__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUpdateProductPricer called on server.");
			return;
		}
		((ProductListing)obj).UserCode_RpcUpdateProductPricer__Int32__Single(reader.ReadInt(), reader.ReadFloat());
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x00029325 File Offset: 0x00027525
	protected void UserCode_CmdUnlockProductTier__Int32(int tierIndex)
	{
		this.unlockedProductTiers[tierIndex] = false;
		this.RpcUnlockProductTier(tierIndex);
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x00029337 File Offset: 0x00027537
	protected static void InvokeUserCode_CmdUnlockProductTier__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdUnlockProductTier called on client.");
			return;
		}
		((ProductListing)obj).UserCode_CmdUnlockProductTier__Int32(reader.ReadInt());
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x00029360 File Offset: 0x00027560
	protected void UserCode_RpcUnlockProductTier__Int32(int tierIndex)
	{
		this.unlockedProductTiers[tierIndex] = false;
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x0002936B File Offset: 0x0002756B
	protected static void InvokeUserCode_RpcUnlockProductTier__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcUnlockProductTier called on server.");
			return;
		}
		((ProductListing)obj).UserCode_RpcUnlockProductTier__Int32(reader.ReadInt());
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x00029394 File Offset: 0x00027594
	static ProductListing()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ProductListing), "System.Void ProductListing::CmdUpdateProductPrice(System.Int32,System.Single)", new RemoteCallDelegate(ProductListing.InvokeUserCode_CmdUpdateProductPrice__Int32__Single), false);
		RemoteProcedureCalls.RegisterCommand(typeof(ProductListing), "System.Void ProductListing::CmdUnlockProductTier(System.Int32)", new RemoteCallDelegate(ProductListing.InvokeUserCode_CmdUnlockProductTier__Int32), false);
		RemoteProcedureCalls.RegisterRpc(typeof(ProductListing), "System.Void ProductListing::RpcUpdateProductPricer(System.Int32,System.Single)", new RemoteCallDelegate(ProductListing.InvokeUserCode_RpcUpdateProductPricer__Int32__Single));
		RemoteProcedureCalls.RegisterRpc(typeof(ProductListing), "System.Void ProductListing::RpcUnlockProductTier(System.Int32)", new RemoteCallDelegate(ProductListing.InvokeUserCode_RpcUnlockProductTier__Int32));
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x00029424 File Offset: 0x00027624
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			Mirror.GeneratedNetworkCode._Write_System.Single[](writer, this.productPlayerPricing);
			Mirror.GeneratedNetworkCode._Write_System.Single[](writer, this.tierInflation);
			Mirror.GeneratedNetworkCode._Write_System.Boolean[](writer, this.unlockedProductTiers);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.Single[](writer, this.productPlayerPricing);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.Single[](writer, this.tierInflation);
		}
		if ((this.syncVarDirtyBits & 4UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.Boolean[](writer, this.unlockedProductTiers);
		}
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x000294D8 File Offset: 0x000276D8
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<float[]>(ref this.productPlayerPricing, null, Mirror.GeneratedNetworkCode._Read_System.Single[](reader));
			base.GeneratedSyncVarDeserialize<float[]>(ref this.tierInflation, null, Mirror.GeneratedNetworkCode._Read_System.Single[](reader));
			base.GeneratedSyncVarDeserialize<bool[]>(ref this.unlockedProductTiers, null, Mirror.GeneratedNetworkCode._Read_System.Boolean[](reader));
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<float[]>(ref this.productPlayerPricing, null, Mirror.GeneratedNetworkCode._Read_System.Single[](reader));
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<float[]>(ref this.tierInflation, null, Mirror.GeneratedNetworkCode._Read_System.Single[](reader));
		}
		if ((num & 4L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool[]>(ref this.unlockedProductTiers, null, Mirror.GeneratedNetworkCode._Read_System.Boolean[](reader));
		}
	}

	// Token: 0x040004F6 RID: 1270
	public static ProductListing Instance;

	// Token: 0x040004F7 RID: 1271
	public GameObject skillTreeOBJ;

	// Token: 0x040004F8 RID: 1272
	public GameObject[] productPrefabs;

	// Token: 0x040004F9 RID: 1273
	public Sprite[] productSprites;

	// Token: 0x040004FA RID: 1274
	[Space(10f)]
	[SyncVar]
	public float[] productPlayerPricing;

	// Token: 0x040004FB RID: 1275
	[SyncVar]
	public float[] tierInflation;

	// Token: 0x040004FC RID: 1276
	[SyncVar]
	public bool[] unlockedProductTiers;

	// Token: 0x040004FD RID: 1277
	[Space(10f)]
	public string[] tiers;

	// Token: 0x040004FE RID: 1278
	public List<int> availableProducts = new List<int>();

	// Token: 0x040004FF RID: 1279
	public int[] productGroups;

	// Token: 0x04000500 RID: 1280
	public Color[] groupsColors;
}

using System;
using UnityEngine;

// Token: 0x020000DC RID: 220
public class Readme : ScriptableObject
{
	// Token: 0x040005B8 RID: 1464
	public Texture2D icon;

	// Token: 0x040005B9 RID: 1465
	public string title;

	// Token: 0x040005BA RID: 1466
	public Readme.Section[] sections;

	// Token: 0x040005BB RID: 1467
	public bool loadedLayout;

	// Token: 0x020000DD RID: 221
	[Serializable]
	public class Section
	{
		// Token: 0x040005BC RID: 1468
		public string heading;

		// Token: 0x040005BD RID: 1469
		public string text;

		// Token: 0x040005BE RID: 1470
		public string linkText;

		// Token: 0x040005BF RID: 1471
		public string url;
	}
}

using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public class ReflectionProbesManager : MonoBehaviour
{
	// Token: 0x0600063D RID: 1597 RVA: 0x0002960A File Offset: 0x0002780A
	private void Start()
	{
		base.StartCoroutine(this.ProbesManagerCoroutine());
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x00029619 File Offset: 0x00027819
	private IEnumerator ProbesManagerCoroutine()
	{
		yield return new WaitForSeconds(8f);
		for (;;)
		{
			ReflectionProbe[] array = this.probesArray;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RenderProbe();
				yield return new WaitForSeconds(0.15f);
			}
			array = null;
			yield return new WaitForSeconds(20f);
		}
		yield break;
	}

	// Token: 0x04000504 RID: 1284
	public ReflectionProbe[] probesArray;
}

using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class Rotateobject : MonoBehaviour
{
	// Token: 0x0600002A RID: 42 RVA: 0x0000495A File Offset: 0x00002B5A
	private void Start()
	{
		base.transform.Rotate(new Vector3(0f, Random.Range(0f, 360f), 0f));
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00004985 File Offset: 0x00002B85
	private void Update()
	{
		base.transform.Rotate(new Vector3(0f, this.speed * Time.deltaTime, 0f));
	}

	// Token: 0x0400006F RID: 111
	public float speed;
}

using System;
using HutongGames.PlayMaker;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class SaveBehaviour : MonoBehaviour
{
	// Token: 0x06000646 RID: 1606 RVA: 0x00029738 File Offset: 0x00027938
	public void SavePersistentValues()
	{
		string value = FsmVariables.GlobalVariables.GetFsmString("CurrentFilename").Value;
		string text = Application.persistentDataPath + "/" + value;
		ES3Settings settings = new ES3Settings(ES3.EncryptionType.AES, "g#asojrtg@omos)^yq");
		ES3.CacheFile(text, settings);
		ES3Settings settings2 = new ES3Settings(text, new Enum[]
		{
			ES3.Location.Cache
		});
		GameData component = this.gameDataOBJ.GetComponent<GameData>();
		ES3.Save<int>("Difficulty", component.difficulty, settings2);
		ES3.Save<int>("Day", component.gameDay, settings2);
		ES3.Save<int>("FranchiseExperience", component.gameFranchiseExperience, settings2);
		ES3.Save<int>("FranchisePoints", component.gameFranchisePoints, settings2);
		ES3.Save<float>("Funds", component.gameFunds, settings2);
		NetworkSpawner component2 = this.gameDataOBJ.GetComponent<NetworkSpawner>();
		UpgradesManager component3 = this.gameDataOBJ.GetComponent<UpgradesManager>();
		ProductListing component4 = this.gameDataOBJ.GetComponent<ProductListing>();
		PaintablesManager component5 = this.gameDataOBJ.GetComponent<PaintablesManager>();
		ES3.Save<string>("SupermarketName", component2.SuperMarketName, settings2);
		ES3.Save<Color>("SupermarketColor", component2.SuperMarketColor, settings2);
		ES3.Save<int>("SpaceBought", component3.spaceBought, settings2);
		ES3.Save<int>("StorageBought", component3.storageBought, settings2);
		ES3.Save<bool[]>("AddonsBought", component3.addonsBought, settings2);
		ES3.Save<bool[]>("ExtraUpgrades", component3.extraUpgrades, settings2);
		ES3.Save<float[]>("ProductPlayerPricing", component4.productPlayerPricing, settings2);
		ES3.Save<float[]>("TierInflation", component4.tierInflation, settings2);
		ES3.Save<bool[]>("UnlockedProductTiers", component4.unlockedProductTiers, settings2);
		ES3.Save<string[]>("PaintableValues", component5.paintablesValuesArray, settings2);
		ES3.StoreCachedFile(text, settings);
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x000298EC File Offset: 0x00027AEC
	public void LoadPersistentValues()
	{
		string value = FsmVariables.GlobalVariables.GetFsmString("CurrentFilename").Value;
		string text = Application.persistentDataPath + "/" + value;
		ES3Settings settings = new ES3Settings(ES3.EncryptionType.AES, "g#asojrtg@omos)^yq");
		ES3.CacheFile(text, settings);
		ES3Settings settings2 = new ES3Settings(text, new Enum[]
		{
			ES3.Location.Cache
		});
		GameData component = this.gameDataOBJ.GetComponent<GameData>();
		component.difficulty = ES3.Load<int>("Difficulty", settings2);
		if (ES3.KeyExists("Day", settings2))
		{
			component.NetworkgameDay = ES3.Load<int>("Day", settings2);
			component.NetworkgameFranchiseExperience = ES3.Load<int>("FranchiseExperience", settings2);
			component.NetworkgameFranchisePoints = ES3.Load<int>("FranchisePoints", settings2);
			component.NetworkgameFunds = ES3.Load<float>("Funds", settings2);
			NetworkSpawner component2 = this.gameDataOBJ.GetComponent<NetworkSpawner>();
			UpgradesManager component3 = this.gameDataOBJ.GetComponent<UpgradesManager>();
			ProductListing component4 = this.gameDataOBJ.GetComponent<ProductListing>();
			PaintablesManager component5 = this.gameDataOBJ.GetComponent<PaintablesManager>();
			component2.NetworkSuperMarketName = ES3.Load<string>("SupermarketName", settings2);
			component2.NetworkSuperMarketColor = ES3.Load<Color>("SupermarketColor", settings2);
			component3.NetworkspaceBought = ES3.Load<int>("SpaceBought", settings2);
			component3.NetworkstorageBought = ES3.Load<int>("StorageBought", settings2);
			bool[] array = ES3.Load<bool[]>("AddonsBought", settings2);
			for (int i = 0; i < array.Length; i++)
			{
				component3.addonsBought[i] = array[i];
			}
			bool[] array2 = ES3.Load<bool[]>("ExtraUpgrades", settings2);
			for (int j = 0; j < array2.Length; j++)
			{
				component3.extraUpgrades[j] = array2[j];
			}
			float[] array3 = ES3.Load<float[]>("ProductPlayerPricing", settings2);
			for (int k = 0; k < array3.Length; k++)
			{
				component4.productPlayerPricing[k] = array3[k];
			}
			float[] array4 = ES3.Load<float[]>("TierInflation", settings2);
			for (int l = 0; l < array4.Length; l++)
			{
				component4.tierInflation[l] = array4[l];
			}
			bool[] array5 = ES3.Load<bool[]>("UnlockedProductTiers", settings2);
			for (int m = 0; m < array5.Length; m++)
			{
				component4.unlockedProductTiers[m] = array5[m];
			}
			if (ES3.KeyExists("PaintableValues", settings2))
			{
				string[] array6 = ES3.Load<string[]>("PaintableValues", settings2);
				for (int n = 0; n < array6.Length; n++)
				{
					component5.paintablesValuesArray[n] = array6[n];
				}
			}
		}
		this.initialLoadDone = true;
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x00029B5C File Offset: 0x00027D5C
	public void LoadUpgradesValues(bool[] addonsArray, bool[] upgradesArray)
	{
		UpgradesManager component = this.gameDataOBJ.GetComponent<UpgradesManager>();
		for (int i = 0; i < addonsArray.Length; i++)
		{
			component.addonsBought[i] = addonsArray[i];
		}
		for (int j = 0; j < upgradesArray.Length; j++)
		{
			component.extraUpgrades[j] = upgradesArray[j];
		}
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x00029BA8 File Offset: 0x00027DA8
	public void LoadProductValues(float[] pPlayerPricingArray, float[] tInflationArray, bool[] uProductTiersArray)
	{
		ProductListing component = this.gameDataOBJ.GetComponent<ProductListing>();
		for (int i = 0; i < pPlayerPricingArray.Length; i++)
		{
			component.productPlayerPricing[i] = pPlayerPricingArray[i];
		}
		for (int j = 0; j < tInflationArray.Length; j++)
		{
			component.tierInflation[j] = tInflationArray[j];
		}
		for (int k = 0; k < uProductTiersArray.Length; k++)
		{
			component.unlockedProductTiers[k] = uProductTiersArray[k];
		}
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x00029C0C File Offset: 0x00027E0C
	public void LoadPaintableValues(string[] paintableValues)
	{
		PaintablesManager component = this.gameDataOBJ.GetComponent<PaintablesManager>();
		for (int i = 0; i < paintableValues.Length; i++)
		{
			component.paintablesValuesArray[i] = paintableValues[i];
		}
	}

	// Token: 0x0400050A RID: 1290
	public bool initialLoadDone;

	// Token: 0x0400050B RID: 1291
	public GameObject gameDataOBJ;
}

using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000B9 RID: 185
public class SeasonalBehaviour : MonoBehaviour
{
	// Token: 0x0600064C RID: 1612 RVA: 0x00029C40 File Offset: 0x00027E40
	private void Update()
	{
		if (this.gameDataComponent.isSupermarketOpen && this.gameDataComponent.timeOfDay > 18.75f && this.currentState == 0)
		{
			this.musicFSM.SendEvent("Send_Data");
			this.nightLight.color = this.halloweenColor;
			this.nightLight.intensity = 3f;
			if (!this.coroutineRunning)
			{
				base.StartCoroutine(this.InterpolateHalloweenTrees());
			}
			if (!this.CheckSphereCast())
			{
				this.nSpawner.HalloweenGhostSpawn();
			}
			this.currentState = 1;
		}
		if (!this.gameDataComponent.isSupermarketOpen && this.gameDataComponent.timeOfDay < 8.05f && this.currentState == 1)
		{
			this.musicFSM.SendEvent("Send_Data_2");
			this.nightLight.color = Color.white;
			this.nightLight.intensity = 1f;
			this.HideTrees();
			this.currentState = 0;
		}
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x00029D3C File Offset: 0x00027F3C
	private bool CheckSphereCast()
	{
		RaycastHit raycastHit;
		Physics.SphereCast(new Vector3(32f, 2f, -2.5f), 0.25f, Vector3.down, out raycastHit, 4f, this.lMask);
		if (raycastHit.transform)
		{
			if (raycastHit.transform.gameObject.GetComponent<BuildableInfo>())
			{
				int decorationID = raycastHit.transform.gameObject.GetComponent<BuildableInfo>().decorationID;
				if (decorationID >= 11 && decorationID <= 16)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x00029DCB File Offset: 0x00027FCB
	private IEnumerator InterpolateHalloweenTrees()
	{
		this.coroutineRunning = true;
		foreach (Transform transform in this.treesOBJs)
		{
			transform.localScale = Vector3.zero;
			transform.gameObject.SetActive(true);
		}
		float elapsedTime = 0f;
		float waitTime = 8f;
		while (elapsedTime < waitTime)
		{
			float t = Mathf.Lerp(0f, 1f, elapsedTime / waitTime);
			for (int j = 0; j < this.treesScale.Length; j++)
			{
				float b = this.treesScale[j];
				Transform transform2 = this.treesOBJs[j];
				float num = Mathf.Lerp(0f, b, t);
				transform2.localScale = new Vector3(num, num, num);
			}
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		yield return null;
		this.coroutineRunning = false;
		yield break;
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x00029DDC File Offset: 0x00027FDC
	private void HideTrees()
	{
		Transform[] array = this.treesOBJs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(false);
		}
	}

	// Token: 0x0400050C RID: 1292
	public GameData gameDataComponent;

	// Token: 0x0400050D RID: 1293
	public PlayMakerFSM musicFSM;

	// Token: 0x0400050E RID: 1294
	public Light nightLight;

	// Token: 0x0400050F RID: 1295
	public Color halloweenColor;

	// Token: 0x04000510 RID: 1296
	public Transform[] treesOBJs;

	// Token: 0x04000511 RID: 1297
	public float[] treesScale;

	// Token: 0x04000512 RID: 1298
	public NetworkSpawner nSpawner;

	// Token: 0x04000513 RID: 1299
	public GameObject ghostsSpawnpoint;

	// Token: 0x04000514 RID: 1300
	public LayerMask lMask;

	// Token: 0x04000515 RID: 1301
	[Space(10f)]
	public GameObject ghostPrefabOBJ;

	// Token: 0x04000516 RID: 1302
	private int currentState;

	// Token: 0x04000517 RID: 1303
	private bool coroutineRunning;
}

using System;
using Mirror;
using Mirror.RemoteCalls;
using Smooth;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class ServerAuthorityExamplePlayerController : NetworkBehaviour
{
	// Token: 0x06000728 RID: 1832 RVA: 0x0002CE0D File Offset: 0x0002B00D
	private void Awake()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.smoothSync = base.GetComponent<SmoothSyncMirror>();
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x0002CE27 File Offset: 0x0002B027
	public override void OnStartServer()
	{
		this.rb.isKinematic = false;
		base.OnStartServer();
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x0002CE3C File Offset: 0x0002B03C
	private void Update()
	{
		if (base.isOwned)
		{
			if (Input.GetKeyUp(KeyCode.DownArrow))
			{
				this.CmdMove(KeyCode.DownArrow);
			}
			if (Input.GetKeyUp(KeyCode.UpArrow))
			{
				this.CmdMove(KeyCode.UpArrow);
			}
			if (Input.GetKeyUp(KeyCode.LeftArrow))
			{
				this.CmdMove(KeyCode.LeftArrow);
			}
			if (Input.GetKeyUp(KeyCode.RightArrow))
			{
				this.CmdMove(KeyCode.RightArrow);
			}
			if (Input.GetKeyUp(KeyCode.T))
			{
				this.CmdTeleport();
			}
		}
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x0002CEBC File Offset: 0x0002B0BC
	[Command]
	private void CmdTeleport()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void ServerAuthorityExamplePlayerController::CmdTeleport()", 55251365, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x0002CEEC File Offset: 0x0002B0EC
	[Command]
	private void CmdMove(KeyCode keyCode)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		Mirror.GeneratedNetworkCode._Write_UnityEngine.KeyCode(writer, keyCode);
		base.SendCommandInternal("System.Void ServerAuthorityExamplePlayerController::CmdMove(UnityEngine.KeyCode)", -953675450, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x0002CF44 File Offset: 0x0002B144
	protected void UserCode_CmdTeleport()
	{
		this.smoothSync.teleportAnyObjectFromServer(base.transform.position + Vector3.right * 5f, base.transform.rotation, base.transform.localScale);
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x0002CF91 File Offset: 0x0002B191
	protected static void InvokeUserCode_CmdTeleport(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTeleport called on client.");
			return;
		}
		((ServerAuthorityExamplePlayerController)obj).UserCode_CmdTeleport();
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x0002CFB4 File Offset: 0x0002B1B4
	protected void UserCode_CmdMove__KeyCode(KeyCode keyCode)
	{
		switch (keyCode)
		{
		case KeyCode.UpArrow:
			this.rb.AddForce(new Vector3(0f, 1.5f, 1f) * this.rigidbodyMovementForce);
			return;
		case KeyCode.DownArrow:
			this.rb.AddForce(new Vector3(0f, -1.5f, -1f) * this.rigidbodyMovementForce);
			return;
		case KeyCode.RightArrow:
			this.rb.AddForce(new Vector3(1f, 0f, 0f) * this.rigidbodyMovementForce);
			return;
		case KeyCode.LeftArrow:
			this.rb.AddForce(new Vector3(-1f, 0f, 0f) * this.rigidbodyMovementForce);
			return;
		default:
			return;
		}
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x0002D089 File Offset: 0x0002B289
	protected static void InvokeUserCode_CmdMove__KeyCode(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdMove called on client.");
			return;
		}
		((ServerAuthorityExamplePlayerController)obj).UserCode_CmdMove__KeyCode(Mirror.GeneratedNetworkCode._Read_UnityEngine.KeyCode(reader));
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x0002D0B4 File Offset: 0x0002B2B4
	static ServerAuthorityExamplePlayerController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ServerAuthorityExamplePlayerController), "System.Void ServerAuthorityExamplePlayerController::CmdTeleport()", new RemoteCallDelegate(ServerAuthorityExamplePlayerController.InvokeUserCode_CmdTeleport), true);
		RemoteProcedureCalls.RegisterCommand(typeof(ServerAuthorityExamplePlayerController), "System.Void ServerAuthorityExamplePlayerController::CmdMove(UnityEngine.KeyCode)", new RemoteCallDelegate(ServerAuthorityExamplePlayerController.InvokeUserCode_CmdMove__KeyCode), true);
	}

	// Token: 0x040005A1 RID: 1441
	private Rigidbody rb;

	// Token: 0x040005A2 RID: 1442
	public float transformMovementSpeed = 30f;

	// Token: 0x040005A3 RID: 1443
	public float rigidbodyMovementForce = 500f;

	// Token: 0x040005A4 RID: 1444
	private SmoothSyncMirror smoothSync;
}

using System;
using System.Globalization;
using System.Threading;
using UnityEngine;

// Token: 0x020000BB RID: 187
public class SetCultureDecimal : MonoBehaviour
{
	// Token: 0x06000657 RID: 1623 RVA: 0x00029F6C File Offset: 0x0002816C
	private void Start()
	{
		string name = Thread.CurrentThread.CurrentCulture.Name;
		CultureInfo cultureInfo = new CultureInfo(name);
		if (cultureInfo.NumberFormat.NumberDecimalSeparator != ",")
		{
			cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
			Thread.CurrentThread.CurrentCulture = cultureInfo;
		}
		this.debug1 = name;
		this.debug2 = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
	}

	// Token: 0x0400051D RID: 1309
	public string debug1;

	// Token: 0x0400051E RID: 1310
	public string debug2;
}

using System;
using TMPro;
using UnityEngine;

// Token: 0x020000BC RID: 188
public class SetLocalizationString : MonoBehaviour
{
	// Token: 0x06000659 RID: 1625 RVA: 0x00029FE3 File Offset: 0x000281E3
	private void Start()
	{
		base.GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString(this.localizationKey);
	}

	// Token: 0x0400051F RID: 1311
	public string localizationKey;
}

using System;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x020000BD RID: 189
public class SetVolume : MonoBehaviour
{
	// Token: 0x0600065B RID: 1627 RVA: 0x0002A000 File Offset: 0x00028200
	public void SetLevel(string mixerString, float sliderValue)
	{
		this.mixer.SetFloat(mixerString, Mathf.Log(sliderValue) * 20f);
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x0002A01C File Offset: 0x0002821C
	public float GetLevel(string mixerString)
	{
		float result;
		if (this.mixer.GetFloat("masterVol", out result))
		{
			return result;
		}
		return 0f;
	}

	// Token: 0x04000520 RID: 1312
	public AudioMixer mixer;

	// Token: 0x04000521 RID: 1313
	private float floatvalue;
}

using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class SetVsyncCount : MonoBehaviour
{
	// Token: 0x0600065E RID: 1630 RVA: 0x0002A044 File Offset: 0x00028244
	public void SetVsync(int vsyncValue)
	{
		QualitySettings.vSyncCount = vsyncValue;
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x0002A04C File Offset: 0x0002824C
	public void SetApplicationTargetFrameRate(int framerate)
	{
		if (framerate < -1 || framerate == 0)
		{
			framerate = -1;
		}
		Application.targetFrameRate = framerate;
	}
}

using System;
using System.Collections.Generic;

// Token: 0x02000015 RID: 21
public static class ShfuffleExtension
{
	// Token: 0x0600004F RID: 79 RVA: 0x000065D4 File Offset: 0x000047D4
	public static void Shuffle<T>(this IList<T> shuffleList)
	{
		int i = shuffleList.Count;
		while (i > 1)
		{
			i--;
			int index = ShfuffleExtension.RandomGenerator.Next(i + 1);
			T value = shuffleList[index];
			shuffleList[index] = shuffleList[i];
			shuffleList[i] = value;
		}
	}

	// Token: 0x0400009D RID: 157
	private static readonly Random RandomGenerator = new Random();
}

using System;
using Mirror;
using Smooth;
using UnityEngine;

// Token: 0x020000D7 RID: 215
public class SmoothSyncMirrorExamplePlayerController : NetworkBehaviour
{
	// Token: 0x06000734 RID: 1844 RVA: 0x0002D104 File Offset: 0x0002B304
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>();
		this.rb2D = base.GetComponent<Rigidbody2D>();
		this.smoothSync = base.GetComponent<SmoothSyncMirror>();
		if (this.smoothSync)
		{
			this.smoothSync.validateStateMethod = new SmoothSyncMirror.validateStateDelegate(SmoothSyncMirrorExamplePlayerController.validateStateOfPlayer);
		}
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x0002D15C File Offset: 0x0002B35C
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			if (base.isOwned)
			{
				base.transform.position = base.transform.position + Vector3.right * 18f;
				this.smoothSync.teleportOwnedObjectFromOwner();
			}
			else if (NetworkServer.active)
			{
				this.smoothSync.teleportAnyObjectFromServer(base.transform.position + Vector3.right * 18f, base.transform.rotation, base.transform.localScale);
			}
		}
		if (!base.isOwned && (!NetworkServer.active || base.netIdentity.connectionToClient != null))
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			this.smoothSync.forceStateSendNextFixedUpdate();
		}
		Input.GetKeyDown(KeyCode.C);
		float d = this.transformMovementSpeed * Time.deltaTime;
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Equals))
		{
			base.transform.localScale = base.transform.localScale + new Vector3(1f, 1f, 1f) * d * 0.2f;
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Minus))
		{
			base.transform.localScale = base.transform.localScale - new Vector3(1f, 1f, 1f) * d * 0.2f;
		}
		if (this.childObjectToControl)
		{
			if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.Equals))
			{
				this.childObjectToControl.transform.localScale = this.childObjectToControl.transform.localScale + new Vector3(1f, 1f, 1f) * d * 0.2f;
			}
			if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.Minus))
			{
				this.childObjectToControl.transform.localScale = this.childObjectToControl.transform.localScale - new Vector3(1f, 1f, 1f) * d * 0.2f;
			}
		}
		if (this.childObjectToControl)
		{
			if (Input.GetKey(KeyCode.S))
			{
				this.childObjectToControl.transform.position = this.childObjectToControl.transform.position + new Vector3(0f, -1.5f, -1f) * d;
			}
			if (Input.GetKey(KeyCode.W))
			{
				this.childObjectToControl.transform.position = this.childObjectToControl.transform.position + new Vector3(0f, 1.5f, 1f) * d;
			}
			if (Input.GetKey(KeyCode.A))
			{
				this.childObjectToControl.transform.position = this.childObjectToControl.transform.position + new Vector3(-1f, 0f, 0f) * d;
			}
			if (Input.GetKey(KeyCode.D))
			{
				this.childObjectToControl.transform.position = this.childObjectToControl.transform.position + new Vector3(1f, 0f, 0f) * d;
			}
		}
		if (this.rb)
		{
			if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				this.rb.velocity = Vector3.zero;
				this.rb.angularVelocity = Vector3.zero;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				this.rb.AddForce(new Vector3(0f, -1.5f, -1f) * this.rigidbodyMovementForce);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				this.rb.AddForce(new Vector3(0f, 1.5f, 1f) * this.rigidbodyMovementForce);
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.rb.AddForce(new Vector3(-1f, 0f, 0f) * this.rigidbodyMovementForce);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				this.rb.AddForce(new Vector3(1f, 0f, 0f) * this.rigidbodyMovementForce);
				return;
			}
		}
		else if (this.rb2D)
		{
			if (Input.GetKeyDown(KeyCode.Alpha0))
			{
				this.rb2D.velocity = Vector3.zero;
				this.rb2D.angularVelocity = 0f;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				this.rb2D.AddForce(new Vector3(0f, -1.5f, -1f) * this.rigidbodyMovementForce);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				this.rb2D.AddForce(new Vector3(0f, 1.5f, 1f) * this.rigidbodyMovementForce);
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				this.rb2D.AddForce(new Vector3(-1f, 0f, 0f) * this.rigidbodyMovementForce);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				this.rb2D.AddForce(new Vector3(1f, 0f, 0f) * this.rigidbodyMovementForce);
				return;
			}
		}
		else
		{
			if (Input.GetKey(KeyCode.DownArrow))
			{
				base.transform.position = base.transform.position + new Vector3(0f, 0f, -1f) * d;
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				base.transform.position = base.transform.position + new Vector3(0f, 0f, 1f) * d;
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				base.transform.position = base.transform.position + new Vector3(-1f, 0f, 0f) * d;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				base.transform.position = base.transform.position + new Vector3(1f, 0f, 0f) * d;
			}
		}
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x0002D82C File Offset: 0x0002BA2C
	public static bool validateStateOfPlayer(StateMirror latestReceivedState, StateMirror latestValidatedState)
	{
		return Vector3.Distance(latestReceivedState.position, latestValidatedState.position) <= 9000f || latestReceivedState.ownerTimestamp - latestValidatedState.receivedOnServerTimestamp >= 0.5f;
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x040005A5 RID: 1445
	private Rigidbody rb;

	// Token: 0x040005A6 RID: 1446
	private Rigidbody2D rb2D;

	// Token: 0x040005A7 RID: 1447
	private SmoothSyncMirror smoothSync;

	// Token: 0x040005A8 RID: 1448
	public float transformMovementSpeed = 30f;

	// Token: 0x040005A9 RID: 1449
	public float rigidbodyMovementForce = 500f;

	// Token: 0x040005AA RID: 1450
	public GameObject childObjectToControl;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class StandingPeopleConcert : MonoBehaviour
{
	// Token: 0x06000036 RID: 54 RVA: 0x00004BBC File Offset: 0x00002DBC
	public void OnDrawGizmos()
	{
		if (!this.isCircle)
		{
			this.surface.transform.localScale = new Vector3(this.planeSize.x, 1f, this.planeSize.y);
			return;
		}
		this.surface.transform.localScale = new Vector3(this.circleDiametr, 1f, this.circleDiametr);
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00004C28 File Offset: 0x00002E28
	public void SpawnRectangleSurface()
	{
		if (this.surface != null)
		{
			Object.DestroyImmediate(this.surface);
		}
		GameObject gameObject = Object.Instantiate<GameObject>(this.planePrefab, base.transform.position, Quaternion.identity);
		this.surface = gameObject;
		this.isCircle = false;
		gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
		gameObject.transform.position += new Vector3(0f, 0.01f, 0f);
		gameObject.transform.parent = base.transform;
		gameObject.name = "surface";
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00004D00 File Offset: 0x00002F00
	public void SpawnCircleSurface()
	{
		if (this.surface != null)
		{
			Object.DestroyImmediate(this.surface);
		}
		GameObject gameObject = Object.Instantiate<GameObject>(this.circlePrefab, base.transform.position, Quaternion.identity);
		this.isCircle = true;
		gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
		gameObject.transform.position += new Vector3(0f, 0.01f, 0f);
		gameObject.transform.parent = base.transform;
		gameObject.name = "surface";
		this.surface = gameObject;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00004DD6 File Offset: 0x00002FD6
	public void RemoveButton()
	{
		if (this.par != null)
		{
			Object.DestroyImmediate(this.par);
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00004DF4 File Offset: 0x00002FF4
	public void PopulateButton()
	{
		this.RemoveButton();
		GameObject gameObject = new GameObject();
		this.par = gameObject;
		gameObject.transform.parent = base.gameObject.transform;
		gameObject.name = "people";
		this.spawnPoints.Clear();
		this.SpawnPeople(this.peopleCount);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00004E4C File Offset: 0x0000304C
	private void SpawnPeople(int _peopleCount)
	{
		int[] randomPrefabIndexes = CommonUtils.GetRandomPrefabIndexes(_peopleCount, ref this.peoplePrefabs);
		for (int i = 0; i < _peopleCount; i++)
		{
			Vector3 vector;
			if (!this.isCircle)
			{
				vector = this.RandomRectanglePosition();
			}
			else
			{
				vector = this.RandomCirclePosition();
			}
			if (vector != Vector3.zero)
			{
				GameObject gameObject = this.peoplePrefabs[randomPrefabIndexes[i]];
				RaycastHit raycastHit;
				if (Physics.Raycast(vector + Vector3.up * this.highToSpawn, Vector3.down, out raycastHit, float.PositiveInfinity))
				{
					GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject, new Vector3(vector.x, raycastHit.point.y, vector.z), Quaternion.Euler(gameObject.transform.rotation.x, base.transform.eulerAngles.y, gameObject.transform.rotation.z));
					PeopleController peopleController = gameObject2.AddComponent<PeopleController>();
					this.spawnPoints.Add(gameObject2.transform.position);
					if (this.target != null)
					{
						peopleController.SetTarget(this.target.transform.position);
						if (this.looking)
						{
							peopleController.target = this.target.transform;
							peopleController.damping = this.damping;
						}
					}
					peopleController.animNames = new string[]
					{
						"idle1",
						"idle2",
						"cheer",
						"claphands"
					};
					gameObject2.transform.parent = this.par.transform;
				}
			}
		}
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00004FE4 File Offset: 0x000031E4
	private Vector3 RandomRectanglePosition()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		for (int i = 0; i < 10; i++)
		{
			vector.x = this.surface.transform.position.x - this.GetRealPlaneSize().x / 2f + Random.Range(0f, this.GetRealPlaneSize().x - 0.6f);
			vector.z = this.surface.transform.position.z - this.GetRealPlaneSize().y / 2f + Random.Range(0f, this.GetRealPlaneSize().y - 0.6f);
			vector.y = this.surface.transform.position.y;
			if (this.IsRandomPositionFree(vector))
			{
				return vector;
			}
		}
		return Vector3.zero;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x000050DC File Offset: 0x000032DC
	private Vector3 RandomCirclePosition()
	{
		Vector3 position = this.surface.transform.position;
		float num = this.GetRealPlaneSize().x / 2f;
		for (int i = 0; i < 10; i++)
		{
			float num2 = Random.value * num;
			float num3 = Random.value * 360f;
			Vector3 vector;
			vector.x = position.x + num2 * Mathf.Sin(num3 * 0.017453292f);
			vector.y = position.y;
			vector.z = position.z + num2 * Mathf.Cos(num3 * 0.017453292f);
			if (this.IsRandomPositionFree(vector))
			{
				return vector;
			}
		}
		return Vector3.zero;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00005188 File Offset: 0x00003388
	private bool IsRandomPositionFree(Vector3 pos)
	{
		for (int i = 0; i < this.spawnPoints.Count; i++)
		{
			if (this.spawnPoints[i].x - 0.6f < pos.x && this.spawnPoints[i].x + 1f > pos.x && this.spawnPoints[i].z - 0.5f < pos.z && this.spawnPoints[i].z + 0.6f > pos.z)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00005230 File Offset: 0x00003430
	private Vector2 GetRealPlaneSize()
	{
		Vector3 size = this.surface.GetComponent<MeshRenderer>().bounds.size;
		return new Vector2(size.x, size.z);
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00005268 File Offset: 0x00003468
	private Vector2 GetRealPeopleModelSize()
	{
		Vector3 size = this.peoplePrefabs[1].GetComponent<MeshRenderer>().bounds.size;
		return new Vector2(size.x, size.z);
	}

	// Token: 0x0400007A RID: 122
	[HideInInspector]
	public GameObject planePrefab;

	// Token: 0x0400007B RID: 123
	[HideInInspector]
	public GameObject circlePrefab;

	// Token: 0x0400007C RID: 124
	[HideInInspector]
	public GameObject surface;

	// Token: 0x0400007D RID: 125
	[HideInInspector]
	public Vector2 planeSize = new Vector2(1f, 1f);

	// Token: 0x0400007E RID: 126
	[Tooltip("People prefabs / Префабы людей")]
	public GameObject[] peoplePrefabs = new GameObject[0];

	// Token: 0x0400007F RID: 127
	[HideInInspector]
	private List<Vector3> spawnPoints = new List<Vector3>();

	// Token: 0x04000080 RID: 128
	[HideInInspector]
	public GameObject target;

	// Token: 0x04000081 RID: 129
	[HideInInspector]
	public int peopleCount;

	// Token: 0x04000082 RID: 130
	[HideInInspector]
	public bool isCircle;

	// Token: 0x04000083 RID: 131
	[HideInInspector]
	public float circleDiametr = 1f;

	// Token: 0x04000084 RID: 132
	[HideInInspector]
	public bool showSurface = true;

	// Token: 0x04000085 RID: 133
	[Tooltip("Type of surface / Тип поверхности")]
	public StandingPeopleConcert.TestEnum SurfaceType;

	// Token: 0x04000086 RID: 134
	[HideInInspector]
	public GameObject par;

	// Token: 0x04000087 RID: 135
	[HideInInspector]
	public bool looking;

	// Token: 0x04000088 RID: 136
	[HideInInspector]
	public float damping = 5f;

	// Token: 0x04000089 RID: 137
	[HideInInspector]
	public float highToSpawn;

	// Token: 0x02000011 RID: 17
	public enum TestEnum
	{
		// Token: 0x0400008B RID: 139
		Rectangle,
		// Token: 0x0400008C RID: 140
		Circle
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class StandingPeopleStreet : MonoBehaviour
{
	// Token: 0x06000042 RID: 66 RVA: 0x00005300 File Offset: 0x00003500
	public void OnDrawGizmos()
	{
		if (!this.isCircle)
		{
			this.surface.transform.localScale = new Vector3(this.planeSize.x, 1f, this.planeSize.y);
			return;
		}
		this.surface.transform.localScale = new Vector3(this.circleDiametr, 1f, this.circleDiametr);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x0000536C File Offset: 0x0000356C
	public void SpawnRectangleSurface()
	{
		if (this.surface != null)
		{
			Object.DestroyImmediate(this.surface);
		}
		GameObject gameObject = Object.Instantiate<GameObject>(this.planePrefab, base.transform.position, Quaternion.identity);
		this.surface = gameObject;
		this.isCircle = false;
		gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
		gameObject.transform.position += new Vector3(0f, 0.01f, 0f);
		gameObject.transform.parent = base.transform;
		gameObject.name = "surface";
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00005444 File Offset: 0x00003644
	public void SpawnCircleSurface()
	{
		if (this.surface != null)
		{
			Object.DestroyImmediate(this.surface);
		}
		GameObject gameObject = Object.Instantiate<GameObject>(this.circlePrefab, base.transform.position, Quaternion.identity);
		this.isCircle = true;
		gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
		gameObject.transform.position += new Vector3(0f, 0.01f, 0f);
		gameObject.transform.parent = base.transform;
		gameObject.name = "surface";
		this.surface = gameObject;
	}

	// Token: 0x06000045 RID: 69 RVA: 0x0000551A File Offset: 0x0000371A
	public void RemoveButton()
	{
		if (this.par != null)
		{
			Object.DestroyImmediate(this.par);
		}
		this.par = null;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x0000553C File Offset: 0x0000373C
	public void PopulateButton()
	{
		this.RemoveButton();
		GameObject gameObject = new GameObject();
		this.par = gameObject;
		gameObject.transform.parent = base.gameObject.transform;
		gameObject.name = "people";
		this.spawnPoints.Clear();
		this.SpawnPeople(this.peopleCount);
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00005594 File Offset: 0x00003794
	private void SpawnPeople(int _peopleCount)
	{
		int num = Random.Range(0, _peopleCount / 3) * 3;
		int num2 = Random.Range(0, (_peopleCount - num) / 2) * 2;
		int num3 = _peopleCount - num - num2;
		int[] randomPrefabIndexes = CommonUtils.GetRandomPrefabIndexes(this.peopleCount, ref this.peoplePrefabs);
		int num4 = 0;
		for (int i = 0; i < num3; i++)
		{
			Vector3 vector;
			if (!this.isCircle)
			{
				vector = this.RandomRectanglePosition();
			}
			else
			{
				vector = this.RandomCirclePosition();
			}
			RaycastHit raycastHit;
			if (vector != Vector3.zero && Physics.Raycast(vector + Vector3.up * this.highToSpawn, Vector3.down, out raycastHit, float.PositiveInfinity))
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.peoplePrefabs[randomPrefabIndexes[num4]], new Vector3(vector.x, raycastHit.point.y, vector.z), Quaternion.identity);
				num4++;
				gameObject.AddComponent<PeopleController>();
				this.spawnPoints.Add(gameObject.transform.position);
				gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.rotation.x, (float)Random.Range(1, 359), gameObject.transform.rotation.z);
				gameObject.GetComponent<PeopleController>().animNames = new string[]
				{
					"idle1",
					"idle2"
				};
				gameObject.transform.parent = this.par.transform;
			}
		}
		for (int j = 0; j < num2 / 2; j++)
		{
			Vector3 vector2;
			if (!this.isCircle)
			{
				vector2 = this.RandomRectanglePosition();
			}
			else
			{
				vector2 = this.RandomCirclePosition();
			}
			if (vector2 != Vector3.zero)
			{
				Vector3 vector3 = Vector3.zero;
				Vector3 vector4 = Vector3.zero;
				for (int k = 0; k < 100; k++)
				{
					for (int l = 0; l < 10; l++)
					{
						vector3 = vector2 + new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
						if (this.IsRandomPositionFree(vector3, Vector3.zero, Vector3.zero))
						{
							break;
						}
						vector3 = Vector3.zero;
					}
					for (int m = 0; m < 10; m++)
					{
						vector4 = vector2 + new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
						if (this.IsRandomPositionFree(vector4, vector3, Vector3.zero))
						{
							break;
						}
						vector4 = Vector3.zero;
					}
					if (vector3 != Vector3.zero && vector4 != Vector3.zero)
					{
						this.spawnPoints.Add(vector3);
						this.spawnPoints.Add(vector4);
						break;
					}
					vector3 = Vector3.zero;
					vector4 = Vector3.zero;
				}
				if (vector3 != Vector3.zero && vector4 != Vector3.zero)
				{
					int num5 = Random.Range(0, this.peoplePrefabs.Length);
					RaycastHit raycastHit2;
					if (Physics.Raycast(vector3 + Vector3.up * this.highToSpawn, Vector3.down, out raycastHit2, float.PositiveInfinity))
					{
						GameObject gameObject2 = Object.Instantiate<GameObject>(this.peoplePrefabs[num5], new Vector3(vector3.x, raycastHit2.point.y, vector3.z), Quaternion.identity);
						num4++;
						gameObject2.AddComponent<PeopleController>();
						gameObject2.GetComponent<PeopleController>().animNames = new string[]
						{
							"talk1",
							"talk2",
							"listen"
						};
						gameObject2.transform.parent = this.par.transform;
						num5 = Random.Range(0, this.peoplePrefabs.Length);
						RaycastHit raycastHit3;
						if (Physics.Raycast(vector4 + Vector3.up * this.highToSpawn, Vector3.down, out raycastHit3, float.PositiveInfinity))
						{
							GameObject gameObject3 = Object.Instantiate<GameObject>(this.peoplePrefabs[num5], new Vector3(vector4.x, raycastHit3.point.y, vector4.z), Quaternion.identity);
							gameObject3.AddComponent<PeopleController>();
							gameObject3.GetComponent<PeopleController>().animNames = new string[]
							{
								"talk1",
								"talk2",
								"listen"
							};
							gameObject3.transform.parent = this.par.transform;
							gameObject3.GetComponent<PeopleController>().SetTarget(gameObject2.transform.position);
							gameObject2.GetComponent<PeopleController>().SetTarget(gameObject3.transform.position);
						}
					}
				}
			}
		}
		for (int n = 0; n < num / 3; n++)
		{
			Vector3 vector5;
			if (!this.isCircle)
			{
				vector5 = this.RandomRectanglePosition();
			}
			else
			{
				vector5 = this.RandomCirclePosition();
			}
			if (vector5 != Vector3.zero)
			{
				int num6 = Random.Range(0, this.peoplePrefabs.Length);
				Vector3 vector6 = Vector3.zero;
				Vector3 vector7 = Vector3.zero;
				Vector3 vector8 = Vector3.zero;
				for (int num7 = 0; num7 < 100; num7++)
				{
					for (int num8 = 0; num8 < 10; num8++)
					{
						vector6 = vector5 + new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
						if (this.IsRandomPositionFree(vector6, Vector3.zero, Vector3.zero))
						{
							break;
						}
						vector6 = Vector3.zero;
					}
					for (int num9 = 0; num9 < 10; num9++)
					{
						if (vector6 != Vector3.zero)
						{
							vector7 = vector5 + new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
							if (this.IsRandomPositionFree(vector7, vector6, Vector3.zero))
							{
								break;
							}
							vector7 = Vector3.zero;
						}
						else
						{
							vector7 = Vector3.zero;
						}
					}
					for (int num10 = 0; num10 < 10; num10++)
					{
						if (vector7 != Vector3.zero && vector6 != Vector3.zero)
						{
							vector8 = vector5 + new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(-0.5f, 0.5f));
							if (this.IsRandomPositionFree(vector8, vector6, vector7))
							{
								break;
							}
							vector8 = Vector3.zero;
						}
						else
						{
							vector8 = Vector3.zero;
						}
					}
					if (vector6 != Vector3.zero && vector7 != Vector3.zero && vector8 != Vector3.zero)
					{
						this.spawnPoints.Add(vector6);
						this.spawnPoints.Add(vector7);
						this.spawnPoints.Add(vector8);
						break;
					}
					vector6 = Vector3.zero;
					vector7 = Vector3.zero;
					vector8 = Vector3.zero;
				}
				if (vector6 != Vector3.zero)
				{
					if (vector6 != Vector3.zero)
					{
						RaycastHit raycastHit4;
						if (!Physics.Raycast(vector6 + Vector3.up * this.highToSpawn, Vector3.down, out raycastHit4, float.PositiveInfinity))
						{
							goto IL_978;
						}
						GameObject gameObject4 = Object.Instantiate<GameObject>(this.peoplePrefabs[num6], new Vector3(vector6.x, raycastHit4.point.y, vector6.z), Quaternion.identity);
						num4++;
						gameObject4.AddComponent<PeopleController>();
						gameObject4.GetComponent<PeopleController>().SetTarget(vector5);
						gameObject4.GetComponent<PeopleController>().animNames = new string[]
						{
							"talk1",
							"talk2",
							"listen"
						};
						gameObject4.transform.parent = this.par.transform;
					}
					num6 = Random.Range(0, this.peoplePrefabs.Length);
					if (vector6 != Vector3.zero)
					{
						RaycastHit raycastHit5;
						if (!Physics.Raycast(vector7 + Vector3.up * this.highToSpawn, Vector3.down, out raycastHit5, float.PositiveInfinity))
						{
							goto IL_978;
						}
						GameObject gameObject5 = Object.Instantiate<GameObject>(this.peoplePrefabs[num6], new Vector3(vector7.x, raycastHit5.point.y, vector7.z), Quaternion.identity);
						num4++;
						gameObject5.AddComponent<PeopleController>();
						gameObject5.GetComponent<PeopleController>().SetTarget(vector5);
						gameObject5.GetComponent<PeopleController>().animNames = new string[]
						{
							"talk1",
							"talk2",
							"listen"
						};
						gameObject5.transform.parent = this.par.transform;
					}
					num6 = Random.Range(0, this.peoplePrefabs.Length);
					RaycastHit raycastHit6;
					if (vector6 != Vector3.zero && Physics.Raycast(vector8 + Vector3.up * this.highToSpawn, Vector3.down, out raycastHit6, float.PositiveInfinity))
					{
						GameObject gameObject6 = Object.Instantiate<GameObject>(this.peoplePrefabs[num6], new Vector3(vector8.x, raycastHit6.point.y, vector8.z), Quaternion.identity);
						num4++;
						gameObject6.AddComponent<PeopleController>();
						gameObject6.GetComponent<PeopleController>().SetTarget(vector5);
						gameObject6.GetComponent<PeopleController>().animNames = new string[]
						{
							"talk1",
							"talk2",
							"listen"
						};
						gameObject6.transform.parent = this.par.transform;
					}
				}
			}
			IL_978:;
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00005F2C File Offset: 0x0000412C
	private Vector3 RandomRectanglePosition()
	{
		Vector3 vector = new Vector3(0f, 0f, 0f);
		for (int i = 0; i < 10; i++)
		{
			vector.x = this.surface.transform.position.x - this.GetRealPlaneSize().x / 2f + 0.3f + Random.Range(0f, this.GetRealPlaneSize().x - 0.6f);
			vector.z = this.surface.transform.position.z - this.GetRealPlaneSize().y / 2f + 0.3f + Random.Range(0f, this.GetRealPlaneSize().y - 0.6f);
			vector.y = this.surface.transform.position.y;
			if (this.IsRandomPositionFree(vector, Vector3.zero, Vector3.zero))
			{
				return vector;
			}
		}
		return Vector3.zero;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00006038 File Offset: 0x00004238
	private Vector3 RandomCirclePosition()
	{
		Vector3 position = this.surface.transform.position;
		float num = this.GetRealPlaneSize().x / 2f;
		for (int i = 0; i < 10; i++)
		{
			float num2 = Random.value * num;
			float num3 = Random.value * 360f;
			Vector3 vector;
			vector.x = position.x + num2 * Mathf.Sin(num3 * 0.017453292f);
			vector.y = position.y;
			vector.z = position.z + num2 * Mathf.Cos(num3 * 0.017453292f);
			if (Vector3.Distance(vector, position) < this.GetRealPlaneSize().x / 2f - 0.3f && this.IsRandomPositionFree(vector, Vector3.zero, Vector3.zero))
			{
				return vector;
			}
		}
		return Vector3.zero;
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00006114 File Offset: 0x00004314
	private bool IsRandomPositionFree(Vector3 pos, Vector3 helpPoint1, Vector3 helpPoint2)
	{
		for (int i = 0; i < this.spawnPoints.Count; i++)
		{
			if (this.spawnPoints[i].x - 0.5f < pos.x && this.spawnPoints[i].x + 0.5f > pos.x && this.spawnPoints[i].z - 0.5f < pos.z && this.spawnPoints[i].z + 0.5f > pos.z)
			{
				return false;
			}
		}
		if (helpPoint1 != Vector3.zero)
		{
			if (helpPoint1.x - 0.6f < pos.x && helpPoint1.x + 0.6f > pos.x && helpPoint1.z - 0.6f < pos.z && helpPoint1.z + 0.6f > pos.z)
			{
				return false;
			}
			if (!this.isCircle)
			{
				if (helpPoint1.x + 0.3f <= this.surface.transform.position.x - this.GetRealPlaneSize().x / 2f && helpPoint1.x - 0.3f >= this.surface.transform.position.x + this.GetRealPlaneSize().x / 2f && helpPoint1.z + 0.3f <= this.surface.transform.position.z - this.GetRealPlaneSize().y / 2f && helpPoint1.z - 0.3f >= this.surface.transform.position.z + this.GetRealPlaneSize().y / 2f)
				{
					return false;
				}
			}
			else if (Vector3.Distance(helpPoint1, this.surface.transform.position) >= this.GetRealPlaneSize().x / 2f - 0.3f)
			{
				return false;
			}
		}
		if (helpPoint2 != Vector3.zero)
		{
			if (helpPoint2.x - 0.6f < pos.x && helpPoint2.x + 0.6f > pos.x && helpPoint2.z - 0.6f < pos.z && helpPoint2.z + 0.6f > pos.z)
			{
				return false;
			}
			if (!this.isCircle)
			{
				if (helpPoint2.x + 0.3f <= this.surface.transform.position.x - this.GetRealPlaneSize().x / 2f && helpPoint2.x - 0.3f >= this.surface.transform.position.x + this.GetRealPlaneSize().x / 2f && helpPoint2.z + 0.3f <= this.surface.transform.position.z - this.GetRealPlaneSize().y / 2f && helpPoint2.z - 0.3f >= this.surface.transform.position.z + this.GetRealPlaneSize().y / 2f)
				{
					return false;
				}
			}
			else if (Vector3.Distance(helpPoint2, this.surface.transform.position) >= this.GetRealPlaneSize().x / 2f - 0.3f)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x000064B0 File Offset: 0x000046B0
	private Vector2 GetRealPlaneSize()
	{
		Vector3 size = this.surface.GetComponent<MeshRenderer>().bounds.size;
		return new Vector2(size.x, size.z);
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000064E8 File Offset: 0x000046E8
	private Vector2 GetRealPeopleModelSize()
	{
		Vector3 size = this.peoplePrefabs[1].GetComponent<MeshRenderer>().bounds.size;
		return new Vector2(size.x, size.z);
	}

	// Token: 0x0400008D RID: 141
	[HideInInspector]
	public GameObject planePrefab;

	// Token: 0x0400008E RID: 142
	[HideInInspector]
	public GameObject circlePrefab;

	// Token: 0x0400008F RID: 143
	[HideInInspector]
	public GameObject surface;

	// Token: 0x04000090 RID: 144
	[HideInInspector]
	public Vector2 planeSize = new Vector2(1f, 1f);

	// Token: 0x04000091 RID: 145
	[Tooltip("People prefabs / Префабы людей")]
	public GameObject[] peoplePrefabs = new GameObject[0];

	// Token: 0x04000092 RID: 146
	[HideInInspector]
	public List<Vector3> spawnPoints = new List<Vector3>();

	// Token: 0x04000093 RID: 147
	[HideInInspector]
	public int peopleCount;

	// Token: 0x04000094 RID: 148
	[HideInInspector]
	public bool isCircle;

	// Token: 0x04000095 RID: 149
	[HideInInspector]
	public float circleDiametr = 1f;

	// Token: 0x04000096 RID: 150
	[HideInInspector]
	public bool showSurface = true;

	// Token: 0x04000097 RID: 151
	[Tooltip("Type of surface / Тип поверхности")]
	public StandingPeopleStreet.TestEnum SurfaceType;

	// Token: 0x04000098 RID: 152
	[HideInInspector]
	public GameObject par;

	// Token: 0x04000099 RID: 153
	[HideInInspector]
	public float highToSpawn;

	// Token: 0x02000013 RID: 19
	public enum TestEnum
	{
		// Token: 0x0400009B RID: 155
		Rectangle,
		// Token: 0x0400009C RID: 156
		Circle
	}
}

using System;
using System.Collections.Generic;
using Mirror;
using Steamworks;
using UnityEngine;

// Token: 0x0200008C RID: 140
public class SteamLobby : MonoBehaviour
{
	// Token: 0x0600049B RID: 1179 RVA: 0x0001FBE4 File Offset: 0x0001DDE4
	private void Start()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		if (SteamLobby.Instance == null)
		{
			SteamLobby.Instance = this;
		}
		this.manager = base.GetComponent<CustomNetworkManager>();
		this.LobbyCreated = Callback<LobbyCreated_t>.Create(new Callback<LobbyCreated_t>.DispatchDelegate(this.OnLobbyCreated));
		this.JoinRequest = Callback<GameLobbyJoinRequested_t>.Create(new Callback<GameLobbyJoinRequested_t>.DispatchDelegate(this.OnJoinRequest));
		this.LobbyEntered = Callback<LobbyEnter_t>.Create(new Callback<LobbyEnter_t>.DispatchDelegate(this.OnLobbyEntered));
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x0001FC60 File Offset: 0x0001DE60
	public void HostLobby(int gameMode)
	{
		switch (gameMode)
		{
		case 0:
			this.LocalHost();
			return;
		case 1:
			SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, this.manager.maxConnections);
			return;
		case 2:
			SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, this.manager.maxConnections);
			return;
		default:
			this.LocalHost();
			return;
		}
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x0001FCB4 File Offset: 0x0001DEB4
	private void LocalHost()
	{
		this.manager.networkAddress = "localhost";
		this.manager.StartHost();
		Debug.Log("Local host started from SteamLobby");
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x0001FCDC File Offset: 0x0001DEDC
	private void OnLobbyCreated(LobbyCreated_t callback)
	{
		if (callback.m_eResult != EResult.k_EResultOK)
		{
			return;
		}
		Debug.Log("Lobby created successfully");
		if (this.fsmCallbackOBJ)
		{
			this.fsmCallbackOBJ.GetComponent<PlayMakerFSM>().SendEvent("Send_Data_3");
		}
		this.manager.StartHost();
		SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "HostAddress", SteamUser.GetSteamID().ToString());
		SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name", SteamFriends.GetPersonaName().ToString() + "'s Supermarket");
		SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "status", "true");
	}

	// Token: 0x0600049F RID: 1183 RVA: 0x0001FD98 File Offset: 0x0001DF98
	private void OnJoinRequest(GameLobbyJoinRequested_t callback)
	{
		Debug.Log("Request to Join lobby");
		SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x0001FDB0 File Offset: 0x0001DFB0
	private void OnLobbyEntered(LobbyEnter_t callback)
	{
		this.CurrentLobbyID = callback.m_ulSteamIDLobby;
		this.CurrentLobbyIDStr = this.CurrentLobbyID.ToString();
		if (NetworkServer.active)
		{
			return;
		}
		if (this.fsmCallbackOBJ)
		{
			this.fsmCallbackOBJ.GetComponent<PlayMakerFSM>().SendEvent("Send_Data_2");
		}
		this.manager.networkAddress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "HostAddress");
		this.manager.StartClient();
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x0001FE2F File Offset: 0x0001E02F
	public void JoinLobby(CSteamID lobbyID)
	{
		SteamMatchmaking.JoinLobby(lobbyID);
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x0001FE38 File Offset: 0x0001E038
	public void LobbyJStr(string lobbyIDstr)
	{
		SteamMatchmaking.JoinLobby((CSteamID)ulong.Parse(lobbyIDstr));
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x0001FE4B File Offset: 0x0001E04B
	public void LeaveGame()
	{
		this.LeaveLobby((CSteamID)this.CurrentLobbyID);
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0001FE60 File Offset: 0x0001E060
	public void SetCurrentLobbyJoinable(bool set)
	{
		if (!SteamMatchmaking.SetLobbyJoinable((CSteamID)this.CurrentLobbyID, set))
		{
			Debug.Log("Couldn't change joinable");
			return;
		}
		if (set)
		{
			NetworkServer.maxConnections = 16;
			Debug.Log("Joinable Changed succesfully to open");
			this.isLobbyClosed = false;
			SteamMatchmaking.SetLobbyData((CSteamID)this.CurrentLobbyID, "status", "true");
			return;
		}
		NetworkServer.maxConnections = NetworkServer.connections.Count;
		Debug.Log("Joinable Changed succesfully to close");
		this.isLobbyClosed = true;
		SteamMatchmaking.SetLobbyData((CSteamID)this.CurrentLobbyID, "status", "false");
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x0001FEFD File Offset: 0x0001E0FD
	public void ClosedLobbyListener()
	{
		if (this.isLobbyClosed)
		{
			NetworkServer.maxConnections = NetworkServer.connections.Count;
		}
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x0001FF18 File Offset: 0x0001E118
	private void LeaveLobby(CSteamID ThisCSteamID)
	{
		SteamMatchmaking.LeaveLobby(ThisCSteamID);
		if (NetworkClient.activeHost)
		{
			this.manager.StopHost();
			Debug.Log("Host stopped");
		}
		else
		{
			this.manager.StopClient();
			Debug.Log("Client stopped");
		}
		this.CanRestartGame = true;
	}

	// Token: 0x040003BF RID: 959
	public static SteamLobby Instance;

	// Token: 0x040003C0 RID: 960
	public GameObject fsmCallbackOBJ;

	// Token: 0x040003C1 RID: 961
	protected Callback<LobbyCreated_t> LobbyCreated;

	// Token: 0x040003C2 RID: 962
	protected Callback<GameLobbyJoinRequested_t> JoinRequest;

	// Token: 0x040003C3 RID: 963
	protected Callback<LobbyEnter_t> LobbyEntered;

	// Token: 0x040003C4 RID: 964
	public List<CSteamID> lobbyIDs = new List<CSteamID>();

	// Token: 0x040003C5 RID: 965
	public ulong CurrentLobbyID;

	// Token: 0x040003C6 RID: 966
	public string CurrentLobbyIDStr;

	// Token: 0x040003C7 RID: 967
	private const string HostAddressKey = "HostAddress";

	// Token: 0x040003C8 RID: 968
	private CustomNetworkManager manager;

	// Token: 0x040003C9 RID: 969
	public bool CanRestartGame;

	// Token: 0x040003CA RID: 970
	public bool isLobbyClosed;

	// Token: 0x040003CB RID: 971
	public Color[] PlayersColorsArray;
}

using System;
using System.Text;
using AOT;
using Steamworks;
using UnityEngine;

// Token: 0x020000BF RID: 191
[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	// Token: 0x170000B2 RID: 178
	// (get) Token: 0x06000661 RID: 1633 RVA: 0x0002A05E File Offset: 0x0002825E
	protected static SteamManager Instance
	{
		get
		{
			if (SteamManager.s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return SteamManager.s_instance;
		}
	}

	// Token: 0x170000B3 RID: 179
	// (get) Token: 0x06000662 RID: 1634 RVA: 0x0002A082 File Offset: 0x00028282
	public static bool Initialized
	{
		get
		{
			return SteamManager.Instance.m_bInitialized;
		}
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x0002A08E File Offset: 0x0002828E
	[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
	protected static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x0002A096 File Offset: 0x00028296
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void InitOnPlayMode()
	{
		SteamManager.s_EverInitialized = false;
		SteamManager.s_instance = null;
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x0002A0A4 File Offset: 0x000282A4
	protected virtual void Awake()
	{
		if (SteamManager.s_instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		SteamManager.s_instance = this;
		if (SteamManager.s_EverInitialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		Object.DontDestroyOnLoad(base.gameObject);
		if (!Packsize.Test())
		{
			Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary(AppId_t.Invalid))
			{
				Debug.Log("[Steamworks.NET] Shutting down because RestartAppIfNecessary returned true. Steam will restart the application.");
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException ex)
		{
			string str = "[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n";
			DllNotFoundException ex2 = ex;
			Debug.LogError(str + ((ex2 != null) ? ex2.ToString() : null), this);
			Application.Quit();
			return;
		}
		this.m_bInitialized = SteamAPI.Init();
		if (!this.m_bInitialized)
		{
			Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			return;
		}
		SteamManager.s_EverInitialized = true;
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x0002A18C File Offset: 0x0002838C
	protected virtual void OnEnable()
	{
		if (SteamManager.s_instance == null)
		{
			SteamManager.s_instance = this;
		}
		if (!this.m_bInitialized)
		{
			return;
		}
		if (this.m_SteamAPIWarningMessageHook == null)
		{
			this.m_SteamAPIWarningMessageHook = new SteamAPIWarningMessageHook_t(SteamManager.SteamAPIDebugTextHook);
			SteamClient.SetWarningMessageHook(this.m_SteamAPIWarningMessageHook);
		}
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x0002A1DA File Offset: 0x000283DA
	protected virtual void OnDestroy()
	{
		if (SteamManager.s_instance != this)
		{
			return;
		}
		SteamManager.s_instance = null;
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.Shutdown();
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x0002A1FE File Offset: 0x000283FE
	protected virtual void Update()
	{
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.RunCallbacks();
	}

	// Token: 0x04000522 RID: 1314
	protected static bool s_EverInitialized;

	// Token: 0x04000523 RID: 1315
	protected static SteamManager s_instance;

	// Token: 0x04000524 RID: 1316
	protected bool m_bInitialized;

	// Token: 0x04000525 RID: 1317
	protected SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;
}

using System;
using Steamworks;
using UnityEngine;

// Token: 0x020000C0 RID: 192
public class SteamOverlay : MonoBehaviour
{
	// Token: 0x0600066A RID: 1642 RVA: 0x0002A20E File Offset: 0x0002840E
	private void OnEnable()
	{
		if (SteamManager.Initialized)
		{
			this.m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(new Callback<GameOverlayActivated_t>.DispatchDelegate(this.OnGameOverlayActivated));
		}
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x0002A22E File Offset: 0x0002842E
	private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
	{
		if (pCallback.m_bActive != 0)
		{
			Debug.Log("Steam Overlay has been activated");
			return;
		}
		Debug.Log("Steam Overlay has been closed");
	}

	// Token: 0x04000526 RID: 1318
	protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using HighlightPlus;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x020000C1 RID: 193
public class StolenProductSpawn : NetworkBehaviour
{
	// Token: 0x0600066D RID: 1645 RVA: 0x0002A24D File Offset: 0x0002844D
	public override void OnStartClient()
	{
		base.StartCoroutine(this.CreateProductObject());
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x0002A25C File Offset: 0x0002845C
	private IEnumerator CreateProductObject()
	{
		yield return new WaitUntil(() => ProductListing.Instance);
		GameObject gameObject = Object.Instantiate<GameObject>(ProductListing.Instance.productPrefabs[this.productID], base.transform);
		gameObject.transform.localPosition = Vector3.zero;
		BoxCollider component = base.GetComponent<BoxCollider>();
		component.center = gameObject.GetComponent<BoxCollider>().center;
		component.size = gameObject.GetComponent<BoxCollider>().size;
		base.GetComponent<HighlightEffect>().enabled = true;
		Vector3 force = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
		base.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
		this.isFinished = true;
		yield return null;
		yield break;
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x0002A26C File Offset: 0x0002846C
	[Command(requiresAuthority = false)]
	public void CmdRecoverStolenProduct()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void StolenProductSpawn::CmdRecoverStolenProduct()", 2099923190, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x0002A29C File Offset: 0x0002849C
	public void RecoverStolenProductFromEmployee()
	{
		GameData.Instance.AlterFundsFromEmployee(this.productCarryingPrice);
		NetworkServer.Destroy(base.gameObject);
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x0002A2B9 File Offset: 0x000284B9
	public IEnumerator TimedDestroy()
	{
		yield return new WaitForSeconds(20f);
		NetworkServer.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x170000B4 RID: 180
	// (get) Token: 0x06000674 RID: 1652 RVA: 0x0002A2C8 File Offset: 0x000284C8
	// (set) Token: 0x06000675 RID: 1653 RVA: 0x0002A2DB File Offset: 0x000284DB
	public int NetworkproductID
	{
		get
		{
			return this.productID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.productID, 1UL, null);
		}
	}

	// Token: 0x170000B5 RID: 181
	// (get) Token: 0x06000676 RID: 1654 RVA: 0x0002A2F8 File Offset: 0x000284F8
	// (set) Token: 0x06000677 RID: 1655 RVA: 0x0002A30B File Offset: 0x0002850B
	public float NetworkproductCarryingPrice
	{
		get
		{
			return this.productCarryingPrice;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<float>(value, ref this.productCarryingPrice, 2UL, null);
		}
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x0002A325 File Offset: 0x00028525
	protected void UserCode_CmdRecoverStolenProduct()
	{
		GameData.Instance.CmdAlterFunds(this.productCarryingPrice);
		NetworkServer.Destroy(base.gameObject);
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x0002A342 File Offset: 0x00028542
	protected static void InvokeUserCode_CmdRecoverStolenProduct(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRecoverStolenProduct called on client.");
			return;
		}
		((StolenProductSpawn)obj).UserCode_CmdRecoverStolenProduct();
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x0002A365 File Offset: 0x00028565
	static StolenProductSpawn()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(StolenProductSpawn), "System.Void StolenProductSpawn::CmdRecoverStolenProduct()", new RemoteCallDelegate(StolenProductSpawn.InvokeUserCode_CmdRecoverStolenProduct), false);
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x0002A388 File Offset: 0x00028588
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.productID);
			writer.WriteFloat(this.productCarryingPrice);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.productID);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteFloat(this.productCarryingPrice);
		}
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x0002A410 File Offset: 0x00028610
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.productID, null, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<float>(ref this.productCarryingPrice, null, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.productID, null, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<float>(ref this.productCarryingPrice, null, reader.ReadFloat());
		}
	}

	// Token: 0x04000527 RID: 1319
	[SyncVar]
	public int productID;

	// Token: 0x04000528 RID: 1320
	[SyncVar]
	public float productCarryingPrice;

	// Token: 0x04000529 RID: 1321
	public bool isFinished;
}

using System;
using System.Collections;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// Token: 0x020000C5 RID: 197
public class TheCoolRoom : MonoBehaviour
{
	// Token: 0x0600068C RID: 1676 RVA: 0x0002A65F File Offset: 0x0002885F
	private void Start()
	{
		this.videoPlayer = base.GetComponent<VideoPlayer>();
		this.LoadValues();
		base.StartCoroutine(this.DelayedVideoActivation());
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x0002A680 File Offset: 0x00028880
	private void LoadValues()
	{
		string filePath = Application.persistentDataPath + "/GameOptions.es3";
		if (ES3.KeyExists("localizationhash3", filePath))
		{
			int[] array = ES3.Load<int[]>("localizationhash3", filePath);
			GameObject gameObject = base.transform.Find("Canvas_Skins/Container/Poses").gameObject;
			for (int i = 0; i < gameObject.transform.childCount; i++)
			{
				if (i != 0)
				{
					gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = array[i].ToString();
				}
			}
		}
		if (ES3.KeyExists("localizationhash1", filePath))
		{
			int num = ES3.Load<int>("localizationhash1", filePath);
			this.skinCanvasOBJ.transform.Find("Container/CharacterNumber").GetComponent<TextMeshProUGUI>().text = num.ToString();
		}
		if (ES3.KeyExists("localizationhash2", filePath))
		{
			int hatIndex = ES3.Load<int>("localizationhash2", filePath);
			this.skinCanvasOBJ.transform.Find("Container/HatNumber").GetComponent<TextMeshProUGUI>().text = hatIndex.ToString();
			base.StartCoroutine(this.AssignHatsToEmployeesCoroutine(hatIndex));
		}
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x0002A798 File Offset: 0x00028998
	private void Update()
	{
		if (FirstPersonController.Instance)
		{
			float num = Vector3.Distance(FirstPersonController.Instance.transform.position, this.skinCanvasOBJ.transform.position);
			if (num < 3f && !this.objsActivated)
			{
				this.objsActivated = true;
				GameObject[] objsActivation = this.OBJsActivation;
				for (int i = 0; i < objsActivation.Length; i++)
				{
					objsActivation[i].SetActive(true);
				}
				this.currentCharacterIndex = FirstPersonController.Instance.GetComponent<PlayerNetwork>().characterID;
				this.currentHatIndex = FirstPersonController.Instance.GetComponent<PlayerNetwork>().hatID;
				this.SetCharacter(this.currentCharacterIndex);
				if (this.dummyCharacterOBJ)
				{
					this.dummyCharacterOBJ.GetComponent<Animator>().SetFloat("PoseFloat", 0f);
				}
			}
			else if (num > 3f && this.objsActivated)
			{
				this.objsActivated = false;
				GameObject[] objsActivation = this.OBJsActivation;
				for (int i = 0; i < objsActivation.Length; i++)
				{
					objsActivation[i].SetActive(false);
				}
			}
		}
		if (!this.allowVideo)
		{
			return;
		}
		switch (this.videoMode)
		{
		case 0:
		case 2:
			break;
		case 1:
			if (!this.isPlayingVideo)
			{
				if (this.videoPlayer.source != VideoSource.VideoClip)
				{
					this.videoPlayer.source = VideoSource.VideoClip;
				}
				this.videoCoroutine = base.StartCoroutine(this.VideoPlayPlaceholder());
			}
			break;
		case 3:
			if (!this.browserCamera.activeSelf)
			{
				this.browserCamera.SetActive(true);
				return;
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x0002A91C File Offset: 0x00028B1C
	public void AttemptURLVideoPlay(string videoURL)
	{
		if (videoURL == "")
		{
			return;
		}
		if (this.isPlayingVideo)
		{
			base.StopCoroutine(this.videoCoroutine);
		}
		if (this.videoPlayer.source != VideoSource.Url)
		{
			this.videoPlayer.source = VideoSource.Url;
		}
		this.videoCoroutine = base.StartCoroutine(this.VideoPlayURL(videoURL));
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x0002A978 File Offset: 0x00028B78
	private IEnumerator VideoPlayURL(string videoURL)
	{
		this.isPlayingVideo = true;
		this.videoPlayer.isLooping = true;
		if (!this.currentAudioURLOBJ)
		{
			this.currentAudioURLOBJ = Object.Instantiate<GameObject>(this.audioURLPrefab);
		}
		this.videoPlayer.controlledAudioTrackCount = 1;
		this.videoPlayer.EnableAudioTrack(0, true);
		this.videoPlayer.SetTargetAudioSource(0, this.currentAudioURLOBJ.GetComponent<AudioSource>());
		this.videoPlayer.url = videoURL;
		this.videoPlayer.errorReceived += this.VideoPlayer_errorReceived;
		this.videoPlayer.Prepare();
		while (!this.videoPlayer.isPrepared)
		{
			yield return null;
		}
		this.videoPlayer.Play();
		this.currentAudioURLOBJ.GetComponent<AudioSource>().Play();
		yield return null;
		yield break;
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x0002A990 File Offset: 0x00028B90
	private void VideoPlayer_errorReceived(VideoPlayer source, string message)
	{
		this.errorOBJ.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
		this.errorOBJ.SetActive(true);
		this.videoPlayer.errorReceived -= this.VideoPlayer_errorReceived;
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x0002A9DC File Offset: 0x00028BDC
	private IEnumerator VideoPlayPlaceholder()
	{
		this.isPlayingVideo = true;
		yield return null;
		if (this.currentVideoIndex >= this.videoclipArray.Length)
		{
			this.currentVideoIndex = 0;
		}
		this.videoPlayer.clip = this.videoclipArray[this.currentVideoIndex];
		this.videoPlayer.Play();
		float seconds = (float)this.videoPlayer.clip.length;
		yield return new WaitForSeconds(seconds);
		yield return null;
		this.currentVideoIndex++;
		this.isPlayingVideo = false;
		yield break;
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x0002A9EC File Offset: 0x00028BEC
	private void TurnOffVideoPlayer()
	{
		this.videoPlayer.isLooping = false;
		if (this.videoPlayer.isPlaying)
		{
			this.videoPlayer.Stop();
		}
		if (this.videoPlayer.clip != null)
		{
			this.videoPlayer.clip = null;
		}
		if (this.isPlayingVideo)
		{
			this.isPlayingVideo = false;
			base.StopCoroutine(this.videoCoroutine);
		}
		this.browserCamera.SetActive(false);
		if (this.currentAudioURLOBJ)
		{
			Object.Destroy(this.currentAudioURLOBJ);
		}
		this.TVRenderTexture.Release();
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x0002AA86 File Offset: 0x00028C86
	private IEnumerator DelayedVideoActivation()
	{
		yield return new WaitForSeconds(11f);
		this.ChangeVideoMode(1);
		yield break;
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x0002AA95 File Offset: 0x00028C95
	public void ChangeVideoMode(int vMode)
	{
		if (!this.auxBool)
		{
			base.StartCoroutine(this.ChangeVideoCoroutine(vMode));
		}
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x0002AAAD File Offset: 0x00028CAD
	private IEnumerator ChangeVideoCoroutine(int vMode)
	{
		this.auxBool = true;
		this.videoMode = -1;
		this.TurnOffVideoPlayer();
		yield return new WaitForSeconds(0.25f);
		this.UpdateButtonSprites(vMode);
		this.videoMode = vMode;
		this.auxBool = false;
		yield break;
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x0002AAC3 File Offset: 0x00028CC3
	public void AllowVideoOption(bool set)
	{
		if (!set)
		{
			this.VideoPlayPlaceholder();
		}
		this.allowVideo = set;
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x0002AAD8 File Offset: 0x00028CD8
	private void UpdateButtonSprites(int currentMode)
	{
		for (int i = 0; i < this.buttonsArray.Length; i++)
		{
			if (i == currentMode)
			{
				this.buttonsArray[i].GetComponent<Image>().sprite = this.buttonOn;
			}
			else
			{
				this.buttonsArray[i].GetComponent<Image>().sprite = this.buttonOff;
			}
			if (currentMode == 2)
			{
				this.setLinkButton.interactable = true;
			}
			else
			{
				this.setLinkButton.interactable = false;
			}
		}
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x0002AB4C File Offset: 0x00028D4C
	public void CharacterIndexAdd(int add)
	{
		this.currentCharacterIndex += add;
		if (this.currentCharacterIndex < 0)
		{
			this.currentCharacterIndex = this.charactersArray.Length - 1;
		}
		else if (this.currentCharacterIndex >= this.charactersArray.Length)
		{
			this.currentCharacterIndex = 0;
		}
		this.SetCharacter(this.currentCharacterIndex);
		this.skinCanvasOBJ.transform.Find("Container/CharacterNumber").GetComponent<TextMeshProUGUI>().text = this.currentCharacterIndex.ToString();
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x0002ABD0 File Offset: 0x00028DD0
	public void HatIndexAdd(int add)
	{
		this.currentHatIndex += add;
		if (this.currentHatIndex < 0)
		{
			this.currentHatIndex = this.hatsArray.Length - 1;
		}
		else if (this.currentHatIndex >= this.hatsArray.Length)
		{
			this.currentHatIndex = 0;
		}
		this.SetHat(this.currentHatIndex);
		this.skinCanvasOBJ.transform.Find("Container/HatNumber").GetComponent<TextMeshProUGUI>().text = this.currentHatIndex.ToString();
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x0002AC54 File Offset: 0x00028E54
	public void SetCharacter(int characterIndex)
	{
		if (this.dummyCharacterOBJ)
		{
			Object.Destroy(this.dummyCharacterOBJ);
		}
		this.dummyCharacterOBJ = Object.Instantiate<GameObject>(this.charactersArray[characterIndex], this.dummySpawnSpot.transform);
		this.dummyCharacterOBJ.transform.localPosition = Vector3.zero;
		this.dummyCharacterOBJ.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
		FirstPersonController.Instance.GetComponent<PlayerNetwork>().CmdChangeCharacter(characterIndex);
		Animator component = this.dummyCharacterOBJ.GetComponent<Animator>();
		component.SetFloat("PoseFloat", (float)this.currentPose);
		component.Play("Pose");
		this.SetHat(this.currentHatIndex);
		this.SaveTrigger();
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x0002AD20 File Offset: 0x00028F20
	public void SetHat(int hatIndex)
	{
		if (this.dummyHatOBJ)
		{
			Object.Destroy(this.dummyHatOBJ);
		}
		FirstPersonController.Instance.GetComponent<PlayerNetwork>().CmdChangeHat(hatIndex);
		this.SaveTrigger();
		this.AssignHatsToEmployees(hatIndex);
		if (hatIndex == 0)
		{
			return;
		}
		GameObject value = this.dummyCharacterOBJ.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("HatSpot").Value;
		this.dummyHatOBJ = Object.Instantiate<GameObject>(this.hatsArray[hatIndex], value.transform);
		this.dummyHatOBJ.transform.localPosition = this.dummyHatOBJ.GetComponent<HatInfo>().offset;
		this.dummyHatOBJ.transform.localRotation = Quaternion.Euler(this.dummyHatOBJ.GetComponent<HatInfo>().rotation);
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x0002ADE4 File Offset: 0x00028FE4
	public void SetPose(int keyIndex, bool add)
	{
		if (!FirstPersonController.Instance)
		{
			return;
		}
		GameObject gameObject = base.transform.Find("Canvas_Skins/Container/Poses").gameObject;
		int num = 35;
		int num2 = 1;
		if (!add)
		{
			num2 = -1;
		}
		int num3 = FirstPersonController.Instance.GetComponent<PlayerNetwork>().posesArray[keyIndex];
		num3 += num2;
		if (num3 < 0)
		{
			num3 = num;
		}
		if (num3 > num)
		{
			num3 = 0;
		}
		FirstPersonController.Instance.GetComponent<PlayerNetwork>().posesArray[keyIndex] = num3;
		gameObject.transform.GetChild(keyIndex).GetComponent<TextMeshProUGUI>().text = num3.ToString();
		if (this.dummyCharacterOBJ)
		{
			Animator component = this.dummyCharacterOBJ.GetComponent<Animator>();
			component.SetFloat("PoseFloat", (float)num3);
			component.Play("Pose");
		}
		this.currentPose = num3;
		this.SaveTrigger();
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x0002AEA9 File Offset: 0x000290A9
	public void SaveTrigger()
	{
		if (!this.isSaving)
		{
			base.StartCoroutine(this.SaveCoroutine());
		}
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x0002AEC0 File Offset: 0x000290C0
	private IEnumerator SaveCoroutine()
	{
		this.isSaving = true;
		yield return new WaitForSeconds(3f);
		FirstPersonController.Instance.GetComponent<PlayerNetwork>().SavePlayerSkins();
		this.isSaving = false;
		yield break;
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x0002AECF File Offset: 0x000290CF
	private IEnumerator AssignHatsToEmployeesCoroutine(int hatIndex)
	{
		yield return new WaitForSeconds(5f);
		this.AssignHatsToEmployees(hatIndex);
		yield break;
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x0002AEE5 File Offset: 0x000290E5
	private void AssignHatsToEmployees(int hatIndex)
	{
		if (NPC_Manager.Instance)
		{
			NPC_Manager.Instance.SetEmployeesHats(hatIndex);
		}
	}

	// Token: 0x04000532 RID: 1330
	public GameObject[] OBJsActivation;

	// Token: 0x04000533 RID: 1331
	public GameObject skinCanvasOBJ;

	// Token: 0x04000534 RID: 1332
	[Space(10f)]
	public GameObject[] charactersArray;

	// Token: 0x04000535 RID: 1333
	public GameObject[] hatsArray;

	// Token: 0x04000536 RID: 1334
	private bool objsActivated;

	// Token: 0x04000537 RID: 1335
	private int currentCharacterIndex;

	// Token: 0x04000538 RID: 1336
	private int currentHatIndex;

	// Token: 0x04000539 RID: 1337
	public GameObject dummySpawnSpot;

	// Token: 0x0400053A RID: 1338
	private GameObject dummyCharacterOBJ;

	// Token: 0x0400053B RID: 1339
	private GameObject dummyHatOBJ;

	// Token: 0x0400053C RID: 1340
	public GameObject DebugOBJ;

	// Token: 0x0400053D RID: 1341
	private int currentPose;

	// Token: 0x0400053E RID: 1342
	private bool isSaving;

	// Token: 0x0400053F RID: 1343
	private bool allowVideo = true;

	// Token: 0x04000540 RID: 1344
	[Space(10f)]
	public VideoClip[] videoclipArray;

	// Token: 0x04000541 RID: 1345
	public RenderTexture TVRenderTexture;

	// Token: 0x04000542 RID: 1346
	public Sprite buttonOn;

	// Token: 0x04000543 RID: 1347
	public Sprite buttonOff;

	// Token: 0x04000544 RID: 1348
	public GameObject[] buttonsArray;

	// Token: 0x04000545 RID: 1349
	public GameObject browserCamera;

	// Token: 0x04000546 RID: 1350
	public Material RTMaterial;

	// Token: 0x04000547 RID: 1351
	public Button setLinkButton;

	// Token: 0x04000548 RID: 1352
	public GameObject audioURLPrefab;

	// Token: 0x04000549 RID: 1353
	public GameObject errorOBJ;

	// Token: 0x0400054A RID: 1354
	private GameObject currentAudioURLOBJ;

	// Token: 0x0400054B RID: 1355
	private int videoMode;

	// Token: 0x0400054C RID: 1356
	private int currentVideoIndex;

	// Token: 0x0400054D RID: 1357
	private VideoPlayer videoPlayer;

	// Token: 0x0400054E RID: 1358
	private bool isPlayingVideo;

	// Token: 0x0400054F RID: 1359
	private Coroutine videoCoroutine;

	// Token: 0x04000550 RID: 1360
	private bool auxBool;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using HighlightPlus;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

// Token: 0x020000CC RID: 204
public class TrashSpawn : NetworkBehaviour
{
	// Token: 0x060006C7 RID: 1735 RVA: 0x0002B33F File Offset: 0x0002953F
	public override void OnStartClient()
	{
		base.StartCoroutine(this.CreateTrash());
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x0002B34E File Offset: 0x0002954E
	private IEnumerator CreateTrash()
	{
		if (this.trashID >= this.trashPrefabs.Length)
		{
			this.NetworktrashID = 0;
		}
		GameObject gameObject = Object.Instantiate<GameObject>(this.trashPrefabs[this.trashID], base.transform);
		gameObject.transform.localPosition = Vector3.zero;
		BoxCollider component = base.GetComponent<BoxCollider>();
		component.center = gameObject.GetComponent<BoxCollider>().center;
		component.size = gameObject.GetComponent<BoxCollider>().size * gameObject.transform.lossyScale.x;
		base.GetComponent<HighlightEffect>().enabled = true;
		yield return null;
		yield break;
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x0002B360 File Offset: 0x00029560
	[Command(requiresAuthority = false)]
	public void CmdClearTrash()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void TrashSpawn::CmdClearTrash()", -321223739, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x060006CC RID: 1740 RVA: 0x0002B390 File Offset: 0x00029590
	// (set) Token: 0x060006CD RID: 1741 RVA: 0x0002B3A3 File Offset: 0x000295A3
	public int NetworktrashID
	{
		get
		{
			return this.trashID;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.trashID, 1UL, null);
		}
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x0002B3BD File Offset: 0x000295BD
	protected void UserCode_CmdClearTrash()
	{
		AchievementsManager.Instance.CmdAddAchievementPoint(5, 1);
		GameData.Instance.PlayBroomSound();
		NetworkServer.Destroy(base.gameObject);
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x0002B3E0 File Offset: 0x000295E0
	protected static void InvokeUserCode_CmdClearTrash(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdClearTrash called on client.");
			return;
		}
		((TrashSpawn)obj).UserCode_CmdClearTrash();
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x0002B403 File Offset: 0x00029603
	static TrashSpawn()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TrashSpawn), "System.Void TrashSpawn::CmdClearTrash()", new RemoteCallDelegate(TrashSpawn.InvokeUserCode_CmdClearTrash), false);
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x0002B428 File Offset: 0x00029628
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.trashID);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.trashID);
		}
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0002B480 File Offset: 0x00029680
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.trashID, null, reader.ReadInt());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.trashID, null, reader.ReadInt());
		}
	}

	// Token: 0x04000566 RID: 1382
	[SyncVar]
	public int trashID;

	// Token: 0x04000567 RID: 1383
	public GameObject[] trashPrefabs;
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using StarterAssets;
using TMPro;
using UnityEngine;

// Token: 0x020000CE RID: 206
public class TutorialManager : NetworkBehaviour
{
	// Token: 0x060006D9 RID: 1753 RVA: 0x0002B5C4 File Offset: 0x000297C4
	private void Update()
	{
		if (!GameData.Instance)
		{
			return;
		}
		int gameDay = GameData.Instance.gameDay;
		if (this.onHold)
		{
			return;
		}
		if (GameData.Instance.isSupermarketOpen && this.state < 22 && this.createdUIOBJ)
		{
			this.QuitTutorial();
		}
		if (gameDay != 1)
		{
			if (gameDay != 2)
			{
				return;
			}
			base.enabled = false;
		}
		else
		{
			switch (this.state)
			{
			case 0:
				base.StartCoroutine(this.TimeCoroutine(10f, 1, "tutorial0"));
				return;
			case 1:
				this.JustCreateItem("tutorial1");
				this.state = 2;
				return;
			case 2:
				if (this.builderOBJ.activeSelf)
				{
					this.state = 3;
					return;
				}
				break;
			case 3:
				this.JustCreateItem("tutorial2");
				this.state = 4;
				return;
			case 4:
				if ((this.shelvesOBJ.transform.childCount > 1 && this.checkoutOBJ.transform.childCount > 0 && this.storageOBJ.transform.childCount > 0) || this.auxiliarBool)
				{
					if (base.isServer)
					{
						this.NetworkauxiliarBool = true;
					}
					this.state = 5;
					return;
				}
				break;
			case 5:
				this.JustCreateItem("tutorial3");
				this.state = 6;
				return;
			case 6:
				if (ProductListing.Instance.unlockedProductTiers[0])
				{
					this.state = 7;
					return;
				}
				break;
			case 7:
				this.JustCreateItem("tutorial4");
				this.state = 8;
				return;
			case 8:
				if (this.UIProductsOBJ.activeSelf)
				{
					this.state = 9;
					return;
				}
				break;
			case 9:
				this.JustCreateItem("tutorial5");
				this.state = 10;
				return;
			case 10:
				if (this.shoppingListOBJ.transform.childCount > 0)
				{
					this.state = 11;
					return;
				}
				break;
			case 11:
				this.JustCreateItem("tutorial6");
				this.state = 12;
				return;
			case 12:
				if (this.boxOBJ.transform.childCount > 0 || this.auxiliarBool2)
				{
					if (base.isServer)
					{
						this.NetworkauxiliarBool2 = true;
					}
					this.state = 13;
					return;
				}
				break;
			case 13:
				this.JustCreateItem("tutorial7");
				this.state = 14;
				return;
			case 14:
				if (FirstPersonController.Instance && FirstPersonController.Instance.GetComponent<PlayerNetwork>().equippedItem == 1)
				{
					this.state = 15;
					return;
				}
				break;
			case 15:
				this.JustCreateItem("tutorial8");
				this.state = 16;
				return;
			case 16:
				if (this.CheckShelvesProduct())
				{
					this.state = 17;
					return;
				}
				break;
			case 17:
				this.JustCreateItem("tutorial9");
				this.state = 18;
				return;
			case 18:
				if (FirstPersonController.Instance && FirstPersonController.Instance.GetComponent<PlayerNetwork>().equippedItem == 2)
				{
					this.state = 19;
					return;
				}
				break;
			case 19:
				this.JustCreateItem("tutorial10");
				this.state = 20;
				return;
			case 20:
				if (this.HavePricesChanged())
				{
					this.state = 21;
					return;
				}
				break;
			case 21:
				this.JustCreateItem("tutorial11");
				this.state = 22;
				return;
			case 22:
				if (GameData.Instance.isSupermarketOpen)
				{
					base.StartCoroutine(this.LastTutorial(24));
					this.state = 23;
					return;
				}
				break;
			case 23:
			case 25:
				break;
			case 24:
				base.enabled = false;
				return;
			default:
				return;
			}
		}
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x0002B938 File Offset: 0x00029B38
	private bool HavePricesChanged()
	{
		int num = 0;
		for (int i = 0; i < 50; i++)
		{
			float basePricePerUnit = ProductListing.Instance.productPrefabs[i].GetComponent<Data_Product>().basePricePerUnit;
			float num2 = ProductListing.Instance.productPlayerPricing[i];
			if (basePricePerUnit != num2)
			{
				num++;
			}
		}
		return num >= 6;
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x0002B985 File Offset: 0x00029B85
	private void QuitTutorial()
	{
		if (this.createdUIOBJ)
		{
			Object.Destroy(this.createdUIOBJ);
		}
		base.enabled = false;
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0002B9A8 File Offset: 0x00029BA8
	private bool CheckShelvesProduct()
	{
		int num = 0;
		if (this.shelvesOBJ.transform.childCount > 0)
		{
			foreach (object obj in this.shelvesOBJ.transform)
			{
				int[] productInfoArray = ((Transform)obj).GetComponent<Data_Container>().productInfoArray;
				int num2 = productInfoArray.Length / 2;
				for (int i = 0; i < num2; i++)
				{
					if (productInfoArray[i * 2] >= 0)
					{
						num++;
					}
				}
			}
		}
		return num >= 6;
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x0002BA4C File Offset: 0x00029C4C
	private IEnumerator LastTutorial(int targetState)
	{
		yield return new WaitForSeconds(5f);
		CanvasGroup cGroup = this.createdUIOBJ.GetComponent<CanvasGroup>();
		float elapsedTime = 0f;
		float waitTime = 4f;
		while (elapsedTime < waitTime)
		{
			float alpha = Mathf.Lerp(1f, 0f, elapsedTime / waitTime);
			cGroup.alpha = alpha;
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		Object.Destroy(this.createdUIOBJ);
		yield return null;
		yield break;
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x0002BA5B File Offset: 0x00029C5B
	private IEnumerator TimeCoroutine(float waitTime, int targetState, string tutorialHash)
	{
		this.onHold = true;
		if (this.createdUIOBJ)
		{
			Object.Destroy(this.createdUIOBJ);
		}
		this.createdUIOBJ = Object.Instantiate<GameObject>(this.UITutorialPrefabOBJ, this.tutorialParentOBJ.transform);
		this.createdUIOBJ.GetComponent<RectTransform>().anchoredPosition = new Vector2(200f, 130f);
		this.createdUIOBJ.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString(tutorialHash);
		yield return new WaitForSeconds(waitTime);
		Object.Destroy(this.createdUIOBJ);
		yield return new WaitForSeconds(1f);
		this.state = targetState;
		yield return null;
		this.onHold = false;
		yield break;
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x0002BA80 File Offset: 0x00029C80
	private void JustCreateItem(string tutorialHash)
	{
		if (this.createdUIOBJ)
		{
			Object.Destroy(this.createdUIOBJ);
		}
		this.createdUIOBJ = Object.Instantiate<GameObject>(this.UITutorialPrefabOBJ, this.tutorialParentOBJ.transform);
		this.createdUIOBJ.GetComponent<RectTransform>().anchoredPosition = new Vector2(200f, 130f);
		this.createdUIOBJ.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = LocalizationManager.instance.GetLocalizationString(tutorialHash);
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x060006E2 RID: 1762 RVA: 0x0002BB08 File Offset: 0x00029D08
	// (set) Token: 0x060006E3 RID: 1763 RVA: 0x0002BB1B File Offset: 0x00029D1B
	public bool NetworkauxiliarBool
	{
		get
		{
			return this.auxiliarBool;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.auxiliarBool, 1UL, null);
		}
	}

	// Token: 0x170000CA RID: 202
	// (get) Token: 0x060006E4 RID: 1764 RVA: 0x0002BB38 File Offset: 0x00029D38
	// (set) Token: 0x060006E5 RID: 1765 RVA: 0x0002BB4B File Offset: 0x00029D4B
	public bool NetworkauxiliarBool2
	{
		get
		{
			return this.auxiliarBool2;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool>(value, ref this.auxiliarBool2, 2UL, null);
		}
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x0002BB68 File Offset: 0x00029D68
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(this.auxiliarBool);
			writer.WriteBool(this.auxiliarBool2);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteBool(this.auxiliarBool);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteBool(this.auxiliarBool2);
		}
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x0002BBF0 File Offset: 0x00029DF0
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.auxiliarBool, null, reader.ReadBool());
			base.GeneratedSyncVarDeserialize<bool>(ref this.auxiliarBool2, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.auxiliarBool, null, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool>(ref this.auxiliarBool2, null, reader.ReadBool());
		}
	}

	// Token: 0x0400056B RID: 1387
	[SyncVar]
	public bool auxiliarBool;

	// Token: 0x0400056C RID: 1388
	[SyncVar]
	public bool auxiliarBool2;

	// Token: 0x0400056D RID: 1389
	public GameObject UITutorialPrefabOBJ;

	// Token: 0x0400056E RID: 1390
	public GameObject tutorialParentOBJ;

	// Token: 0x0400056F RID: 1391
	[Space(10f)]
	public GameObject shelvesOBJ;

	// Token: 0x04000570 RID: 1392
	public GameObject checkoutOBJ;

	// Token: 0x04000571 RID: 1393
	public GameObject storageOBJ;

	// Token: 0x04000572 RID: 1394
	[Space(10f)]
	public GameObject builderOBJ;

	// Token: 0x04000573 RID: 1395
	public GameObject UIProductsOBJ;

	// Token: 0x04000574 RID: 1396
	public GameObject shoppingListOBJ;

	// Token: 0x04000575 RID: 1397
	public GameObject boxOBJ;

	// Token: 0x04000576 RID: 1398
	private bool onHold;

	// Token: 0x04000577 RID: 1399
	private int state;

	// Token: 0x04000578 RID: 1400
	private GameObject createdUIOBJ;
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Token: 0x020000DE RID: 222
[CompilerGenerated]
[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("Unity.MonoScriptGenerator.MonoScriptInfoGenerator", null)]
internal class UnitySourceGeneratedAssemblyMonoScriptTypes_v1
{
	// Token: 0x0600074A RID: 1866 RVA: 0x0002DB24 File Offset: 0x0002BD24
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static UnitySourceGeneratedAssemblyMonoScriptTypes_v1.MonoScriptData Get()
	{
		UnitySourceGeneratedAssemblyMonoScriptTypes_v1.MonoScriptData result = default(UnitySourceGeneratedAssemblyMonoScriptTypes_v1.MonoScriptData);
		result.FilePathsData = new byte[]
		{
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			68,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			97,
			109,
			101,
			114,
			97,
			92,
			67,
			97,
			109,
			77,
			111,
			117,
			115,
			101,
			79,
			114,
			98,
			105,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			72,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			97,
			109,
			101,
			114,
			97,
			92,
			77,
			111,
			117,
			115,
			101,
			76,
			111,
			111,
			107,
			65,
			100,
			118,
			97,
			110,
			99,
			101,
			100,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			66,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			80,
			97,
			116,
			104,
			115,
			92,
			65,
			117,
			100,
			105,
			101,
			110,
			99,
			101,
			80,
			97,
			116,
			104,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			62,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			80,
			97,
			116,
			104,
			115,
			92,
			77,
			111,
			118,
			101,
			80,
			97,
			116,
			104,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			61,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			80,
			97,
			116,
			104,
			115,
			92,
			78,
			101,
			119,
			80,
			97,
			116,
			104,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			68,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			80,
			97,
			116,
			104,
			115,
			92,
			80,
			101,
			111,
			112,
			108,
			101,
			87,
			97,
			108,
			107,
			80,
			97,
			116,
			104,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			62,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			80,
			97,
			116,
			104,
			115,
			92,
			87,
			97,
			108,
			107,
			80,
			97,
			116,
			104,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			60,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			82,
			111,
			116,
			97,
			116,
			101,
			111,
			98,
			106,
			101,
			99,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			83,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			116,
			114,
			101,
			101,
			116,
			32,
			65,
			110,
			100,
			32,
			67,
			111,
			110,
			99,
			101,
			114,
			116,
			92,
			80,
			101,
			111,
			112,
			108,
			101,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			108,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			90,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			116,
			114,
			101,
			101,
			116,
			32,
			65,
			110,
			100,
			32,
			67,
			111,
			110,
			99,
			101,
			114,
			116,
			92,
			80,
			111,
			112,
			117,
			108,
			97,
			116,
			105,
			111,
			110,
			83,
			121,
			115,
			116,
			101,
			109,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			88,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			116,
			114,
			101,
			101,
			116,
			32,
			65,
			110,
			100,
			32,
			67,
			111,
			110,
			99,
			101,
			114,
			116,
			92,
			83,
			116,
			97,
			110,
			100,
			105,
			110,
			103,
			80,
			101,
			111,
			112,
			108,
			101,
			67,
			111,
			110,
			99,
			101,
			114,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			87,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			116,
			114,
			101,
			101,
			116,
			32,
			65,
			110,
			100,
			32,
			67,
			111,
			110,
			99,
			101,
			114,
			116,
			92,
			83,
			116,
			97,
			110,
			100,
			105,
			110,
			103,
			80,
			101,
			111,
			112,
			108,
			101,
			83,
			116,
			114,
			101,
			101,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			116,
			105,
			108,
			115,
			92,
			67,
			111,
			109,
			109,
			111,
			110,
			85,
			116,
			105,
			108,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			105,
			122,
			101,
			110,
			115,
			32,
			80,
			82,
			79,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			116,
			105,
			108,
			115,
			92,
			83,
			104,
			102,
			117,
			102,
			102,
			108,
			101,
			69,
			120,
			116,
			101,
			110,
			115,
			105,
			111,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			55,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			121,
			66,
			85,
			114,
			98,
			97,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			66,
			105,
			108,
			108,
			98,
			111,
			97,
			114,
			100,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			54,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			121,
			66,
			85,
			114,
			98,
			97,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			97,
			121,
			78,
			105,
			103,
			104,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			68,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			67,
			105,
			116,
			121,
			66,
			85,
			114,
			98,
			97,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			105,
			109,
			112,
			108,
			101,
			67,
			97,
			109,
			101,
			114,
			97,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			108,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			103,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			92,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			92,
			68,
			101,
			109,
			111,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			80,
			108,
			97,
			121,
			101,
			114,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			108,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			88,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			92,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			67,
			108,
			105,
			101,
			110,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			4,
			0,
			0,
			0,
			94,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			92,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			67,
			111,
			109,
			109,
			115,
			78,
			101,
			116,
			119,
			111,
			114,
			107,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			88,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			92,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			80,
			108,
			97,
			121,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			88,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			92,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			92,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			83,
			101,
			114,
			118,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			78,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			92,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			92,
			79,
			102,
			102,
			108,
			105,
			110,
			101,
			92,
			79,
			102,
			102,
			108,
			105,
			110,
			101,
			67,
			111,
			109,
			109,
			115,
			78,
			101,
			116,
			119,
			111,
			114,
			107,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			63,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			116,
			70,
			120,
			68,
			101,
			109,
			111,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			77,
			97,
			110,
			117,
			97,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			105,
			111,
			110,
			68,
			101,
			109,
			111,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			81,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			112,
			104,
			101,
			114,
			101,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			118,
			101,
			110,
			116,
			69,
			120,
			97,
			109,
			112,
			108,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			82,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			112,
			104,
			101,
			114,
			101,
			83,
			101,
			108,
			101,
			99,
			116,
			105,
			111,
			110,
			69,
			118,
			101,
			110,
			116,
			115,
			69,
			120,
			97,
			109,
			112,
			108,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			4,
			0,
			0,
			0,
			85,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			80,
			105,
			112,
			101,
			108,
			105,
			110,
			101,
			115,
			92,
			85,
			82,
			80,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			82,
			101,
			110,
			100,
			101,
			114,
			80,
			97,
			115,
			115,
			70,
			101,
			97,
			116,
			117,
			114,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			72,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			79,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			87,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			79,
			99,
			99,
			108,
			117,
			100,
			101,
			114,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			114,
			111,
			102,
			105,
			108,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			84,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			83,
			101,
			101,
			84,
			104,
			114,
			111,
			117,
			103,
			104,
			79,
			99,
			99,
			108,
			117,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			84,
			114,
			105,
			103,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			67,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			73,
			110,
			112,
			117,
			116,
			80,
			114,
			111,
			120,
			121,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			61,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			77,
			105,
			115,
			99,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			82,
			101,
			110,
			100,
			101,
			114,
			105,
			110,
			103,
			85,
			116,
			105,
			108,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			69,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			104,
			97,
			100,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			64,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			92,
			82,
			117,
			110,
			116,
			105,
			109,
			101,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			86,
			82,
			67,
			104,
			101,
			99,
			107,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			88,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			101,
			73,
			99,
			111,
			110,
			115,
			92,
			69,
			120,
			97,
			109,
			112,
			108,
			101,
			115,
			92,
			65,
			100,
			100,
			105,
			116,
			105,
			111,
			110,
			110,
			97,
			108,
			81,
			117,
			101,
			117,
			101,
			80,
			114,
			111,
			118,
			105,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			101,
			73,
			99,
			111,
			110,
			115,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			77,
			97,
			115,
			107,
			69,
			102,
			102,
			101,
			99,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			101,
			73,
			99,
			111,
			110,
			115,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			81,
			117,
			101,
			117,
			101,
			80,
			114,
			111,
			118,
			105,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			72,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			108,
			111,
			98,
			97,
			108,
			92,
			69,
			120,
			101,
			99,
			117,
			116,
			101,
			73,
			110,
			69,
			100,
			105,
			116,
			111,
			114,
			65,
			116,
			116,
			114,
			105,
			98,
			117,
			116,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			67,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			108,
			111,
			98,
			97,
			108,
			92,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			69,
			120,
			116,
			101,
			110,
			115,
			105,
			111,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			60,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			108,
			111,
			98,
			97,
			108,
			92,
			74,
			52,
			70,
			66,
			101,
			104,
			97,
			118,
			105,
			111,
			117,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			57,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			108,
			111,
			98,
			97,
			108,
			92,
			83,
			105,
			110,
			103,
			108,
			101,
			116,
			111,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			64,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			108,
			111,
			98,
			97,
			108,
			92,
			83,
			105,
			110,
			103,
			108,
			101,
			116,
			111,
			110,
			80,
			101,
			114,
			115,
			105,
			115,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			53,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			71,
			101,
			110,
			101,
			114,
			97,
			116,
			111,
			114,
			92,
			71,
			108,
			111,
			98,
			97,
			108,
			92,
			84,
			111,
			111,
			108,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			63,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			77,
			111,
			100,
			101,
			114,
			110,
			83,
			117,
			112,
			101,
			114,
			109,
			97,
			114,
			107,
			101,
			116,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			70,
			114,
			101,
			101,
			67,
			97,
			109,
			101,
			114,
			97,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			66,
			117,
			116,
			116,
			111,
			110,
			92,
			66,
			117,
			116,
			116,
			111,
			110,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			60,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			104,
			97,
			114,
			116,
			115,
			92,
			80,
			105,
			101,
			67,
			104,
			97,
			114,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			3,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			32,
			77,
			101,
			110,
			117,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			82,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			32,
			77,
			101,
			110,
			117,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			77,
			111,
			98,
			105,
			108,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			32,
			77,
			101,
			110,
			117,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			32,
			77,
			101,
			110,
			117,
			92,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			83,
			117,
			98,
			77,
			101,
			110,
			117,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			67,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			67,
			111,
			114,
			101,
			92,
			77,
			85,
			73,
			80,
			73,
			110,
			116,
			101,
			114,
			110,
			97,
			108,
			84,
			111,
			111,
			108,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			68,
			101,
			109,
			111,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			83,
			119,
			97,
			121,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			68,
			101,
			109,
			111,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			83,
			119,
			97,
			121,
			80,
			97,
			114,
			101,
			110,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			64,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			68,
			101,
			109,
			111,
			76,
			105,
			115,
			116,
			83,
			104,
			97,
			100,
			111,
			119,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			68,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			73,
			110,
			112,
			117,
			116,
			83,
			121,
			115,
			116,
			101,
			109,
			67,
			104,
			101,
			99,
			107,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			59,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			101,
			109,
			111,
			92,
			76,
			97,
			117,
			110,
			99,
			104,
			85,
			82,
			76,
			46,
			99,
			115,
			0,
			0,
			0,
			4,
			0,
			0,
			0,
			68,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			92,
			67,
			117,
			115,
			116,
			111,
			109,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			3,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			92,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			77,
			117,
			108,
			116,
			105,
			83,
			101,
			108,
			101,
			99,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			4,
			0,
			0,
			0,
			83,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			72,
			111,
			114,
			105,
			122,
			111,
			110,
			116,
			97,
			108,
			32,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			92,
			72,
			111,
			114,
			105,
			122,
			111,
			110,
			116,
			97,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			69,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			92,
			65,
			110,
			105,
			109,
			97,
			116,
			101,
			100,
			73,
			99,
			111,
			110,
			72,
			97,
			110,
			100,
			108,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			61,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			92,
			73,
			99,
			111,
			110,
			76,
			105,
			98,
			114,
			97,
			114,
			121,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			61,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			73,
			99,
			111,
			110,
			92,
			73,
			99,
			111,
			110,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			73,
			110,
			112,
			117,
			116,
			32,
			70,
			105,
			101,
			108,
			100,
			92,
			67,
			117,
			115,
			116,
			111,
			109,
			73,
			110,
			112,
			117,
			116,
			70,
			105,
			101,
			108,
			100,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			72,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			76,
			97,
			121,
			111,
			117,
			116,
			32,
			71,
			114,
			111,
			117,
			112,
			92,
			76,
			97,
			121,
			111,
			117,
			116,
			71,
			114,
			111,
			117,
			112,
			70,
			105,
			120,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			75,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			76,
			97,
			121,
			111,
			117,
			116,
			32,
			71,
			114,
			111,
			117,
			112,
			92,
			82,
			97,
			100,
			105,
			97,
			108,
			76,
			97,
			121,
			111,
			117,
			116,
			71,
			114,
			111,
			117,
			112,
			46,
			99,
			115,
			0,
			0,
			0,
			3,
			0,
			0,
			0,
			62,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			92,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			66,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			92,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			73,
			116,
			101,
			109,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			92,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			82,
			111,
			119,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			77,
			111,
			100,
			97,
			108,
			32,
			87,
			105,
			110,
			100,
			111,
			119,
			92,
			77,
			111,
			100,
			97,
			108,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			77,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			92,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			78,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			92,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			83,
			116,
			97,
			99,
			107,
			105,
			110,
			103,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			66,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			32,
			66,
			97,
			114,
			92,
			80,
			66,
			70,
			105,
			108,
			108,
			101,
			100,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			69,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			32,
			66,
			97,
			114,
			92,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			61,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			82,
			101,
			110,
			100,
			101,
			114,
			105,
			110,
			103,
			92,
			82,
			105,
			112,
			112,
			108,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			82,
			101,
			110,
			100,
			101,
			114,
			105,
			110,
			103,
			92,
			85,
			73,
			71,
			114,
			97,
			100,
			105,
			101,
			110,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			64,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			92,
			82,
			97,
			100,
			105,
			97,
			108,
			83,
			108,
			105,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			66,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			92,
			82,
			97,
			110,
			103,
			101,
			77,
			97,
			120,
			83,
			108,
			105,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			66,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			92,
			82,
			97,
			110,
			103,
			101,
			77,
			105,
			110,
			83,
			108,
			105,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			63,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			92,
			82,
			97,
			110,
			103,
			101,
			83,
			108,
			105,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			63,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			73,
			110,
			112,
			117,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			92,
			83,
			108,
			105,
			100,
			101,
			114,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			83,
			119,
			105,
			116,
			99,
			104,
			92,
			83,
			119,
			105,
			116,
			99,
			104,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			64,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			84,
			111,
			103,
			103,
			108,
			101,
			92,
			67,
			117,
			115,
			116,
			111,
			109,
			84,
			111,
			103,
			103,
			108,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			84,
			111,
			111,
			108,
			115,
			92,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			84,
			97,
			98,
			98,
			105,
			110,
			103,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			67,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			92,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			67,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			92,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			77,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			65,
			110,
			105,
			109,
			97,
			116,
			101,
			100,
			73,
			99,
			111,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			66,
			117,
			116,
			116,
			111,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			67,
			117,
			115,
			116,
			111,
			109,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			77,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			73,
			116,
			101,
			109,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			74,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			72,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			75,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			73,
			110,
			112,
			117,
			116,
			70,
			105,
			101,
			108,
			100,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			77,
			111,
			100,
			97,
			108,
			87,
			105,
			110,
			100,
			111,
			119,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			77,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			73,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			80,
			105,
			101,
			67,
			104,
			97,
			114,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			76,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			80,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			76,
			111,
			111,
			112,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			74,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			83,
			99,
			114,
			111,
			108,
			108,
			98,
			97,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			83,
			108,
			105,
			100,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			83,
			119,
			105,
			116,
			99,
			104,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			84,
			111,
			103,
			103,
			108,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			72,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			78,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			85,
			73,
			32,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			92,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			87,
			105,
			110,
			100,
			111,
			119,
			92,
			87,
			105,
			110,
			100,
			111,
			119,
			68,
			114,
			97,
			103,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			3,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			87,
			105,
			110,
			100,
			111,
			119,
			92,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			71,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			69,
			120,
			116,
			101,
			114,
			110,
			97,
			108,
			95,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			85,
			73,
			95,
			77,
			111,
			100,
			101,
			114,
			110,
			92,
			83,
			99,
			114,
			105,
			112,
			116,
			115,
			92,
			87,
			105,
			110,
			100,
			111,
			119,
			92,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			66,
			117,
			116,
			116,
			111,
			110,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			62,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			65,
			100,
			100,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			67,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			65,
			100,
			100,
			82,
			97,
			110,
			103,
			101,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			64,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			108,
			101,
			97,
			114,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			74,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			108,
			101,
			97,
			114,
			65,
			108,
			108,
			80,
			114,
			111,
			120,
			105,
			101,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			110,
			99,
			97,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			67,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			110,
			116,
			97,
			105,
			110,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			112,
			121,
			84,
			111,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			64,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			117,
			110,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			65,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			69,
			120,
			105,
			115,
			116,
			115,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			62,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			66,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			78,
			101,
			120,
			116,
			46,
			99,
			115,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			70,
			92,
			65,
			115,
			115,
			101,
			116,
			115,
			92,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			32,
			65,
			114,
			114,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			92,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			92,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			80,
			114,
			101,
			118,
			105,
			111,
			117,
			115,
			46,
			99,
			115,
			"Not showing all elements because this array is too big (120159 elements)"
		};
		result.TypesData = new byte[]
		{
			0,
			0,
			0,
			0,
			14,
			124,
			67,
			97,
			109,
			77,
			111,
			117,
			115,
			101,
			79,
			114,
			98,
			105,
			116,
			0,
			0,
			0,
			0,
			18,
			124,
			77,
			111,
			117,
			115,
			101,
			76,
			111,
			111,
			107,
			65,
			100,
			118,
			97,
			110,
			99,
			101,
			100,
			0,
			0,
			0,
			0,
			13,
			124,
			65,
			117,
			100,
			105,
			101,
			110,
			99,
			101,
			80,
			97,
			116,
			104,
			0,
			0,
			0,
			0,
			9,
			124,
			77,
			111,
			118,
			101,
			80,
			97,
			116,
			104,
			0,
			0,
			0,
			0,
			8,
			124,
			78,
			101,
			119,
			80,
			97,
			116,
			104,
			0,
			0,
			0,
			0,
			15,
			124,
			80,
			101,
			111,
			112,
			108,
			101,
			87,
			97,
			108,
			107,
			80,
			97,
			116,
			104,
			0,
			0,
			0,
			0,
			9,
			124,
			87,
			97,
			108,
			107,
			80,
			97,
			116,
			104,
			0,
			0,
			0,
			0,
			13,
			124,
			82,
			111,
			116,
			97,
			116,
			101,
			111,
			98,
			106,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			17,
			124,
			80,
			101,
			111,
			112,
			108,
			101,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			108,
			101,
			114,
			0,
			0,
			0,
			0,
			24,
			124,
			80,
			111,
			112,
			117,
			108,
			97,
			116,
			105,
			111,
			110,
			83,
			121,
			115,
			116,
			101,
			109,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			22,
			124,
			83,
			116,
			97,
			110,
			100,
			105,
			110,
			103,
			80,
			101,
			111,
			112,
			108,
			101,
			67,
			111,
			110,
			99,
			101,
			114,
			116,
			0,
			0,
			0,
			0,
			21,
			124,
			83,
			116,
			97,
			110,
			100,
			105,
			110,
			103,
			80,
			101,
			111,
			112,
			108,
			101,
			83,
			116,
			114,
			101,
			101,
			116,
			0,
			0,
			0,
			0,
			12,
			124,
			67,
			111,
			109,
			109,
			111,
			110,
			85,
			116,
			105,
			108,
			115,
			0,
			0,
			0,
			0,
			18,
			124,
			83,
			104,
			102,
			117,
			102,
			102,
			108,
			101,
			69,
			120,
			116,
			101,
			110,
			115,
			105,
			111,
			110,
			0,
			0,
			0,
			0,
			10,
			124,
			66,
			105,
			108,
			108,
			98,
			111,
			97,
			114,
			100,
			0,
			0,
			0,
			0,
			20,
			66,
			105,
			108,
			108,
			98,
			111,
			97,
			114,
			100,
			124,
			65,
			100,
			118,
			101,
			114,
			116,
			76,
			105,
			115,
			116,
			0,
			0,
			0,
			0,
			9,
			124,
			68,
			97,
			121,
			78,
			105,
			103,
			104,
			116,
			0,
			0,
			0,
			0,
			44,
			85,
			110,
			105,
			116,
			121,
			84,
			101,
			109,
			112,
			108,
			97,
			116,
			101,
			80,
			114,
			111,
			106,
			101,
			99,
			116,
			115,
			124,
			83,
			105,
			109,
			112,
			108,
			101,
			67,
			97,
			109,
			101,
			114,
			97,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			108,
			101,
			114,
			0,
			0,
			0,
			0,
			56,
			85,
			110,
			105,
			116,
			121,
			84,
			101,
			109,
			112,
			108,
			97,
			116,
			101,
			80,
			114,
			111,
			106,
			101,
			99,
			116,
			115,
			46,
			83,
			105,
			109,
			112,
			108,
			101,
			67,
			97,
			109,
			101,
			114,
			97,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			108,
			101,
			114,
			124,
			67,
			97,
			109,
			101,
			114,
			97,
			83,
			116,
			97,
			116,
			101,
			0,
			0,
			0,
			0,
			76,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			46,
			68,
			101,
			109,
			111,
			124,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			80,
			108,
			97,
			121,
			101,
			114,
			67,
			111,
			110,
			116,
			114,
			111,
			108,
			108,
			101,
			114,
			0,
			0,
			0,
			0,
			61,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			124,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			67,
			108,
			105,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			67,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			124,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			67,
			111,
			109,
			109,
			115,
			78,
			101,
			116,
			119,
			111,
			114,
			107,
			0,
			0,
			0,
			0,
			50,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			124,
			77,
			105,
			114,
			114,
			111,
			114,
			67,
			111,
			110,
			110,
			0,
			0,
			0,
			0,
			74,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			124,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			78,
			101,
			116,
			119,
			111,
			114,
			107,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			69,
			120,
			116,
			101,
			110,
			115,
			105,
			111,
			110,
			115,
			0,
			0,
			0,
			0,
			64,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			124,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			78,
			101,
			116,
			119,
			111,
			114,
			107,
			77,
			101,
			115,
			115,
			97,
			103,
			101,
			0,
			0,
			0,
			0,
			61,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			124,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			80,
			108,
			97,
			121,
			101,
			114,
			0,
			0,
			0,
			0,
			61,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			124,
			77,
			105,
			114,
			114,
			111,
			114,
			73,
			103,
			110,
			111,
			114,
			97,
			110,
			99,
			101,
			83,
			101,
			114,
			118,
			101,
			114,
			0,
			0,
			0,
			0,
			51,
			68,
			105,
			115,
			115,
			111,
			110,
			97,
			110,
			99,
			101,
			46,
			73,
			110,
			116,
			101,
			103,
			114,
			97,
			116,
			105,
			111,
			110,
			115,
			46,
			79,
			102,
			102,
			108,
			105,
			110,
			101,
			124,
			79,
			102,
			102,
			108,
			105,
			110,
			101,
			67,
			111,
			109,
			109,
			115,
			78,
			101,
			116,
			119,
			111,
			114,
			107,
			0,
			0,
			0,
			0,
			29,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			68,
			101,
			109,
			111,
			115,
			124,
			72,
			105,
			116,
			70,
			120,
			68,
			101,
			109,
			111,
			0,
			0,
			0,
			0,
			39,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			68,
			101,
			109,
			111,
			115,
			124,
			77,
			97,
			110,
			117,
			97,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			105,
			111,
			110,
			68,
			101,
			109,
			111,
			0,
			0,
			0,
			0,
			47,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			68,
			101,
			109,
			111,
			115,
			124,
			83,
			112,
			104,
			101,
			114,
			101,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			118,
			101,
			110,
			116,
			69,
			120,
			97,
			109,
			112,
			108,
			101,
			0,
			0,
			0,
			0,
			48,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			68,
			101,
			109,
			111,
			115,
			124,
			83,
			112,
			104,
			101,
			114,
			101,
			83,
			101,
			108,
			101,
			99,
			116,
			105,
			111,
			110,
			69,
			118,
			101,
			110,
			116,
			115,
			69,
			120,
			97,
			109,
			112,
			108,
			101,
			0,
			0,
			0,
			0,
			44,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			82,
			101,
			110,
			100,
			101,
			114,
			80,
			97,
			115,
			115,
			70,
			101,
			97,
			116,
			117,
			114,
			101,
			0,
			0,
			0,
			0,
			58,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			82,
			101,
			110,
			100,
			101,
			114,
			80,
			97,
			115,
			115,
			70,
			101,
			97,
			116,
			117,
			114,
			101,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			97,
			115,
			115,
			0,
			0,
			0,
			0,
			67,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			82,
			101,
			110,
			100,
			101,
			114,
			80,
			97,
			115,
			115,
			70,
			101,
			97,
			116,
			117,
			114,
			101,
			43,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			97,
			115,
			115,
			124,
			80,
			97,
			115,
			115,
			68,
			97,
			116,
			97,
			0,
			0,
			0,
			0,
			75,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			82,
			101,
			110,
			100,
			101,
			114,
			80,
			97,
			115,
			115,
			70,
			101,
			97,
			116,
			117,
			114,
			101,
			43,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			97,
			115,
			115,
			124,
			68,
			105,
			115,
			116,
			97,
			110,
			99,
			101,
			67,
			111,
			109,
			112,
			97,
			114,
			101,
			114,
			0,
			0,
			0,
			0,
			36,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			81,
			117,
			97,
			108,
			105,
			116,
			121,
			76,
			101,
			118,
			101,
			108,
			69,
			120,
			116,
			101,
			110,
			115,
			105,
			111,
			110,
			115,
			0,
			0,
			0,
			0,
			26,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			71,
			108,
			111,
			119,
			80,
			97,
			115,
			115,
			68,
			97,
			116,
			97,
			1,
			0,
			0,
			0,
			29,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			44,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			124,
			77,
			111,
			100,
			101,
			108,
			77,
			97,
			116,
			101,
			114,
			105,
			97,
			108,
			115,
			0,
			0,
			0,
			0,
			52,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			46,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			124,
			80,
			101,
			114,
			67,
			97,
			109,
			101,
			114,
			97,
			79,
			99,
			99,
			108,
			117,
			115,
			105,
			111,
			110,
			68,
			97,
			116,
			97,
			1,
			0,
			0,
			0,
			29,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			1,
			0,
			0,
			0,
			29,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			69,
			102,
			102,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			30,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			30,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			114,
			111,
			102,
			105,
			108,
			101,
			0,
			0,
			0,
			0,
			22,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			77,
			101,
			115,
			104,
			68,
			97,
			116,
			97,
			0,
			0,
			0,
			0,
			41,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			83,
			101,
			101,
			84,
			104,
			114,
			111,
			117,
			103,
			104,
			79,
			99,
			99,
			108,
			117,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			30,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			84,
			114,
			105,
			103,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			24,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			73,
			110,
			112,
			117,
			116,
			80,
			114,
			111,
			120,
			121,
			0,
			0,
			0,
			0,
			18,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			77,
			105,
			115,
			99,
			0,
			0,
			0,
			0,
			28,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			82,
			101,
			110,
			100,
			101,
			114,
			105,
			110,
			103,
			85,
			116,
			105,
			108,
			115,
			0,
			0,
			0,
			0,
			26,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			83,
			104,
			97,
			100,
			101,
			114,
			80,
			97,
			114,
			97,
			109,
			115,
			0,
			0,
			0,
			0,
			21,
			72,
			105,
			103,
			104,
			108,
			105,
			103,
			104,
			116,
			80,
			108,
			117,
			115,
			124,
			86,
			82,
			67,
			104,
			101,
			99,
			107,
			0,
			0,
			0,
			0,
			25,
			124,
			65,
			100,
			100,
			105,
			116,
			105,
			111,
			110,
			110,
			97,
			108,
			81,
			117,
			101,
			117,
			101,
			80,
			114,
			111,
			118,
			105,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			11,
			124,
			77,
			97,
			115,
			107,
			69,
			102,
			102,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			17,
			74,
			52,
			70,
			124,
			81,
			117,
			101,
			117,
			101,
			80,
			114,
			111,
			118,
			105,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			30,
			124,
			69,
			120,
			112,
			111,
			115,
			101,
			77,
			101,
			116,
			104,
			111,
			100,
			73,
			110,
			69,
			100,
			105,
			116,
			111,
			114,
			65,
			116,
			116,
			114,
			105,
			98,
			117,
			116,
			101,
			0,
			0,
			0,
			0,
			24,
			74,
			52,
			70,
			124,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			69,
			120,
			116,
			101,
			110,
			115,
			105,
			111,
			110,
			115,
			0,
			0,
			0,
			0,
			16,
			74,
			52,
			70,
			124,
			74,
			52,
			70,
			66,
			101,
			104,
			97,
			118,
			105,
			111,
			117,
			114,
			0,
			0,
			0,
			0,
			13,
			74,
			52,
			70,
			124,
			83,
			105,
			110,
			103,
			108,
			101,
			116,
			111,
			110,
			0,
			0,
			0,
			0,
			20,
			74,
			52,
			70,
			124,
			83,
			105,
			110,
			103,
			108,
			101,
			116,
			111,
			110,
			80,
			101,
			114,
			115,
			105,
			115,
			116,
			0,
			0,
			0,
			0,
			9,
			74,
			52,
			70,
			124,
			84,
			111,
			111,
			108,
			115,
			0,
			0,
			0,
			0,
			11,
			124,
			70,
			114,
			101,
			101,
			67,
			97,
			109,
			101,
			114,
			97,
			0,
			0,
			0,
			0,
			26,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			66,
			117,
			116,
			116,
			111,
			110,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			34,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			66,
			117,
			116,
			116,
			111,
			110,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			124,
			80,
			97,
			100,
			100,
			105,
			110,
			103,
			0,
			0,
			0,
			0,
			21,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			80,
			105,
			101,
			67,
			104,
			97,
			114,
			116,
			0,
			0,
			0,
			0,
			38,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			80,
			105,
			101,
			67,
			104,
			97,
			114,
			116,
			124,
			80,
			105,
			101,
			67,
			104,
			97,
			114,
			116,
			68,
			97,
			116,
			97,
			78,
			111,
			100,
			101,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			43,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			124,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			43,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			124,
			83,
			117,
			98,
			77,
			101,
			110,
			117,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			37,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			77,
			111,
			98,
			105,
			108,
			101,
			0,
			0,
			0,
			0,
			49,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			77,
			111,
			98,
			105,
			108,
			101,
			124,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			83,
			117,
			98,
			77,
			101,
			110,
			117,
			0,
			0,
			0,
			0,
			30,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			77,
			85,
			73,
			80,
			73,
			110,
			116,
			101,
			114,
			110,
			97,
			108,
			84,
			111,
			111,
			108,
			115,
			0,
			0,
			0,
			0,
			28,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			68,
			101,
			109,
			111,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			83,
			119,
			97,
			121,
			0,
			0,
			0,
			0,
			34,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			68,
			101,
			109,
			111,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			83,
			119,
			97,
			121,
			80,
			97,
			114,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			68,
			101,
			109,
			111,
			76,
			105,
			115,
			116,
			83,
			104,
			97,
			100,
			111,
			119,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			73,
			110,
			112,
			117,
			116,
			83,
			121,
			115,
			116,
			101,
			109,
			67,
			104,
			101,
			99,
			107,
			101,
			114,
			0,
			0,
			0,
			0,
			22,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			76,
			97,
			117,
			110,
			99,
			104,
			85,
			82,
			76,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			67,
			117,
			115,
			116,
			111,
			109,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			0,
			0,
			0,
			0,
			41,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			67,
			117,
			115,
			116,
			111,
			109,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			124,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			48,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			67,
			117,
			115,
			116,
			111,
			109,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			124,
			73,
			116,
			101,
			109,
			84,
			101,
			120,
			116,
			67,
			104,
			97,
			110,
			103,
			101,
			100,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			32,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			67,
			117,
			115,
			116,
			111,
			109,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			124,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			32,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			77,
			117,
			108,
			116,
			105,
			83,
			101,
			108,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			44,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			77,
			117,
			108,
			116,
			105,
			83,
			101,
			108,
			101,
			99,
			116,
			124,
			84,
			111,
			103,
			103,
			108,
			101,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			37,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			77,
			117,
			108,
			116,
			105,
			83,
			101,
			108,
			101,
			99,
			116,
			124,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			72,
			111,
			114,
			105,
			122,
			111,
			110,
			116,
			97,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			0,
			0,
			0,
			0,
			45,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			72,
			111,
			114,
			105,
			122,
			111,
			110,
			116,
			97,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			124,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			52,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			72,
			111,
			114,
			105,
			122,
			111,
			110,
			116,
			97,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			124,
			73,
			116,
			101,
			109,
			84,
			101,
			120,
			116,
			67,
			104,
			97,
			110,
			103,
			101,
			100,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			36,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			72,
			111,
			114,
			105,
			122,
			111,
			110,
			116,
			97,
			108,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			124,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			32,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			65,
			110,
			105,
			109,
			97,
			116,
			101,
			100,
			73,
			99,
			111,
			110,
			72,
			97,
			110,
			100,
			108,
			101,
			114,
			0,
			0,
			0,
			0,
			24,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			73,
			99,
			111,
			110,
			76,
			105,
			98,
			114,
			97,
			114,
			121,
			0,
			0,
			0,
			0,
			33,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			73,
			99,
			111,
			110,
			76,
			105,
			98,
			114,
			97,
			114,
			121,
			124,
			73,
			99,
			111,
			110,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			24,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			73,
			99,
			111,
			110,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			29,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			67,
			117,
			115,
			116,
			111,
			109,
			73,
			110,
			112,
			117,
			116,
			70,
			105,
			101,
			108,
			100,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			76,
			97,
			121,
			111,
			117,
			116,
			71,
			114,
			111,
			117,
			112,
			70,
			105,
			120,
			0,
			0,
			0,
			0,
			30,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			82,
			97,
			100,
			105,
			97,
			108,
			76,
			97,
			121,
			111,
			117,
			116,
			71,
			114,
			111,
			117,
			112,
			0,
			0,
			0,
			0,
			21,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			0,
			0,
			0,
			0,
			30,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			124,
			76,
			105,
			115,
			116,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			29,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			124,
			76,
			105,
			115,
			116,
			82,
			111,
			119,
			0,
			0,
			0,
			0,
			25,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			24,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			76,
			105,
			115,
			116,
			86,
			105,
			101,
			119,
			82,
			111,
			119,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			77,
			111,
			100,
			97,
			108,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			32,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			33,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			83,
			116,
			97,
			99,
			107,
			105,
			110,
			103,
			0,
			0,
			0,
			0,
			21,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			80,
			66,
			70,
			105,
			108,
			108,
			101,
			100,
			0,
			0,
			0,
			0,
			24,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			0,
			0,
			0,
			0,
			41,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			124,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			19,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			82,
			105,
			112,
			112,
			108,
			101,
			0,
			0,
			0,
			0,
			23,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			71,
			114,
			97,
			100,
			105,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			25,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			82,
			97,
			100,
			105,
			97,
			108,
			83,
			108,
			105,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			37,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			82,
			97,
			100,
			105,
			97,
			108,
			83,
			108,
			105,
			100,
			101,
			114,
			124,
			83,
			108,
			105,
			100,
			101,
			114,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			82,
			97,
			110,
			103,
			101,
			77,
			97,
			120,
			83,
			108,
			105,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			82,
			97,
			110,
			103,
			101,
			77,
			105,
			110,
			83,
			108,
			105,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			24,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			82,
			97,
			110,
			103,
			101,
			83,
			108,
			105,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			24,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			83,
			108,
			105,
			100,
			101,
			114,
			73,
			110,
			112,
			117,
			116,
			0,
			0,
			0,
			0,
			26,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			83,
			108,
			105,
			100,
			101,
			114,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			38,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			83,
			108,
			105,
			100,
			101,
			114,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			124,
			83,
			108,
			105,
			100,
			101,
			114,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			26,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			83,
			119,
			105,
			116,
			99,
			104,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			38,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			83,
			119,
			105,
			116,
			99,
			104,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			124,
			83,
			119,
			105,
			116,
			99,
			104,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			25,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			67,
			117,
			115,
			116,
			111,
			109,
			84,
			111,
			103,
			103,
			108,
			101,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			69,
			108,
			101,
			109,
			101,
			110,
			116,
			84,
			97,
			98,
			98,
			105,
			110,
			103,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			27,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			22,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			34,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			65,
			110,
			105,
			109,
			97,
			116,
			101,
			100,
			73,
			99,
			111,
			110,
			0,
			0,
			0,
			0,
			28,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			66,
			117,
			116,
			116,
			111,
			110,
			0,
			0,
			0,
			0,
			33,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			67,
			111,
			110,
			116,
			101,
			120,
			116,
			77,
			101,
			110,
			117,
			0,
			0,
			0,
			0,
			28,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			67,
			117,
			115,
			116,
			111,
			109,
			0,
			0,
			0,
			0,
			30,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			0,
			0,
			0,
			0,
			34,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			68,
			114,
			111,
			112,
			100,
			111,
			119,
			110,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			72,
			83,
			101,
			108,
			101,
			99,
			116,
			111,
			114,
			0,
			0,
			0,
			0,
			32,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			73,
			110,
			112,
			117,
			116,
			70,
			105,
			101,
			108,
			100,
			0,
			0,
			0,
			0,
			33,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			77,
			111,
			100,
			97,
			108,
			87,
			105,
			110,
			100,
			111,
			119,
			0,
			0,
			0,
			0,
			34,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			78,
			111,
			116,
			105,
			102,
			105,
			99,
			97,
			116,
			105,
			111,
			110,
			0,
			0,
			0,
			0,
			30,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			80,
			105,
			101,
			67,
			104,
			97,
			114,
			116,
			0,
			0,
			0,
			0,
			33,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			0,
			0,
			0,
			0,
			37,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			80,
			114,
			111,
			103,
			114,
			101,
			115,
			115,
			66,
			97,
			114,
			76,
			111,
			111,
			112,
			0,
			0,
			0,
			0,
			31,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			83,
			99,
			114,
			111,
			108,
			108,
			98,
			97,
			114,
			0,
			0,
			0,
			0,
			28,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			83,
			108,
			105,
			100,
			101,
			114,
			0,
			0,
			0,
			0,
			28,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			83,
			119,
			105,
			116,
			99,
			104,
			0,
			0,
			0,
			0,
			28,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			84,
			111,
			103,
			103,
			108,
			101,
			0,
			0,
			0,
			0,
			29,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			84,
			111,
			111,
			108,
			116,
			105,
			112,
			0,
			0,
			0,
			0,
			35,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			85,
			73,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			26,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			87,
			105,
			110,
			100,
			111,
			119,
			68,
			114,
			97,
			103,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			26,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			0,
			0,
			0,
			0,
			44,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			124,
			87,
			105,
			110,
			100,
			111,
			119,
			67,
			104,
			97,
			110,
			103,
			101,
			69,
			118,
			101,
			110,
			116,
			0,
			0,
			0,
			0,
			37,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			46,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			124,
			87,
			105,
			110,
			100,
			111,
			119,
			73,
			116,
			101,
			109,
			0,
			0,
			0,
			0,
			32,
			77,
			105,
			99,
			104,
			115,
			107,
			121,
			46,
			77,
			85,
			73,
			80,
			124,
			87,
			105,
			110,
			100,
			111,
			119,
			77,
			97,
			110,
			97,
			103,
			101,
			114,
			66,
			117,
			116,
			116,
			111,
			110,
			0,
			0,
			0,
			0,
			42,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			65,
			100,
			100,
			0,
			0,
			0,
			0,
			47,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			65,
			100,
			100,
			82,
			97,
			110,
			103,
			101,
			0,
			0,
			0,
			0,
			44,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			108,
			101,
			97,
			114,
			0,
			0,
			0,
			0,
			54,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			108,
			101,
			97,
			114,
			65,
			108,
			108,
			80,
			114,
			111,
			120,
			105,
			101,
			115,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			110,
			99,
			97,
			116,
			0,
			0,
			0,
			0,
			47,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			110,
			116,
			97,
			105,
			110,
			115,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			112,
			121,
			84,
			111,
			0,
			0,
			0,
			0,
			44,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			117,
			110,
			116,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			69,
			120,
			105,
			115,
			116,
			115,
			0,
			0,
			0,
			0,
			42,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			78,
			101,
			120,
			116,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			80,
			114,
			101,
			118,
			105,
			111,
			117,
			115,
			0,
			0,
			0,
			0,
			48,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			82,
			97,
			110,
			100,
			111,
			109,
			0,
			0,
			0,
			0,
			62,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			82,
			97,
			110,
			100,
			111,
			109,
			67,
			117,
			114,
			118,
			101,
			100,
			87,
			101,
			105,
			103,
			104,
			116,
			101,
			100,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			84,
			121,
			112,
			101,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			73,
			110,
			100,
			101,
			120,
			79,
			102,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			73,
			110,
			115,
			101,
			114,
			116,
			0,
			0,
			0,
			0,
			48,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			73,
			110,
			116,
			101,
			114,
			115,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			73,
			115,
			69,
			109,
			112,
			116,
			121,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			76,
			97,
			115,
			116,
			73,
			110,
			100,
			101,
			120,
			79,
			102,
			0,
			0,
			0,
			0,
			43,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			77,
			111,
			118,
			101,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			82,
			101,
			108,
			97,
			116,
			105,
			118,
			101,
			0,
			0,
			0,
			0,
			49,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			82,
			97,
			121,
			99,
			97,
			115,
			116,
			65,
			108,
			108,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			82,
			101,
			109,
			111,
			118,
			101,
			0,
			0,
			0,
			0,
			47,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			82,
			101,
			109,
			111,
			118,
			101,
			65,
			116,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			82,
			101,
			109,
			111,
			118,
			101,
			82,
			97,
			110,
			103,
			101,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			82,
			101,
			115,
			101,
			116,
			86,
			97,
			108,
			117,
			101,
			115,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			82,
			101,
			118,
			101,
			114,
			115,
			101,
			0,
			0,
			0,
			0,
			55,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			82,
			101,
			118,
			101,
			114,
			116,
			84,
			111,
			83,
			110,
			97,
			112,
			83,
			104,
			111,
			116,
			0,
			0,
			0,
			0,
			42,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			101,
			116,
			0,
			0,
			0,
			0,
			56,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			101,
			116,
			69,
			118,
			101,
			110,
			116,
			67,
			97,
			108,
			108,
			98,
			97,
			99,
			107,
			115,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			104,
			117,
			102,
			102,
			108,
			101,
			0,
			0,
			0,
			0,
			43,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			111,
			114,
			116,
			0,
			0,
			0,
			0,
			48,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			119,
			97,
			112,
			73,
			116,
			101,
			109,
			115,
			0,
			0,
			0,
			0,
			51,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			84,
			97,
			107,
			101,
			83,
			110,
			97,
			112,
			83,
			104,
			111,
			116,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			114,
			101,
			97,
			116,
			101,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			68,
			101,
			115,
			116,
			114,
			111,
			121,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			0,
			0,
			0,
			0,
			43,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			70,
			105,
			110,
			100,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			67,
			114,
			101,
			97,
			116,
			101,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			68,
			101,
			115,
			116,
			114,
			111,
			121,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			0,
			0,
			0,
			0,
			42,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			65,
			100,
			100,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			65,
			100,
			100,
			77,
			97,
			110,
			121,
			0,
			0,
			0,
			0,
			44,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			67,
			108,
			101,
			97,
			114,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			67,
			111,
			110,
			99,
			97,
			116,
			0,
			0,
			0,
			0,
			47,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			67,
			111,
			110,
			116,
			97,
			105,
			110,
			115,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			67,
			111,
			110,
			116,
			97,
			105,
			110,
			115,
			75,
			101,
			121,
			0,
			0,
			0,
			0,
			52,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			67,
			111,
			110,
			116,
			97,
			105,
			110,
			115,
			86,
			97,
			108,
			117,
			101,
			0,
			0,
			0,
			0,
			44,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			67,
			111,
			117,
			110,
			116,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			69,
			100,
			105,
			116,
			75,
			101,
			121,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			69,
			120,
			105,
			115,
			116,
			115,
			0,
			0,
			0,
			0,
			42,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			71,
			101,
			116,
			0,
			0,
			0,
			0,
			54,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			71,
			101,
			116,
			75,
			101,
			121,
			70,
			114,
			111,
			109,
			86,
			97,
			108,
			117,
			101,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			71,
			101,
			116,
			77,
			97,
			110,
			121,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			71,
			101,
			116,
			78,
			101,
			120,
			116,
			0,
			0,
			0,
			0,
			48,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			71,
			101,
			116,
			82,
			97,
			110,
			100,
			111,
			109,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			71,
			101,
			116,
			84,
			121,
			112,
			101,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			73,
			115,
			69,
			109,
			112,
			116,
			121,
			0,
			0,
			0,
			0,
			43,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			75,
			101,
			121,
			115,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			82,
			101,
			109,
			111,
			118,
			101,
			0,
			0,
			0,
			0,
			53,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			82,
			101,
			118,
			101,
			114,
			116,
			83,
			110,
			97,
			112,
			83,
			104,
			111,
			116,
			0,
			0,
			0,
			0,
			42,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			83,
			101,
			116,
			0,
			0,
			0,
			0,
			46,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			83,
			101,
			116,
			77,
			97,
			110,
			121,
			0,
			0,
			0,
			0,
			28,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			83,
			111,
			114,
			116,
			75,
			101,
			121,
			115,
			102,
			114,
			111,
			109,
			86,
			97,
			108,
			117,
			101,
			115,
			0,
			0,
			0,
			0,
			51,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			84,
			97,
			107,
			101,
			83,
			110,
			97,
			112,
			83,
			104,
			111,
			116,
			0,
			0,
			0,
			0,
			45,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			72,
			97,
			115,
			104,
			84,
			97,
			98,
			108,
			101,
			86,
			97,
			108,
			117,
			101,
			115,
			0,
			0,
			0,
			0,
			58,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			65,
			99,
			116,
			105,
			118,
			97,
			116,
			101,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			115,
			0,
			0,
			0,
			0,
			57,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			67,
			111,
			110,
			116,
			97,
			105,
			110,
			115,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			59,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			70,
			105,
			110,
			100,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			115,
			66,
			121,
			84,
			97,
			103,
			0,
			0,
			0,
			0,
			62,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			65,
			108,
			108,
			67,
			104,
			105,
			108,
			100,
			79,
			102,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			62,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			67,
			104,
			105,
			108,
			100,
			114,
			101,
			110,
			79,
			102,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			59,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			67,
			108,
			111,
			115,
			101,
			115,
			116,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			66,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			67,
			108,
			111,
			115,
			101,
			115,
			116,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			73,
			110,
			83,
			105,
			103,
			104,
			116,
			0,
			0,
			0,
			0,
			60,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			70,
			97,
			114,
			116,
			104,
			101,
			115,
			116,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			0,
			0,
			0,
			0,
			67,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			70,
			97,
			114,
			116,
			104,
			101,
			115,
			116,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			73,
			110,
			83,
			105,
			103,
			104,
			116,
			0,
			0,
			0,
			0,
			68,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			71,
			97,
			109,
			101,
			111,
			98,
			106,
			101,
			99,
			116,
			77,
			97,
			120,
			70,
			115,
			109,
			70,
			108,
			111,
			97,
			116,
			73,
			110,
			100,
			101,
			120,
			0,
			0,
			0,
			0,
			61,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			101,
			110,
			100,
			69,
			118,
			101,
			110,
			116,
			84,
			111,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			115,
			0,
			0,
			0,
			0,
			67,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			101,
			110,
			100,
			83,
			116,
			114,
			105,
			110,
			103,
			69,
			118,
			101,
			110,
			116,
			84,
			111,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			115,
			0,
			0,
			0,
			0,
			63,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			111,
			114,
			116,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			66,
			121,
			68,
			105,
			115,
			116,
			97,
			110,
			99,
			101,
			0,
			0,
			0,
			0,
			54,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			111,
			114,
			116,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			115,
			0,
			0,
			0,
			0,
			73,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			46,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			83,
			111,
			114,
			116,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			115,
			124,
			109,
			121,
			71,
			97,
			109,
			101,
			79,
			98,
			106,
			101,
			99,
			116,
			83,
			111,
			114,
			116,
			101,
			114,
			0,
			0,
			0,
			0,
			54,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			65,
			118,
			101,
			114,
			97,
			103,
			101,
			86,
			97,
			108,
			117,
			101,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			76,
			105,
			115,
			116,
			71,
			101,
			116,
			77,
			97,
			120,
			86,
			97,
			108,
			117,
			101,
			0,
			0,
			0,
			0,
			50,
			72,
			117,
			116,
			111,
			110,
			103,
			71,
			97,
			109,
			101,
			115,
			46,
			80,
			108,
			97,
			121,
			77,
			97,
			107,
			101,
			114,
			46,
			65,
			99,
			116,
			105,
			111,
			110,
			115,
			124,
			65,
			114,
			114,
			97,
			121,
			"Not showing all elements because this array is too big (123866 elements)"
		};
		result.TotalFiles = 1790;
		result.TotalTypes = 2344;
		result.IsEditorOnly = false;
		return result;
	}

	// Token: 0x020000DF RID: 223
	private struct MonoScriptData
	{
		// Token: 0x040005C0 RID: 1472
		public byte[] FilePathsData;

		// Token: 0x040005C1 RID: 1473
		public byte[] TypesData;

		// Token: 0x040005C2 RID: 1474
		public int TotalTypes;

		// Token: 0x040005C3 RID: 1475
		public int TotalFiles;

		// Token: 0x040005C4 RID: 1476
		public bool IsEditorOnly;
	}
}

using System;
using System.Collections;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

// Token: 0x020000D1 RID: 209
public class UpgradesManager : NetworkBehaviour
{
	// Token: 0x060006F4 RID: 1780 RVA: 0x0002BEF2 File Offset: 0x0002A0F2
	public override void OnStartClient()
	{
		this.ManageSpace(0, this.spaceBought);
		this.ManageStorage(0, this.storageBought);
		this.ManageAddons();
		base.StartCoroutine(this.GameStartSetPerks());
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x0002BF24 File Offset: 0x0002A124
	[Command(requiresAuthority = false)]
	public void CmdAddSpace()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void UpgradesManager::CmdAddSpace()", -39006188, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x0002BF54 File Offset: 0x0002A154
	[ClientRpc]
	private void RpcAddSpace()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void UpgradesManager::RpcAddSpace()", 323008859, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x0002BF84 File Offset: 0x0002A184
	private void ManageSpace(int oldBought, int sBought)
	{
		this.spacePrice = 250 + sBought * 250;
		this.spacePriceOBJ.text = "$" + this.spacePrice.ToString();
		if (sBought == 0)
		{
			return;
		}
		GameObject gameObject = this.expansionsParentOBJ.transform.GetChild(0).gameObject;
		GameObject gameObject2 = this.expansionsUIParentOBJ.transform.GetChild(0).gameObject;
		for (int i = 0; i < sBought; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(false);
			gameObject2.transform.GetChild(i).gameObject.SetActive(false);
			if (gameObject.transform.GetChild(i).GetComponent<ExpansionAuxiliar>())
			{
				GameObject[] relatedPaintablesOBJs = gameObject.transform.GetChild(i).GetComponent<ExpansionAuxiliar>().relatedPaintablesOBJs;
				for (int j = 0; j < relatedPaintablesOBJs.Length; j++)
				{
					relatedPaintablesOBJs[j].SetActive(false);
				}
			}
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x0002C080 File Offset: 0x0002A280
	[Command(requiresAuthority = false)]
	public void CmdAddStorage()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		base.SendCommandInternal("System.Void UpgradesManager::CmdAddStorage()", 771762947, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x0002C0B0 File Offset: 0x0002A2B0
	[ClientRpc]
	private void RpcAddStorage()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		this.SendRPCInternal("System.Void UpgradesManager::RpcAddStorage()", -1101983712, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x0002C0E0 File Offset: 0x0002A2E0
	private void ManageStorage(int oldstoBought, int stoBought)
	{
		this.storagePrice = 2000 + stoBought * 1000;
		this.storagePriceOBJ.text = "$" + this.storagePrice.ToString();
		if (stoBought == 0)
		{
			return;
		}
		GameObject gameObject = this.expansionsParentOBJ.transform.GetChild(1).gameObject;
		GameObject gameObject2 = this.expansionsUIParentOBJ.transform.GetChild(1).gameObject;
		for (int i = 0; i < stoBought; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(false);
			gameObject2.transform.GetChild(i).gameObject.SetActive(false);
			if (gameObject.transform.GetChild(i).GetComponent<ExpansionAuxiliar>())
			{
				GameObject[] relatedPaintablesOBJs = gameObject.transform.GetChild(i).GetComponent<ExpansionAuxiliar>().relatedPaintablesOBJs;
				for (int j = 0; j < relatedPaintablesOBJs.Length; j++)
				{
					relatedPaintablesOBJs[j].SetActive(false);
				}
			}
		}
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x0000465C File Offset: 0x0000285C
	private void ManageAddons()
	{
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x0002C1DC File Offset: 0x0002A3DC
	[Command(requiresAuthority = false)]
	public void CmdAcquirePerk(int perkIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(perkIndex);
		base.SendCommandInternal("System.Void UpgradesManager::CmdAcquirePerk(System.Int32)", 935775746, writer, 0, false);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0002C218 File Offset: 0x0002A418
	[ClientRpc]
	private void RpcAcquirePerk(int perkIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(perkIndex);
		this.SendRPCInternal("System.Void UpgradesManager::RpcAcquirePerk(System.Int32)", -1809233233, writer, 0, true);
		NetworkWriterPool.Return(writer);
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0002C252 File Offset: 0x0002A452
	private IEnumerator GameStartSetPerks()
	{
		int num;
		for (int i = 0; i < this.extraUpgrades.Length; i = num + 1)
		{
			if (this.extraUpgrades[i])
			{
				this.ManageExtraPerks(i);
			}
			yield return null;
			num = i;
		}
		yield return null;
		yield break;
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0002C264 File Offset: 0x0002A464
	private void ManageExtraPerks(int perkIndex)
	{
		switch (perkIndex)
		{
		case 0:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 1:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 2:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 3:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 4:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 5:
			NPC_Manager.Instance.extraEmployeeSpeedFactor += 0.2f;
			NPC_Manager.Instance.UpdateEmployeeStats();
			break;
		case 6:
			NPC_Manager.Instance.extraCheckoutMoney += 0.1f;
			NPC_Manager.Instance.UpdateEmployeeStats();
			break;
		case 7:
			NPC_Manager.Instance.extraEmployeeSpeedFactor += 0.2f;
			NPC_Manager.Instance.UpdateEmployeeStats();
			break;
		case 8:
			this.boxRecycleFactor = 4;
			break;
		case 9:
			base.GetComponent<GameData>().extraCustomersPerk++;
			break;
		case 10:
			base.GetComponent<GameData>().extraCustomersPerk++;
			break;
		case 11:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 12:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 13:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 14:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 15:
			NPC_Manager.Instance.maxEmployees++;
			NPC_Manager.Instance.UpdateEmployeesNumberInBlackboard();
			break;
		case 16:
			NPC_Manager.Instance.productCheckoutWait -= 0.15f;
			break;
		case 17:
			NPC_Manager.Instance.productCheckoutWait -= 0.2f;
			break;
		case 18:
			NPC_Manager.Instance.productCheckoutWait -= 0.15f;
			break;
		case 19:
			NPC_Manager.Instance.employeeItemPlaceWait -= 0.05f;
			break;
		case 20:
			NPC_Manager.Instance.employeeItemPlaceWait -= 0.05f;
			break;
		case 21:
			NPC_Manager.Instance.extraEmployeeSpeedFactor += 0.2f;
			NPC_Manager.Instance.UpdateEmployeeStats();
			break;
		case 22:
			NPC_Manager.Instance.extraEmployeeSpeedFactor += 0.2f;
			NPC_Manager.Instance.UpdateEmployeeStats();
			break;
		case 23:
			NPC_Manager.Instance.extraEmployeeSpeedFactor += 0.2f;
			NPC_Manager.Instance.UpdateEmployeeStats();
			break;
		case 24:
			NPC_Manager.Instance.employeeRecycleBoxes = true;
			this.interruptRecyclingButtonOBJ.SetActive(true);
			break;
		}
		GameObject gameObject = this.UIPerksParent.transform.GetChild(perkIndex).gameObject;
		gameObject.GetComponent<CanvasGroup>().alpha = 1f;
		gameObject.tag = "Untagged";
		gameObject.transform.Find("Highlight2").gameObject.SetActive(true);
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0002C621 File Offset: 0x0002A821
	private void PlaySpecialAudio()
	{
		base.transform.Find("Audio_Special").GetComponent<AudioSource>().Play();
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0002C640 File Offset: 0x0002A840
	public UpgradesManager()
	{
		this._Mirror_SyncVarHookDelegate_spaceBought = new Action<int, int>(this.ManageSpace);
		this._Mirror_SyncVarHookDelegate_storageBought = new Action<int, int>(this.ManageStorage);
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0000C914 File Offset: 0x0000AB14
	public override bool Weaved()
	{
		return true;
	}

	// Token: 0x170000CF RID: 207
	// (get) Token: 0x06000703 RID: 1795 RVA: 0x0002C6B0 File Offset: 0x0002A8B0
	// (set) Token: 0x06000704 RID: 1796 RVA: 0x0002C6C3 File Offset: 0x0002A8C3
	public int NetworkspaceBought
	{
		get
		{
			return this.spaceBought;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.spaceBought, 1UL, this._Mirror_SyncVarHookDelegate_spaceBought);
		}
	}

	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x06000705 RID: 1797 RVA: 0x0002C6E4 File Offset: 0x0002A8E4
	// (set) Token: 0x06000706 RID: 1798 RVA: 0x0002C6F7 File Offset: 0x0002A8F7
	public int NetworkstorageBought
	{
		get
		{
			return this.storageBought;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<int>(value, ref this.storageBought, 2UL, this._Mirror_SyncVarHookDelegate_storageBought);
		}
	}

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x06000707 RID: 1799 RVA: 0x0002C718 File Offset: 0x0002A918
	// (set) Token: 0x06000708 RID: 1800 RVA: 0x0002C72B File Offset: 0x0002A92B
	public bool[] NetworkaddonsBought
	{
		get
		{
			return this.addonsBought;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool[]>(value, ref this.addonsBought, 4UL, null);
		}
	}

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x06000709 RID: 1801 RVA: 0x0002C748 File Offset: 0x0002A948
	// (set) Token: 0x0600070A RID: 1802 RVA: 0x0002C75B File Offset: 0x0002A95B
	public bool[] NetworkextraUpgrades
	{
		get
		{
			return this.extraUpgrades;
		}
		[param: In]
		set
		{
			base.GeneratedSyncVarSetter<bool[]>(value, ref this.extraUpgrades, 8UL, null);
		}
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x0002C778 File Offset: 0x0002A978
	protected void UserCode_CmdAddSpace()
	{
		if (this.spaceBought >= 36)
		{
			GameCanvas.Instance.CreateCanvasNotification("message9");
			return;
		}
		GameData component = base.GetComponent<GameData>();
		component.NetworkgameFunds = component.gameFunds - (float)this.spacePrice;
		base.GetComponent<GameData>().otherCosts += (float)this.spacePrice;
		this.NetworkspaceBought = this.spaceBought + 1;
		this.RpcAddSpace();
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x0002C7E5 File Offset: 0x0002A9E5
	protected static void InvokeUserCode_CmdAddSpace(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddSpace called on client.");
			return;
		}
		((UpgradesManager)obj).UserCode_CmdAddSpace();
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x0002C808 File Offset: 0x0002AA08
	protected void UserCode_RpcAddSpace()
	{
		this.PlaySpecialAudio();
		GameCanvas.Instance.CreateImportantNotification("messagei3");
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0002C81F File Offset: 0x0002AA1F
	protected static void InvokeUserCode_RpcAddSpace(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAddSpace called on server.");
			return;
		}
		((UpgradesManager)obj).UserCode_RpcAddSpace();
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0002C844 File Offset: 0x0002AA44
	protected void UserCode_CmdAddStorage()
	{
		if (this.storageBought >= 8)
		{
			GameCanvas.Instance.CreateCanvasNotification("message9a");
			return;
		}
		GameData component = base.GetComponent<GameData>();
		component.NetworkgameFunds = component.gameFunds - (float)this.storagePrice;
		base.GetComponent<GameData>().otherCosts += (float)this.storagePrice;
		this.NetworkstorageBought = this.storageBought + 1;
		this.RpcAddStorage();
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0002C8B0 File Offset: 0x0002AAB0
	protected static void InvokeUserCode_CmdAddStorage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAddStorage called on client.");
			return;
		}
		((UpgradesManager)obj).UserCode_CmdAddStorage();
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0002C8D3 File Offset: 0x0002AAD3
	protected void UserCode_RpcAddStorage()
	{
		this.PlaySpecialAudio();
		GameCanvas.Instance.CreateImportantNotification("messagei4");
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0002C8EA File Offset: 0x0002AAEA
	protected static void InvokeUserCode_RpcAddStorage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAddStorage called on server.");
			return;
		}
		((UpgradesManager)obj).UserCode_RpcAddStorage();
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0002C910 File Offset: 0x0002AB10
	protected void UserCode_CmdAcquirePerk__Int32(int perkIndex)
	{
		this.extraUpgrades[perkIndex] = true;
		GameData instance = GameData.Instance;
		instance.NetworkgameFranchisePoints = instance.gameFranchisePoints - 1;
		GameData.Instance.NetworkgameFranchisePoints = Mathf.Clamp(GameData.Instance.gameFranchisePoints, 0, 1000);
		this.RpcAcquirePerk(perkIndex);
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x0002C95E File Offset: 0x0002AB5E
	protected static void InvokeUserCode_CmdAcquirePerk__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAcquirePerk called on client.");
			return;
		}
		((UpgradesManager)obj).UserCode_CmdAcquirePerk__Int32(reader.ReadInt());
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x0002C987 File Offset: 0x0002AB87
	protected void UserCode_RpcAcquirePerk__Int32(int perkIndex)
	{
		base.GetComponent<GameData>().transform.Find("Audio_AcquirePerk").GetComponent<AudioSource>().Play();
		this.extraUpgrades[perkIndex] = true;
		this.ManageExtraPerks(perkIndex);
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0002C9B8 File Offset: 0x0002ABB8
	protected static void InvokeUserCode_RpcAcquirePerk__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcAcquirePerk called on server.");
			return;
		}
		((UpgradesManager)obj).UserCode_RpcAcquirePerk__Int32(reader.ReadInt());
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x0002C9E4 File Offset: 0x0002ABE4
	static UpgradesManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(UpgradesManager), "System.Void UpgradesManager::CmdAddSpace()", new RemoteCallDelegate(UpgradesManager.InvokeUserCode_CmdAddSpace), false);
		RemoteProcedureCalls.RegisterCommand(typeof(UpgradesManager), "System.Void UpgradesManager::CmdAddStorage()", new RemoteCallDelegate(UpgradesManager.InvokeUserCode_CmdAddStorage), false);
		RemoteProcedureCalls.RegisterCommand(typeof(UpgradesManager), "System.Void UpgradesManager::CmdAcquirePerk(System.Int32)", new RemoteCallDelegate(UpgradesManager.InvokeUserCode_CmdAcquirePerk__Int32), false);
		RemoteProcedureCalls.RegisterRpc(typeof(UpgradesManager), "System.Void UpgradesManager::RpcAddSpace()", new RemoteCallDelegate(UpgradesManager.InvokeUserCode_RpcAddSpace));
		RemoteProcedureCalls.RegisterRpc(typeof(UpgradesManager), "System.Void UpgradesManager::RpcAddStorage()", new RemoteCallDelegate(UpgradesManager.InvokeUserCode_RpcAddStorage));
		RemoteProcedureCalls.RegisterRpc(typeof(UpgradesManager), "System.Void UpgradesManager::RpcAcquirePerk(System.Int32)", new RemoteCallDelegate(UpgradesManager.InvokeUserCode_RpcAcquirePerk__Int32));
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x0002CAB4 File Offset: 0x0002ACB4
	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(this.spaceBought);
			writer.WriteInt(this.storageBought);
			Mirror.GeneratedNetworkCode._Write_System.Boolean[](writer, this.addonsBought);
			Mirror.GeneratedNetworkCode._Write_System.Boolean[](writer, this.extraUpgrades);
			return;
		}
		writer.WriteULong(this.syncVarDirtyBits);
		if ((this.syncVarDirtyBits & 1UL) != 0UL)
		{
			writer.WriteInt(this.spaceBought);
		}
		if ((this.syncVarDirtyBits & 2UL) != 0UL)
		{
			writer.WriteInt(this.storageBought);
		}
		if ((this.syncVarDirtyBits & 4UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.Boolean[](writer, this.addonsBought);
		}
		if ((this.syncVarDirtyBits & 8UL) != 0UL)
		{
			Mirror.GeneratedNetworkCode._Write_System.Boolean[](writer, this.extraUpgrades);
		}
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x0002CB98 File Offset: 0x0002AD98
	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.spaceBought, this._Mirror_SyncVarHookDelegate_spaceBought, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<int>(ref this.storageBought, this._Mirror_SyncVarHookDelegate_storageBought, reader.ReadInt());
			base.GeneratedSyncVarDeserialize<bool[]>(ref this.addonsBought, null, Mirror.GeneratedNetworkCode._Read_System.Boolean[](reader));
			base.GeneratedSyncVarDeserialize<bool[]>(ref this.extraUpgrades, null, Mirror.GeneratedNetworkCode._Read_System.Boolean[](reader));
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.spaceBought, this._Mirror_SyncVarHookDelegate_spaceBought, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<int>(ref this.storageBought, this._Mirror_SyncVarHookDelegate_storageBought, reader.ReadInt());
		}
		if ((num & 4L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool[]>(ref this.addonsBought, null, Mirror.GeneratedNetworkCode._Read_System.Boolean[](reader));
		}
		if ((num & 8L) != 0L)
		{
			base.GeneratedSyncVarDeserialize<bool[]>(ref this.extraUpgrades, null, Mirror.GeneratedNetworkCode._Read_System.Boolean[](reader));
		}
	}

	// Token: 0x04000585 RID: 1413
	[SyncVar(hook = "ManageSpace")]
	public int spaceBought;

	// Token: 0x04000586 RID: 1414
	[SyncVar(hook = "ManageStorage")]
	public int storageBought;

	// Token: 0x04000587 RID: 1415
	[SyncVar]
	public bool[] addonsBought = new bool[6];

	// Token: 0x04000588 RID: 1416
	[SyncVar]
	public bool[] extraUpgrades = new bool[11];

	// Token: 0x04000589 RID: 1417
	public GameObject UIPerksParent;

	// Token: 0x0400058A RID: 1418
	public int maxEmployees;

	// Token: 0x0400058B RID: 1419
	public int boxRecycleFactor = 1;

	// Token: 0x0400058C RID: 1420
	[Space(10f)]
	public GameObject expansionsParentOBJ;

	// Token: 0x0400058D RID: 1421
	public GameObject expansionsUIParentOBJ;

	// Token: 0x0400058E RID: 1422
	[Space(10f)]
	public int spacePrice = 500;

	// Token: 0x0400058F RID: 1423
	public TextMeshProUGUI spacePriceOBJ;

	// Token: 0x04000590 RID: 1424
	[Space(10f)]
	public int storagePrice = 1000;

	// Token: 0x04000591 RID: 1425
	public TextMeshProUGUI storagePriceOBJ;

	// Token: 0x04000592 RID: 1426
	[Space(10f)]
	public GameObject interruptRecyclingButtonOBJ;

	// Token: 0x04000593 RID: 1427
	public Action<int, int> _Mirror_SyncVarHookDelegate_spaceBought;

	// Token: 0x04000594 RID: 1428
	public Action<int, int> _Mirror_SyncVarHookDelegate_storageBought;
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000C RID: 12
[Serializable]
public class WalkPath : MonoBehaviour
{
	// Token: 0x0600001B RID: 27 RVA: 0x0000462B File Offset: 0x0000282B
	public Vector3 getNextPoint(int w, int index)
	{
		return this.points[w, index];
	}

	// Token: 0x0600001C RID: 28 RVA: 0x0000463A File Offset: 0x0000283A
	public Vector3 getStartPoint(int w)
	{
		return this.points[w, 1];
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00004649 File Offset: 0x00002849
	public int getPointsTotal(int w)
	{
		return this.pointLength[w];
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00004653 File Offset: 0x00002853
	private void Awake()
	{
		this.DrawCurved(false);
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000465C File Offset: 0x0000285C
	public virtual void SpawnOnePeople(int w, bool forward, float walkSpeed, float runSpeed)
	{
	}

	// Token: 0x06000020 RID: 32 RVA: 0x0000465C File Offset: 0x0000285C
	public virtual void SpawnPeople()
	{
	}

	// Token: 0x06000021 RID: 33 RVA: 0x0000465C File Offset: 0x0000285C
	public virtual void DrawCurved(bool withDraw)
	{
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00004660 File Offset: 0x00002860
	protected Vector3 GetRoutePosition(Vector3[] pointArray, float distance, int pointCount, bool loopPath)
	{
		int num = 0;
		float length = this._distances[this._distances.Length - 1];
		distance = Mathf.Repeat(distance, length);
		while (this._distances[num] < distance)
		{
			num++;
		}
		int num2 = (num - 1 + pointCount) % pointCount;
		int num3 = num;
		float t = Mathf.InverseLerp(this._distances[num2], this._distances[num3], distance);
		return Vector3.Lerp(pointArray[num2], pointArray[num3], t);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x000046D4 File Offset: 0x000028D4
	protected int GetRoutePoint(float distance, int wayIndex, int pointCount, bool forward, bool loopPath)
	{
		int num = 0;
		float length = this._distances[this._distances.Length - 1];
		distance = Mathf.Repeat(distance, length);
		while (this._distances[num] < distance)
		{
			num++;
		}
		return num;
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00004710 File Offset: 0x00002910
	private bool PointWithSphereCollision(Vector3 colisionSpherePosition, Vector3 pointPosition)
	{
		return Vector3.Magnitude(colisionSpherePosition - pointPosition) < this.eraseRadius;
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00004726 File Offset: 0x00002926
	private bool PointWithLineCollision(Vector3 lineStartPosition, Vector3 lineEndPosition, Vector3 pointPosition)
	{
		return this.Distance(lineStartPosition, lineEndPosition, pointPosition) < this.addPointDistance;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x0000473C File Offset: 0x0000293C
	private float Distance(Vector3 lineStartPosition, Vector3 lineEndPosition, Vector3 pointPosition)
	{
		float num = Vector3.SqrMagnitude(lineEndPosition - lineStartPosition);
		if (num == 0f)
		{
			return Vector3.Distance(pointPosition, lineStartPosition);
		}
		float d = Mathf.Max(0f, Mathf.Min(1f, Vector3.Dot(pointPosition - lineStartPosition, lineEndPosition - lineStartPosition) / num));
		Vector3 b = lineStartPosition + d * (lineEndPosition - lineStartPosition);
		return Vector3.Distance(pointPosition, b);
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000047AC File Offset: 0x000029AC
	public void AddPoint()
	{
		if (this.firstPointIndex == -1 && this.secondPointIndex == this.firstPointIndex)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate<GameObject>(GameObject.Find("Population System").GetComponent<PopulationSystemManager>().pointPrefab, this.mousePosition, Quaternion.identity);
		gameObject.name = "p+";
		gameObject.transform.parent = this.pathPointTransform[this.firstPointIndex].transform.parent;
		this.pathPointTransform.Insert(this.firstPointIndex + 1, gameObject);
		this.pathPoint.Insert(this.firstPointIndex + 1, gameObject.transform.position);
	}

	// Token: 0x06000028 RID: 40 RVA: 0x0000485C File Offset: 0x00002A5C
	public void DeletePoint()
	{
		if (this.deletePointIndex == -1)
		{
			return;
		}
		Object.DestroyImmediate(this.pathPointTransform[this.deletePointIndex]);
		this.pathPointTransform.RemoveAt(this.deletePointIndex);
		this.pathPoint.RemoveAt(this.deletePointIndex);
	}

	// Token: 0x04000054 RID: 84
	[Tooltip("Objects of motion / Объекты движения")]
	public GameObject[] peoplePrefabs;

	// Token: 0x04000055 RID: 85
	[Tooltip("Number of paths / Количество путей")]
	public int numberOfWays;

	// Token: 0x04000056 RID: 86
	[Tooltip("Space between paths / Пространство между путями")]
	public float lineSpacing;

	// Token: 0x04000057 RID: 87
	[Tooltip("Density of movement of objects / Плотность движения объектов")]
	[Range(0.01f, 0.5f)]
	public float Density = 0.2f;

	// Token: 0x04000058 RID: 88
	[Tooltip("Distance between objects / Дистанция между объектами")]
	[Range(1f, 10f)]
	public float _minimalObjectLength = 1f;

	// Token: 0x04000059 RID: 89
	[Tooltip("Make the path closed in the ring / Сделать путь замкнутым в кольцо")]
	public bool loopPath;

	// Token: 0x0400005A RID: 90
	protected float[] _distances;

	// Token: 0x0400005B RID: 91
	[HideInInspector]
	public List<Vector3> pathPoint = new List<Vector3>();

	// Token: 0x0400005C RID: 92
	[HideInInspector]
	public List<GameObject> pathPointTransform = new List<GameObject>();

	// Token: 0x0400005D RID: 93
	[HideInInspector]
	public Vector3[,] points;

	// Token: 0x0400005E RID: 94
	[HideInInspector]
	public List<Vector3> CalcPoint = new List<Vector3>();

	// Token: 0x0400005F RID: 95
	[HideInInspector]
	public int[] pointLength = new int[10];

	// Token: 0x04000060 RID: 96
	[HideInInspector]
	public bool disableLineDraw;

	// Token: 0x04000061 RID: 97
	[HideInInspector]
	public bool[] _forward;

	// Token: 0x04000062 RID: 98
	[HideInInspector]
	public GameObject par;

	// Token: 0x04000063 RID: 99
	[HideInInspector]
	public PathType pathType;

	// Token: 0x04000064 RID: 100
	[Tooltip("Radius of the sphere-scraper [m] / Радиус сферы-стёрки [м]")]
	[Range(0.1f, 25f)]
	public float eraseRadius = 2f;

	// Token: 0x04000065 RID: 101
	[Tooltip("The minimum distance from the cursor to the line at which you can add a new point to the path [m] / Минимальное расстояние от курсора до линии, при котором можно добавить новую точку в путь [м]")]
	[Range(0.5f, 10f)]
	public float addPointDistance = 2f;

	// Token: 0x04000066 RID: 102
	[Tooltip("Adjust the spawn of cars to the nearest surface. This option will be useful if there are bridges in the scene / Регулировка спавна людей к ближайшей поверхности. Этот параметор будет полезен, если в сцене есть мосты.")]
	public float highToSpawn = 1f;

	// Token: 0x04000067 RID: 103
	[Range(0f, 5f)]
	[Tooltip("Offset from the line along the X axis / Смещение от линии по оси X")]
	public float randXPos = 0.1f;

	// Token: 0x04000068 RID: 104
	[Range(0f, 5f)]
	[Tooltip("Offset from the line along the Z axis / Смещение от линии по оси Z")]
	public float randZPos = 0.1f;

	// Token: 0x04000069 RID: 105
	[HideInInspector]
	public bool newPointCreation;

	// Token: 0x0400006A RID: 106
	[HideInInspector]
	public bool oldPointDeleting;

	// Token: 0x0400006B RID: 107
	[HideInInspector]
	public Vector3 mousePosition = Vector3.zero;

	// Token: 0x0400006C RID: 108
	private int deletePointIndex = -1;

	// Token: 0x0400006D RID: 109
	private int firstPointIndex = -1;

	// Token: 0x0400006E RID: 110
	private int secondPointIndex = -1;
}

using System;
using UnityEngine;
using Vuplex.WebView;

// Token: 0x020000D3 RID: 211
public class WebHelper : MonoBehaviour
{
	// Token: 0x06000720 RID: 1824 RVA: 0x0002CD6D File Offset: 0x0002AF6D
	public void ReturnPage()
	{
		this.iwebView = this.wViewPrefab.WebView;
		this.iwebView.GoBack();
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x0002CD8B File Offset: 0x0002AF8B
	public void RefreshPage()
	{
		this.iwebView = this.wViewPrefab.WebView;
		this.iwebView.Reload();
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x0002CDA9 File Offset: 0x0002AFA9
	public void GoToMainURL()
	{
		this.iwebView = this.wViewPrefab.WebView;
		this.iwebView.LoadUrl("https://www.google.com");
	}

	// Token: 0x04000599 RID: 1433
	public WebViewPrefab wViewPrefab;

	// Token: 0x0400059A RID: 1434
	private IWebView iwebView;
}

using System;
using UnityEngine;

// Token: 0x020000D4 RID: 212
public class WheelControl : MonoBehaviour
{
	// Token: 0x06000724 RID: 1828 RVA: 0x0002CDCC File Offset: 0x0002AFCC
	private void Start()
	{
		this.WheelCollider = base.GetComponent<WheelCollider>();
	}

	// Token: 0x0400059B RID: 1435
	public Transform wheelModel;

	// Token: 0x0400059C RID: 1436
	[HideInInspector]
	public WheelCollider WheelCollider;

	// Token: 0x0400059D RID: 1437
	public bool steerable;

	// Token: 0x0400059E RID: 1438
	public bool motorized;
}

using System;
using UnityEngine;

// Token: 0x020000D5 RID: 213
public class Z_FPS_Display : MonoBehaviour
{
	// Token: 0x06000726 RID: 1830 RVA: 0x0002CDDA File Offset: 0x0002AFDA
	private void Update()
	{
		this.deltaTime += (Time.unscaledDeltaTime - this.deltaTime) * 0.1f;
		this.FPS = 1f / this.deltaTime;
	}

	// Token: 0x0400059F RID: 1439
	public float deltaTime;

	// Token: 0x040005A0 RID: 1440
	public float FPS;
}
