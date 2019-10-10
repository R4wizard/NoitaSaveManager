;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "Noita Save Manager"
  OutFile "release/install.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\Noita Save Manager"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Noita Save Manager" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin

;--------------------------------
;Variables

  Var StartMenuFolder

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY

  ;Start Menu Folder Page Configuration
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU"
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\Noita Save Manager"
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Noita Save Manager"

  !insertmacro MUI_PAGE_STARTMENU Application $StartMenuFolder

  !insertmacro MUI_PAGE_INSTFILES

  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Noita Save Manager" SecNoitaSM

  SetOutPath "$INSTDIR"

  File /r "NoitaSaveManager\bin\Release\*"

  ;Store installation folder
  WriteRegStr HKCU "Software\Noita Save Manager" "" $INSTDIR

  ;Create uninstaller
  WriteUninstaller "$INSTDIR\uninstall.exe"

  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application

    ;Create shortcuts
    CreateDirectory "$SMPROGRAMS\$StartMenuFolder"
    CreateShortcut "$SMPROGRAMS\$StartMenuFolder\Uninstall Noita Save Manager.lnk" "$INSTDIR\uninstall.exe"
    CreateShortcut "$SMPROGRAMS\$StartMenuFolder\Noita Save Manager.lnk" "$INSTDIR\NoitaSaveManager.exe"

  !insertmacro MUI_STARTMENU_WRITE_END

SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecNoitaSM ${LANG_ENGLISH} "A tool for managing Noita save files."

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecNoitaSM} $(DESC_SecNoitaSM)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  Delete "$INSTDIR\uninstall.exe"

  RMDir /r "$INSTDIR"

  !insertmacro MUI_STARTMENU_GETFOLDER Application $StartMenuFolder

    Delete "$SMPROGRAMS\$StartMenuFolder\Uninstall Noita Save Manager.lnk"
  RMDir "$SMPROGRAMS\$StartMenuFolder"

  DeleteRegKey /ifempty HKCU "Software\Noita Save Manager"

SectionEnd