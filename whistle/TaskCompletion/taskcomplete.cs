using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace whistle.TaskCompletion
{
    public class taskcomplete : Java.Lang.Object, IOnSuccessListener, IOnFailureListener
    {
        public event EventHandler<TaskSuccessEventArgs> Success;
        public event EventHandler<TaskCompletionListenerFailureEventArgs> Failure;
        public void OnFailure(Java.Lang.Exception e)
        {
            Failure?.Invoke(this, new TaskCompletionListenerFailureEventArgs { Cause = e.Message });
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            Success?.Invoke(this, new TaskSuccessEventArgs { Result = result});
        }

        public class TaskSuccessEventArgs : EventArgs 
        {
            public Java.Lang.Object Result { get; set; }
        }

        public class TaskCompletionListenerFailureEventArgs : EventArgs
        {
            public string Cause { get; set; }
        }
    }
}