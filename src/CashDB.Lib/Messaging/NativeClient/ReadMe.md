# NativeClient namespace

This namespace contains a C# PInvoke wrapper around the C/C++ API
of CashDB. This namespace does not contribute to the server-side
logic of CashDB. 

This namespace is primarily intended for testing purposes, however
it could also be used by a client implementation if this implementation
happens to be in .NET.

This namespace is the sole point of depdencence from `CashDB.Lib` to
`CashDB.Client`. The rest of the server logic is NOT dependent upon the
client library. As PInvoke calls are late-bound, it is possible to run
the CashDB server without `CashDB.Client`.
