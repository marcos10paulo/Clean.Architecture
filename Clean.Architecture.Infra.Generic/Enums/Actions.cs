using System.ComponentModel;

namespace Clean.Architecture.Infra.Generic.Enums
{
    public enum Actions
    {
        [Description("I")]
        Insert,
        [Description("U")]
        Update,
        [Description("D")]
        Delete
    }
}
