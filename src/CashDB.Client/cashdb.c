#include <stdio.h>
#include <stdlib.h>

#include "cashdb.h"
#include "connection.h"
#include "protocol.h"

#ifdef _WIN32
#include <WinSock2.h>
#endif


int32_t cashdb_initialize()
{
	#ifdef  _WIN32
	WSADATA wsaData;
	int wsInitFailed = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (wsInitFailed)
	{
		return CASHDB_ERR_INTERNAL_ERROR;
	}
	#endif
	return CASHDB_SUCCESS;
}

int32_t cashdb_shutdown()
{
	#ifdef _WIN32
	WSACleanup();
	#endif
	return CASHDB_SUCCESS;
}


int32_t cashdb_connect( const char* connection_string, connection_t* conn )
{
	connection_s* result = connection_new(connection_string);

	if (result == NULL)
	{
		return CASHDB_ERR_CONNECTION_FAILED;
	}

	if (!connection_open(result))
	{
		connection_free(result);
		return CASHDB_ERR_CONNECTION_FAILED;
	}

	*conn = result;
	return CASHDB_SUCCESS;
}


int32_t cashdb_disconnect(connection_t connection, const char* reason)
{
	connection_s* cnx = (connection_s*) connection;

	if (!connection_close(cnx))
	{
		return CASHDB_ERR_INTERNAL_ERROR;
	}

	connection_free(cnx);
	return CASHDB_SUCCESS;
}


int32_t cashdb_utxo_open_block(
	connection_t conn,
	block_id_t* parentid,
	block_handle_t* block,
	block_ucid_t* block_ucid
)
{
	connection_s* cnx = (connection_s*)conn;
	return open_block(cnx, parentid, block, block_ucid);
}

int32_t cashdb_utxo_commit_block(
	connection_t conn,
	block_handle_t block,
	block_id_t* blockid
)
{
	connection_s* cnx = (connection_s*)conn;
	return commit_block(cnx, block, blockid);
}

int32_t cashdb_utxo_get_committed_block(
	connection_t connection,
	block_id_t* blockid,
	block_handle_t* block
)
{
	connection_s* cnx = (connection_s*)connection;
	return get_committed_block_handle(cnx, blockid, block);
}

int32_t cashdb_utxo_get_uncommitted_block(
	connection_t conn,
	block_ucid_t* block_ucid,
	block_handle_t* block
)
{
	connection_s* cnx = (connection_s*)conn;
	return get_uncommitted_block_handle(cnx, block_ucid, block);
}

int32_t cashdb_utxo_get_blockinfo(
	connection_t connection,
	block_handle_t block,
	block_info_t* info
)
{
	connection_s* cnx = (connection_s*)connection;
	return get_block_info(cnx, block, info);
}

int32_t cashdb_utxo_set_coins(
	connection_t conn,
	block_handle_t context,
	int32_t coin_length,
	coin_t* coins,
	int32_t storage_length,
	uint8_t* storage
)
{
	connection_s* cnx = (connection_s*)conn;
	return set_coins(cnx, context, coin_length, coins, storage_length, storage);
}

int32_t cashdb_utxo_get_coins(
	connection_t conn,
	block_handle_t context,
	int32_t coin_length,
	coin_t* coins,
	int32_t storage_length,
	uint8_t* storage
)
{
	connection_s* cnx = (connection_s*)conn;

	range storage_range = { 0 };
	storage_range.begin = (char*) storage;
	storage_range.end = storage_range.begin + storage_length;
	
	return get_coins(cnx, context, coin_length, coins, &storage_range);
}
