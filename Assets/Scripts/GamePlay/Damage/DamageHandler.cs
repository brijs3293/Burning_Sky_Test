using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EA.BurningSky.Gameplay
{
    public class DamageHandler : MonoBehaviour
    {
        static Dictionary<int, IDamagable> _registerOfAllDamagables = new Dictionary<int, IDamagable>();

        public static void RegisterDamagable(int hashCode, IDamagable damagable)
        {
            if (!_registerOfAllDamagables.ContainsKey(hashCode))
            {
                _registerOfAllDamagables.Add(hashCode, damagable);
            }
        }

        public static void UnRegisterDamagable(int hashCode)
        {
            _registerOfAllDamagables.Remove(hashCode);
        }

        public static void Damage(int hashCode, float damage)
        {
            if (_registerOfAllDamagables.TryGetValue(hashCode, out var damagable))
            {
                damagable.Damage(damage);
            }
        }
    }
}
