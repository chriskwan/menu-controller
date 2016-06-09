// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the MENUCONTROLLERUNMANAGED_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// MENUCONTROLLERUNMANAGED_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef MENUCONTROLLERUNMANAGED_EXPORTS
#define MENUCONTROLLERUNMANAGED_API __declspec(dllexport)
#else
#define MENUCONTROLLERUNMANAGED_API __declspec(dllimport)
#endif

// This class is exported from the MenuControllerUnmanaged.dll
class MENUCONTROLLERUNMANAGED_API CMenuControllerUnmanaged {
public:
	CMenuControllerUnmanaged(void);
	// TODO: add your methods here.
};

extern MENUCONTROLLERUNMANAGED_API int nMenuControllerUnmanaged;

MENUCONTROLLERUNMANAGED_API int fnMenuControllerUnmanaged(void);

extern "C" MENUCONTROLLERUNMANAGED_API int GetMenuItemString(HMENU hMenu, UINT uIDItem, LPSTR lpString);
extern "C" MENUCONTROLLERUNMANAGED_API int ClickMenuItem(HWND hWnd, HMENU hMenu, int nPos);
extern "C" MENUCONTROLLERUNMANAGED_API BOOL IsCheckMarksItem(HMENU hMenu, int nPos);
extern "C" MENUCONTROLLERUNMANAGED_API BOOL IsDisabled(HMENU hMenu, int nPos);
