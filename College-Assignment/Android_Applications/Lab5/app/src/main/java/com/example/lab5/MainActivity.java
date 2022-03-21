/* I, Damanpreet Singh, 000741359 certify that this material is my original work. No
other person's work has been used without due acknowledgement.
video : https://youtu.be/Xk-8C6FdCEA
* */


package com.example.lab5;


import androidx.activity.result.ActivityResultLauncher;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import com.google.android.material.snackbar.BaseTransientBottomBar;
import com.google.android.material.snackbar.Snackbar;

public class MainActivity extends AppCompatActivity  {

    public static String TAG = "==MyReceiver==";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Ask for permission (SDK >= 23) when app starts
        ActivityCompat.requestPermissions(this,
            new String[]{Manifest.permission.RECEIVE_SMS}, 1);

        //Fragment manager for message clipboard text
        //could have been done in different ways i choose this one

        FragmentManager fm = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fm.beginTransaction();
        fragmentTransaction.replace(R.id.frame1, new fragOne());
        fragmentTransaction.commit();
        Log.d(TAG, "Frag Created");

        //getting clipboard from message brodcaster
        Intent myIntent = getIntent();
        String msg = myIntent.getStringExtra(MyReceiver.MSG);
        TextView tv = findViewById(R.id.msgview);
        tv.setText(msg);


    }

    //method is called whenever a prompt is required for permission
    private void askPermission(View view){
        ActivityCompat.requestPermissions(this,
                new String[]{Manifest.permission.RECEIVE_SMS}, 1);


    }

    //permission result method used to check is permission was granted
    @Override
    public void onRequestPermissionsResult(int resultCode,
                                           String permissions[], int[] results ) {
        super.onRequestPermissionsResult(resultCode, permissions, results);
        Log.d(TAG, "onRequestPermissionsResult " + resultCode);
        View parentLayout = findViewById(android.R.id.content);
        if (resultCode == 1) {
                if (results.length > 0 && results[0] ==
                        PackageManager.PERMISSION_GRANTED) {
                    Log.d(TAG, "User agreed to SMS perms");
                    onDialogue(parentLayout);

                } else {
                    Log.d(TAG, "User *DENIED* SMS perms");
                    onDialogue(parentLayout);

            }
        }
    }

    // method to create snackbar if permission was denied
    // or ask user if he would like to quit
    public void onDialogue(View v) {

        // SnackBars support the duration "LENGHT_INDEFINITE"
        Snackbar snackBar = Snackbar.make(v,"", Snackbar.LENGTH_INDEFINITE);
        snackBar.setBackgroundTint(Color.rgb(200,0,100));

        if (ActivityCompat.checkSelfPermission(this,
                Manifest.permission.RECEIVE_SMS) !=
                PackageManager.PERMISSION_GRANTED) {
            // Get the inflater for the current activity's view
            LayoutInflater inflater = getLayoutInflater();
            // inflate the custom_snackbar_view created previously
            View customSnackView = inflater.inflate(R.layout.snacklayout, null);
            // we perform a tricky cast. SnackBar.getView() returns a view,
            // but we can interpret it as a ViewGroup. We need this to
            // be able to modify it by calling addView, a ViewGroup method.
            ViewGroup snackbarLayout = (ViewGroup) snackBar.getView();
            // Makes a border around the layout
            snackbarLayout.setPadding(25, 25, 25, 25);
            // add the custom snack bar layout to snackbar layout
            snackbarLayout.addView(customSnackView, 0);
            snackBar.show();
            // register the button from the custom_snackbar_view layout file
            Button bsnack1 = customSnackView.findViewById(R.id.button);
            bsnack1.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    snackBar.dismiss();
                    askPermission(v);
                }
            });
            // register the button from the custom_snackbar_view layout file
            Button bsnack2 = customSnackView.findViewById(R.id.button2);
            bsnack2.setOnClickListener(this::onQuitClick);

        }
        else{
            snackBar.dismiss();
            }

        }

        //if user clicks on quit in snackbar this method will be called
    private void onQuitClick(View view) {
        finish();
        System.exit(0);

    }

}





