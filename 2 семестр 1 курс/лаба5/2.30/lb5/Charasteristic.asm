public _Charasteristic
.586
.model flat
.code
_Charasteristic    proc
        push    ebp
        mov     ebp,esp
        push    ecx
        push    esi
        push    edi
        push    ebx
        push    edx

        xor ecx,ecx
        xor eax,eax

    C1:
        cmp ecx, [ebp+12]
        je  ex
        push ecx
        xor ecx,ecx

    C2:
        cmp ecx,[ebp+16]
        je  C2pop
        push ecx
        xor ecx,ecx
        mov ebx,[ebp+12]
        sub ebx,[esp+4]
        inc ebx
        inc ecx

    C3:
        cmp ecx,ebx
        je C3pop
        push ecx
        xor ecx,ecx
        mov edx,[ebp+16]
        sub edx,[esp+4]
        inc edx
        inc ecx

    C4:
        cmp ecx,edx
        je C4pop
        push ecx
        mov ecx,[esp+12]
        push ebx
        push edx
        mov ebx,[esp+12]
        add ebx,[esp+20]
        mov edx,[esp+8]
        add edx,[esp+16]
        mov edi,[ebp+8]
        jmp R1

    R1:
        cmp ecx,ebx
        je  valid
        mov esi,[edi+ecx*4]
        push ecx      
        mov ecx,[esp+20]
        push eax
        push edx
        mov eax,4
        mul ecx
        add esi,eax
        pop edx
        pop eax
        

    R2: 
        cmp ecx,edx
        je R2pop
        inc ecx
        push eax
        mov eax,[esi]
        cmp eax,0
        jne sledR2
        pop eax
        add esi,4
        jmp novalidref

    sledR2:
        pop eax
        add esi,4
        jmp R2

    C2pop:
        pop ecx
        inc ecx
        jmp C1
    C3pop:
        pop ecx
        inc ecx
        jmp C2
    C4pop:
        pop ecx
        inc ecx
        jmp C3
    R1pop:
        pop edx
        pop ebx
        pop ecx
        inc ecx
        jmp C4
    R2pop:
        pop ecx
        inc ecx
        jmp R1



    valid:
        mov ebx, [esp+8]
        push eax
        mov eax, [esp+16]
        push edx
        mul ebx
        pop edx
        mov ebx, eax
        pop eax
        cmp eax, ebx
        jg  validref
        mov eax, ebx
        jmp validref

    validref:
        pop edx
        pop ebx
        pop ecx
        inc ecx
        jmp C4

    novalidref:
        pop ecx
        pop edx
        pop ebx
        pop ecx
        inc ecx
        jmp C4

        ex:

        pop        edx
        pop        ebx
        pop        edi
        pop        esi
        pop        ecx
        pop        ebp
        ret
_Charasteristic    endp
end