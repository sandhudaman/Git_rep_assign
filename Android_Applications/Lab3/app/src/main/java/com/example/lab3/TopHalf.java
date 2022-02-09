package com.example.lab3;

import android.app.AppComponentFactory;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;


public class TopHalf extends Fragment  {

    public final String tag = "==MainActivity==";

    public TopHalf() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_top_half, container, false);


        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_top_half, container, false);


    }


}