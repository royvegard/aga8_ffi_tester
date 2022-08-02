build_rust:
	cd rust && cargo build

run_rust:
	cd rust && cargo run

test_rust:
	cd rust && cargo test

test_c: c/aga8_c_test
	LD_LIBRARY_PATH=aga8/target/debug c/aga8_c_test

test: test_c test_rust

c/aga8_c_test: c/main.c c/aga8.h
	gcc c/main.c -o c/aga8_c_test -Laga8/target/debug -laga8

c/aga8.h: aga8_shared_lib
	cp aga8/target/aga8.h c/

aga8_shared_lib:
	cd aga8 && cargo build --all-features
	touch aga8_shared_lib

clean_rust:
	cd rust && cargo clean

clean_aga8_lib:
	cd aga8 && cargo clean
	rm -f aga8_shared_lib

clean_c:
	cd c && rm -f aga8_c_test aga8.h

clean: clean_rust clean_aga8_lib clean_c
