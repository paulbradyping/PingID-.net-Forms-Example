using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Diagnostics;


namespace PingIDAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // public static string org_alias = "<< org_alias value from pingid.properties file >>";
        // public static string use_base64_key = "<< use_base64_key value from pingid.properties file >>";
        // public static string token = "<< token value from pingid.properties file >>";
        // public static string api_version = "4.6";

        public static string org_alias = "";
        public static string use_base64_key = "<< use_base64_key value from pingid.properties file >>";
        public static string token = "<< token value from pingid.properties file >>";
        public static string api_version = "4.6";
        public static string deviceID = "";
        public static string sessionID = "";
        public static string AuthsessionId = "";
        public static string devicefound = "";
        public static string OTPValue = "";
        public static string NewDeviceID = "";
        public static string NewDeviceType = "";
        public static string AddnewDevice = "0";






        public static string Base64UrlEncodeString(string rawString)
        {
            return Base64UrlEncodeString(Encoding.UTF8.GetBytes(rawString));
        }

        public static string Base64UrlEncodeString(byte[] rawBytes)
        {
            var encodedString = Convert.ToBase64String(rawBytes);

            encodedString = encodedString.Replace('+', '-');
            encodedString = encodedString.Replace('/', '_');
            encodedString = encodedString.TrimEnd(new char[] { '=' });

            return encodedString;
        }

        public static byte[] Base64UrlDecodeString(string encodedString)
        {
            encodedString = encodedString.Replace('-', '+');
            encodedString = encodedString.Replace('_', '/');
            encodedString = encodedString.PadRight(encodedString.Length + (4 - encodedString.Length % 4) % 4, '=');

            return Convert.FromBase64String(encodedString);
        }

        public static string DictionaryToJsonString(Dictionary<string, object> dictionary)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(dictionary);
        }

        public static string sendToken(Dictionary<string, object> requestBody, string apiEndpoint)
        {


            Dictionary<string, object> jwtHeader = new Dictionary<string, object>();
            jwtHeader.Add("alg", "HS256");
            jwtHeader.Add("org_alias", org_alias);
            jwtHeader.Add("token", token);

            var headerSerialized = DictionaryToJsonString(jwtHeader);
            var headerEncoded = Base64UrlEncodeString(headerSerialized);

            Dictionary<string, object> reqHeaderClaims = new Dictionary<string, object>();
            reqHeaderClaims.Add("locale", "en");
            reqHeaderClaims.Add("orgAlias", org_alias);
            reqHeaderClaims.Add("secretKey", token);
            reqHeaderClaims.Add("timestamp", DateTime.UtcNow);
            reqHeaderClaims.Add("version", api_version);

            Dictionary<string, object> jwtPayload = new Dictionary<string, object>();
            jwtPayload.Add("reqHeader", reqHeaderClaims);
            jwtPayload.Add("reqBody", requestBody);

            var payloadSerialized = DictionaryToJsonString(jwtPayload);
            var payloadEncoded = Base64UrlEncodeString(payloadSerialized);

            var signedComponents = String.Join(".", headerEncoded, payloadEncoded);

            var HMAC = new HMACSHA256(Base64UrlDecodeString(use_base64_key));
            var signatureBytes = HMAC.ComputeHash(Encoding.UTF8.GetBytes(signedComponents));
            var signatureEncoded = Base64UrlEncodeString(signatureBytes);

            var apiToken = String.Join(".", signedComponents, signatureEncoded);

            // Send the JWS

            var response = HttpPost(apiEndpoint, apiToken);

            return response;

        }

        public static string HttpPost(string URI, string jwt)
        {
            WebRequest webRequest = WebRequest.Create(URI);

            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";
            byte[] payload = Encoding.UTF8.GetBytes(jwt);
            webRequest.ContentLength = payload.Length;

            Stream outputStream = webRequest.GetRequestStream();
            outputStream.Write(payload, 0, payload.Length);
            outputStream.Close();
            try
            {
                WebResponse webResponse = webRequest.GetResponse();


                if (webResponse == null) return null;

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();

            }
            catch (WebException e)
            {

                StreamReader sr = new StreamReader(e.Response.GetResponseStream());


                MessageBox.Show(sr.ReadToEnd(), "Error Message Returned Click In Message Box and hit CTRL C Use JWT.io to read the errror ", MessageBoxButtons.OK);

            }
            return "hi";


        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {


                if (textBox1.Text == "") throw new ApplicationException();
                richTextBox1.Clear();
                org_alias = textBox2.Text;
                use_base64_key = textBox3.Text;
                token = textBox4.Text;
                api_version = textBox5.Text;

                Dictionary<string, object> reqBody = new Dictionary<string, object>();
                reqBody.Add("userName", textBox1.Text);
                reqBody.Add("getSameDeviceUsers", false);

                var apiEndpoint = "https://idpxnyl3m.pingidentity.com/pingid/rest/4/getuserdetails/do";

                string apiResponse = sendToken(reqBody, apiEndpoint);

                string[] responseComponents = apiResponse.Split(new char[] { '.' });

                string responsePayload = responseComponents[1];
                string responsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(responsePayload));

                //Dump the payload all of it into the richtext box just so you can see it. 
                StartAuth1.Enabled = true;


                richTextBox1.AppendText("PayLoad: " + "\n" + responsePayloadDecoded);

                GetDevices.Visible = true;


            }
            catch
            {
                if (textBox1.Text == "") MessageBox.Show("You Must Enter the Name of a User registered in PingOne ");




            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            org_alias = textBox2.Text;
            use_base64_key = textBox3.Text;
            token = textBox4.Text;
            api_version = textBox5.Text;

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            org_alias = textBox2.Text;
            use_base64_key = textBox3.Text;
            token = textBox4.Text;
            api_version = textBox5.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
            
           
            openFileDialog1.ShowDialog();

            string infile = openFileDialog1.FileName.ToString();
            string inline = "";
            
            StreamReader readinfile = new StreamReader(infile);

            while ((inline = readinfile.ReadLine()) != null)
                
            {
                
                //org_alias = inline.Substring(inline.IndexOf("id=[",6 ));
                if (inline.Contains("org_alias"))
                {
                    org_alias = inline.Substring(inline.IndexOf("org_alias=") + 10);
                }

                if (inline.Contains("use_base64_key"))
                {
                    //use_base64_key = inline.Substring(inline.IndexOf("use_base64_key=") + 15, (inline.IndexOf(("email =[") + 7) - inline.IndexOf(("]"))));
                    use_base64_key = inline.Substring(inline.IndexOf("use_base64_key=") + 15);

                }

                if (inline.Contains("token"))
                {

                    token = inline.Substring(inline.IndexOf("token=") + 6);

                }

            }

            textBox2.Text = org_alias;
            textBox3.Text = use_base64_key;
            textBox4.Text = token;

            GetUserInfo.Enabled = true;
                textBox1.Enabled = true;
                btn_addDevice.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;



            }

            catch
            {

                MessageBox.Show("Something went wrong with the PingID prop file file???");

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {




                org_alias = textBox2.Text;
                use_base64_key = textBox3.Text;
                token = textBox4.Text;
                api_version = textBox5.Text;



                // for the authenticate these are all the parameters needed in the request body
                //
                Dictionary<string, object> reqBody = new Dictionary<string, object>();


                reqBody.Add("spAlias", "web");

                // set the device id to be used for

                reqBody.Add("deviceId", devicefound);

                // the user name to send the auth to 

                reqBody.Add("userName", textBox1.Text);

                // reqBody.Add("sessionId", AuthsessionId);


                var apiEndpoint = "https://idpxnyl3m.pingidentity.com/pingid/rest/4/startauthentication/do";


                string apiResponse = sendToken(reqBody, apiEndpoint);

                string[] responseComponents = apiResponse.Split(new char[] { '.' });

                string responsePayload = responseComponents[1];
                string responsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(responsePayload));


                richTextBox1.Clear();

                richTextBox1.Refresh();

                richTextBox1.AppendText("PayLoad: " + "\n" + responsePayloadDecoded);

                panel2.Visible = false;


                StartAuth2.Enabled = true;

                // show the button to authenticate

                AuthOnline.Visible = true;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {


            try
            {

                // we need to get a couple values that came from the get user. 
                // in this demo it is just reading the value of the rich text box and find the data. 
                // deviceID

                // some string stuff this too could be done better. But for the demo it works. 

                //string devicefound = "";
                //string searchfor = richTextBox1.Text.ToString();

                //devicefound = searchfor.Substring(searchfor.IndexOf("deviceId", 10));
                //devicefound = devicefound.Substring(0, devicefound.IndexOf(","));
                //devicefound = devicefound.Substring(devicefound.IndexOf(":") + 1);


                // I am setting this in each control but you could do it one and reuse this.. again this is 
                // just a sample 
                org_alias = textBox2.Text;
                use_base64_key = textBox3.Text;
                token = textBox4.Text;
                api_version = textBox5.Text;

                Dictionary<string, object> AuthreqBody = new Dictionary<string, object>();

                // AuthreqBody.Add("userName", textBox1.Text);

                AuthreqBody.Add("spAlias", "web");

                // set the device id to be used for

                AuthreqBody.Add("deviceId", devicefound);

                // the user name to send the auth to 

                AuthreqBody.Add("userName", textBox1.Text);

                var AuthapiEndpoint = "https://idpxnyl3m.pingidentity.com/pingid/rest/4/startauthentication/do";

                string AuthapiResponse = sendToken(AuthreqBody, AuthapiEndpoint);

                string[] AuthresponseComponents = AuthapiResponse.Split(new char[] { '.' });

                string AuthresponsePayload = AuthresponseComponents[1];
                string AuthresponsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(AuthresponsePayload));

                // get the session id out of the 1st auth response above. 


                AuthsessionId = AuthresponsePayloadDecoded.Substring(AuthresponsePayloadDecoded.IndexOf("sessionId", 10));

                AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.IndexOf(","));

                AuthsessionId = AuthsessionId.Substring(AuthsessionId.IndexOf(":") + 2);

                AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.Length - 1);

                richTextBox1.Clear();

                richTextBox1.Refresh();

                richTextBox1.AppendText("PayLoad: " + "\n" + AuthresponsePayloadDecoded);

                groupBox3.Enabled = true;

            }

            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                // we need to get a couple values that came from the get user. 
                // in this demo it is just reading the value of the rich text box and find the data. 
                // deviceID
                //"PayLoad: \n{\"responseBody\":{\"sameDeviceUsersDetails\":[],\"userDetails\":{\"lastTransactions\":[],\"devicesDetails\":[{\"nickname\":\"iPhone 5S\",\"sentNotClaimedSms\":-1,\"availableClaimedSms\":0,\"pushEnabled\":true,\"displayID\":\"iPhone 5S\",\"enrollment\":\"2016-03-28 14:39:26.217\",\"sentClaimedSms\":-1,\"availableNotClaimedSms\":0,\"deviceModel\":\"iPhone 5S\",\"countryCode\":null,\"deviceId\":187835,\"deviceUuid\":null,\"appVersion\":\"1.7(943)\",\"deviceRole\":\"PRIMARY\",\"hasWatch\":false,\"phoneNumber\":null,\"email\":null,\"osVersion\":\"9.3.5\",\"type\":\"iPhone\"}],\"picURL\":\"PHF5Q77RUYQDSNVXTB47JLJR2EEXSFQBTPTDFNMQHDCAJH3H6L5EDAI=\",\"spList\":[{\"spAlias\":\"pingone\",\"bypassExpiration\":null,\"spName\":\"SSO\",\"status\":\"ACTIVE\"},{\"spAlias\":\"vpn\",\"bypassExpiration\":null,\"spName\":\"VPN\",\"status\":\"ACTIVE\"}],\"lastLogin\":1474037590000,\"bypassExpiration\":null,\"deviceDetails\":{\"nickname\":\"iPhone 5S\",\"sentNotClaimedSms\":-1,\"availableClaimedSms\":0,\"pushEnabled\":true,\"displayID\":\"iPhone 5S\",\"enrollment\":\"2016-03-28 14:39:26.217\",\"sentClaimedSms\":-1,\"availableNotClaimedSms\":0,\"deviceModel\":\"iPhone 5S\",\"countryCode\":null,\"deviceId\":187835,\"deviceUuid\":null,\"appVersion\":\"1.7(943)\",\"deviceRole\":\"PRIMARY\",\"hasWatch\":false,\"phoneNumber\":null,\"email\":null,\"osVersion\":\"9.3.5\",\"type\":\"iPhone\"},\"userEnabled\":true,\"fname\":\"New\",\"userId\":6461158,\"userInBypass\":false,\"email\":\"paulbrady+newuser@pingidentity.com\",\"lname\":\"User\",\"status\":\"ACTIVE\",\"userName\":\"newuser\",\"role\":\"REGULAR\"},\"uniqueMsgId\":\"webs_26jtge4IpchTYiHqcYF8zsH6e0Bw3YDujZwpYxGBUt4\",\"errorId\":200,\"errorMsg\":\"ok\",\"clientData\":null}}"

                org_alias = textBox2.Text;
                use_base64_key = textBox3.Text;
                token = textBox4.Text;
                api_version = textBox5.Text;

                Dictionary<string, object> AuthOnlinereqBody = new Dictionary<string, object>();

                // AuthreqBody.Add("userName", textBox1.Text);

                AuthOnlinereqBody.Add("spAlias", "web");

                // set the device id to be used for

                AuthOnlinereqBody.Add("deviceId", devicefound);

                // the user name to send the auth to 

                AuthOnlinereqBody.Add("userName", textBox1.Text);

                // authenticate online
                AuthOnlinereqBody.Add("authType", "CONFIRM");


                //https://idpxnyl3m.pingidentity.com/pingid/rest/4/authonline/do

                var AuthapiEndpoint = "https://idpxnyl3m.pingidentity.com/pingid/rest/4/authonline/do";

                string AuthapiResponse = sendToken(AuthOnlinereqBody, AuthapiEndpoint);

                string[] AuthresponseComponents = AuthapiResponse.Split(new char[] { '.' });

                string AuthresponsePayload = AuthresponseComponents[1];
                string AuthresponsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(AuthresponsePayload));

                // get the session id out of the 1st auth response above. 


                AuthsessionId = AuthresponsePayloadDecoded.Substring(AuthresponsePayloadDecoded.IndexOf("sessionId", 10));

                AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.IndexOf(","));

                AuthsessionId = AuthsessionId.Substring(AuthsessionId.IndexOf(":") + 2);

                AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.Length - 1);

                richTextBox1.Clear();

                richTextBox1.Refresh();

                richTextBox1.AppendText("PayLoad: " + "\n" + AuthresponsePayloadDecoded);

            }

            catch
            {

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {

                OTPValue = textBox6.Text.ToString();

                if (AddnewDevice== "0" )
                {

                // we need to get a couple values that came from the get user. 
                // in this demo it is just reading the value of the rich text box and find the data. 
                // deviceID
                //"PayLoad: \n{\"responseBody\":{\"sameDeviceUsersDetails\":[],\"userDetails\":{\"lastTransactions\":[],\"devicesDetails\":[{\"nickname\":\"iPhone 5S\",\"sentNotClaimedSms\":-1,\"availableClaimedSms\":0,\"pushEnabled\":true,\"displayID\":\"iPhone 5S\",\"enrollment\":\"2016-03-28 14:39:26.217\",\"sentClaimedSms\":-1,\"availableNotClaimedSms\":0,\"deviceModel\":\"iPhone 5S\",\"countryCode\":null,\"deviceId\":187835,\"deviceUuid\":null,\"appVersion\":\"1.7(943)\",\"deviceRole\":\"PRIMARY\",\"hasWatch\":false,\"phoneNumber\":null,\"email\":null,\"osVersion\":\"9.3.5\",\"type\":\"iPhone\"}],\"picURL\":\"PHF5Q77RUYQDSNVXTB47JLJR2EEXSFQBTPTDFNMQHDCAJH3H6L5EDAI=\",\"spList\":[{\"spAlias\":\"pingone\",\"bypassExpiration\":null,\"spName\":\"SSO\",\"status\":\"ACTIVE\"},{\"spAlias\":\"vpn\",\"bypassExpiration\":null,\"spName\":\"VPN\",\"status\":\"ACTIVE\"}],\"lastLogin\":1474037590000,\"bypassExpiration\":null,\"deviceDetails\":{\"nickname\":\"iPhone 5S\",\"sentNotClaimedSms\":-1,\"availableClaimedSms\":0,\"pushEnabled\":true,\"displayID\":\"iPhone 5S\",\"enrollment\":\"2016-03-28 14:39:26.217\",\"sentClaimedSms\":-1,\"availableNotClaimedSms\":0,\"deviceModel\":\"iPhone 5S\",\"countryCode\":null,\"deviceId\":187835,\"deviceUuid\":null,\"appVersion\":\"1.7(943)\",\"deviceRole\":\"PRIMARY\",\"hasWatch\":false,\"phoneNumber\":null,\"email\":null,\"osVersion\":\"9.3.5\",\"type\":\"iPhone\"},\"userEnabled\":true,\"fname\":\"New\",\"userId\":6461158,\"userInBypass\":false,\"email\":\"paulbrady+newuser@pingidentity.com\",\"lname\":\"User\",\"status\":\"ACTIVE\",\"userName\":\"newuser\",\"role\":\"REGULAR\"},\"uniqueMsgId\":\"webs_26jtge4IpchTYiHqcYF8zsH6e0Bw3YDujZwpYxGBUt4\",\"errorId\":200,\"errorMsg\":\"ok\",\"clientData\":null}}"

                org_alias = textBox2.Text;
                use_base64_key = textBox3.Text;
                token = textBox4.Text;
                api_version = textBox5.Text;

                Dictionary<string, object> AuthOfflinereqBody = new Dictionary<string, object>();

                // AuthreqBody.Add("userName", textBox1.Text);

                AuthOfflinereqBody.Add("spAlias", "web");

                // set the device id to be used for

              //  AuthOfflinereqBody.Add("deviceId", devicefound);

                // the user name to send the auth to 

                AuthOfflinereqBody.Add("userName", textBox1.Text);

                // authenticate online
                // AuthOnlinereqBody.Add("authType", "CONFIRM");

                //Add the session ID from the Start Auth to use Offline


                AuthOfflinereqBody.Add("sessionId", AuthsessionId);


                // authenticate with OTP 

                AuthOfflinereqBody.Add("otp", OTPValue);

                //https://idpxnyl3m.pingidentity.com/pingid/rest/4/authoffline/do


                var AuthapiEndpoint = "https://idpxnyl3m.pingidentity.com/pingid/rest/4/authoffline/do";

                string AuthapiResponse = sendToken(AuthOfflinereqBody, AuthapiEndpoint);

                string[] AuthresponseComponents = AuthapiResponse.Split(new char[] { '.' });

                string AuthresponsePayload = AuthresponseComponents[1];
                string AuthresponsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(AuthresponsePayload));

                // get the session id out of the 1st auth response above. 


                //AuthsessionId = AuthresponsePayloadDecoded.Substring(AuthresponsePayloadDecoded.IndexOf("sessionId", 10));

                //AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.IndexOf(","));

                //AuthsessionId = AuthsessionId.Substring(AuthsessionId.IndexOf(":") + 2);

                //AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.Length - 1);

                richTextBox1.Clear();

                richTextBox1.Refresh();

                richTextBox1.AppendText("PayLoad: " + "\n" + AuthresponsePayloadDecoded);

                 panel1.Visible = false;


                }
                else
                {
                    // This will happen during the completion of StartOfflinePairing 
                    // sorry for jumping around.. but its only a sample. 
                    // 

                    Dictionary<string, object> FinalOfflinePairingAuthreqBody = new Dictionary<string, object>();
                    
                    FinalOfflinePairingAuthreqBody.Add("spAlias", "web");

//                    // set what we need for FinalizeOfflinePairing
//                    https://idpxnyl3m.pingidentity.com/pingid/rest/4/finalizeofflinepairing/do
//                    Request Body Parameters
//                    Example reqBody object in the API payload:
//                    "reqHeader": { ... },
//"reqBody": {
//                        "sessionId": "oacts_rxodmgpbVkjVltIBVP7C7m6y6ddsOY-a8BYqpDHHxZY",
// "otp": "123456",
// "clientData": "Session data echoed back to the requestor"

                    FinalOfflinePairingAuthreqBody.Add("otp", OTPValue );

                    // the session data from teh 1st call to start offline pairing Dont get confused 
                    // buy have it here... It is differnt session data from auth offline whic happens above 
                    
                    FinalOfflinePairingAuthreqBody.Add("sessionId", AuthsessionId);

                   // FinalOfflinePairingAuthreqBody.Add("userName", textBox1.Text);

                    var FinalOfflinePairingAuthapiEndpoint = " https://idpxnyl3m.pingidentity.com/pingid/rest/4/finalizeofflinepairing/do";

                    string FinalOfflinePairingAuthapiResponse = sendToken(FinalOfflinePairingAuthreqBody, FinalOfflinePairingAuthapiEndpoint);

                    string[] FinalOfflinePairingAuthresponseComponents = FinalOfflinePairingAuthapiResponse.Split(new char[] { '.' });

                    string FinalOfflinePairingAuthresponsePayload = FinalOfflinePairingAuthresponseComponents[1];
                    string FinalOfflinePairingAuthresponsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(FinalOfflinePairingAuthresponsePayload));

                    // get the session id out of the 1st auth response above. 


                    //AuthsessionId = AuthresponsePayloadDecoded.Substring(AuthresponsePayloadDecoded.IndexOf("sessionId", 10));

                    //AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.IndexOf(","));

                    //AuthsessionId = AuthsessionId.Substring(AuthsessionId.IndexOf(":") + 2);

                    //AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.Length - 1);

                    richTextBox1.Clear();

                    richTextBox1.Refresh();

                    richTextBox1.AppendText("PayLoad: " + "\n" + FinalOfflinePairingAuthresponsePayloadDecoded);



                    panel1.Visible = false;

                }

            }

            catch
            {

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // display the list of device for to pick from.   Of course you could add more automation here and use other info
            // from the get user to help you decide which device to use. 
            panel2.Visible = true;



            // set the device ID to be used for authentication

            devicefound = DeviceList.SelectedItem.ToString();

            devicefound = devicefound.Substring(devicefound.IndexOf(":") + 1);

            panel2.Visible = false;

            richTextBox1.Clear();
            richTextBox1.Text = "Device Selected is: " + devicefound;

            //display the start auth button
            StartAuth1.Visible = true;



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //// create alist of devices
            //// allow the user pick which one to use if there are more than 1
            ////
            string newDevice = "";

            string model = "";

            //
            // use split to get teh items we want into an array.  If you want, break the code near line 339
            // you can then look at all the items that are returned lots of info is avaible for you to use. 
            //

            char[] delimiterChars = { ',' };

            string text = richTextBox1.Text.ToString();

            richTextBox1.Clear();

            string[] words = text.Split(delimiterChars);

            for (int x = 0; x < words.Count(); x++)
            {

                if (words[x].Contains("deviceId"))
                {
                    newDevice = words[x].ToString();

                    DeviceList.Items.Add(newDevice);

                }

                if (words[x].Contains("deviceModel"))
                {

                    model = words[x].ToString();

                    ModelList.Items.Add(model);

                }

            }

            if (DeviceList.Items.Count != 0)
            {

                panel2.Visible = true;

            }
            else
            {
                MessageBox.Show("No Devices found for user? ");
            }
        }

        private void btn_addDevice_Click(object sender, EventArgs e)
        {
            //this will go through the add device use case.  The controls are on the panel 
            try
            {

                panel3.Visible = true;

            }

            catch

            {

            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {


                if (NewDeviceType=="" )
                {
                    throw new ArgumentException("You must make a selection");


                }
          

              // Add another device  AuthOffLine ADD ANOTHER device

            //                The call to StartOfflinePairing causes PingID to send an OTP to the user via email, SMS or voice message, as indicated in the call parameters.The user must then enter the OTP manually to the service provider's application, which should then call FinalizeOfflinePairing while providing the OTP, to complete the pairing process.

            //This is the StartOfflinePairing URL:

            //https://idpxnyl3m.pingidentity.com/pingid/rest/4/startofflinepairing/do

            //                "reqHeader": { ... },
            //"reqBody": {
            //                    "username": "jdoe",
            // "type": "SMS",
            // "pairingData": "13035551234",
            // "clientData": "Session data echoed back to the requestor"
            //}

            // I am setting this in each control but you could do it one and reuse this.. again this is 
            // just a sample 
            org_alias = textBox2.Text;
            use_base64_key = textBox3.Text;
            token = textBox4.Text;
            api_version = textBox5.Text;

            Dictionary<string, object> AuthreqBody = new Dictionary<string, object>();

            // AuthreqBody.Add("userName", textBox1.Text);

            AuthreqBody.Add("spAlias", "web");

                // set the tyoe to be used for
//                The type of offline message to send to the user. One of:

//SMS - to send a text message.
//VOICE - to send a voice message.
//EMAIL - to send an email message.

            AuthreqBody.Add("type", NewDeviceType);

            // the user name to send the auth to 

            AuthreqBody.Add("username", textBox1.Text);

                // the pairing data (phone num, email or voice num)

                AuthreqBody.Add("pairingData","1"+ textBox7.Text);


            var AuthapiEndpoint = "https://idpxnyl3m.pingidentity.com/pingid/rest/4/startofflinepairing/do";

            string AuthapiResponse = sendToken(AuthreqBody, AuthapiEndpoint);

            string[] AuthresponseComponents = AuthapiResponse.Split(new char[] { '.' });

            string AuthresponsePayload = AuthresponseComponents[1];
            string AuthresponsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(AuthresponsePayload));

            // get the session id out of the 1st auth response above. 


            AuthsessionId = AuthresponsePayloadDecoded.Substring(AuthresponsePayloadDecoded.IndexOf("sessionId", 10));

            AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.IndexOf(","));

            AuthsessionId = AuthsessionId.Substring(AuthsessionId.IndexOf(":") + 2);

            AuthsessionId = AuthsessionId.Substring(0, AuthsessionId.Length - 1);

            richTextBox1.Clear();

            richTextBox1.Refresh();

            richTextBox1.AppendText("PayLoad: " + "\n" + AuthresponsePayloadDecoded);

                //groupBox3.Enabled = true;


                // now that we have the session ID lets use it to send and OTP to the device.. 
                // create new dictionary (could probably do this smarter but I am just going to create new ones

                // present the panel to get teh OTP that was sent

                AddnewDevice = "1";


                panel1.Visible = true;

                panel3.Visible = false;

                // the code will finish in the button clik for panel 1


            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            NewDeviceType = "SMS";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            NewDeviceType = "VOICE";


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            NewDeviceType = "EMAIL";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
   

            try
            {


   //             if (textBox1.Text == "") throw new ApplicationException();
                richTextBox1.Clear();
                org_alias = textBox2.Text;
                use_base64_key = textBox3.Text;
                token = textBox4.Text;
                api_version = textBox5.Text;

                Dictionary<string, object> reqBody = new Dictionary<string, object>();

                // activate user?
                // If you set this to true, you will get back the activation code to 
                //give to the user. 

                if (activateUserChk.Checked==true)
                {

                    reqBody.Add("activateUser", "true");


                }
                else
                {
                    reqBody.Add("activateUser", "false");

                }

                reqBody.Add("userName",txbNewUsername.Text);



                reqBody.Add("fName", txbFname.Text);

                reqBody.Add("lname", txbLname.Text);

                reqBody.Add("email", txbEmail.Text);

                reqBody.Add("role", "REGULAR");

                var apiEndpoint = "https://idpxnyl3m.pingidentity.com/pingid/rest/4/adduser/do";

                string apiResponse = sendToken(reqBody, apiEndpoint);

                string[] responseComponents = apiResponse.Split(new char[] { '.' });

                string responsePayload = responseComponents[1];
                string responsePayloadDecoded = Encoding.UTF8.GetString(Base64UrlDecodeString(responsePayload));

                //Dump the payload all of it into the richtext box just so you can see it. 
                StartAuth1.Enabled = true;


                richTextBox1.AppendText("PayLoad: " + "\n" + responsePayloadDecoded);

                panel4.Visible = false;



            }
            catch
            {
                if (textBox1.Text == "") MessageBox.Show("You Must Enter the Name of a User registered in PingOne ");




            }
            // bottom of add user

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            panel4.Visible = true;

        }
    }
}
