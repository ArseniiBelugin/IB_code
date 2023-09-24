;тип приложения
     format     PE      console
;точка входа
     entry start
;подключение макробиблиотек
     include 'WIN32A.INC' ;invoke
;секция данных
     section    '.data' data readable writeable
maxSize         =       100
Array           dd      maxSize dup(?)
n               dd      ?
min             dd      ?

cMsg1           db      ' n = '
lencMsg1        =       $-cMsg1
cMsg2           db      'Input array :', 10, 13
lencMsg2        =       $-cMsg2
cMsg3           db      'Modified array :', 10, 13
lencMsg3        =       $-cMsg3
cMsg4           db      'Error input'
lencMsg4        =       $-cMsg4
endl            db      10,13
lenendl         =       $ - endl

stdin           dd  ?
stdout          dd  ?

buffer          db  15 dup(?)
lenbuf          = $ - buffer
cntread         dd  ?
errorIn         dd ?

;секция кода
     section    '.code' code readable executable
start:
      invoke    GetStdHandle,STD_INPUT_HANDLE
      mov       [stdin],eax
      invoke    GetStdHandle,STD_OUTPUT_HANDLE
      mov       [stdout],eax

;ввод количества элементов в массиве
      invoke     WriteConsole,[stdout],cMsg1,lencMsg1,NULL,NULL
      stdcall    readInt, n, errorIn
      cmp        [errorIn], 0
      jne        errIn
      cmp        [n], 0
      jle        errIn
      cmp        [n], maxSize
      jg         errIn

;ввод элементов массива
      invoke     WriteConsole,[stdout],cMsg2,lencMsg2,NULL,NULL
      mov        ecx, [n]
      mov        esi, Array
readIn:
      stdcall   readInt, esi, errorIn
      cmp       [errorIn], 0
      jne       errIn
      add       esi, 4
      loop      readIn

;поиск минимума
      mov     ecx,[n]
      xor     esi, esi ;esi - индекс
      xor     eax, eax
      mov     eax, dword [Array]
minArr:
      cmp     eax, dword [Array + 4 * esi]
      jl     next
      mov     eax, dword [Array + 4 * esi]
next:
      inc     esi
      loop    minArr
;сохранение минимума
      mov     [min], eax
;изменение массива
      mov     ecx,[n]
      xor     esi, esi ;esi - индекс
      mov     eax, [min]
      mov     ebx, 2
      imul    ebx
chAr:
      cmp     eax, dword [Array + 4 * esi]
      jle     change
      sal     dword [Array + 4 * esi], 1
change:
      inc     esi
      loop    chAr

;вывод "Modified array"
      pusha
      invoke     WriteConsole,[stdout],cMsg3,lencMsg3,NULL,NULL
      popa
;вывод массива
      mov       ecx, [n]
      mov       esi, [n]
      dec       esi
      xor       eax, eax
wrAr:
      stdcall   writeInt, dword [Array + 4 * esi]
      push      ecx
      push      esi
      invoke    WriteConsole,[stdout],endl,lenendl,NULL,NULL
      pop       esi
      pop       ecx
      dec       esi
      loop      wrAr

      jmp        exit
errIn:
      invoke     WriteConsole,[stdout],cMsg4,lencMsg4,NULL,NULL
;выход с задержкой
exit:
      invoke    ReadConsole,[stdin],buffer,lenbuf,cntread,NULL
      invoke    ExitProcess,0


;находим минимум
;умножаем на 2 все элементы, которые меньше чем удвоенный минимум
;выводим массив в обратном порядке
;7, 5, 9, 4, 8, 7, 14, 9

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
      jle       inLend
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