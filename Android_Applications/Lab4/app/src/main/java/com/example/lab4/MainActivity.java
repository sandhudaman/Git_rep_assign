/*I, Damanpreet Singh, 000741359 certify that this material is my original work. No
*   other person's work has been used without due acknowledgement.
*
*   Youtube Link: https://youtu.be/Ww90YNF_u9k
*/

package com.example.lab4;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.os.Bundle;
import android.util.Log;

public class MainActivity extends AppCompatActivity {

    private static final String TAG = "++MAIN ACTIVITY++";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // used fragment manager just to launch TopFragment
        //uses replace her as well although not required
        // rest of the code in Top fragment
        FragmentManager fm = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fm.beginTransaction();
        fragmentTransaction.replace(R.id.mainFrame, new Top());
        fragmentTransaction.commit();

        Log.d(TAG, "onCreate");


    }
}