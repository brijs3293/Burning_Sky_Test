using System.Collections.Generic;
using UnityEngine;

namespace BurningSky.Gameplay
{
    /// <summary>
    /// A common register for all objects which can be damaged. This register is created to transfer responsibility of damage. 
    /// Secondly it provides better performance as every time when bullet hits Getcomponent is not called as all the IDamagable are registered here so just has to search rather getting component
    /// </summary>
    public class DamageHandler
    {
        #region Variables

        static readonly Dictionary<int, IDamagable> _registerOfAllDamagables = new Dictionary<int, IDamagable>();

        #endregion

        #region Public_Methods

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
        #endregion
    }
}
