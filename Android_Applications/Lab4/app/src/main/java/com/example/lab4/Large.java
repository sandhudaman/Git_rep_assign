package com.example.lab4;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;


public class Large extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v =inflater.inflate(R.layout.fragment_large, container, false);

        EditText myInput = getActivity().findViewById(R.id.editTextTextPersonName);
        String  name = myInput.getText().toString();

        TextView tView = v.findViewById(R.id.textView2);
        tView.setText(name);

        return v;
    }
}