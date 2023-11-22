using HarmonyLib;
using ResoniteModLoader;
using FrooxEngine;

namespace LogFlush
{
	public class LogFlush : ResoniteMod
	{
		public override string Name => "LogFlush";
		public override string Author => "Nytra";
		public override string Version => "1.1.0";
		public override string Link => "https://github.com/Nytra/ResoniteLogFlush";
		public override void OnEngineInit()
		{
			Harmony harmony = new Harmony("owo.Nytra.LogFlush");
			harmony.PatchAll();
		}

		[HarmonyPatch(typeof(Userspace), "OnCommonUpdate")]
		class LogFlushPatch
		{
			public static void Postfix()
			{
                if (Engine.Current.InputInterface.GetKeyDown(Key.F1))
				{
					Msg("Flushing LogStream...");
					FrooxEngineBootstrap.LogStream.Flush();
				}
            }
		}
	}
}