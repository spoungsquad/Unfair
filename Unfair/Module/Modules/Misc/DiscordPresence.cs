using System;
using System.Linq;
using System.Timers;
using DiscordRPC;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Unfair.Module.Modules.Misc
{
	public class DiscordPresence : Module
	{
		private DiscordRpcClient _client;
		private DateTime _startTime;
		private Timer _timer = new Timer(5000);

		private string[] _phrases =
		{
			"Anticheat? What's that?",
			"Do the devs even care about this game?",
			".gg/aQpBhhPQ",
			"can we get unbanned from the 1v1 server please",
			"Any spoung?",
			"carter has our ips 😨"
		};
		
		public DiscordPresence() : base("DiscordPresence", "Shows a status on Discord", Category.Misc, KeyCode.U)
		{
			_startTime = DateTime.UtcNow;
			
			_client = new DiscordRpcClient("1137115070476853351");
			_client.SkipIdenticalPresence = true;
			
			_timer.Elapsed += UpdatePresence;
			_timer.Start();
		}

		public override void OnEnable()
		{
			_client.Initialize();
		}
		
		public override void OnDisable()
		{
			_client.ClearPresence();
			_client.Deinitialize();
		}

		private void UpdatePresence(object sender, ElapsedEventArgs e)
		{
			if (!_client.IsInitialized) return;
			
			_client.SetPresence(new RichPresence
			{
				Details = _phrases[Random.Range(0, _phrases.Length)],
				State = $"{ModuleManager.Modules.Count(m => m.Enabled)} modules enabled",
				
				Assets = new DiscordRPC.Assets { LargeImageKey = "unfair" },
				
				Timestamps = new Timestamps { Start = _startTime }
			});
		}
	}
}