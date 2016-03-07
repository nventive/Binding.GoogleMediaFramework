package com.google.android.libraries.mediaframework.layeredvideo;

import android.graphics.Color;
import android.graphics.PorterDuff;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.FrameLayout;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.google.android.libraries.mediaframework.R;
import com.google.android.libraries.mediaframework.exoplayerextensions.ExoplayerWrapper;

/**
 * Creates a view for a loading state.
 */
public class LoadingLayer implements Layer  {

    /**
     * The progress bar that will be displayed.
     */
    private ProgressBar loading;

    /**
     * The color of the progress bar
     */
    private int loadingColor = Color.WHITE;
    /**
     * The view that is created by this layer (it contains LoadingLayer#loading).
     */
    private FrameLayout view;

    @Override
    public FrameLayout createView(LayerManager layerManager) {
        LayoutInflater inflater = layerManager.getActivity().getLayoutInflater();

        view = (FrameLayout) inflater.inflate(R.layout.loading_layer, null);
        loading = (ProgressBar)view.findViewById(R.id.loading);
        UpdateColors();
        return view;
    }

    @Override
    public void onLayerDisplayed(LayerManager layerManager) {

    }

    public void setLoadingColor(int color) {
        this.loadingColor = color;
        if (loading != null) {
            UpdateColors();
        }
    }

    private void UpdateColors() {
        loading.getIndeterminateDrawable().setColorFilter(loadingColor, PorterDuff.Mode.SRC_IN);
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
