Imports System.Runtime.InteropServices

Module MemoryRelease
    <DllImport("KERNEL32.DLL", EntryPoint:="SetProcessWorkingSetSize", _
    SetLastError:=True, CallingConvention:=CallingConvention.StdCall)> _
    Function SetProcessWorkingSetSize(ByVal pProcess As IntPtr, _
ByVal dwMinimumWorkingSetSize As Integer, _
ByVal dwMaximumWorkingSetSize As Integer) As Boolean
    End Function

    <DllImport("PSAPI.DLL", EntryPoint:="EmptyWorkingSet", _
        SetLastError:=True, CallingConvention:=CallingConvention.StdCall)> _
    Function EmptyWorkingSet(ByVal pProcess As IntPtr) As Boolean
    End Function


    <DllImport("KERNEL32.DLL", EntryPoint:="GetCurrentProcess", _
    SetLastError:=True, CallingConvention:=CallingConvention.StdCall)> _
    Function GetCurrentProcess() As IntPtr
    End Function

    Sub Release()
        Dim pHandle As IntPtr = GetCurrentProcess()
        Call SetProcessWorkingSetSize(pHandle, -1, -1)
    End Sub

    Sub Release2()
        Dim pHandle As IntPtr = GetCurrentProcess()
        Call EmptyWorkingSet(pHandle)
    End Sub
End Module