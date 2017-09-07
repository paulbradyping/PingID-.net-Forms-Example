# PingID-.net-Forms-Example
This .net forms application uses the PingID API
It uses a PingID properties file from a PingOne Tenant that is being tested. 

Pre- Requisites 
-PingOne Tenant with PingID. 
-Registered Device or Multiple Devices
-Test User other than the 1st Administrator

Install
-Clone the repository and download the zip. 

Extract it,  in the debug folder you will find the compiled .exe 


Start the application. 
-To Start the application use the windows explorer and browse to the folder that has PingIDAPI.exe in it.
Run the PingIDAPI.exe 

You need the pingID properties file from the PingOne Tenant you are testing with
Browse to select that file

You can Add a New user or you can use existing users.   
OR
Enter the username of a someone that is Registered in PingOne with a device(s)

Click Start Authenticate

PingOne if all is correct PingOne will return the user and all the info about them and all the Device they have Registered

Then You can Online Authenticate by clicking the button

To build this app open the project or SLN with Visual Studio.net 2015

You will need to include the Jose JWT Nuget package available here
https://www.nuget.org/packages/jose-jwt/

or from within visual studio 2015 Tools, Nuget Package Manager, Package Manager Console
Install-Package jose-jwt




