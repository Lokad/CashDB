#/bin/sh

make -C src/CashDB.Client release
make -C extern/src/lmdb
dotnet build -c Release src/CashDB.Linux.sln

