package com.pythonbro.clientframe;

import android.app.Activity;
import android.content.Intent;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import android.widget.Toast;

import com.pythonbro.clientframe.util.IabHelper;
import com.pythonbro.clientframe.util.IabResult;
import com.pythonbro.clientframe.util.Inventory;
import com.pythonbro.clientframe.util.Purchase;
import com.pythonbro.clientframe.util.Security;

import org.json.JSONObject;

public class GoogleSDK {

    private static GoogleSDK instance;
    private String base64EncodedPublic;
    private IabHelper mHelper;
    private String productId;
    private boolean isGooglePlaySetup = false;

    private String LogTag = "GoogleLog";
    private Activity mainActivity;
    private final int requestID = 10001;
    private String extension;
    Handler mainHandler;

    private GoogleSDK(){

    }

    public static GoogleSDK getInstance(){
        if (instance == null){
            instance = new GoogleSDK();
        }
        return instance;
    }

    public void Init(Activity activity){
        mainActivity = activity;
        mainHandler = new Handler(Looper.getMainLooper());
        base64EncodedPublic = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA" +
                "nNMYrcGiqxupwhlqAamcLJtct1ZSlp+AmeEhgzYKGvK2eF3j96nx/Z82ekoUEXNqZLva37Kr9Rlq+3x5JhOkEd38+dUPvO8klKX1ByxGIk/2S2Lm9uM6DqgTyK4QqI8lJSnCsj6jzii/XWgEZXYVnD/G22AW1fbf+bsWxO+NPXd1wMjgFvC948PZFAyWoJVy8rk6k/9WtSVtVcr1E9fIgD8aAiAdMa2Ov8Ysb6cbaMNOYe6QBePVAkFwMFWB6U5Z0D/PYefBdVLLvFBFeLTopc0JM09+vlHR0OyOqz4BcZy7GOIDDN5rtoa8iy2zGYnZ96ZIZvYMdRSAbENzrvPBLQIDAQAB";
        mHelper = new IabHelper(mainActivity, base64EncodedPublic);
        GooglePaySetUp(new SetupCallback() {
            @Override
            public void onSuccess() {
                isGooglePlaySetup = true;
                Log.d(LogTag, "google play init success!");
            }

            @Override
            public void onFailed() {
                Log.d(LogTag, "google play init failed!");

            }
        });
        mHelper.enableDebugLogging(true, LogTag);
    }

    public void GooglePaySetUp(final SetupCallback callback) {
        if (mHelper == null) {
            callback.onFailed();
            return;
        }

        mHelper.startSetup(new IabHelper.OnIabSetupFinishedListener() {
            @Override
            public void onIabSetupFinished(IabResult result) {

                // TODO Auto-generated method stub
                if (!result.isSuccess()) {
                    Log.d(LogTag, "mHelper startSetup fail! " + result);
                    callback.onFailed();
                    return;
                }

                // ???????????????
                callback.onSuccess();

            }
        });
    }

    public void Pay(String productId , String extension){
        mainHandler.post(new Runnable() {
            @Override
            public void run() {
                if (!isGooglePlaySetup) {
                    GooglePaySetUp(new SetupCallback() {

                        @Override
                        public void onSuccess() {
                            isGooglePlaySetup = true;
                            QueryList();
                        }

                        @Override
                        public void onFailed() {

                            Log.d(LogTag, "Pay failed: Setup! callback");

                        }
                    });
                    return;
                }
                QueryList();
            }
        });

    }

    public void QueryList(){
        try {
            Log.d(LogTag, "Setup successful. ??????????????????.");
            mHelper.queryInventoryAsync(mQueryFinishedListener);
        }catch (Exception e){
            e.printStackTrace();
        }
    }

    // ????????????????????????????????????
    IabHelper.QueryInventoryFinishedListener mQueryFinishedListener = new IabHelper.QueryInventoryFinishedListener() {
        @Override
        public void onQueryInventoryFinished(IabResult result, Inventory inventory) {
            Log.d(LogTag, "????????????????????????.");

            // Have we been disposed of in the meantime? If so, quit.
            if (mHelper == null)
                return;

            // Is it a failure?
            if (result.isFailure()) {
                Log.d(LogTag, "Pay failed:query inventory! callback, Result: " + result);
//                try {
//                    Purchase purchase = new Purchase("inapp", "{\"packageName\":\"com.pythonbro.clientframe\","+
//                            "\"orderId\":\"transactionId.android.test.purchased\","+
//                            "\"productId\":\"android.test.purchased\",\"developerPayload\":\"orderId\",\"purchaseTime\":0,"+
//                            "\"purchaseState\":0,\"purchaseToken\":\"inapp:com.pythonbro.clientframe:android.test.purchased\"}",
//                            "");
//                    mHelper.consumeAsync(purchase, null);
//                } catch (Exception e) {
//                    e.printStackTrace();
//                }

                return;
            }
            Log.d(LogTag, "????????????????????????.");

            // ???????????????SKU_GAS?????????????????????????????????????????????????????????????????????
            Purchase gasPurchase = inventory.getPurchase(productId);

            if (gasPurchase != null ) {
                Log.d(LogTag, "We have gas. Consuming it.");
                try {
                    mHelper.consumeAsync(inventory.getPurchase(productId), mConsumeFinishedListener);
                } catch (IabHelper.IabAsyncInProgressException e) {
                    e.printStackTrace();
                }
                return;
            }
            Log.d(LogTag, "???????????????????????????.");
            // ????????????
            try {
                mHelper.launchPurchaseFlow(mainActivity, productId, requestID, mPurchaseFinishedListener, extension);
            } catch (IabHelper.IabAsyncInProgressException e) {
                e.printStackTrace();
            }
        }
    };

    // Callback ????????????
    IabHelper.OnIabPurchaseFinishedListener mPurchaseFinishedListener = new IabHelper.OnIabPurchaseFinishedListener() {
        @Override
        public void onIabPurchaseFinished(IabResult result, Purchase info) {
            Log.d(LogTag, "Purchase finished: " + result + ", purchase: " + info);
            if (mHelper == null)
                return;
            // TODO Auto-generated method stub
            if (result.isFailure()) {
                Log.d(LogTag, "Pay failed:purchase! callback");
                Log.d(LogTag, "???????????????");
                return;
            }

            if (info.getSku().equals(productId)) {
                // bought 1/4 tank of gas. So consume it.
                Log.d(LogTag, "Purchase is ?????????. ?????????.");
                try {
                    mHelper.consumeAsync(info, mConsumeFinishedListener);
                } catch (IabHelper.IabAsyncInProgressException e) {
                    e.printStackTrace();
                }
            }
        }
    };

    // ?????????????????????
    IabHelper.OnConsumeFinishedListener mConsumeFinishedListener = new IabHelper.OnConsumeFinishedListener() {
        public void onConsumeFinished(Purchase purchase, IabResult result) {
            Log.d(LogTag, "????????????. Purchase: " + purchase + ", result: " + result);

            // if we were disposed of in the meantime, quit.
            if (mHelper == null)
                return;

            if (result.isSuccess()) {

                Log.d(LogTag, "????????????. Provisioning.");
                String purchaseData = purchase.getPurchaseData();
                String dataSignature = purchase.getSignature();

                Log.d(LogTag, "Purchase successful.");

                final JSONObject json = new JSONObject();
                try {
                    json.put("purchaseData", purchaseData);
                    json.put("dataSignature", dataSignature);
                    json.put("orderId", extension);
                } catch (Exception e) {
                    e.printStackTrace();
                }
                Runnable runnable = new Runnable() {
                    @Override
                    public void run() {
//                        String payCallback = HttpUtils.httpPost(callBackUrl, json.toString(), 10, 10, false);
//                        if (payCallback != null && payCallback.length() != 0) {
//                            Log.d(LogTag, "pay result sent success!");
//                        }
                        // TODO Auto-generated method stub

                    }
                };
                new Thread(runnable).start();
                Log.d(LogTag, "Pay success! callback");
                boolean isSucces = Security.verifyPurchase(base64EncodedPublic, purchaseData, dataSignature);
                Toast.makeText(mainActivity, "Pay Success!", Toast.LENGTH_LONG).show();
            } else {
                Log.d(LogTag, "Error while consuming: " + result);
                Log.d(LogTag, "Pay failed:purchase! callback");
            }
            Log.d(LogTag, "End consumption flow.");
        }
    };

    public void SetCallback(int requestCode, int resultCode, Intent data){
        if (mHelper == null){
            return;
        }
        mHelper.handleActivityResult(requestCode, resultCode, data);
    }

    public void OnDestroy()
    {
        if(mHelper != null){
            mHelper.disposeWhenFinished();
            mHelper = null;
        }
    }

    public interface SetupCallback{
        public void onSuccess();
        public void onFailed();
    }
}
