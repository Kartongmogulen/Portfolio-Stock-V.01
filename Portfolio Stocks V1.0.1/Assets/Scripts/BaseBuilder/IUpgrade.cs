using UnityEngine;

    public interface IUpgrade
    {
        string UpgradeType { get; }
        int _level { get; } 
        void ApplyUpgrade();
    }

