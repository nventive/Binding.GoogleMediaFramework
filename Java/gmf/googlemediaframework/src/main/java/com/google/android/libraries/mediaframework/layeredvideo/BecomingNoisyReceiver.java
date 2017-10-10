package com.google.android.libraries.mediaframework.layeredvideo;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.media.AudioManager;
import android.util.Log;

public class BecomingNoisyReceiver extends BroadcastReceiver
{
    private IBecomingNoisyReceiverListener _listener;

    public BecomingNoisyReceiver(IBecomingNoisyReceiverListener listener)
    {
        _listener = listener;
    }

    @Override
    public void onReceive(Context context, Intent intent)
    {
        if (_listener != null && AudioManager.ACTION_AUDIO_BECOMING_NOISY.equals(intent.getAction()))
        {
            _listener.onBecomingNoisy();
        }
    }

    public interface IBecomingNoisyReceiverListener
    {
        public void onBecomingNoisy();
    }
}
