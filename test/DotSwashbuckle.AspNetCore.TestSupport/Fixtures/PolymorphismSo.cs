namespace DotSwashbuckle.AspNetCore.TestSupport.Fixtures
{
    /// <summary>
    /// Represents the type of <see cref="WitnessCondition"/>.
    /// </summary>
    public enum WitnessConditionType : byte
    {
        /// <summary>
        /// Indicates that the condition will always be met or not met.
        /// </summary>
        Boolean = 0x00,

        /// <summary>
        /// Reverse another condition.
        /// </summary>
        Not = 0x01,

        /// <summary>
        /// Indicates that all conditions must be met.
        /// </summary>
        And = 0x02,

        /// <summary>
        /// Indicates that any of the conditions meets.
        /// </summary>
        Or = 0x03,

        /// <summary>
        /// Indicates that the condition is met when the current context has the specified script hash.
        /// </summary>
        ScriptHash = 0x18,

        /// <summary>
        /// Indicates that the condition is met when the current context has the specified group.
        /// </summary>
        Group = 0x19,

        /// <summary>
        /// Indicates that the condition is met when the current context is the entry point or is called by the entry point.
        /// </summary>
        CalledByEntry = 0x20,

        /// <summary>
        /// Indicates that the condition is met when the current context is called by the specified contract.
        /// </summary>
        CalledByContract = 0x28,

        /// <summary>
        /// Indicates that the condition is met when the current context is called by the specified group.
        /// </summary>
        CalledByGroup = 0x29
    }

    public abstract class WitnessConditionModel
    {
        public abstract WitnessConditionType Type { get; }
    }

    public class AndConditionModel : WitnessConditionModel
    {
        public WitnessConditionModel[] Expressions { get; set; }
        public override WitnessConditionType Type => WitnessConditionType.And;
    }

    public class OrConditionModel : WitnessConditionModel
    {
        public WitnessConditionModel[] Expressions { get; set; }
        public override WitnessConditionType Type => WitnessConditionType.Or;
    }

    public class GroupConditionModel : WitnessConditionModel
    {
        public string Group { get; set; }
        public override WitnessConditionType Type => WitnessConditionType.Group;
    }
}
