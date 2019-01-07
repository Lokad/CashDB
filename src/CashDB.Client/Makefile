all: release debug

clean:
	$(MAKE) realclean CONFIG=Release
	$(MAKE) realclean CONFIG=Debug

release:
	$(MAKE) cashdb_lib CONFIG=Release
debug:
	$(MAKE) cashdb_lib CONFIG=Debug

CFLAGS = -Wall -fPIC
ifeq ($(CONFIG), Debug)
    CFLAGS += -DDEBUG -g3 -O0
else ifeq ($(CONFIG), Release)
    CFLAGS += -DNDEBUG -flto -O3
else ifdef CONFIG
    $(error invalid config $(CONFIG))
endif

BIN_DIR:=../x64/$(CONFIG)
OBJ_DIR:=obj/x64/$(CONFIG)
CASHDB_LIB:=$(BIN_DIR)/libcashdbclient.so
C_FILES:=ranges.c status.c cashdb.c connection.c protocol.c
H_FILES:=compat.h ranges.h status.h cashdb.h connection.h protocol.h
O_FILES:=$(C_FILES:%.c=$(OBJ_DIR)/%.o)


cashdb_lib: $(CASHDB_LIB)

$(OBJ_DIR)/%.o: %.c $(H_FILES)
	mkdir -p $(dir $@)
	gcc $(CFLAGS) -fvisibility=hidden -o $@ -c $<

$(OBJ_DIR)/cashdb.o: cashdb.c $(H_FILES)
	mkdir -p $(dir $@)
	gcc $(CFLAGS) -fvisibility=default -o $@ -c $<

$(CASHDB_LIB): $(O_FILES)
	mkdir -p $(dir $@)
	gcc $(CFLAGS) -shared -o $@ $^

.PHONY: clean all release debug


realclean:
	rm -f $(CASHDB_LIB)
	if [ -d $(BIN_DIR) ]; then rmdir --ignore-fail-on-non-empty -p $(BIN_DIR); fi
	rm -f $(O_FILES)
	if [ -d $(OBJ_DIR) ]; then rmdir --ignore-fail-on-non-empty -p $(OBJ_DIR); fi
