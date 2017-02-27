set(CROSS_ROOTFS $ENV{ROOTFS_DIR})

set(CMAKE_SYSTEM_NAME Linux)
set(CMAKE_SYSTEM_VERSION 1)
set(CMAKE_SYSTEM_PROCESSOR armv7l)

set(TOOLCHAIN "arm-linux-gnueabihf")

add_compile_options(-target armv7-linux-gnueabihf)
add_compile_options(-mthumb)
add_compile_options(-mfpu=vfpv3)
add_compile_options(--sysroot=${CROSS_ROOTFS})

set(CROSS_LINK_FLAGS "${CROSS_LINK_FLAGS} -target ${TOOLCHAIN}")
set(CROSS_LINK_FLAGS "${CROSS_LINK_FLAGS} -B${CROSS_ROOTFS}/usr/lib/gcc/${TOOLCHAIN}")
set(CROSS_LINK_FLAGS "${CROSS_LINK_FLAGS} -L${CROSS_ROOTFS}/lib/${TOOLCHAIN}")
set(CROSS_LINK_FLAGS "${CROSS_LINK_FLAGS} --sysroot=${CROSS_ROOTFS}")

set(CMAKE_EXE_LINKER_FLAGS    "${CMAKE_EXE_LINKER_FLAGS}    ${CROSS_LINK_FLAGS}" CACHE STRING "" FORCE)
set(CMAKE_SHARED_LINKER_FLAGS "${CMAKE_SHARED_LINKER_FLAGS} ${CROSS_LINK_FLAGS}" CACHE STRING "" FORCE)
set(CMAKE_MODULE_LINKER_FLAGS "${CMAKE_MODULE_LINKER_FLAGS} ${CROSS_LINK_FLAGS}" CACHE STRING "" FORCE)

set(CMAKE_FIND_ROOT_PATH "${CROSS_ROOTFS}")
set(CMAKE_FIND_ROOT_PATH_MODE_PROGRAM NEVER)
set(CMAKE_FIND_ROOT_PATH_MODE_LIBRARY ONLY)
set(CMAKE_FIND_ROOT_PATH_MODE_INCLUDE ONLY)
set(CMAKE_FIND_ROOT_PATH_MODE_PACKAGE ONLY)

set(LLVM_ARM_DIR "$ENV{LLVM_ARM_HOME}")
if(LLVM_ARM_DIR)
    set(WITH_LLDB_LIBS "${LLVM_ARM_DIR}/lib/" CACHE STRING "")
    set(WITH_LLDB_INCLUDES "${LLVM_ARM_DIR}/include" CACHE STRING "")
    set(LLDB_H "${WITH_LLDB_INCLUDES}" CACHE STRING "")
    set(LLDB "${LLVM_ARM_DIR}/lib/liblldb.so" CACHE STRING "")
else()
    set(WITH_LLDB_LIBS "${CROSS_ROOTFS}/usr/lib/${TOOLCHAIN}" CACHE STRING "")
    set(WITH_LLDB_INCLUDES "${CROSS_ROOTFS}/usr/lib/llvm-3.6/include" CACHE STRING "")
endif()
