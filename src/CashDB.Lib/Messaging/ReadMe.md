# Messaging namespace

This namespace defines the fine-print of the binary protocol between the
CashDB server and the CashDB client. Unlike, the 'official' C/C++ API of
CashDB, there is little or no intent to preserve backward compatibility for
this API.

The client-server protocol operates over a single TCP socket, following an
asynchronous pattern where requests (resp. responses) are continuously
received (resp. sent).
