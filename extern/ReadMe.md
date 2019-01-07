# Dependencies of CashDB

This folder contains dependent projects for CashDB. Those projects
have been released under open source licensing terms of their own.

We have:

* `/src/commandline/`, a C#/.NET command-line parsing utility.
* `/src/LightningDB/`, a C#/.NET wrapper around the native LMDB library.
* `/src/lmdb/`, a C++ high-performance key-value store.

Although CashDB leverages LMDB, this key-value store is not used as the
primary store to hold the UTXO set within CashDB. CashDB operates
dominantly through direct accesses to memory mapped files.
