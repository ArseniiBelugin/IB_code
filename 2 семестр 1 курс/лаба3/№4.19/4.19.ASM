;тип приложения
     format     PE      console
;точка входа
     entry start
;подключение макробиблиотек
     include 'WIN32AX.INC' ;invoke
;секция данных
     section    '.data' data readable writeable

Array           dd      ?;адрес памяти в куче
n               dd      ?
hHeap           dd      ?;дескриптор кучи
s               dd      ?;размер свободного места
temp            dd      ?
count           dd      ?
turn            dd      ?


;секция кода
     section    '.code' code readable executable
start:
       cinvoke printf, "S = N = "
       cinvoke scanf, "%d %d", s, n
       mov     [count], 0
;работа с кучей
       invoke   HeapCreate, 0, 0, 0
       cmp      eax, NULL
       jne      goodHeap
       cinvoke  printf, "%s", <"Failed create heap",10,13,0>
       jmp      exit
goodHeap:
       mov      [hHeap], eax
;выделение памяти в куче
       mov      ecx, [n]
       sal      ecx, 2
       invoke   HeapAlloc, [hHeap], HEAP_ZERO_MEMORY, ecx
       mov      [Array], eax
;ввод массива
       push     dword [n]
       push     dword [Array]
       call     readArray
;сортировка
       stdcall  sort, [Array], [n]


;сохранение в память
;       mov      eax, [n]
;       mov      ebx, 2
;       cdq
;       idiv     ebx
       mov      ecx, [n]
       mov      eax, 0; указатель на начало массива
       mov      esi, [n]; указатель на конец массива
       dec      esi
       mov      edi, [Array]
       mov      [turn], 0



l1:
       cmp      [turn], 0
       jne      min
       mov      ebx, [s]
       mov      edx, [edi + eax * 4]
       cmp      edx, 0
       je       nmax
       sub      ebx, edx
       cmp      ebx, 0
       jl       nmax
       mov      [turn], 1
       inc      [count]
       mov      [temp], edx
       sub      [s], edx
nmax:
       inc      eax
       jmp      next
min:
       mov      ebx, [s]
       mov      edx, [edi + esi * 4]
       cmp      edx, 0
       je       nmin
       sub      ebx, edx
       cmp      ebx, 0
       jl       nmin
       mov      [turn], 0
       inc      [count]
       mov      [temp], edx
       sub      [s], edx
nmin:
       dec      esi

next:
       loop     l1


;освобождение памяти и разрушение кучи
output:
       pusha
       invoke   HeapFree, [hHeap], 0, [Array]
       invoke   HeapDestroy,[hHeap]
       cinvoke  printf, "%s", <"Answer",10,13,0>
       popa
       cinvoke  printf, "%d %d", dword [count], dword [temp]
;выход с задержкой
exit:
       cinvoke   getchar
       cinvoke   getchar
       invoke    ExitProcess,0




proc          writeArray
      ;пролог                       ;ebp             +0
      push       ebp                ;адрес возврата  +4
      mov        ebp, esp           ;адрес массива   +8
      pusha                         ;n               +12

      mov       ecx, [ebp + 12]
      mov       esi, [ebp + 8]

wrArr:
      push      ecx
      push      esi
      cinvoke   printf, "%d ",dword [esi]
      pop       esi
      pop       ecx
      add       esi, 4
      loop      wrArr

      ;эпилог
      popa
      pop        ebp
      ret        8
      endp

;подпрограмма ввода массива
proc          readArray
      ;пролог                       ;ebp             +0
      push       ebp                ;адрес возврата  +4
      mov        ebp, esp           ;адрес массива   +8
      pusha                         ;n               +12

      mov       ecx, [ebp + 12]
      mov       esi, [ebp + 8]

rdArr:
      push      ecx
      push      esi
      cinvoke   scanf, "%d", esi
      pop       esi
      pop       ecx
      add       esi, 4
      loop      rdArr

      ;эпилог
      popa
      pop        ebp
      ret        8
      endp





proc  sort      Massiv, cnt
      pusha

      mov       esi, [Massiv]
      mov       ecx, [cnt]
      dec       ecx

outL:
      mov       eax,[esi]
      mov       ebx, esi
      mov       edi, esi
      add       edi, 4
      push      ecx
inL:
      cmp       eax, [edi]
      jge       inLend
      mov       eax, [edi]
      mov       ebx, edi

inLend:
      add       edi, 4
      loop      inL
      mov       edx, [esi]
      mov       [esi], eax
      mov       [ebx], edx
      pop       ecx
      add       esi, 4

      loop      outL
      popa
      ret
      endp


;секция импорта
     section    '.idata' import data readable writeable
     library    kernel32,'KERNEL32.DLL',\
                msvcrt, 'msvcrt.DLL'
     import     kernel32,\
                ExitProcess,'ExitProcess',\
                GetProcessHeap,'GetProcessHeap',\
                HeapCreate,'HeapCreate',\
                HeapDestroy,'HeapDestroy',\
                HeapAlloc,'HeapAlloc',\
                HeapFree,'HeapFree'
     import     msvcrt, scanf,'scanf',\
                printf,'printf',getchar,'getchar'