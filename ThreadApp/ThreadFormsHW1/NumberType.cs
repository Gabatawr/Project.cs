using System;
using System.ComponentModel;
using System.Threading;

namespace ThreadFormsHW1
{
    public abstract class NumberType
    {
        //---------------------------------------------------------------------
        protected bool _stopped;
        protected Thread _thread;
        protected readonly SynchronizationContext _syncContext;
        //---------------------------------------------------------------------
        public event EventHandler<Response> Callback;
        //---------------------------------------------------------------------
        protected NumberType() => _syncContext = AsyncOperationManager.SynchronizationContext;
        //---------------------------------------------------------------------
        protected void _trigger(Response response) => Callback?.Invoke(this, response);
        virtual protected void _generate(object obj)
        {
            throw new NotImplementedException();
        }
        //---------------------------------------------------------------------
        public void Start(object obj)
        {
            _thread = new(_generate);
            _thread.IsBackground = true;
            _thread.Start(obj);

            _stopped = false;
        }
        public void Stop()
        {
            if (_thread != null && _thread.IsAlive)
            {
                try { _thread.Abort(); }
                catch (Exception) { }
            }
            _stopped = true;
        }
        //---------------------------------------------------------------------
        public void Pause()
        {
            if (_thread != null && _thread.IsAlive)
            {
                try { _thread.Suspend(); }
                catch (Exception) { }
            }
        }
        public void Resume()
        {
            if (_thread != null && _thread.ThreadState == ThreadState.Suspended)
            {
                try { _thread.Resume(); }
                catch (Exception) { }
            }
        }
        //---------------------------------------------------------------------
    }
}
