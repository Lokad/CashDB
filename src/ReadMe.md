# Core CashDB projects

This folder contains:

* `CashDB.Client`, the native C client library to connect to a CashDB instance.
* `CashDB.Lib`, the backend logic in C#/.NET behind a CashDB instance.
* `CashDB.Server`, the host application in C#/.NET for a CashDB instance.

For C#/.NET scenarios, the `CashDB.Lib` library happens to contain a managed 
wrapper around the native client `CashDB.Client`.
