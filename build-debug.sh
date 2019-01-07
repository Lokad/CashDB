#/bin/sh

make -C src/CashDB.Client debug
make -C extern/src/lmdb
dotnet build -c Debug src/CashDB.Linux.sln

