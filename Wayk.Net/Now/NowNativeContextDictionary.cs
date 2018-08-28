namespace Devolutions.Wayk.Now
{
    using System;
    using System.Collections.Generic;

    internal class NowNativeContextDictionary : Dictionary<IntPtr, NowObject>
    {
        public void Add(NowObject obj)
        {
            Add(obj.Context, obj);
        }
    }
}