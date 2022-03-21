package com.example.lab5;

import static android.provider.Telephony.Sms.Intents.getMessagesFromIntent;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.telephony.SmsMessage;
import android.util.Log;

import androidx.appcompat.app.AppCompatActivity;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

//Receiver class for receiving messages
public class MyReceiver extends BroadcastReceiver {

    public static String tag = "==MyReceiver==";
    public static String MSG = "MSG";
    public static String messageList = "";

    @Override
    public void onReceive(Context context, Intent intent) {
        Log.d(tag, "onReceive");
        // Pull the SmsMessage information from the intent
        // This is an array of messages
        SmsMessage[] messages = getMessagesFromIntent(intent);

        // Get the sender from the first message block
        String sender = messages[0].getOriginatingAddress();

        // Get the first message body text -
        String msg = messages[0].getMessageBody();

        // Log the message
        Log.d(tag, sender + " : " + msg);

        //Using Date class to get brodcast time
        Date formatted = Calendar.getInstance().getTime();
        // converting that time into string
        String makeTime = formatted.toString();

        // Prepare to launch the main activity
        Intent myIntent = new Intent(context,
                MainActivity.class);
        messageList = messageList + "Received ON: "+ makeTime + "\n"+ sender +" \n" +msg + "\n";

        myIntent.putExtra(MSG, messageList);



        // setting flags for the New Activity Flags
        //tried to play around with them ran into an error
        // didn't wont the activty to restart
        //tried to use fragments that didn't help

        myIntent.addFlags( Intent.FLAG_ACTIVITY_CLEAR_TASK
                | Intent.FLAG_ACTIVITY_CLEAR_TOP
               | Intent.FLAG_ACTIVITY_NEW_TASK  );

        context.startActivity(myIntent);


    }
}
