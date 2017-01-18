# Sitefinity.RecaptchaBackendLogin
Modifying the Sitefinity backend login to use Google Recaptcha

![recaptcha backend login](https://github.com/nzagorchev/Sitefinity.RecaptchaBackendLogin/blob/master/SetupAndFunctionality/login_with_recaptcha.png)

## Functionality:
![recaptcha login gif](https://github.com/nzagorchev/Sitefinity.RecaptchaBackendLogin/blob/master/SetupAndFunctionality/recaptcha_login_gif.gif)

## Installation:
Download the project and add it in the Sitefinity application solution. 
Reference the Sitefinity assemblies for your version. Reference the Recaptcha project from the Sitefinity application. Build the solution and start it.

Go to Administration -> Modules & Services. Click Install a module. Install the RecaptchaModule, enter the following parameters:
Name: RecaptchaModule
Type: RecaptchaBackendLogin.RecaptchaModule

After the module has been installed, you will now have the Recaptcha config and resources in place, as well as, the new login widget in the toolboxes. The default login form will also be added in the widget toolboxes in case you want to revert to the original login.

## Configuration
Now you need to configure the Recaptcha. Get your site key and secret key from google recaptcha:
https://developers.google.com/recaptcha/docs/start
Go to Advanced settings -> Recaptcha. Populate the secret key and site key. You can also set other settings for the recaptcha.

## Setup
Once the settings are configured, go to Administration -> Backend pages. Modify the Login page under Login. Remove the default widget and set on its place the RecaptchaStsLoginFormPanel. Publish the page.

