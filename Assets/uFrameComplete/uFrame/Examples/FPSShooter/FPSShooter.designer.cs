// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using UnityEngine;


public enum FPSPlayerState {
    
    Alive,
    
    Dead,
}

public enum FPSGameState {
    
    Active,
    
    Paused,
    
    Done,
}

public enum FPSWeaponState {
    
    Active,
    
    Reloading,
    
    InActive,
    
    Empty,
    
    Firing,
}

public enum WeaponType {
    
    MP5,
    
    UMP5,
    
    Colt,
}

[DiagramInfoAttribute("FPSShooter")]
public partial class FPSDamageableViewModel : ViewModel {
    
    public readonly P<System.Single> _HealthProperty = new P<float>();
    
    public readonly P<FPSPlayerState> _StateProperty = new P<FPSPlayerState>();
    
    private ICommand _ApplyDamage;
    
    public virtual float Health {
        get {
            return _HealthProperty.Value;
        }
        set {
            _HealthProperty.Value = value;
        }
    }
    
    public virtual FPSPlayerState State {
        get {
            return _StateProperty.Value;
        }
        set {
            _StateProperty.Value = value;
        }
    }
    
    public virtual ICommand ApplyDamage {
        get {
            return _ApplyDamage;
        }
        set {
            _ApplyDamage = value;
        }
    }
}

[DiagramInfoAttribute("FPSShooter")]
public partial class FPSEnemyViewModel : FPSDamageableViewModel {
    
    public readonly P<System.Single> _SpeedProperty = new P<float>();
    
    public virtual float Speed {
        get {
            return _SpeedProperty.Value;
        }
        set {
            _SpeedProperty.Value = value;
        }
    }
}

[DiagramInfoAttribute("FPSShooter")]
public partial class FPSGameViewModel : ViewModel {
    
    public readonly P<FPSPlayerViewModel> _CurrentPlayerProperty = new P<FPSPlayerViewModel>();
    
    public readonly P<FPSGameState> _StateProperty = new P<FPSGameState>();
    
    public readonly P<System.Int32> _ScoreProperty = new P<int>();
    
    public readonly P<System.Int32> _KillsProperty = new P<int>();
    
    public readonly ModelCollection<FPSEnemyViewModel> _EnemiesProperty = new ModelCollection<FPSEnemyViewModel>();
    
    private ICommand _MainMenu;
    
    private ICommand _QuitGame;
    
    public virtual FPSPlayerViewModel CurrentPlayer {
        get {
            return _CurrentPlayerProperty.Value;
        }
        set {
            _CurrentPlayerProperty.Value = value;
        }
    }
    
    public virtual FPSGameState State {
        get {
            return _StateProperty.Value;
        }
        set {
            _StateProperty.Value = value;
        }
    }
    
    public virtual int Score {
        get {
            return _ScoreProperty.Value;
        }
        set {
            _ScoreProperty.Value = value;
        }
    }
    
    public virtual int Kills {
        get {
            return _KillsProperty.Value;
        }
        set {
            _KillsProperty.Value = value;
        }
    }
    
    public virtual System.Collections.Generic.ICollection<FPSEnemyViewModel> Enemies {
        get {
            return _EnemiesProperty;
        }
        set {
            _EnemiesProperty.Value = value.ToList();
        }
    }
    
    public virtual ICommand MainMenu {
        get {
            return _MainMenu;
        }
        set {
            _MainMenu = value;
        }
    }
    
    public virtual ICommand QuitGame {
        get {
            return _QuitGame;
        }
        set {
            _QuitGame = value;
        }
    }
}

[DiagramInfoAttribute("FPSShooter")]
public partial class FPSPlayerViewModel : FPSDamageableViewModel {
    
    public readonly P<System.Int32> _CurrentWeaponIndexProperty = new P<int>();
    
    public readonly ModelCollection<FPSWeaponViewModel> _WeaponsProperty = new ModelCollection<FPSWeaponViewModel>();
    
    private ICommand _NextWeapon;
    
    private ICommand _PickupWeapon;
    
    private ICommand _PreviousWeapon;
    
    private ICommand _SelectWeapon;
    
    public virtual int CurrentWeaponIndex {
        get {
            return _CurrentWeaponIndexProperty.Value;
        }
        set {
            _CurrentWeaponIndexProperty.Value = value;
        }
    }
    
    public virtual System.Collections.Generic.ICollection<FPSWeaponViewModel> Weapons {
        get {
            return _WeaponsProperty;
        }
        set {
            _WeaponsProperty.Value = value.ToList();
        }
    }
    
    public virtual ICommand NextWeapon {
        get {
            return _NextWeapon;
        }
        set {
            _NextWeapon = value;
        }
    }
    
    public virtual ICommand PickupWeapon {
        get {
            return _PickupWeapon;
        }
        set {
            _PickupWeapon = value;
        }
    }
    
    public virtual ICommand PreviousWeapon {
        get {
            return _PreviousWeapon;
        }
        set {
            _PreviousWeapon = value;
        }
    }
    
    public virtual ICommand SelectWeapon {
        get {
            return _SelectWeapon;
        }
        set {
            _SelectWeapon = value;
        }
    }
}

[DiagramInfoAttribute("FPSShooter")]
public partial class FPSWeaponViewModel : ViewModel {
    
    public readonly P<System.Int32> _AmmoProperty = new P<int>();
    
    public readonly P<FPSWeaponState> _StateProperty = new P<FPSWeaponState>();
    
    public readonly P<System.Int32> _ZoomIndexProperty = new P<int>();
    
    public readonly P<System.Int32> _MaxZoomsProperty = new P<int>();
    
    public readonly P<WeaponType> _WeaponTypeProperty = new P<WeaponType>();
    
    public readonly P<System.Single> _ReloadTimeProperty = new P<float>();
    
    public readonly P<System.Int32> _RoundSizeProperty = new P<int>();
    
    public readonly P<System.Int32> _MinSpreadProperty = new P<int>();
    
    public readonly P<System.Int32> _BurstSizeProperty = new P<int>();
    
    public readonly P<System.Single> _SpreadProperty = new P<float>();
    
    public readonly P<System.Single> _RecoilSpeedProperty = new P<float>();
    
    public readonly P<System.Single> _FireSpeedProperty = new P<float>();
    
    public readonly P<System.Single> _BurstSpeedProperty = new P<float>();
    
    public readonly P<System.Single> _SpreadMultiplierProperty = new P<float>();
    
    private ICommand _BeginFire;
    
    private ICommand _NextZoom;
    
    private ICommand _Reload;
    
    private ICommand _EndFire;
    
    public virtual int Ammo {
        get {
            return _AmmoProperty.Value;
        }
        set {
            _AmmoProperty.Value = value;
        }
    }
    
    public virtual FPSWeaponState State {
        get {
            return _StateProperty.Value;
        }
        set {
            _StateProperty.Value = value;
        }
    }
    
    public virtual int ZoomIndex {
        get {
            return _ZoomIndexProperty.Value;
        }
        set {
            _ZoomIndexProperty.Value = value;
        }
    }
    
    public virtual int MaxZooms {
        get {
            return _MaxZoomsProperty.Value;
        }
        set {
            _MaxZoomsProperty.Value = value;
        }
    }
    
    public virtual WeaponType WeaponType {
        get {
            return _WeaponTypeProperty.Value;
        }
        set {
            _WeaponTypeProperty.Value = value;
        }
    }
    
    public virtual float ReloadTime {
        get {
            return _ReloadTimeProperty.Value;
        }
        set {
            _ReloadTimeProperty.Value = value;
        }
    }
    
    public virtual int RoundSize {
        get {
            return _RoundSizeProperty.Value;
        }
        set {
            _RoundSizeProperty.Value = value;
        }
    }
    
    public virtual int MinSpread {
        get {
            return _MinSpreadProperty.Value;
        }
        set {
            _MinSpreadProperty.Value = value;
        }
    }
    
    public virtual int BurstSize {
        get {
            return _BurstSizeProperty.Value;
        }
        set {
            _BurstSizeProperty.Value = value;
        }
    }
    
    public virtual float Spread {
        get {
            return _SpreadProperty.Value;
        }
        set {
            _SpreadProperty.Value = value;
        }
    }
    
    public virtual float RecoilSpeed {
        get {
            return _RecoilSpeedProperty.Value;
        }
        set {
            _RecoilSpeedProperty.Value = value;
        }
    }
    
    public virtual float FireSpeed {
        get {
            return _FireSpeedProperty.Value;
        }
        set {
            _FireSpeedProperty.Value = value;
        }
    }
    
    public virtual float BurstSpeed {
        get {
            return _BurstSpeedProperty.Value;
        }
        set {
            _BurstSpeedProperty.Value = value;
        }
    }
    
    public virtual float SpreadMultiplier {
        get {
            return _SpreadMultiplierProperty.Value;
        }
        set {
            _SpreadMultiplierProperty.Value = value;
        }
    }
    
    public virtual ICommand BeginFire {
        get {
            return _BeginFire;
        }
        set {
            _BeginFire = value;
        }
    }
    
    public virtual ICommand NextZoom {
        get {
            return _NextZoom;
        }
        set {
            _NextZoom = value;
        }
    }
    
    public virtual ICommand Reload {
        get {
            return _Reload;
        }
        set {
            _Reload = value;
        }
    }
    
    public virtual ICommand EndFire {
        get {
            return _EndFire;
        }
        set {
            _EndFire = value;
        }
    }
}

[DiagramInfoAttribute("FPSShooter")]
public partial class WavesFPSGameViewModel : FPSGameViewModel {
    
    public readonly P<System.Int32> _KillsToNextWaveProperty = new P<int>();
    
    public readonly P<System.Int32> _WaveKillsProperty = new P<int>();
    
    public readonly P<System.Int32> _CurrentWaveProperty = new P<int>();
    
    public virtual int KillsToNextWave {
        get {
            return _KillsToNextWaveProperty.Value;
        }
        set {
            _KillsToNextWaveProperty.Value = value;
        }
    }
    
    public virtual int WaveKills {
        get {
            return _WaveKillsProperty.Value;
        }
        set {
            _WaveKillsProperty.Value = value;
        }
    }
    
    public virtual int CurrentWave {
        get {
            return _CurrentWaveProperty.Value;
        }
        set {
            _CurrentWaveProperty.Value = value;
        }
    }
}

[DiagramInfoAttribute("FPSShooter")]
public partial class FPSMenuViewModel : ViewModel {
    
    private ICommand _Play;
    
    public virtual ICommand Play {
        get {
            return _Play;
        }
        set {
            _Play = value;
        }
    }
}

[DiagramInfoAttribute("FPSShooter")]
public partial class DeathMatchGameViewModel : FPSGameViewModel {
}
