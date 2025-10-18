namespace Content.Server.Arcade.SpaceVillain;

public sealed partial class SpaceVillainGame
{
    /// <summary>
    /// A state holder for the fighters in the SpaceVillain game.
    /// </summary>
    public sealed class Fighter
    {
        /// <summary>
        /// The current hit point total of the fighter.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        public int Hp
        {
            get => _hp;
            set
            {
                if (Unlimited)
                {
                    _hp = MathHelper.Clamp(value, -9999, 9999);
                }
                else
                {
                    _hp = MathHelper.Clamp(value, 0, HpMax);
                }
            }
        }
        private int _hp;

        /// <summary>
        /// The maximum hit point total of the fighter.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        public int HpMax
        {
            get => _hpMax;
            set
            {
                _hpMax = Math.Max(value, 0);
                Hp = _hp;  // Re-clamp the HP value
            }
        }
        private int _hpMax;

        /// <summary>
        /// The current mana total of the fighter.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        public int Mp
        {
            get => _mp;
            set
            {
                if (Unlimited)
                {
                    _mp = MathHelper.Clamp(value, -9999, 9999);
                }
                else
                {
                    _mp = MathHelper.Clamp(value, 0, MpMax);
                }
            }
        }
        private int _mp;

        /// <summary>
        /// The maximum mana total of the fighter.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        public int MpMax
        {
            get => _mpMax;
            set
            {
                _mpMax = Math.Max(value, 0);
                Mp = _mp;  // Re-clamp the MP value
            }
        }
        private int _mpMax;

        /// <summary>
        /// Whether the given fighter can take damage/lose mana.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        public bool Invincible = false;

        /// <summary>
        /// Whether the given fighter can have unclamped health/mana.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        public bool Unlimited = false;
    }
}
