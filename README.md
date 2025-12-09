# MC_SVTimeScale
  
Backup your save before using any mods.  
  
Uninstall any mods and attempt to replicate issues before reporting any suspected base game bugs on official channels.  

Function
====
Speed up game time scale in increments or by holding a key.  
  
This mod increases the whole game's run speed.  It is not a speed booster plus.  If a hard hitting enemy wants you dead, you wont escape, you'll die faster.
  
Additionally, the game uses built-in timers which expect "normal" time progression for things like energy generation, shield regeneration, weapon heat disappation etc.  This 
mod currently does not compensate for "skipped" updates in this regard.  It is mainly for getting around at a less painful speed.  
  
Be cautious about very large values.  The mod has no built-in cap.
  
Install
=======
1. Install BepInEx - https://docs.bepinex.dev/articles/user_guide/installation/index.html Stable version 5.4.21 x64.  
2. Run the game at least once to initialise BepInEx and quit.  
3. Download latest mod release.  
4. Place MC_SVTimeScale.dll in .\SteamLibrary\steamapps\common\Star Valor\BepInEx\plugins\  
  
Use / Configuration
=====
After first run, a new file will be created in .\Star Valor\BepInEx\config\ called mc.starvalor.timescale.cfg to change key bindings and operating mode.  
  
Options:  
- Enable hold key mode? - Set to true to enable hold key mode.  Set to false to use increment/reset mode.  Default is false.  
- Hold key - The "hold key" mode key.  Default is \\.  
- Time scale - The time multiplier to use in when the hold key mode key is held.  Default is 3.  
- Increment Key - The "increment" key for increment/reset mode.  Default is =.  
- Reset Key - The "reset" key for increment/reset mode.  Default is \-.  
- Step size - The step to increment the time multiplier by when in increment/reset mode.  Default is 0.5.  
