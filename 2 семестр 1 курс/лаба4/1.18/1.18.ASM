;тип приложения
     format     PE      console
;точка входа
     entry start
;подключение макро библиотек
     include 'WIN32AX.INC' ;invoke
;секция данных
     section    '.data' data readable writeable
filename        db      100 dup(0)
lfilename       dd      ?
flength         dd      ?
fbuf            dd      ?
hHeap           dd      ?
hFile           dd      ?

stdin           dd  ?
stdout          dd  ?

buffer          db  3 dup(?);?,?,?
lenbuf          = $ - buffer
cntread         dd  ?

n               = 100
first           db  n dup(?)
lfirst          dd  ?
;секция кода
     section    '.code' code readable executable
start:
      invoke    GetStdHandle,STD_INPUT_HANDLE
      mov       [stdin],eax
      invoke    GetStdHandle,STD_OUTPUT_HANDLE
      mov       [stdout],eax
;вывод строки
      cinvoke   printf, "%s", <"Input filename : ", 0>
;ввод строки имя файла
      invoke    ReadConsole,[stdin],filename,100,lfilename,NULL
      mov       esi, filename
      mov       ecx, [lfilename]
      mov       byte [esi + ecx - 2], 0
;открытие файла
      invoke    CreateFile, filename, GENERIC_READ, 0, NULL, OPEN_EXISTING,\
      FILE_ATTRIBUTE_NORMAL, NULL
      mov       [hFile], eax
      cmp       eax, -1
      jne       goodFile
      cinvoke   printf, "%s", <"Error file open!",10, 13, 0>
      jmp       exit
goodFile:
      invoke    GetFileSize, [hFile], flength
      mov       [flength], eax
      cinvoke   printf, "Length file - %d %s", [flength], <10,13,0>
;работа с кучей
      invoke   HeapCreate, 0, 0, 0
      cmp      eax, NULL
      jne      goodHeap
      cinvoke  printf, "%s", <"Failed create heap",10,13,0>
      jmp      exit
goodHeap:
      mov      [hHeap], eax
;выделение памяти в куче
      mov      ebx, [flength]
      inc      ebx
      invoke   HeapAlloc, [hHeap], HEAP_ZERO_MEMORY, ecx
      cmp      eax, NULL
      jne      goodAlloc
      invoke   printf, "Error alloc memory"
      jmp      exit

goodAlloc:
      mov       [fbuf], eax
      invoke    ReadFile, [hFile], [fbuf], [flength], cntread, NULL
      mov       esi,[fbuf]
      add       esi, [flength]
      mov       byte [esi], 0
      cinvoke   printf, "File : %s %s", [fbuf], <10,13,0>
;цикл
      mov       esi, [fbuf]
      mov       ecx, [flength]
      add       ecx, esi

S:
      cmp       byte[esi], 'a'
      je        A
      cmp       byte[esi], 'b'
      je        B
      jmp       Err1

A:
      inc       esi
      cmp       byte[esi], 'a'
      je        A
      cmp       byte[esi], 'b'
      je        B
      jmp       Err1

B:
      inc       esi
      cmp       byte[esi], 'a'
      je        ACK
      cmp       byte[esi], 'b'
      je        S
      jne       Err1

ACK:
      inc       esi
      cmp       byte[esi], 'a'
      jmp       ACK
      cmp       byte[esi], 'b'
      jmp       SBCK
      cmp       esi, ecx
      je        K
      jne       Err1

SBCK:
      inc       esi
      cmp       byte[esi],'a'
      je        ACK
      cmp       byte[esi],'b'
      je        SBCK
      cmp       esi, ecx
      je        K
      jne       Err1


K:
     ; invoke    WriteConsole,[stdout],cMsg2,lencMsg2, NULL, NULL
      jmp       exit
Err1:
     ; invoke    WriteConsole,[stdout],cMsg3,lencMsg3, NULL, NULL
;выход с задержкой
exit:
      invoke    ReadConsole,[stdin],buffer,lenbuf,cntread,NULL
      invoke    ExitProcess,0
;секция импорта
     section    '.idata' import data readable writeable
     library    kernel32,'KERNEL32.DLL',\
                msvcrt, 'msvcrt.DLL'
     import     kernel32,\
                GetStdHandle,'GetStdHandle',\
                WriteConsole,'WriteConsoleA',\
                ReadConsole,'ReadConsoleA',\
                ExitProcess,'ExitProcess',\
                HeapCreate,'HeapCreate',\
                HeapDestroy,'HeapDestroy',\
                HeapAlloc,'HeapAlloc',\
                HeapFree,'HeapFree',\
                CreateFile, 'CreateFileA',\
                ReadFile, 'ReadFile',\
                WriteFile, 'WriteFile',\
                GetFileSize, 'GetFileSize',\
                CloseHandle, 'CloseHandle'
      import     msvcrt, scanf,'scanf',\
                printf,'printf',getchar,'getchar'