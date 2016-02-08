package com.google.android.libraries.mediaframework.layeredvideo;

import android.view.LayoutInflater;
import android.view.View;
import android.widget.FrameLayout;
import android.widget.ImageButton;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.google.android.libraries.mediaframework.R;
import com.google.android.libraries.mediaframework.exoplayerextensions.ExoplayerWrapper;

/**
 * Creates a view for a loading state.
 */
public class ErrorLayer implements Layer  {

    /**
     * The retry button that the user can press to try again after an error occurred
     */
    private ImageButton retryButton;

    /**
     * The view that is created by this layer (it contains LoadingLayer#loading).
     */
    private FrameLayout view;

    @Override
    public FrameLayout createView(LayerManager layerManager) {
        LayoutInflater inflater = layerManager.getActivity().getLayoutInflater();

        view = (FrameLayout) inflater.inflate(R.layout.error_layer, null);

        return view;
    }

    @Override
    public void onLayerDisplayed(LayerManager layerManager) {

    }

    /**
     * Show or hide the error layer.
     * @param visibility One of {@link android.view.View#INVISIBLE},
     *                   {@link android.view.View#VISIBLE}, {@link android.view.View#GONE}.
     */
    public void setVisibility(int visibility) {
        view.setVisibility(visibility);
    }
}
