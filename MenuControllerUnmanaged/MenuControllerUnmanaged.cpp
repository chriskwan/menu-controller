// MenuControllerUnmanaged.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "MenuControllerUnmanaged.h"
//#include "msword.h"

// This is an example of an exported variable
MENUCONTROLLERUNMANAGED_API int nMenuControllerUnmanaged=0;

// This is an example of an exported function.
MENUCONTROLLERUNMANAGED_API int fnMenuControllerUnmanaged(void)
{
	return 42;
}

// This is the constructor of a class that has been exported.
// see MenuControllerUnmanaged.h for the class definition
CMenuControllerUnmanaged::CMenuControllerUnmanaged()
{
	return;
}

int GetMenuItemString(HMENU hMenu, UINT uIDItem, LPSTR lpString)
{
	return GetMenuStringA(hMenu, uIDItem, lpString, 20, MF_BYPOSITION);
}

int ClickMenuItem(HWND hWnd, HMENU hMenu, int nPos)
{
	UINT uiMenuItemID = GetMenuItemID(hMenu, nPos);
	return SendMessage(hWnd, WM_COMMAND, MAKEWPARAM(uiMenuItemID, 0), 0);
}

BOOL IsCheckMarksItem(HMENU hMenu, int nPos)
{
	MENUITEMINFO mii;
	mii.cbSize = sizeof(MENUITEMINFO);
	mii.fMask = MIIM_CHECKMARKS;
	return GetMenuItemInfo(hMenu, nPos, true, &mii);
}

BOOL IsDisabled(HMENU hMenu, int nPos)
{
	return (GetMenuState(hMenu, nPos, MF_BYPOSITION) & (MF_DISABLED | MF_GRAYED));
}
