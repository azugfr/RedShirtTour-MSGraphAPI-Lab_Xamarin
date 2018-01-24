# RedShirtTour-MSGraphAPI-Lab_Xamarin
Red Shirt Tour Paris 2018 - Hands On Lab MS Graph API


## Table of contents

* [Introduction](#introduction)
* [Prerequisites](#prerequisites)
* [Exercice 1 : Register and configure the app](#register)
* [Exercice 1 : Implement AuthentificationService](#authService)
* * [Exercice 2 : Implement GroupService](#groupService)
* * [Exercice 3 : Implement EventService](#eventService)
* [Build and debug](#build)
* [Questions and comments](#questions)
* [Additional resources](#additional-resources)

<a name="introduction"></a>
## Introduction

This Repo will help you step by step throw exercices to implement Graph API in a Xamarin Forms application. Connection to Graph API, get all groups, list in a view all events associated, display event informations and Subscribe to one.

<a name="Prerequisites"></a>
## Exercices ##

This sample requires the following:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin for Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([development mode enabled](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * Either a [Microsoft](https://www.outlook.com) or [Office 365 for business account](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

If you want to run the iOS project in this sample, you'll need the following:

  * The latest iOS SDK
  * The latest version of Xcode
  * Mac OS X Yosemite(10.10) & above 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * A [Xamarin Mac agent connected to Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

You can use the [Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) if you want to run the Android project.

<a name="register"></a>
## Exercice 1 : Register and configure the app

1. Into the [App Registration Portal](https://apps.dev.microsoft.com/) using your account provide during the Red Shirt Dev Tour Lab session.
2. Select **Add an app**.
3. Enter a name for the app, and select **Create**.
	
	The registration page displays, listing the properties of your app.
 
4. Under **Platforms**, select **Add platform**.
5. Select **Native Application**.
6. Copy the Application Id value and the Custom Redirect URI value (under the **Native Application** header) that was created for you when you added the **Native Application** platform. This URI should contain your Application Id value and be in this form: `msal<Application Id>://auth` You'll need to enter these values into the sample app.

	The app id is a unique identifier for your app.

7. Select **Save**.

<a name="authService"></a>
## Exercice 1 : Implement AuthentificationService

1. Command are already implemented in the MainViewModel
2. A exception will occure during the run time because the AuthentificationService is not created.
3. We are going to create a singleton GraphServiceClient object in GetAuthenticatedClient()
4. GraphServiceClient needs : 
	1. A url (https://graph.microsoft.com/v1.0)
	2. A DelegateAuthenticationProvider with a TOKEN and a simple 		AuthorizationHEader
	3. The token can be retrived by a simple async method that we will create GetTokenForUserAsync()
	4. GraphLibrary provide a method that generate a WebView AcquireTokenAsync
	5. We need to managed this call multiple time. Save the token and managed the expirationTime (Let's say 5 mins)
5. Implement a sign Out method that erase all object

<a name="groupService"></a>
## Exercice 2 : Implement GroupService

<a name="eventService"></a>
## Exercice 3 : Implement GroupService





| Step1 | Step2 | Step3 | Step4 |
| --- | ------- | ----| ----|
| <img src="/readme-images/step1.png" alt="Step1" width="100%" /> | <img src="/readme-images/step2.png" alt="Step2" width="100%" /> | <img src="/readme-images/step3.png" alt="Step3" width="100%" /> | <img src="/readme-images/step4.png" alt="Step4" width="100%" /> |


## Copyright
Copyright (c) 2017 Cellenza. All rights reserved. Lab Red Shirt Dev Tour 23 January 2018


