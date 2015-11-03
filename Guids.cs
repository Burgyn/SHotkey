// Guids.cs
// MUST match guids.h
using System;

namespace MMLib.SHotkey
{
    static class GuidList
    {
        public const string guidSHotkeyPkgString = "02078ebf-2c93-4560-be2d-caf994add48b";
        public const string guidSHotkeyCmdSetString = "7f7b71bb-4217-4167-abc8-88f9b4bedacd";
        public const string guidToolWindowPersistanceString = "92ae5bce-9492-4f9e-bfe7-a5732fa403a3";

        public static readonly Guid guidSHotkeyCmdSet = new Guid(guidSHotkeyCmdSetString);
    };
}