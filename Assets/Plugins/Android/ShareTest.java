package com.pythonbro.clientframe;
import android.content.Intent;
import android.net.Uri;
import android.content.Context;
public class ShareTest  {
	
    public static void share(Context ctx) {
		System.out.println("onshare:  " + ctx.getPackageName());
		String mAddress = "market://details?id=" + ctx.getPackageName();
		Intent marketIntent = new Intent("android.intent.action.VIEW");
		marketIntent.setData(Uri.parse(mAddress));
		ctx.startActivity(marketIntent);
    }
}