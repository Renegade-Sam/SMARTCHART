### SMARTCHART ###

The purpose of this application is to keep the logistical aspects of being a nurse easy.

Sam H.

Technologies used: 
Visual Studio 2022, C# / .NET 4.7.2 
Database/Storage: .JSON
MSTest, framework 4.7.2

Prerequisites: 
Visual Studio 2022, 
.NET SDK 7 or later.

Installation:
Clone repository or download a ZIP file and extract it.
Download Visual Studio 2022.
In SMARTCHART folder go to: \bin\Debug\SMARTCHART.App
Newtonsoft.Json included, no external dependency required.

Running the application: Simply run the SMARTCHART application in the folder.

Trying the Sprint 1 functionality: 
Once the app is running, enter your name. This name is saved for your view later.
Go to Patient Hub and register a patient. The patients name will display on screen.
You may create as many patients and use the search command to find them quickly.
Next edit the patients information, or delete it. The display will immediately update your actions.
Finally go to Log Hub. Your action history under the name you entered will be stored.

Trying the Sprint 2 functionality:
To access full application a user must enter "Professor" as their sign-in name.
"Professor" allows the view of logs hub that shows users actions previously.
It will show what they did when editing a patients information.
In order to edit a patient, a user must select an individual field to edit. 
As before press the "Edit Patient" button and a pop-up will guide you to desired field.
Once finished click Ok and the windows panel will update your change live.

Automated Testing:
The MSTest is located in C:\Users\YourName\Yourfolderlocation\SMARTCHART\Tests\SMARTCHART.UnitTests

Visual studio has a built in "Test" command that will run the commands and show the outputs. 
It is advised to build both the SMARTCHART app and SMARTCHART.UnitTests
then Test, Run all Tests will run the program.

Known limitations.
The user name can be anything and simply a keepsake for logging.
The user must enter a name, there is no 'quit' button.
The patients hub sorting needs finetuning; Not always accurate.
