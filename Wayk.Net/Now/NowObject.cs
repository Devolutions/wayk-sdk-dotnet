namespace Devolutions.Wayk.Now
{
    using System;

    public abstract class NowObject : IDisposable
    {
        private static readonly NowNativeContextDictionary contexts = new NowNativeContextDictionary();

        public IntPtr Context { get; }

        protected NowObject(IntPtr context)
        {
            Context = context;

            contexts.Add(this);
        }

        public static implicit operator IntPtr(NowObject obj)
        {
            return obj.Context;
        }

        public static implicit operator NowObject(IntPtr context)
        {
            return contexts.TryGetValue(context, out var value) ? value : default;
        }

        public virtual void Dispose()
        {
            contexts.Remove(this);
        }
    }
}
