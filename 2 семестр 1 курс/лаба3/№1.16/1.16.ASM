;тип приложения
     format     PE      console
;точка входа
     entry start
;подключение макробиблиотек
     include 'WIN32A.INC' ;invoke
;секция данных
     section    '.data' data readable writeable


cMsg1           db      'A = '
lencMsg1        =       $-cMsg1
cMsg2           db      'C = '
lencMsg2        =       $-cMsg2
cMsg3           db      'D = '
lencMsg3        =       $-cMsg3
cMsg4           db      'Error input'
lencMsg4        =       $-cMsg4
cMsg5           db      'Division by 0 not allowed'
lencMsg5        =       $-cMsg5

stdin           dd  ?
stdout          dd  ?

A               dd  ?
C               dd  ?
D               dd  ?
result          dd  ?
buffer          db  15 dup(?)
lenbuf          = $ - buffer
cntread         dd  ?
errorIn         dd  ?

;секция кода
     section    '.code' code readable executable
start:
      invoke    GetStdHandle,STD_INPUT_HANDLE
      mov       [stdin],eax
      invoke    GetStdHandle,STD_OUTPUT_HANDLE
      mov       [stdout],eax

      invoke     WriteConsole,[stdout],cMsg1,lencMsg1,NULL,NULL
      stdcall    readInt, A, errorIn
      cmp        [errorIn], 0
      jne        errIn
      cmp        [A], 2
      je         errDiv

      invoke     WriteConsole,[stdout],cMsg2,lencMsg2,NULL,NULL
      stdcall    readInt, C, errorIn
      cmp        [errorIn], 0
      jne        errIn

      invoke     WriteConsole,[stdout],cMsg3,lencMsg3,NULL,NULL
      stdcall    readInt, D, errorIn
      cmp        [errorIn], 0
      jne        errIn

      xor        eax, eax
      mov        eax, [D]
      mov        ebx, 4
      imul       ebx
      add        eax, [C]
      sub        eax, 123
      mov        [result], eax
      mov        eax, [A]
      mov        bx, 2
      cdq
      idiv       bx
      neg        eax
      add        eax, 1
      mov        ebx, eax
      mov        eax, [result]
      cdq
      idiv       ebx
      mov        [result], eax

      stdcall    writeInt, [result]
      jmp        exit

errIn:
      invoke     WriteConsole,[stdout],cMsg4,lencMsg4,NULL,NULL
      jmp        exit
errDiv:
      invoke     WriteConsole,[stdout],cMsg5,lencMsg5,NULL,NULL
      jmp        exit
;выход с задержкой
exit:
      invoke    ReadConsole,[stdin],buffer,lenbuf,cntread,NULL
      invoke    ExitProcess,0


; a = -4 c = 123 d = 3 answer = 4
; a = 4  c = 456 d = 10 answer = - 373




proc  writeInt  number
;пролог
      push      eax
      push      edx
      push      esi
      push      ecx
      push      edi
      push      ebx
;обработка
      mov       eax, [number]
      mov       esi, buffer
      xor       edi, edi
      xor       ecx, ecx
      mov       ebx, 10
;знак
      cmp       eax, 0
      jge       m1
      mov       [esi], byte '-'
      inc       esi
      inc       edi
      neg       eax
m1:
;получение цифр
      cdq
      div       ebx
      push      edx
      inc       ecx
      cmp       eax, 0
      jne       m1
;формируем строку
      add  edi, ecx
m2:   pop  edx
      add  dl, '0'
      mov  [esi], dl
      inc  esi
      loop m2

      invoke     WriteConsole,[stdout], buffer, edi, NULL, NULL
;эпилог
      pop       ebx
      pop       edi
      pop       ecx
      pop       esi
      pop       edx
      pop       eax

      ret
      endp
proc    readInt number, errorIn
        pusha
        invoke  ReadConsole, [stdin],buffer, lenbuf, cntread, NULL
        mov     ecx, [cntread]
        sub     ecx, 2
        xor     eax, eax
        mov     esi, buffer
        mov     edi, 10
        xor     ebx, ebx
        cmp     [esi], byte '-'
        jne     m3
        inc     esi
        dec     ecx

m3:     mov     bl,[esi]
        sub     bl, '0'
        cmp     bl, 0
        jl      err1
        cmp     bl, 9
        jg      err1
        imul    edi
        jc      err2
        add     eax,ebx
        jc      err2
        jo      err2
        inc     esi
        loop    m3
        cmp     [buffer],'-'
        jne     m4
        neg     eax
m4:     mov     edx, [number]
        mov     [edx], eax
        mov     ebx, 0
        jmp     m5

err1:   mov     ebx, 1
        jmp     m5
err2:   mov     ebx, 2
m5:     mov     edx,[errorIn]
        mov     [edx], ebx

        popa
        ret
        endp
;секция импорта
     section    '.idata' import data readable writeable
     library    kernel32,'KERNEL32.DLL'
     import     kernel32,\
                GetStdHandle,'GetStdHandle',\
                WriteConsole,'WriteConsoleA',\
                ReadConsole,'ReadConsoleA',\
                ExitProcess,'ExitProcess'