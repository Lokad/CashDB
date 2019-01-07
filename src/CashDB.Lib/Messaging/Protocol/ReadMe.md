# Messaging.Protocol namespace

This namespace contains the list of all the requests and responses
that are exchanged between the CashDB client and the CashDB server.
This namespace is the counterpart of the file `protocol.h`.

Each request has a single response. The `ProtocolErrorResponse` being
the wild card returned when the request itself is broken.
