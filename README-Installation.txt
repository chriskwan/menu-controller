PRELIMINARIES:
1. Install Visual Studio 2010 Professional (make sure to install everything).


BUILDING PROJECTS:
1. Open .\MenuController.sln in VS 2010.
2. From the "Build" menu, select "Rebuild Solution".  NOTE: IGNORE BUILD ERROR AT THIS POINT!!!
3. Select "Release" from the "Solution Configurations" dropdown. 
4. From the "Build" menu, select "Rebuild Solution".  NOTE: SHOULD SEE "Build succeeded" IN BOTTOM LEFT CORNER.
5. Select "Debug" from the "Solution Configurations" dropdown. 
6. From the "Build" menu, select "Rebuild Solution".  SHOULD SEE "Build succeeded" IN BOTTOM LEFT CORNER.

BUILDING INSTALLER:
1. Select "Debug" from the "Solution Configurations" dropdown.  
2. From "Solution Explorer" right-click on MenuControllerSetup and select "Build".  NOTE: IGNORE WARNINGS (SHOULD BE FIXED AT SOME POINT).

INSTALLING:
1. Go to .\MenuController\MenuControllerSetup\Release and run setup.exe and go through prompts until installation is complete.
2. Go to "C:\Program Files\Camera Mouse Suite\MenuController\" and run MenuController.exe

RELEASING NEW VERSION:
1. In FormMain.cs, change the VERSION constant to desired version number.
2. Build a new version by following the steps in "BUILD INSTALLER".
3. Copy .\MenuControllerSetup\Release\MenuControllerSetup.msi to .\MenuControllerSetup\Committed
4. Release  .\MenuControllerSetup\Committed\MenuControllerSetup.msi and .\MenuControllerSetup\Committed\setup.exe together.