package com.example.lab4;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

//Top fragment class
public class Top extends Fragment implements View.OnClickListener{

    private String TAG = "++TOP ACTIVITY++";

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_top, container, false);

        // Initiating all the buttons for listner inside on clickview

        Button buttonSmall = v.findViewById(R.id.button2);
        buttonSmall.setOnClickListener(this::onClick);
        Button buttonMedium = v.findViewById(R.id.button);
        buttonMedium.setOnClickListener(this::onClick);
        Button buttonLarge = v.findViewById(R.id.button3);
        buttonLarge.setOnClickListener(this::onClick);

        return v;

    }
    //used fragment manger to get 3 different fragments
    // each fragment is replaced in specific buttons clicked
    @Override
    public void onClick(View v) {
        FragmentManager fm = getParentFragmentManager();
        FragmentTransaction fragmentTransaction = fm.beginTransaction();

        //clicking small button will call small fragment
        if (v.getId() == R.id.button2) {

            fragmentTransaction.replace(R.id.mainFrame2, new Small());
            fragmentTransaction.commit();
            Log.d(TAG, "onSmallClick");
        }
        //clicking medium button will call medium fragment
        else if (v.getId() == R.id.button) {
            fragmentTransaction.replace(R.id.mainFrame2, new Medium());
            fragmentTransaction.commit();
            Log.d(TAG, "onMediumClick");

        }
        //clicking large button will call Large fragment
        else if (v.getId() == R.id.button3) {
            fragmentTransaction.replace(R.id.mainFrame2, new Large());
            fragmentTransaction.commit();
            Log.d(TAG, "onLargeClick");

        }


    }
}