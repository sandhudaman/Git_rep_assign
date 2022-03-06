/**
 * I, Damanpreet Singh, 000741359 certify that this material is my original work.
 * No other person's work has been used without due
 * acknowledgement.
 */
/**
 * Link to Video:  https://youtu.be/32xTXwuvYQk
 */

package com.example.camohawksingh;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.text.Editable;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import java.util.Random;

public class MainActivity extends AppCompatActivity {

    // declaring rand to find a random no.
    Random rand = new Random();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // To capture Input
        EditText myInput = findViewById(R.id.editTextTextPersonName2);
        myInput.setText("");
        // To update Answer after user click RANDOM! button
        TextView myOutput = findViewById(R.id.textView2);
        myOutput.setText("");

    }

    /** nextRandom()
     *Function to check if integer is in a valid format using try Catch
     * try catch will catch all exceptions where no. is not interger Including any NULL value
     * if statement was used to send a message if no. is less than 1
     *
     * @param view is being used my methds such as findViewById
     */
    public void nextRandom(View view){

        EditText myInput = findViewById(R.id.editTextTextPersonName2);
        //capturing input as a variable to be used in function
        Editable ranGiven = myInput.getText();


        try {
            int ranNum = Integer.parseInt(String.valueOf(ranGiven));
            // if and else statement to check for 0 as an input

            if (ranNum > 0){
                int result = rand.nextInt(ranNum );
                TextView myOutput = findViewById(R.id.textView2);
                myOutput.setText(String.valueOf(result + 1));
            }

            else{
                TextView myOutput = findViewById(R.id.textView2);
                myOutput.setText("Please Enter a Number Greater Than 0");
            }

        }
        catch (NumberFormatException e){
            TextView myOutput = findViewById(R.id.textView2);
            myOutput.setText("Invalid! Please Enter an Integer");

        }
    }

}