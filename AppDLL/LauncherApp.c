#include "pch.h"
#include <windows.h>
#include <stdio.h>
#include <commdlg.h>

_declspec(dllexport) char* openFileDiag(HWND hwndOwner, const char* filter, const char* tittle) {
    static char fileName[MAX_PATH] = "";

    OPENFILENAME ofn;
    ZeroMemory(&ofn, sizeof(ofn));
    ofn.lStructSize = sizeof(ofn);
    ofn.hwndOwner = hwndOwner;
    ofn.lpstrFilter = filter;
    ofn.lpstrFile = fileName;
    ofn.nMaxFile = MAX_PATH;
    ofn.Flags = OFN_PATHMUSTEXIST | OFN_FILEMUSTEXIST;
    ofn.lpstrTitle = tittle;

    if (GetOpenFileName(&ofn)) {
        return fileName;
    }
    else {
        return NULL;
    }
}